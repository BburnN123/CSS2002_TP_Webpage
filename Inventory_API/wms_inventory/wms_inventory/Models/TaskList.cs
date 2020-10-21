using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace wms_inventory.Models
{
    public class TaskList
    {
        public int id { get; set; }
        public string trackingId { get; set; }
        public DateTime task_datetime { get; set; }
        public string description { get; set; }
        public string status { get; set; }
    }
}
