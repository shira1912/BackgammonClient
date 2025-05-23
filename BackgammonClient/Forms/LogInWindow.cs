using BackgammonClient.Forms;
using BackgammonClient.Utils;
using System;
using System.Net.Mail;
using System.Net;
using System.Windows.Forms;
using System.Threading;
using System.Threading.Tasks;

namespace BackgammonClient
{
    public partial class LogInWindow : Form
    {
        private LogInWindow _logInWindow;
        private WaitingRoomWindow _waitingRoomWindow;
        public event Action<string> sendMessage;
        public event Action<string> OnResetPassword;

        public event Action<string> OnCaptcha;

        public event Action OnSwitchWindowToSignUp;
        private CaptchaCard CaptchaCard;
        private CaptchaCard TimerCard;
        private int countTries = 0;

        public LogInWindow()
        {
            InitializeComponent();
            CaptchaCard = new CaptchaCard(false);
            _waitingRoomWindow = new WaitingRoomWindow();
            forgotPassEmailT.Hide();
            sendFPEmailB.Hide();
            CaptchaCard.Location = new System.Drawing.Point(196, 208);

        }

        public void ShowMessageInMessageBox(string message)
        {
            MessageBox.Show(message);
        }

        public async void updateTries()
        {
            countTries++;

            if (countTries > 3)
            {
                TimerCard = new CaptchaCard(true);
                TimerCard.BringToFront();
                TimerCard.Location = new System.Drawing.Point(196, 208);
                Controls.Add(TimerCard);
                await Task.Delay(60000);
                Controls.Remove(TimerCard);
            }
        }

        private void LogInButton_Click(object sender, EventArgs e)
        {
            var username = UserNameTextBox.Text.Trim();
            var password = PasswordTextBox.Text.Trim();

            var validationMessage = LogInLegitimacyCheckingUtils.IsUserNameAndPasswordLegitimate(username, password, checkBox.Checked);
            if (!string.IsNullOrEmpty(validationMessage))
            {
                MessageBox.Show(validationMessage);
                return;
            }

            var input = $"{username},{password}";
            sendMessage?.Invoke("Login," + input);
        }


        private void SignUpButton_Click(object sender, EventArgs e)
        {
            OnSwitchWindowToSignUp?.Invoke();
        }

        private void LogInWindow_Load(object sender, EventArgs e)
        {

        }

        private void SkipButton_Click(object sender, EventArgs e)
        {
            sendMessage?.Invoke("Login,alex1989,StrongP@ssw0rd");
        }

        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox.Checked)
            {
                Controls.Add(CaptchaCard);
                checkBox.Enabled = false;
            }

        }
        public void SendEmail(string userMail, string subject, string body)
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("backgammonproj2025@gmail.com"); // כתובת המייל שלך
                mail.To.Add(userMail);             // כתובת הנמען
                mail.Subject = subject;
                mail.Body = body;

                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.Credentials = new NetworkCredential("backgammonproj2025@gmail.com", "znvayxcxdcveefqa");
                smtp.EnableSsl = true;

                smtp.Send(mail);
                MessageBox.Show("Email sent");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Email sending failed: " + ex.Message);
            }
        }
        private void ForgotPassLinkL_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            forgotPassEmailT.Show();
            sendFPEmailB.Show();
        }

        private void sendFPEmailB_Click(object sender, EventArgs e)
        {
            string email = forgotPassEmailT.Text;
            OnResetPassword.Invoke("IsEmailExists," + email);
        }

        public void sendForgotPassEmail(string emailGiven)
        {
            string code = new Random().Next(100000, 999999).ToString();
            string emailBody = "Hello!\r\n\r\nWe received a request to reset the password for your account.\r\n\r\nTo proceed, please enter the following verification code:\r\n\r\n🔐 Verification Code: " + code + "\r\n\r\nThank you,\r\n\r\nBackgammon Team";
            SendEmail(forgotPassEmailT.Text, "Reset Your Password", emailBody);
            EmailVerificationForm emailVerificationForm = new EmailVerificationForm("password", code, forgotPassEmailT.Text);
            emailVerificationForm.sendMessage += sendMessage;
            emailVerificationForm.Show();
        }

        private void LogInWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
