using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donton.Common.Constants
{
    public static class ActionControls
    {
        public static List<object> Defaults
        {
            get
            {
                List<object> commands = new List<object>();
                commands.Add(new { buttonOption = new { iconCss = "e-icons e-edit", cssClass = "e-flat", type = "gridEdit" } });
                commands.Add(new { buttonOption = new { iconCss = "e-icons e-delete ", cssClass = "e-flat", type = "gridDelete" } });

                return commands;
            }
        }

        public static List<object> ViewEditDelete
        {
            get
            {
                List<object> commands = new List<object>();
                commands.Add(new { buttonOption = new { iconCss = "far fa-eye", cssClass = "e-flat", type = "gridView" } });
                commands.Add(new { buttonOption = new { iconCss = "e-icons e-edit", cssClass = "e-flat", type = "gridEdit" } });
                commands.Add(new { buttonOption = new { iconCss = "e-icons e-delete ", cssClass = "e-flat", type = "gridDelete" } });

                return commands;
            }
        }

        public static List<object> ViewDelete
        {
            get
            {
                List<object> commands = new List<object>();
                commands.Add(new { buttonOption = new { iconCss = "far fa-eye", cssClass = "e-flat", type = "gridView" } });
                commands.Add(new { buttonOption = new { iconCss = "e-icons e-delete ", cssClass = "e-flat", type = "gridDelete" } });

                return commands;
            }
        }
        public static List<object> Duplicate
        {
            get
            {
                List<object> commands = new List<object>();
                commands.Add(new { buttonOption = new { iconCss = "e-icons e-edit", cssClass = "e-flat", type = "gridEdit" } });
                commands.Add(new { buttonOption = new { iconCss = "fas fa-share", cssClass = "e-modify text-green bg-white border-none", type = "gridDuplicate" } });
                commands.Add(new { buttonOption = new { iconCss = "e-icons e-delete ", cssClass = "e-flat", type = "gridDelete" } });


                return commands;
            }
        }

        public static List<object> ViewOnly
        {
            get
            {
                List<object> commands = new List<object>();
                commands.Add(new { buttonOption = new { iconCss = "far fa-eye", cssClass = "e-flat", type = "gridView" } });
                return commands;
            }
        }

        public static List<object> DeleteOnly
        {
            get
            {
                List<object> commands = new List<object>();
                commands.Add(new { buttonOption = new { iconCss = "e-icons e-delete ", cssClass = "e-flat", type = "gridDelete" } });
                return commands;
            }
        }

        public static List<object> Approvals
        {
            get
            {
                List<object> commands = new List<object>();
                commands.Add(new { buttonOption = new { iconCss = "fas fa-user-check text-primary", cssClass = "e-flat", type = "gridApprove" } });
                commands.Add(new { buttonOption = new { iconCss = "fas fa-user-times text-danger", cssClass = "e-flat", type = "gridDisapprove" } });
                return commands;
            }
        }
        public static List<object> ExamPublish
        {
            get
            {
                List<object> commands = new List<object>();
                commands.Add(new { buttonOption = new { iconCss = "far fa-eye", cssClass = "e-flat", type = "gridView" } });
                commands.Add(new { buttonOption = new { iconCss = "fas fa-upload text-primary", cssClass = "e-flat", type = "gridPublish" } });
                return commands;
            }
        }

        public static List<string> ToolBars
        {
            get
            {
                var toolBar = new List<string>() { "Search" };
                return toolBar;
            }
        }
        public static List<object> Progress
        {
            get
            {
                List<object> commands = new List<object>();
                commands.Add(new { buttonOption = new { iconCss = "far fa-eye", cssClass = "e-flat", type = "gridView" } });
                commands.Add(new { buttonOption = new { iconCss = "fas fa-signal", cssClass = "e-modify text-green bg-white border-none", type = "gridProgress" } });
                commands.Add(new { buttonOption = new { iconCss = "e-icons e-delete ", cssClass = "e-flat", type = "gridDelete" } });


                return commands;
            }
        }
    }
}