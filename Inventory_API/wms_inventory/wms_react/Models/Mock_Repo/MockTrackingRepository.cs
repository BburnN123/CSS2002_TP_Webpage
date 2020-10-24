using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace wms_react.Models
{
    public class MockTrackingRepository : ITrackingRepository
    {
        private List<Tracking> trackinglist;
        public MockTrackingRepository()
        {
            trackinglist = new List<Tracking>()
            {
                new Tracking(){ id = 1, trackingId = "123", company = "company abc", packingSize = "small", datetime = DateTime.Parse("5/1/2008 8:30:52 AM"), packing_weight = 112},
                new Tracking(){ id = 2, trackingId = "456", company = "company def", packingSize = "small", datetime = DateTime.Parse("5/1/2008 8:30:52 AM"), packing_weight = 112},
                new Tracking(){ id = 3, trackingId = "789", company = "company ghi", packingSize = "small", datetime = DateTime.Parse("5/1/2008 8:30:52 AM"), packing_weight = 112}
            };
        }

        // Get Tracking Details
        public Tracking GetTracking(string id)
        {
            // Find the id 
            return trackinglist.FirstOrDefault(e => e.trackingId == id);
        }

        // Add New Tracking Details
        public Tracking AddTracking(Tracking track)
        {
   
            // Retrieve the max id and increment by 1
            track.id = trackinglist.Max(e => e.id) + 1;
            //Add the following details into the list
            trackinglist.Add(track);

            return track;
        }

        // Return a collection of tracking details
        public IEnumerable<Tracking> GetAllTracking()
        {
            return trackinglist;
        }

        // Update Tracking Details
        public Tracking UpdateTracking(Tracking new_track)
        {
            // Find the id of the object
            Tracking tracking = trackinglist.FirstOrDefault(e => e.id == new_track.id);

            // If found then update
            if (tracking != null)
            {
                tracking.id = new_track.id;
                tracking.trackingId = new_track.trackingId;
                tracking.packingSize = new_track.packingSize;
                tracking.packing_weight = new_track.packing_weight;
                tracking.datetime = new_track.datetime;
                tracking.company = new_track.company;
            }
            else
            {
                throw new EntryPointNotFoundException();
            }
            return tracking;
        }

        // Delete Tracking Details
        public Tracking DeleteTracking(int id)
        {
            // Find the Id
            Tracking tracking = trackinglist.FirstOrDefault(e => e.id == id);
            if(tracking != null)
            {
                trackinglist.Remove(tracking);
            }
            return tracking;
        }
    }
}
