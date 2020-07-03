using HrMatch.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrMatchApp.Models
{
    public class WorkersAnnouncements
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [ForeignKey("User")]
        public int WorkerID { get; set; }
        public User User { get; set; }

        [ForeignKey("Announcement")]
        public int AnnouncementID { get; set; }
        public Announcement Announcement { get; set; }

        private WorkersAnnouncements()
        {
                
        }


        public WorkersAnnouncements(int workerID, int announcementID)
        {
            WorkerID = workerID;
            AnnouncementID = announcementID;
        }
    }
}
