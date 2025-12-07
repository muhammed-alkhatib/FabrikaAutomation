using System;
using System.Drawing;
using System.Windows.Forms;

namespace FabrikaAutomation
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            CustomizeUI();
        }

        private void CustomizeUI()
        {
            // فورم
            this.Text = "";
            this.BackColor = Color.FromArgb(18, 32, 47);
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ClientSize = new Size(480, 550);

            // عنوان
            Label title = new Label();
            title.Text = "Fabrika Automation";
            title.Font = new Font("Segoe UI", 26, FontStyle.Bold);
            title.ForeColor = Color.White;
            title.Dock = DockStyle.Top;
            title.Height = 100;
            title.TextAlign = ContentAlignment.MiddleCenter;
            this.Controls.Add(title);

            // Panel رئيسي
            Panel loginPanel = new Panel();
            loginPanel.Size = new Size(420, 380);
            loginPanel.BackColor = Color.FromArgb(43, 58, 75);
            loginPanel.Location = new Point((this.ClientSize.Width - loginPanel.Width) / 2, 140);
            loginPanel.Anchor = AnchorStyles.None;
            this.Controls.Add(loginPanel);

            // TextBox Kullanıcı Adı
            TextBox txtUser = new TextBox();
            txtUser.Name = "txtUser";
            txtUser.Font = new Font("Segoe UI", 14);
            txtUser.Size = new Size(300, 38);
            txtUser.Location = new Point(60, 70);
            loginPanel.Controls.Add(txtUser);

            // Placeholder Kullanıcı
            txtUser.ForeColor = Color.Silver;
            txtUser.Text = "Kullanıcı";
            txtUser.GotFocus += (s, e) =>
            {
                if (txtUser.ForeColor == Color.Silver)
                {
                    txtUser.Text = "";
                    txtUser.ForeColor = Color.Black;
                }
            };

            txtUser.LostFocus += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(txtUser.Text))
                {
                    txtUser.Text = "Kullanıcı";
                    txtUser.ForeColor = Color.Silver;
                }
            };

            // TextBox Şifre
            TextBox txtPass = new TextBox();
            txtPass.Name = "txtPass";
            txtPass.Font = new Font("Segoe UI", 14);
            txtPass.Size = new Size(300, 38);
            txtPass.Location = new Point(60, 140);
            loginPanel.Controls.Add(txtPass);

            // Placeholder Şifre
            txtPass.ForeColor = Color.Silver;
            txtPass.Text = "Şifre";
            txtPass.GotFocus += (s, e) =>
            {
                if (txtPass.ForeColor == Color.Silver)
                {
                    txtPass.Text = "";
                    txtPass.ForeColor = Color.Black;
                    txtPass.PasswordChar = '•';
                }
            };

            txtPass.LostFocus += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(txtPass.Text))
                {
                    txtPass.PasswordChar = '\0';
                    txtPass.Text = "Şifre";
                    txtPass.ForeColor = Color.Silver;
                }
            };

            // زر الدخول
            Button btnLogin = new Button();
            btnLogin.Text = "GİRİŞ";
            btnLogin.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            btnLogin.Size = new Size(300, 45);
            btnLogin.Location = new Point(60, 220);
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.BackColor = Color.FromArgb(0, 140, 255);
            btnLogin.ForeColor = Color.White;
            btnLogin.FlatAppearance.BorderSize = 0;

            btnLogin.MouseEnter += (s, e) =>
            {
                btnLogin.BackColor = Color.FromArgb(0, 110, 210);
            };
            btnLogin.MouseLeave += (s, e) =>
            {
                btnLogin.BackColor = Color.FromArgb(0, 140, 255);
            };

            btnLogin.Click += (s, e) =>
            {
                // بسيط: يوزر admin وباس 1234
                if (txtUser.ForeColor != Color.Silver &&
                    txtPass.ForeColor != Color.Silver &&
                    txtUser.Text == "admin" && txtPass.Text == "1234")
                {
                    Form1 f = new Form1();
                    f.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Hatalı kullanıcı adı veya şifre!", "Hata",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };

            loginPanel.Controls.Add(btnLogin);

            // زر إغلاق (X)
            Button closeBtn = new Button();
            closeBtn.Text = "X";
            closeBtn.Size = new Size(40, 30);
            closeBtn.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            closeBtn.ForeColor = Color.White;
            closeBtn.FlatStyle = FlatStyle.Flat;
            closeBtn.FlatAppearance.BorderSize = 0;
            closeBtn.BackColor = Color.Transparent;
            closeBtn.Location = new Point(this.ClientSize.Width - 50, 10);
            closeBtn.Click += (s, e) => Application.Exit();
            this.Controls.Add(closeBtn);
        }
    }
}
