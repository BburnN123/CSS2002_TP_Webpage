using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace wms_react.Models
{
    public interface ITaskListRepository
    {
        // Get all Tracking Details
        IEnumerable<TaskList> GetAllTaskList();
        // Get Tracking Details
        TaskList GetTaskList(string id);
        // Add New Tracking Details
        TaskList AddTaskList(TaskList task);
        // Update Tracking Details
        TaskList UpdateTaskList(TaskList new_task);
        // Delete Tracking Details
        TaskList DeleteTaskList(int id);
    }
}
