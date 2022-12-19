using System.ComponentModel.DataAnnotations;

namespace Shop.DataModels.CustomModels
{
    public class CategoryModel
    {
        #region Properties
        public int Id { get; set; }

        [Required(ErrorMessage = "Category Name is Required.")]
        public string Name { get; set; }
        #endregion
    }
}