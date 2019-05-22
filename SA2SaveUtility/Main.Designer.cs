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
            this.tsmi_saveAs360PS3 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_saveAs360PS3New = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_saveAs360PS3Append = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_Chao = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_LoadChao = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_SaveCurrentChao = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_DupeChao = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_About = new System.Windows.Forms.ToolStripMenuItem();
            tc_Main = new System.Windows.Forms.TabControl();
            this.lb_UpdateAvailable = new System.Windows.Forms.Label();
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
            this.tsmi_Save});
            this.tsmi_File.Name = "tsmi_File";
            this.tsmi_File.Size = new System.Drawing.Size(37, 20);
            this.tsmi_File.Text = "File";
            // 
            // tsmi_Open
            // 
            this.tsmi_Open.Name = "tsmi_Open";
            this.tsmi_Open.Size = new System.Drawing.Size(180, 22);
            this.tsmi_Open.Text = "Load";
            this.tsmi_Open.Click += new System.EventHandler(this.Tsmi_Open_Click);
            // 
            // tsmi_Save
            // 
            this.tsmi_Save.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_saveAsPC,
            this.tsmi_saveAsGC,
            this.tsmi_saveAs360PS3});
            this.tsmi_Save.Enabled = false;
            this.tsmi_Save.Name = "tsmi_Save";
            this.tsmi_Save.Size = new System.Drawing.Size(180, 22);
            this.tsmi_Save.Text = "Save";
            // 
            // tsmi_saveAsPC
            // 
            this.tsmi_saveAsPC.Name = "tsmi_saveAsPC";
            this.tsmi_saveAsPC.Size = new System.Drawing.Size(180, 22);
            this.tsmi_saveAsPC.Text = "as PC Save";
            this.tsmi_saveAsPC.Click += new System.EventHandler(this.Tsmi_saveAsPC_Click);
            // 
            // tsmi_saveAsGC
            // 
            this.tsmi_saveAsGC.Name = "tsmi_saveAsGC";
            this.tsmi_saveAsGC.Size = new System.Drawing.Size(180, 22);
            this.tsmi_saveAsGC.Text = "as Gamecube Save";
            this.tsmi_saveAsGC.Click += new System.EventHandler(this.Tsmi_saveAsGC_Click);
            // 
            // tsmi_saveAs360PS3
            // 
            this.tsmi_saveAs360PS3.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_saveAs360PS3New,
            this.tsmi_saveAs360PS3Append});
            this.tsmi_saveAs360PS3.Name = "tsmi_saveAs360PS3";
            this.tsmi_saveAs360PS3.Size = new System.Drawing.Size(180, 22);
            this.tsmi_saveAs360PS3.Text = "as 360/PS3 Save";
            this.tsmi_saveAs360PS3.Click += new System.EventHandler(this.Tsmi_saveAs360PS3_Click);
            // 
            // tsmi_saveAs360PS3New
            // 
            this.tsmi_saveAs360PS3New.Name = "tsmi_saveAs360PS3New";
            this.tsmi_saveAs360PS3New.Size = new System.Drawing.Size(266, 22);
            this.tsmi_saveAs360PS3New.Text = "Save to New Save";
            this.tsmi_saveAs360PS3New.Visible = false;
            this.tsmi_saveAs360PS3New.Click += new System.EventHandler(this.Tsmi_saveAs360PS3New_Click);
            // 
            // tsmi_saveAs360PS3Append
            // 
            this.tsmi_saveAs360PS3Append.Name = "tsmi_saveAs360PS3Append";
            this.tsmi_saveAs360PS3Append.Size = new System.Drawing.Size(266, 22);
            this.tsmi_saveAs360PS3Append.Text = "Append Current Slot to Existing Save";
            this.tsmi_saveAs360PS3Append.Visible = false;
            this.tsmi_saveAs360PS3Append.Click += new System.EventHandler(this.Tsmi_saveAs360PS3Append_Click);
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
            // lb_UpdateAvailable
            // 
            this.lb_UpdateAvailable.AutoSize = true;
            this.lb_UpdateAvailable.ForeColor = System.Drawing.Color.ForestGreen;
            this.lb_UpdateAvailable.Location = new System.Drawing.Point(443, 7);
            this.lb_UpdateAvailable.Name = "lb_UpdateAvailable";
            this.lb_UpdateAvailable.Size = new System.Drawing.Size(114, 13);
            this.lb_UpdateAvailable.TabIndex = 2;
            this.lb_UpdateAvailable.Text = "An update is available!";
            this.lb_UpdateAvailable.Visible = false;
            this.lb_UpdateAvailable.Click += new System.EventHandler(this.Lb_UpdateAvailable_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(569, 258);
            this.Controls.Add(this.lb_UpdateAvailable);
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
        private System.Windows.Forms.ToolStripMenuItem tsmi_saveAs360PS3;
        private System.Windows.Forms.ToolStripMenuItem tsmi_About;
        private System.Windows.Forms.ToolStripMenuItem tsmi_saveAs360PS3New;
        private System.Windows.Forms.ToolStripMenuItem tsmi_saveAs360PS3Append;
        private System.Windows.Forms.Label lb_UpdateAvailable;
        public static System.Windows.Forms.TabControl tc_Main;
        private System.Windows.Forms.ToolStripMenuItem tsmi_saveAsGC;
    }
}

