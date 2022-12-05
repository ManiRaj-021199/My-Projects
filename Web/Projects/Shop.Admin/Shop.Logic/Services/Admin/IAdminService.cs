using Shop.DataModels.CustomModels;

namespace Shop.Logic.Services.Admin
{
    public interface IAdminService
    {
        LoginResponseModel AdminLogin(LoginModel loginModel);
    }
}