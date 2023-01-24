using System;

namespace Edgy_Name_Generator
{
    partial class EditorForm
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
            this.btnInput1 = new System.Windows.Forms.Button();
            this.grpInput1 = new System.Windows.Forms.GroupBox();
            this.btnName1 = new System.Windows.Forms.Button();
            this.txtName1 = new System.Windows.Forms.TextBox();
            this.grpAddNoun = new System.Windows.Forms.GroupBox();
            this.txtAddPlur = new System.Windows.Forms.TextBox();
            this.chkAddPlur = new System.Windows.Forms.CheckBox();
            this.txtAddSing = new System.Windows.Forms.TextBox();
            this.btnMinus1 = new System.Windows.Forms.Button();
            this.btnPlus1 = new System.Windows.Forms.Button();
            this.lblInput1 = new System.Windows.Forms.Label();
            this.grpInput2 = new System.Windows.Forms.GroupBox();
            this.btnName2 = new System.Windows.Forms.Button();
            this.btnMinus2 = new System.Windows.Forms.Button();
            this.txtName2 = new System.Windows.Forms.TextBox();
            this.btnPlus2 = new System.Windows.Forms.Button();
            this.lblInput2 = new System.Windows.Forms.Label();
            this.txtAdjAdd = new System.Windows.Forms.TextBox();
            this.btnInput2 = new System.Windows.Forms.Button();
            this.grpAdjRemove = new System.Windows.Forms.GroupBox();
            this.btnAdjRemove = new System.Windows.Forms.Button();
            this.chkLstAdj = new System.Windows.Forms.CheckedListBox();
            this.cmbFamily2 = new System.Windows.Forms.ComboBox();
            this.grpNounRemove = new System.Windows.Forms.GroupBox();
            this.btnNounRemove = new System.Windows.Forms.Button();
            this.chkLstNoun = new System.Windows.Forms.CheckedListBox();
            this.cmbFamily1 = new System.Windows.Forms.ComboBox();
            this.lblFamily1 = new System.Windows.Forms.Label();
            this.lblFamily2 = new System.Windows.Forms.Label();
            this.lbl1 = new System.Windows.Forms.Label();
            this.lbl2 = new System.Windows.Forms.Label();
            this.grpInput1.SuspendLayout();
            this.grpAddNoun.SuspendLayout();
            this.grpInput2.SuspendLayout();
            this.grpAdjRemove.SuspendLayout();
            this.grpNounRemove.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnInput1
            // 
            this.btnInput1.Enabled = false;
            this.btnInput1.Location = new System.Drawing.Point(10, 151);
            this.btnInput1.Name = "btnInput1";
            this.btnInput1.Size = new System.Drawing.Size(280, 38);
            this.btnInput1.TabIndex = 4;
            this.btnInput1.Text = "ADD VOCABULARY";
            this.btnInput1.UseVisualStyleBackColor = true;
            this.btnInput1.Click += new System.EventHandler(this.btnInput1_Click);
            // 
            // grpInput1
            // 
            this.grpInput1.Controls.Add(this.btnName1);
            this.grpInput1.Controls.Add(this.txtName1);
            this.grpInput1.Controls.Add(this.grpAddNoun);
            this.grpInput1.Controls.Add(this.btnMinus1);
            this.grpInput1.Controls.Add(this.btnInput1);
            this.grpInput1.Controls.Add(this.btnPlus1);
            this.grpInput1.Controls.Add(this.lblInput1);
            this.grpInput1.Font = new System.Drawing.Font("Showcard Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpInput1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.grpInput1.Location = new System.Drawing.Point(50, 100);
            this.grpInput1.Name = "grpInput1";
            this.grpInput1.Size = new System.Drawing.Size(300, 200);
            this.grpInput1.TabIndex = 14;
            this.grpInput1.TabStop = false;
            this.grpInput1.Text = "Edit / Add";
            // 
            // btnName1
            // 
            this.btnName1.Enabled = false;
            this.btnName1.Location = new System.Drawing.Point(213, 23);
            this.btnName1.Name = "btnName1";
            this.btnName1.Size = new System.Drawing.Size(77, 38);
            this.btnName1.TabIndex = 0;
            this.btnName1.TabStop = false;
            this.btnName1.Text = "UPDATE";
            this.btnName1.UseVisualStyleBackColor = true;
            this.btnName1.Click += new System.EventHandler(this.btnName_Click);
            // 
            // txtName1
            // 
            this.txtName1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtName1.Location = new System.Drawing.Point(10, 28);
            this.txtName1.Name = "txtName1";
            this.txtName1.Size = new System.Drawing.Size(197, 22);
            this.txtName1.TabIndex = 0;
            this.txtName1.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // grpAddNoun
            // 
            this.grpAddNoun.Controls.Add(this.txtAddPlur);
            this.grpAddNoun.Controls.Add(this.chkAddPlur);
            this.grpAddNoun.Controls.Add(this.txtAddSing);
            this.grpAddNoun.Font = new System.Drawing.Font("Chiller", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpAddNoun.Location = new System.Drawing.Point(10, 95);
            this.grpAddNoun.Name = "grpAddNoun";
            this.grpAddNoun.Size = new System.Drawing.Size(280, 50);
            this.grpAddNoun.TabIndex = 23;
            this.grpAddNoun.TabStop = false;
            // 
            // txtAddPlur
            // 
            this.txtAddPlur.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddPlur.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtAddPlur.Location = new System.Drawing.Point(172, 18);
            this.txtAddPlur.Name = "txtAddPlur";
            this.txtAddPlur.Size = new System.Drawing.Size(100, 22);
            this.txtAddPlur.TabIndex = 2;
            this.txtAddPlur.TextChanged += new System.EventHandler(this.txtAddPlur_TextChanged);
            // 
            // chkAddPlur
            // 
            this.chkAddPlur.AutoSize = true;
            this.chkAddPlur.Checked = true;
            this.chkAddPlur.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAddPlur.Location = new System.Drawing.Point(148, 21);
            this.chkAddPlur.Name = "chkAddPlur";
            this.chkAddPlur.Size = new System.Drawing.Size(18, 17);
            this.chkAddPlur.TabIndex = 0;
            this.chkAddPlur.TabStop = false;
            this.chkAddPlur.UseVisualStyleBackColor = true;
            this.chkAddPlur.CheckedChanged += new System.EventHandler(this.chkAddPlur_CheckedChanged);
            // 
            // txtAddSing
            // 
            this.txtAddSing.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddSing.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtAddSing.Location = new System.Drawing.Point(6, 18);
            this.txtAddSing.Name = "txtAddSing";
            this.txtAddSing.Size = new System.Drawing.Size(100, 22);
            this.txtAddSing.TabIndex = 1;
            this.txtAddSing.TextChanged += new System.EventHandler(this.txtAddSing_TextChanged);
            // 
            // btnMinus1
            // 
            this.btnMinus1.Location = new System.Drawing.Point(41, 63);
            this.btnMinus1.Name = "btnMinus1";
            this.btnMinus1.Size = new System.Drawing.Size(25, 25);
            this.btnMinus1.TabIndex = 16;
            this.btnMinus1.TabStop = false;
            this.btnMinus1.Text = "-";
            this.btnMinus1.UseVisualStyleBackColor = true;
            this.btnMinus1.Visible = false;
            this.btnMinus1.Click += new System.EventHandler(this.btnMinus_Click);
            // 
            // btnPlus1
            // 
            this.btnPlus1.Location = new System.Drawing.Point(10, 63);
            this.btnPlus1.Name = "btnPlus1";
            this.btnPlus1.Size = new System.Drawing.Size(25, 25);
            this.btnPlus1.TabIndex = 15;
            this.btnPlus1.TabStop = false;
            this.btnPlus1.Text = "+";
            this.btnPlus1.UseVisualStyleBackColor = true;
            this.btnPlus1.Click += new System.EventHandler(this.btnPlus_Click);
            // 
            // lblInput1
            // 
            this.lblInput1.AutoSize = true;
            this.lblInput1.Location = new System.Drawing.Point(72, 67);
            this.lblInput1.Name = "lblInput1";
            this.lblInput1.Size = new System.Drawing.Size(80, 18);
            this.lblInput1.TabIndex = 14;
            this.lblInput1.Text = "Amount: 1";
            // 
            // grpInput2
            // 
            this.grpInput2.Controls.Add(this.btnName2);
            this.grpInput2.Controls.Add(this.btnMinus2);
            this.grpInput2.Controls.Add(this.txtName2);
            this.grpInput2.Controls.Add(this.btnPlus2);
            this.grpInput2.Controls.Add(this.lblInput2);
            this.grpInput2.Controls.Add(this.txtAdjAdd);
            this.grpInput2.Controls.Add(this.btnInput2);
            this.grpInput2.Font = new System.Drawing.Font("Showcard Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpInput2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.grpInput2.Location = new System.Drawing.Point(700, 100);
            this.grpInput2.Name = "grpInput2";
            this.grpInput2.Size = new System.Drawing.Size(300, 200);
            this.grpInput2.TabIndex = 15;
            this.grpInput2.TabStop = false;
            this.grpInput2.Text = "Edit / Add";
            // 
            // btnName2
            // 
            this.btnName2.Enabled = false;
            this.btnName2.Location = new System.Drawing.Point(213, 23);
            this.btnName2.Name = "btnName2";
            this.btnName2.Size = new System.Drawing.Size(77, 38);
            this.btnName2.TabIndex = 24;
            this.btnName2.TabStop = false;
            this.btnName2.Text = "UPDATE";
            this.btnName2.UseVisualStyleBackColor = true;
            this.btnName2.Click += new System.EventHandler(this.btnName_Click);
            // 
            // btnMinus2
            // 
            this.btnMinus2.Location = new System.Drawing.Point(41, 63);
            this.btnMinus2.Name = "btnMinus2";
            this.btnMinus2.Size = new System.Drawing.Size(25, 25);
            this.btnMinus2.TabIndex = 13;
            this.btnMinus2.TabStop = false;
            this.btnMinus2.Text = "-";
            this.btnMinus2.UseVisualStyleBackColor = true;
            this.btnMinus2.Visible = false;
            this.btnMinus2.Click += new System.EventHandler(this.btnMinus_Click);
            // 
            // txtName2
            // 
            this.txtName2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtName2.Location = new System.Drawing.Point(10, 28);
            this.txtName2.Name = "txtName2";
            this.txtName2.Size = new System.Drawing.Size(197, 22);
            this.txtName2.TabIndex = 0;
            this.txtName2.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // btnPlus2
            // 
            this.btnPlus2.Location = new System.Drawing.Point(10, 63);
            this.btnPlus2.Name = "btnPlus2";
            this.btnPlus2.Size = new System.Drawing.Size(25, 25);
            this.btnPlus2.TabIndex = 12;
            this.btnPlus2.TabStop = false;
            this.btnPlus2.Text = "+";
            this.btnPlus2.UseVisualStyleBackColor = true;
            this.btnPlus2.Click += new System.EventHandler(this.btnPlus_Click);
            // 
            // lblInput2
            // 
            this.lblInput2.AutoSize = true;
            this.lblInput2.Location = new System.Drawing.Point(72, 67);
            this.lblInput2.Name = "lblInput2";
            this.lblInput2.Size = new System.Drawing.Size(80, 18);
            this.lblInput2.TabIndex = 11;
            this.lblInput2.Text = "Amount: 1";
            // 
            // txtAdjAdd
            // 
            this.txtAdjAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAdjAdd.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtAdjAdd.Location = new System.Drawing.Point(10, 113);
            this.txtAdjAdd.Name = "txtAdjAdd";
            this.txtAdjAdd.Size = new System.Drawing.Size(280, 22);
            this.txtAdjAdd.TabIndex = 1;
            this.txtAdjAdd.TextChanged += new System.EventHandler(this.txtAdjAdd_TextChanged);
            // 
            // btnInput2
            // 
            this.btnInput2.Enabled = false;
            this.btnInput2.Location = new System.Drawing.Point(10, 151);
            this.btnInput2.Name = "btnInput2";
            this.btnInput2.Size = new System.Drawing.Size(280, 38);
            this.btnInput2.TabIndex = 2;
            this.btnInput2.Text = "ADD VOCABULARY";
            this.btnInput2.UseVisualStyleBackColor = true;
            this.btnInput2.Click += new System.EventHandler(this.btnInput2_Click);
            // 
            // grpAdjRemove
            // 
            this.grpAdjRemove.Controls.Add(this.btnAdjRemove);
            this.grpAdjRemove.Controls.Add(this.chkLstAdj);
            this.grpAdjRemove.Font = new System.Drawing.Font("Showcard Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpAdjRemove.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.grpAdjRemove.Location = new System.Drawing.Point(1016, 128);
            this.grpAdjRemove.Name = "grpAdjRemove";
            this.grpAdjRemove.Size = new System.Drawing.Size(234, 271);
            this.grpAdjRemove.TabIndex = 17;
            this.grpAdjRemove.TabStop = false;
            this.grpAdjRemove.Visible = false;
            // 
            // btnAdjRemove
            // 
            this.btnAdjRemove.Location = new System.Drawing.Point(10, 20);
            this.btnAdjRemove.Name = "btnAdjRemove";
            this.btnAdjRemove.Size = new System.Drawing.Size(213, 38);
            this.btnAdjRemove.TabIndex = 20;
            this.btnAdjRemove.Text = "REMOVE SELECTED";
            this.btnAdjRemove.UseVisualStyleBackColor = true;
            this.btnAdjRemove.Click += new System.EventHandler(this.btnAdjRemove_Click);
            // 
            // chkLstAdj
            // 
            this.chkLstAdj.CheckOnClick = true;
            this.chkLstAdj.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkLstAdj.ForeColor = System.Drawing.SystemColors.WindowText;
            this.chkLstAdj.FormattingEnabled = true;
            this.chkLstAdj.Location = new System.Drawing.Point(10, 67);
            this.chkLstAdj.Name = "chkLstAdj";
            this.chkLstAdj.Size = new System.Drawing.Size(213, 191);
            this.chkLstAdj.TabIndex = 19;
            // 
            // cmbFamily2
            // 
            this.cmbFamily2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFamily2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFamily2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbFamily2.FormattingEnabled = true;
            this.cmbFamily2.Location = new System.Drawing.Point(1081, 100);
            this.cmbFamily2.Name = "cmbFamily2";
            this.cmbFamily2.Size = new System.Drawing.Size(169, 24);
            this.cmbFamily2.TabIndex = 18;
            this.cmbFamily2.SelectedIndexChanged += new System.EventHandler(this.cmbAdjFam_SelectedIndexChanged);
            // 
            // grpNounRemove
            // 
            this.grpNounRemove.Controls.Add(this.btnNounRemove);
            this.grpNounRemove.Controls.Add(this.chkLstNoun);
            this.grpNounRemove.Font = new System.Drawing.Font("Showcard Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpNounRemove.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.grpNounRemove.Location = new System.Drawing.Point(366, 128);
            this.grpNounRemove.Name = "grpNounRemove";
            this.grpNounRemove.Size = new System.Drawing.Size(234, 271);
            this.grpNounRemove.TabIndex = 21;
            this.grpNounRemove.TabStop = false;
            this.grpNounRemove.Visible = false;
            // 
            // btnNounRemove
            // 
            this.btnNounRemove.Location = new System.Drawing.Point(10, 20);
            this.btnNounRemove.Name = "btnNounRemove";
            this.btnNounRemove.Size = new System.Drawing.Size(213, 38);
            this.btnNounRemove.TabIndex = 20;
            this.btnNounRemove.Text = "REMOVE SELECTED";
            this.btnNounRemove.UseVisualStyleBackColor = true;
            this.btnNounRemove.Click += new System.EventHandler(this.btnNounRemove_Click);
            // 
            // chkLstNoun
            // 
            this.chkLstNoun.CheckOnClick = true;
            this.chkLstNoun.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkLstNoun.ForeColor = System.Drawing.SystemColors.WindowText;
            this.chkLstNoun.FormattingEnabled = true;
            this.chkLstNoun.Location = new System.Drawing.Point(10, 67);
            this.chkLstNoun.Name = "chkLstNoun";
            this.chkLstNoun.Size = new System.Drawing.Size(213, 191);
            this.chkLstNoun.TabIndex = 19;
            // 
            // cmbFamily1
            // 
            this.cmbFamily1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFamily1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFamily1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbFamily1.FormattingEnabled = true;
            this.cmbFamily1.Location = new System.Drawing.Point(431, 100);
            this.cmbFamily1.Name = "cmbFamily1";
            this.cmbFamily1.Size = new System.Drawing.Size(169, 24);
            this.cmbFamily1.TabIndex = 22;
            this.cmbFamily1.SelectedIndexChanged += new System.EventHandler(this.cmbNounFam_SelectedIndexChanged);
            // 
            // lblFamily1
            // 
            this.lblFamily1.AutoSize = true;
            this.lblFamily1.Font = new System.Drawing.Font("Showcard Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFamily1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblFamily1.Location = new System.Drawing.Point(363, 102);
            this.lblFamily1.Name = "lblFamily1";
            this.lblFamily1.Size = new System.Drawing.Size(62, 18);
            this.lblFamily1.TabIndex = 24;
            this.lblFamily1.Text = "Family:";
            // 
            // lblFamily2
            // 
            this.lblFamily2.AutoSize = true;
            this.lblFamily2.Font = new System.Drawing.Font("Showcard Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFamily2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.lblFamily2.Location = new System.Drawing.Point(1013, 102);
            this.lblFamily2.Name = "lblFamily2";
            this.lblFamily2.Size = new System.Drawing.Size(62, 18);
            this.lblFamily2.TabIndex = 25;
            this.lblFamily2.Text = "Family:";
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Font = new System.Drawing.Font("Showcard Gothic", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbl1.Location = new System.Drawing.Point(234, 18);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(191, 62);
            this.lbl1.TabIndex = 26;
            this.lbl1.Text = "NOUNS";
            // 
            // lbl2
            // 
            this.lbl2.AutoSize = true;
            this.lbl2.Font = new System.Drawing.Font("Showcard Gothic", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.lbl2.Location = new System.Drawing.Point(852, 18);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(322, 62);
            this.lbl2.TabIndex = 27;
            this.lbl2.Text = "ADJECTIVES";
            // 
            // EditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(1302, 721);
            this.Controls.Add(this.lbl2);
            this.Controls.Add(this.lbl1);
            this.Controls.Add(this.lblFamily2);
            this.Controls.Add(this.lblFamily1);
            this.Controls.Add(this.cmbFamily1);
            this.Controls.Add(this.grpNounRemove);
            this.Controls.Add(this.cmbFamily2);
            this.Controls.Add(this.grpAdjRemove);
            this.Controls.Add(this.grpInput2);
            this.Controls.Add(this.grpInput1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "EditorForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EditorForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.EditorForm_FormClosed);
            this.Load += new System.EventHandler(this.EditorForm_Load);
            this.grpInput1.ResumeLayout(false);
            this.grpInput1.PerformLayout();
            this.grpAddNoun.ResumeLayout(false);
            this.grpAddNoun.PerformLayout();
            this.grpInput2.ResumeLayout(false);
            this.grpInput2.PerformLayout();
            this.grpAdjRemove.ResumeLayout(false);
            this.grpNounRemove.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnInput1;
        private System.Windows.Forms.GroupBox grpInput1;
        private System.Windows.Forms.GroupBox grpInput2;
        private System.Windows.Forms.GroupBox grpAdjRemove;
        private System.Windows.Forms.ComboBox cmbFamily2;
        private System.Windows.Forms.Button btnAdjRemove;
        private System.Windows.Forms.CheckedListBox chkLstAdj;
        private System.Windows.Forms.Button btnMinus2;
        private System.Windows.Forms.Button btnPlus2;
        private System.Windows.Forms.Label lblInput2;
        private System.Windows.Forms.TextBox txtAdjAdd;
        private System.Windows.Forms.Button btnInput2;
        private System.Windows.Forms.GroupBox grpNounRemove;
        private System.Windows.Forms.Button btnNounRemove;
        private System.Windows.Forms.CheckedListBox chkLstNoun;
        private System.Windows.Forms.ComboBox cmbFamily1;
        private System.Windows.Forms.Button btnMinus1;
        private System.Windows.Forms.Button btnPlus1;
        private System.Windows.Forms.Label lblInput1;
        private System.Windows.Forms.GroupBox grpAddNoun;
        private System.Windows.Forms.TextBox txtAddSing;
        private System.Windows.Forms.TextBox txtAddPlur;
        private System.Windows.Forms.CheckBox chkAddPlur;
        private System.Windows.Forms.Label lblFamily1;
        private System.Windows.Forms.Label lblFamily2;
        private System.Windows.Forms.TextBox txtName1;
        private System.Windows.Forms.Button btnName1;
        private System.Windows.Forms.Button btnName2;
        private System.Windows.Forms.TextBox txtName2;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.Label lbl2;
    }
}