using MicroMultiBusiness.WebUI.Models;
using MicroMultiBusiness.WebUI.Services.Abstract;

namespace MicroMultiBusiness.WebUI.Services.Concrete
{
    public class UserService : IUserService
    {
        private readonly HttpClient _httpClient;

        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<UserDetailVM> GetUserInfo()
        {
            return await _httpClient.GetFromJsonAsync<UserDetailVM>("/api/users/getuser");
        }
    }
}
