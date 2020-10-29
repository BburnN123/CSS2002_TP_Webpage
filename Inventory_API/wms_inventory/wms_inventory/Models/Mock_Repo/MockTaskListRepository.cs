using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace wms_inventory.Models
{
    public class MockTasklistRepository : ITaskListRepository
    {
        private List<TaskList> tasklist;
        public MockTasklistRepository()
        {
            tasklist = new List<TaskList>()
            {
                new TaskList(){ id = 1, trackingId = "123",  task_datetime = DateTime.Parse("5/1/2008 8:30:52 AM"), description = "Hey", status = "Delivered"},
                new TaskList(){ id = 2, trackingId = "456",  task_datetime = DateTime.Parse("5/1/2008 8:30:52 AM"), description = "Hi", status = "Don't"},
                new TaskList(){ id = 3, trackingId = "789",  task_datetime = DateTime.Parse("5/1/2008 8:30:52 AM"), description = "Bye", status = "Bye Bye"}
            };
        }

        // Get Tracking Details
        public TaskList GetTaskList(string id)
        {
            // Find the id 
            return tasklist.FirstOrDefault(e => e.trackingId == id);
        }

        // Add New Tracking Details
        public TaskList AddTaskList(TaskList task)
        {

            // Retrieve the max id and increment by 1
            task.id = tasklist.Max(e => e.id) + 1;
            //Add the following details into the list
            tasklist.Add(task);

            return task;
        }

        // Return a collection of tracking details
        public IEnumerable<TaskList> GetAllTaskList()
        {
            return tasklist;
        }

        // Update Tracking Details
        public TaskList UpdateTaskList(TaskList new_task)
        {
            // Find the id of the object
            TaskList task = tasklist.FirstOrDefault(e => e.id == new_task.id);

            // If found then update
            if (task != null)
            {
                task.id = new_task.id;
                task.trackingId = new_task.trackingId;
                task.description = new_task.description;
                task.task_datetime = new_task.task_datetime;
                task.status = new_task.status;

            }
            else
            {
                throw new EntryPointNotFoundException();
            }
            return task;
        }

        // Delete Tracking Details
        public TaskList DeleteTaskList(int id)
        {
            // Find the Id
            TaskList task = tasklist.FirstOrDefault(e => e.id == id);
            if(task != null)
            {
                tasklist.Remove(task);
            }
            return task;
        }
    }
}
