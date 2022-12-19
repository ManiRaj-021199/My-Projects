using System;
using System.Collections.Generic;
using System.Linq;
using Shop.DataModels.CustomModels;
using Shop.DataModels.Models;

namespace Shop.Logic.Services.Admin
{
    public class AdminService : IAdminService
    {
        #region Fields
        private readonly ShopContext appDbContext;
        #endregion

        #region Constructors
        public AdminService(ShopContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        #endregion

        #region Publics
        public LoginResponseModel AdminLogin(LoginModel loginModel)
        {
            LoginResponseModel loginResponseModel = new LoginResponseModel();

            try
            {
                AdminInfo userData = appDbContext.AdminInfos.FirstOrDefault(adminInfo => adminInfo.Email == loginModel.Email);

                if(userData != null)
                {
                    if(userData.Password == loginModel.Password)
                    {
                        loginResponseModel.Status = true;
                        loginResponseModel.Message = $"{userData.Id}|{userData.Name}|{userData.Email}";
                    }
                    else
                    {
                        loginResponseModel.Status = false;
                        loginResponseModel.Message = "Your Password is Incorrect.";
                    }
                }
                else
                {
                    loginResponseModel.Status = false;
                    loginResponseModel.Message = "Email not registered. Please check your Email Id";
                }
            }
            catch(Exception)
            {
                loginResponseModel.Status = false;
                loginResponseModel.Message = "An error occured. Please try again.";
            }

            return loginResponseModel;
        }

        public CategoryModel SaveCategory(CategoryModel categoryModel)
        {
            try
            {
                CategoryModel category = new CategoryModel { Name = categoryModel.Name };

                appDbContext.Add(category);
                appDbContext.SaveChanges();

                return categoryModel;
            }
            catch(Exception err)
            {
                throw new Exception(err.Message);
            }
        }

        public List<CategoryModel> GetCategories()
        {
            List<Category> data = appDbContext.Categories.ToList();
            List<CategoryModel> categoryList = new List<CategoryModel>();

            foreach(Category category in data)
            {
                CategoryModel categoryModel = new CategoryModel();

                categoryModel.Id = category.Id;
                categoryModel.Name = category.Name;

                categoryList.Add(categoryModel);
            }

            return categoryList;
        }
        #endregion
    }
}