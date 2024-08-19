using MicroMultiBusiness.DTOLayer.IdentityDTOs.LoginDTOs;

namespace MicroMultiBusiness.WebUI.Services.Abstract
{
    public interface IIdentityService
    {
        Task<bool> SignIn(SignInDTO signInDTO);
    }
}
