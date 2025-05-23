namespace BackgammonClient.Forms
{
    partial class GameWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            roll = new System.Windows.Forms.Button();
            pictureBox1 = new System.Windows.Forms.PictureBox();
            pictureBox2 = new System.Windows.Forms.PictureBox();
            turnLabel = new System.Windows.Forms.Label();
            doneButton = new System.Windows.Forms.Button();
            colorPictureBox = new System.Windows.Forms.PictureBox();
            youLabel = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            updatesLabel = new System.Windows.Forms.Label();
            skipToBearingButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)colorPictureBox).BeginInit();
            SuspendLayout();
            // 
            // roll
            // 
            roll.BackColor = System.Drawing.Color.SaddleBrown;
            roll.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            roll.ForeColor = System.Drawing.Color.Tan;
            roll.Location = new System.Drawing.Point(17, 45);
            roll.Name = "roll";
            roll.Size = new System.Drawing.Size(101, 23);
            roll.TabIndex = 0;
            roll.Text = "ROLL THE DICE";
            roll.UseVisualStyleBackColor = false;
            roll.Click += rollTheDice_click;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new System.Drawing.Point(27, 74);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new System.Drawing.Size(35, 35);
            pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Location = new System.Drawing.Point(71, 74);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new System.Drawing.Size(35, 35);
            pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 2;
            pictureBox2.TabStop = false;
            // 
            // turnLabel
            // 
            turnLabel.AutoSize = true;
            turnLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            turnLabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            turnLabel.Location = new System.Drawing.Point(6, 158);
            turnLabel.Name = "turnLabel";
            turnLabel.Size = new System.Drawing.Size(129, 15);
            turnLabel.TabIndex = 3;
            turnLabel.Text = "IT'S NOT YOUR TURN";
            // 
            // doneButton
            // 
            doneButton.BackColor = System.Drawing.Color.SaddleBrown;
            doneButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            doneButton.ForeColor = System.Drawing.Color.Tan;
            doneButton.Location = new System.Drawing.Point(27, 214);
            doneButton.Name = "doneButton";
            doneButton.Size = new System.Drawing.Size(75, 23);
            doneButton.TabIndex = 4;
            doneButton.Text = "DONE";
            doneButton.UseVisualStyleBackColor = false;
            doneButton.Click += doneButton_Click;
            // 
            // colorPictureBox
            // 
            colorPictureBox.BackColor = System.Drawing.Color.Silver;
            colorPictureBox.Location = new System.Drawing.Point(46, 290);
            colorPictureBox.Name = "colorPictureBox";
            colorPictureBox.Size = new System.Drawing.Size(35, 35);
            colorPictureBox.TabIndex = 5;
            colorPictureBox.TabStop = false;
            // 
            // youLabel
            // 
            youLabel.AutoSize = true;
            youLabel.BackColor = System.Drawing.Color.Tan;
            youLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            youLabel.ForeColor = System.Drawing.Color.SaddleBrown;
            youLabel.Location = new System.Drawing.Point(23, 272);
            youLabel.Name = "youLabel";
            youLabel.Size = new System.Drawing.Size(82, 15);
            youLabel.TabIndex = 6;
            youLabel.Text = "YOUR COLOR";
            youLabel.Click += label1_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Bell MT", 24F, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, 0);
            label3.ForeColor = System.Drawing.Color.SaddleBrown;
            label3.Location = new System.Drawing.Point(6, 5);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(125, 37);
            label3.TabIndex = 10;
            label3.Text = "שש-בש";
            label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // updatesLabel
            // 
            updatesLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            updatesLabel.Location = new System.Drawing.Point(17, 337);
            updatesLabel.Name = "updatesLabel";
            updatesLabel.Size = new System.Drawing.Size(112, 50);
            updatesLabel.TabIndex = 11;
            // 
            // skipToBearingButton
            // 
            skipToBearingButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            skipToBearingButton.Location = new System.Drawing.Point(23, 409);
            skipToBearingButton.Name = "skipToBearingButton";
            skipToBearingButton.Size = new System.Drawing.Size(91, 40);
            skipToBearingButton.TabIndex = 12;
            skipToBearingButton.Text = "SKIP TO BEARING OFF";
            skipToBearingButton.UseVisualStyleBackColor = true;
            skipToBearingButton.Click += skipToBearingButton_Click;
            // 
            // GameWindow
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.Tan;
            ClientSize = new System.Drawing.Size(984, 461);
            Controls.Add(skipToBearingButton);
            Controls.Add(updatesLabel);
            Controls.Add(label3);
            Controls.Add(youLabel);
            Controls.Add(colorPictureBox);
            Controls.Add(doneButton);
            Controls.Add(turnLabel);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(roll);
            Name = "GameWindow";
            Text = "GAME";
            FormClosed += GameWindow_FormClosed;
            Load += GameWindow_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)colorPictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button roll;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label turnLabel;
        private System.Windows.Forms.Button doneButton;
        private System.Windows.Forms.PictureBox colorPictureBox;
        private System.Windows.Forms.Label youLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label updatesLabel;
        private System.Windows.Forms.Button skipToBearingButton;
    }
}