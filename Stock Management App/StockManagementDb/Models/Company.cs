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
    public partial class Company
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3)]
        [DisplayName(" Company Name")]
        [Index("Ix_CompanyName",1, IsUnique = true)]
       // [Remote("IsNameExist", "Categories", ErrorMessage = "Category Name Already Exists")]
        public string CompanyName { get; set; }

        public IEnumerable<Item> Items { get; set; }
        public IEnumerable<StockOut> StockOuts { get; set; } 
    }
    public partial class Company : IValidatableObject
    {
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            StockDbContext db = new StockDbContext();

            var dbModel = db.Companys.FirstOrDefault(x => x.CompanyName == CompanyName );

            if (dbModel != null)
            {
                ValidationResult error = new ValidationResult("Company name alrady exist", new[] { "CompanyName" });
                yield return error;
            }

        }
    }
}
