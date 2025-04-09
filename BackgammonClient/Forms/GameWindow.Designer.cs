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
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)colorPictureBox).BeginInit();
            SuspendLayout();
            // 
            // roll
            // 
            roll.Location = new System.Drawing.Point(18, 45);
            roll.Name = "roll";
            roll.Size = new System.Drawing.Size(75, 23);
            roll.TabIndex = 0;
            roll.Text = "roll";
            roll.UseVisualStyleBackColor = true;
            roll.Click += rollTheDice_click;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new System.Drawing.Point(18, 85);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new System.Drawing.Size(34, 33);
            pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Location = new System.Drawing.Point(58, 85);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new System.Drawing.Size(34, 33);
            pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 2;
            pictureBox2.TabStop = false;
            // 
            // turnLabel
            // 
            turnLabel.AutoSize = true;
            turnLabel.Location = new System.Drawing.Point(15, 319);
            turnLabel.Name = "turnLabel";
            turnLabel.Size = new System.Drawing.Size(0, 15);
            turnLabel.TabIndex = 3;
            // 
            // doneButton
            // 
            doneButton.Location = new System.Drawing.Point(18, 268);
            doneButton.Name = "doneButton";
            doneButton.Size = new System.Drawing.Size(75, 23);
            doneButton.TabIndex = 4;
            doneButton.Text = "done";
            doneButton.UseVisualStyleBackColor = true;
            doneButton.Click += doneButton_Click;
            // 
            // colorPictureBox
            // 
            colorPictureBox.BackColor = System.Drawing.SystemColors.InactiveCaption;
            colorPictureBox.Location = new System.Drawing.Point(17, 183);
            colorPictureBox.Name = "colorPictureBox";
            colorPictureBox.Size = new System.Drawing.Size(35, 31);
            colorPictureBox.TabIndex = 5;
            colorPictureBox.TabStop = false;
            // 
            // youLabel
            // 
            youLabel.AutoSize = true;
            youLabel.Location = new System.Drawing.Point(18, 165);
            youLabel.Name = "youLabel";
            youLabel.Size = new System.Drawing.Size(30, 15);
            youLabel.TabIndex = 6;
            youLabel.Text = "you:";
            youLabel.Click += label1_Click;
            // 
            // GameWindow
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(800, 450);
            Controls.Add(youLabel);
            Controls.Add(colorPictureBox);
            Controls.Add(doneButton);
            Controls.Add(turnLabel);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(roll);
            Name = "GameWindow";
            Text = "GameWindow";
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
    }
}