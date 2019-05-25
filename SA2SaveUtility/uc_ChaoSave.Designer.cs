namespace SA2SaveUtility
{
    partial class uc_ChaoSave
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
            this.gb_GardensUnlocked = new System.Windows.Forms.GroupBox();
            this.checkb_DarkGarden = new System.Windows.Forms.CheckBox();
            this.checkb_HeroGarden = new System.Windows.Forms.CheckBox();
            this.gb_GardensUnlocked.SuspendLayout();
            this.SuspendLayout();
            // 
            // gb_GardensUnlocked
            // 
            this.gb_GardensUnlocked.Controls.Add(this.checkb_HeroGarden);
            this.gb_GardensUnlocked.Controls.Add(this.checkb_DarkGarden);
            this.gb_GardensUnlocked.Location = new System.Drawing.Point(3, 3);
            this.gb_GardensUnlocked.Name = "gb_GardensUnlocked";
            this.gb_GardensUnlocked.Size = new System.Drawing.Size(112, 42);
            this.gb_GardensUnlocked.TabIndex = 0;
            this.gb_GardensUnlocked.TabStop = false;
            this.gb_GardensUnlocked.Text = "Gardens Unlocked";
            // 
            // checkb_DarkGarden
            // 
            this.checkb_DarkGarden.AutoSize = true;
            this.checkb_DarkGarden.Location = new System.Drawing.Point(7, 20);
            this.checkb_DarkGarden.Name = "checkb_DarkGarden";
            this.checkb_DarkGarden.Size = new System.Drawing.Size(49, 17);
            this.checkb_DarkGarden.TabIndex = 0;
            this.checkb_DarkGarden.Text = "Dark";
            this.checkb_DarkGarden.UseVisualStyleBackColor = true;
            this.checkb_DarkGarden.CheckedChanged += new System.EventHandler(this.Checkb_DarkGarden_CheckedChanged);
            // 
            // checkb_HeroGarden
            // 
            this.checkb_HeroGarden.AutoSize = true;
            this.checkb_HeroGarden.Location = new System.Drawing.Point(62, 20);
            this.checkb_HeroGarden.Name = "checkb_HeroGarden";
            this.checkb_HeroGarden.Size = new System.Drawing.Size(49, 17);
            this.checkb_HeroGarden.TabIndex = 1;
            this.checkb_HeroGarden.Text = "Hero";
            this.checkb_HeroGarden.UseVisualStyleBackColor = true;
            this.checkb_HeroGarden.CheckedChanged += new System.EventHandler(this.Checkb_HeroGarden_CheckedChanged);
            // 
            // uc_ChaoSave
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gb_GardensUnlocked);
            this.Name = "uc_ChaoSave";
            this.Size = new System.Drawing.Size(566, 216);
            this.gb_GardensUnlocked.ResumeLayout(false);
            this.gb_GardensUnlocked.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gb_GardensUnlocked;
        private System.Windows.Forms.CheckBox checkb_HeroGarden;
        private System.Windows.Forms.CheckBox checkb_DarkGarden;
    }
}
