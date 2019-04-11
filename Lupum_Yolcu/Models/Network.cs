using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Lupum_Yolcu.Models
{
    public class Network
    {
        public Network()
        {
            ProductNetworkPrices = new HashSet<ProductNetworkPrice>();
        }

        public int Id { get; set; }

        [StringLength(50),Required]
        public string Name { get; set; }

        public virtual ICollection<ProductNetworkPrice> ProductNetworkPrices { get; set; }

    }


}