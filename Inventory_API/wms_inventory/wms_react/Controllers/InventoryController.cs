using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using wms_react.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace wms_react.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private ITrackingRepository trackingRepository;
        private ITaskListRepository taskingRepository;


        public InventoryController(ITrackingRepository _trackingRepository, ITaskListRepository _taskingRepository)
        {
            trackingRepository = _trackingRepository;
            taskingRepository = _taskingRepository;
        }

        /******************************** TRACKING API ********************************/
        /*
         
             Retrieve Tracking by TrackingID
             Retrieve All Tracking
             Add Tracking
             Delete Tracking
             Update Tracking
         
         */

        // GET api/tracking/<InventoryController>/123 (Tracking Id)
        [HttpGet("tracking/{trackingId}")]
        public Tracking Get_Tracking(string trackingId)
        {
            var get_tracking = trackingRepository.GetTracking(trackingId);
            var task_obj = taskingRepository.GetTaskList(trackingId);

            get_tracking.task_obj = task_obj;
            return get_tracking;
        }

        // api/tracking/
        [HttpGet("tracking")]
        public IEnumerable<Tracking> GetAll_Tracking()
        {
            return trackingRepository.GetAllTracking();
        }

        // POST api/tracking/<InventoryController>
        [HttpPost("tracking")]
        public Tracking Add_Tracking([FromBody] Tracking new_track)
        {
            return trackingRepository.AddTracking(new_track);
        }

        // PUT api/tracking/<InventoryController>/5
        [HttpPut("tracking")]
        public Tracking Update_Tracking([FromBody] Tracking new_track)
        {
            return trackingRepository.UpdateTracking(new_track);
        }

        // DELETE api/tracking/<InventoryController>/5
        [HttpDelete("tracking/{id}")]
        public Tracking Delete_Tracking(int id)
        {
            return trackingRepository.DeleteTracking(id);
        }

        /******************************** END OF TRACKING API ********************************/


        /******************************** TASKLIST API ********************************/
        // GET api/tracking/<InventoryController>/123 (Tracking Id)
        [HttpGet("tasklist/{trackingId}")]
        public TaskList Get_Task(string trackingId)
        {
            return taskingRepository.GetTaskList(trackingId);
        }
        /******************************** END OF TRACKING API ********************************/
    }
}
