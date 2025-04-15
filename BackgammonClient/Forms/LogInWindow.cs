using BackgammonClient.Forms;
using BackgammonClient.Utils;
using System;
using System.Net.Mail;
using System.Net;
using System.Windows.Forms;

namespace BackgammonClient
{
    public partial class LogInWindow : Form
    {
        private LogInWindow _logInWindow;
        private WaitingRoomWindow _waitingRoomWindow;
        public event Action<string> OnLogIn;
        public event Action<string> OnCaptcha;
        public event Action<string> sendMessage;

        public event Action OnSwitchWindowToSignUp;
        private CaptchaCard captchaCard;

        public LogInWindow()
        {
            InitializeComponent();
            captchaCard = new CaptchaCard();
            _waitingRoomWindow = new WaitingRoomWindow();
            forgotPassEmailT.Hide();
            sendFPEmailB.Hide();
            captchaCard.Location = new System.Drawing.Point(0, 0);
        }

        public void ShowMessageInMessageBox(string message)
        {
            MessageBox.Show(message);
        }

        private void LogInButton_Click(object sender, EventArgs e)
        {
            var username = UserNameTextBox.Text.Trim();
            var password = PasswordTextBox.Text.Trim();

            var validationMessage = LogInLegitimacyCheckingUtils.IsUserNameAndPasswordLegitimate(username, password);
            if (!string.IsNullOrEmpty(validationMessage))
            {
                MessageBox.Show(validationMessage);
                return;
            }

            var input = $"{username},{password}";
            OnLogIn?.Invoke("Login," + input);
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
            OnLogIn?.Invoke("Login,alex1989,StrongP@ssw0rd");
        }

        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox.Checked)
            {
                Controls.Add(captchaCard);
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
            sendMessage("isEmailExists, " + forgotPassEmailT);
        }

        public void sendForgotPassEmail(string emailGiven)
        {
            string code = new Random().Next(100000, 999999).ToString();
            string emailBody = "Hello!\r\n\r\nWe received a request to reset the password for your CtrlAltBookIt account.\r\n\r\nTo proceed, please enter the following verification code:\r\n\r\n🔐 Verification Code: " + code + "\r\n\r\nThank you,\r\n\r\nBackgammon Team";
            SendEmail(forgotPassEmailT.Text, "Reset Your CtrlAltBookIt Password", emailBody);
            EmailVerificationForm emailVerificationForm = new EmailVerificationForm("password", code, emailGiven);
        }
    }
}
