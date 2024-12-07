using Hangfire.Dashboard;
using WildlifePoaching.API.Models.Enums;

namespace WildlifePoaching.API.Filters
{
    public class HangfireAuthorizationFilter : IDashboardAuthorizationFilter
    {
        public bool Authorize(DashboardContext context)
        {
            var httpContext = context.GetHttpContext();
            // Only allow authenticated users with Admin role
            return httpContext.User.Identity?.IsAuthenticated == true &&
                   httpContext.User.IsInRole(UserRole.Admin.ToString());
        }
    }
}
