using System.Windows.Forms;

namespace SA2SaveUtility
{
    public static class CustomBehaviours
    {
        public static void Value(this Control c, int value)
        {
            bool denyChange = false;
            if (Main.isRTE) { denyChange = c.Focused; }
            if (c is TrackBar)
            {
                if (((TrackBar)c).Value != value && !denyChange) { ((TrackBar)c).Value = value; }
            }
            if (c is NumericUpDown)
            {
                if (((NumericUpDown)c).Value != value && !denyChange) { ((NumericUpDown)c).Value = value; }
            }
        }

        public static void SelectedIndex(this ComboBox c, int index)
        {
            bool denyChange = false;
            if (Main.isRTE) { denyChange = c.Focused; }
            if (c.SelectedIndex != index && !denyChange) { c.SelectedIndex = index; }
        }

        public static void Text(this TextBox c, string text)
        {
            bool denyChange = false;
            if (Main.isRTE) { denyChange = c.Focused; }
            if (c.Text != text && !denyChange) { c.Text = text; }
        }

        public static void Checked(this CheckBox c, bool _checked)
        {
            bool denyChange = false;
            if (Main.isRTE) { denyChange = c.Focused; }
            if (c.Checked != _checked && !denyChange) { c.Checked = _checked; }
        }
    }
}
