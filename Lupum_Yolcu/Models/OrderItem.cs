﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lupum_Yolcu.Models
{
    public class OrderItem
    {
        public int Id { get; set; }

        [Required]
        public int OrderId { get; set; }

        [Required]
        public int ProductId { get; set; }

       

        [Column(TypeName = "money")]
        [Required]
        public decimal Price { get; set; }

        [StringLength(50)]
        public string Color { get; set; }

        [Required]
        public int Count { get; set; }

        [Required]
        public int Gift { get; set; }

        [Required]
        public byte Discount { get; set; }
        

        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }

    }


}