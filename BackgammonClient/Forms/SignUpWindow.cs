using BackgammonClient.Utils;
using System;
using System.Linq;
using System.Windows.Forms;

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

            var input = $"{username},{password},{firstName},{lastName},{email},{city},{gender}";
            OnSignUp?.Invoke("SignUp," + input);
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
