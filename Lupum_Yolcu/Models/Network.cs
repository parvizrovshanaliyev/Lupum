using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Lupum_Yolcu.Models
{
    public class Network
    {
        public Network()
        {
            ProductNetworkPrices = new HashSet<ProductNetworkPrice>();
            Markets = new HashSet<Market>();
        }

        public int Id { get; set; }

        [StringLength(50),Required]
        public string Name { get; set; }

        public virtual ICollection<ProductNetworkPrice> ProductNetworkPrices { get; set; }
        public virtual ICollection<Market> Markets { get; set; }

    }


}