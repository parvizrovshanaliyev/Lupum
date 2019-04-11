using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lupum_Yolcu.Models
{
    public class User
    {
        public User()
        {
            Markets = new HashSet<Market>();
        }
        public int Id { get; set; }


        public bool Status { get; set; }

        [StringLength(50)]
        public string Fullname { get; set; }

        [StringLength(50), Required]
        public string Email { get; set; }

        [StringLength(200)]
        public string Password { get; set; }

        [StringLength(200)]
        public string Token { get; set; }

        [Required]
        public int GroupId { get; set; }

        public virtual ICollection<Market> Markets { get; set; }
        public virtual Group Group { get; set; }

    }
}