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
    public partial class uc_MainChao : UserControl
    {
        Offsets offsets = new Offsets();

        public uint mainIndex = 0;

        public uc_MainChao()
        {
            InitializeComponent();
        }

        private void Checkb_RaceDark_CheckedChanged(object sender, EventArgs e)
        {
            Main.WriteByte((int)(offsets.main.ChaoRaceDark), Convert.ToInt32(checkb_RaceDark.Checked), mainIndex);
        }

        private void Checkb_RaceHero_CheckedChanged(object sender, EventArgs e)
        {
            Main.WriteByte((int)(offsets.main.ChaoRaceHero), Convert.ToInt32(checkb_RaceHero.Checked), mainIndex);
        }

        private void Checkb_RaceChallenge_CheckedChanged(object sender, EventArgs e)
        {
            Main.WriteByte((int)(offsets.main.ChaoRaceChallenge), Convert.ToInt32(checkb_RaceChallenge.Checked), mainIndex);
        }

        private void Checkb_RaceJewel_CheckedChanged(object sender, EventArgs e)
        {
            Main.WriteByte((int)(offsets.main.ChaoRaceJewel), Convert.ToInt32(checkb_RaceJewel.Checked), mainIndex);
        }

        private void Checkb_RaceBeginner_CheckedChanged(object sender, EventArgs e)
        {
            Main.WriteByte((int)(offsets.main.ChaoRaceBeginner), Convert.ToInt32(checkb_RaceBeginner.Checked), mainIndex);
        }

        private void Checkb_KarateSuper_CheckedChanged(object sender, EventArgs e)
        {
            Main.WriteByte((int)(offsets.main.ChaoKarateSuper), Convert.ToInt32(checkb_KarateSuper.Checked), mainIndex);
        }

        private void Checkb_KarateExpert_CheckedChanged(object sender, EventArgs e)
        {
            Main.WriteByte((int)(offsets.main.ChaoKarateExpert), Convert.ToInt32(checkb_KarateExpert.Checked), mainIndex);
        }

        private void Checkb_KarateStandard_CheckedChanged(object sender, EventArgs e)
        {
            Main.WriteByte((int)(offsets.main.ChaoKarateStandard), Convert.ToInt32(checkb_KarateStandard.Checked), mainIndex);
        }

        private void Checkb_KarateBeginner_CheckedChanged(object sender, EventArgs e)
        {
            Main.WriteByte((int)(offsets.main.ChaoKarateBeginner), Convert.ToInt32(checkb_KarateBeginner.Checked), mainIndex);
        }
    }
}
