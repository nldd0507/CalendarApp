using CalendarApp.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalendarApp.GUI
{
    public partial class AddAppointmentForm : Form
    {
        private AppointmentService apptService = new AppointmentService();
        public AddAppointmentForm(DateTime selectedDate)
        {
            InitializeComponent();
            dtpStartTime.Value = selectedDate.Date.AddHours(8);
            dtpEndTime.Value = selectedDate.Date.AddHours(9);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string title = txtTitle.Text;
            string location = txtLocation.Text;
            DateTime start = dtpStartTime.Value;
            DateTime end = dtpEndTime.Value;

            int currentUserId = LoginForm.CurrentLoggedInUser.Id;

            string result = apptService.CreateAppointment(currentUserId, title, location, start, end);

            if (result == "ERROR_EMPTY_NAME")
            {
                MessageBox.Show("Tên cuộc hẹn không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (result == "ERROR_NEGATIVE_TIME")
            {
                MessageBox.Show("Thời gian kết thúc phải lớn hơn thời gian bắt đầu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (result == "ASK_JOIN_GROUP")
            {
                var answer = MessageBox.Show("Có một cuộc họp nhóm cùng tên đang diễn ra vào giờ này. Bạn có muốn tham gia nhóm này thay vì tạo mới không?",
                                             "Phát hiện họp nhóm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (answer == DialogResult.Yes)
                {
                    MessageBox.Show("Đã thêm bạn vào danh sách tham gia cuộc họp nhóm!");
                    this.Close();
                }
            }
            else if (result == "ASK_REPLACE_CONFLICT")
            {
                var answer = MessageBox.Show("Khung giờ này bạn đã có lịch hẹn. Bạn có muốn thay thế lịch cũ bằng lịch mới này không?",
                                             "Xung đột thời gian", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (answer == DialogResult.Yes)
                {
                    apptService.CreateAppointment(currentUserId, title, location, start, end, true);
                    MessageBox.Show("Đã thay thế lịch hẹn thành công!");
                    this.Close();
                }
            }
            else if (result == "SUCCESS")
            {
                MessageBox.Show("Thêm lịch hẹn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }
    }
}
