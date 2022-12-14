using Shop.DataModels.CustomModels;

namespace Shop.Admin.Services.AdminPanel
{
    public interface IAdminPanelService
    {
        Task<LoginResponseModel?> AdminLogin(LoginModel? loginModel);
        Task<CategoryModel?> SaveCategory(CategoryModel? categoryModel);
        Task<List<CategoryModel?>> GetCategories();
    }
}