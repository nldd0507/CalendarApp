using CalendarApp.BLL;
using CalendarApp.GUI;

namespace CalendarApp
{
    public partial class LoginForm : Form
    {
        private UserService userService = new UserService();
        public static DTO.User CurrentLoggedInUser;
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string user = txtUsername.Text;
            string password = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(user) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }

            bool isSuccess = userService.Register(user, password);
            if (isSuccess) MessageBox.Show("Đăng kí thành công!");
            else MessageBox.Show("Tên đăng nhập đã tồn tại!");
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string user = txtUsername.Text;
            string password = txtPassword.Text;

            var loggedInUser = userService.Login(user, password);

            if (loggedInUser != null) { 
                CurrentLoggedInUser = loggedInUser;
                MessageBox.Show("Đăng nhập thành công! Chào mừng " + loggedInUser.Username);
                MainForm main = new MainForm();
                main.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!");
            }
        }
    }
}
