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
        public EmailVerificationForm(string code, string userEmail)
        {
            InitializeComponent();
            
            this.verificationCode = code;
            this.userEmail = userEmail;
            Controls.Remove(resetPasswordPanel);
        }

        private void VerifyB_Click(object sender, EventArgs e)
        {
            if (userInput.Text == verificationCode)
            {
               
                    this.DialogResult = DialogResult.OK; // תוצאה מוצלחת
                    this.Close(); // סגירת החלון
            }
            else
            {
                MessageBox.Show("try again");
                userInput.Text = "";
            }
        }
    }
}
