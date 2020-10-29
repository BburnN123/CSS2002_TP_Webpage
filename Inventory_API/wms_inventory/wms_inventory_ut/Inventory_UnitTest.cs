using System;
using System.Collections.Generic;
using System.Linq;
using wms_inventory.Controllers;
using wms_inventory.Models;
using Xunit;

namespace wms_inventory_ut
{

    public class Inventory_UnitTest
    {
        /******************************** TRACKING UNIT TEST ********************************/
        [Fact]
        public void Mock_RetrieveAll_Tracking()
        {
            var controller = new InventoryController(new MockTrackingRepository(), new MockTasklistRepository());
            
            var actual = controller.GetAll_Tracking();
            // In our mock repository there should be 3 dummy data
            Assert.Equal(3,actual.Count());
        }

        [Fact]
        public void Mock_Retrieve_TrackingDetails()
        {
            var controller = new InventoryController(new MockTrackingRepository(), new MockTasklistRepository());

            // Enter the delivery number
            var actual = controller.Get_Tracking("123");
            // In our mock repository tracking id 123 should return company abc
            Assert.Equal("company abc", actual.company);
        }

        [Fact]
        public void Mock_Add_New_Tracking()
        {
            var controller = new InventoryController(new MockTrackingRepository(), new MockTasklistRepository());
            var data_obj = Mock_GetTrackingDetail();

            //Add the new tracking details into the data
            controller.Add_Tracking(data_obj);
            // Check if the info is added into the details
            var actual = controller.Get_Tracking("000");

            // In our mock repository, it should return the same obj
            Assert.Equal(data_obj, actual);
        }

        [Fact]
        public void Mock_Update_Exisiting_Tracking()
        {
            var controller = new InventoryController(new MockTrackingRepository(), new MockTasklistRepository());
            var data_obj = Mock_GetTrackingDetail();

            // Update the first object in the mocking repository
            data_obj.id = 1;
            /* Current Tracking
             * id = 1, 
             * trackingId = "123",
             * company = "company abc",
             * packingSize = "small", 
             * datetime = DateTime.Parse("5/1/2008 8:30:52 AM"), 
             * packing_weight = 112
            */

            //Update the tracking details 1
            var actual = controller.Update_Tracking(data_obj);

            // In our mock repository 
            Assert.Equal(data_obj.company, actual.company);
        }

        [Fact]
        public void Mock_Delete_Exisiting_Tracking()
        {
            var controller = new InventoryController(new MockTrackingRepository(), new MockTasklistRepository());

            //Delete the tracking details id 1
            controller.Delete_Tracking(1);
            var actual = controller.GetAll_Tracking();

            // Total there was 3, now should left with 2
            Assert.Equal(2, actual.Count());  
        }
        /******************************** END OF TRACKING UNIT TEST ********************************/

        /******************************** TASKING UNIT TEST ********************************/
        [Fact]
        public void Mock_Get_Task()
        {
            var controller = new InventoryController(new MockTrackingRepository(), new MockTasklistRepository());

            // Enter the delivery number
            var actual = controller.Get_Task("123");
            // In our mock repository tracking id 123 should return company abc
            Assert.Equal("Delivered", actual.status);
        }
        /******************************** END OF TRACKING UNIT TEST ********************************/

        [Fact]
        public void Combining_Two_Classes()
        {
            var controller = new InventoryController(new MockTrackingRepository(), new MockTasklistRepository());
          

            //Tracking id : 123
            string trackingId = "123";
            // Tracking Object
            var get_tracking = controller.Get_Tracking(trackingId);

            var task_obj = controller.Get_Task(trackingId);
            //Task Object
            get_tracking.task_obj = controller.Get_Task(trackingId);

            // Assign the object into the tracking
           
            
            // Should not be null
            Assert.NotNull(get_tracking.task_obj);
        }



        // Dummy Data
        private Tracking Mock_GetTrackingDetail()
        {
            return new Tracking() {trackingId = "000", company = "company zxc", packingSize = "big", datetime = DateTime.Parse("5/1/2008 8:30:52 AM"), packing_weight = 112 };
        }

        private TaskList Mock_GetTaskDetail()
        {
            return new TaskList() {trackingId = "000", task_datetime = DateTime.Parse("5/1/2008 8:30:52 AM"), description = "Bye", status = "Bye Bye" };
        }

    }
}
