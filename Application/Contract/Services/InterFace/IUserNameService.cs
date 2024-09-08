

namespace Application.Contract.Services.InterFace
{
    public interface IUserNameService
    {
        public Task<string> GetUserName(string userId);
    }
}
