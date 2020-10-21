using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace wms_inventory.Models
{
    public class Tracking
    {
        public int id { get; set; }
        [Required]
        public string trackingId { get; set; }
        public string company { get; set; }
        public string packingSize { get; set; }
        public DateTime datetime { get; set; }
        public int packing_weight { get; set; }
    }
}
