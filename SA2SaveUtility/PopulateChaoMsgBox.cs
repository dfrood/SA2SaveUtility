using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace SA2SaveUtility
{
    public partial class PopulateChaoMsgBox : Form
    {
        public int tabIndex { get; set; }

        public PopulateChaoMsgBox()
        {
            InitializeComponent();
        }

        private void Btn_PopulateChaoConfirm_Click(object sender, EventArgs e)
        {   ComboBox garden = Main.tc_Main.TabPages[tabIndex].Controls[0].Controls[0].Controls[0].Controls.OfType<ComboBox>().Where(x => x.Name == "cb_Garden").First();
            CheckBox initChao = Main.tc_Main.TabPages[tabIndex].Controls[0].Controls[0].Controls[0].Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_InitChao").First();
            garden.SelectedIndex = cb_Garden.SelectedIndex;
            initChao.Checked = true;
            Main.tc_Main.TabPages[tabIndex].Text = "";
            foreach (Control ctl in Main.tc_Main.TabPages[tabIndex].Controls) ctl.Enabled = true;
            foreach (Control ctl in Main.tc_Main.TabPages[tabIndex].Controls) ctl.Visible = true;
            Close();
        }

        private void Btn_PopulateChaoCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
