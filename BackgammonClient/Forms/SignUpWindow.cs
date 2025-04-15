using BackgammonClient.Utils;
using System;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Windows.Forms;
using BackgammonClient.Forms;

namespace BackgammonClient
{
    public partial class SignUpWindow : Form
    {
        public event Action<string> OnSignUp;
        public event Action OnSwitchWindowToLogIn; // switching to logIn window 

        private string[] cities = {
            "Jerusalem",
            "Tel Aviv",
            "Haifa",
            "Rishon LeZion",
            "Petah Tikva",
            "Ashdod",
            "Netanya",
            "Beersheba",
            "Holon",
            "Bnei Brak",
            "Ramat Gan",
            "Rehovot",
            "Bat Yam",
            "Ashkelon",
            "Herzliya",
            "Kfar Saba",
            "Modi'in-Maccabim-Re'ut",
            "Nazareth",
            "Ra'anana",
            "Hadera",
            "Beit Shemesh",
            "Lod",
            "Ramla",
            "Tayibe",
            "Kiryat Gat",
            "Kiryat Motzkin",
            "Acre",
            "Dimona",
            "Nahariya",
            "Sderot"
        };

        private string[] genders = { "Male", "Female" };

        public SignUpWindow()
        {
            InitializeComponent();
            InitializeComboBoxes();
        }

        public void ShowMessageInMessageBox(string message)
        {
            MessageBox.Show(message);
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

        private void SignUpButton_Click(object sender, EventArgs e)
        {
            var username = UserNameTextBox.Text.Trim();
            var password = PasswordTextBox.Text.Trim();
            var firstName = FirstNameTextBox.Text.Trim();
            var lastName = LastNameTextBox.Text.Trim();
            var email = EmailTextBox.Text.Trim();
            var city = CityComboBox.Text.Trim();
            var gender = GenderComboBox.Text.Trim();

            var validationMessage = LogInLegitimacyCheckingUtils.IsAllFieldsFull(username, password, firstName, lastName, email, city, gender);

            if (!string.IsNullOrEmpty(validationMessage))
            {
                MessageBox.Show(validationMessage);
                return;
            }

            else
            {
                string code = new Random().Next(100000, 999999).ToString();
                SendEmail(EmailTextBox.Text, "Email Verification", "Hello " + FirstNameTextBox.Text + "!\r\n\r\nTo complete your registration, please enter the following verification code:\r\n\r\n🔒 Your verification code: " + code + "\r\n\r\nIf you did not request this registration, you can safely ignore this email.\r\n\r\nThank you,  \r\nBackgammon Team");
                EmailVerificationForm emailVerificationForm = new EmailVerificationForm("mail", code, EmailTextBox.Text);
                DialogResult emailVerificationResult = emailVerificationForm.ShowDialog();

                if (emailVerificationResult == DialogResult.OK)
                {
                    MessageBox.Show("Email vertification was successful");
                    var input = $"{username},{password},{firstName},{lastName},{email},{city},{gender}";
                    OnSignUp?.Invoke("SignUp," + input);
                }

                //var input = $"{username},{password},{firstName},{lastName},{email},{city},{gender}";
                //OnSignUp?.Invoke("SignUp," + input);
            }
        }

        private void LogInButton_Click_1(object sender, EventArgs e)
        {
            OnSwitchWindowToLogIn?.Invoke();
        }

        private void InitializeComboBoxes()
        {
            CityComboBox.Items.AddRange(cities);
            GenderComboBox.Items.AddRange(genders);
        }

        private void SignUpWindow_Load(object sender, EventArgs e)
        {

        }
    }
}
