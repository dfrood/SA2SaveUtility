using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SA2SaveUtility
{
    public partial class uc_Mission : UserControl
    {
        Offsets offsets = new Offsets();

        public uint mainIndex = 0;

        public KeyValuePair<string, uint> currentPair = new KeyValuePair<string, uint>();

        public uc_Mission()
        {
            InitializeComponent();
        }

        private void Cb_1R_SelectedIndexChanged(object sender, EventArgs e)
        {
            Main.WriteByte((int)(currentPair.Value + offsets.mission.M1), (byte)cb_1R.SelectedIndex, mainIndex);
        }

        private void Cb_2R_SelectedIndexChanged(object sender, EventArgs e)
        {
            Main.WriteByte((int)(currentPair.Value + offsets.mission.M2), (byte)cb_2R.SelectedIndex, mainIndex);
        }

        private void Cb_3R_SelectedIndexChanged(object sender, EventArgs e)
        {
            Main.WriteByte((int)(currentPair.Value + offsets.mission.M3), (byte)cb_3R.SelectedIndex, mainIndex);
        }

        private void Cb_4R_SelectedIndexChanged(object sender, EventArgs e)
        {
            Main.WriteByte((int)(currentPair.Value + offsets.mission.M4), (byte)cb_4R.SelectedIndex, mainIndex);
        }

        private void Cb_5R_SelectedIndexChanged(object sender, EventArgs e)
        {
            Main.WriteByte((int)(currentPair.Value + offsets.mission.M5), (byte)cb_5R.SelectedIndex, mainIndex);
        }

        private void Nud_1S_ValueChanged(object sender, EventArgs e)
        {
            Main.WriteBytes((int)(currentPair.Value + offsets.mission.M1S), BitConverter.GetBytes((int)nud_1S.Value), mainIndex, 4);
        }

        private void Nud_4S_ValueChanged(object sender, EventArgs e)
        {
            Main.WriteBytes((int)(currentPair.Value + offsets.mission.M4S), BitConverter.GetBytes((int)nud_4S.Value), mainIndex, 4);
        }

        private void Nud_5S_ValueChanged(object sender, EventArgs e)
        {
            Main.WriteBytes((int)(currentPair.Value + offsets.mission.M5S), BitConverter.GetBytes((int)nud_5S.Value), mainIndex, 4);
        }

        private void Nud_1Rings_ValueChanged(object sender, EventArgs e)
        {
            Main.WriteBytes((int)(currentPair.Value + offsets.mission.M1R), BitConverter.GetBytes((int)nud_1Rings.Value), mainIndex, 2);
        }

        private void Nud_4Rings_ValueChanged(object sender, EventArgs e)
        {
            Main.WriteBytes((int)(currentPair.Value + offsets.mission.M4R), BitConverter.GetBytes((int)nud_4Rings.Value), mainIndex, 2);
        }

        private void Nud_5Rings_ValueChanged(object sender, EventArgs e)
        {
            Main.WriteBytes((int)(currentPair.Value + offsets.mission.M5R), BitConverter.GetBytes((int)nud_5Rings.Value), mainIndex, 2);
        }

        private void Nud_1P_ValueChanged(object sender, EventArgs e)
        {
            Main.WriteBytes((int)(currentPair.Value + offsets.mission.M1P), BitConverter.GetBytes((int)nud_1P.Value), mainIndex, 2);
        }

        private void Nud_2P_ValueChanged(object sender, EventArgs e)
        {
            Main.WriteBytes((int)(currentPair.Value + offsets.mission.M2P), BitConverter.GetBytes((int)nud_2P.Value), mainIndex, 2);
        }

        private void Nud_3P_ValueChanged(object sender, EventArgs e)
        {
            Main.WriteBytes((int)(currentPair.Value + offsets.mission.M3P), BitConverter.GetBytes((int)nud_3P.Value), mainIndex, 2);
        }

        private void Nud_4P_ValueChanged(object sender, EventArgs e)
        {
            Main.WriteBytes((int)(currentPair.Value + offsets.mission.M4P), BitConverter.GetBytes((int)nud_4P.Value), mainIndex, 2);
        }

        private void Nud_5P_ValueChanged(object sender, EventArgs e)
        {
            Main.WriteBytes((int)(currentPair.Value + offsets.mission.M5P), BitConverter.GetBytes((int)nud_5P.Value), mainIndex, 2);
        }

        private void Nud_1TimeMM_ValueChanged(object sender, EventArgs e)
        {
            Main.WriteByte((int)(currentPair.Value + offsets.mission.M1T), Convert.ToInt32(nud_1TimeMM.Value), mainIndex);
        }

        private void Nud_1TimeSS_ValueChanged(object sender, EventArgs e)
        {
            Main.WriteByte((int)(currentPair.Value + offsets.mission.M1T + 0x01), Convert.ToInt32(nud_1TimeSS.Value), mainIndex);
        }

        private void Nud_1TimeMS_ValueChanged(object sender, EventArgs e)
        {
            Main.WriteByte((int)(currentPair.Value + offsets.mission.M1T + 0x02), Convert.ToInt32(nud_1TimeMS.Value), mainIndex);
        }

        private void Nud_2TimeMM_ValueChanged(object sender, EventArgs e)
        {
            Main.WriteByte((int)(currentPair.Value + offsets.mission.M2T), Convert.ToInt32(nud_2TimeMM.Value), mainIndex);
        }

        private void Nud_2TimeSS_ValueChanged(object sender, EventArgs e)
        {
            Main.WriteByte((int)(currentPair.Value + offsets.mission.M2T + 0x01), Convert.ToInt32(nud_2TimeSS.Value), mainIndex);
        }

        private void Nud_2TimeMS_ValueChanged(object sender, EventArgs e)
        {
            Main.WriteByte((int)(currentPair.Value + offsets.mission.M2T + 0x02), Convert.ToInt32(nud_2TimeMS.Value), mainIndex);
        }

        private void Nud_3TimeMM_ValueChanged(object sender, EventArgs e)
        {
            Main.WriteByte((int)(currentPair.Value + offsets.mission.M3T), Convert.ToInt32(nud_3TimeMM.Value), mainIndex);
        }

        private void Nud_3TimeSS_ValueChanged(object sender, EventArgs e)
        {
            Main.WriteByte((int)(currentPair.Value + offsets.mission.M3T + 0x01), Convert.ToInt32(nud_3TimeSS.Value), mainIndex);
        }

        private void Nud_3TimeMS_ValueChanged(object sender, EventArgs e)
        {
            Main.WriteByte((int)(currentPair.Value + offsets.mission.M3T + 0x02), Convert.ToInt32(nud_3TimeMS.Value), mainIndex);
        }

        private void Nud_4TimeMM_ValueChanged(object sender, EventArgs e)
        {
            Main.WriteByte((int)(currentPair.Value + offsets.mission.M4T), Convert.ToInt32(nud_4TimeMM.Value), mainIndex);
        }

        private void Nud_4TimeSS_ValueChanged(object sender, EventArgs e)
        {
            Main.WriteByte((int)(currentPair.Value + offsets.mission.M4T + 0x01), Convert.ToInt32(nud_4TimeSS.Value), mainIndex);
        }

        private void Nud_4TimeMS_ValueChanged(object sender, EventArgs e)
        {
            Main.WriteByte((int)(currentPair.Value + offsets.mission.M4T + 0x02), Convert.ToInt32(nud_4TimeMS.Value), mainIndex);
        }

        private void Nud_5TimeMM_ValueChanged(object sender, EventArgs e)
        {
            Main.WriteByte((int)(currentPair.Value + offsets.mission.M5T), Convert.ToInt32(nud_5TimeMM.Value), mainIndex);
        }

        private void Nud_5TimeSS_ValueChanged(object sender, EventArgs e)
        {
            Main.WriteByte((int)(currentPair.Value + offsets.mission.M5T + 0x01), Convert.ToInt32(nud_5TimeSS.Value), mainIndex);
        }

        private void Nud_5TimeMS_ValueChanged(object sender, EventArgs e)
        {
            Main.WriteByte((int)(currentPair.Value + offsets.mission.M5T + 0x02), Convert.ToInt32(nud_5TimeMS.Value), mainIndex);
        }
    }
}
