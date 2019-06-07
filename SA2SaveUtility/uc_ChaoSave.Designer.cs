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
            this.checkb_HeroGarden = new System.Windows.Forms.CheckBox();
            this.checkb_DarkGarden = new System.Windows.Forms.CheckBox();
            this.btn_HeldItems = new System.Windows.Forms.Button();
            this.btn_MarketItems = new System.Windows.Forms.Button();
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
            // btn_HeldItems
            // 
            this.btn_HeldItems.Location = new System.Drawing.Point(3, 187);
            this.btn_HeldItems.Name = "btn_HeldItems";
            this.btn_HeldItems.Size = new System.Drawing.Size(75, 23);
            this.btn_HeldItems.TabIndex = 1;
            this.btn_HeldItems.Text = "Held Items";
            this.btn_HeldItems.UseVisualStyleBackColor = true;
            this.btn_HeldItems.Click += new System.EventHandler(this.Btn_HeldItems_Click);
            // 
            // btn_MarketItems
            // 
            this.btn_MarketItems.Location = new System.Drawing.Point(84, 187);
            this.btn_MarketItems.Name = "btn_MarketItems";
            this.btn_MarketItems.Size = new System.Drawing.Size(115, 23);
            this.btn_MarketItems.TabIndex = 2;
            this.btn_MarketItems.Text = "Black Market Items";
            this.btn_MarketItems.UseVisualStyleBackColor = true;
            this.btn_MarketItems.Visible = false;
            // 
            // uc_ChaoSave
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btn_MarketItems);
            this.Controls.Add(this.btn_HeldItems);
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
        private System.Windows.Forms.Button btn_HeldItems;
        private System.Windows.Forms.Button btn_MarketItems;
    }
}
