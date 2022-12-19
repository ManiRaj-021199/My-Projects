using Microsoft.AspNetCore.Components;
using Shop.Admin.Services.AdminPanel;
using Shop.DataModels.CustomModels;

namespace Shop.Admin.Pages
{
    public class CategoryBase : ComponentBase
    {
        #region Properties
        [CascadingParameter]
        public EventCallback EventNotify { get; set; }

        [Inject]
        public IAdminPanelService? AdminPanelService { get; set; }

        public CategoryModel? Category { get; set; }
        public List<CategoryModel> CategoryList { get; set; } = null!;
        #endregion

        #region Protecteds
        protected override async Task OnInitializedAsync()
        {
            this.Category = new CategoryModel();
            await GetCategories();
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if(firstRender) await this.EventNotify.InvokeAsync();
        }

        protected async Task SaveCategory()
        {
            await this.AdminPanelService!.SaveCategory(this.Category);
        }

        protected void ClearForm()
        {
            this.Category = new CategoryModel();
        }

        protected async Task GetCategories()
        {
            this.CategoryList = (await this.AdminPanelService!.GetCategories())!;
        }

        protected async Task EditCategory(CategoryModel category)
        {
            
        }

        protected async Task DeleteCategory(CategoryModel category)
        {

        }
        #endregion
    }
}