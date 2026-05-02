using CalendarApp.DAL;
using CalendarApp.DTO;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;

namespace CalendarApp.BLL
{
    public class AppointmentService
    {
        public string CreateAppointment(int userId, string title, string location, DateTime start, DateTime end,  bool hasReminder, int reminderMinutes, string reminderMessage, bool forceReplace = false)
        {
            if (string.IsNullOrWhiteSpace(title)) return "ERROR_EMPTY_NAME";

            if (start >= end)
                return "ERROR_NEGATIVE_TIME";
            using (var db = new AppDbContext())
            {
                var groupMeeting = db.Appointments.FirstOrDefault(a =>
                a.IsGroupMeeting == true &&
                a.Title == title &&
                a.StartTime == start && a.EndTime == end);

                if (groupMeeting != null)
                {
                    return "ASK_JOIN_GROUP";
                }

                var conflictAppt = db.Appointments.FirstOrDefault(a =>
                a.UserId == userId && start < a.EndTime && end > a.StartTime);

                if(conflictAppt != null)
                {
                    if (!forceReplace)
                    {
                        return "ASK_REPLACE_CONFLICT";
                    }
                    else db.Appointments.Remove(conflictAppt);
                }

                var newAppt = new Appointment
                {
                    Title = title,
                    Location = location,
                    StartTime= start,
                    EndTime= end,
                    IsGroupMeeting = false,
                    UserId=userId,

                    HasReminder = hasReminder,
                    ReminderMinutesBefore = reminderMinutes,
                    ReminderMessage = reminderMessage
                };

                db.Appointments.Add(newAppt);
                db.SaveChanges();
                return "SUCCESS";
            }
        }
        public List<Appointment> GetAppointmentsByDate(int userId, DateTime date)
        {
            using (var db = new AppDbContext())
            {
                return db.Appointments
                    .Where(a => a.UserId == userId && a.StartTime.Date == date.Date)
                    .OrderBy(a => a.StartTime)
                    .ToList();
            }
        }

        public bool DeleteAppointment(int appointmentId)
        {
            using(var db = new AppDbContext())
            {
                var appt = db.Appointments.Find(appointmentId);

                if(appt != null)
                {
                    db.Appointments.Remove(appt);
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
        }
        public List<Appointment> GetAppointmentsToRemind(int userId)
        {
            using (var db = new AppDbContext())
            {
                DateTime now = DateTime.Now;
                var upcomingAppts = db.Appointments
                 .Where(a => a.UserId == userId && a.HasReminder && a.StartTime >= now)
                 .ToList();

                return upcomingAppts
                 .Where(a => now >= a.StartTime.AddMinutes(-a.ReminderMinutesBefore))
                 .ToList();
            }
        }
    }      
}
