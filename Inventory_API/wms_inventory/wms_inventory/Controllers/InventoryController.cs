using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using wms_inventory.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace wms_inventory.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private ITrackingRepository trackingRepository;

        public InventoryController(ITrackingRepository _trackingRepository)
        {
            trackingRepository = _trackingRepository;
        }

        // GET api/<InventoryController>/id
        [HttpGet("{id}")] 
        public Tracking Get(string id)
        {
            return trackingRepository.GetTracking(id);
        }

        [HttpGet]
        public IEnumerable<Tracking> GetAll()
        {
            return trackingRepository.GetAllTracking();
        }

        // POST api/<InventoryController>
        [HttpPost]
        public Tracking Add_Tracking([FromBody] Tracking new_track)
        {
            return trackingRepository.AddTracking(new_track);
        }

        // PUT api/<InventoryController>/5
        [HttpPut]
        public Tracking Update_Tracking([FromBody] Tracking new_track)
        {
            return trackingRepository.UpdateTracking(new_track);
        }

        // DELETE api/<InventoryController>/5
        [HttpDelete("{id}")]
        public Tracking Delete_Tracking(int id)
        {
            return trackingRepository.DeleteTracking(id);
        }
    }
}
