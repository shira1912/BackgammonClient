using BackgammonClient.Forms;
using BackgammonClient.Utils;
using System;
using System.Windows.Forms;

namespace BackgammonClient
{
    public partial class LogInWindow : Form
    {
        private LogInWindow _logInWindow;
        private WaitingRoomWindow _waitingRoomWindow;
        public event Action<string> OnLogIn;
        public event Action<string> OnCaptcha;
        public event Action OnSwitchWindowToSignUp;
        private CaptchaCard captchaCard;

        public LogInWindow()
        {
            InitializeComponent();
            captchaCard = new CaptchaCard();
            _waitingRoomWindow = new WaitingRoomWindow();
            captchaCard.Location = new System.Drawing.Point(0,0);
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
    }
}
