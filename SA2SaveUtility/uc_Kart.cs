using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SA2SaveUtility
{
    public partial class uc_Kart : UserControl
    {
        Offsets offsets = new Offsets();

        public uint mainIndex = 0;

        public KeyValuePair<string, uint> currentPair = new KeyValuePair<string, uint>();

        public uc_Kart()
        {
            InitializeComponent();
        }

        private void Checkb_Emblem_CheckedChanged(object sender, EventArgs e)
        {
            Main.WriteByte((int)(currentPair.Value + offsets.kart.Emblem), Convert.ToInt32(checkb_Emblem.Checked), mainIndex);
        }

        private void Cb_1stCharacter_SelectedIndexChanged(object sender, EventArgs e)
        {
            int character = 0;
            if (cb_1stCharacter.SelectedIndex < 5)
            {
                character = cb_1stCharacter.SelectedIndex;
            }
            else
            {
                character = cb_1stCharacter.SelectedIndex + 122;
            }
            Main.WriteByte((int)(currentPair.Value + offsets.kart.FirstC), character, mainIndex);
        }

        private void Cb_2ndCharacter_SelectedIndexChanged(object sender, EventArgs e)
        {
            int character = 0;
            if (cb_2ndCharacter.SelectedIndex < 5)
            {
                character = cb_2ndCharacter.SelectedIndex;
            }
            else
            {
                character = cb_2ndCharacter.SelectedIndex + 122;
            }
            Main.WriteByte((int)(currentPair.Value + offsets.kart.SecondC), character, mainIndex);
        }

        private void Cb_3rdCharacter_SelectedIndexChanged(object sender, EventArgs e)
        {
            int character = 0;
            if (cb_3rdCharacter.SelectedIndex < 5)
            {
                character = cb_3rdCharacter.SelectedIndex;
            }
            else
            {
                character = cb_3rdCharacter.SelectedIndex + 122;
            }
            Main.WriteByte((int)(currentPair.Value + offsets.kart.ThirdC), character, mainIndex);
        }

        private void Nud_1TimeMM_ValueChanged(object sender, EventArgs e)
        {
            Main.WriteByte((int)(currentPair.Value + offsets.kart.FirstT), Convert.ToInt32(nud_1TimeMM.Value), mainIndex);
        }

        private void Nud_1TimeSS_ValueChanged(object sender, EventArgs e)
        {
            Main.WriteByte((int)(currentPair.Value + offsets.kart.FirstT + 0x01), Convert.ToInt32(nud_1TimeSS.Value), mainIndex);
        }

        private void Nud_1TimeMS_ValueChanged(object sender, EventArgs e)
        {
            Main.WriteByte((int)(currentPair.Value + offsets.kart.FirstT + 0x02), Convert.ToInt32(nud_1TimeMS.Value), mainIndex);
        }

        private void Nud_2TimeMM_ValueChanged(object sender, EventArgs e)
        {
            Main.WriteByte((int)(currentPair.Value + offsets.kart.SecondT), Convert.ToInt32(nud_2TimeMM.Value), mainIndex);
        }

        private void Nud_2TimeSS_ValueChanged(object sender, EventArgs e)
        {
            Main.WriteByte((int)(currentPair.Value + offsets.kart.SecondT + 0x01), Convert.ToInt32(nud_2TimeSS.Value), mainIndex);
        }

        private void Nud_2TimeMS_ValueChanged(object sender, EventArgs e)
        {
            Main.WriteByte((int)(currentPair.Value + offsets.kart.SecondT + 0x02), Convert.ToInt32(nud_2TimeMS.Value), mainIndex);
        }

        private void Nud_3TimeMM_ValueChanged(object sender, EventArgs e)
        {
            Main.WriteByte((int)(currentPair.Value + offsets.kart.ThirdT), Convert.ToInt32(nud_3TimeMM.Value), mainIndex);
        }

        private void Nud_3TimeSS_ValueChanged(object sender, EventArgs e)
        {
            Main.WriteByte((int)(currentPair.Value + offsets.kart.ThirdT + 0x01), Convert.ToInt32(nud_3TimeSS.Value), mainIndex);
        }

        private void Nud_3TimeMS_ValueChanged(object sender, EventArgs e)
        {
            Main.WriteByte((int)(currentPair.Value + offsets.kart.ThirdT + 0x02), Convert.ToInt32(nud_3TimeMS.Value), mainIndex);
        }
    }
}
