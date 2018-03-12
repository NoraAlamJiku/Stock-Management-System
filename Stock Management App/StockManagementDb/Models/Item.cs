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
    public partial class Item
    {
        public int Id { get; set; }

        [Required]
        [DisplayName(" Category Name")]
        public int CategoryId { get; set; }

        [Required]
        [DisplayName(" Company Name")]
        public int CompanyId { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3)]
        [DisplayName("Item Name")]
        [Index("Ix_ItemName", IsUnique = true)]
       // [Remote("IsNameExist", "Categories", ErrorMessage = "Category Name Already Exists")]
        public string ItemName { get; set; }

        [Required]
        [DisplayName("Reorder Level")]
        public int ReorderLevel { get; set; }

        public virtual Category Category { get; set; }
        public virtual Company Company { get; set; }

        public IEnumerable<StockIn> StockIns { get; set; }
        public IEnumerable<StockOut> StockOuts { get; set; } 
       
    }
    public partial class Item : IValidatableObject
    {
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            StockDbContext db = new StockDbContext();

            var dbModel = db.Items.FirstOrDefault(x => x.ItemName == ItemName);

            if (dbModel != null)
            {
                ValidationResult error = new ValidationResult("Item name alrady exist", new[] { "ItemName" });
                yield return error;
            }

        }
    }
}
