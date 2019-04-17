using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lupum_Yolcu.Models
{
    public class Product
    {
        public Product()
        {
            ProductNetworkPrices = new HashSet<ProductNetworkPrice>();
            ProductColors = new HashSet<ProductColor>();
            OrderItems = new HashSet<OrderItem>();
        }
        public int Id { get; set; }

        public bool Status { get; set; }

        [StringLength(50), Required]
        public string Name { get; set; }

        [Column(TypeName = "money")]
        [Required]
        public decimal Price { get; set; }


        public int  GiftCount { get; set; } ///yoxdursa 0 yaz

        public string  Colors { get; set; }

        [Required]
        public int TypeId { get; set; }

        public virtual ICollection<ProductNetworkPrice> ProductNetworkPrices { get; set; }
        public virtual ICollection<ProductColor> ProductColors { get; set; }
        public virtual Type Type { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }

    }
    public class ProductColor
    {
        public int Id { get; set; }

        [StringLength(50), Required]
        public string Name { get; set; }

        [Required]
        public int ProductId { get; set; }

        public virtual Product Product { get; set; }

    }


}