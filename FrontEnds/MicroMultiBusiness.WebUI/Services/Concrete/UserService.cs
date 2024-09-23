using MicroMultiBusiness.DTOLayer.IdentityDTOs.UserDTOs;
using MicroMultiBusiness.WebUI.Models;
using MicroMultiBusiness.WebUI.Services.Abstract;
using Newtonsoft.Json;

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

        public async Task<List<ResultUserDTO>> GetUsersList()
        {
            var response = await _httpClient.GetAsync("http://localhost:5001/api/users/GetUsersList");
            var jsonData = await response.Content.ReadAsStringAsync();
            var valuesList = JsonConvert.DeserializeObject<List<ResultUserDTO>>(jsonData);
            return valuesList;
        }
    }
}
