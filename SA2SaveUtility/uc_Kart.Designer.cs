namespace SA2SaveUtility
{
    partial class uc_Kart
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
            this.lb_3rdT = new System.Windows.Forms.Label();
            this.nud_3TimeMM = new System.Windows.Forms.NumericUpDown();
            this.nud_3TimeSS = new System.Windows.Forms.NumericUpDown();
            this.nud_3TimeMS = new System.Windows.Forms.NumericUpDown();
            this.cb_3rdCharacter = new System.Windows.Forms.ComboBox();
            this.lb_3rdCharacter = new System.Windows.Forms.Label();
            this.lb_3rd = new System.Windows.Forms.Label();
            this.lb_2ndT = new System.Windows.Forms.Label();
            this.nud_2TimeMM = new System.Windows.Forms.NumericUpDown();
            this.nud_2TimeSS = new System.Windows.Forms.NumericUpDown();
            this.nud_2TimeMS = new System.Windows.Forms.NumericUpDown();
            this.cb_2ndCharacter = new System.Windows.Forms.ComboBox();
            this.lb_2ndCharacter = new System.Windows.Forms.Label();
            this.lb_2nd = new System.Windows.Forms.Label();
            this.checkb_Emblem = new System.Windows.Forms.CheckBox();
            this.lb_1stT = new System.Windows.Forms.Label();
            this.nud_1TimeMM = new System.Windows.Forms.NumericUpDown();
            this.nud_1TimeSS = new System.Windows.Forms.NumericUpDown();
            this.nud_1TimeMS = new System.Windows.Forms.NumericUpDown();
            this.cb_1stCharacter = new System.Windows.Forms.ComboBox();
            this.lb_1stCharacter = new System.Windows.Forms.Label();
            this.lb_1st = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nud_3TimeMM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_3TimeSS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_3TimeMS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_2TimeMM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_2TimeSS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_2TimeMS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_1TimeMM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_1TimeSS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_1TimeMS)).BeginInit();
            this.SuspendLayout();
            // 
            // lb_3rdT
            // 
            this.lb_3rdT.AutoSize = true;
            this.lb_3rdT.Location = new System.Drawing.Point(123, 120);
            this.lb_3rdT.Name = "lb_3rdT";
            this.lb_3rdT.Size = new System.Drawing.Size(84, 13);
            this.lb_3rdT.TabIndex = 148;
            this.lb_3rdT.Text = "Time (mm:ss:ms)";
            // 
            // nud_3TimeMM
            // 
            this.nud_3TimeMM.Location = new System.Drawing.Point(126, 137);
            this.nud_3TimeMM.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.nud_3TimeMM.Name = "nud_3TimeMM";
            this.nud_3TimeMM.Size = new System.Drawing.Size(34, 20);
            this.nud_3TimeMM.TabIndex = 145;
            this.nud_3TimeMM.ValueChanged += new System.EventHandler(this.Nud_3TimeMM_ValueChanged);
            // 
            // nud_3TimeSS
            // 
            this.nud_3TimeSS.Location = new System.Drawing.Point(161, 137);
            this.nud_3TimeSS.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.nud_3TimeSS.Name = "nud_3TimeSS";
            this.nud_3TimeSS.Size = new System.Drawing.Size(34, 20);
            this.nud_3TimeSS.TabIndex = 146;
            this.nud_3TimeSS.ValueChanged += new System.EventHandler(this.Nud_3TimeSS_ValueChanged);
            // 
            // nud_3TimeMS
            // 
            this.nud_3TimeMS.Location = new System.Drawing.Point(196, 137);
            this.nud_3TimeMS.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.nud_3TimeMS.Name = "nud_3TimeMS";
            this.nud_3TimeMS.Size = new System.Drawing.Size(34, 20);
            this.nud_3TimeMS.TabIndex = 147;
            this.nud_3TimeMS.ValueChanged += new System.EventHandler(this.Nud_3TimeMS_ValueChanged);
            // 
            // cb_3rdCharacter
            // 
            this.cb_3rdCharacter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_3rdCharacter.FormattingEnabled = true;
            this.cb_3rdCharacter.Items.AddRange(new object[] {
            "Sonic",
            "Shadow",
            "Tails",
            "Eggman",
            "Knuckles",
            "Rouge",
            "Sonic [Hidden]",
            "Shadow [Hidden]",
            "Tails [Hidden]",
            "Eggman [Hidden]",
            "Knuckles [Hidden]",
            "Rouge [Hidden]"});
            this.cb_3rdCharacter.Location = new System.Drawing.Point(30, 136);
            this.cb_3rdCharacter.Name = "cb_3rdCharacter";
            this.cb_3rdCharacter.Size = new System.Drawing.Size(70, 21);
            this.cb_3rdCharacter.TabIndex = 144;
            this.cb_3rdCharacter.SelectedIndexChanged += new System.EventHandler(this.Cb_3rdCharacter_SelectedIndexChanged);
            // 
            // lb_3rdCharacter
            // 
            this.lb_3rdCharacter.AutoSize = true;
            this.lb_3rdCharacter.Location = new System.Drawing.Point(27, 120);
            this.lb_3rdCharacter.Name = "lb_3rdCharacter";
            this.lb_3rdCharacter.Size = new System.Drawing.Size(53, 13);
            this.lb_3rdCharacter.TabIndex = 143;
            this.lb_3rdCharacter.Text = "Character";
            // 
            // lb_3rd
            // 
            this.lb_3rd.AutoSize = true;
            this.lb_3rd.Location = new System.Drawing.Point(3, 139);
            this.lb_3rd.Name = "lb_3rd";
            this.lb_3rd.Size = new System.Drawing.Size(22, 13);
            this.lb_3rd.TabIndex = 142;
            this.lb_3rd.Text = "3rd";
            // 
            // lb_2ndT
            // 
            this.lb_2ndT.AutoSize = true;
            this.lb_2ndT.Location = new System.Drawing.Point(123, 72);
            this.lb_2ndT.Name = "lb_2ndT";
            this.lb_2ndT.Size = new System.Drawing.Size(84, 13);
            this.lb_2ndT.TabIndex = 141;
            this.lb_2ndT.Text = "Time (mm:ss:ms)";
            // 
            // nud_2TimeMM
            // 
            this.nud_2TimeMM.Location = new System.Drawing.Point(126, 89);
            this.nud_2TimeMM.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.nud_2TimeMM.Name = "nud_2TimeMM";
            this.nud_2TimeMM.Size = new System.Drawing.Size(34, 20);
            this.nud_2TimeMM.TabIndex = 138;
            this.nud_2TimeMM.ValueChanged += new System.EventHandler(this.Nud_2TimeMM_ValueChanged);
            // 
            // nud_2TimeSS
            // 
            this.nud_2TimeSS.Location = new System.Drawing.Point(161, 89);
            this.nud_2TimeSS.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.nud_2TimeSS.Name = "nud_2TimeSS";
            this.nud_2TimeSS.Size = new System.Drawing.Size(34, 20);
            this.nud_2TimeSS.TabIndex = 139;
            this.nud_2TimeSS.ValueChanged += new System.EventHandler(this.Nud_2TimeSS_ValueChanged);
            // 
            // nud_2TimeMS
            // 
            this.nud_2TimeMS.Location = new System.Drawing.Point(196, 89);
            this.nud_2TimeMS.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.nud_2TimeMS.Name = "nud_2TimeMS";
            this.nud_2TimeMS.Size = new System.Drawing.Size(34, 20);
            this.nud_2TimeMS.TabIndex = 140;
            this.nud_2TimeMS.ValueChanged += new System.EventHandler(this.Nud_2TimeMS_ValueChanged);
            // 
            // cb_2ndCharacter
            // 
            this.cb_2ndCharacter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_2ndCharacter.FormattingEnabled = true;
            this.cb_2ndCharacter.Items.AddRange(new object[] {
            "Sonic",
            "Shadow",
            "Tails",
            "Eggman",
            "Knuckles",
            "Rouge",
            "Sonic [Hidden]",
            "Shadow [Hidden]",
            "Tails [Hidden]",
            "Eggman [Hidden]",
            "Knuckles [Hidden]",
            "Rouge [Hidden]"});
            this.cb_2ndCharacter.Location = new System.Drawing.Point(30, 88);
            this.cb_2ndCharacter.Name = "cb_2ndCharacter";
            this.cb_2ndCharacter.Size = new System.Drawing.Size(70, 21);
            this.cb_2ndCharacter.TabIndex = 137;
            this.cb_2ndCharacter.SelectedIndexChanged += new System.EventHandler(this.Cb_2ndCharacter_SelectedIndexChanged);
            // 
            // lb_2ndCharacter
            // 
            this.lb_2ndCharacter.AutoSize = true;
            this.lb_2ndCharacter.Location = new System.Drawing.Point(27, 72);
            this.lb_2ndCharacter.Name = "lb_2ndCharacter";
            this.lb_2ndCharacter.Size = new System.Drawing.Size(53, 13);
            this.lb_2ndCharacter.TabIndex = 136;
            this.lb_2ndCharacter.Text = "Character";
            // 
            // lb_2nd
            // 
            this.lb_2nd.AutoSize = true;
            this.lb_2nd.Location = new System.Drawing.Point(3, 91);
            this.lb_2nd.Name = "lb_2nd";
            this.lb_2nd.Size = new System.Drawing.Size(25, 13);
            this.lb_2nd.TabIndex = 135;
            this.lb_2nd.Text = "2nd";
            // 
            // checkb_Emblem
            // 
            this.checkb_Emblem.AutoSize = true;
            this.checkb_Emblem.Location = new System.Drawing.Point(6, 5);
            this.checkb_Emblem.Name = "checkb_Emblem";
            this.checkb_Emblem.Size = new System.Drawing.Size(109, 17);
            this.checkb_Emblem.TabIndex = 134;
            this.checkb_Emblem.Text = "Emblem Obtained";
            this.checkb_Emblem.UseVisualStyleBackColor = true;
            this.checkb_Emblem.CheckedChanged += new System.EventHandler(this.Checkb_Emblem_CheckedChanged);
            // 
            // lb_1stT
            // 
            this.lb_1stT.AutoSize = true;
            this.lb_1stT.Location = new System.Drawing.Point(123, 25);
            this.lb_1stT.Name = "lb_1stT";
            this.lb_1stT.Size = new System.Drawing.Size(84, 13);
            this.lb_1stT.TabIndex = 133;
            this.lb_1stT.Text = "Time (mm:ss:ms)";
            // 
            // nud_1TimeMM
            // 
            this.nud_1TimeMM.Location = new System.Drawing.Point(126, 42);
            this.nud_1TimeMM.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.nud_1TimeMM.Name = "nud_1TimeMM";
            this.nud_1TimeMM.Size = new System.Drawing.Size(34, 20);
            this.nud_1TimeMM.TabIndex = 130;
            this.nud_1TimeMM.ValueChanged += new System.EventHandler(this.Nud_1TimeMM_ValueChanged);
            // 
            // nud_1TimeSS
            // 
            this.nud_1TimeSS.Location = new System.Drawing.Point(161, 42);
            this.nud_1TimeSS.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.nud_1TimeSS.Name = "nud_1TimeSS";
            this.nud_1TimeSS.Size = new System.Drawing.Size(34, 20);
            this.nud_1TimeSS.TabIndex = 131;
            this.nud_1TimeSS.ValueChanged += new System.EventHandler(this.Nud_1TimeSS_ValueChanged);
            // 
            // nud_1TimeMS
            // 
            this.nud_1TimeMS.Location = new System.Drawing.Point(196, 42);
            this.nud_1TimeMS.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.nud_1TimeMS.Name = "nud_1TimeMS";
            this.nud_1TimeMS.Size = new System.Drawing.Size(34, 20);
            this.nud_1TimeMS.TabIndex = 132;
            this.nud_1TimeMS.ValueChanged += new System.EventHandler(this.Nud_1TimeMS_ValueChanged);
            // 
            // cb_1stCharacter
            // 
            this.cb_1stCharacter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_1stCharacter.FormattingEnabled = true;
            this.cb_1stCharacter.Items.AddRange(new object[] {
            "Sonic",
            "Shadow",
            "Tails",
            "Eggman",
            "Knuckles",
            "Rouge",
            "Sonic [Hidden]",
            "Shadow [Hidden]",
            "Tails [Hidden]",
            "Eggman [Hidden]",
            "Knuckles [Hidden]",
            "Rouge [Hidden]"});
            this.cb_1stCharacter.Location = new System.Drawing.Point(30, 41);
            this.cb_1stCharacter.Name = "cb_1stCharacter";
            this.cb_1stCharacter.Size = new System.Drawing.Size(70, 21);
            this.cb_1stCharacter.TabIndex = 129;
            this.cb_1stCharacter.SelectedIndexChanged += new System.EventHandler(this.Cb_1stCharacter_SelectedIndexChanged);
            // 
            // lb_1stCharacter
            // 
            this.lb_1stCharacter.AutoSize = true;
            this.lb_1stCharacter.Location = new System.Drawing.Point(27, 25);
            this.lb_1stCharacter.Name = "lb_1stCharacter";
            this.lb_1stCharacter.Size = new System.Drawing.Size(53, 13);
            this.lb_1stCharacter.TabIndex = 128;
            this.lb_1stCharacter.Text = "Character";
            // 
            // lb_1st
            // 
            this.lb_1st.AutoSize = true;
            this.lb_1st.Location = new System.Drawing.Point(3, 44);
            this.lb_1st.Name = "lb_1st";
            this.lb_1st.Size = new System.Drawing.Size(21, 13);
            this.lb_1st.TabIndex = 127;
            this.lb_1st.Text = "1st";
            // 
            // uc_Kart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lb_3rdT);
            this.Controls.Add(this.nud_3TimeMM);
            this.Controls.Add(this.nud_3TimeSS);
            this.Controls.Add(this.nud_3TimeMS);
            this.Controls.Add(this.cb_3rdCharacter);
            this.Controls.Add(this.lb_3rdCharacter);
            this.Controls.Add(this.lb_3rd);
            this.Controls.Add(this.lb_2ndT);
            this.Controls.Add(this.nud_2TimeMM);
            this.Controls.Add(this.nud_2TimeSS);
            this.Controls.Add(this.nud_2TimeMS);
            this.Controls.Add(this.cb_2ndCharacter);
            this.Controls.Add(this.lb_2ndCharacter);
            this.Controls.Add(this.lb_2nd);
            this.Controls.Add(this.checkb_Emblem);
            this.Controls.Add(this.lb_1stT);
            this.Controls.Add(this.nud_1TimeMM);
            this.Controls.Add(this.nud_1TimeSS);
            this.Controls.Add(this.nud_1TimeMS);
            this.Controls.Add(this.cb_1stCharacter);
            this.Controls.Add(this.lb_1stCharacter);
            this.Controls.Add(this.lb_1st);
            this.Name = "uc_Kart";
            this.Size = new System.Drawing.Size(558, 172);
            ((System.ComponentModel.ISupportInitialize)(this.nud_3TimeMM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_3TimeSS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_3TimeMS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_2TimeMM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_2TimeSS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_2TimeMS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_1TimeMM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_1TimeSS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_1TimeMS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lb_3rdT;
        private System.Windows.Forms.NumericUpDown nud_3TimeMM;
        private System.Windows.Forms.NumericUpDown nud_3TimeSS;
        private System.Windows.Forms.NumericUpDown nud_3TimeMS;
        private System.Windows.Forms.ComboBox cb_3rdCharacter;
        private System.Windows.Forms.Label lb_3rdCharacter;
        private System.Windows.Forms.Label lb_3rd;
        private System.Windows.Forms.Label lb_2ndT;
        private System.Windows.Forms.NumericUpDown nud_2TimeMM;
        private System.Windows.Forms.NumericUpDown nud_2TimeSS;
        private System.Windows.Forms.NumericUpDown nud_2TimeMS;
        private System.Windows.Forms.ComboBox cb_2ndCharacter;
        private System.Windows.Forms.Label lb_2ndCharacter;
        private System.Windows.Forms.Label lb_2nd;
        private System.Windows.Forms.CheckBox checkb_Emblem;
        private System.Windows.Forms.Label lb_1stT;
        private System.Windows.Forms.NumericUpDown nud_1TimeMM;
        private System.Windows.Forms.NumericUpDown nud_1TimeSS;
        private System.Windows.Forms.NumericUpDown nud_1TimeMS;
        private System.Windows.Forms.ComboBox cb_1stCharacter;
        private System.Windows.Forms.Label lb_1stCharacter;
        private System.Windows.Forms.Label lb_1st;
    }
}
