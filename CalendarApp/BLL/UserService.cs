using CalendarApp.DAL;
using CalendarApp.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarApp.BLL
{
    public class UserService
    {
        public bool Register(string username, string password)
        {
            using (var db = new AppDbContext())
            {
                bool isExist = db.Users.Any(u => u.Username == username);
                if (isExist) return false;
                var newUser = new User { Username= username, Password = password};
                db.Users.Add(newUser);
                db.SaveChanges();
                return true;
            }
        }

        public User Login(string username, string password)
        {
            using (var db = new AppDbContext())
            {
                {
                    return db.Users.FirstOrDefault(u => u.Username == username && u.Password == password);
                }
            }
        }
    }
}
