using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Edgy_Name_Generator
{
    public partial class GeneratorForm : Form
    {
        // Fields

        private Random actOfGod = new Random();
        private WordManager linguist = new WordManager();

        private int spacing = 10;



        // Constructor

        public GeneratorForm()
        {
            InitializeComponent();
        }



        // Events

        /// <summary>
        /// Initial setup as the form loads.
        /// </summary>
        private void Form1_Load(object sender, EventArgs e)
        {
            // Fix dimensions of window
            this.Text = "Edgy Name Generator";
            this.Width = 1000;
            this.Height = 600;

            // Set locations
            lblName.Location = new Point((this.Width - lblName.Width) / 2, 2 * spacing);
            lblTitle.Location = new Point((this.Width - lblTitle.Width) / 2, lblName.Height + (3 * spacing));
            grpOptions.Location = new Point((this.Width - grpOptions.Width) / 2, lblName.Height + lblTitle.Height + (8 * spacing));

            // Get a random name
            linguist.currentName = linguist.GetRandomName();
            RefreshName();

            // Get a random title
            linguist.currentTitle = linguist.GetRandomTitle();
            RefreshTitle();
        }

        /// <summary>
        /// Center everything when form size changes.
        /// </summary>
        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            HorizontallyCenter(grpOptions);
            HorizontallyCenter(lblName);
            HorizontallyCenter(lblTitle);
        }


        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (Global.Editor == null)
            {
                Global.Editor = new EditorForm(linguist);
                Global.Editor.Show();
            }
        }
        private void randomButton_Click(object sender, EventArgs e)
        {
            switch ((sender as Button).Parent.Name)
            {
                case "grpName":
                    linguist.currentName = linguist.GetRandomName();
                    break;

                case "grpNameA":
                    if (linguist.currentName.Style == NameStyle.AdjNoun)
                        linguist.currentName.FirstWord = linguist.GetRandomAdj();
                    else
                        linguist.currentName.FirstWord = linguist.GetRandomNoun();
                    break;

                case "grpNameB":
                    linguist.currentName.SecondWord = linguist.GetRandomNoun();
                    break;

                case "grpTitle":
                    linguist.currentTitle = linguist.GetRandomTitle();
                    break;

                case "grpTitleA":
                    if (linguist.currentTitle.Style == TitleStyle.TheAdjNoun)
                        linguist.currentTitle.FirstWord = linguist.GetRandomAdj();
                    else
                        linguist.currentTitle.FirstWord = linguist.GetRandomNoun();
                    break;

                case "grpTitleB":
                    if (linguist.currentTitle.Style == TitleStyle.NounOfTheAdj)
                        linguist.currentTitle.SecondWord = linguist.GetRandomAdj();
                    else
                        linguist.currentTitle.SecondWord = linguist.GetRandomNoun();
                    break;

                default:
                    linguist.currentName = linguist.GetRandomName();
                    linguist.currentTitle = linguist.GetRandomTitle();
                    break;
            }

            RefreshName();
            RefreshTitle();
        }
        private void swapButton_Click(object sender, EventArgs e)
        {
            switch ((sender as Button).Parent.Name)
            {
                case "grpName":
                    linguist.currentName.SwapNouns();
                    break;

                case "grpTitle":
                    linguist.currentTitle.SwapNouns();
                    break;

                default:
                    break;
            }

            RefreshName();
            RefreshTitle();
        }
        private void styleButton_Click(object sender, EventArgs e)
        {
            switch ((sender as Button).Parent.Name)
            {
                case "grpName":
                    linguist.currentName.CycleStyle();
                    break;

                case "grpTitle":
                    linguist.currentTitle.CycleStyle();
                    break;

                default:
                    break;
            }

            RefreshName();
            RefreshTitle();
        }
        private void relatedButton_Click(object sender, EventArgs e)
        {
            WordFamily<string> tempFamA;
            WordFamily<NounPair> tempFamN;
            int index;

            switch ((sender as Button).Parent.Name)
            {
                case "grpNameA":
                    if (linguist.currentName.Style == NameStyle.AdjNoun)
                    {
                        tempFamA = linguist.GetFamilyOf((string)linguist.currentName.FirstWord);
                        index = tempFamA.IndexOf((string)linguist.currentName.FirstWord);

                        if (index == tempFamA.Count - 1)
                            linguist.currentName.FirstWord = tempFamA[0];
                        else
                            linguist.currentName.FirstWord = tempFamA[index + 1];
                    }
                    else
                    {
                        tempFamN = linguist.GetFamilyOf((NounPair)linguist.currentName.FirstWord);
                        index = tempFamN.IndexOf((NounPair)linguist.currentName.FirstWord);

                        if (index == tempFamN.Count - 1)
                            linguist.currentName.FirstWord = tempFamN[0];
                        else
                            linguist.currentName.FirstWord = tempFamN[index + 1];
                    }
                    break;

                case "grpNameB":
                    tempFamN = linguist.GetFamilyOf((NounPair)linguist.currentName.SecondWord);
                    index = tempFamN.IndexOf((NounPair)linguist.currentName.SecondWord);

                    if (index == tempFamN.Count - 1)
                        linguist.currentName.SecondWord = tempFamN[0];
                    else
                        linguist.currentName.SecondWord = tempFamN[index + 1];
                    break;

                case "grpTitleA":
                    if (linguist.currentTitle.Style == TitleStyle.TheAdjNoun)
                    {
                        tempFamA = linguist.GetFamilyOf((string)linguist.currentTitle.FirstWord);
                        index = tempFamA.IndexOf((string)linguist.currentTitle.FirstWord);

                        if (index == tempFamA.Count - 1)
                            linguist.currentTitle.FirstWord = tempFamA[0];
                        else
                            linguist.currentTitle.FirstWord = tempFamA[index + 1];
                    }
                    else
                    {
                        tempFamN = linguist.GetFamilyOf((NounPair)linguist.currentTitle.FirstWord);
                        index = tempFamN.IndexOf((NounPair)linguist.currentTitle.FirstWord);

                        if (index == tempFamN.Count - 1)
                            linguist.currentTitle.FirstWord = tempFamN[0];
                        else
                            linguist.currentTitle.FirstWord = tempFamN[index + 1];
                    }
                    break;

                case "grpTitleB":
                    if (linguist.currentTitle.Style == TitleStyle.NounOfTheAdj)
                    {
                        tempFamA = linguist.GetFamilyOf((string)linguist.currentTitle.SecondWord);
                        index = tempFamA.IndexOf((string)linguist.currentTitle.SecondWord);

                        if (index == tempFamA.Count - 1)
                            linguist.currentTitle.SecondWord = tempFamA[0];
                        else
                            linguist.currentTitle.SecondWord = tempFamA[index + 1];
                    }
                    else
                    {
                        tempFamN = linguist.GetFamilyOf((NounPair)linguist.currentTitle.SecondWord);
                        index = tempFamN.IndexOf((NounPair)linguist.currentTitle.SecondWord);

                        if (index == tempFamN.Count - 1)
                            linguist.currentTitle.SecondWord = tempFamN[0];
                        else
                            linguist.currentTitle.SecondWord = tempFamN[index + 1];
                    }
                    break;

                default:
                    break;
            }

            RefreshName();
            RefreshTitle();
        }

        private void RefreshName()
        {
            lblName.Text = linguist.currentName.Full;
            HorizontallyCenter(lblName);

            if (linguist.currentName.Style == NameStyle.AdjNoun)
            {
                btnSwap1.Enabled = false;
                btnStyle1.Enabled = false;
            }
            else
            {
                btnSwap1.Enabled = true;
                btnStyle1.Enabled = true;
            }
        }
        private void RefreshTitle()
        {
            lblTitle.Text = linguist.currentTitle.Full;
            HorizontallyCenter(lblTitle);

            if (linguist.currentTitle.Style == TitleStyle.TheAdjNoun || linguist.currentTitle.Style == TitleStyle.NounOfTheAdj)
                btnSwap2.Enabled = false;
            else
                btnSwap2.Enabled = true;
        }
        private void HorizontallyCenter(Control control)
        {
            control.Location = new Point((this.Width - control.Width) / 2, control.Location.Y);
        }
    }
}
