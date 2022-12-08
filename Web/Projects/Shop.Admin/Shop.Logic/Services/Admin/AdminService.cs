using Shop.DataModels.CustomModels;

namespace Shop.Logic.Services.Admin
{
    public class AdminService : IAdminService
    {
        #region Publics
        public LoginResponseModel AdminLogin(LoginModel loginModel)
        {
            LoginResponseModel loginResponseModel = new LoginResponseModel
                                                    {
                                                        Status = false,
                                                        Message = "Incorrect Id / Password"
                                                    };

            return loginResponseModel;
        }
        #endregion
    }
}