using System;
using System.Windows.Forms;

namespace SA2SaveUtility
{
    public static class InvokeChecker
    {
        public static void InvokeCheck(this Control c, Action a)
        {
            if (c.InvokeRequired)
            {
                c.Invoke(a);
            }
            else
            {
                a();
            }
        }
    }
}
