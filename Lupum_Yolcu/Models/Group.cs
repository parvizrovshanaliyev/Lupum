using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lupum_Yolcu.Models
{
    public class Group
    {
        public Group()
        {
            Users = new HashSet<User>();
            Roles = new HashSet<Role>();
        }

        public int Id { get; set; }
        
        [StringLength(50), Required]
        public string Name { get; set; }

        public virtual ICollection<User> Users { get; set; }

        public virtual ICollection<Role> Roles { get; set; }
    }
}