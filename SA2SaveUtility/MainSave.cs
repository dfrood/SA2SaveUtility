using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace SA2SaveUtility
{
    class MainSave
    {
        public static Offsets offsets = new Offsets();
        public static Dictionary<int, TabPage> activeMain = new Dictionary<int, TabPage>();

        public static void GetMain()
        {
            if (Main.isPC || Main.isGC)
            {
                uc_Main uc = new uc_Main();
                TabPage tp = new TabPage();
                tp.Controls.Add(uc);
                if (Main.isGC)
                {
                    int fileNo = Int32.Parse(Encoding.UTF8.GetString(Main.gcFileBytes));
                    uc.gcFileNo = fileNo;
                }
                Main.tc_Main.TabPages.Add(tp);
                Main.tc_Main.SelectedTab = tp;
                List<byte> header = new List<byte>();
                if (!Main.isRTE)
                {
                    header = Main.loadedSave.Skip(0x27).Take(0x19).ToList();
                    tp.Text = Encoding.UTF8.GetString(header.Take(header.IndexOf(0x00)).ToArray());
                }

                if (Main.isRTE) { tp.Text = "Live Editor"; }

                activeMain.Add(Main.tc_Main.TabPages.IndexOf(tp), tp);

                KeyValuePair<int, TabPage> currentMain = activeMain.Where(x => x.Key == Main.tc_Main.TabPages.IndexOf(tp)).First();

                if (!Main.isRTE) { UpdateSave(Main.tc_Main, currentMain, Main.loadedSave.ToArray()); }
                else { UpdateSave(Main.tc_Main, currentMain, Memory.ReadBytes(offsets.mainMemoryStart, 0x6000)); }
            }

            if (!Main.isPC && !Main.isGC)
            {
                uint index = 0;
                if (!Main.isPS3)
                {
                    foreach (byte[] main in Main.SplitByteArray(Main.loadedSave.ToArray(), 0x6004))
                    {
                        if (BitConverter.ToString(main.Take(4).ToArray()) != "00-00-00-00")
                        {
                            uc_Main uc = new uc_Main();
                            TabPage tp = new TabPage();
                            uc.mainIndex = index;
                            tp.Controls.Add(uc);
                            Main.tc_Main.TabPages.Add(tp);
                            Main.tc_Main.SelectedTab = Main.tc_Main.TabPages[0];

                            List<byte> header = new List<byte>(main.Skip(0x2B).Take(0x19));
                            tp.Text = Encoding.UTF8.GetString(header.Take(header.IndexOf(0x00)).ToArray());

                            activeMain.Add(Main.tc_Main.TabPages.IndexOf(tp), tp);

                            KeyValuePair<int, TabPage> currentMain = activeMain.Where(x => x.Key == Main.tc_Main.TabPages.IndexOf(tp)).First();
                            UpdateSave(Main.tc_Main, currentMain, main.ToArray());
                        }
                        index++;
                    }
                }
                else
                {
                    foreach (byte[] main in Main.SplitByteArray(Main.loadedSave.ToArray(), 0x6008))
                    {
                        if (BitConverter.ToString(main.Take(4).ToArray()) != "00-00-00-00")
                        {
                            uc_Main uc = new uc_Main();
                            TabPage tp = new TabPage();
                            uc.mainIndex = index;
                            tp.Controls.Add(uc);
                            Main.tc_Main.TabPages.Add(tp);
                            Main.tc_Main.SelectedTab = Main.tc_Main.TabPages[0];

                            List<byte> header = new List<byte>(main.Skip(0x2F).Take(0x19));
                            tp.Text = Encoding.UTF8.GetString(header.Take(header.IndexOf(0x00)).ToArray());

                            activeMain.Add(Main.tc_Main.TabPages.IndexOf(tp), tp);

                            KeyValuePair<int, TabPage> currentMain = activeMain.Where(x => x.Key == Main.tc_Main.TabPages.IndexOf(tp)).First();
                            UpdateSave(Main.tc_Main, currentMain, main.Take(0x04).ToArray().ToList().Concat(main.Skip(0x08).ToArray().ToList()).ToArray());
                        }
                        index++;
                    }
                }
            }
        }

        public static void UpdateSave(TabControl tc, KeyValuePair<int, TabPage> currentMain, byte[] save)
        {
            if (!Main.isPC && !Main.isGC) { save = save.Skip(0x04).ToArray(); }

            int playTime = 0;
            if (Main.isPC) { playTime = BitConverter.ToInt32(save.Skip(Convert.ToInt32(offsets.main.PlayTime)).Take(4).ToArray(), 0); }
            else { playTime = BitConverter.ToInt32(save.Skip(Convert.ToInt32(offsets.main.PlayTime)).Take(4).Reverse().ToArray(), 0); }

            int emblemTime = 0;
            if (Main.isPC) { emblemTime = BitConverter.ToInt32(save.Skip(Convert.ToInt32(offsets.main.EmblemResultsTime)).Take(4).ToArray(), 0); }
            else { emblemTime = BitConverter.ToInt32(save.Skip(Convert.ToInt32(offsets.main.EmblemResultsTime)).Take(4).Reverse().ToArray(), 0); }

            int lives = 0;
            if (Main.isPC)
            {
                if (!Main.isRTE) { lives = BitConverter.ToInt16(save.Skip(Convert.ToInt32(offsets.main.Lives)).Take(2).ToArray(), 0); }
                else { lives = BitConverter.ToInt16(Memory.ReadBytes(Convert.ToInt32(offsets.main.LivesRTE), 2), 0); }
            }
            else { lives = BitConverter.ToInt16(save.Skip(Convert.ToInt32(offsets.main.Lives)).Take(2).Reverse().ToArray(), 0); }

            int rings = 0;
            if (Main.isPC)
            {
                if (!Main.isRTE) { rings = BitConverter.ToInt32(save.Skip(Convert.ToInt32(offsets.main.Rings)).Take(4).ToArray(), 0); }
                else { rings = BitConverter.ToInt32(Memory.ReadBytes(Convert.ToInt32(offsets.main.RingsRTE), 4), 0); }
            }
            else { rings = BitConverter.ToInt32(save.Skip(Convert.ToInt32(offsets.main.Rings)).Take(4).Reverse().ToArray(), 0); }

            int textLang = 0;
            if (!Main.isRTE) { textLang = (int)save[offsets.main.TextLanguage]; }
            else { textLang = (int)Memory.ReadBytes(Convert.ToInt32(offsets.main.TextLanguageRTE), 1).First(); }

            int voiceLang = 0;
            if (!Main.isRTE) { voiceLang = (int)save[offsets.main.VoiceLanguage]; }
            else { voiceLang = (int)Memory.ReadBytes(Convert.ToInt32(offsets.main.VoiceLanguageRTE), 1).First(); }

            int sonicCW = (int)save[offsets.main.ChaoWorldSonic];
            int tailsCW = (int)save[offsets.main.ChaoWorldTails];
            int knucklesCW = (int)save[offsets.main.ChaoWorldKnuckles];
            int shadowCW = (int)save[offsets.main.ChaoWorldShadow];
            int eggmanCW = (int)save[offsets.main.ChaoWorldEggman];
            int rougeCW = (int)save[offsets.main.ChaoWorldRouge];

            int sonicLS = 0;
            if (!Main.isRTE) { sonicLS = (int)save[offsets.main.SonicLightShoes]; }
            else { sonicLS = (int)Memory.ReadBytes(Convert.ToInt32(offsets.main.SonicLightShoesRTE), 1).First(); }
            int sonicAL = 0;
            if (!Main.isRTE) { sonicAL = (int)save[offsets.main.SonicAncientLight]; }
            else { sonicAL = (int)Memory.ReadBytes(Convert.ToInt32(offsets.main.SonicAncientLightRTE), 1).First(); }
            int sonicMG = 0;
            if (!Main.isRTE) { sonicMG = (int)save[offsets.main.SonicMagic]; }
            else { sonicMG = (int)Memory.ReadBytes(Convert.ToInt32(offsets.main.SonicMagicRTE), 1).First(); }
            int sonicFR = 0;
            if (!Main.isRTE) { sonicFR = (int)save[offsets.main.SonicFlame]; }
            else { sonicFR = (int)Memory.ReadBytes(Convert.ToInt32(offsets.main.SonicFlameRTE), 1).First(); }
            int sonicBB = 0;
            if (!Main.isRTE) { sonicBB = (int)save[offsets.main.SonicBounce]; }
            else { sonicBB = (int)Memory.ReadBytes(Convert.ToInt32(offsets.main.SonicBounceRTE), 1).First(); }
            int sonicMM = 0;
            if (!Main.isRTE) { sonicMM = (int)save[offsets.main.SonicMM]; }
            else { sonicMM = (int)Memory.ReadBytes(Convert.ToInt32(offsets.main.SonicMMRTE), 1).First(); }

            int tailsBo = 0;
            if (!Main.isRTE) { tailsBo = (int)save[offsets.main.TailsBooster]; }
            else { tailsBo = (int)Memory.ReadBytes(Convert.ToInt32(offsets.main.TailsBoosterRTE), 1).First(); }
            int tailsBa = 0;
            if (!Main.isRTE) { tailsBa = (int)save[offsets.main.TailsBazooka]; }
            else { tailsBa = (int)Memory.ReadBytes(Convert.ToInt32(offsets.main.TailsBazookaRTE), 1).First(); }
            int tailsL = 0;
            if (!Main.isRTE) { tailsL = (int)save[offsets.main.TailsLaser]; }
            else { tailsL = (int)Memory.ReadBytes(Convert.ToInt32(offsets.main.TailsLaserRTE), 1).First(); }
            int tailsMM = 0;
            if (!Main.isRTE) { tailsMM = (int)save[offsets.main.TailsMM]; }
            else { tailsMM = (int)Memory.ReadBytes(Convert.ToInt32(offsets.main.TailsMMRTE), 1).First(); }

            int knucklesSC = 0;
            if (!Main.isRTE) { knucklesSC = (int)save[offsets.main.KnucklesShovel]; }
            else { knucklesSC = (int)Memory.ReadBytes(Convert.ToInt32(offsets.main.KnucklesShovelRTE), 1).First(); }
            int knucklesS = 0;
            if (!Main.isRTE) { knucklesS = (int)save[offsets.main.KnucklesSun]; }
            else { knucklesS = (int)Memory.ReadBytes(Convert.ToInt32(offsets.main.KnucklesSunRTE), 1).First(); }
            int knucklesHG = 0;
            if (!Main.isRTE) { knucklesHG = (int)save[offsets.main.KnucklesHammer]; }
            else { knucklesHG = (int)Memory.ReadBytes(Convert.ToInt32(offsets.main.KnucklesHammerRTE), 1).First(); }
            int knucklesAN = 0;
            if (!Main.isRTE) { knucklesAN = (int)save[offsets.main.KnucklesAir]; }
            else { knucklesAN = (int)Memory.ReadBytes(Convert.ToInt32(offsets.main.KnucklesAirRTE), 1).First(); }
            int knucklesMM = 0;
            if (!Main.isRTE) { knucklesMM = (int)save[offsets.main.KnucklesMM]; }
            else { knucklesMM = (int)Memory.ReadBytes(Convert.ToInt32(offsets.main.KnucklesMMRTE), 1).First(); }

            int shadowAS = 0;
            if (!Main.isRTE) { shadowAS = (int)save[offsets.main.ShadowAir]; }
            else { shadowAS = (int)Memory.ReadBytes(Convert.ToInt32(offsets.main.ShadowAirRTE), 1).First(); }
            int shadowAL = 0;
            if (!Main.isRTE) { shadowAL = (int)save[offsets.main.ShadowAncientLight]; }
            else { shadowAL = (int)Memory.ReadBytes(Convert.ToInt32(offsets.main.ShadowAncientLightRTE), 1).First(); }
            int shadowFR = 0;
            if (!Main.isRTE) { shadowFR = (int)save[offsets.main.ShadowFlame]; }
            else { shadowFR = (int)Memory.ReadBytes(Convert.ToInt32(offsets.main.ShadowFlameRTE), 1).First(); }
            int shadowMM = 0;
            if (!Main.isRTE) { shadowMM = (int)save[offsets.main.ShadowMM]; }
            else { shadowMM = (int)Memory.ReadBytes(Convert.ToInt32(offsets.main.ShadowMMRTE), 1).First(); }

            int eggmanJE = 0;
            if (!Main.isRTE) { eggmanJE = (int)save[offsets.main.EggmanJet]; }
            else { eggmanJE = (int)Memory.ReadBytes(Convert.ToInt32(offsets.main.EggmanJetRTE), 1).First(); }
            int eggmanLC = 0;
            if (!Main.isRTE) { eggmanLC = (int)save[offsets.main.EggmanCannon]; }
            else { eggmanLC = (int)Memory.ReadBytes(Convert.ToInt32(offsets.main.EggmanCannonRTE), 1).First(); }
            int eggmanLB = 0;
            if (!Main.isRTE) { eggmanLB = (int)save[offsets.main.EggmanLaser]; }
            else { eggmanLB = (int)Memory.ReadBytes(Convert.ToInt32(offsets.main.EggmanLaserRTE), 1).First(); }
            int eggmanPA = 0;
            if (!Main.isRTE) { eggmanPA = (int)save[offsets.main.EggmanArmor]; }
            else { eggmanPA = (int)Memory.ReadBytes(Convert.ToInt32(offsets.main.EggmanArmorRTE), 1).First(); }
            int eggmanMM = 0;
            if (!Main.isRTE) { eggmanMM = (int)save[offsets.main.EggmanMM]; }
            else { eggmanMM = (int)Memory.ReadBytes(Convert.ToInt32(offsets.main.EggmanMMRTE), 1).First(); }

            int rougePN = 0;
            if (!Main.isRTE) { rougePN = (int)save[offsets.main.RougePick]; }
            else { rougePN = (int)Memory.ReadBytes(Convert.ToInt32(offsets.main.RougePickRTE), 1).First(); }
            int rougeTS = 0;
            if (!Main.isRTE) { rougeTS = (int)save[offsets.main.RougeTreasure]; }
            else { rougeTS = (int)Memory.ReadBytes(Convert.ToInt32(offsets.main.RougeTreasureRTE), 1).First(); }
            int rougeIB = 0;
            if (!Main.isRTE) { rougeIB = (int)save[offsets.main.RougeBoots]; }
            else { rougeIB = (int)Memory.ReadBytes(Convert.ToInt32(offsets.main.RougeBootsRTE), 1).First(); }
            int rougeMM = 0;
            if (!Main.isRTE) { rougeMM = (int)save[offsets.main.RougeMM]; }
            else { rougeMM = (int)Memory.ReadBytes(Convert.ToInt32(offsets.main.RougeMMRTE), 1).First(); }

            int karateB = (int)save[offsets.main.ChaoKarateBeginner];
            int karateS = (int)save[offsets.main.ChaoKarateStandard];
            int karateE = (int)save[offsets.main.ChaoKarateExpert];
            int karateSu = (int)save[offsets.main.ChaoKarateSuper];

            int raceB = (int)save[offsets.main.ChaoRaceBeginner];
            int raceJ = (int)save[offsets.main.ChaoRaceJewel];
            int raceC = (int)save[offsets.main.ChaoRaceChallenge];
            int raceH = (int)save[offsets.main.ChaoRaceHero];
            int raceD = (int)save[offsets.main.ChaoRaceDark];

            int themeA = 0;
            if (!Main.isRTE) { themeA = (int)save[offsets.main.ThemeAmy]; }
            else { themeA = (int)Memory.ReadBytes(Convert.ToInt32(offsets.main.ThemeAmyRTE), 1).First(); }
            int themeM = 0;
            if (!Main.isRTE) { themeM = (int)save[offsets.main.ThemeMaria]; }
            else { themeM = (int)Memory.ReadBytes(Convert.ToInt32(offsets.main.ThemeMariaRTE), 1).First(); }
            int themeS = 0;
            if (!Main.isRTE) { themeS = (int)save[offsets.main.ThemeSecretary]; }
            else { themeS = (int)Memory.ReadBytes(Convert.ToInt32(offsets.main.ThemeSecretaryRTE), 1).First(); }
            int themeO = 0;
            if (!Main.isRTE) { themeO = (int)save[offsets.main.ThemeOmochao]; }
            else { themeO = (int)Memory.ReadBytes(Convert.ToInt32(offsets.main.ThemeOmochaoRTE), 1).First(); }

            int greenH = (int)save[offsets.main.GreenHill];


            int kartS = 0;
            if (!Main.isRTE) { kartS = (int)save[offsets.main.KartSonic]; }
            else { kartS = (int)Memory.ReadBytes(Convert.ToInt32(offsets.main.KartSonicRTE), 1).First(); }
            int kartSh = 0;
            if (!Main.isRTE) { kartSh = (int)save[offsets.main.KartShadow]; }
            else { kartSh = (int)Memory.ReadBytes(Convert.ToInt32(offsets.main.KartShadowRTE), 1).First(); }
            int kartT = 0;
            if (!Main.isRTE) { kartT = (int)save[offsets.main.KartTails]; }
            else { kartT = (int)Memory.ReadBytes(Convert.ToInt32(offsets.main.KartTailsRTE), 1).First(); }
            int kartE = 0;
            if (!Main.isRTE) { kartE = (int)save[offsets.main.KartEggman]; }
            else { kartE = (int)Memory.ReadBytes(Convert.ToInt32(offsets.main.KartEggmanRTE), 1).First(); }
            int kartK = 0;
            if (!Main.isRTE) { kartK = (int)save[offsets.main.KartKnuckles]; }
            else { kartK = (int)Memory.ReadBytes(Convert.ToInt32(offsets.main.KartKnucklesRTE), 1).First(); }
            int kartR = 0;
            if (!Main.isRTE) { kartR = (int)save[offsets.main.KartRouge]; }
            else { kartR = (int)Memory.ReadBytes(Convert.ToInt32(offsets.main.KartRougeRTE), 1).First(); }

            Control.ControlCollection controls = tc.TabPages[tc.TabPages.IndexOf(currentMain.Value)].Controls[0].Controls[0].Controls;

            //Main
            CheckBox checkb_GreenHill = controls[0].Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_GreenHill").First();
            checkb_GreenHill.InvokeCheck(() => checkb_GreenHill.Checked(Convert.ToBoolean(greenH)));
            foreach (GroupBox gb in controls[0].Controls.OfType<GroupBox>())
            {
                if (gb.Name == "gb_TotalRings")
                {
                    NumericUpDown nud_TotalRings = gb.Controls.OfType<NumericUpDown>().Where(x => x.Name == "nud_TotalRings").First();
                    nud_TotalRings.InvokeCheck(() => nud_TotalRings.Value(rings));
                }
                if (gb.Name == "gb_Lives")
                {
                    NumericUpDown nud_Lives = gb.Controls.OfType<NumericUpDown>().Where(x => x.Name == "nud_Lives").First();
                    nud_Lives.InvokeCheck(() => nud_Lives.Value(lives));
                }
                if (gb.Name == "gb_PlayTime")
                {
                    NumericUpDown nud_PlayHour = gb.Controls.OfType<NumericUpDown>().Where(x => x.Name == "nud_PlayHour").First();
                    NumericUpDown nud_PlayMinute = gb.Controls.OfType<NumericUpDown>().Where(x => x.Name == "nud_PlayMinute").First();
                    NumericUpDown nud_PlaySecond = gb.Controls.OfType<NumericUpDown>().Where(x => x.Name == "nud_PlaySecond").First();
                    int hours = playTime / 216000;
                    int minutes = (playTime - (hours * 216000)) / 3600;
                    int seconds = ((playTime - (hours * 216000)) - ((playTime - (hours * 21600)) - ((playTime - (hours * 21600)) - minutes * 3600))) / 60;
                    nud_PlayHour.InvokeCheck(() => nud_PlayHour.Value(hours));
                    nud_PlayMinute.InvokeCheck(() => nud_PlayMinute.Value(minutes));
                    nud_PlaySecond.InvokeCheck(() => nud_PlaySecond.Value(seconds));
                }
                if (gb.Name == "gb_GCFileNo")
                {
                    NumericUpDown nud_GCFileNumber = gb.Controls.OfType<NumericUpDown>().Where(x => x.Name == "nud_GCFileNumber").First();
                    GroupBox gb_GCFileNo = gb;
                    if (!Main.isGC) { gb_GCFileNo.InvokeCheck(() => gb_GCFileNo.Visible = false); }
                    else { gb_GCFileNo.InvokeCheck(() => gb_GCFileNo.Visible = true); }
                    if (Main.isGC)
                    {
                        int fileNo = Int32.Parse(Encoding.UTF8.GetString(Main.gcFileBytes).Replace("-", " "));
                        nud_GCFileNumber.InvokeCheck(() => nud_GCFileNumber.Value(fileNo));
                    }
                }
                if (gb.Name == "gb_Languages")
                {
                    ComboBox cb_Text = gb.Controls.OfType<ComboBox>().Where(x => x.Name == "cb_Text").First();
                    ComboBox cb_Voice = gb.Controls.OfType<ComboBox>().Where(x => x.Name == "cb_Voice").First();
                    if (Main.isPC)
                    {
                        cb_Text.InvokeCheck(() => cb_Text.Items.Clear());
                        cb_Text.InvokeCheck(() => cb_Text.Items.AddRange(new object[] {
                            "Japanese",
                            "English"}));
                    }

                    cb_Text.InvokeCheck(() => cb_Text.SelectedIndex(textLang));
                    cb_Voice.InvokeCheck(() => cb_Voice.SelectedIndex(voiceLang));
                }
                if (gb.Name == "gb_EmblemTime")
                {
                    NumericUpDown nud_EmblemHour = gb.Controls.OfType<NumericUpDown>().Where(x => x.Name == "nud_EmblemHour").First();
                    NumericUpDown nud_EmblemMinute = gb.Controls.OfType<NumericUpDown>().Where(x => x.Name == "nud_EmblemMinute").First();
                    NumericUpDown nud_EmblemSecond = gb.Controls.OfType<NumericUpDown>().Where(x => x.Name == "nud_EmblemSecond").First();
                    int hours = emblemTime / 216000;
                    int minutes = (emblemTime - (hours * 216000)) / 3600;
                    int seconds = ((emblemTime - (hours * 216000)) - ((emblemTime - (hours * 21600)) - ((emblemTime - (hours * 21600)) - minutes * 3600))) / 60;
                    nud_EmblemHour.InvokeCheck(() => nud_EmblemHour.Value(hours));
                    nud_EmblemMinute.InvokeCheck(() => nud_EmblemMinute.Value(minutes));
                    nud_EmblemSecond.InvokeCheck(() => nud_EmblemSecond.Value(seconds));
                }
                if (gb.Name == "gb_ChaoWorldCharacters")
                {
                    CheckBox checkb_CWSonic = gb.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_CWSonic").First();
                    CheckBox checkb_CWTails = gb.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_CWTails").First();
                    CheckBox checkb_CWKnuckles = gb.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_CWKnuckles").First();
                    CheckBox checkb_CWShadow = gb.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_CWShadow").First();
                    CheckBox checkb_CWEggman = gb.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_CWEggman").First();
                    CheckBox checkb_CWRouge = gb.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_CWRouge").First();
                    checkb_CWSonic.InvokeCheck(() => checkb_CWSonic.Checked(Convert.ToBoolean(sonicCW)));
                    checkb_CWTails.InvokeCheck(() => checkb_CWTails.Checked(Convert.ToBoolean(tailsCW)));
                    checkb_CWKnuckles.InvokeCheck(() => checkb_CWKnuckles.Checked(Convert.ToBoolean(knucklesCW)));
                    checkb_CWShadow.InvokeCheck(() => checkb_CWShadow.Checked(Convert.ToBoolean(shadowCW)));
                    checkb_CWEggman.InvokeCheck(() => checkb_CWEggman.Checked(Convert.ToBoolean(eggmanCW)));
                    checkb_CWRouge.InvokeCheck(() => checkb_CWRouge.Checked(Convert.ToBoolean(rougeCW)));
                }
                if (gb.Name == "gb_UnlockedKarts")
                {
                    CheckBox checkb_KartSonic = gb.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_KartSonic").First();
                    CheckBox checkb_KartShadow = gb.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_KartShadow").First();
                    CheckBox checkb_KartTails = gb.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_KartTails").First();
                    CheckBox checkb_KartEggman = gb.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_KartEggman").First();
                    CheckBox checkb_KartKnuckles = gb.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_KartKnuckles").First();
                    CheckBox checkb_KartRouge = gb.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_KartRouge").First();
                    checkb_KartSonic.InvokeCheck(() => checkb_KartSonic.Checked(Convert.ToBoolean(kartS)));
                    checkb_KartShadow.InvokeCheck(() => checkb_KartShadow.Checked(Convert.ToBoolean(kartSh)));
                    checkb_KartTails.InvokeCheck(() => checkb_KartTails.Checked(Convert.ToBoolean(kartT)));
                    checkb_KartEggman.InvokeCheck(() => checkb_KartEggman.Checked(Convert.ToBoolean(kartE)));
                    checkb_KartKnuckles.InvokeCheck(() => checkb_KartKnuckles.Checked(Convert.ToBoolean(kartK)));
                    checkb_KartRouge.InvokeCheck(() => checkb_KartRouge.Checked(Convert.ToBoolean(kartR)));
                }
                if (gb.Name == "gb_UnlockedThemes")
                {
                    CheckBox checkb_Amy = gb.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_Amy").First();
                    CheckBox checkb_Maria = gb.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_Maria").First();
                    CheckBox checkb_Secretary = gb.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_Secretary").First();
                    CheckBox checkb_Omochao = gb.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_Omochao").First();
                    checkb_Amy.InvokeCheck(() => checkb_Amy.Checked(Convert.ToBoolean(themeA)));
                    checkb_Maria.InvokeCheck(() => checkb_Maria.Checked(Convert.ToBoolean(themeM)));
                    checkb_Secretary.InvokeCheck(() => checkb_Secretary.Checked(Convert.ToBoolean(themeS)));
                    checkb_Omochao.InvokeCheck(() => checkb_Omochao.Checked(Convert.ToBoolean(themeO)));
                }
                if (gb.Name == "gb_Upgrades")
                {
                    TabControl tcUp = gb.Controls.OfType<TabControl>().Where(x => x.Name == "tc_Upgrades").First();
                    TabPage tpSonic = tcUp.Controls.OfType<TabPage>().Where(x => x.Name == "tp_Sonic").First();
                    TabPage tpTails = tcUp.Controls.OfType<TabPage>().Where(x => x.Name == "tp_Tails").First();
                    TabPage tpKnuckles = tcUp.Controls.OfType<TabPage>().Where(x => x.Name == "tp_Knuckles").First();
                    TabPage tpShadow = tcUp.Controls.OfType<TabPage>().Where(x => x.Name == "tp_Shadow").First();
                    TabPage tpEggman = tcUp.Controls.OfType<TabPage>().Where(x => x.Name == "tp_Eggman").First();
                    TabPage tpRouge = tcUp.Controls.OfType<TabPage>().Where(x => x.Name == "tp_Rouge").First();

                    CheckBox checkb_SonicLightShoes = tpSonic.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_SonicLightShoes").First();
                    CheckBox checkb_SonicAncientLight = tpSonic.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_SonicAncientLight").First();
                    CheckBox checkb_SonicMagicGloves = tpSonic.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_SonicMagicGloves").First();
                    CheckBox checkb_SonicFlameRing = tpSonic.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_SonicFlameRing").First();
                    CheckBox checkb_SonicBounceBracelet = tpSonic.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_SonicBounceBracelet").First();
                    CheckBox checkb_SonicMysticMelody = tpSonic.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_SonicMysticMelody").First();

                    CheckBox checkb_TailsBooster = tpTails.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_TailsBooster").First();
                    CheckBox checkb_TailsBazooka = tpTails.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_TailsBazooka").First();
                    CheckBox checkb_TailsLaserBlaster = tpTails.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_TailsLaserBlaster").First();
                    CheckBox checkb_TailsMysticMelody = tpTails.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_TailsMysticMelody").First();

                    CheckBox checkb_KnucklesShovelClaw = tpKnuckles.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_KnucklesShovelClaw").First();
                    CheckBox checkb_KnucklesSunglasses = tpKnuckles.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_KnucklesSunglasses").First();
                    CheckBox checkb_KnucklesHammerGloves = tpKnuckles.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_KnucklesHammerGloves").First();
                    CheckBox checkb_KnucklesAirNecklace = tpKnuckles.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_KnucklesAirNecklace").First();
                    CheckBox checkb_KnucklesMysticMelody = tpKnuckles.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_KnucklesMysticMelody").First();

                    CheckBox checkb_ShadowAirShoes = tpShadow.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_ShadowAirShoes").First();
                    CheckBox checkb_ShadowAncientLight = tpShadow.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_ShadowAncientLight").First();
                    CheckBox checkb_ShadowFlameRing = tpShadow.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_ShadowFlameRing").First();
                    CheckBox checkb_ShadowMysticMelody = tpShadow.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_ShadowMysticMelody").First();

                    CheckBox checkb_EggmanJetEngine = tpEggman.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_EggmanJetEngine").First();
                    CheckBox checkb_EggmanLargeCannon = tpEggman.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_EggmanLargeCannon").First();
                    CheckBox checkb_EggmanLaserBlaster = tpEggman.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_EggmanLaserBlaster").First();
                    CheckBox checkb_EggmanProtectiveArmor = tpEggman.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_EggmanProtectiveArmor").First();
                    CheckBox checkb_EggmanMysticMelody = tpEggman.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_EggmanMysticMelody").First();

                    CheckBox checkb_RougePickNails = tpRouge.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_RougePickNails").First();
                    CheckBox checkb_RougeTreasureScope = tpRouge.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_RougeTreasureScope").First();
                    CheckBox checkb_RougeIronBoots = tpRouge.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_RougeIronBoots").First();
                    CheckBox checkb_RougeMysticMelody = tpRouge.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_RougeMysticMelody").First();

                    checkb_SonicLightShoes.InvokeCheck(() => checkb_SonicLightShoes.Checked(Convert.ToBoolean(sonicLS)));
                    checkb_SonicAncientLight.InvokeCheck(() => checkb_SonicAncientLight.Checked(Convert.ToBoolean(sonicAL)));
                    checkb_SonicMagicGloves.InvokeCheck(() => checkb_SonicMagicGloves.Checked(Convert.ToBoolean(sonicMG)));
                    checkb_SonicFlameRing.InvokeCheck(() => checkb_SonicFlameRing.Checked(Convert.ToBoolean(sonicFR)));
                    checkb_SonicBounceBracelet.InvokeCheck(() => checkb_SonicBounceBracelet.Checked(Convert.ToBoolean(sonicBB)));
                    checkb_SonicMysticMelody.InvokeCheck(() => checkb_SonicMysticMelody.Checked(Convert.ToBoolean(sonicMM)));

                    checkb_TailsBooster.InvokeCheck(() => checkb_TailsBooster.Checked(Convert.ToBoolean(tailsBo)));
                    checkb_TailsBazooka.InvokeCheck(() => checkb_TailsBazooka.Checked(Convert.ToBoolean(tailsBa)));
                    checkb_TailsLaserBlaster.InvokeCheck(() => checkb_TailsLaserBlaster.Checked(Convert.ToBoolean(tailsL)));
                    checkb_TailsMysticMelody.InvokeCheck(() => checkb_TailsMysticMelody.Checked(Convert.ToBoolean(tailsMM)));

                    checkb_KnucklesShovelClaw.InvokeCheck(() => checkb_KnucklesShovelClaw.Checked(Convert.ToBoolean(knucklesSC)));
                    checkb_KnucklesSunglasses.InvokeCheck(() => checkb_KnucklesSunglasses.Checked(Convert.ToBoolean(knucklesS)));
                    checkb_KnucklesHammerGloves.InvokeCheck(() => checkb_KnucklesHammerGloves.Checked(Convert.ToBoolean(knucklesHG)));
                    checkb_KnucklesAirNecklace.InvokeCheck(() => checkb_KnucklesAirNecklace.Checked(Convert.ToBoolean(knucklesAN)));
                    checkb_KnucklesMysticMelody.InvokeCheck(() => checkb_KnucklesMysticMelody.Checked(Convert.ToBoolean(knucklesMM)));

                    checkb_ShadowAirShoes.InvokeCheck(() => checkb_ShadowAirShoes.Checked(Convert.ToBoolean(shadowAS)));
                    checkb_ShadowAncientLight.InvokeCheck(() => checkb_ShadowAncientLight.Checked(Convert.ToBoolean(shadowAL)));
                    checkb_ShadowFlameRing.InvokeCheck(() => checkb_ShadowFlameRing.Checked(Convert.ToBoolean(shadowFR)));
                    checkb_ShadowMysticMelody.InvokeCheck(() => checkb_ShadowMysticMelody.Checked(Convert.ToBoolean(shadowMM)));

                    checkb_EggmanJetEngine.InvokeCheck(() => checkb_EggmanJetEngine.Checked(Convert.ToBoolean(eggmanJE)));
                    checkb_EggmanLargeCannon.InvokeCheck(() => checkb_EggmanLargeCannon.Checked(Convert.ToBoolean(eggmanLC)));
                    checkb_EggmanLaserBlaster.InvokeCheck(() => checkb_EggmanLaserBlaster.Checked(Convert.ToBoolean(eggmanLB)));
                    checkb_EggmanProtectiveArmor.InvokeCheck(() => checkb_EggmanProtectiveArmor.Checked(Convert.ToBoolean(eggmanPA)));
                    checkb_EggmanMysticMelody.InvokeCheck(() => checkb_EggmanMysticMelody.Checked(Convert.ToBoolean(eggmanMM)));

                    checkb_RougePickNails.InvokeCheck(() => checkb_RougePickNails.Checked(Convert.ToBoolean(rougePN)));
                    checkb_RougeTreasureScope.InvokeCheck(() => checkb_RougeTreasureScope.Checked(Convert.ToBoolean(rougeTS)));
                    checkb_RougeIronBoots.InvokeCheck(() => checkb_RougeIronBoots.Checked(Convert.ToBoolean(rougeIB)));
                    checkb_RougeMysticMelody.InvokeCheck(() => checkb_RougeMysticMelody.Checked(Convert.ToBoolean(rougeMM)));
                }
            }

            int tcIndex = 0;
            Main.tc_Main.InvokeCheck(() => tcIndex = Main.tc_Main.SelectedIndex);
            uc_Main ucMain = (uc_Main)Main.tc_Main.Controls[tcIndex].Controls[0];
            TabControl tcMain = ucMain.Controls.OfType<TabControl>().First().Controls[1].Controls.OfType<TabControl>().First();
            IEnumerable<TabPage> tpMissions = tcMain.Controls.OfType<TabPage>();
            uc_MainChao ucMainChao = tpMissions.Where(x => x.Text == "Chao").First().Controls.OfType<uc_MainChao>().First();

            //Emblems
            foreach (KeyValuePair<string, uint> keyValuePair in offsets.main.MissionOffsets)
            {
                TabPage currentMissionTab = tpMissions.OfType<TabPage>().Where(x => x.Text == keyValuePair.Key).First();
                uc_Mission ucCurrentMission = currentMissionTab.Controls.OfType<uc_Mission>().First();

                List<byte> currentMission = new List<byte>();
                currentMission.AddRange(save.Skip((int)keyValuePair.Value).Take(0xAB));

                int M1 = (int)(currentMission[(int)offsets.mission.M1]);
                int M2 = (int)(currentMission[(int)offsets.mission.M2]);
                int M3 = (int)(currentMission[(int)offsets.mission.M3]);
                int M4 = (int)(currentMission[(int)offsets.mission.M4]);
                int M5 = (int)(currentMission[(int)offsets.mission.M5]);

                int M1MM = (int)(currentMission[(int)(offsets.mission.M1T) + 0x00]);
                int M1SS = (int)(currentMission[(int)(offsets.mission.M1T) + 0x01]);
                int M1MS = (int)(currentMission[(int)(offsets.mission.M1T) + 0x02]);
                int M2MM = (int)(currentMission[(int)(offsets.mission.M2T) + 0x00]);
                int M2SS = (int)(currentMission[(int)(offsets.mission.M2T) + 0x01]);
                int M2MS = (int)(currentMission[(int)(offsets.mission.M2T) + 0x02]);
                int M3MM = (int)(currentMission[(int)(offsets.mission.M3T) + 0x00]);
                int M3SS = (int)(currentMission[(int)(offsets.mission.M3T) + 0x01]);
                int M3MS = (int)(currentMission[(int)(offsets.mission.M3T) + 0x02]);
                int M4MM = (int)(currentMission[(int)(offsets.mission.M4T) + 0x00]);
                int M4SS = (int)(currentMission[(int)(offsets.mission.M4T) + 0x01]);
                int M4MS = (int)(currentMission[(int)(offsets.mission.M4T) + 0x02]);
                int M5MM = (int)(currentMission[(int)(offsets.mission.M5T) + 0x00]);
                int M5SS = (int)(currentMission[(int)(offsets.mission.M5T) + 0x01]);
                int M5MS = (int)(currentMission[(int)(offsets.mission.M5T) + 0x02]);

                int M1P = 0;
                if (Main.isPC) { M1P = BitConverter.ToInt16(currentMission.Skip(Convert.ToInt32(offsets.mission.M1P)).Take(4).ToArray(), 0); }
                else { M1P = BitConverter.ToInt16(currentMission.Skip(Convert.ToInt32(offsets.mission.M1P)).Take(4).Reverse().ToArray(), 0); }
                int M2P = 0;
                if (Main.isPC) { M2P = BitConverter.ToInt16(currentMission.Skip(Convert.ToInt32(offsets.mission.M2P)).Take(4).ToArray(), 0); }
                else { M2P = BitConverter.ToInt16(currentMission.Skip(Convert.ToInt32(offsets.mission.M2P)).Take(4).Reverse().ToArray(), 0); }
                int M3P = 0;
                if (Main.isPC) { M3P = BitConverter.ToInt16(currentMission.Skip(Convert.ToInt32(offsets.mission.M3P)).Take(4).ToArray(), 0); }
                else { M3P = BitConverter.ToInt16(currentMission.Skip(Convert.ToInt32(offsets.mission.M3P)).Take(4).Reverse().ToArray(), 0); }
                int M4P = 0;
                if (Main.isPC) { M4P = BitConverter.ToInt16(currentMission.Skip(Convert.ToInt32(offsets.mission.M4P)).Take(4).ToArray(), 0); }
                else { M4P = BitConverter.ToInt16(currentMission.Skip(Convert.ToInt32(offsets.mission.M4P)).Take(4).Reverse().ToArray(), 0); }
                int M5P = 0;
                if (Main.isPC) { M5P = BitConverter.ToInt16(currentMission.Skip(Convert.ToInt32(offsets.mission.M5P)).Take(4).ToArray(), 0); }
                else { M5P = BitConverter.ToInt16(currentMission.Skip(Convert.ToInt32(offsets.mission.M5P)).Take(4).Reverse().ToArray(), 0); }

                int M1R = 0;
                if (Main.isPC) { M1R = BitConverter.ToInt16(currentMission.Skip(Convert.ToInt32(offsets.mission.M1R)).Take(4).ToArray(), 0); }
                else { M1R = BitConverter.ToInt16(currentMission.Skip(Convert.ToInt32(offsets.mission.M1R)).Take(4).Reverse().ToArray(), 0); }
                int M2R = 0;
                if (Main.isPC) { M2R = BitConverter.ToInt16(currentMission.Skip(Convert.ToInt32(offsets.mission.M2R)).Take(4).ToArray(), 0); }
                else { M2R = BitConverter.ToInt16(currentMission.Skip(Convert.ToInt32(offsets.mission.M2R)).Take(4).Reverse().ToArray(), 0); }
                int M3R = 0;
                if (Main.isPC) { M3R = BitConverter.ToInt16(currentMission.Skip(Convert.ToInt32(offsets.mission.M3R)).Take(4).ToArray(), 0); }
                else { M3R = BitConverter.ToInt16(currentMission.Skip(Convert.ToInt32(offsets.mission.M3R)).Take(4).Reverse().ToArray(), 0); }
                int M4R = 0;
                if (Main.isPC) { M4R = BitConverter.ToInt16(currentMission.Skip(Convert.ToInt32(offsets.mission.M4R)).Take(4).ToArray(), 0); }
                else { M4R = BitConverter.ToInt16(currentMission.Skip(Convert.ToInt32(offsets.mission.M4R)).Take(4).Reverse().ToArray(), 0); }
                int M5R = 0;
                if (Main.isPC) { M5R = BitConverter.ToInt16(currentMission.Skip(Convert.ToInt32(offsets.mission.M5R)).Take(4).ToArray(), 0); }
                else { M5R = BitConverter.ToInt16(currentMission.Skip(Convert.ToInt32(offsets.mission.M5R)).Take(4).Reverse().ToArray(), 0); }


                int M1S = 0;
                if (Main.isPC) { M1S = BitConverter.ToInt32(currentMission.Skip(Convert.ToInt32(offsets.mission.M1S)).Take(4).ToArray(), 0); }
                else { M1S = BitConverter.ToInt32(currentMission.Skip(Convert.ToInt32(offsets.mission.M1S)).Take(4).Reverse().ToArray(), 0); }
                int M4S = 0;
                if (Main.isPC) { M4S = BitConverter.ToInt32(currentMission.Skip(Convert.ToInt32(offsets.mission.M4S)).Take(4).ToArray(), 0); }
                else { M4S = BitConverter.ToInt32(currentMission.Skip(Convert.ToInt32(offsets.mission.M4S)).Take(4).Reverse().ToArray(), 0); }
                int M5S = 0;
                if (Main.isPC) { M5S = BitConverter.ToInt32(currentMission.Skip(Convert.ToInt32(offsets.mission.M5S)).Take(4).ToArray(), 0); }
                else { M5S = BitConverter.ToInt32(currentMission.Skip(Convert.ToInt32(offsets.mission.M5S)).Take(4).Reverse().ToArray(), 0); }

                ComboBox cb_1R = ucCurrentMission.Controls.OfType<ComboBox>().Where(x => x.Name == "cb_1R").First();
                ComboBox cb_2R = ucCurrentMission.Controls.OfType<ComboBox>().Where(x => x.Name == "cb_2R").First();
                ComboBox cb_3R = ucCurrentMission.Controls.OfType<ComboBox>().Where(x => x.Name == "cb_3R").First();
                ComboBox cb_4R = ucCurrentMission.Controls.OfType<ComboBox>().Where(x => x.Name == "cb_4R").First();
                ComboBox cb_5R = ucCurrentMission.Controls.OfType<ComboBox>().Where(x => x.Name == "cb_5R").First();

                NumericUpDown nud_1TimeMM = ucCurrentMission.Controls.OfType<NumericUpDown>().Where(x => x.Name == "nud_1TimeMM").First();
                NumericUpDown nud_1TimeSS = ucCurrentMission.Controls.OfType<NumericUpDown>().Where(x => x.Name == "nud_1TimeSS").First();
                NumericUpDown nud_1TimeMS = ucCurrentMission.Controls.OfType<NumericUpDown>().Where(x => x.Name == "nud_1TimeMS").First();
                NumericUpDown nud_2TimeMM = ucCurrentMission.Controls.OfType<NumericUpDown>().Where(x => x.Name == "nud_2TimeMM").First();
                NumericUpDown nud_2TimeSS = ucCurrentMission.Controls.OfType<NumericUpDown>().Where(x => x.Name == "nud_2TimeSS").First();
                NumericUpDown nud_2TimeMS = ucCurrentMission.Controls.OfType<NumericUpDown>().Where(x => x.Name == "nud_2TimeMS").First();
                NumericUpDown nud_3TimeMM = ucCurrentMission.Controls.OfType<NumericUpDown>().Where(x => x.Name == "nud_3TimeMM").First();
                NumericUpDown nud_3TimeSS = ucCurrentMission.Controls.OfType<NumericUpDown>().Where(x => x.Name == "nud_3TimeSS").First();
                NumericUpDown nud_3TimeMS = ucCurrentMission.Controls.OfType<NumericUpDown>().Where(x => x.Name == "nud_3TimeMS").First();
                NumericUpDown nud_4TimeMM = ucCurrentMission.Controls.OfType<NumericUpDown>().Where(x => x.Name == "nud_4TimeMM").First();
                NumericUpDown nud_4TimeSS = ucCurrentMission.Controls.OfType<NumericUpDown>().Where(x => x.Name == "nud_4TimeSS").First();
                NumericUpDown nud_4TimeMS = ucCurrentMission.Controls.OfType<NumericUpDown>().Where(x => x.Name == "nud_4TimeMS").First();
                NumericUpDown nud_5TimeMM = ucCurrentMission.Controls.OfType<NumericUpDown>().Where(x => x.Name == "nud_5TimeMM").First();
                NumericUpDown nud_5TimeSS = ucCurrentMission.Controls.OfType<NumericUpDown>().Where(x => x.Name == "nud_5TimeSS").First();
                NumericUpDown nud_5TimeMS = ucCurrentMission.Controls.OfType<NumericUpDown>().Where(x => x.Name == "nud_5TimeMS").First();

                NumericUpDown nud_1P = ucCurrentMission.Controls.OfType<NumericUpDown>().Where(x => x.Name == "nud_1P").First();
                NumericUpDown nud_2P = ucCurrentMission.Controls.OfType<NumericUpDown>().Where(x => x.Name == "nud_2P").First();
                NumericUpDown nud_3P = ucCurrentMission.Controls.OfType<NumericUpDown>().Where(x => x.Name == "nud_3P").First();
                NumericUpDown nud_4P = ucCurrentMission.Controls.OfType<NumericUpDown>().Where(x => x.Name == "nud_4P").First();
                NumericUpDown nud_5P = ucCurrentMission.Controls.OfType<NumericUpDown>().Where(x => x.Name == "nud_5P").First();

                NumericUpDown nud_1Rings = ucCurrentMission.Controls.OfType<NumericUpDown>().Where(x => x.Name == "nud_1Rings").First();
                NumericUpDown nud_4Rings = ucCurrentMission.Controls.OfType<NumericUpDown>().Where(x => x.Name == "nud_4Rings").First();
                NumericUpDown nud_5Rings = ucCurrentMission.Controls.OfType<NumericUpDown>().Where(x => x.Name == "nud_5Rings").First();

                NumericUpDown nud_1S = ucCurrentMission.Controls.OfType<NumericUpDown>().Where(x => x.Name == "nud_1S").First();
                NumericUpDown nud_4S = ucCurrentMission.Controls.OfType<NumericUpDown>().Where(x => x.Name == "nud_4S").First();
                NumericUpDown nud_5S = ucCurrentMission.Controls.OfType<NumericUpDown>().Where(x => x.Name == "nud_5S").First();

                cb_1R.InvokeCheck(() => cb_1R.SelectedIndex(M1));
                cb_2R.InvokeCheck(() => cb_2R.SelectedIndex(M2));
                cb_3R.InvokeCheck(() => cb_3R.SelectedIndex(M3));
                cb_4R.InvokeCheck(() => cb_4R.SelectedIndex(M4));
                cb_5R.InvokeCheck(() => cb_5R.SelectedIndex(M5));

                nud_1TimeMM.InvokeCheck(() => nud_1TimeMM.Value(M1MM));
                nud_1TimeSS.InvokeCheck(() => nud_1TimeSS.Value(M1SS));
                nud_1TimeMS.InvokeCheck(() => nud_1TimeMS.Value(M1MS));
                nud_2TimeMM.InvokeCheck(() => nud_2TimeMM.Value(M2MM));
                nud_2TimeSS.InvokeCheck(() => nud_2TimeSS.Value(M2SS));
                nud_2TimeMS.InvokeCheck(() => nud_2TimeMS.Value(M2MS));
                nud_3TimeMM.InvokeCheck(() => nud_3TimeMM.Value(M3MM));
                nud_3TimeSS.InvokeCheck(() => nud_3TimeSS.Value(M3SS));
                nud_3TimeMS.InvokeCheck(() => nud_3TimeMS.Value(M3MS));
                nud_4TimeMM.InvokeCheck(() => nud_4TimeMM.Value(M4MM));
                nud_4TimeSS.InvokeCheck(() => nud_4TimeSS.Value(M4SS));
                nud_4TimeMS.InvokeCheck(() => nud_4TimeMS.Value(M4MS));
                nud_5TimeMM.InvokeCheck(() => nud_5TimeMM.Value(M5MM));
                nud_5TimeSS.InvokeCheck(() => nud_5TimeSS.Value(M5SS));
                nud_5TimeMS.InvokeCheck(() => nud_5TimeMS.Value(M5MS));

                nud_1P.InvokeCheck(() => nud_1P.Value(M1P));
                nud_2P.InvokeCheck(() => nud_2P.Value(M2P));
                nud_3P.InvokeCheck(() => nud_3P.Value(M3P));
                nud_4P.InvokeCheck(() => nud_4P.Value(M4P));
                nud_5P.InvokeCheck(() => nud_5P.Value(M5P));

                nud_1Rings.InvokeCheck(() => nud_1Rings.Value(M1R));
                nud_4Rings.InvokeCheck(() => nud_4Rings.Value(M4R));
                nud_5Rings.InvokeCheck(() => nud_5Rings.Value(M5R));

                nud_1S.InvokeCheck(() => nud_1S.Value(M1S));
                nud_4S.InvokeCheck(() => nud_4S.Value(M4S));
                nud_5S.InvokeCheck(() => nud_5S.Value(M5S));
            }

            //Kart
            foreach (KeyValuePair<string, uint> keyValuePair in offsets.main.KartOffsets)
            {
                TabPage currentMissionTab = tpMissions.OfType<TabPage>().Where(x => x.Text == keyValuePair.Key).First();
                uc_Kart ucCurrentMission = currentMissionTab.Controls.OfType<uc_Kart>().First();

                List<byte> currentMission = new List<byte>();
                currentMission.AddRange(save.Skip((int)keyValuePair.Value).Take(0x29));

                int E = (int)(currentMission[(int)offsets.kart.Emblem]);

                int M1C = (int)(currentMission[(int)offsets.kart.FirstC]);
                int M2C = (int)(currentMission[(int)offsets.kart.SecondC]);
                int M3C = (int)(currentMission[(int)offsets.kart.ThirdC]);

                //Change value to workable value for ComboBox if hidden kart
                if (M1C > 5)
                {
                    M1C -= 122;
                }
                if (M2C > 5)
                {
                    M2C -= 122;
                }
                if (M3C > 5)
                {
                    M3C -= 122;
                }

                int M1MM = (int)(currentMission[(int)(offsets.kart.FirstT) + 0x00]);
                int M1SS = (int)(currentMission[(int)(offsets.kart.FirstT) + 0x01]);
                int M1MS = (int)(currentMission[(int)(offsets.kart.FirstT) + 0x02]);
                int M2MM = (int)(currentMission[(int)(offsets.kart.SecondT) + 0x00]);
                int M2SS = (int)(currentMission[(int)(offsets.kart.SecondT) + 0x01]);
                int M2MS = (int)(currentMission[(int)(offsets.kart.SecondT) + 0x02]);
                int M3MM = (int)(currentMission[(int)(offsets.kart.ThirdT) + 0x00]);
                int M3SS = (int)(currentMission[(int)(offsets.kart.ThirdT) + 0x01]);
                int M3MS = (int)(currentMission[(int)(offsets.kart.ThirdT) + 0x02]);

                CheckBox checkb_Emblem = ucCurrentMission.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_Emblem").First();

                ComboBox cb_1stCharacter = ucCurrentMission.Controls.OfType<ComboBox>().Where(x => x.Name == "cb_1stCharacter").First();
                ComboBox cb_2ndCharacter = ucCurrentMission.Controls.OfType<ComboBox>().Where(x => x.Name == "cb_2ndCharacter").First();
                ComboBox cb_3rdCharacter = ucCurrentMission.Controls.OfType<ComboBox>().Where(x => x.Name == "cb_3rdCharacter").First();

                NumericUpDown nud_1TimeMM = ucCurrentMission.Controls.OfType<NumericUpDown>().Where(x => x.Name == "nud_1TimeMM").First();
                NumericUpDown nud_1TimeSS = ucCurrentMission.Controls.OfType<NumericUpDown>().Where(x => x.Name == "nud_1TimeSS").First();
                NumericUpDown nud_1TimeMS = ucCurrentMission.Controls.OfType<NumericUpDown>().Where(x => x.Name == "nud_1TimeMS").First();
                NumericUpDown nud_2TimeMM = ucCurrentMission.Controls.OfType<NumericUpDown>().Where(x => x.Name == "nud_2TimeMM").First();
                NumericUpDown nud_2TimeSS = ucCurrentMission.Controls.OfType<NumericUpDown>().Where(x => x.Name == "nud_2TimeSS").First();
                NumericUpDown nud_2TimeMS = ucCurrentMission.Controls.OfType<NumericUpDown>().Where(x => x.Name == "nud_2TimeMS").First();
                NumericUpDown nud_3TimeMM = ucCurrentMission.Controls.OfType<NumericUpDown>().Where(x => x.Name == "nud_3TimeMM").First();
                NumericUpDown nud_3TimeSS = ucCurrentMission.Controls.OfType<NumericUpDown>().Where(x => x.Name == "nud_3TimeSS").First();
                NumericUpDown nud_3TimeMS = ucCurrentMission.Controls.OfType<NumericUpDown>().Where(x => x.Name == "nud_3TimeMS").First();

                checkb_Emblem.InvokeCheck(() => checkb_Emblem.Checked = Convert.ToBoolean(E));

                cb_1stCharacter.InvokeCheck(() => cb_1stCharacter.SelectedIndex(M1C));
                cb_2ndCharacter.InvokeCheck(() => cb_2ndCharacter.SelectedIndex(M2C));
                cb_3rdCharacter.InvokeCheck(() => cb_3rdCharacter.SelectedIndex(M3C));

                nud_1TimeMM.InvokeCheck(() => nud_1TimeMM.Value(M1MM));
                nud_1TimeSS.InvokeCheck(() => nud_1TimeSS.Value(M1SS));
                nud_1TimeMS.InvokeCheck(() => nud_1TimeMS.Value(M1MS));
                nud_2TimeMM.InvokeCheck(() => nud_2TimeMM.Value(M2MM));
                nud_2TimeSS.InvokeCheck(() => nud_2TimeSS.Value(M2SS));
                nud_2TimeMS.InvokeCheck(() => nud_2TimeMS.Value(M2MS));
                nud_3TimeMM.InvokeCheck(() => nud_3TimeMM.Value(M3MM));
                nud_3TimeSS.InvokeCheck(() => nud_3TimeSS.Value(M3SS));
                nud_3TimeMS.InvokeCheck(() => nud_3TimeMS.Value(M3MS));
            }

            //Boss
            foreach (KeyValuePair<string, KeyValuePair<uint, uint>> keyValuePair in offsets.main.BossOffsets)
            {
                TabPage currentMissionTab = tpMissions.OfType<TabPage>().Where(x => x.Text == keyValuePair.Key).First();
                uc_Boss ucCurrentMission = currentMissionTab.Controls.OfType<uc_Boss>().First();

                List<byte> currentMission = new List<byte>();
                currentMission.AddRange(save.Skip((int)keyValuePair.Value.Key).Take(0x8D));

                int E = (int)save[keyValuePair.Value.Value];

                int M1MM = (int)(currentMission[(int)(offsets.boss.FirstT) + 0x00]);
                int M1SS = (int)(currentMission[(int)(offsets.boss.FirstT) + 0x01]);
                int M1MS = (int)(currentMission[(int)(offsets.boss.FirstT) + 0x02]);
                int M2MM = (int)(currentMission[(int)(offsets.boss.SecondT) + 0x00]);
                int M2SS = (int)(currentMission[(int)(offsets.boss.SecondT) + 0x01]);
                int M2MS = (int)(currentMission[(int)(offsets.boss.SecondT) + 0x02]);
                int M3MM = (int)(currentMission[(int)(offsets.boss.ThirdT) + 0x00]);
                int M3SS = (int)(currentMission[(int)(offsets.boss.ThirdT) + 0x01]);
                int M3MS = (int)(currentMission[(int)(offsets.boss.ThirdT) + 0x02]);

                CheckBox checkb_Emblem = ucCurrentMission.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_Emblem").First();

                NumericUpDown nud_1TimeMM = ucCurrentMission.Controls.OfType<NumericUpDown>().Where(x => x.Name == "nud_1TimeMM").First();
                NumericUpDown nud_1TimeSS = ucCurrentMission.Controls.OfType<NumericUpDown>().Where(x => x.Name == "nud_1TimeSS").First();
                NumericUpDown nud_1TimeMS = ucCurrentMission.Controls.OfType<NumericUpDown>().Where(x => x.Name == "nud_1TimeMS").First();
                NumericUpDown nud_2TimeMM = ucCurrentMission.Controls.OfType<NumericUpDown>().Where(x => x.Name == "nud_2TimeMM").First();
                NumericUpDown nud_2TimeSS = ucCurrentMission.Controls.OfType<NumericUpDown>().Where(x => x.Name == "nud_2TimeSS").First();
                NumericUpDown nud_2TimeMS = ucCurrentMission.Controls.OfType<NumericUpDown>().Where(x => x.Name == "nud_2TimeMS").First();
                NumericUpDown nud_3TimeMM = ucCurrentMission.Controls.OfType<NumericUpDown>().Where(x => x.Name == "nud_3TimeMM").First();
                NumericUpDown nud_3TimeSS = ucCurrentMission.Controls.OfType<NumericUpDown>().Where(x => x.Name == "nud_3TimeSS").First();
                NumericUpDown nud_3TimeMS = ucCurrentMission.Controls.OfType<NumericUpDown>().Where(x => x.Name == "nud_3TimeMS").First();

                checkb_Emblem.InvokeCheck(() => checkb_Emblem.Checked = Convert.ToBoolean(E));

                nud_1TimeMM.InvokeCheck(() => nud_1TimeMM.Value = M1MM);
                nud_1TimeSS.InvokeCheck(() => nud_1TimeSS.Value = M1SS);
                nud_1TimeMS.InvokeCheck(() => nud_1TimeMS.Value = M1MS);
                nud_2TimeMM.InvokeCheck(() => nud_2TimeMM.Value = M2MM);
                nud_2TimeSS.InvokeCheck(() => nud_2TimeSS.Value = M2SS);
                nud_2TimeMS.InvokeCheck(() => nud_2TimeMS.Value = M2MS);
                nud_3TimeMM.InvokeCheck(() => nud_3TimeMM.Value = M3MM);
                nud_3TimeSS.InvokeCheck(() => nud_3TimeSS.Value = M3SS);
                nud_3TimeMS.InvokeCheck(() => nud_3TimeMS.Value = M3MS);
            }

            //Chao Emblems
            CheckBox checkb_RaceBeginner = ucMainChao.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_RaceBeginner").First();
            CheckBox checkb_RaceJewel = ucMainChao.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_RaceJewel").First();
            CheckBox checkb_RaceChallenge = ucMainChao.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_RaceChallenge").First();
            CheckBox checkb_RaceHero = ucMainChao.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_RaceHero").First();
            CheckBox checkb_RaceDark = ucMainChao.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_RaceDark").First();
            CheckBox checkb_KarateBeginner = ucMainChao.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_KarateBeginner").First();
            CheckBox checkb_KarateStandard = ucMainChao.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_KarateStandard").First();
            CheckBox checkb_KarateExpert = ucMainChao.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_KarateExpert").First();
            CheckBox checkb_KarateSuper = ucMainChao.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_KarateSuper").First();

            checkb_RaceBeginner.InvokeCheck(() => checkb_RaceBeginner.Checked = Convert.ToBoolean(raceB));
            checkb_RaceJewel.InvokeCheck(() => checkb_RaceJewel.Checked = Convert.ToBoolean(raceJ));
            checkb_RaceChallenge.InvokeCheck(() => checkb_RaceChallenge.Checked = Convert.ToBoolean(raceC));
            checkb_RaceHero.InvokeCheck(() => checkb_RaceHero.Checked = Convert.ToBoolean(raceH));
            checkb_RaceDark.InvokeCheck(() => checkb_RaceDark.Checked = Convert.ToBoolean(raceD));
            checkb_KarateBeginner.InvokeCheck(() => checkb_KarateBeginner.Checked = Convert.ToBoolean(karateB));
            checkb_KarateStandard.InvokeCheck(() => checkb_KarateStandard.Checked = Convert.ToBoolean(karateS));
            checkb_KarateExpert.InvokeCheck(() => checkb_KarateExpert.Checked = Convert.ToBoolean(karateE));
            checkb_KarateSuper.InvokeCheck(() => checkb_KarateSuper.Checked = Convert.ToBoolean(karateSu));
        }

        public static byte[] ByteSwapMain(byte[] save)
        {
            //Unsure what the following bytes do, however I can't get saves to convert from PC to console with these on different values
            save[0x5CE0] = 0x00;
            save[0x5CE1] = 0x00;
            save[0x5CE2] = 0x00;
            save[0x5CE3] = 0x00;
            List<byte> byteArray = save.ToList<byte>();
            foreach (KeyValuePair<string, uint> keyValuePair in offsets.main.MissionOffsets)
            {
                byteArray.Reverse((int)(keyValuePair.Value + offsets.mission.M1P), 2);
                byteArray.Reverse((int)(keyValuePair.Value + offsets.mission.M2P), 2);
                byteArray.Reverse((int)(keyValuePair.Value + offsets.mission.M3P), 2);
                byteArray.Reverse((int)(keyValuePair.Value + offsets.mission.M4P), 2);
                byteArray.Reverse((int)(keyValuePair.Value + offsets.mission.M5P), 2);
                byteArray.Reverse((int)(keyValuePair.Value + offsets.mission.M1R), 2);
                byteArray.Reverse((int)(keyValuePair.Value + offsets.mission.M4R), 2);
                byteArray.Reverse((int)(keyValuePair.Value + offsets.mission.M5R), 2);
                byteArray.Reverse((int)(keyValuePair.Value + offsets.mission.M1S), 4);
                byteArray.Reverse((int)(keyValuePair.Value + offsets.mission.M4S), 4);
                byteArray.Reverse((int)(keyValuePair.Value + offsets.mission.M5S), 4);
            }
            byteArray.Reverse((int)offsets.main.PlayTime, 4);
            byteArray.Reverse((int)offsets.main.EmblemResultsTime, 4);
            byteArray.Reverse((int)offsets.main.Rings, 4);
            byteArray.Reverse((int)offsets.main.Lives, 2);
            return byteArray.ToArray();
        }
    }
}
