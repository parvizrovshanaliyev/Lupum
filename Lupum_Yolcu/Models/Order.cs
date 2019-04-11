using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Lupum_Yolcu.Models
{
    public enum State
    {
        Pending = 0,
        Accepted = 1,
        canceled = 2
    }

    public class Order
    {
        public Order()
        {
            OrderItems = new HashSet<OrderItem>();
        }
        public int Id { get; set; }

        public State Status { get; set; }

        public DateTime Date { get; set; }

        [Required]
        public int MarketId { get; set; }

        public virtual Market Market { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }

    }


}