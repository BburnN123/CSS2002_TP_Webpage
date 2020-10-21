using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace wms_inventory.Models
{
    public interface ITrackingRepository
    {
        // Get all Tracking Details
        IEnumerable<Tracking> GetAllTracking();
        // Get Tracking Details
        Tracking GetTracking(string id);
        // Add New Tracking Details
        Tracking AddTracking(Tracking track);
        // Update Tracking Details
        Tracking UpdateTracking(Tracking new_track);
        // Delete Tracking Details
        Tracking DeleteTracking(int id);
    }
}
