using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagementDb.Models
{
    public partial class Category
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 3)]
        [DisplayName("Category Name")]
        [Index("Ix_CategoryName",1, IsUnique = true)]
       // [Remote("IsNameExist", "Categories", ErrorMessage = "Category Name Already Exists")]
        public string CategoryName { get; set; }

        public IEnumerable<Item> Items { get; set; }
        public IEnumerable<StockIn> StockIns { get; set; } 
    }
    public partial class Category : IValidatableObject
    {
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            StockDbContext db = new StockDbContext();

            var dbModel = db.Categorys.FirstOrDefault(x => x.CategoryName == CategoryName);

            if (dbModel != null)
            {
                ValidationResult error = new ValidationResult("Category name alrady exist", new[] { "CategoryName" });
                yield return error;
            }

        }
    }
}
