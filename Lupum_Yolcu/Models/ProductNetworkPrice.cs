using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lupum_Yolcu.Models
{
    public class ProductNetworkPrice
    {
        public int Id { get; set; }
        [Required]
        public int ProductId { get; set; }

        [Required]
        public int NetworkId { get; set; }

        [Column(TypeName = "money")]
        [Required]
        public decimal Price { get; set; }

        public virtual Product Product { get; set; }
        public virtual Network Network { get; set; }
    }


}