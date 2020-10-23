using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace wms_inventory.Models
{
    public class SQLTrackingRepository : ITrackingRepository
    {
        private readonly AppDbContext context;
        public SQLTrackingRepository(AppDbContext context)
        {
            this.context = context;
        }
        public Tracking AddTracking(Tracking track)
        {
            context.TrackDbSet.Add(track);
            context.SaveChanges();
            return track;
        }

        public Tracking DeleteTracking(int id)
        {
            Tracking track = context.TrackDbSet.Find(id);
            if (track != null)
            {
                context.TrackDbSet.Remove(track);
                context.SaveChanges();
            }
            return track;
        }

        public IEnumerable<Tracking> GetAllTracking()
        {
            return context.TrackDbSet;
        }

        public Tracking GetTracking(string id)
        {
           return context.TrackDbSet.Find(id);

        }

        public Tracking UpdateTracking(Tracking new_track)
        {
            var track = context.TrackDbSet.Attach(new_track);
            track.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return new_track;

        }
    }
}
