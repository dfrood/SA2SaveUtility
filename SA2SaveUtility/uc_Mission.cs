using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SA2SaveUtility
{
    public partial class uc_Mission : UserControl
    {
        Offsets offsets = new Offsets();

        public KeyValuePair<string, uint> currentPair = new KeyValuePair<string, uint>();

        public uc_Mission()
        {
            InitializeComponent();
        }

        private void Cb_1R_SelectedIndexChanged(object sender, EventArgs e)
        {
            Main.loadedSave[(int)(currentPair.Value + offsets.mission.M1)] = (byte)cb_1R.SelectedIndex;
        }

        private void Cb_2R_SelectedIndexChanged(object sender, EventArgs e)
        {
            Main.loadedSave[(int)(currentPair.Value + offsets.mission.M2)] = (byte)cb_2R.SelectedIndex;
        }

        private void Cb_3R_SelectedIndexChanged(object sender, EventArgs e)
        {
            Main.loadedSave[(int)(currentPair.Value + offsets.mission.M3)] = (byte)cb_3R.SelectedIndex;
        }

        private void Cb_4R_SelectedIndexChanged(object sender, EventArgs e)
        {
            Main.loadedSave[(int)(currentPair.Value + offsets.mission.M4)] = (byte)cb_4R.SelectedIndex;
        }

        private void Cb_5R_SelectedIndexChanged(object sender, EventArgs e)
        {
            Main.loadedSave[(int)(currentPair.Value + offsets.mission.M5)] = (byte)cb_5R.SelectedIndex;
        }

        private void Nud_1S_ValueChanged(object sender, EventArgs e)
        {
            byte[] bytes = BitConverter.GetBytes((int)nud_1S.Value);
            Array.Resize<byte>(ref bytes, bytes.Length);

            for (int i = 0; i < bytes.Length; i++)
            {
                Main.loadedSave[(int)(currentPair.Value + offsets.mission.M1S) + i] = bytes[i];
            }
        }

        private void Nud_4S_ValueChanged(object sender, EventArgs e)
        {
            byte[] bytes = BitConverter.GetBytes((int)nud_4S.Value);
            Array.Resize<byte>(ref bytes, bytes.Length);

            for (int i = 0; i < bytes.Length; i++)
            {
                Main.loadedSave[(int)(currentPair.Value + offsets.mission.M4S) + i] = bytes[i];
            }
        }

        private void Nud_5S_ValueChanged(object sender, EventArgs e)
        {
            byte[] bytes = BitConverter.GetBytes((int)nud_5S.Value);
            Array.Resize<byte>(ref bytes, bytes.Length);

            for (int i = 0; i < bytes.Length; i++)
            {
                Main.loadedSave[(int)(currentPair.Value + offsets.mission.M5S) + i] = bytes[i];
            }
        }

        private void Nud_1Rings_ValueChanged(object sender, EventArgs e)
        {
            byte[] bytes = BitConverter.GetBytes((int)nud_1Rings.Value);
            Array.Resize<byte>(ref bytes, bytes.Length);

            for (int i = 0; i < bytes.Length; i++)
            {
                Main.loadedSave[(int)(currentPair.Value + offsets.mission.M1R) + i] = bytes[i];
            }
        }

        private void Nud_4Rings_ValueChanged(object sender, EventArgs e)
        {
            byte[] bytes = BitConverter.GetBytes((int)nud_4Rings.Value);
            Array.Resize<byte>(ref bytes, bytes.Length);

            for (int i = 0; i < bytes.Length; i++)
            {
                Main.loadedSave[(int)(currentPair.Value + offsets.mission.M4R) + i] = bytes[i];
            }
        }

        private void Nud_5Rings_ValueChanged(object sender, EventArgs e)
        {
            byte[] bytes = BitConverter.GetBytes((int)nud_5Rings.Value);
            Array.Resize<byte>(ref bytes, bytes.Length);

            for (int i = 0; i < bytes.Length; i++)
            {
                Main.loadedSave[(int)(currentPair.Value + offsets.mission.M5R) + i] = bytes[i];
            }
        }

        private void Nud_1P_ValueChanged(object sender, EventArgs e)
        {
            byte[] bytes = BitConverter.GetBytes((int)nud_1P.Value);
            Array.Resize<byte>(ref bytes, bytes.Length);

            for (int i = 0; i < bytes.Length; i++)
            {
                Main.loadedSave[(int)(currentPair.Value + offsets.mission.M1P) + i] = bytes[i];
            }
        }

        private void Nud_2P_ValueChanged(object sender, EventArgs e)
        {
            byte[] bytes = BitConverter.GetBytes((int)nud_2P.Value);
            Array.Resize<byte>(ref bytes, bytes.Length);

            for (int i = 0; i < bytes.Length; i++)
            {
                Main.loadedSave[(int)(currentPair.Value + offsets.mission.M2P) + i] = bytes[i];
            }
        }

        private void Nud_3P_ValueChanged(object sender, EventArgs e)
        {
            byte[] bytes = BitConverter.GetBytes((int)nud_3P.Value);
            Array.Resize<byte>(ref bytes, bytes.Length);

            for (int i = 0; i < bytes.Length; i++)
            {
                Main.loadedSave[(int)(currentPair.Value + offsets.mission.M3P) + i] = bytes[i];
            }
        }

        private void Nud_4P_ValueChanged(object sender, EventArgs e)
        {
            byte[] bytes = BitConverter.GetBytes((int)nud_4P.Value);
            Array.Resize<byte>(ref bytes, bytes.Length);

            for (int i = 0; i < bytes.Length; i++)
            {
                Main.loadedSave[(int)(currentPair.Value + offsets.mission.M4P) + i] = bytes[i];
            }
        }

        private void Nud_5P_ValueChanged(object sender, EventArgs e)
        {
            byte[] bytes = BitConverter.GetBytes((int)nud_5P.Value);
            Array.Resize<byte>(ref bytes, bytes.Length);

            for (int i = 0; i < bytes.Length; i++)
            {
                Main.loadedSave[(int)(currentPair.Value + offsets.mission.M5P) + i] = bytes[i];
            }
        }

        private void Nud_1TimeMM_ValueChanged(object sender, EventArgs e)
        {
            Main.loadedSave[(int)(currentPair.Value + offsets.mission.M1T + 0x00)] = (byte)nud_1TimeMM.Value;
        }

        private void Nud_1TimeSS_ValueChanged(object sender, EventArgs e)
        {
            Main.loadedSave[(int)(currentPair.Value + offsets.mission.M1T + 0x01)] = (byte)nud_1TimeSS.Value;
        }

        private void Nud_1TimeMS_ValueChanged(object sender, EventArgs e)
        {
            Main.loadedSave[(int)(currentPair.Value + offsets.mission.M1T + 0x02)] = (byte)nud_1TimeMS.Value;
        }

        private void Nud_2TimeMM_ValueChanged(object sender, EventArgs e)
        {
            Main.loadedSave[(int)(currentPair.Value + offsets.mission.M2T + 0x00)] = (byte)nud_2TimeMM.Value;
        }

        private void Nud_2TimeSS_ValueChanged(object sender, EventArgs e)
        {
            Main.loadedSave[(int)(currentPair.Value + offsets.mission.M2T + 0x01)] = (byte)nud_2TimeSS.Value;
        }

        private void Nud_2TimeMS_ValueChanged(object sender, EventArgs e)
        {
            Main.loadedSave[(int)(currentPair.Value + offsets.mission.M2T + 0x02)] = (byte)nud_2TimeMS.Value;
        }

        private void Nud_3TimeMM_ValueChanged(object sender, EventArgs e)
        {
            Main.loadedSave[(int)(currentPair.Value + offsets.mission.M3T + 0x00)] = (byte)nud_3TimeMM.Value;
        }

        private void Nud_3TimeSS_ValueChanged(object sender, EventArgs e)
        {
            Main.loadedSave[(int)(currentPair.Value + offsets.mission.M3T + 0x01)] = (byte)nud_3TimeSS.Value;
        }

        private void Nud_3TimeMS_ValueChanged(object sender, EventArgs e)
        {
            Main.loadedSave[(int)(currentPair.Value + offsets.mission.M3T + 0x02)] = (byte)nud_3TimeMS.Value;
        }

        private void Nud_4TimeMM_ValueChanged(object sender, EventArgs e)
        {
            Main.loadedSave[(int)(currentPair.Value + offsets.mission.M4T + 0x00)] = (byte)nud_4TimeMM.Value;
        }

        private void Nud_4TimeSS_ValueChanged(object sender, EventArgs e)
        {
            Main.loadedSave[(int)(currentPair.Value + offsets.mission.M4T + 0x01)] = (byte)nud_4TimeSS.Value;
        }

        private void Nud_4TimeMS_ValueChanged(object sender, EventArgs e)
        {
            Main.loadedSave[(int)(currentPair.Value + offsets.mission.M4T + 0x02)] = (byte)nud_4TimeMS.Value;
        }

        private void Nud_5TimeMM_ValueChanged(object sender, EventArgs e)
        {
            Main.loadedSave[(int)(currentPair.Value + offsets.mission.M5T + 0x00)] = (byte)nud_5TimeMM.Value;
        }

        private void Nud_5TimeSS_ValueChanged(object sender, EventArgs e)
        {
            Main.loadedSave[(int)(currentPair.Value + offsets.mission.M5T + 0x01)] = (byte)nud_5TimeSS.Value;
        }

        private void Nud_5TimeMS_ValueChanged(object sender, EventArgs e)
        {
            Main.loadedSave[(int)(currentPair.Value + offsets.mission.M5T + 0x02)] = (byte)nud_5TimeMS.Value;
        }
    }
}
