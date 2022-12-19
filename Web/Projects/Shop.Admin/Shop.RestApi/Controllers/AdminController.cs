using Microsoft.AspNetCore.Mvc;
using Shop.DataModels.CustomModels;
using Shop.Logic.Services.Admin;

namespace Shop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        #region Fields
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IAdminService adminService;
        #endregion

        #region Constructors
        public AdminController(IAdminService adminService, IWebHostEnvironment webHostEnvironment)
        {
            this.adminService = adminService;
            this.webHostEnvironment = webHostEnvironment;
        }
        #endregion

        #region Publics
        [HttpPost]
        [Route("AdminLogin")]
        public IActionResult AdminLogin(LoginModel loginModel)
        {
            LoginResponseModel data = adminService.AdminLogin(loginModel);

            return Ok(data);
        }

        [HttpPost]
        [Route("SaveCategory")]
        public IActionResult SaveCategory(CategoryModel categoryModel)
        {
            var data = adminService.SaveCategory(categoryModel);
            return Ok(data);
        }

        [HttpGet]
        [Route("GetCategories")]
        public IActionResult GetCategories()
        {
            var data = adminService.GetCategories();
            return Ok(data);
        }
        #endregion
    }
}