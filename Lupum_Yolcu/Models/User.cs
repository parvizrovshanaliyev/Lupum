using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lupum_Yolcu.Models
{
    public class User
    {
        public int Id { get; set; }


        public bool Status { get; set; }

        [StringLength(50),Required]
        public string Fullname { get; set; }

        [StringLength(50), Required]
        public string Email { get; set; }

        [StringLength(200), Required]
        public string Password { get; set; }

        [Required]
        public int GroupId { get; set; }


        public virtual Group Group { get; set; }

    }
}