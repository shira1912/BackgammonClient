using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BackgammonClient.Forms
{
    public partial class EmailVerificationForm : Form
    {
        private string verificationCode;
        public event Action<string> sendMessage;
        private string userEmail;
        private string type;
        public EmailVerificationForm(string type, string code, string userEmail)
        {
            InitializeComponent();
            this.type = type;
            this.verificationCode = code;
            this.userEmail = userEmail;
            Controls.Remove(resetPasswordPanel);
        }

        private void VerifyB_Click(object sender, EventArgs e)
        {
            if (userInput.Text == verificationCode)
            {
                if (type == "mail")
                {
                    this.DialogResult = DialogResult.OK; // תוצאה מוצלחת
                    this.Close(); // סגירת החלון
                }
                else if(type == "password")
                {
                    Controls.Clear();
                    Controls.Add(resetPasswordPanel);
                }
            }
            else
            {
                MessageBox.Show("try again");
                userInput.Text = "";
            }
        }

        private void ResetPasswordB_Click(object sender, EventArgs e)
        {
            if (newPass1.Text != newPass2.Text)
            {
                MessageBox.Show("Passwords are not the same");
            }
            else if (newPass1.Text.Length < 6)
            {
                MessageBox.Show("Password must be six or more characters long");
            }
            else
            {
                sendMessage("ResetPassword" + userEmail + "_" + newPass1.Text);
                this.Close();
            }
        }
    }
}
