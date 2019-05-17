namespace SA2SaveUtility
{
    partial class uc_Main
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tc_Main = new System.Windows.Forms.TabControl();
            this.tp_Main = new System.Windows.Forms.TabPage();
            this.gb_ChaoWorldCharacters = new System.Windows.Forms.GroupBox();
            this.checkb_CWRouge = new System.Windows.Forms.CheckBox();
            this.checkb_CWEggman = new System.Windows.Forms.CheckBox();
            this.checkb_CWShadow = new System.Windows.Forms.CheckBox();
            this.checkb_CWKnuckles = new System.Windows.Forms.CheckBox();
            this.checkb_CWTails = new System.Windows.Forms.CheckBox();
            this.checkb_CWSonic = new System.Windows.Forms.CheckBox();
            this.btn_UnlockAll = new System.Windows.Forms.Button();
            this.gb_UnlockedThemes = new System.Windows.Forms.GroupBox();
            this.checkb_Maria = new System.Windows.Forms.CheckBox();
            this.checkb_Amy = new System.Windows.Forms.CheckBox();
            this.checkb_Omochao = new System.Windows.Forms.CheckBox();
            this.checkb_Secretary = new System.Windows.Forms.CheckBox();
            this.gb_TotalRings = new System.Windows.Forms.GroupBox();
            this.nud_TotalRings = new System.Windows.Forms.NumericUpDown();
            this.tp_Emblems = new System.Windows.Forms.TabPage();
            this.tc_Missions = new System.Windows.Forms.TabControl();
            this.tc_Main.SuspendLayout();
            this.tp_Main.SuspendLayout();
            this.gb_ChaoWorldCharacters.SuspendLayout();
            this.gb_UnlockedThemes.SuspendLayout();
            this.gb_TotalRings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_TotalRings)).BeginInit();
            this.tp_Emblems.SuspendLayout();
            this.SuspendLayout();
            // 
            // tc_Main
            // 
            this.tc_Main.Controls.Add(this.tp_Main);
            this.tc_Main.Controls.Add(this.tp_Emblems);
            this.tc_Main.Location = new System.Drawing.Point(0, -3);
            this.tc_Main.Name = "tc_Main";
            this.tc_Main.SelectedIndex = 0;
            this.tc_Main.Size = new System.Drawing.Size(568, 216);
            this.tc_Main.TabIndex = 0;
            // 
            // tp_Main
            // 
            this.tp_Main.BackColor = System.Drawing.SystemColors.Control;
            this.tp_Main.Controls.Add(this.gb_ChaoWorldCharacters);
            this.tp_Main.Controls.Add(this.btn_UnlockAll);
            this.tp_Main.Controls.Add(this.gb_UnlockedThemes);
            this.tp_Main.Controls.Add(this.gb_TotalRings);
            this.tp_Main.Location = new System.Drawing.Point(4, 22);
            this.tp_Main.Name = "tp_Main";
            this.tp_Main.Padding = new System.Windows.Forms.Padding(3);
            this.tp_Main.Size = new System.Drawing.Size(560, 190);
            this.tp_Main.TabIndex = 0;
            this.tp_Main.Text = "Main";
            // 
            // gb_ChaoWorldCharacters
            // 
            this.gb_ChaoWorldCharacters.Controls.Add(this.checkb_CWRouge);
            this.gb_ChaoWorldCharacters.Controls.Add(this.checkb_CWEggman);
            this.gb_ChaoWorldCharacters.Controls.Add(this.checkb_CWShadow);
            this.gb_ChaoWorldCharacters.Controls.Add(this.checkb_CWKnuckles);
            this.gb_ChaoWorldCharacters.Controls.Add(this.checkb_CWTails);
            this.gb_ChaoWorldCharacters.Controls.Add(this.checkb_CWSonic);
            this.gb_ChaoWorldCharacters.Location = new System.Drawing.Point(6, 50);
            this.gb_ChaoWorldCharacters.Name = "gb_ChaoWorldCharacters";
            this.gb_ChaoWorldCharacters.Size = new System.Drawing.Size(145, 71);
            this.gb_ChaoWorldCharacters.TabIndex = 50;
            this.gb_ChaoWorldCharacters.TabStop = false;
            this.gb_ChaoWorldCharacters.Text = "Chao World Characters";
            // 
            // checkb_CWRouge
            // 
            this.checkb_CWRouge.AutoSize = true;
            this.checkb_CWRouge.Location = new System.Drawing.Point(78, 49);
            this.checkb_CWRouge.Name = "checkb_CWRouge";
            this.checkb_CWRouge.Size = new System.Drawing.Size(58, 17);
            this.checkb_CWRouge.TabIndex = 5;
            this.checkb_CWRouge.Text = "Rouge";
            this.checkb_CWRouge.UseVisualStyleBackColor = true;
            this.checkb_CWRouge.CheckedChanged += new System.EventHandler(this.Checkb_CWRouge_CheckedChanged);
            // 
            // checkb_CWEggman
            // 
            this.checkb_CWEggman.AutoSize = true;
            this.checkb_CWEggman.Location = new System.Drawing.Point(78, 34);
            this.checkb_CWEggman.Name = "checkb_CWEggman";
            this.checkb_CWEggman.Size = new System.Drawing.Size(65, 17);
            this.checkb_CWEggman.TabIndex = 4;
            this.checkb_CWEggman.Text = "Eggman";
            this.checkb_CWEggman.UseVisualStyleBackColor = true;
            this.checkb_CWEggman.CheckedChanged += new System.EventHandler(this.Checkb_CWEggman_CheckedChanged);
            // 
            // checkb_CWShadow
            // 
            this.checkb_CWShadow.AutoSize = true;
            this.checkb_CWShadow.Location = new System.Drawing.Point(78, 19);
            this.checkb_CWShadow.Name = "checkb_CWShadow";
            this.checkb_CWShadow.Size = new System.Drawing.Size(65, 17);
            this.checkb_CWShadow.TabIndex = 3;
            this.checkb_CWShadow.Text = "Shadow";
            this.checkb_CWShadow.UseVisualStyleBackColor = true;
            this.checkb_CWShadow.CheckedChanged += new System.EventHandler(this.Checkb_CWShadow_CheckedChanged);
            // 
            // checkb_CWKnuckles
            // 
            this.checkb_CWKnuckles.AutoSize = true;
            this.checkb_CWKnuckles.Location = new System.Drawing.Point(7, 50);
            this.checkb_CWKnuckles.Name = "checkb_CWKnuckles";
            this.checkb_CWKnuckles.Size = new System.Drawing.Size(70, 17);
            this.checkb_CWKnuckles.TabIndex = 2;
            this.checkb_CWKnuckles.Text = "Knuckles";
            this.checkb_CWKnuckles.UseVisualStyleBackColor = true;
            this.checkb_CWKnuckles.CheckedChanged += new System.EventHandler(this.Checkb_CWKnuckles_CheckedChanged);
            // 
            // checkb_CWTails
            // 
            this.checkb_CWTails.AutoSize = true;
            this.checkb_CWTails.Location = new System.Drawing.Point(7, 35);
            this.checkb_CWTails.Name = "checkb_CWTails";
            this.checkb_CWTails.Size = new System.Drawing.Size(48, 17);
            this.checkb_CWTails.TabIndex = 1;
            this.checkb_CWTails.Text = "Tails";
            this.checkb_CWTails.UseVisualStyleBackColor = true;
            this.checkb_CWTails.CheckedChanged += new System.EventHandler(this.Checkb_CWTails_CheckedChanged);
            // 
            // checkb_CWSonic
            // 
            this.checkb_CWSonic.AutoSize = true;
            this.checkb_CWSonic.Location = new System.Drawing.Point(7, 20);
            this.checkb_CWSonic.Name = "checkb_CWSonic";
            this.checkb_CWSonic.Size = new System.Drawing.Size(53, 17);
            this.checkb_CWSonic.TabIndex = 0;
            this.checkb_CWSonic.Text = "Sonic";
            this.checkb_CWSonic.UseVisualStyleBackColor = true;
            this.checkb_CWSonic.CheckedChanged += new System.EventHandler(this.Checkb_CWSonic_CheckedChanged);
            // 
            // btn_UnlockAll
            // 
            this.btn_UnlockAll.Location = new System.Drawing.Point(6, 161);
            this.btn_UnlockAll.Name = "btn_UnlockAll";
            this.btn_UnlockAll.Size = new System.Drawing.Size(81, 23);
            this.btn_UnlockAll.TabIndex = 49;
            this.btn_UnlockAll.Text = "180 Emblems";
            this.btn_UnlockAll.UseVisualStyleBackColor = true;
            this.btn_UnlockAll.Click += new System.EventHandler(this.Btn_UnlockAll_Click);
            // 
            // gb_UnlockedThemes
            // 
            this.gb_UnlockedThemes.Controls.Add(this.checkb_Maria);
            this.gb_UnlockedThemes.Controls.Add(this.checkb_Amy);
            this.gb_UnlockedThemes.Controls.Add(this.checkb_Omochao);
            this.gb_UnlockedThemes.Controls.Add(this.checkb_Secretary);
            this.gb_UnlockedThemes.Location = new System.Drawing.Point(157, 50);
            this.gb_UnlockedThemes.Name = "gb_UnlockedThemes";
            this.gb_UnlockedThemes.Size = new System.Drawing.Size(138, 52);
            this.gb_UnlockedThemes.TabIndex = 48;
            this.gb_UnlockedThemes.TabStop = false;
            this.gb_UnlockedThemes.Text = "Unlocked Themes";
            // 
            // checkb_Maria
            // 
            this.checkb_Maria.AutoSize = true;
            this.checkb_Maria.Location = new System.Drawing.Point(84, 30);
            this.checkb_Maria.Name = "checkb_Maria";
            this.checkb_Maria.Size = new System.Drawing.Size(52, 17);
            this.checkb_Maria.TabIndex = 3;
            this.checkb_Maria.Text = "Maria";
            this.checkb_Maria.UseVisualStyleBackColor = true;
            // 
            // checkb_Amy
            // 
            this.checkb_Amy.AutoSize = true;
            this.checkb_Amy.Location = new System.Drawing.Point(84, 16);
            this.checkb_Amy.Name = "checkb_Amy";
            this.checkb_Amy.Size = new System.Drawing.Size(46, 17);
            this.checkb_Amy.TabIndex = 2;
            this.checkb_Amy.Text = "Amy";
            this.checkb_Amy.UseVisualStyleBackColor = true;
            // 
            // checkb_Omochao
            // 
            this.checkb_Omochao.AutoSize = true;
            this.checkb_Omochao.Location = new System.Drawing.Point(7, 30);
            this.checkb_Omochao.Name = "checkb_Omochao";
            this.checkb_Omochao.Size = new System.Drawing.Size(72, 17);
            this.checkb_Omochao.TabIndex = 1;
            this.checkb_Omochao.Text = "Omochao";
            this.checkb_Omochao.UseVisualStyleBackColor = true;
            // 
            // checkb_Secretary
            // 
            this.checkb_Secretary.AutoSize = true;
            this.checkb_Secretary.Location = new System.Drawing.Point(7, 16);
            this.checkb_Secretary.Name = "checkb_Secretary";
            this.checkb_Secretary.Size = new System.Drawing.Size(71, 17);
            this.checkb_Secretary.TabIndex = 0;
            this.checkb_Secretary.Text = "Secretary";
            this.checkb_Secretary.UseVisualStyleBackColor = true;
            // 
            // gb_TotalRings
            // 
            this.gb_TotalRings.Controls.Add(this.nud_TotalRings);
            this.gb_TotalRings.Location = new System.Drawing.Point(6, 6);
            this.gb_TotalRings.Name = "gb_TotalRings";
            this.gb_TotalRings.Size = new System.Drawing.Size(106, 38);
            this.gb_TotalRings.TabIndex = 47;
            this.gb_TotalRings.TabStop = false;
            this.gb_TotalRings.Text = "Total Rings";
            // 
            // nud_TotalRings
            // 
            this.nud_TotalRings.Location = new System.Drawing.Point(4, 14);
            this.nud_TotalRings.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.nud_TotalRings.Name = "nud_TotalRings";
            this.nud_TotalRings.Size = new System.Drawing.Size(97, 20);
            this.nud_TotalRings.TabIndex = 43;
            this.nud_TotalRings.ValueChanged += new System.EventHandler(this.Nud_TotalRings_ValueChanged);
            // 
            // tp_Emblems
            // 
            this.tp_Emblems.BackColor = System.Drawing.SystemColors.Control;
            this.tp_Emblems.Controls.Add(this.tc_Missions);
            this.tp_Emblems.Location = new System.Drawing.Point(4, 22);
            this.tp_Emblems.Name = "tp_Emblems";
            this.tp_Emblems.Padding = new System.Windows.Forms.Padding(3);
            this.tp_Emblems.Size = new System.Drawing.Size(560, 190);
            this.tp_Emblems.TabIndex = 1;
            this.tp_Emblems.Text = "Missions";
            // 
            // tc_Missions
            // 
            this.tc_Missions.Location = new System.Drawing.Point(-2, -1);
            this.tc_Missions.Name = "tc_Missions";
            this.tc_Missions.SelectedIndex = 0;
            this.tc_Missions.Size = new System.Drawing.Size(566, 198);
            this.tc_Missions.TabIndex = 0;
            // 
            // uc_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tc_Main);
            this.Name = "uc_Main";
            this.Size = new System.Drawing.Size(566, 216);
            this.tc_Main.ResumeLayout(false);
            this.tp_Main.ResumeLayout(false);
            this.gb_ChaoWorldCharacters.ResumeLayout(false);
            this.gb_ChaoWorldCharacters.PerformLayout();
            this.gb_UnlockedThemes.ResumeLayout(false);
            this.gb_UnlockedThemes.PerformLayout();
            this.gb_TotalRings.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nud_TotalRings)).EndInit();
            this.tp_Emblems.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tc_Main;
        private System.Windows.Forms.TabPage tp_Main;
        private System.Windows.Forms.TabPage tp_Emblems;
        private System.Windows.Forms.TabControl tc_Missions;
        private System.Windows.Forms.GroupBox gb_TotalRings;
        private System.Windows.Forms.NumericUpDown nud_TotalRings;
        private System.Windows.Forms.GroupBox gb_UnlockedThemes;
        private System.Windows.Forms.CheckBox checkb_Maria;
        private System.Windows.Forms.CheckBox checkb_Amy;
        private System.Windows.Forms.CheckBox checkb_Omochao;
        private System.Windows.Forms.CheckBox checkb_Secretary;
        private System.Windows.Forms.Button btn_UnlockAll;
        private System.Windows.Forms.GroupBox gb_ChaoWorldCharacters;
        private System.Windows.Forms.CheckBox checkb_CWRouge;
        private System.Windows.Forms.CheckBox checkb_CWEggman;
        private System.Windows.Forms.CheckBox checkb_CWShadow;
        private System.Windows.Forms.CheckBox checkb_CWKnuckles;
        private System.Windows.Forms.CheckBox checkb_CWTails;
        private System.Windows.Forms.CheckBox checkb_CWSonic;
    }
}
