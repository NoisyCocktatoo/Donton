using Donton.Common.Constants;
using Donton.DataAccess.DataService;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using System.Security.Principal;
using UAParser;

namespace Donton.UserInterface.Pages
{
    public static class IdentityExtension
    {
        public static string GetAccountName(this IIdentity identity)
        {
            ClaimsIdentity claimsIdentity = identity as ClaimsIdentity;
            Claim claim = claimsIdentity.FindFirst(CustomClaims.FullName);
            return (claim != null) ? claim.Value : string.Empty;
        }

        public static string GetEmail(this IIdentity identity)
        {
            ClaimsIdentity claimsIdentity = identity as ClaimsIdentity;
            Claim claim = claimsIdentity.FindFirst(CustomClaims.Email);
            return (claim != null) ? claim.Value : string.Empty;
        }

        public static string GetRole(this IIdentity identity)
        {
            ClaimsIdentity claimsIdentity = identity as ClaimsIdentity;
            Claim claim = claimsIdentity.FindFirst(ClaimTypes.Role);
            return (claim != null) ? claim.Value : string.Empty;
        }

        public static string GetAccountId(this IIdentity identity)
        {
            ClaimsIdentity claimsIdentity = identity as ClaimsIdentity;
            Claim claim = claimsIdentity.FindFirst(CustomClaims.UserAccessId);
            return (claim != null) ? claim.Value : string.Empty;
        }

        public static string GetProfileId(this IIdentity identity)
        {
            ClaimsIdentity claimsIdentity = identity as ClaimsIdentity;
            Claim claim = claimsIdentity.FindFirst(CustomClaims.ProfileId);
            return (claim != null) ? claim.Value : string.Empty;
        }


        public static string GetProfileImage(this IIdentity identity)
        {
            ClaimsIdentity claimsIdentity = identity as ClaimsIdentity;
            Claim claim = claimsIdentity.FindFirst(CustomClaims.ProfilePicture);
            return (claim != null) ? claim.Value : string.Empty;
        }

        public static string GetAccountBalance(this IIdentity identity)
        {
            ClaimsIdentity claimsIdentity = identity as ClaimsIdentity;
            Claim claim = claimsIdentity.FindFirst(CustomClaims.AccountBalance);
            return (claim != null) ? claim.Value : string.Empty;
        }
    }


    public abstract partial class BasePageModel : PageModel
    {
        public string FullName
        {
            get
            {
                var _ = User.Identity.GetAccountName();
                return _;
            }
        }

        public string EmailAddress
        {
            get
            {
                var _ = User.Identity.GetEmail();
                return _;
            }
        }

        public string Role
        {
            get
            {
                var _ = User.Identity.GetRole();
                return _;
            }
        }

        public string ProfilelImage
        {
            get
            {
                var _ = User.Identity.GetProfileImage();
                return _;
            }
        }

        public long AccountId
        {
            get
            {
                var _ = User.Identity.GetAccountId();
                return Convert.ToInt64(_);
            }
        }

        public long ProfileId
        {
            get
            {
                var _ = User.Identity.GetAccountId();
                return Convert.ToInt64(_);
            }
        }


        public double AccountBalance
        {
            get
            {
                var _ = User.Identity.GetAccountId();
                return Convert.ToDouble(_);
            }
        }

        public string GetIpAddress
        {
            get
            {
                var _ = Request.HttpContext.Connection.RemoteIpAddress;
                return _.ToString();
            }
        }
        public string GetBrowser
        {
            get
            {
                var _ = Request.Headers["User-Agent"].ToString();
                var uaParser = Parser.GetDefault();
                ClientInfo c = uaParser.Parse(_);
                return c.UA.Family + " " + c.UA.Major + "." + c.UA.Minor;
            }
        }
    }
    public abstract partial class BasePageModel : PageModel
    {
        protected readonly IWebHostEnvironment env_;
        public IHttpContextAccessor accessor_;
        public IDataAccessService dataService_;
        public string RootPath
        {
            get
            {
                return env_.WebRootPath;
            }
        }

        public BasePageModel(IDependencyAggregate aggregate)
        {
            dataService_ = aggregate.DataAccessService;
            env_ = aggregate.WebHostEnvironment;
            accessor_ = aggregate.HttpContextAccessor;
        }
    }
    public interface IDependencyAggregate
    {
        IDataAccessService DataAccessService { get; }
        IWebHostEnvironment WebHostEnvironment { get; }
        IHttpContextAccessor HttpContextAccessor { get; }
        
    }

    public class DependencyAggregate : IDependencyAggregate
    {
        public IDataAccessService DataAccessService { get; set; }
        public IWebHostEnvironment WebHostEnvironment { get; }
        public IHttpContextAccessor HttpContextAccessor { get; }


        public DependencyAggregate(IDataAccessService dataAccessService, IWebHostEnvironment webHostEnvironment, IHttpContextAccessor accessor)
        {
            DataAccessService = dataAccessService;
            WebHostEnvironment = webHostEnvironment;
            HttpContextAccessor = accessor;
        }
    }

 
}
