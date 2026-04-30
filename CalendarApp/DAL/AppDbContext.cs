using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CalendarApp.DTO;

namespace CalendarApp.DAL
{
    public class AppDbContext:DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public AppDbContext()
        {
            // Nếu database hoặc bảng chưa tồn tại, nó sẽ tự tạo ngay khi ứng dụng chạy
            this.Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=calendarapp.db");
        }
    }
}
