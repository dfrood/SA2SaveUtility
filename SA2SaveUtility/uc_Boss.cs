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
    public partial class uc_Boss : UserControl
    {
        Offsets offsets = new Offsets();

        public uint mainIndex = 0;

        public KeyValuePair<string, KeyValuePair<uint, uint>> currentPair = new KeyValuePair<string, KeyValuePair<uint, uint>>();

        public uc_Boss()
        {
            InitializeComponent();
        }

        private void Checkb_Emblem_CheckedChanged(object sender, EventArgs e)
        {
            Main.WriteByte((int)(currentPair.Value.Key + offsets.boss.Emblem), Convert.ToInt32(checkb_Emblem.Checked), mainIndex);
            Main.WriteByte((int)(currentPair.Value.Value), Convert.ToInt32(checkb_Emblem.Checked), mainIndex);
        }

        private void Nud_1TimeMM_ValueChanged(object sender, EventArgs e)
        {
            Main.WriteByte((int)(currentPair.Value.Key + offsets.boss.FirstT), Convert.ToInt32(nud_1TimeMM.Value), mainIndex);
        }

        private void Nud_1TimeSS_ValueChanged(object sender, EventArgs e)
        {
            Main.WriteByte((int)(currentPair.Value.Key + offsets.boss.FirstT + 0x01), Convert.ToInt32(nud_1TimeSS.Value), mainIndex);
        }

        private void Nud_1TimeMS_ValueChanged(object sender, EventArgs e)
        {
            Main.WriteByte((int)(currentPair.Value.Key + offsets.boss.FirstT + 0x02), Convert.ToInt32(nud_1TimeMS.Value), mainIndex);
        }

        private void Nud_2TimeMM_ValueChanged(object sender, EventArgs e)
        {
            Main.WriteByte((int)(currentPair.Value.Key + offsets.boss.SecondT), Convert.ToInt32(nud_2TimeMM.Value), mainIndex);
        }

        private void Nud_2TimeSS_ValueChanged(object sender, EventArgs e)
        {
            Main.WriteByte((int)(currentPair.Value.Key + offsets.boss.SecondT + 0x01), Convert.ToInt32(nud_2TimeSS.Value), mainIndex);
        }

        private void Nud_2TimeMS_ValueChanged(object sender, EventArgs e)
        {
            Main.WriteByte((int)(currentPair.Value.Key + offsets.boss.SecondT + 0x02), Convert.ToInt32(nud_2TimeMS.Value), mainIndex);
        }

        private void Nud_3TimeMM_ValueChanged(object sender, EventArgs e)
        {
            Main.WriteByte((int)(currentPair.Value.Key + offsets.boss.ThirdT), Convert.ToInt32(nud_3TimeMM.Value), mainIndex);
        }

        private void Nud_3TimeSS_ValueChanged(object sender, EventArgs e)
        {
            Main.WriteByte((int)(currentPair.Value.Key + offsets.boss.ThirdT + 0x01), Convert.ToInt32(nud_3TimeSS.Value), mainIndex);
        }

        private void Nud_3TimeMS_ValueChanged(object sender, EventArgs e)
        {
            Main.WriteByte((int)(currentPair.Value.Key + offsets.boss.ThirdT + 0x02), Convert.ToInt32(nud_3TimeMS.Value), mainIndex);
        }
    }
}
