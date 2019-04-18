using System.ComponentModel.DataAnnotations;

namespace Lupum_Yolcu.Models
{
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