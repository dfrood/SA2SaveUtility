using System;
using System.Windows.Forms;

namespace SA2SaveUtility
{
    public partial class uc_ChaoSave : UserControl
    {
        Offsets offsets = new Offsets();
        public HeldItems heldItems = new HeldItems();
        public MarketItems marketItems = new MarketItems();

        public uc_ChaoSave()
        {
            InitializeComponent();
            if (Main.isRTE)
            {
                btn_HeldItems.Visible = false;
                btn_MarketItems.Visible = false;
            }
            else
            {
                btn_HeldItems.Visible = true;
                btn_MarketItems.Visible = true;
            }
        }

        private void SetGardens()
        {
            uint portals = 0x06;

            if (checkb_DarkGarden.Checked) { portals += 0x40; }
            if (checkb_HeroGarden.Checked) { portals += 0x10; }

            byte[] portalBytes = BitConverter.GetBytes((UInt32)portals);
            if (!Main.isPC) { Array.Reverse(portalBytes); }
            for (int i = 0; i < portalBytes.Length; i++)
            {
                if (Main.isRTE) { Memory.WriteByteAtAddress((int)offsets.chaoSave.GardensRTE + i, portalBytes[i]); }
                else { Main.loadedSave[(int)(offsets.chaoSave.Gardens + i)] = portalBytes[i]; }
            }
        }

        private void Checkb_DarkGarden_CheckedChanged(object sender, EventArgs e)
        {
            SetGardens();
        }

        private void Checkb_HeroGarden_CheckedChanged(object sender, EventArgs e)
        {
            SetGardens();
        }

        private void Btn_HeldItems_Click(object sender, EventArgs e)
        {
            heldItems.ShowDialog();
        }

        private void Btn_MarketItems_Click(object sender, EventArgs e)
        {
            marketItems.ShowDialog();
        }
    }
}
