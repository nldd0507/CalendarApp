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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            LoadAppointments();
        }

        private void btnAddAppointment_Click(object sender, EventArgs e)
        {
            DateTime selectedDate = monthCalendar1.SelectionRange.Start;

            AddAppointmentForm addForm = new AddAppointmentForm(selectedDate);
            addForm.ShowDialog();

            LoadAppointments();
        }

        private void LoadAppointments()
        {
            DateTime selectedDate = monthCalendar1.SelectionRange.Start;

            AppointmentService service = new AppointmentService();
            var list = service.GetAppointmentsByDate(LoginForm.CurrentLoggedInUser.Id, selectedDate);

            dgvAppointments.DataSource = null;

            dgvAppointments.DataSource = list.Select(a => new
            {
                Id = a.Id,
                Tiêu_Đề = a.Title,
                Địa_Điểm = a.Location,
                Bắt_Đầu = a.StartTime.ToString("HH:mm"),
                Kết_Thúc = a.EndTime.ToString("HH:mm"),
                Là_Họp_Nhóm = a.IsGroupMeeting
            }).ToList();

            if (dgvAppointments.Columns["Id"] != null)
                dgvAppointments.Columns["Id"].Visible = false;
            foreach (DataGridViewRow row in dgvAppointments.Rows)
            {
                bool isGroup = Convert.ToBoolean(row.Cells["Là_Họp_Nhóm"].Value);
                if (isGroup)
                {
                    row.DefaultCellStyle.BackColor = Color.LightSkyBlue; 
                    row.DefaultCellStyle.ForeColor = Color.DarkBlue;
                }
            }
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            LoadAppointments();
        }

        private void xóaLịchHẹnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvAppointments.CurrentRow != null)
            {
                int id = Convert.ToInt32(dgvAppointments.CurrentRow.Cells["Id"].Value);
                string title = dgvAppointments.CurrentRow.Cells["Tiêu_Đề"].Value.ToString();

                DialogResult dialogResult = MessageBox.Show($"Bạn có chắc chắn muốn xóa lịch '{title}' không?",
                                                            "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    AppointmentService service = new AppointmentService();
                    if (service.DeleteAppointment(id))
                    {
                        MessageBox.Show("Đã xóa thành công!");
                        LoadAppointments();
                    }
                }
            }
        }

        private void dgvAppointments_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                dgvAppointments.ClearSelection();
                dgvAppointments.Rows[e.RowIndex].Selected = true;
                dgvAppointments.CurrentCell = dgvAppointments.Rows[e.RowIndex].Cells["Tiêu_Đề"];
            }
        }

        private List<int> remindedAppointmentIds = new List<int>();
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (LoginForm.CurrentLoggedInUser == null) return;

            AppointmentService service = new AppointmentService();

            var upcoming = service.GetAppointmentsToRemind(LoginForm.CurrentLoggedInUser.Id);

            foreach (var appt in upcoming)
            {
                if (!remindedAppointmentIds.Contains(appt.Id))
                {
                    remindedAppointmentIds.Add(appt.Id);

                    MessageBox.Show($"[NHẮC NHỞ]: {appt.ReminderMessage}\n\n" +
                                    $"Sự kiện: {appt.Title}\n" +
                                    $"Bắt đầu lúc: {appt.StartTime.ToString("HH:mm")}\n" +
                                    $"Địa điểm: {appt.Location}",
                                    "Smart Calendar Reminder",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information,
                                    MessageBoxDefaultButton.Button1,
                                    MessageBoxOptions.DefaultDesktopOnly);
                }
            }
        }
    }
}
