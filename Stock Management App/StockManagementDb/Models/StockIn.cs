using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagementDb.Models
{
    public class StockIn
    {
        public int Id { get; set; }

        [Required]
        [DisplayName(" Category Name")]
        public int CategoryId { get; set; }

        [Required]
        [DisplayName("Item Name")]
        public int ItemId { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        [DisplayName("Stock-In-Quentity")]
        public double StockInQuentity { get; set; }

        public virtual Category Category { get; set; }
        public virtual Item Item { get; set; }
    }
}
