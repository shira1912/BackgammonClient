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
    public partial class CaptchaCard : UserControl
    {
        public CaptchaCard()
        {
            InitializeComponent();
            // יצירת קאפצ'ה
            GenerateCaptcha();
            tryCount = 0;
            lblCountdown.Hide();
            progressBar.Hide();
        }

        private string captchaText;
        private int tryCount;
        private int countdownSeconds = 60;  // זמן ההתחלה - 60 שניות (דקה)
        public bool check = false;

        private void GenerateCaptcha()
        {
            // יצירת טקסט אקראי
            Random rand = new Random();
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890";
            captchaText = "";
            for (int i = 0; i < 6; i++)
            {
                captchaText += chars[rand.Next(chars.Length)];
            }

            // יצירת תמונה עם הטקסט
            Bitmap captchaBitmap = new Bitmap(200, 40);
            using (Graphics g = Graphics.FromImage(captchaBitmap))
            {
                g.Clear(Color.White);

                // הגדרת פונט
                Font font = new Font("Arial", 20, FontStyle.Bold);

                // הוספת רעש או קווים
                for (int i = 0; i < 20; i++)
                {
                    g.DrawLine(new Pen(Color.Gray), rand.Next(200), rand.Next(40), rand.Next(200), rand.Next(40));
                }

                // הוספת הטקסט
                g.DrawString(captchaText, font, Brushes.Black, new PointF(50, 5));
            }

            // הצגת התמונה
            captchaImageLabel.Image = captchaBitmap;
        }


        private void checkButton_Click(object sender, EventArgs e)
        {
            // בדוק אם התשובה נכונה
            if (userInputT.Text.Equals(captchaText, StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("good");
                check = true; // תוצאה מוצלחת
                this.Hide(); // סגירת החלון
            }
            else
            {
                tryCount++;
                if (tryCount > 3)
                {
                    MessageBox.Show("too many tries. try again later.");
                    DisableInputs();
                    countdownSeconds = 60;
                    progressBar.Value = 0;  // אתחול של ה-ProgressBar ל-0
                    progressBar.Maximum = 60;
                    countdownTimer.Start();
                    UpdateCountdownDisplay();  // עדכון תצוגת הזמן
                }
                else
                {
                    MessageBox.Show("are you a robot?");
                    GenerateCaptcha(); // יצירת קאפצ'ה חדשה אחרי טעות
                }

            }
        }

        private void countdownTimer_Tick(object sender, EventArgs e)
        {
            countdownSeconds--;  // כל שנייה יורד 1 בשניות
            progressBar.Value = 60 - countdownSeconds;  // עדכון ה-ProgressBar
            UpdateCountdownDisplay();  // עדכון תצוגת הזמן

            if (countdownSeconds <= 0)
            {
                countdownTimer.Stop();  // עצירת ה-Timer כשנגמר הזמן
                EnableInputs();
                tryCount = 0;
                MessageBox.Show("you may try again");  // פעולה שמתבצעת בסיום

            }
        }

        private void DisableInputs()
        {
            // השבתת כפתור התחלה ו-TextBox לדוגמה
            captchaImageLabel.Hide();
            checkButton.Enabled = false;
            userInputT.Enabled = false;
            lblCountdown.Show();
            progressBar.Show();
            // אם יש שדות נוספים, ניתן להוסיף אותם כאן
        }

        // הפעלת שדות קלט לאחר סיום הספירה
        private void EnableInputs()
        {
            // הפעלת כפתור התחלה ו-TextBox לדוגמה
            captchaImageLabel.Show();
            checkButton.Enabled = true;
            userInputT.Enabled = true;
            lblCountdown.Hide();
            progressBar.Hide();
            // אם יש שדות נוספים, ניתן להפעיל אותם כאן
        }

        private void UpdateCountdownDisplay()
        {
            // חישוב דקות ושניות
            int minutes = countdownSeconds / 60;
            int seconds = countdownSeconds % 60;

            // הצגת הזמן במבנה "HH:mm:ss"
            lblCountdown.Text = $"{minutes:D2}:{seconds:D2}";  // מציג את הזמן בשעון
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("good");
            check = true; // תוצאה מוצלחת
            this.Hide(); // סגירת החלון
        }
    }
}
