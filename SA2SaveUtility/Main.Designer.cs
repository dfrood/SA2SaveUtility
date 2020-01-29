namespace SA2SaveUtility
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.ms_Main = new System.Windows.Forms.MenuStrip();
            this.tsmi_File = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_Open = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_Save = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_saveAsPC = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_saveAsGC = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_saveAs360 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_saveAs360New = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_saveAs360Append = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_saveAsPS3 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_saveAsPS3New = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_saveAsPS3Append = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_RTE = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_RTE_SA = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_RTE_SA_Main = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_RTE_SA_Chao = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_RTE_SA2 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_RTE_SA2_Main = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_RTE_SA2_Chao = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_Chao = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_LoadChao = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_SaveCurrentChao = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_DupeChao = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_About = new System.Windows.Forms.ToolStripMenuItem();
            tc_Main = new System.Windows.Forms.TabControl();
            btn_AutoUpdate = new System.Windows.Forms.Button();
            this.checkb_AutoUpdate = new System.Windows.Forms.CheckBox();
            this.checkb_CheckForUpdates = new System.Windows.Forms.CheckBox();
            this.checkb_RTEUpdates = new System.Windows.Forms.CheckBox();
            this.ms_Main.SuspendLayout();
            this.SuspendLayout();
            // 
            // ms_Main
            // 
            this.ms_Main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_File,
            this.tsmi_Chao,
            this.tsmi_About});
            this.ms_Main.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.ms_Main.Location = new System.Drawing.Point(0, 0);
            this.ms_Main.Name = "ms_Main";
            this.ms_Main.Size = new System.Drawing.Size(569, 24);
            this.ms_Main.TabIndex = 0;
            this.ms_Main.Text = "menuStrip1";
            // 
            // tsmi_File
            // 
            this.tsmi_File.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_Open,
            this.tsmi_Save,
            this.tsmi_RTE});
            this.tsmi_File.Name = "tsmi_File";
            this.tsmi_File.Size = new System.Drawing.Size(37, 20);
            this.tsmi_File.Text = "File";
            // 
            // tsmi_Open
            // 
            this.tsmi_Open.Name = "tsmi_Open";
            this.tsmi_Open.Size = new System.Drawing.Size(129, 22);
            this.tsmi_Open.Text = "Load";
            this.tsmi_Open.Click += new System.EventHandler(this.Tsmi_Open_Click);
            // 
            // tsmi_Save
            // 
            this.tsmi_Save.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_saveAsPC,
            this.tsmi_saveAsGC,
            this.tsmi_saveAs360,
            this.tsmi_saveAsPS3});
            this.tsmi_Save.Enabled = false;
            this.tsmi_Save.Name = "tsmi_Save";
            this.tsmi_Save.Size = new System.Drawing.Size(129, 22);
            this.tsmi_Save.Text = "Save";
            // 
            // tsmi_saveAsPC
            // 
            this.tsmi_saveAsPC.Name = "tsmi_saveAsPC";
            this.tsmi_saveAsPC.Size = new System.Drawing.Size(172, 22);
            this.tsmi_saveAsPC.Text = "as PC Save";
            this.tsmi_saveAsPC.Click += new System.EventHandler(this.Tsmi_saveAsPC_Click);
            // 
            // tsmi_saveAsGC
            // 
            this.tsmi_saveAsGC.Name = "tsmi_saveAsGC";
            this.tsmi_saveAsGC.Size = new System.Drawing.Size(172, 22);
            this.tsmi_saveAsGC.Text = "as Gamecube Save";
            this.tsmi_saveAsGC.Click += new System.EventHandler(this.Tsmi_saveAsGC_Click);
            // 
            // tsmi_saveAs360
            // 
            this.tsmi_saveAs360.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_saveAs360New,
            this.tsmi_saveAs360Append});
            this.tsmi_saveAs360.Name = "tsmi_saveAs360";
            this.tsmi_saveAs360.Size = new System.Drawing.Size(172, 22);
            this.tsmi_saveAs360.Text = "as 360 Save";
            this.tsmi_saveAs360.Click += new System.EventHandler(this.Tsmi_saveAs360_Click);
            // 
            // tsmi_saveAs360New
            // 
            this.tsmi_saveAs360New.Name = "tsmi_saveAs360New";
            this.tsmi_saveAs360New.Size = new System.Drawing.Size(267, 22);
            this.tsmi_saveAs360New.Text = "Save to New Save";
            this.tsmi_saveAs360New.Visible = false;
            this.tsmi_saveAs360New.Click += new System.EventHandler(this.Tsmi_saveAs360New_Click);
            // 
            // tsmi_saveAs360Append
            // 
            this.tsmi_saveAs360Append.Name = "tsmi_saveAs360Append";
            this.tsmi_saveAs360Append.Size = new System.Drawing.Size(267, 22);
            this.tsmi_saveAs360Append.Text = "Append Current Slot to Existing Save";
            this.tsmi_saveAs360Append.Visible = false;
            this.tsmi_saveAs360Append.Click += new System.EventHandler(this.Tsmi_saveAs360Append_Click);
            // 
            // tsmi_saveAsPS3
            // 
            this.tsmi_saveAsPS3.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_saveAsPS3New,
            this.tsmi_saveAsPS3Append});
            this.tsmi_saveAsPS3.Name = "tsmi_saveAsPS3";
            this.tsmi_saveAsPS3.Size = new System.Drawing.Size(172, 22);
            this.tsmi_saveAsPS3.Text = "as PS3 Save";
            this.tsmi_saveAsPS3.Click += new System.EventHandler(this.Tsmi_saveAsPS3_Click);
            // 
            // tsmi_saveAsPS3New
            // 
            this.tsmi_saveAsPS3New.Name = "tsmi_saveAsPS3New";
            this.tsmi_saveAsPS3New.Size = new System.Drawing.Size(267, 22);
            this.tsmi_saveAsPS3New.Text = "Save to New Save";
            this.tsmi_saveAsPS3New.Click += new System.EventHandler(this.Tsmi_saveAsPS3New_Click);
            // 
            // tsmi_saveAsPS3Append
            // 
            this.tsmi_saveAsPS3Append.Name = "tsmi_saveAsPS3Append";
            this.tsmi_saveAsPS3Append.Size = new System.Drawing.Size(267, 22);
            this.tsmi_saveAsPS3Append.Text = "Append Current Slot to Existing Save";
            this.tsmi_saveAsPS3Append.Click += new System.EventHandler(this.Tsmi_saveAsPS3Append_Click);
            // 
            // tsmi_RTE
            // 
            this.tsmi_RTE.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_RTE_SA,
            this.tsmi_RTE_SA2});
            this.tsmi_RTE.Name = "tsmi_RTE";
            this.tsmi_RTE.Size = new System.Drawing.Size(129, 22);
            this.tsmi_RTE.Text = "Live Editor";
            // 
            // tsmi_RTE_SA
            // 
            this.tsmi_RTE_SA.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_RTE_SA_Main,
            this.tsmi_RTE_SA_Chao});
            this.tsmi_RTE_SA.Name = "tsmi_RTE_SA";
            this.tsmi_RTE_SA.Size = new System.Drawing.Size(170, 22);
            this.tsmi_RTE_SA.Text = "Sonic Adventure";
            this.tsmi_RTE_SA.Visible = false;
            // 
            // tsmi_RTE_SA_Main
            // 
            this.tsmi_RTE_SA_Main.Name = "tsmi_RTE_SA_Main";
            this.tsmi_RTE_SA_Main.Size = new System.Drawing.Size(102, 22);
            this.tsmi_RTE_SA_Main.Text = "Main";
            // 
            // tsmi_RTE_SA_Chao
            // 
            this.tsmi_RTE_SA_Chao.Name = "tsmi_RTE_SA_Chao";
            this.tsmi_RTE_SA_Chao.Size = new System.Drawing.Size(102, 22);
            this.tsmi_RTE_SA_Chao.Text = "Chao";
            // 
            // tsmi_RTE_SA2
            // 
            this.tsmi_RTE_SA2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_RTE_SA2_Main,
            this.tsmi_RTE_SA2_Chao});
            this.tsmi_RTE_SA2.Name = "tsmi_RTE_SA2";
            this.tsmi_RTE_SA2.Size = new System.Drawing.Size(170, 22);
            this.tsmi_RTE_SA2.Text = "Sonic Adventure 2";
            // 
            // tsmi_RTE_SA2_Main
            // 
            this.tsmi_RTE_SA2_Main.Name = "tsmi_RTE_SA2_Main";
            this.tsmi_RTE_SA2_Main.Size = new System.Drawing.Size(102, 22);
            this.tsmi_RTE_SA2_Main.Text = "Main";
            this.tsmi_RTE_SA2_Main.Click += new System.EventHandler(this.Tsmi_RTE_SA2_Main_Click);
            // 
            // tsmi_RTE_SA2_Chao
            // 
            this.tsmi_RTE_SA2_Chao.Name = "tsmi_RTE_SA2_Chao";
            this.tsmi_RTE_SA2_Chao.Size = new System.Drawing.Size(102, 22);
            this.tsmi_RTE_SA2_Chao.Text = "Chao";
            this.tsmi_RTE_SA2_Chao.Click += new System.EventHandler(this.Tsmi_RTE_SA2_Chao_Click);
            // 
            // tsmi_Chao
            // 
            this.tsmi_Chao.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_LoadChao,
            this.tsmi_SaveCurrentChao,
            this.tsmi_DupeChao});
            this.tsmi_Chao.Enabled = false;
            this.tsmi_Chao.Name = "tsmi_Chao";
            this.tsmi_Chao.Size = new System.Drawing.Size(47, 20);
            this.tsmi_Chao.Text = "Chao";
            // 
            // tsmi_LoadChao
            // 
            this.tsmi_LoadChao.Name = "tsmi_LoadChao";
            this.tsmi_LoadChao.Size = new System.Drawing.Size(221, 22);
            this.tsmi_LoadChao.Text = "Load Chao into Current Slot";
            this.tsmi_LoadChao.Click += new System.EventHandler(this.Tsmi_LoadChao_Click);
            // 
            // tsmi_SaveCurrentChao
            // 
            this.tsmi_SaveCurrentChao.Name = "tsmi_SaveCurrentChao";
            this.tsmi_SaveCurrentChao.Size = new System.Drawing.Size(221, 22);
            this.tsmi_SaveCurrentChao.Text = "Save Current Chao";
            this.tsmi_SaveCurrentChao.Click += new System.EventHandler(this.Tsmi_SaveCurrentChao_Click);
            // 
            // tsmi_DupeChao
            // 
            this.tsmi_DupeChao.Name = "tsmi_DupeChao";
            this.tsmi_DupeChao.Size = new System.Drawing.Size(221, 22);
            this.tsmi_DupeChao.Text = "Dupe Current Chao";
            this.tsmi_DupeChao.Click += new System.EventHandler(this.Tsmi_DupeCurrentChao_Click);
            // 
            // tsmi_About
            // 
            this.tsmi_About.Name = "tsmi_About";
            this.tsmi_About.Size = new System.Drawing.Size(52, 20);
            this.tsmi_About.Text = "About";
            this.tsmi_About.Click += new System.EventHandler(this.Tsmi_About_Click);
            // 
            // tc_Main
            // 
            tc_Main.Location = new System.Drawing.Point(0, 24);
            tc_Main.Name = "tc_Main";
            tc_Main.SelectedIndex = 0;
            tc_Main.Size = new System.Drawing.Size(572, 235);
            tc_Main.TabIndex = 1;
            // 
            // btn_AutoUpdate
            // 
            btn_AutoUpdate.ForeColor = System.Drawing.Color.ForestGreen;
            btn_AutoUpdate.Location = new System.Drawing.Point(144, 1);
            btn_AutoUpdate.Name = "btn_AutoUpdate";
            btn_AutoUpdate.Size = new System.Drawing.Size(122, 23);
            btn_AutoUpdate.TabIndex = 4;
            btn_AutoUpdate.Text = "An update is available!";
            btn_AutoUpdate.UseVisualStyleBackColor = true;
            btn_AutoUpdate.Visible = false;
            btn_AutoUpdate.Click += new System.EventHandler(Btn_AutoUpdate_Click);
            // 
            // checkb_AutoUpdate
            // 
            this.checkb_AutoUpdate.AutoSize = true;
            this.checkb_AutoUpdate.Location = new System.Drawing.Point(479, 5);
            this.checkb_AutoUpdate.Name = "checkb_AutoUpdate";
            this.checkb_AutoUpdate.Size = new System.Drawing.Size(86, 17);
            this.checkb_AutoUpdate.TabIndex = 5;
            this.checkb_AutoUpdate.Text = "Auto Update";
            this.checkb_AutoUpdate.UseVisualStyleBackColor = true;
            this.checkb_AutoUpdate.CheckedChanged += new System.EventHandler(this.Checkb_AutoUpdate_CheckedChanged);
            // 
            // checkb_CheckForUpdates
            // 
            this.checkb_CheckForUpdates.AutoSize = true;
            this.checkb_CheckForUpdates.Location = new System.Drawing.Point(359, 5);
            this.checkb_CheckForUpdates.Name = "checkb_CheckForUpdates";
            this.checkb_CheckForUpdates.Size = new System.Drawing.Size(115, 17);
            this.checkb_CheckForUpdates.TabIndex = 6;
            this.checkb_CheckForUpdates.Text = "Check for Updates";
            this.checkb_CheckForUpdates.UseVisualStyleBackColor = true;
            this.checkb_CheckForUpdates.CheckedChanged += new System.EventHandler(this.Checkb_CheckForUpdates_CheckedChanged);
            // 
            // checkb_RTEUpdates
            // 
            this.checkb_RTEUpdates.AutoSize = true;
            this.checkb_RTEUpdates.Location = new System.Drawing.Point(268, 5);
            this.checkb_RTEUpdates.Name = "checkb_RTEUpdates";
            this.checkb_RTEUpdates.Size = new System.Drawing.Size(91, 17);
            this.checkb_RTEUpdates.TabIndex = 7;
            this.checkb_RTEUpdates.Text = "RTE Updates";
            this.checkb_RTEUpdates.UseVisualStyleBackColor = true;
            this.checkb_RTEUpdates.CheckedChanged += new System.EventHandler(this.Checkb_RTEUpdates_CheckedChanged);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(569, 258);
            this.Controls.Add(this.checkb_RTEUpdates);
            this.Controls.Add(this.checkb_CheckForUpdates);
            this.Controls.Add(this.checkb_AutoUpdate);
            this.Controls.Add(btn_AutoUpdate);
            this.Controls.Add(tc_Main);
            this.Controls.Add(this.ms_Main);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.ms_Main;
            this.MaximizeBox = false;
            this.Name = "Main";
            this.Text = "Sonic Adventure 2 - Save Utility";
            this.ms_Main.ResumeLayout(false);
            this.ms_Main.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip ms_Main;
        private System.Windows.Forms.ToolStripMenuItem tsmi_File;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Open;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Save;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Chao;
        private System.Windows.Forms.ToolStripMenuItem tsmi_LoadChao;
        private System.Windows.Forms.ToolStripMenuItem tsmi_SaveCurrentChao;
        private System.Windows.Forms.ToolStripMenuItem tsmi_DupeChao;
        private System.Windows.Forms.ToolStripMenuItem tsmi_saveAsPC;
        private System.Windows.Forms.ToolStripMenuItem tsmi_saveAs360;
        private System.Windows.Forms.ToolStripMenuItem tsmi_About;
        private System.Windows.Forms.ToolStripMenuItem tsmi_saveAs360New;
        private System.Windows.Forms.ToolStripMenuItem tsmi_saveAs360Append;
        private System.Windows.Forms.ToolStripMenuItem tsmi_saveAsGC;
        private System.Windows.Forms.CheckBox checkb_AutoUpdate;
        private System.Windows.Forms.CheckBox checkb_CheckForUpdates;
        private System.Windows.Forms.ToolStripMenuItem tsmi_saveAsPS3;
        private System.Windows.Forms.ToolStripMenuItem tsmi_saveAsPS3New;
        private System.Windows.Forms.ToolStripMenuItem tsmi_saveAsPS3Append;
        private System.Windows.Forms.ToolStripMenuItem tsmi_RTE;
        private System.Windows.Forms.ToolStripMenuItem tsmi_RTE_SA;
        private System.Windows.Forms.ToolStripMenuItem tsmi_RTE_SA_Main;
        private System.Windows.Forms.ToolStripMenuItem tsmi_RTE_SA_Chao;
        private System.Windows.Forms.ToolStripMenuItem tsmi_RTE_SA2;
        private System.Windows.Forms.ToolStripMenuItem tsmi_RTE_SA2_Main;
        private System.Windows.Forms.ToolStripMenuItem tsmi_RTE_SA2_Chao;
        private System.Windows.Forms.CheckBox checkb_RTEUpdates;
        public static System.Windows.Forms.Button btn_AutoUpdate;
        public static System.Windows.Forms.TabControl tc_Main;
    }
}