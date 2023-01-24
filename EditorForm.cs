using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.SymbolStore;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Edgy_Name_Generator
{
    public partial class EditorForm : Form
    {
        // Fields

        private int spacing = 10;
        private WordManager linguist;

        private List<TextBox> adjMembers;
        private int adjInputs;

        private List<GroupBox> nounMembers;
        private int nounInputs;



        // Constructor

        public EditorForm(WordManager linguist)
        {
            InitializeComponent();

            this.linguist = linguist;

            adjInputs = 1;
            adjMembers = new List<TextBox>{ txtAdjAdd };

            nounInputs = 1;
            nounMembers = new List<GroupBox> { grpAddNoun };
        }



        // -------------------------------
        // - - - - - FORM EVENTS - - - - -
        // -------------------------------

        private void EditorForm_Load(object sender, EventArgs e)
        {
            // Fix dimensions of window
            this.Text = "Edit Vocabulary";
            this.Width = 1000;
            this.Height = 600;

            // Set label locations
            lbl1.Location = new Point((500 - lbl1.Width) / 2, 15);
            lbl2.Location = new Point((1500 - lbl2.Width) / 2, 15);

            // Add controls to adjective input
            for (int i = 0; i < 9; i++)
            {
                TextBox nextBox = new TextBox();
                nextBox.Size = txtAdjAdd.Size;
                nextBox.Location = new Point(txtAdjAdd.Location.X, adjMembers[i].Location.Y + txtAdjAdd.Height + spacing);
                nextBox.Visible = false;
                nextBox.Font = new Font(new FontFamily("Microsoft Sans Serif"), 7.8f, FontStyle.Regular, GraphicsUnit.Point);
                grpInput2.Controls.Add(nextBox);
                nextBox.TextChanged += txtAdjAdd_TextChanged;
                adjMembers.Add(nextBox);
            }

            // Add controls to noun input
            for (int i = 0; i < 9; i++)
            {
                // Initialize another groupbox
                GroupBox nextBox = new GroupBox();
                nextBox.Size = grpAddNoun.Size;
                nextBox.Location = new Point(grpAddNoun.Location.X, nounMembers[i].Location.Y + grpAddNoun.Height);
                nextBox.Visible = false;

                // Create the controls
                TextBox singText = new TextBox();    // Textbox for singular input
                singText.Name = "txtAddSing";
                CheckBox plurCheck = new CheckBox(); // Checkox to toggle plural
                plurCheck.Name = "chkAddPlur";
                TextBox plurText = new TextBox();    // Textbox for plural input
                plurText.Name = "txtAddPlur";

                // Size and place the controls
                singText.Size = grpAddNoun.Controls["txtAddSing"].Size;
                singText.Location = grpAddNoun.Controls["txtAddSing"].Location;
                plurCheck.Size = grpAddNoun.Controls["chkAddPlur"].Size;
                plurCheck.Location = grpAddNoun.Controls["chkAddPlur"].Location;
                plurText.Size = grpAddNoun.Controls["txtAddPlur"].Size;
                plurText.Location = grpAddNoun.Controls["txtAddPlur"].Location;

                // Set up some defaults
                singText.Font = new Font(new FontFamily("Microsoft Sans Serif"), 7.8f, FontStyle.Regular, GraphicsUnit.Point);
                singText.TabIndex = 2 + i;
                plurCheck.Checked = true;
                plurCheck.TabStop = false;
                plurText.Font = new Font(new FontFamily("Microsoft Sans Serif"), 7.8f, FontStyle.Regular, GraphicsUnit.Point);
                plurText.TabIndex = 3 + i;
                plurText.Enabled = true;

                // Add events to the controls
                singText.TextChanged += txtAddSing_TextChanged;
                plurCheck.CheckedChanged += chkAddPlur_CheckedChanged;
                plurText.TextChanged += txtAddPlur_TextChanged;

                // Actually add controls to this groupbox
                nextBox.Controls.Add(singText);
                nextBox.Controls.Add(plurCheck);
                nextBox.Controls.Add(plurText);


                grpInput1.Controls.Add(nextBox);
                nounMembers.Add(nextBox);
            }

            // Set up combo boxes
            RefreshFamilyList(cmbFamily1);
            cmbFamily1.SelectedIndex = 0;
            RefreshFamilyList(cmbFamily2);
            cmbFamily2.SelectedIndex = 0;
        }

        private void EditorForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            linguist.UpdateFiles();
        }

        private void EditorForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Global.Editor = null;
        }


        // -------------------------------
        // - - - - - NOUN EVENTS - - - - -
        // -------------------------------

        private void txtAddSing_TextChanged(object sender, EventArgs e)
        {
            TextBox singText = (TextBox)sender;
            CheckBox thisCheck = (CheckBox)singText.Parent.Controls["chkAddPlur"];
            TextBox plurText = (TextBox)singText.Parent.Controls["txtAddPlur"];

            if (thisCheck.Checked && singText.Text != "")
                plurText.Text = singText.Text + "s";
            else if (plurText.Text == "s" || singText.Text == "")
                plurText.Text = "";

            ScanInputs(grpAddNoun);
        }
        private void chkAddPlur_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox thisCheck = (CheckBox)sender;
            TextBox singText = (TextBox)thisCheck.Parent.Controls["txtAddSing"];
            TextBox plurText = (TextBox)thisCheck.Parent.Controls["txtAddPlur"];

            if (thisCheck.Checked)
            {
                plurText.Enabled = true;

                if (singText.Text != "")
                    plurText.Text = singText.Text + "s";
            }
            else
            {
                plurText.Text = "";
                plurText.Enabled = false;
            }

            txtAddPlur_TextChanged(sender, e);

            ScanInputs(grpAddNoun);
        }
        private void txtAddPlur_TextChanged(object sender, EventArgs e)
        {
            ScanInputs(grpAddNoun);
        }

        private void cmbNounFam_SelectedIndexChanged(object sender, EventArgs e)
        {
            // If "New Family" is selected, hide the check box list
            if (cmbFamily1.SelectedIndex == 0)
            {
                grpNounRemove.Visible = false;

                cmbFamily1.Text = "New Family";
                txtName1.Text = "New Family";
            }

            // If any other family is selected, refresh the check box list
            else
            {
                grpNounRemove.Visible = true;

                cmbFamily1.Text = linguist.NounFamilies[cmbFamily1.SelectedIndex - 1].Name;
                txtName1.Text = linguist.NounFamilies[cmbFamily1.SelectedIndex - 1].Name;

                RefreshVocabList(chkLstNoun);
            }
        }

        private void btnInput1_Click(object sender, EventArgs e)
        {
            // Initialize some variables
            WordFamily<NounPair> expecting = null;                         // Family to be added to
            NounPair inputNoun;                                  // Placeholder for noun to be added
            List<string> successList = new List<string>();       // List of successfully added nouns
            List<NounPair> inputList = new List<NounPair>();     // Temporary list of inputted nouns
            string inputName = ForceCasing(txtName1.Text); // Inputted family name

            btnName_Click(btnName1, e);

            // Go through each input group box
            foreach (GroupBox bestBox in nounMembers)
            {
                if (bestBox.Visible == false) // Stop searching if group box is not visible
                    break;
                else
                {
                    string inputSing = ForceCasing(bestBox.Controls["txtAddSing"].Text); // Force casing of singular

                    CheckBox plurCheck = (CheckBox)bestBox.Controls["chkAddPlur"];
                    if (plurCheck.Checked) // If plural toggle is checked
                    {
                        string inputPlur = ForceCasing(bestBox.Controls["txtAddPlur"].Text); // Force casing of plural
                        inputNoun = new NounPair(inputSing, inputPlur);                      // Define input noun
                    }
                    else
                        inputNoun = new NounPair(inputSing); // Define input noun

                    inputList.Add(inputNoun); // Add input noun to input list

                    // Clear the group box
                    bestBox.Controls["txtAddSing"].Text = "";                       // Reset singular text
                    CheckBox plurToggle = (CheckBox)bestBox.Controls["chkAddPlur"];
                    plurToggle.Checked = true;                                      // Check plural checkbox
                    bestBox.Controls["txtAddPlur"].Text = "";                       // Reset plural text
                }
            }

            if (cmbFamily1.SelectedIndex == 0) // If a new family is being created
            {
                WordFamily<NounPair> newFam = new WordFamily<NounPair>(inputName);      // Initialize new family
                bool addTest = linguist.AddNounFamily(newFam.Name); // Test if family can be added

                if (addTest) // If successful, update expecting
                    expecting = newFam;
                else // If unsuccessful, prompt the user with a message box
                {
                    DialogResult result = MessageBox.Show
                        ($"A '{newFam.Name}' family already exists. Add contents to the existing '{newFam.Name}'?",
                        "DUPLICATE FOUND",
                        MessageBoxButtons.YesNo);

                    if (result == DialogResult.Yes) // If yes, transfer expecting family
                        expecting = linguist.NounFamilies[cmbFamily1.Items.IndexOf(newFam.Name) - 1];
                    else // If no, rename this family
                        newFam.Name += " but different";
                }

                MessageBox.Show($"The '{newFam.Name}' family has been added to the list."); // Inform the user
            }
            else // Otherwise, get expecting family from combo box selection
            {
                expecting = linguist.NounFamilies[cmbFamily1.SelectedIndex - 1];
            }

            while (inputList.Count > 0)
            {
                WordFamily<NounPair> addTest = linguist.AddNoun(inputList[0], expecting); // Try adding a noun

                if (addTest == null) // If successful
                    successList.Add(inputList[0].Singular);
                else if (addTest == expecting) // If expecting family already contained the noun
                    MessageBox.Show($"{inputList[0].Singular} was already in '{expecting.Name}'.");
                else // If another family contains the noun
                {
                    DialogResult result = MessageBox.Show
                        ($"{inputList[0].Singular} is already in '{addTest.Name}'. Remove {inputList[0].Singular} from '{addTest.Name}'?",
                        "DUPLICATE FOUND",
                        MessageBoxButtons.YesNo);

                    if (result == DialogResult.Yes) // If yes, remove noun from its family
                    {
                        RemoveNoun(inputList[0], addTest, sender, e);

                        // Now we can add the noun
                        linguist.AddNoun(inputList[0], expecting);
                        successList.Add(inputList[0].Singular);
                    }
                }

                inputList.RemoveAt(0); // Remove noun from input list
            }

            if (successList.Count > 0) // If there are nouns left, construct an informative message
            {
                string message = $"added to '{expecting.Name}'.";

                for (int i = successList.Count; i > 0; i--)
                {
                    if (successList.Count == 1) { message = $"{successList[i - 1]} was {message}"; }
                    else if (successList.Count == 2)
                    {
                        if (i == 2) { message = $"and {successList[i - 1]} were {message} "; }
                        else { message = $"{successList[i - 1]} {message} "; }
                    }
                    else
                    {
                        if (i == successList.Count) { message = $"and {successList[i - 1]} were {message}"; }
                        else { message = $"{successList[i - 1]}, {message}"; }
                    }
                }

                MessageBox.Show(message); // Inform the user of what's been added
            }

            // Reset everything
            while (nounInputs > 1)
                btnMinus_Click(btnMinus1, e);

            // Refresh some stuff
            RefreshVocabList(chkLstNoun);
            RefreshFamilyList(cmbFamily1);

            // Change the index selected to maintain the family
            if (expecting == null) { cmbFamily1.SelectedIndex = 0; }
            else                   { cmbFamily1.SelectedIndex = cmbFamily1.Items.IndexOf(expecting.Name); }
            cmbNounFam_SelectedIndexChanged(sender, e);

            // Put the cursor back on that first text box
            txtAddSing.Focus();
        }
        private void btnNounRemove_Click(object sender, EventArgs e)
        {
            WordFamily<NounPair> expecting = linguist.NounFamilies[cmbFamily1.SelectedIndex - 1]; // Family to remove from

            List<NounPair> trashNouns = new List<NounPair>(); // Declare list of nouns to remove
            foreach (int index in chkLstNoun.CheckedIndices)  // Run through checked indices
                trashNouns.Add(expecting.Items[index]);       // Add corresponding nouns to list

            foreach (NounPair trashNoun in trashNouns)        // Run through noun list
                RemoveNoun(trashNoun, expecting, sender, e);  // Remove them from family

            // This may seem redundant but it's necessary as the checklist will update with every removal
        }



        // ------------------------------------
        // - - - - - ADJECTIVE EVENTS - - - - -
        // ------------------------------------

        private void txtAdjAdd_TextChanged(object sender, EventArgs e)
        {
            ScanInputs(grpInput2);
        }

        private void cmbAdjFam_SelectedIndexChanged(object sender, EventArgs e)
        {
            // If "New Family" is selected, hide the check box list
            if (cmbFamily2.SelectedIndex == 0)
                grpAdjRemove.Visible = false;
            // If any other family is selected, refresh the check box list
            else
            {
                grpAdjRemove.Visible = true;
                RefreshVocabList(chkLstAdj);
            }

            // Make sure the text matches the selection
            if (cmbFamily2.SelectedIndex == 0)
            {
                cmbFamily2.Text = "New Family";
                txtName2.Text = "New Family";
            }
            else
            {
                cmbFamily2.Text = linguist.AdjFamilies[cmbFamily2.SelectedIndex - 1].Name;
                txtName2.Text = linguist.AdjFamilies[cmbFamily2.SelectedIndex - 1].Name;
            }
        }

        private void btnInput2_Click(object sender, EventArgs e)
        {
            // Initialize some variables
            WordFamily<string> expecting = null;                         // Family to be added to
            string inputAdj;                                    // Placeholder for adjectives to be added
            List<string> successList = new List<string>();      // List of successfully added adjectives
            List<string> inputList = new List<string>();        // Temporary list of inputted adjectives
            string inputName = ForceCasing(txtName2.Text); // Inputted family name

            btnName_Click(btnName2, e);

            // Go through each input text box
            foreach (TextBox bestBox in adjMembers)
            {
                if (bestBox.Visible == false) // Stop searching if text box is not visible
                    break;
                else
                {
                    inputAdj = ForceCasing(bestBox.Text); // Force casing of adjective
                    inputList.Add(inputAdj);              // Add input adjective to input list
                    bestBox.Clear();                      // Clear text box
                }
            }

            if (cmbFamily2.SelectedIndex == 0) // If a new family is being created
            {
                WordFamily<string> newFam = new WordFamily<string>(inputName);       // Initialize new family
                bool addTest = linguist.AddAdjFamily(newFam.Name); // Test if family can be added

                if (addTest) // If successful, update expecting
                    expecting = newFam;
                else // If unsuccessful, prompt the user with a message box
                {
                    DialogResult result = MessageBox.Show
                        ($"A '{newFam.Name}' family already exists. Add contents to the existing '{newFam.Name}'?",
                        "DUPLICATE FOUND",
                        MessageBoxButtons.YesNo);

                    if (result == DialogResult.Yes) // If yes, transfer expecting family
                        expecting = linguist.AdjFamilies[cmbFamily2.Items.IndexOf(newFam.Name) - 1];
                    else // If no, rename this family
                        newFam.Name += " but different";
                }

                MessageBox.Show($"The '{newFam.Name}' family has been added to the list."); // Inform the user
            }
            else // Otherwise, get expecting family from combo box selection
            {
                expecting = linguist.AdjFamilies[cmbFamily2.SelectedIndex - 1];
            }

            while (inputList.Count > 0)
            {
                WordFamily<string> addTest = linguist.AddAdj(inputList[0], expecting); // Try adding an adjective

                if (addTest == null) // If successful
                    successList.Add(inputList[0]);
                else if (addTest == expecting) // If expecting family already contained the adjective
                    MessageBox.Show($"{inputList[0]} was already in '{expecting.Name}'.");
                else // If another family contains the adjective
                {
                    DialogResult result = MessageBox.Show
                        ($"{inputList[0]} is already in '{addTest.Name}'. Remove {inputList[0]} from '{addTest.Name}'?",
                        "DUPLICATE FOUND",
                        MessageBoxButtons.YesNo);

                    if (result == DialogResult.Yes) // If yes, remove adjective from its family
                    {
                        RemoveAdj(inputList[0], addTest, sender, e);

                        // Now we can add the adjective
                        linguist.AddAdj(inputList[0], expecting);
                        successList.Add(inputList[0]);
                    }
                }

                inputList.RemoveAt(0); // Remove adjective from input list
            }

            if (successList.Count > 0) // If there are adjectives left, construct an informative message
            {
                string message = $"added to '{expecting.Name}'.";

                for (int i = successList.Count; i > 0; i--)
                {
                    if (successList.Count == 1) { message = $"{successList[i - 1]} was {message}"; }
                    else if (successList.Count == 2)
                    {
                        if (i == 2) { message = $"and {successList[i - 1]} were {message} "; }
                        else { message = $"{successList[i - 1]} {message} "; }
                    }
                    else
                    {
                        if (i == successList.Count) { message = $"and {successList[i - 1]} were {message}"; }
                        else { message = $"{successList[i - 1]}, {message}"; }
                    }
                }

                MessageBox.Show(message); // Inform the user of what's been added
            }

            // Reset everything
            while (adjInputs > 1)
                btnMinus_Click(btnMinus2, e);

            // Refresh some stuff
            RefreshVocabList(chkLstAdj);
            RefreshFamilyList(cmbFamily2);

            // Change the index selected to maintain the family
            if (expecting == null) { cmbFamily2.SelectedIndex = 0; }
            else { cmbFamily2.SelectedIndex = cmbFamily2.Items.IndexOf(expecting.Name); }
            cmbAdjFam_SelectedIndexChanged(sender, e);

            // Put the cursor back on that first text box
            txtAdjAdd.Focus();
        }
        private void btnAdjRemove_Click(object sender, EventArgs e)
        {
            WordFamily<string> expecting = linguist.AdjFamilies[cmbFamily2.SelectedIndex - 1]; // Family to remove from

            List<string> trashAdjs = new List<string>();      // Declare list of adjectives to remove
            foreach (int index in chkLstAdj.CheckedIndices)  // Run through checked indices
                trashAdjs.Add(expecting.Items[index]);       // Add corresponding adjectives to list

            foreach (string trashAdj in trashAdjs)        // Run through adjective list
                RemoveAdj(trashAdj, expecting, sender, e);  // Remove them from family

            // This may seem redundant but it's necessary as the checklist will update with every removal
        }



        // ----------------------------------
        // - - - - - DUAL FUNCTIONS - - - - -
        // ----------------------------------

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            TextBox nameText = (TextBox)sender;                                               // Get object as text box
            int textNum = (int)Char.GetNumericValue(nameText.Name[nameText.Name.Length - 1]); // Get number at end of control name

            // Declare variables for controls
            ComboBox familyPicker = (ComboBox)this.Controls[$"cmbFamily{textNum}"];
            Button nameButton = (Button)nameText.Parent.Controls[$"btnName{textNum}"];

            // Toggle enabled state of button
            if (familyPicker.SelectedIndex == 0)
                if (nameText.Text == "") { nameButton.Enabled = false; }
                else                     { nameButton.Enabled = true;  }
            else
                if (nameText.Text == "")
                    { nameButton.Enabled = false; }
                else if (textNum == 1 && ForceCasing(nameText.Text) == linguist.NounFamilies[familyPicker.SelectedIndex - 1].Name)
                    { nameButton.Enabled = false; }
                else if (textNum == 2 && ForceCasing(nameText.Text) == linguist.AdjFamilies[familyPicker.SelectedIndex - 1].Name)
                    { nameButton.Enabled = false; }
                else 
                    { nameButton.Enabled = true;  }
        }
        private void btnName_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;                                         // Get object as button
            int btnNum = (int)Char.GetNumericValue(btn.Name[btn.Name.Length - 1]); // Get number at end of control name

            if (btnNum == 1)
            {
                string inputName = ForceCasing(txtName1.Text); // Inputted family name

                int nameIndex = linguist.IndexOfNounFamily(inputName); // Search for name duplicate
                if (nameIndex != -1 && nameIndex != cmbFamily1.SelectedIndex - 1) // If family name was already found
                {
                    MessageBox.Show
                        ($"A '{inputName}' family already exists.",
                        "DUPLICATE FOUND",
                        MessageBoxButtons.OK);

                    inputName += " but different";
                }

                if (cmbFamily1.SelectedIndex == 0)
                {
                    linguist.AddNounFamily(inputName);
                }
                else
                    linguist.NounFamilies[cmbFamily1.SelectedIndex - 1].Name = inputName;

                linguist.NounFamilies.Sort();
                RefreshFamilyList(cmbFamily1);
                cmbFamily1.SelectedIndex = cmbFamily1.Items.IndexOf(inputName);
            }
            else if (btnNum == 2)
            {
                string inputName = ForceCasing(txtName2.Text); // Inputted family name

                int nameIndex = linguist.IndexOfAdjFamily(inputName); // Search for name duplicate
                if (nameIndex != -1 && nameIndex != cmbFamily2.SelectedIndex - 1) // If family name was already found
                {
                    MessageBox.Show
                        ($"A '{inputName}' family already exists.",
                        "DUPLICATE FOUND",
                        MessageBoxButtons.OK);

                    inputName += " but different";
                }

                if (cmbFamily2.SelectedIndex == 0)
                {
                    linguist.AddAdjFamily(inputName);
                }
                else
                    linguist.AdjFamilies[cmbFamily2.SelectedIndex - 1].Name = inputName;

                linguist.AdjFamilies.Sort();
                RefreshFamilyList(cmbFamily2);
                cmbFamily2.SelectedIndex = cmbFamily2.Items.IndexOf(inputName);
            }
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;                                         // Get object as button
            int btnNum = (int)Char.GetNumericValue(btn.Name[btn.Name.Length - 1]); // Get number at end of control name

            if (btnNum == 1)
            {
                nounInputs++;
                lblInput1.Text = $"Amount: {nounInputs}";
                nounMembers[nounInputs - 1].Visible = true;

                btnInput1.Location = new Point(btnInput1.Location.X, btnInput1.Location.Y + grpAddNoun.Height + (spacing / 2));
                grpInput1.Size = new Size(grpInput1.Width, grpInput1.Height + nounMembers[0].Height + (spacing / 2));

                if (nounInputs >= 10)
                {
                    btnPlus1.Visible = false;
                    btnMinus1.Visible = true;
                }
                else
                    btnMinus1.Visible = true;

                nounMembers[nounInputs - 1].Focus();
                ScanInputs(grpAddNoun);
            }
            else if (btnNum == 2)
            {
                adjInputs++;
                lblInput2.Text = $"Amount: {adjInputs}";
                adjMembers[adjInputs - 1].Visible = true;

                btnInput2.Location = new Point(btnInput2.Location.X, btnInput2.Location.Y + adjMembers[0].Height + spacing);
                grpInput2.Size = new Size(grpInput2.Width, grpInput2.Height + adjMembers[0].Height + spacing);

                if (adjInputs >= 10)
                {
                    btnPlus2.Visible = false;
                    btnMinus2.Visible = true;
                }
                else
                    btnMinus2.Visible = true;

                adjMembers[adjInputs - 1].Focus();
                ScanInputs(grpInput2);
            }
        }
        private void btnMinus_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;                                         // Get object as button
            int btnNum = (int)Char.GetNumericValue(btn.Name[btn.Name.Length - 1]); // Get number at end of control name

            if (btnNum == 1)
            {
                nounInputs--;
                lblInput1.Text = $"Amount: {nounInputs}";
                nounMembers[nounInputs].Visible = false;

                // Clear this text box
                nounMembers[nounInputs].Controls[0].Text = "";
                CheckBox check = (CheckBox)nounMembers[nounInputs].Controls[1];
                check.Checked = true;
                nounMembers[nounInputs].Controls[2].Text = "";

                btnInput1.Location = new Point(btnInput1.Location.X, btnInput1.Location.Y - grpAddNoun.Height - (spacing / 2));
                grpInput1.Size = new Size(grpInput1.Width, grpInput1.Height - nounMembers[0].Height - (spacing / 2));

                if (nounInputs <= 1)
                {
                    btnPlus1.Visible = true;
                    btnMinus1.Visible = false;
                }
                else
                    btnPlus1.Visible = true;

                nounMembers[nounInputs - 1].Focus();
                ScanInputs(grpAddNoun);
            }
            else if (btnNum == 2)
            {
                adjInputs--;
                lblInput2.Text = $"Amount: {adjInputs}";
                adjMembers[adjInputs].Visible = false;

                adjMembers[adjInputs].Clear();

                btnInput2.Location = new Point(btnInput2.Location.X, btnInput2.Location.Y - adjMembers[0].Height - spacing);
                grpInput2.Size = new Size(grpInput2.Width, grpInput2.Height - adjMembers[0].Height - spacing);

                if (adjInputs <= 1)
                {
                    btnPlus2.Visible = true;
                    btnMinus2.Visible = false;
                }
                else
                    btnPlus2.Visible = true;

                adjMembers[adjInputs - 1].Focus();
                ScanInputs(grpInput2);
            }
        }



        // ------------------------------------
        // - - - - - HELPER FUNCTIONS - - - - -
        // ------------------------------------

        /// <summary>
        /// Rewrites the contents of a combo box.
        /// </summary>
        /// <param name="checklist">The combo box to refresh.</param>
        private void RefreshFamilyList(ComboBox combo)
        {
            combo.Items.Clear();
            combo.Items.Add("New Family");

            if (combo == cmbFamily2)
                foreach (WordFamily<string> adjFam in linguist.AdjFamilies)
                    combo.Items.Add(adjFam.Name);
            else if (combo == cmbFamily1)
                foreach (WordFamily<NounPair> nounFam in linguist.NounFamilies)
                    combo.Items.Add(nounFam.Name);
        }

        /// <summary>
        /// Rewrites the contents of a family's checked list box.
        /// </summary>
        /// <param name="checklist">The checked list box to refresh.</param>
        private void RefreshVocabList(CheckedListBox checklist)
        {
            checklist.Items.Clear();

            if (checklist == chkLstAdj && cmbFamily2.SelectedIndex > 0)
            {
                foreach (string word in linguist.AdjFamilies[cmbFamily2.SelectedIndex - 1].Items)
                    chkLstAdj.Items.Add(word);

                checklist.Size = new Size(checklist.Width, checklist.PreferredHeight);
                checklist.Parent.Size = new Size(checklist.Parent.Width, checklist.Location.Y + checklist.Height + spacing);
            }
            else if (checklist == chkLstNoun && cmbFamily1.SelectedIndex > 0)
            {
                foreach (NounPair word in linguist.NounFamilies[cmbFamily1.SelectedIndex - 1].Items)
                    chkLstNoun.Items.Add(word.Full);

                checklist.Size = new Size(checklist.Width, checklist.PreferredHeight);
                checklist.Parent.Size = new Size(checklist.Parent.Width, checklist.Location.Y + checklist.Height + spacing);
            }
        }

        /// <summary>
        /// Scans the inputs for a group box, and enables or disables the submit button associated.
        /// </summary>
        /// <param name="group">The group box to scan.</param>
        private void ScanInputs(GroupBox group)
        {
            bool emptyBox = false;

            if (group == grpInput2)
            {
                if (txtName2.Text == "")
                    emptyBox = true;

                foreach (TextBox box in adjMembers)
                {
                    if (box.Visible == false)
                        break;
                    else
                    {
                        if (box.Text == "")
                        {
                            emptyBox = true;
                            break;
                        }
                    }
                }

                btnInput2.Enabled = !emptyBox;
            }
            else if (group == grpAddNoun)
            {
                if (txtName1.Text == "")
                    emptyBox = true;

                foreach (GroupBox binder in nounMembers)
                {
                    if (binder.Visible == false)
                        break;
                    else
                    {
                        if (binder.Controls["txtAddSing"].Text == "")
                        {
                            emptyBox = true;
                            break;
                        }
                        else if (binder.Controls["txtAddPlur"].Enabled && binder.Controls["txtAddPlur"].Text == "")
                        {
                            emptyBox = true;
                            break;
                        }
                    }
                }

                btnInput1.Enabled = !emptyBox;
            }
        }





        /// <summary>
        /// Removes a noun pair from its respective family, and displays a messagebox on success.
        /// </summary>
        /// <param name="trashAdj">The noun pair to be removed.</param>
        /// <param name="trashFam">The family to be removed from</param>
        private void RemoveNoun(NounPair trashNoun, WordFamily<NounPair> trashFam, object sender, EventArgs e)
        {
            // Check to see how the removal went
            switch (linguist.RemoveNoun(trashNoun, trashFam))
            {
                // If successful
                case 0:
                    MessageBox.Show($"{trashNoun.Singular} was removed from '{trashFam.Name}'.");
                    RefreshVocabList(chkLstNoun);
                    break;

                // If that was the last noun in the family
                case 1:
                    MessageBox.Show($"The '{trashFam.Name}' family has been removed.");

                    // Refresh the boxes
                    RefreshFamilyList(cmbFamily1);
                    RefreshVocabList(chkLstNoun);

                    // Change the index selected to "New Family"
                    cmbFamily1.SelectedIndex = 0;
                    break;

                // If the adjective is simply removed
                case 2:
                    MessageBox.Show($"{trashNoun.Singular} couldn't be found in '{trashFam.Name}'.");
                    break;

                // Default
                default:
                    MessageBox.Show("Butter.");
                    break;
            }
        }

        /// <summary>
        /// Removes an adjective from its respective family, and displays a messagebox on success.
        /// </summary>
        /// <param name="trashAdj">The adjective to be removed.</param>
        /// <param name="trashFam">The family to be removed from</param>
        private void RemoveAdj(string trashAdj, WordFamily<string> trashFam, object sender, EventArgs e)
        {
            // Check to see how the removal went
            switch (linguist.RemoveAdj(trashAdj, trashFam))
            {
                // If successful
                case 0:
                    MessageBox.Show($"{trashAdj} was removed from '{trashFam.Name}'.");
                    RefreshVocabList(chkLstAdj);
                    break;

                // If that was the last adjective in the family
                case 1:
                    MessageBox.Show($"The '{trashFam.Name}' family has been removed.");

                    // Refresh the boxes
                    RefreshFamilyList(cmbFamily2);
                    RefreshVocabList(chkLstAdj);

                    // Change the index selected to "New Family"
                    cmbFamily2.SelectedIndex = 0;
                    break;

                // If the adjective is simply removed
                case 2:
                    MessageBox.Show($"{trashAdj} couldn't be found in '{trashFam.Name}'.");
                    break;

                // Default
                default:
                    MessageBox.Show("Buttery.");
                    break;
            }
        }
        
        /// <summary>
        /// Returns a string with only the first character capitalized
        /// </summary>
        /// <param name="input">the inputted string</param>
        /// <returns></returns>
        private string ForceCasing(string input)
        {
            input = input.ToLower();
            return char.ToUpper(input[0]) + input.Substring(1);
        }
    }
}
