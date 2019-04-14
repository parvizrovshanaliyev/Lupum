using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lupum_Yolcu.Models
{
    public class Role
    {

        public int Id { get; set; }
        
        [Required]
        public int GroupId { get; set; }

        [Required]
        public int ActionId { get; set; }

        
        public bool CanView { get; set; }

        
        public bool CanAdd { get; set; }

        
        public bool CanEdit { get; set; }

        
        public bool CanDelete { get; set; }

        
        public bool Ownerdata { get; set; }


        public virtual Group Group { get; set; }
        public virtual Action Action { get; set; }

    }
}