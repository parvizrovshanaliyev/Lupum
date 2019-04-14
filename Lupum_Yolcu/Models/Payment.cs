using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lupum_Yolcu.Models
{
    public class Payment
    {
        public int Id { get; set; }

        public State Status { get; set; }

        [Required]
        public int MarketId { get; set; }

        [Column(TypeName = "money")]
        [Required]
        public decimal Value { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public virtual Market Market { get; set; }


    }


}