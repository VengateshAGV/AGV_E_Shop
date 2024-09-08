

using DataConnections.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Shop.ModelArea.Models;
using Shop.ModelArea.Models.Commen;
using System.Security.Claims;

namespace DataConnections.Common
{
    public static class ExtensionMethods
    {
        public static async Task<string> GetCurrentUserId(UserManager<UserID> userManager, IHttpContextAccessor contextAccessor)
        {
            var userId = contextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId == null)
            {
                var user = await userManager.GetUserAsync(contextAccessor.HttpContext.User);
                userId = user?.Id;
            }
            return userId;
        }

        public static async void saveCommonFields(this ApplicationContext context, UserManager<UserID> _userManager, IHttpContextAccessor _contextAccessor)
        {
            var userId = await GetCurrentUserId(_userManager, _contextAccessor);

            IEnumerable<BaseModel> insertEntity = context.ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Added)
                .Select(e => e.Entity)
                .OfType<BaseModel>();

            IEnumerable<BaseModel> UpdateEntity = context.ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Modified)
                .Select(e => e.Entity)
                .OfType<BaseModel>();
            foreach (var item in insertEntity)
            {
                item.CreatedOn = DateTime.UtcNow;
                item.CreatedBy = userId;
                item.ModifiOn = DateTime.UtcNow;
            }
            foreach (var item in insertEntity)
            {
                
                item.ModifiBy = userId;
                item.ModifiOn = DateTime.UtcNow;
            }

        }
    }
}
