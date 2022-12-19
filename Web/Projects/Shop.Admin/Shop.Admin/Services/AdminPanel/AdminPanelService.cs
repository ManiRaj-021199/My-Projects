using Newtonsoft.Json;
using Shop.DataModels.CustomModels;

namespace Shop.Admin.Services.AdminPanel
{
    public class AdminPanelService : IAdminPanelService
    {
        #region Fields
        private readonly HttpClient httpClient;
        #endregion

        #region Constructors
        public AdminPanelService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        #endregion

        #region Publics
        public async Task<LoginResponseModel?> AdminLogin(LoginModel? loginModel)
        {
            HttpResponseMessage? result = await httpClient.PostAsJsonAsync("api/admin/AdminLogin", loginModel);
            string strResultContent = await result.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<LoginResponseModel>(strResultContent);
        }

        public async Task<CategoryModel?> SaveCategory(CategoryModel? categoryModel)
        {
            HttpResponseMessage? result = await httpClient.PostAsJsonAsync("api/admin/SaveCategory", categoryModel);
            string strResultContent = await result.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<CategoryModel?>(strResultContent);
        }

        public async Task<List<CategoryModel?>> GetCategories()
        {
            return (await httpClient.GetFromJsonAsync<List<CategoryModel?>>("api/admin/GetCategories"))!;
        }
        #endregion
    }
}