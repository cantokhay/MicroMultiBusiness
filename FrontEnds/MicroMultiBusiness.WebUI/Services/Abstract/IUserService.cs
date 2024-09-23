using MicroMultiBusiness.DTOLayer.IdentityDTOs.UserDTOs;
using MicroMultiBusiness.WebUI.Models;

namespace MicroMultiBusiness.WebUI.Services.Abstract
{
    public interface IUserService
    {
        Task<UserDetailVM> GetUserInfo();
        Task<List<ResultUserDTO>> GetUsersList();
    }
}
