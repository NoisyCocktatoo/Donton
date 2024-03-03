using Donton.Common.Constants;
using Donton.Common.RequestResponses.Responses;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donton.Common.Helpers
{
    public class ExcelToTable
    {
        private static bool IsDataExists(string contact, SqlConnection sqlConnection)
        {
            var sqlCommand = new SqlCommand("SELECT COUNT(*) FROM [maintenance].[Contact] WHERE ContactNumber = @ContactNumber", sqlConnection);
            sqlCommand.Parameters.AddWithValue("@ContactNumber", contact);

            int count = (int)sqlCommand.ExecuteScalar();
            return count > 0;
        }

        public static async Task<PostResponse> ReadExcelAndInsertToTable(string filePath, DBConfig setting)
        {
            var retValue = new PostResponse();
            try
            {
                var connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filePath + ";Extended Properties=Excel 12.0 XML;");
                connection.Open();

                var adapter = new OleDbDataAdapter("SELECT * FROM [Sheet1$]", connection);
                var dataTable = new DataTable();
                adapter.Fill(dataTable);

                var sqlConnection = new SqlConnection($@"Data Source={setting.Server};Initial Catalog={setting.DBName};User ID={setting.DBUser};Password={setting.DBPassword};Encrypt=false;TrustServerCertificate=true");
                sqlConnection.Open();

                var query = @"INSERT INTO
                [maintenance].[Contact] (ContactNumber, LastName,FirstName,MiddleName,Email)
                VALUES (@ContactNumber, @LastName,@FirstName,@MiddleName,@Email)";

                var sqlCommand = new SqlCommand(query, sqlConnection);
                var nullCount = 0;
                var incCount = 0;
                var dupCount = 0;
                foreach (DataRow row in dataTable.Rows)
                {
                    sqlCommand.Parameters.Clear(); 

                    string contact = row["ContactNumber"].ToString();
                    string lastName = row["LastName"].ToString();
                    string firstName = row["FirstName"].ToString();
                    string middleName = row["MiddleName"].ToString();
                    string email = row["Email"].ToString();

                    if (!IsDataExists(contact, sqlConnection))
                    {
                        if (string.IsNullOrEmpty(contact) && string.IsNullOrEmpty(lastName) && string.IsNullOrEmpty(firstName) && string.IsNullOrEmpty(middleName) && string.IsNullOrEmpty(email))
                        {
                            nullCount += 1;
                        }
                        //check if required fields are empty
                        else if (string.IsNullOrEmpty(contact) || string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(firstName))
                        {
                            incCount += 1;
                        }
                        else
                        {
                            sqlCommand.Parameters.Clear();
                            sqlCommand.Parameters.AddWithValue("@ContactNumber", contact);
                            sqlCommand.Parameters.AddWithValue("@LastName", lastName);
                            sqlCommand.Parameters.AddWithValue("@FirstName", firstName);
                            sqlCommand.Parameters.AddWithValue("@MiddleName", middleName);
                            sqlCommand.Parameters.AddWithValue("@Email", email);
                            await sqlCommand.ExecuteNonQueryAsync();
                        }
                    }
                    else
                    {
                        dupCount += 1;
                    }
                }
                connection.Close();
                sqlConnection.Close();

                if (nullCount == dataTable.Rows.Count)
                {
                    retValue.IsSuccess = false;
                    retValue.Message = BatchUploadResponse.NoDataFound;
                }
                else if (incCount > 0 && (incCount + nullCount) == dataTable.Rows.Count)
                {
                    retValue.IsSuccess = false;
                    retValue.Message = BatchUploadResponse.MissingRequiredInfo;
                }
                else if (dupCount > 0 && (dupCount + nullCount) == dataTable.Rows.Count)
                {
                    retValue.IsSuccess = false;
                    retValue.Message = BatchUploadResponse.AllExist;
                }
                else if (incCount > 0 && incCount != dataTable.Rows.Count)
                {
                    retValue.IsSuccess = true;
                    retValue.Message = BatchUploadResponse.SomeMissing;
                }
                else
                {
                    retValue.IsSuccess = true;
                    retValue.Message = BatchUploadResponse.Success;
                }
            }
            catch (Exception ex)
            {
                retValue.Message = ex.Message;
            }

            return retValue;
        }
    }
}
