using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml.XPath;

namespace SA2SaveUtility
{
    public partial class Main : Form
    {
        public static bool saveIsPC;
        public static bool saveIsMain;
        public bool isLatest;
        public string latestVersionString;

        public string loadedFile { get; set; }
        public string currentDir = Directory.GetParent(Assembly.GetExecutingAssembly().Location).ToString();
        public string backupsDir = Directory.GetParent(Assembly.GetExecutingAssembly().Location).ToString() + @"\backups";
        string chaoDirectory = Directory.GetParent(Assembly.GetExecutingAssembly().Location) + @"\chao";


        public static byte[] loadedSave;
        Offsets offsets = new Offsets();

        public Main()
        {
            InitializeComponent();
            if (!Directory.Exists(backupsDir)) { Directory.CreateDirectory(backupsDir); }
            if (!Directory.Exists(chaoDirectory)) { Directory.CreateDirectory(chaoDirectory); }
        }

        private void Main_Load(object sender, EventArgs e)
        {
            UpdateCheck();
        }

        public void UpdateCheck()
        {
            string xml = new WebClient().DownloadString("https://dev.froody.tech/version.xml");
            XDocument doc = XDocument.Parse(xml);
            latestVersionString = doc.XPathSelectElement("Applications/SA2SaveUtility").Value;
            Version latestVersion = Version.Parse(latestVersionString);
            Version currentVersion = Version.Parse(ProductVersion);
            if (currentVersion.CompareTo(latestVersion) < 0) { isLatest = false; lb_UpdateAvailable.Visible = true; }
            else { isLatest = true; lb_UpdateAvailable.Visible = false;  }
        }

        public static void WriteByte(int offset, int value, uint mainIndex)
        {
            if (saveIsPC) { loadedSave[offset] = (byte)value; }
            else { loadedSave[offset + 4 + (int)(0x6004 * mainIndex)] = (byte)value; }
        }
        public static void WriteBytes(int offset, byte[] bytes, uint mainIndex, int length)
        {
            Array.Resize<byte>(ref bytes, length);
            if (!saveIsPC) { Array.Reverse(bytes); }
            for (int i = 0; i < length; i++)
            {
                if (saveIsPC) { loadedSave[offset + i] = bytes[i]; }
                else { loadedSave[offset + i + (int)(0x6004 * mainIndex) + 4] = bytes[i]; }
            }
        }

        public static List<byte[]> SplitByteArray(byte[] bytes, int BlockLength)
        {
            List<byte[]> _byteArrayList = new List<byte[]>();

            byte[] buffer;

            for (int i = 0; i < bytes.Length; i += BlockLength)
            {
                if ((i + BlockLength) > bytes.Length)
                {
                    buffer = new byte[bytes.Length - i];
                    Buffer.BlockCopy(bytes, i, buffer, 0, bytes.Length - i);
                }
                else
                {
                    buffer = new byte[BlockLength];
                    Buffer.BlockCopy(bytes, i, buffer, 0, BlockLength);
                }

                _byteArrayList.Add(buffer);
            }

            return _byteArrayList;
        }

