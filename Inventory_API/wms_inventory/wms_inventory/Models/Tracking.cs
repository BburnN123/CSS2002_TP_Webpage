using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace wms_inventory.Models
{
    public class Tracking
    {
        [Key]
        public int id { get; set; }
        [Required]
        [Column(TypeName ="nvarchar(500)")]
        public string trackingId { get; set; }
        [Column(TypeName = "nvarchar(500)")]
        public string company { get; set; }
        [Column(TypeName = "int")]
        public string packingSize { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime datetime { get; set; }
        [Column(TypeName = "int")]
        public int packing_weight { get; set; }

        public TaskList task_obj { get; set; }
    }
}
