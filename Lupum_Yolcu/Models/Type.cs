using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Lupum_Yolcu.Models
{
    public class Type
    {
        public Type()
        {
            Products = new HashSet<Product>();
        }
        public int Id { get; set; }

        public bool Status { get; set; }

        [StringLength(50), Required]
        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; }

    }


}