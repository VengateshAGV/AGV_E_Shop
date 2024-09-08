

using Application.Contract.Services.InterFace;
using Microsoft.AspNetCore.Identity;
using Shop.ModelArea.Models;

namespace Application.Contract.Services
{
    public class UserNameService : IUserNameService
    {
        private readonly UserManager<UserID> _manager;

        public UserNameService(UserManager<UserID> manager)
        {
            _manager = manager;
        }

        public async Task<string> GetUserName(string userId)
        {
            if (String.IsNullOrWhiteSpace(userId))
            {
                return String.Empty;
            }

            var user = await _manager.FindByNameAsync(userId);

            if (user != null)
            {
                return user.UserName;
            }

            return "NA";
        }
    }
}