        private void Tsmi_Open_Click(object sender, EventArgs e)
        {
            //Setup dialog OpenFileDialog for loading save file
            OpenFileDialog loadSave = new OpenFileDialog();
            loadSave.Filter = "PC Main Save|*SONIC2B__S*|PC Chao Save|*SONIC2B__ALF*|Console Main Save/Chao Save|*.bin";
            loadSave.Title = "Load a Save";

            if (loadSave.ShowDialog() == DialogResult.OK)
            {
                bool validSave = false;
                loadedSave = File.ReadAllBytes(loadSave.FileName);

                tc_Main.TabPages.Clear();
                ChaoSave.activeChao = new Dictionary<uint, TabPage>();
                MainSave.activeMain = new Dictionary<int, TabPage>();

                switch (loadSave.FilterIndex)
                {
                    case 1:
                        {
                            saveIsPC = true;
                            saveIsMain = true;
                            if (loadedSave.Length == 0x6000)
                            {
                                validSave = true;
                                SaveIsMain();
                                ActiveForm.Text = "Sonic Adventure 2 - Save Utility [Editing PC Main Save]";
                            }
                            break;
                        }
                    case 2:
                        {
                            saveIsPC = true;
                            saveIsMain = false;
                            if (loadedSave.Length == 0x10000)
                            {
                                validSave = true;
                                SaveIsChao();
                                ActiveForm.Text = "Sonic Adventure 2 - Save Utility [Editing PC Chao Save]";
                            }
                            break;
                        }
                    case 3:
                        {
                            saveIsPC = false;
                            if (loadedSave.Length == 0x3C028)
                            {
                                validSave = true;
                                SaveIsMain();
                                ActiveForm.Text = "Sonic Adventure 2 - Save Utility [Editing Console Main Save]";
                            }
                            if (loadedSave.Length == 0x10000)
                            {
                                validSave = true;
                                SaveIsChao();
                                ActiveForm.Text = "Sonic Adventure 2 - Save Utility [Editing Console Chao Save]";
                            }
                            break;
                        }
                }

                if (validSave)
                {
                    loadedFile = loadSave.FileName;
                    File.WriteAllBytes(backupsDir + @"\" + DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + "." + loadSave.SafeFileName, loadedSave.ToArray());
                    tsmi_Save.Enabled = true;
                }
                else
                {
                    tsmi_SaveCurrentChao.Enabled = false;
                    MessageBox.Show("That doesn't appear to be a Sonic Adventure 2 save file.", "Error loading save file", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    loadedSave = null;
                }
            }
        }

        private void SaveIsChao()
        {
            saveIsMain = false;
            ChaoSave.GetChao();
            tsmi_SaveCurrentChao.Enabled = true;
            tsmi_Chao.Enabled = true;
            tsmi_saveAsConsoleNew.Visible = false;
            tsmi_saveAsConsoleAppend.Visible = false;
        }
        private void SaveIsMain()
        {
            saveIsMain = true;
            MainSave.GetMain();
            tsmi_SaveCurrentChao.Enabled = false;
            tsmi_Chao.Enabled = false;
            tsmi_saveAsConsoleNew.Visible = true;
            tsmi_saveAsConsoleAppend.Visible = true;
        }

        private void Tsmi_LoadChao_Click(object sender, EventArgs e)
        {
            uc_Chao uc = (uc_Chao)tc_Main.Controls[tc_Main.SelectedIndex].Controls[0];
            OpenFileDialog loadChao = new OpenFileDialog();
            loadChao.InitialDirectory = chaoDirectory;
            loadChao.Filter = "Chao File|*.chao";
            loadChao.Title = "Load a Chao";
            loadChao.ShowDialog();
            if (loadChao.FileName != "")
            {
                byte[] chao = File.ReadAllBytes(loadChao.FileName);
                if (chao.Length == 2048)
                {
                    List<byte> byteList = new List<byte>();
                    byteList.AddRange(loadedSave.Take((int)(0x3AA4 + (0x800 * uc.chaoNumber))).ToArray());
                    if (!saveIsPC) { byteList.AddRange(ChaoSave.ByteSwapChao(chao)); }
                    else { byteList.AddRange(chao); }
                    byteList.AddRange(loadedSave.Skip((int)(0x3AA4 + (0x800 * (uc.chaoNumber + 1)))).ToArray());
                    loadedSave = byteList.ToArray();
                    ChaoSave.GetChao();
                }
                else
                {
                    MessageBox.Show("That doesn't appear to be a chao file.", "Error loading chao", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Tsmi_SaveCurrentChao_Click(object sender, EventArgs e)
        {
            uc_Chao uc = (uc_Chao)tc_Main.Controls[tc_Main.SelectedIndex].Controls[0];
            byte[] chao = new byte[2048];
            if (!saveIsPC) { chao = ChaoSave.ByteSwapChao(loadedSave.Skip((int)(0x3AA4 + (0x800 * uc.chaoNumber))).Take(0x800).ToArray()); }
            else { chao = loadedSave.Skip((int)(0x3AA4 + (0x800 * uc.chaoNumber))).Take(0x800).ToArray(); }
            SaveFileDialog saveChao = new SaveFileDialog();
            saveChao.InitialDirectory = chaoDirectory;
            saveChao.Filter = "Chao File| *.chao";
            saveChao.Title = "Save a Chao";
            saveChao.ShowDialog();

            if (saveChao.FileName != "") { File.WriteAllBytes(saveChao.FileName, chao); }
        }

        private void Tsmi_DupeCurrentChao_Click(object sender, EventArgs e)
        {
            uc_Chao uc = (uc_Chao)tc_Main.Controls[tc_Main.SelectedIndex].Controls[0];
            byte[] chaoToDupe = loadedSave.Skip((int)(0x3AA4 + (0x800 * uc.chaoNumber))).Take(0x800).ToArray();
            byte[] array = loadedSave.Skip(0x3AA4).Take(0x12000).ToArray();
            uint chaoIndex = 0;
            foreach (byte[] chao in SplitByteArray(array, 0x800))
            {
                if ((chao[offsets.chao.Garden] == 0 || chao[offsets.chao.Garden] == 255) && chaoIndex != 24)
                {
                    List<byte> byteArray = new List<byte>();
                    byteArray.AddRange(loadedSave.Take((int)(0x3AA4 + (0x800 * chaoIndex))).ToArray());
                    byteArray.AddRange(chaoToDupe);
                    byteArray.AddRange(loadedSave.Skip((int)(0x3AA4 + (0x800 * (chaoIndex + 1)))).ToArray());
                    loadedSave = byteArray.ToArray();
                    MessageBox.Show("Chao has been duped into slot " + (chaoIndex + 1) + ".", "Chao duped", MessageBoxButtons.OK, MessageBoxIcon.None);
                    ChaoSave.GetChao();
                    break;
                }
                else if (chaoIndex == 24)
                {
                    MessageBox.Show("Failed to find a slot for the chao, you'll have to make room.", "Error duping chao", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                chaoIndex++;
            }
        }

        private void Tsmi_saveAsPC_Click(object sender, EventArgs e)
        {
            if (!saveIsMain)
            {
                try
                {
                    List<byte> byteList = new List<byte>();
                    byteList.AddRange(loadedSave.Take(0x3AA4).ToArray());
                    foreach (byte[] chao in SplitByteArray(loadedSave.Skip(0x3AA4).Take(0xC000).ToArray(), 0x800))
                    {
                        if (!saveIsPC) { byteList.AddRange(ChaoSave.ByteSwapChao(chao)); }
                        else { byteList.AddRange(chao); }
                    }
                    byteList.AddRange(loadedSave.Skip(0xFAA4).Take(0x55C).ToArray());

                    byte[] chaoToSave = byteList.ToArray();

                    byte[] splitForChecksum = chaoToSave.Skip(0x3040).ToArray();
                    ChaoSave.WriteChecksum(splitForChecksum, true);
                    List<byte> byteArray = new List<byte>();
                    byteArray.AddRange(chaoToSave.Take(0x3040).ToArray());
                    byteArray.AddRange(splitForChecksum);
                    chaoToSave = byteArray.ToArray();
                    string pcFileName = Path.GetDirectoryName(loadedFile) + @"\SONIC2B__ALF";
                    int index = 1;
                    while (true)
                    {
                        if (!File.Exists(pcFileName))
                        {
                            break;
                        }
                        else
                        {
                            pcFileName = Path.GetDirectoryName(loadedFile) + @"\SONIC2B__ALF" + index;
                            index++;
                        }
                    }
                    File.WriteAllBytes(pcFileName, chaoToSave);
                    MessageBox.Show("Chao save file has been saved to " + pcFileName + "!", "Success", MessageBoxButtons.OK, MessageBoxIcon.None);
                }
                catch
                {
                    MessageBox.Show("There was a problem saving the chao save file!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                try
                {
                    uc_Main uc = (uc_Main)tc_Main.Controls[tc_Main.SelectedIndex].Controls[0];
                    List<byte> toSave = new List<byte>();
                    if (saveIsPC) { toSave = new List<byte>(loadedSave); }
                    else { toSave = new List<byte>(loadedSave.Skip((0x6004 * (int)(uc.mainIndex)) + 4).Take(0x6000).ToArray()); toSave = MainSave.ByteSwapMain(toSave.ToArray()).ToList(); }
                    toSave = new List<byte>(MainSave.WriteChecksum(toSave.ToArray(), true));
                    string pcFileName = Path.GetDirectoryName(loadedFile) + @"\SONIC2B__S01";
                    int index = 1;
                    while (true)
                    {
                        if (!File.Exists(pcFileName))
                        {
                            break;
                        }
                        else
                        {
                            pcFileName = Path.GetDirectoryName(loadedFile) + @"\SONIC2B__S" + index.ToString("00");
                            index++;
                        }
                    }
                    File.WriteAllBytes(pcFileName, toSave.ToArray());
                    MessageBox.Show("Save file has been saved to " + pcFileName + "!", "Success", MessageBoxButtons.OK, MessageBoxIcon.None);
                }
                catch
                {
                    MessageBox.Show("There was a problem saving the save file!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Tsmi_saveAsConsole_Click(object sender, EventArgs e)
        {
            if (!saveIsMain) { SaveAsConsole(); }
        }

        private void Tsmi_About_Click(object sender, EventArgs e)
        {
            if (isLatest) { MessageBox.Show("Version: " + ProductVersion + Environment.NewLine + "SA2 Save Utility is created by Froody." + Environment.NewLine + "Some chao offsets retrieved from https://chao.tehfusion.co.uk/chao-hacking/, thank you Fusion!", "About", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            else { if (isLatest) { MessageBox.Show("Version: " + ProductVersion + Environment.NewLine + "There is a new version available at https://github.com/dfrood/SA2SaveUtility/releases/tag/" + latestVersionString + Environment.NewLine + "SA2 Save Utility is created by Froody." + Environment.NewLine + "Some chao offsets retrieved from https://chao.tehfusion.co.uk/chao-hacking/, thank you Fusion!", "About", MessageBoxButtons.OK, MessageBoxIcon.Information); } }
        }

        private void Tsmi_saveAsConsoleNew_Click(object sender, EventArgs e)
        {
            SaveAsConsole();
        }

        private void SaveAsConsole()
        {
            if (!saveIsMain)
            {
                try
                {
                    List<byte> byteList = new List<byte>();
                    byteList.AddRange(loadedSave.Take(0x3AA4).ToArray());
                    foreach (byte[] chao in SplitByteArray(loadedSave.Skip(0x3AA4).Take(0xC000).ToArray(), 0x800))
                    {
                        if (saveIsPC) { byteList.AddRange(ChaoSave.ByteSwapChao(chao)); }
                        else { byteList.AddRange(chao); }
                    }
                    byteList.AddRange(loadedSave.Skip(0xFAA4).Take(0x55C).ToArray());

                    byte[] chaoToSave = byteList.ToArray();

                    byte[] splitForChecksum = chaoToSave.Skip(0x3040).ToArray();
                    ChaoSave.WriteChecksum(splitForChecksum, true);
                    List<byte> byteArray = new List<byte>();
                    byteArray.AddRange(chaoToSave.Take(0x3040).ToArray());
                    byteArray.AddRange(splitForChecksum);
                    chaoToSave = byteArray.ToArray();
                    string consoleFileName = Path.GetDirectoryName(loadedFile) + @"\savedata.bin";
                    int index = 1;
                    while (true)
                    {
                        if (!File.Exists(consoleFileName))
                        {
                            break;
                        }
                        else
                        {
                            consoleFileName = Path.GetDirectoryName(loadedFile) + @"\savedata" + index + ".bin";
                            index++;
                        }
                    }
                    File.WriteAllBytes(consoleFileName, chaoToSave);
                    MessageBox.Show("Chao save file has been saved to " + consoleFileName + "!", "Success", MessageBoxButtons.OK, MessageBoxIcon.None);
                }
                catch
                {
                    MessageBox.Show("There was a problem saving the chao save file!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                try
                {
                    uc_Main uc = (uc_Main)tc_Main.Controls[tc_Main.SelectedIndex].Controls[0];
                    List<byte> toSave = new List<byte>();
                    if (!saveIsPC)
                    {
                        toSave = new List<byte>(MainSave.WriteChecksum(loadedSave, true));
                    }
                    else
                    {
                        toSave.Add(0x00);
                        toSave.Add(0x00);
                        toSave.Add(0x00);
                        toSave.Add(0x01);
                        toSave.AddRange(MainSave.ByteSwapMain(loadedSave));
                        toSave = MainSave.WriteChecksum(toSave.ToArray(), false).ToList();
                    }
                    for (int i = toSave.Count; i < 0x3C028; i++)
                    {
                        toSave.Add(0x00);
                    }
                    string consoleFileName = Path.GetDirectoryName(loadedFile) + @"\savedata.bin";
                    int index = 1;
                    while (true)
                    {
                        if (!File.Exists(consoleFileName))
                        {
                            break;
                        }
                        else
                        {
                            consoleFileName = Path.GetDirectoryName(loadedFile) + @"\savedata" + index + ".bin";
                            index++;
                        }
                    }
                    File.WriteAllBytes(consoleFileName, toSave.ToArray());
                    MessageBox.Show("Save file has been saved to " + consoleFileName + "!", "Success", MessageBoxButtons.OK, MessageBoxIcon.None);
                }
                catch
                {
                    MessageBox.Show("There was a problem saving the save file!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Tsmi_saveAsConsoleAppend_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog loadToAppend = new OpenFileDialog();
                loadToAppend.InitialDirectory = chaoDirectory;
                loadToAppend.Filter = "Console Main Save|*.bin";
                loadToAppend.Title = "Chose a file to add this save to";
                loadToAppend.ShowDialog();
                if (loadToAppend.FileName != "")
                {
                    byte[] save = File.ReadAllBytes(loadToAppend.FileName);
                    if (save.Length == 0x3C028)
                    {
                        int slotIndex = 0;
                        int slotNotTaken = 0;
                        List<int> takenSlots = new List<int>();
                        foreach (byte[] saveSlot in SplitByteArray(save, 0x6004)) { takenSlots.Add(saveSlot[3]); }
                        for (int i = 1; i < 10; i++)
                        {
                            if (!takenSlots.Contains(i)) { slotNotTaken = i; break; }
                        }
                        if (slotNotTaken != 0)
                        {
                            List<byte> combinedSave = new List<byte>();
                            foreach (byte[] saveSlot in SplitByteArray(save, 0x6004))
                            {
                                if (saveSlot[3] == 0x00)
                                {
                                    uc_Main uc = (uc_Main)tc_Main.Controls[tc_Main.SelectedIndex].Controls[0];
                                    List<byte> toSave = new List<byte>();
                                    if (!saveIsPC)
                                    {
                                        toSave = new List<byte>(MainSave.WriteChecksum(loadedSave.Skip((int)(0x6004 * uc.mainIndex)).Take(0x6004).ToArray(), false));
                                        toSave[3] = (byte)slotNotTaken;
                                    }
                                    else
                                    {
                                        toSave.Add(0x00);
                                        toSave.Add(0x00);
                                        toSave.Add(0x00);
                                        toSave.Add((byte)slotNotTaken);
                                        toSave.AddRange(MainSave.ByteSwapMain(loadedSave));
                                        toSave = MainSave.WriteChecksum(toSave.ToArray(), false).ToList();
                                    }
                                    combinedSave.AddRange(save.Take(0x6004 * slotIndex));
                                    combinedSave.AddRange(toSave);
                                    combinedSave.AddRange(save.Skip(0x6004 * (slotIndex + 1)));
                                    break;
                                }
                                slotIndex++;
                            }
                            string consoleFileName = Path.GetDirectoryName(loadedFile) + @"\savedata.bin";
                            int index = 1;
                            while (true)
                            {
                                if (!File.Exists(consoleFileName))
                                {
                                    break;
                                }
                                else
                                {
                                    consoleFileName = Path.GetDirectoryName(loadedFile) + @"\savedata" + index + ".bin";
                                    index++;
                                }
                            }
                            File.WriteAllBytes(consoleFileName, combinedSave.ToArray());
                            MessageBox.Show("Save file has been saved to " + consoleFileName + ", in slot " + slotNotTaken + ".", "Success", MessageBoxButtons.OK, MessageBoxIcon.None);
                        }
                        else
                        {
                            MessageBox.Show("Couldn't find a slot to save to!", "Error writing save", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("That doesn't appear to be a console main save.", "Error writing save", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch
            {
                MessageBox.Show("There was a problem saving the save file!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Lb_UpdateAvailable_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/dfrood/SA2SaveUtility/releases/tag/" + latestVersionString);
        }
    }
}
