using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagementDb.Models
{
    public class StockOut
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("Company Name")]
        public int CompanyId { get; set; }

        [Required]
        [DisplayName("Item Name")]
        public int ItemId { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        [DisplayName("Quantity")]
        public double Quentity { get; set; }

        public virtual Company Company { get; set; }
        public virtual Item Item { get; set; }
       
    }
}
