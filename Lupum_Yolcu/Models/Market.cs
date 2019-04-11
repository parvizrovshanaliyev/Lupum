using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lupum_Yolcu.Models
{
    public class Market
    {
        public Market()
        {
            Orders = new HashSet<Order>();
            Payments = new HashSet<Payment>();
        }
        public int Id { get; set; }

        public bool Status { get; set; }

        [StringLength(50), Required]
        public string Name { get; set; }

        [StringLength(50), Required]
        public string Phone { get; set; }

        [Column(TypeName ="money")]
        public decimal? Limit { get; set; }

        [Required]
        public int UserId { get; set; }
        public int? NetworkId { get; set; }

        public virtual User User { get; set; }
        public virtual Network Network { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }

    }


}