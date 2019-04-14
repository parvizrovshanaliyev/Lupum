using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lupum_Yolcu.Models
{
    public class Action
    {
        public Action()
        {
            Roles = new HashSet<Role>();
        }

        public int Id { get; set; }



        [StringLength(50), Required]
        public string Name { get; set; }

        [StringLength(50), Required]
        public string Controller { get; set; }

        [StringLength(50), Required]
        public string Icon { get; set; }


        public virtual ICollection<Role> Roles { get; set; } 
    }
}