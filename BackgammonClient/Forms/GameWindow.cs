
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
        private int selectedSlot;

        private int color;

        private int cube1, cube2, usedCube;
        private bool cube1Used = false;
        private bool cube2Used = false;

        // Bar representation - one for each player
        private int whiteOnBar = 0;
        private int blackOnBar = 0;
        //private Button whiteBarButton;
        //private Button blackBarButton;

        // Disc buttons for the bar
        private Button whiteBarDiscButton;
        private Button blackBarDiscButton;

        // Images for discs
        private Image whiteDiscImage;
        private Image blackDiscImage;
        private Image redSlotTopImage;
        private Image whiteSlotTopImage;
        private Image redSlotBottonImage;
        private Image whiteSlotBottomImage;

        // Add these properties to track the checkers that have been borne off
        private int whiteCheckersOff = 0;
        private int blackCheckersOff = 0;

        // Add UI elements to display the number of checkers borne off
        private Label whiteOffLabel;
        private Label blackOffLabel;

        // Add a button to represent the bearing off area
        private Button whiteBearOffButton;
        private Button blackBearOffButton;

        // Flag to track if we're moving from the bar
        private bool movingFromBar = false;

        public event Action OnSwitchTurn;
        public event Action<string> sendMessage;
        private Color[] discsColor = [System.Drawing.SystemColors.ButtonHighlight, System.Drawing.SystemColors.ActiveCaptionText];

        private delegate void delSwitchTurn(bool turn);
        private delegate void delUpdateBoard(string state);
        public GameWindow(int color)
        {
            InitializeComponent();
            this.color = color;

            // Load the disc images once
            whiteDiscImage = Image.FromFile(@"../../../boardImages/white.png");
            blackDiscImage = Image.FromFile(@"../../../boardImages/black.png");
            redSlotTopImage = Image.FromFile(@"../../../boardImages/red slot top.png");
            whiteSlotTopImage = Image.FromFile(@"../../../boardImages/white slot top.png");
            redSlotBottonImage = Image.FromFile(@"../../../boardImages/red slot.png");
            whiteSlotBottomImage = Image.FromFile(@"../../../boardImages/white slot.png");

            buildBoard();
            initialSlots();
            placeDiscs();
            updateBarDisplay();
            SetupBearingOff();
            initalTurn(color == 1);
        }

        public void switchTurn(bool turn)
        {
            this.Invoke(new delSwitchTurn(initalTurn), turn);
        }

        public bool isDone()
        {
            return false;
        }
        public void updateBoard(string state)
        {
            this.Invoke(new delUpdateBoard(stateChanged), state);
        }

        public void initalTurn(bool turn)
        {
            this.updatesLabel.Text = "";

            // When starting a new turn, reset dice and move counters
            if (turn)
            {
                // Reset dice usage when a new turn starts
                cube1Used = false;
                cube2Used = false;
                cube1 = 0;
                cube2 = 0;
                movesRemaining = 0;

                // Clear the dice images
                pictureBox1.Image = null;
                pictureBox2.Image = null;
            }

            disableButtons(turn);

            if (turn)
            {
                this.turnLabel.Text = "IT'S YOUR TURN";
            }
            else
            {
                this.turnLabel.Text = "IT'S NOT YOUR TURN";
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
            // Always start by disabling all slot buttons
            for (int i = 0; i < slots.Length; i++)
            {
                this.slotsButtons[i].Enabled = false;
            }

            // Enable/disable done button based on turn
            this.roll.Enabled = false;
            doneButton.Enabled = turn;

            // Only enable roll button if it's a new turn
            // We don't want to re-enable it if it was explicitly disabled after rolling
            if (turn && (cube1Used || cube2Used || movesRemaining == 0))
            {
                // If dice were used or there are no moves remaining, roll should stay disabled
                roll.Enabled = false;
            }
            else if (turn && movesRemaining == 0)
            {
                // If it's a new turn (no moves remaining from previous turn), enable the roll button
                roll.Enabled = true;
            }

            // For the initial turn, we want roll to be enabled
            if (turn && cube1 == 0 && cube2 == 0)
            {
                roll.Enabled = true;
            }

            // Initially disable ALL disc buttons
            for (int i = 0; i < this.discsButtons.Length; i++)
            {
                if (discsButtons[i] != null)
                {
                    this.discsButtons[i].Enabled = false;
                }
            }

            // Initially disable bar buttons
            whiteBarDiscButton.Enabled = false;
            blackBarDiscButton.Enabled = false;

            // If it's not the player's turn, we're done (everything remains disabled)
            if (!turn)
                return;

            // Check if player has checkers on the bar
            bool whiteHasCheckersOnBar = whiteOnBar > 0;
            bool blackHasCheckersOnBar = blackOnBar > 0;

            // WHITE PLAYER'S TURN
            if (this.color == 1 && turn)
            {
                if (whiteHasCheckersOnBar)
                {
                    // White player has checkers on bar - ONLY enable white bar disc button
                    whiteBarDiscButton.Enabled = true;

                    // Make sure the bar disc is visible
                    whiteBarDiscButton.Visible = true;

                    // Set the updates label message
                    this.updatesLabel.Text = "You must move your checkers from the bar first!";
                }
                else
                {
                    // No checkers on bar - enable regular white disc buttons
                    for (int i = 0; i < this.discsButtons.Length; i++)
                    {
                        if (discsButtons[i] != null && (int)this.discsButtons[i].Tag == 1)
                        {
                            this.discsButtons[i].Enabled = true;
                        }
                    }
                    this.updatesLabel.Text = "";
                }
            }
            // BLACK PLAYER'S TURN
            else if (this.color == 2 && turn)
            {
                if (blackHasCheckersOnBar)
                {
                    // Black player has checkers on bar - ONLY enable black bar disc button
                    blackBarDiscButton.Enabled = true;

                    // Make sure the bar disc is visible
                    blackBarDiscButton.Visible = true;

                    // Set the updates label message
                    this.updatesLabel.Text = "You must move your checkers from the bar first!";
                }
                else
                {
                    // No checkers on bar - enable regular black disc buttons
                    for (int i = 0; i < this.discsButtons.Length; i++)
                    {
                        if (discsButtons[i] != null && (int)this.discsButtons[i].Tag == 2)
                        {
                            this.discsButtons[i].Enabled = true;
                        }
                    }
                    this.updatesLabel.Text = "";
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
            this.updatesLabel.Text = "";
        }

        public void stateChanged(string state)
        {
            string[] stateComponents = state.Split(';');

            // Process slots
            for (int i = 0; i < slots.Length; i++)
            {
                if (i < stateComponents.Length)
                {
                    string[] slot = stateComponents[i].Split(':');
                    slots[i].setColor(Int32.Parse(slot[0]));
                    slots[i].setQuantity(Int32.Parse(slot[1]));
                }
            }

            // Process bar information if available
            int infoIndex = slots.Length;
            if (stateComponents.Length > infoIndex)
            {
                string[] barInfo = stateComponents[infoIndex].Split(':');
                if (barInfo[0] == "bar" && barInfo.Length == 3)
                {
                    whiteOnBar = Int32.Parse(barInfo[1]);
                    blackOnBar = Int32.Parse(barInfo[2]);
                    updateBarDisplay();
                }

                // Process bearing off information if available
                infoIndex++;
                if (stateComponents.Length > infoIndex)
                {
                    string[] offInfo = stateComponents[infoIndex].Split(':');
                    if (offInfo[0] == "off" && offInfo.Length == 3)
                    {
                        whiteCheckersOff = Int32.Parse(offInfo[1]);
                        blackCheckersOff = Int32.Parse(offInfo[2]);

                        // Update the UI
                        whiteOffLabel.Text = whiteCheckersOff.ToString();
                        blackOffLabel.Text = blackCheckersOff.ToString();
                    }
                }
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

                    this.discsButtons[counter] = new Button();

                    Point location = this.slotsButtons[i].Location;
                    if (i > (slots.Length / 2) - 1)
                    {
                        this.discsButtons[counter].Location = new System.Drawing.Point(location.X + 10, location.Y - (j * 30) + 120);
                    }
                    else
                    {
                        this.discsButtons[counter].Location = new System.Drawing.Point(location.X + 10, location.Y + (j * 30));
                    }

                    // Set background image and Tag, and BackColor
                    if (slots[i].getColor() == 1)
                    {
                        this.discsButtons[counter].BackgroundImage = whiteDiscImage;
                        this.discsButtons[counter].BackgroundImageLayout = ImageLayout.Stretch;
                        this.discsButtons[counter].Tag = 1; // 1 for white
                        this.discsButtons[counter].Name = counter.ToString();
                    }
                    else
                    {
                        this.discsButtons[counter].BackgroundImage = blackDiscImage;
                        this.discsButtons[counter].BackgroundImageLayout = ImageLayout.Stretch;
                        this.discsButtons[counter].Tag = 2; // 2 for black
                        this.discsButtons[counter].Name = counter.ToString();
                    }

                    // Make buttons transparent
                    this.discsButtons[counter].FlatStyle = FlatStyle.Flat;
                    this.discsButtons[counter].FlatAppearance.BorderSize = 0;
                    this.discsButtons[counter].BackColor = Color.Transparent;
                    this.discsButtons[counter].UseVisualStyleBackColor = false; // Add this line

                    this.discsButtons[counter].Size = new System.Drawing.Size(30, 30);
                    this.discsButtons[counter].TabIndex = 36;
                    this.discsButtons[counter].TabStop = false;

                    // Check if it's the player's turn and if the disc color matches the player's color
                    bool isTurn = this.turnLabel.Text == "IT'S YOUR TURN";

                    // Don't enable regular discs if there are checkers on the bar
                    bool playerHasCheckersOnBar = (this.color == 1 && whiteOnBar > 0) || (this.color == 2 && blackOnBar > 0);
                    if (playerHasCheckersOnBar)
                    {
                        this.discsButtons[counter].Enabled = false;
                    }
                    else
                    {
                        // Enable only if it's the player's turn and the disc color matches
                        this.discsButtons[counter].Enabled = isTurn && ((int)this.discsButtons[counter].Tag == this.color);
                    }

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
            // Check if player has checkers on the bar
            bool playerHasCheckersOnBar = (this.color == 1 && whiteOnBar > 0) ||
                                         (this.color == 2 && blackOnBar > 0);

            // If player has checkers on the bar, they must move those first
            if (playerHasCheckersOnBar)
            {
                // Update the label instead of showing a message box
                this.updatesLabel.Text = "You must move your checkers from the bar first!";
                return;
            }

            // Continue with normal disc selection logic
            int selectedDiscId = int.Parse(((Button)sender).Name);
            int selectedDiscColor = (int)((Button)sender).Tag;

            // Store the selected disc for later use
            this.selectedDisc = discs[selectedDiscId];
            int slot = selectedDisc.getSlotId();

            // Disable all slots first
            for (int i = 0; i < slotsButtons.Length; i++)
            {
                slotsButtons[i].Enabled = false;
                this.slotsButtons[i].BackColor = System.Drawing.Color.Silver;
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
                this.slotsButtons[slotId].BackColor = System.Drawing.Color.Gainsboro;
            }
        }

        public void buildBoard()
        {
            placeSlotsTop();
            placeSlotsBottom();
            placeBars();

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

            // Use the movingFromBar flag to determine if we're moving from the bar
            if (!movingFromBar)
            {
                // Regular move from a slot
                if (slots[selectedSlot].getQuantity() > 0)
                {
                    slots[selectedSlot].setQuantity(slots[selectedSlot].getQuantity() - 1);
                }
            }

            // Check if we're hitting an opponent's checker
            bool isHit = false;
            if (slots[selectedSlotId].getQuantity() == 1 && slots[selectedSlotId].getColor() != this.color)
            {
                // This is a hit!
                isHit = true;

                // Add the hit checker to the appropriate bar
                if (this.color == 1) // White hits Black
                {
                    blackOnBar++;
                }
                else // Black hits White
                {
                    whiteOnBar++;
                }

                // Clear the slot for our checker
                slots[selectedSlotId].setQuantity(0);
            }

            // Add our disc to the target slot
            slots[selectedSlotId].setQuantity(slots[selectedSlotId].getQuantity() + 1);
            slots[selectedSlotId].setColor(this.color);

            // If we moved from bar, decrement the appropriate bar counter
            if (movingFromBar)
            {
                if (this.color == 1)
                {
                    whiteOnBar--;
                }
                else
                {
                    blackOnBar--;
                }
            }

            int diff;
            if (movingFromBar)
            {
                // Calculate the difference based on entry point rules
                if (this.color == 1) // White
                {
                    diff = 24 - selectedSlotId;
                }
                else // Black
                {
                    diff = selectedSlotId + 1;
                }
            }
            else
            {
                diff = Math.Abs(selectedSlotId - selectedSlot);
            }

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

            // Reset the movingFromBar flag
            movingFromBar = false;

            // Reset selection
            selectedDisc = null;

            if (movesRemaining <= 0)
            {
                this.OnSwitchTurn?.Invoke();
            }

            // Important: Redraw the board to reflect changes
            placeDiscs();
            updateBarDisplay(); // Update bar visualization

            // Check if we still have checkers on the bar and if it's still our turn
            if ((this.color == 1 && whiteOnBar > 0) || (this.color == 2 && blackOnBar > 0))
            {
                // We still have checkers on the bar, check if there are valid moves
                bool hasValidMove = false;

                if (!cube1Used)
                {
                    hasValidMove |= CheckValidEntryExists(cube1);
                }

                if (!cube2Used)
                {
                    hasValidMove |= CheckValidEntryExists(cube2);
                }

                if (!hasValidMove && movesRemaining > 0)
                {
                    // Update label instead of showing a message box
                    this.updatesLabel.Text = "No valid moves available to enter from the bar. Turn passes.";
                    this.OnSwitchTurn?.Invoke();
                }
            }

            disableUsedCube();
            sendState();
        }

        private bool CheckValidEntryExists(int dieValue)
        {
            int entryPoint;

            if (this.color == 1) // White
            {
                entryPoint = 24 - dieValue;
            }
            else // Black
            {
                entryPoint = dieValue - 1;
            }

            // Check if this point is a valid entry
            if (entryPoint >= 0 && entryPoint < 24)
            {
                if (slots[entryPoint].getColor() == this.color ||
                    slots[entryPoint].getQuantity() <= 1 ||
                    slots[entryPoint].getQuantity() == 0)
                {
                    return true;
                }
            }

            return false;
        }

        public void disableUsedCube()
        {
            // Disable all slots first
            for (int i = 0; i < slotsButtons.Length; i++)
            {
                slotsButtons[i].Enabled = false;
                this.slotsButtons[i].BackColor = System.Drawing.Color.Silver;
            }

            // Check if player has checkers on the bar
            bool playerHasCheckersOnBar = (this.color == 1 && whiteOnBar > 0) ||
                                         (this.color == 2 && blackOnBar > 0);

            if (playerHasCheckersOnBar)
            {
                // Player has checkers on the bar, show entry points
                if (!cube1Used)
                {
                    EnableEntryPoint(cube1);
                }

                if (!cube2Used)
                {
                    EnableEntryPoint(cube2);
                }
                return;
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

            // Check if the player can bear off
            if (CanBearOff(this.color))
            {
                // For bearing off, we need to enable the bearing off "button"
                // For white (color 1), moving down from slots 0-5
                // For black (color 2), moving up from slots 18-23

                if (this.color == 1) // white
                {
                    // White bears off by going "below" slot 0
                    if (currentSlot - dieValue < 0)
                    {
                        // Enable bearing off only if:
                        // 1. The die value exactly matches the distance (e.g., checker on point 3 with die value 3)
                        // 2. OR, the die value is greater than the distance AND there are no checkers further away

                        bool canBearOff = false;
                        if (currentSlot + 1 == dieValue) // Exact match
                        {
                            canBearOff = true;
                        }
                        else if (currentSlot + 1 < dieValue) // Die is larger than needed
                        {
                            // Check if there are no checkers on higher points
                            bool hasHigherCheckers = false;
                            for (int i = currentSlot + 1; i <= 5; i++)
                            {
                                if (slots[i].getColor() == this.color && slots[i].getQuantity() > 0)
                                {
                                    hasHigherCheckers = true;
                                    break;
                                }
                            }
                            canBearOff = !hasHigherCheckers;
                        }

                        if (canBearOff)
                        {
                            // Enable the bearing off "button" for white
                            whiteBearOffButton.Enabled = true;
                            whiteBearOffButton.BackColor = System.Drawing.Color.Gainsboro;
                            return;
                        }
                    }

                    // Regular move
                    if (currentSlot - dieValue >= 0)
                        targetSlot = currentSlot - dieValue;
                }
                else // black
                {
                    // Black bears off by going "above" slot 23
                    if (currentSlot + dieValue > 23)
                    {
                        // Enable bearing off only if:
                        // 1. The die value exactly matches the distance (e.g., checker on point 21 with die value 3)
                        // 2. OR, the die value is greater than the distance AND there are no checkers further away

                        bool canBearOff = false;
                        if (24 - currentSlot == dieValue) // Exact match
                        {
                            canBearOff = true;
                        }
                        else if (24 - currentSlot < dieValue) // Die is larger than needed
                        {
                            // Check if there are no checkers on lower points
                            bool hasLowerCheckers = false;
                            for (int i = 18; i < currentSlot; i++)
                            {
                                if (slots[i].getColor() == this.color && slots[i].getQuantity() > 0)
                                {
                                    hasLowerCheckers = true;
                                    break;
                                }
                            }
                            canBearOff = !hasLowerCheckers;
                        }

                        if (canBearOff)
                        {
                            // Enable the bearing off "button" for black
                            blackBearOffButton.Enabled = true;
                            blackBearOffButton.BackColor = System.Drawing.Color.Gainsboro;
                            return;
                        }
                    }

                    // Regular move
                    if (currentSlot + dieValue < slotsButtons.Length)
                        targetSlot = currentSlot + dieValue;
                }
            }
            else
            {
                // Regular move logic (no bearing off)
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
            }

            if (targetSlot != -1)
                enableValidSlot(targetSlot);
        }

        private void BarDiscClick(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            bool isWhiteBar = clickedButton == whiteBarDiscButton;

            // Set the movingFromBar flag
            movingFromBar = true;

            // Only allow clicking your own bar disc
            if ((isWhiteBar && this.color == 1 && whiteOnBar > 0) ||
                (!isWhiteBar && this.color == 2 && blackOnBar > 0))
            {
                // Disable all slot buttons first
                for (int i = 0; i < slotsButtons.Length; i++)
                {
                    slotsButtons[i].Enabled = false;
                    slotsButtons[i].BackColor = System.Drawing.Color.Silver;
                }

                // Enable valid entry points based on dice
                bool hasValidMove = false;

                if (!cube1Used)
                {
                    hasValidMove |= EnableEntryPoint(cube1);
                }

                if (!cube2Used)
                {
                    hasValidMove |= EnableEntryPoint(cube2);
                }

                // If no valid moves available, switch turn
                if (!hasValidMove && movesRemaining > 0)
                {
                    // Update label instead of showing a message box
                    this.updatesLabel.Text = "No valid moves available to enter from the bar. Turn passes.";
                    movingFromBar = false; // Reset the flag
                    this.OnSwitchTurn?.Invoke();
                }
            }
        }

        private bool EnableEntryPoint(int dieValue)
        {
            int entryPoint;
            bool validMoveFound = false;

            if (this.color == 1) // White
            {
                // White enters from point 24 (which is 23 in 0-based indexing)
                entryPoint = 24 - dieValue;
            }
            else // Black
            {
                // Black enters from point 1 (which is 0 in 0-based indexing)
                entryPoint = dieValue - 1;
            }

            // Check if the entry point is valid and within bounds
            if (entryPoint >= 0 && entryPoint < 24)
            {
                // Check if this point is a valid entry (either empty, has our pieces, or only 1 opponent piece)
                if (slots[entryPoint].getColor() == this.color ||
                    slots[entryPoint].getQuantity() <= 1 ||
                    slots[entryPoint].getQuantity() == 0)
                {
                    this.slotsButtons[entryPoint].Enabled = true;
                    this.slotsButtons[entryPoint].BackColor = System.Drawing.Color.Gainsboro;
                    validMoveFound = true;
                }
            }

            return validMoveFound;
        }

        private void updateBarDisplay()
        {
            // Update white bar disc
            if (whiteOnBar > 0)
            {
                whiteBarDiscButton.Visible = true;
                whiteBarDiscButton.Text = whiteOnBar > 1 ? whiteOnBar.ToString() : "";

                // Set background image instead of color
                whiteBarDiscButton.BackgroundImage = whiteDiscImage;
                whiteBarDiscButton.BackgroundImageLayout = ImageLayout.Stretch;
                whiteBarDiscButton.Tag = 1; // Tag as white
                whiteBarDiscButton.FlatStyle = FlatStyle.Flat;
                whiteBarDiscButton.FlatAppearance.BorderSize = 0;
                whiteBarDiscButton.BackColor = Color.Transparent;

                // Only enable if it's this player's turn and they are white
                whiteBarDiscButton.Enabled = (this.turnLabel.Text == "IT'S YOUR TURN" && this.color == 1);
            }
            else
            {
                whiteBarDiscButton.Visible = false;
                whiteBarDiscButton.Text = "";
            }

            // Update black bar disc
            if (blackOnBar > 0)
            {
                blackBarDiscButton.Visible = true;
                blackBarDiscButton.Text = blackOnBar > 1 ? blackOnBar.ToString() : "";

                // Set background image instead of color
                blackBarDiscButton.BackgroundImage = blackDiscImage;
                blackBarDiscButton.BackgroundImageLayout = ImageLayout.Stretch;
                blackBarDiscButton.Tag = 2; // Tag as black
                blackBarDiscButton.FlatStyle = FlatStyle.Flat;
                blackBarDiscButton.FlatAppearance.BorderSize = 0;
                blackBarDiscButton.BackColor = Color.Transparent;
                blackBarDiscButton.ForeColor = Color.White; // White text on black background

                // Only enable if it's this player's turn and they are black
                blackBarDiscButton.Enabled = (this.turnLabel.Text == "IT'S YOUR TURN" && this.color == 2);
            }
            else
            {
                blackBarDiscButton.Visible = false;
                blackBarDiscButton.Text = "";
            }
        }
        private bool CanBearOff(int playerColor)
        {
            // Check if any checkers are on bar
            if ((playerColor == 1 && whiteOnBar > 0) || (playerColor == 2 && blackOnBar > 0))
                return false;

            // Define home board range for each player
            int startSlot = (playerColor == 1) ? 0 : 18;
            int endSlot = (playerColor == 1) ? 5 : 23;

            // Check if all checkers are in the home board
            for (int i = 0; i < slots.Length; i++)
            {
                // If there's a checker of the player's color outside the home board, can't bear off
                if (slots[i].getColor() == playerColor && slots[i].getQuantity() > 0)
                {
                    if (i < startSlot || i > endSlot)
                        return false;
                }
            }

            return true;
        }

        private void BearOffClick(object sender, EventArgs e)
        {
            // null check
            if (selectedDisc == null)
            {
                this.updatesLabel.Text = "Please select a checker to bear off first.";
                return;
            }

            Button clickedButton = (Button)sender;
            bool isWhiteBearingOff = clickedButton == whiteBearOffButton;

            int slotId = selectedDisc.getSlotId();

            int dieValue;

            if (this.color == 1) // white
            {
                dieValue = slotId + 1; // For white, distance from 0

                // If exact match with cube1, use cube1
                if (dieValue == cube1 && !cube1Used)
                {
                    cube1Used = true;
                    usedCube = cube1;
                }
                // If exact match with cube2, use cube2
                else if (dieValue == cube2 && !cube2Used)
                {
                    cube2Used = true;
                    usedCube = cube2;
                }
                // If greater than cube1, use cube1
                else if (dieValue < cube1 && !cube1Used)
                {
                    cube1Used = true;
                    usedCube = cube1;
                }
                // If greater than cube2, use cube2
                else if (dieValue < cube2 && !cube2Used)
                {
                    cube2Used = true;
                    usedCube = cube2;
                }

                // Remove the checker from the slot
                slots[slotId].setQuantity(slots[slotId].getQuantity() - 1);

                // Increment the checkers off counter
                whiteCheckersOff++;
                whiteOffLabel.Text = whiteCheckersOff.ToString();
            }
            else // black
            {
                dieValue = 24 - slotId; // For black, distance from 24

                // If exact match with cube1, use cube1
                if (dieValue == cube1 && !cube1Used)
                {
                    cube1Used = true;
                    usedCube = cube1;
                }
                // If exact match with cube2, use cube2
                else if (dieValue == cube2 && !cube2Used)
                {
                    cube2Used = true;
                    usedCube = cube2;
                }
                // If greater than cube1, use cube1
                else if (dieValue < cube1 && !cube1Used)
                {
                    cube1Used = true;
                    usedCube = cube1;
                }
                // If greater than cube2, use cube2
                else if (dieValue < cube2 && !cube2Used)
                {
                    cube2Used = true;
                    usedCube = cube2;
                }

                // Remove the checker from the slot
                slots[slotId].setQuantity(slots[slotId].getQuantity() - 1);

                // Increment the checkers off counter
                blackCheckersOff++;
                blackOffLabel.Text = blackCheckersOff.ToString();
            }

            usedCubesAmount++;
            movesRemaining--;

            // Reset selection
            selectedDisc = null;

            // Check if we've won
            if ((this.color == 1 && whiteCheckersOff == 15) || (this.color == 2 && blackCheckersOff == 15))
            {
                // Game over, player has won
                this.updatesLabel.Text = "Game Over! You have borne off all your checkers!";
                // Disable further moves
                roll.Enabled = false;
                doneButton.Enabled = false;
            }
            else if (movesRemaining <= 0)
            {
                this.OnSwitchTurn?.Invoke();
            }

            // Important: Redraw the board to reflect changes
            placeDiscs();

            // Disable used cube
            disableUsedCube();

            // Send the state update
            sendState();
        }
        public void sendState()
        {
            string[] slotsString = new string[slots.Length];
            for (int i = 0; i < slots.Length; i++)
            {
                slotsString[i] = slots[i].toString();
            }

            // Add bar information to the state
            string barInfo = "bar:" + whiteOnBar + ":" + blackOnBar;

            // Add bearing off information
            string bearOffInfo = "off:" + whiteCheckersOff + ":" + blackCheckersOff;

            sendMessage("State," + string.Join(";", slotsString) + ";" + barInfo + ";" + bearOffInfo);
        }

        private void rollTheDice_click(object sender, EventArgs e)
        {
            // Clear any previous updates message
            this.updatesLabel.Text = "";

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

            // Check if player has checkers on the bar and no valid moves
            bool playerHasCheckersOnBar = (this.color == 1 && whiteOnBar > 0) ||
                                         (this.color == 2 && blackOnBar > 0);

            if (playerHasCheckersOnBar)
            {
                bool hasValidMove = false;

                hasValidMove |= CheckValidEntryExists(cube1);
                hasValidMove |= CheckValidEntryExists(cube2);

                if (!hasValidMove)
                {
                    // Update label instead of showing a message box
                    this.updatesLabel.Text = "No valid moves available to enter from the bar. Turn passes.";
                    this.OnSwitchTurn?.Invoke();
                }
            }

            // Update button states after roll
            disableButtons(true);
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
            int x = 735;
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
                this.slotsButtons[i].BackColor = System.Drawing.Color.Silver;
                this.slotsButtons[i].Click += new System.EventHandler(this.SlotClick);
                this.Controls.Add(this.slotsButtons[i]);
                this.slotsButtons[i].SendToBack();

                if ((i + 1) % (slotsButtons.Length / 4) == 0 && i != 0 && i != slotsButtons.Length / 2 - 1)
                {
                    x -= 50;
                }
                if (i % 2 == 0)
                {
                    this.slotsButtons[i].BackgroundImage = redSlotTopImage;
                    this.slotsButtons[i].BackgroundImageLayout = ImageLayout.Stretch;
                }
                else if (i % 2 == 1)
                {
                    this.slotsButtons[i].BackgroundImage = whiteSlotTopImage;
                    this.slotsButtons[i].BackgroundImageLayout = ImageLayout.Stretch;
                }
                x -= 50;
            }
        }
        public void placeSlotsBottom()
        {
            int y = 285;
            int x = 135;
            for (int i = slotsButtons.GetLength(0) / 2; i < slotsButtons.Length; i++)
            {
                this.slotsButtons[i] = new Button();

                this.slotsButtons[i].Location = new System.Drawing.Point(x, y);
                this.slotsButtons[i].Name = "slot," + (i);
                this.slotsButtons[i].Size = new System.Drawing.Size(50, 153);
                this.slotsButtons[i].TabIndex = 36;
                this.slotsButtons[i].TabStop = false;
                this.slotsButtons[i].BackColor = System.Drawing.Color.Silver;
                this.slotsButtons[i].Click += new System.EventHandler(this.SlotClick);
                this.Controls.Add(this.slotsButtons[i]);
                this.slotsButtons[i].SendToBack();

                if ((i + 1) % (slotsButtons.Length / 4) == 0 && i != 0)
                {
                    x += 50;
                }

                if (i % 2 == 0)
                {
                    this.slotsButtons[i].BackgroundImage = redSlotBottonImage;
                    this.slotsButtons[i].BackgroundImageLayout = ImageLayout.Stretch;
                }
                else if (i % 2 == 1)
                {
                    this.slotsButtons[i].BackgroundImage = whiteSlotBottomImage;
                    this.slotsButtons[i].BackgroundImageLayout = ImageLayout.Stretch;
                }

                x += 50;
            }
            x = 50;


        }
        public void placeBars()
        {
            // Create disc buttons that sit on top of the bar buttons
            whiteBarDiscButton = new Button();
            whiteBarDiscButton.Location = new System.Drawing.Point(435 + 10, 130 + 60); // Center on bar
            whiteBarDiscButton.Name = "whiteBarDisc";
            whiteBarDiscButton.Size = new System.Drawing.Size(30, 30); // Same as other disc buttons
            whiteBarDiscButton.TabIndex = 42;
            whiteBarDiscButton.TabStop = false;
            whiteBarDiscButton.BackgroundImage = whiteDiscImage;
            whiteBarDiscButton.BackgroundImageLayout = ImageLayout.Stretch;
            whiteBarDiscButton.Tag = 1; // Tag as white
            whiteBarDiscButton.FlatStyle = FlatStyle.Flat;
            whiteBarDiscButton.FlatAppearance.BorderSize = 0;
            whiteBarDiscButton.BackColor = Color.Transparent;
            whiteBarDiscButton.Visible = false; // Hidden by default
            whiteBarDiscButton.Click += new System.EventHandler(this.BarDiscClick);
            this.Controls.Add(whiteBarDiscButton);
            whiteBarDiscButton.BringToFront();

            blackBarDiscButton = new Button();
            blackBarDiscButton.Location = new System.Drawing.Point(435 + 10, 165 + 60); // Center on bar
            blackBarDiscButton.Name = "blackBarDisc";
            blackBarDiscButton.Size = new System.Drawing.Size(30, 30); // Same as other disc buttons
            blackBarDiscButton.TabIndex = 43;
            blackBarDiscButton.TabStop = false;
            blackBarDiscButton.BackgroundImage = blackDiscImage;
            blackBarDiscButton.BackgroundImageLayout = ImageLayout.Stretch;
            blackBarDiscButton.Tag = 2; // Tag as black
            blackBarDiscButton.FlatStyle = FlatStyle.Flat;
            blackBarDiscButton.FlatAppearance.BorderSize = 0;
            blackBarDiscButton.BackColor = Color.Transparent;
            blackBarDiscButton.ForeColor = System.Drawing.Color.White;
            blackBarDiscButton.Visible = false; // Hidden by default
            blackBarDiscButton.Click += new System.EventHandler(this.BarDiscClick);
            this.Controls.Add(blackBarDiscButton);
            blackBarDiscButton.BringToFront();
        }

        private void SetupBearingOff()
        {
            // Set up the bearing off buttons
            whiteBearOffButton = new Button();
            whiteBearOffButton.Location = new System.Drawing.Point(800, 60); // Position on left side for white
            whiteBearOffButton.Name = "whiteBearOff";
            whiteBearOffButton.Size = new System.Drawing.Size(50, 100);
            whiteBearOffButton.TabIndex = 44;
            whiteBearOffButton.TabStop = false;
            whiteBearOffButton.Text = "BEAR OFF";
            whiteBearOffButton.BackColor = System.Drawing.Color.Silver;
            whiteBearOffButton.Enabled = false;
            whiteBearOffButton.Click += new System.EventHandler(this.BearOffClick);
            this.Controls.Add(whiteBearOffButton);

            blackBearOffButton = new Button();
            blackBearOffButton.Location = new System.Drawing.Point(800, 345); // Position on right side for black
            blackBearOffButton.Name = "blackBearOff";
            blackBearOffButton.Size = new System.Drawing.Size(50, 100);
            blackBearOffButton.TabIndex = 45;
            blackBearOffButton.TabStop = false;
            blackBearOffButton.Text = "BEAR OFF";
            blackBearOffButton.BackColor = System.Drawing.Color.Silver;
            blackBearOffButton.Enabled = false;
            blackBearOffButton.Click += new System.EventHandler(this.BearOffClick);
            this.Controls.Add(blackBearOffButton);

            // Set up labels to show count of borne off checkers
            whiteOffLabel = new Label();
            whiteOffLabel.Location = new System.Drawing.Point(50, 225);
            whiteOffLabel.Name = "whiteOffLabel";
            whiteOffLabel.Size = new System.Drawing.Size(50, 20);
            whiteOffLabel.Text = "0";
            whiteOffLabel.TextAlign = ContentAlignment.MiddleCenter;
            this.Controls.Add(whiteOffLabel);

            blackOffLabel = new Label();
            blackOffLabel.Location = new System.Drawing.Point(800, 375);
            blackOffLabel.Name = "blackOffLabel";
            blackOffLabel.Size = new System.Drawing.Size(50, 20);
            blackOffLabel.Text = "0";
            blackOffLabel.TextAlign = ContentAlignment.MiddleCenter;
            this.Controls.Add(blackOffLabel);
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