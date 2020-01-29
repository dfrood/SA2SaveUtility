namespace SA2SaveUtility
{
    partial class PopulateChaoMsgBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PopulateChaoMsgBox));
            this.btn_PopulateChaoConfirm = new System.Windows.Forms.Button();
            this.btn_PopulateChaoCancel = new System.Windows.Forms.Button();
            this.cb_Garden = new System.Windows.Forms.ComboBox();
            this.lb_Garden = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_PopulateChaoConfirm
            // 
            this.btn_PopulateChaoConfirm.Location = new System.Drawing.Point(6, 45);
            this.btn_PopulateChaoConfirm.Name = "btn_PopulateChaoConfirm";
            this.btn_PopulateChaoConfirm.Size = new System.Drawing.Size(88, 23);
            this.btn_PopulateChaoConfirm.TabIndex = 0;
            this.btn_PopulateChaoConfirm.Text = "Confirm";
            this.btn_PopulateChaoConfirm.UseVisualStyleBackColor = true;
            this.btn_PopulateChaoConfirm.Click += new System.EventHandler(this.Btn_PopulateChaoConfirm_Click);
            // 
            // btn_PopulateChaoCancel
            // 
            this.btn_PopulateChaoCancel.Location = new System.Drawing.Point(100, 45);
            this.btn_PopulateChaoCancel.Name = "btn_PopulateChaoCancel";
            this.btn_PopulateChaoCancel.Size = new System.Drawing.Size(98, 23);
            this.btn_PopulateChaoCancel.TabIndex = 1;
            this.btn_PopulateChaoCancel.Text = "Cancel";
            this.btn_PopulateChaoCancel.UseVisualStyleBackColor = true;
            this.btn_PopulateChaoCancel.Click += new System.EventHandler(this.Btn_PopulateChaoCancel_Click);
            // 
            // cb_Garden
            // 
            this.cb_Garden.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Garden.FormattingEnabled = true;
            this.cb_Garden.Items.AddRange(new object[] {
            "Chao Garden",
            "Hero Garden",
            "Dark Garden",
            "Station Square",
            "Egg Carrier",
            "Mystic Ruins"});
            this.cb_Garden.Location = new System.Drawing.Point(6, 18);
            this.cb_Garden.Name = "cb_Garden";
            this.cb_Garden.Size = new System.Drawing.Size(88, 21);
            this.cb_Garden.TabIndex = 7;
            // 
            // lb_Garden
            // 
            this.lb_Garden.AutoSize = true;
            this.lb_Garden.Location = new System.Drawing.Point(5, 2);
            this.lb_Garden.Name = "lb_Garden";
            this.lb_Garden.Size = new System.Drawing.Size(42, 13);
            this.lb_Garden.TabIndex = 6;
            this.lb_Garden.Text = "Garden";
            // 
            // PopulateChaoMsgBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(201, 71);
            this.Controls.Add(this.cb_Garden);
            this.Controls.Add(this.lb_Garden);
            this.Controls.Add(this.btn_PopulateChaoCancel);
            this.Controls.Add(this.btn_PopulateChaoConfirm);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PopulateChaoMsgBox";
            this.Text = "Populate Slot";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_PopulateChaoConfirm;
        private System.Windows.Forms.Button btn_PopulateChaoCancel;
        private System.Windows.Forms.ComboBox cb_Garden;
        private System.Windows.Forms.Label lb_Garden;
    }
}