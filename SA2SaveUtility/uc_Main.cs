using System;
using System.Windows.Forms;

namespace SA2SaveUtility
{
    public partial class uc_Main : UserControl
    {

        Offsets offsets = new Offsets();

        public uc_Main()
        {
            InitializeComponent();
        }

        private void Btn_UnlockAll_Click(object sender, EventArgs e)
        {

        }

        private void Nud_TotalRings_ValueChanged(object sender, EventArgs e)
        {
            byte[] bytes = BitConverter.GetBytes((int)nud_TotalRings.Value);
            Array.Resize<byte>(ref bytes, bytes.Length);

            for (int i = 0; i < bytes.Length; i++)
            {
                Main.loadedSave[(int)(offsets.main.Rings) + i] = bytes[i];
            }
        }

        private void Checkb_CWSonic_CheckedChanged(object sender, EventArgs e)
        {
            Main.loadedSave[(int)offsets.main.ChaoWorldSonic] = (byte)Convert.ToInt32(checkb_CWSonic.Checked);
        }

        private void Checkb_CWTails_CheckedChanged(object sender, EventArgs e)
        {
            Main.loadedSave[(int)offsets.main.ChaoWorldTails] = (byte)Convert.ToInt32(checkb_CWTails.Checked);
        }

        private void Checkb_CWKnuckles_CheckedChanged(object sender, EventArgs e)
        {
            Main.loadedSave[(int)offsets.main.ChaoWorldKnuckles] = (byte)Convert.ToInt32(checkb_CWKnuckles.Checked);
        }

        private void Checkb_CWShadow_CheckedChanged(object sender, EventArgs e)
        {
            Main.loadedSave[(int)offsets.main.ChaoWorldShadow] = (byte)Convert.ToInt32(checkb_CWShadow.Checked);
        }

        private void Checkb_CWEggman_CheckedChanged(object sender, EventArgs e)
        {
            Main.loadedSave[(int)offsets.main.ChaoWorldEggman] = (byte)Convert.ToInt32(checkb_CWEggman.Checked);
        }

        private void Checkb_CWRouge_CheckedChanged(object sender, EventArgs e)
        {
            Main.loadedSave[(int)offsets.main.ChaoWorldRouge] = (byte)Convert.ToInt32(checkb_CWRouge.Checked);
        }
    }
}
