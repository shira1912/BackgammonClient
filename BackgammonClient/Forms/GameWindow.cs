using BackgammonClient.Objects;
using BackgammonClient.Properties;
using DataProtocols;
using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.VisualBasic.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BackgammonClient.Forms
{
    public partial class GameWindow : Form
    {

        private Button[] slotsButtons = new Button[24];

        private int[] WhitediscsPlaces = new int[15];
        private Button[] discsButtons = new Button[30];

        private Disc[] discs = new Disc[30];
        //private int slotOfDiscId;
        private Disc selectedDisc;
        private int selectedDiscId;

        int usedCubesAmount = 0;
        private int movesRemaining = 0;

        private int[] Blackdiscs = new int[15];

        private Slot[] slots = new Slot[24];
        private int color;
        private int cube1, cube2, usedCube;
        private bool cube1Used = false;
        private bool cube2Used = false;
        private int selectedSlot;

        public event Action OnSwitchTurn;
        public event Action<string> sendMessage;
        private Color[] discsColor = [System.Drawing.SystemColors.ButtonHighlight, System.Drawing.SystemColors.ActiveCaptionText];

        private delegate void delSwitchTurn(bool turn);
        private delegate void delUpdateBoard(string state);
        public GameWindow(int color)
        {
            InitializeComponent();
            this.color = color;
            buildBoard();
            initialSlots();
            placeDiscs();
            initialTurn(color == 1);
         //   this.colorPictureBox.BackColor = discsColor[1];
        }

        public void switchTurn(bool turn)
        {
            this.Invoke(new delSwitchTurn(initialTurn), turn);
        }

        public bool isDone()
        {
            return false;
        }
        public void updateBoard(string state)
        {
            this.Invoke(new delUpdateBoard(stateChanged), state);
        }

        public void initialTurn(bool turn)
        {
            disableButtons(turn);
            if (turn)
            {
                this.turnLabel.Text = "It's your turn";
            }
            else
            {
                this.turnLabel.Text = "It's not your turn";
            }
        }

        

        public void initialSlots()
        {
            for (int i = 0; i < slots.Length; i++)
            {
                slots[i] = new Slot(0, 0);
            }
            slots[0] = new Slot(2, 2);
            slots[5] = new Slot(5, 1);
            slots[7] = new Slot(3, 1);
            slots[11] = new Slot(5, 2);
            slots[12] = new Slot(5, 1);
            slots[16] = new Slot(3, 2);
            slots[18] = new Slot(5, 2);
            slots[23] = new Slot(2, 1);
        }

        public void disableButtons(bool turn)
        {
            // Disable all slot buttons
            for (int i = 0; i < slots.Length; i++)
            {
                this.slotsButtons[i].Enabled = false;
            }

            // Enable/disable roll and done buttons based on turn
            roll.Enabled = turn;
            doneButton.Enabled = turn;

            // Enable/disable disc buttons based on turn and color
            for (int i = 0; i < this.discsButtons.Length; i++)
            {
                if (discsButtons[i] != null)
                {
                    // Only enable discs of the player's color when it's their turn
                    this.discsButtons[i].Enabled = turn &&
                        (this.discsButtons[i].BackColor == discsColor[this.color - 1]);
                }
            }
        }

        public void initialBoard()
        {
            for (int i = 0; i < discsButtons.Length; i++)
            {
                if (discsButtons[i] != null)
                {
                    this.Controls.Remove(discsButtons[i]);
                    discsButtons[i].Dispose();
                    discsButtons[i] = null;
                }
            }


        }

        public void stateChanged(string state)
        {
            string[] slotsString = state.Split(';');

            for (int i = 0; i < slotsString.Length; i++)
            {
                string[] slot = slotsString[i].Split(':');
                slots[i].setColor(Int32.Parse(slot[0]));
                slots[i].setQuantity(Int32.Parse(slot[1]));
            }
            placeDiscs();
        }
        public void placeDiscs()
        {
            initialBoard();
            int counter = 0;
            for (int i = 0; i < slots.Length; i++)
            {
                for (int j = 0; j < slots[i].getQuantity(); j++)
                {
                    // Make sure we don't exceed the array bounds
                    if (counter >= discsButtons.Length)
                    {
                        Console.WriteLine($"Warning: Exceeded discsButtons array size at slot {i}, disc {j}");
                        continue;
                    }

                    this.discsButtons[counter] = new Button(); // Use counter instead of i

                    Point location = this.slotsButtons[i].Location;
                    if (i > (slots.Length / 2) - 1)
                    {
                        this.discsButtons[counter].Location = new System.Drawing.Point(location.X + 10, location.Y - (j * 30) + 120);
                    }
                    else
                    {
                        this.discsButtons[counter].Location = new System.Drawing.Point(location.X + 10, location.Y + (j * 30));
                    }

                    if (slots[i].getColor() == 1)
                    {
                        this.discsButtons[counter].BackColor = discsColor[0]; // white
                        this.discsButtons[counter].Name = counter.ToString();
                    }
                    else
                    {
                        this.discsButtons[counter].BackColor = discsColor[1]; // black
                        this.discsButtons[counter].Name = counter.ToString();
                    }

                    this.discsButtons[counter].Size = new System.Drawing.Size(30, 30);
                    this.discsButtons[counter].TabIndex = 36;
                    this.discsButtons[counter].TabStop = false;

                    // Check if it's the player's turn and if the disc color matches the player's color
                    bool isTurn = this.turnLabel.Text == "It's your turn";
                    this.discsButtons[counter].Enabled = isTurn &&
                        (this.discsButtons[counter].BackColor == discsColor[this.color - 1]);

                    this.discsButtons[counter].Click += new System.EventHandler(this.showAvailableSlots);

                    this.Controls.Add(this.discsButtons[counter]);
                    this.discsButtons[counter].BringToFront();

                    this.discs[counter] = new Disc(i);
                    counter++;
                }
            }
        }
        

        public void showAvailableSlots(object sender, EventArgs e)
        {

            int selectedDiscId = int.Parse(((Button)sender).Name);
            Color selectedDiscColor = ((Button)sender).BackColor;

            // Store the selected disc for later use
            this.selectedDisc = discs[selectedDiscId];
            int slot = selectedDisc.getSlotId();

            // Disable all slots first
            for (int i = 0; i < slotsButtons.Length; i++)
            {
                slotsButtons[i].Enabled = false;
            }

            // Only show slots for unused dice
            if (!cube1Used)
            {
                EnableSlotForDie(slot, cube1);
            }

            if (!cube2Used)
            {
                EnableSlotForDie(slot, cube2);
            }

            this.selectedSlot = slot;



        }
        

        public void enableValidSlot(int slotId)
        {
            if (slots[slotId].getColor() == this.color || slots[slotId].getQuantity() <= 1)
            {
                this.slotsButtons[slotId].Enabled = true;
            }
        }

        public void buildBoard()
        {
            placeSlotsTop();
            placeSlotsBottom();
            if (this.color == 1)
            {
                this.colorPictureBox.BackColor = discsColor[0];
            }

            else if (this.color == 2)
            {
                this.colorPictureBox.BackColor = discsColor[1];
            }
        }

        public void SlotClick(object sender, EventArgs e)
        {
            string[] selectedSlotName = ((Button)sender).Name.Split(',');
            int selectedSlotId = int.Parse(selectedSlotName[1]);

            // Make sure we properly decrement the quantity at the starting slot
            if (slots[selectedSlot].getQuantity() > 0)
            {
                slots[selectedSlot].setQuantity(slots[selectedSlot].getQuantity() - 1);
            }

            // Add disc to the target slot
            slots[selectedSlotId].setQuantity(slots[selectedSlotId].getQuantity() + 1);
            slots[selectedSlotId].setColor(this.color);

            int diff = Math.Abs(selectedSlotId - selectedSlot);

            // Mark which cube was used
            if (diff == cube1)
            {
                cube1Used = true;
                usedCube = cube1;
            }
            else if (diff == cube2)
            {
                cube2Used = true;
                usedCube = cube2;
            }

            usedCubesAmount++;
            movesRemaining--;

            // Reset selection
            selectedDisc = null;

            if (movesRemaining <= 0)
            {
                this.OnSwitchTurn?.Invoke();
            }

            // Important: Redraw the board to reflect changes
            placeDiscs();

            disableUsedCube();
            sendState();
        }

        public void disableUsedCube()
        {
            // Disable all slots first
            for (int i = 0; i < slotsButtons.Length; i++)
            {
                slotsButtons[i].Enabled = false;
            }

            // If no dice are used yet or no disc is selected, exit
            if (selectedDisc == null) return;

            int slot = selectedDisc.getSlotId();

            // Check which die is still available and enable appropriate slots
            if (!cube1Used)
            {
                EnableSlotForDie(slot, cube1);
            }

            if (!cube2Used)
            {
                EnableSlotForDie(slot, cube2);
            }
        }

        // Helper method to enable a slot based on die value
        private void EnableSlotForDie(int currentSlot, int dieValue)
        {
            int targetSlot = -1;

            if (this.color == 1) // white
            {
                if (currentSlot - dieValue >= 0)
                    targetSlot = currentSlot - dieValue;
            }
            else // black
            {
                if (currentSlot + dieValue < slotsButtons.Length)
                    targetSlot = currentSlot + dieValue;
            }

            if (targetSlot != -1)
                enableValidSlot(targetSlot);
        }


        public void sendState()
        {
            string[] slotsString = new string[slots.Length];
            for (int i = 0; i < slots.Length; i++)
            {
                slotsString[i] = slots[i].toString();
            }
            sendMessage("State," + string.Join(";", slotsString));
        }



        private void rollTheDice_click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            cube1 = rnd.Next(1, 7);
            cube2 = rnd.Next(1, 7);

            // Reset dice usage flags
            cube1Used = false;
            cube2Used = false;
            usedCube = 0;

            if (cube1 == cube2)
            {
                movesRemaining = 4;
            }
            else
            {
                movesRemaining = 2;
            }
            setCubePicture(cube1, 1);
            setCubePicture(cube2, 2);

            this.roll.Enabled = false;

            //send the dice to the server
            sendMessage("Dice," + cube1 + "," + cube2);

            this.roll.Enabled = false;

        }


        private void doneButton_Click(object sender, EventArgs e)
        {
            this.OnSwitchTurn?.Invoke();
        }

        private void GameWindow_Load(object sender, EventArgs e)
        {

        }

        public void placeSlotsTop()
        {
            int x = 700;
            int y = 10;
            for (int i = 0; i < slotsButtons.Length / 2; i++)
            {
                this.slotsButtons[i] = new Button();

                this.slotsButtons[i].Location = new System.Drawing.Point(x, y);
                this.slotsButtons[i].Name = "slot," + (i);
                this.slotsButtons[i].Size = new System.Drawing.Size(50, 150);
                this.slotsButtons[i].TabIndex = 36;
                this.slotsButtons[i].TabStop = false;
                this.slotsButtons[i].Enabled = false;
                this.slotsButtons[i].Click += new System.EventHandler(this.SlotClick);
                this.Controls.Add(this.slotsButtons[i]);
                this.slotsButtons[i].SendToBack();

                if ((i + 1) % (slotsButtons.Length / 4) == 0 && i != 0 && i != slotsButtons.Length / 2 - 1)
                {
                    x -= 50;
                }
                x -= 50;
            }
        }

        public void placeSlotsBottom()
        {
            int y = 285;
            int x = 100;
            for (int i = slotsButtons.GetLength(0) / 2; i < slotsButtons.Length; i++)
            {
                this.slotsButtons[i] = new Button();

                this.slotsButtons[i].Location = new System.Drawing.Point(x, y);
                this.slotsButtons[i].Name = "slot," + (i);
                this.slotsButtons[i].Size = new System.Drawing.Size(50, 153);
                this.slotsButtons[i].TabIndex = 36;
                this.slotsButtons[i].TabStop = false;
                this.slotsButtons[i].Click += new System.EventHandler(this.SlotClick);
                this.Controls.Add(this.slotsButtons[i]);
                this.slotsButtons[i].SendToBack();

                if ((i + 1) % (slotsButtons.Length / 4) == 0 && i != 0)
                {
                    x += 50;
                }

                x += 50;
            }
            x = 50;
        }

        public void setCubePicture(int cube, int cubeNum)
        {

            if (cubeNum == 1)
            {
                switch (cube)
                {
                    case 1:
                        {
                            pictureBox1.Image = Image.FromFile(@"../../../cubeImages/one.png");
                            break;
                        }

                    case 2:
                        {
                            pictureBox1.Image = Image.FromFile(@"../../../cubeImages/two.jpg");
                            break;
                        }

                    case 3:
                        {
                            pictureBox1.Image = Image.FromFile(@"../../../cubeImages/three.jpg");
                            break;
                        }

                    case 4:
                        {
                            pictureBox1.Image = Image.FromFile(@"../../../cubeImages/four.jpg");
                            break;
                        }

                    case 5:
                        {
                            pictureBox1.Image = Image.FromFile(@"../../../cubeImages/five.jpg");
                            break;
                        }

                    case 6:
                        {
                            pictureBox1.Image = Image.FromFile(@"../../../cubeImages/six.jpg");
                            break;
                        }
                }
            }

            else if (cubeNum == 2)
            {
                switch (cube)
                {
                    case 1:
                        {
                            pictureBox2.Image = Image.FromFile(@"../../../cubeImages/one.png");
                            break;
                        }

                    case 2:
                        {
                            pictureBox2.Image = Image.FromFile(@"../../../cubeImages/two.jpg");
                            break;
                        }

                    case 3:
                        {
                            pictureBox2.Image = Image.FromFile(@"../../../cubeImages/three.jpg");
                            break;
                        }

                    case 4:
                        {
                            pictureBox2.Image = Image.FromFile(@"../../../cubeImages/four.jpg");
                            break;
                        }

                    case 5:
                        {
                            pictureBox2.Image = Image.FromFile(@"../../../cubeImages/five.jpg");
                            break;
                        }

                    case 6:
                        {
                            pictureBox2.Image = Image.FromFile(@"../../../cubeImages/six.jpg");
                            break;
                        }
                        //pictureBox1.Image = Image.FromFile(Environment.CurrentDirectory + "Resources/" +cube1.ToString()+".jpg");
                        //pictureBox2.Image = Image.FromFile(Environment.CurrentDirectory + "Resources/" + cube2.ToString() + ".jpg");
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
