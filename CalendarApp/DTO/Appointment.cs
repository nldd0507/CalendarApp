using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarApp.DTO
{
    public class Appointment
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Location { get; set; } 
        public DateTime StartTime {  get; set; }
        public DateTime EndTime { get; set; } 
        public bool IsGroupMeeting { get; set; }    


        //foreign key
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
