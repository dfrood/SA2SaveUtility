﻿using System;
using System.Windows.Forms;

namespace SA2SaveUtility
{
    public partial class uc_ChaoSave : UserControl
    {
        Offsets offsets = new Offsets();

        public uc_ChaoSave()
        {
            InitializeComponent();
        }

        private void SetGardens()
        {
            byte portals = 0x00;

            if (checkb_DarkGarden.Checked) { portals += 0x40; }
            if (checkb_HeroGarden.Checked) { portals += 0x10; }
            Main.loadedSave[(int)offsets.chaoSave.Gardens] = portals;
        }

        private void Checkb_DarkGarden_CheckedChanged(object sender, EventArgs e)
        {
            SetGardens();
        }

        private void Checkb_HeroGarden_CheckedChanged(object sender, EventArgs e)
        {
            SetGardens();
        }
    }
}