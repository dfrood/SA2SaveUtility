using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SA2SaveUtility
{
    class MainSave
    {
        public static Offsets offsets = new Offsets();
        public static Dictionary<int, TabPage> activeMain = new Dictionary<int, TabPage>();

        public static byte[] WriteChecksum(byte[] save, bool PC, bool GC, bool PS3)
        {
            byte[] checksum = new byte[4];
            List<byte> newSave = new List<byte>();

            if (PC || GC)
            {
                if (PC) { checksum = BitConverter.GetBytes(save.Skip(0x2844).ToArray().Select(x => (int)x).Sum()); }
                if (GC) { checksum = BitConverter.GetBytes(save.Skip(0x2844).ToArray().Select(x => (int)x).Sum()).Reverse().ToArray(); }
                newSave.AddRange(save.Take(0x2840).ToArray());
                newSave.AddRange(checksum);
                newSave.AddRange(save.Skip(0x2844).ToArray());
            }
            if (!PC && !GC)
            {
                if (!PS3)
                {
                    foreach (byte[] splitSave in Main.SplitByteArray(save, 0x6004))
                    {
                        checksum = BitConverter.GetBytes(splitSave.Skip(0x2848).ToArray().Select(x => (int)x).Sum()).Reverse().ToArray();
                        newSave.AddRange(splitSave.Take(0x2844).ToArray());
                        newSave.AddRange(checksum);
                        newSave.AddRange(splitSave.Skip(0x2848).ToArray());
                    }
                }
                else
                {
                    foreach (byte[] splitSave in Main.SplitByteArray(save, 0x6008))
                    {
                        checksum = BitConverter.GetBytes(splitSave.Skip(0x284C).ToArray().Select(x => (int)x).Sum()).Reverse().ToArray();
                        newSave.AddRange(splitSave.Take(0x2848).ToArray());
                        newSave.AddRange(checksum);
                        newSave.AddRange(splitSave.Skip(0x284C).ToArray());
                    }
                }
            }


            return newSave.ToArray();
        }

        public static void GetMain()
        {
            offsets = new Offsets();
            offsets.main.MissionOffsets.Add("City Escape", 0x326C);
            offsets.main.MissionOffsets.Add("Wild Canyon", 0x34B8);
            offsets.main.MissionOffsets.Add("Prison Lane", 0x2F5C);
            offsets.main.MissionOffsets.Add("Metal Harbour", 0x3020);
            offsets.main.MissionOffsets.Add("Green Forest", 0x2AC4);
            offsets.main.MissionOffsets.Add("Pumpkin Hill", 0x2C4C);
            offsets.main.MissionOffsets.Add("Mission Street", 0x357C);
            offsets.main.MissionOffsets.Add("Aquatic Mine", 0x2DD4);
            offsets.main.MissionOffsets.Add("Route 101", 0x5668);
            offsets.main.MissionOffsets.Add("Hidden Base", 0x3A14);
            offsets.main.MissionOffsets.Add("Pyramid Cave", 0x3DE8);
            offsets.main.MissionOffsets.Add("Death Chamber", 0x3B9C);
            offsets.main.MissionOffsets.Add("Eternal Engine", 0x3AD8);
            offsets.main.MissionOffsets.Add("Meteor Herd", 0x40F8);
            offsets.main.MissionOffsets.Add("Crazy Gadget", 0x3950);
            offsets.main.MissionOffsets.Add("Final Rush", 0x3F70);

            offsets.main.MissionOffsets.Add("Iron Gate", 0x30E4);
            offsets.main.MissionOffsets.Add("Dry Lagoon", 0x3640);
            offsets.main.MissionOffsets.Add("Sand Ocean", 0x388C);
            offsets.main.MissionOffsets.Add("Radical Highway", 0x3330);
            offsets.main.MissionOffsets.Add("Egg Quarters", 0x3C60);
            offsets.main.MissionOffsets.Add("Lost Colony", 0x3D24);
            offsets.main.MissionOffsets.Add("Weapons Bed", 0x31A8);
            offsets.main.MissionOffsets.Add("Security Hall", 0x2E98);
            offsets.main.MissionOffsets.Add("White Jungle", 0x2B88);
            offsets.main.MissionOffsets.Add("Route 202", 0x572C);
            offsets.main.MissionOffsets.Add("Sky Rail", 0x2D10);
            offsets.main.MissionOffsets.Add("Mad Space", 0x4A28);
            offsets.main.MissionOffsets.Add("Cosmic Wall", 0x4964);
            offsets.main.MissionOffsets.Add("Final Chase", 0x4718);

            offsets.main.MissionOffsets.Add("Cannon's Core", 0x4280);

            offsets.main.KartOffsets.Add("Kart Racing - Beginner", 0x57F0);
            offsets.main.KartOffsets.Add("Kart Racing - Standard", 0x57FD);
            offsets.main.KartOffsets.Add("Kart Racing - Expert", 0x580A);

            offsets.main.BossOffsets.Add("Boss Attack - Hero", new KeyValuePair<uint, uint>(0x5818, 0x5CD5));
            offsets.main.BossOffsets.Add("Boss Attack - Dark", new KeyValuePair<uint, uint>(0x58DC, 0x5CD6));
            offsets.main.BossOffsets.Add("Boss Attack - All", new KeyValuePair<uint, uint>(0x59A0, 0x5CD7));

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
                List<byte> header = new List<byte>(Main.loadedSave.Skip(0x27).Take(0x19));
                tp.Text = Encoding.UTF8.GetString(header.Take(header.IndexOf(0x00)).ToArray());

                activeMain.Add(Main.tc_Main.TabPages.IndexOf(tp), tp);

                KeyValuePair<int, TabPage> currentMain = activeMain.Where(x => x.Key == Main.tc_Main.TabPages.IndexOf(tp)).First();
                UpdateSave(Main.tc_Main, currentMain, Main.loadedSave.ToArray());
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
            if (!Main.isPC && !Main.isGC) { save = save.Skip(0x04).ToArray();  }

            int playTime = 0;
            if (Main.isPC) { playTime = BitConverter.ToInt32(save.Skip(Convert.ToInt32(offsets.main.PlayTime)).Take(4).ToArray(), 0); }
            else { playTime = BitConverter.ToInt32(save.Skip(Convert.ToInt32(offsets.main.PlayTime)).Take(4).Reverse().ToArray(), 0); }

            int emblemTime = 0;
            if (Main.isPC) { emblemTime = BitConverter.ToInt32(save.Skip(Convert.ToInt32(offsets.main.EmblemResultsTime)).Take(4).ToArray(), 0); }
            else { emblemTime = BitConverter.ToInt32(save.Skip(Convert.ToInt32(offsets.main.EmblemResultsTime)).Take(4).Reverse().ToArray(), 0); }

            int lives = 0;
            if (Main.isPC) { lives = BitConverter.ToInt16(save.Skip(Convert.ToInt32(offsets.main.Lives)).Take(2).ToArray(), 0); }
            else { lives = BitConverter.ToInt16(save.Skip(Convert.ToInt32(offsets.main.Lives)).Take(2).Reverse().ToArray(), 0); }

            int rings = 0;
            if (Main.isPC) { rings = BitConverter.ToInt32(save.Skip(Convert.ToInt32(offsets.main.Rings)).Take(4).ToArray(), 0); }
            else { rings = BitConverter.ToInt32(save.Skip(Convert.ToInt32(offsets.main.Rings)).Take(4).Reverse().ToArray(), 0); }

            int textLang = (int)save[offsets.main.TextLanguage];
            int voiceLang = (int)save[offsets.main.VoiceLanguage];

            int sonicCW = (int)save[offsets.main.ChaoWorldSonic];
            int tailsCW = (int)save[offsets.main.ChaoWorldTails];
            int knucklesCW = (int)save[offsets.main.ChaoWorldKnuckles];
            int shadowCW = (int)save[offsets.main.ChaoWorldShadow];
            int eggmanCW = (int)save[offsets.main.ChaoWorldEggman];
            int rougeCW = (int)save[offsets.main.ChaoWorldRouge];

            int sonicLS = (int)save[offsets.main.SonicLightShoes];
            int sonicAL = (int)save[offsets.main.ShadowAncientLight];
            int sonicMG = (int)save[offsets.main.SonicMagic];
            int sonicFR = (int)save[offsets.main.SonicFlame];
            int sonicBB = (int)save[offsets.main.SonicBounce];
            int sonicMM = (int)save[offsets.main.SonicMM];

            int tailsBo = (int)save[offsets.main.TailsBooster];
            int tailsBa = (int)save[offsets.main.TailsBazooka];
            int tailsL = (int)save[offsets.main.TailsLaser];
            int tailsMM = (int)save[offsets.main.TailsMM];

            int knucklesSC = (int)save[offsets.main.KnucklesShovel];
            int knucklesS = (int)save[offsets.main.KnucklesSun];
            int knucklesHG = (int)save[offsets.main.KnucklesHammer];
            int knucklesAN = (int)save[offsets.main.KnucklesAir];
            int knucklesMM = (int)save[offsets.main.KnucklesMM];

            int shadowAS = (int)save[offsets.main.ShadowAir];
            int shadowAL = (int)save[offsets.main.ShadowAncientLight];
            int shadowFR = (int)save[offsets.main.ShadowFlame];
            int shadowMM = (int)save[offsets.main.ShadowMM];

            int eggmanJE = (int)save[offsets.main.EggmanJet];
            int eggmanLC = (int)save[offsets.main.EggmanCannon];
            int eggmanLB = (int)save[offsets.main.EggmanLaser];
            int eggmanPA = (int)save[offsets.main.EggmanArmor];
            int eggmanMM = (int)save[offsets.main.EggmanMM];

            int rougePN = (int)save[offsets.main.RougePick];
            int rougeTS = (int)save[offsets.main.RougeTreasure];
            int rougeIB = (int)save[offsets.main.RougeBoots];
            int rougeMM = (int)save[offsets.main.RougeMM];

            int karateB = (int)save[offsets.main.ChaoKarateBeginner];
            int karateS = (int)save[offsets.main.ChaoKarateStandard];
            int karateE = (int)save[offsets.main.ChaoKarateExpert];
            int karateSu = (int)save[offsets.main.ChaoKarateSuper];

            int raceB = (int)save[offsets.main.ChaoRaceBeginner];
            int raceJ = (int)save[offsets.main.ChaoRaceJewel];
            int raceC = (int)save[offsets.main.ChaoRaceChallenge];
            int raceH = (int)save[offsets.main.ChaoRaceHero];
            int raceD = (int)save[offsets.main.ChaoRaceDark];

            int themeA = (int)save[offsets.main.ThemeAmy];
            int themeM = (int)save[offsets.main.ThemeMaria];
            int themeS = (int)save[offsets.main.ThemeSecretary];
            int themeO = (int)save[offsets.main.ThemeOmochao];

            int greenH = (int)save[offsets.main.GreenHill];


            int kartS = (int)save[offsets.main.KartSonic];
            int kartSh = (int)save[offsets.main.KartShadow];
            int kartT = (int)save[offsets.main.KartTails];
            int kartE = (int)save[offsets.main.KartEggman];
            int kartK = (int)save[offsets.main.KartKnuckles];
            int kartR = (int)save[offsets.main.KartRouge];

            Control.ControlCollection controls = tc.TabPages[tc.TabPages.IndexOf(currentMain.Value)].Controls[0].Controls[0].Controls;

            //Main
            controls[0].Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_GreenHill").First().Checked = Convert.ToBoolean(greenH);
            foreach (GroupBox gb in controls[0].Controls.OfType<GroupBox>())
            {
                if (gb.Name == "gb_TotalRings") { if (gb.Controls.OfType<NumericUpDown>().First().Value != rings) { gb.Controls.OfType<NumericUpDown>().First().Value = rings; } }
                if (gb.Name == "gb_Lives") { if (gb.Controls.OfType<NumericUpDown>().First().Value != lives) { gb.Controls.OfType<NumericUpDown>().First().Value = lives; } }
                if (gb.Name == "gb_PlayTime")
                {
                    int hours = playTime / 216000;
                    int minutes = (playTime - (hours * 216000)) / 3600;
                    int seconds = ((playTime - (hours * 216000)) - ((playTime - (hours * 21600)) - ((playTime - (hours * 21600)) - minutes * 3600))) / 60;
                    gb.Controls.OfType<NumericUpDown>().Where(x => x.Name == "nud_PlayHour").First().Value = hours;
                    gb.Controls.OfType<NumericUpDown>().Where(x => x.Name == "nud_PlayMinute").First().Value = minutes;
                    gb.Controls.OfType<NumericUpDown>().Where(x => x.Name == "nud_PlaySecond").First().Value = seconds;
                }
                if (gb.Name == "gb_GCFileNo")
                {
                    if (Main.isGC)
                    {
                        int fileNo = Int32.Parse(Encoding.UTF8.GetString(Main.gcFileBytes).Replace("-", " "));
                        gb.Controls.OfType<NumericUpDown>().Where(x => x.Name == "nud_GCFileNumber").First().Value = fileNo;
                    }
                }
                if (gb.Name == "gb_Languages")
                {
                    gb.Controls.OfType<ComboBox>().Where(x => x.Name == "cb_Text").First().SelectedIndex = textLang;
                    gb.Controls.OfType<ComboBox>().Where(x => x.Name == "cb_Voice").First().SelectedIndex = voiceLang;
                }
                if (gb.Name == "gb_EmblemTime")
                {
                    int hours = emblemTime / 216000;
                    int minutes = (emblemTime - (hours * 216000)) / 3600;
                    int seconds = ((emblemTime - (hours * 216000)) - ((emblemTime - (hours * 21600)) - ((emblemTime - (hours * 21600)) - minutes * 3600))) / 60;
                    gb.Controls.OfType<NumericUpDown>().Where(x => x.Name == "nud_EmblemHour").First().Value = hours;
                    gb.Controls.OfType<NumericUpDown>().Where(x => x.Name == "nud_EmblemMinute").First().Value = minutes;
                    gb.Controls.OfType<NumericUpDown>().Where(x => x.Name == "nud_EmblemSecond").First().Value = seconds;
                }
                if (gb.Name == "gb_ChaoWorldCharacters")
                {
                    gb.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_CWSonic").First().Checked = Convert.ToBoolean(sonicCW);
                    gb.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_CWTails").First().Checked = Convert.ToBoolean(tailsCW);
                    gb.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_CWKnuckles").First().Checked = Convert.ToBoolean(knucklesCW);
                    gb.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_CWShadow").First().Checked = Convert.ToBoolean(shadowCW);
                    gb.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_CWEggman").First().Checked = Convert.ToBoolean(eggmanCW);
                    gb.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_CWRouge").First().Checked = Convert.ToBoolean(rougeCW);
                }
                if (gb.Name == "gb_UnlockedKarts")
                {
                    gb.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_KartSonic").First().Checked = Convert.ToBoolean(kartS);
                    gb.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_KartShadow").First().Checked = Convert.ToBoolean(kartSh);
                    gb.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_KartTails").First().Checked = Convert.ToBoolean(kartT);
                    gb.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_KartEggman").First().Checked = Convert.ToBoolean(kartE);
                    gb.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_KartKnuckles").First().Checked = Convert.ToBoolean(kartK);
                    gb.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_KartRouge").First().Checked = Convert.ToBoolean(kartR);
                }
                if (gb.Name == "gb_UnlockedThemes")
                {
                    gb.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_Amy").First().Checked = Convert.ToBoolean(themeA);
                    gb.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_Maria").First().Checked = Convert.ToBoolean(themeM);
                    gb.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_Secretary").First().Checked = Convert.ToBoolean(themeS);
                    gb.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_Omochao").First().Checked = Convert.ToBoolean(themeO);
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

                    tpSonic.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_SonicLightShoes").First().Checked = Convert.ToBoolean(sonicLS);
                    tpSonic.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_SonicAncientLight").First().Checked = Convert.ToBoolean(sonicAL);
                    tpSonic.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_SonicMagicGloves").First().Checked = Convert.ToBoolean(sonicMG);
                    tpSonic.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_SonicFlameRing").First().Checked = Convert.ToBoolean(sonicFR);
                    tpSonic.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_SonicBounceBracelet").First().Checked = Convert.ToBoolean(sonicBB);
                    tpSonic.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_SonicMysticMelody").First().Checked = Convert.ToBoolean(sonicMM);

                    tpTails.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_TailsBooster").First().Checked = Convert.ToBoolean(tailsBo);
                    tpTails.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_TailsBazooka").First().Checked = Convert.ToBoolean(tailsBa);
                    tpTails.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_TailsLaserBlaster").First().Checked = Convert.ToBoolean(tailsL);
                    tpTails.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_TailsMysticMelody").First().Checked = Convert.ToBoolean(tailsMM);

                    tpKnuckles.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_KnucklesShovelClaw").First().Checked = Convert.ToBoolean(knucklesSC);
                    tpKnuckles.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_KnucklesSunglasses").First().Checked = Convert.ToBoolean(knucklesS);
                    tpKnuckles.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_KnucklesHammerGloves").First().Checked = Convert.ToBoolean(knucklesHG);
                    tpKnuckles.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_KnucklesAirNecklace").First().Checked = Convert.ToBoolean(knucklesAN);
                    tpKnuckles.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_KnucklesMysticMelody").First().Checked = Convert.ToBoolean(knucklesMM);

                    tpShadow.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_ShadowAirShoes").First().Checked = Convert.ToBoolean(shadowAS);
                    tpShadow.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_ShadowAncientLight").First().Checked = Convert.ToBoolean(shadowAL);
                    tpShadow.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_ShadowFlameRing").First().Checked = Convert.ToBoolean(shadowFR);
                    tpShadow.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_ShadowMysticMelody").First().Checked = Convert.ToBoolean(shadowMM);

                    tpEggman.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_EggmanJetEngine").First().Checked = Convert.ToBoolean(eggmanJE);
                    tpEggman.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_EggmanLargeCannon").First().Checked = Convert.ToBoolean(eggmanLC);
                    tpEggman.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_EggmanLaserBlaster").First().Checked = Convert.ToBoolean(eggmanLB);
                    tpEggman.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_EggmanProtectiveArmor").First().Checked = Convert.ToBoolean(eggmanPA);
                    tpEggman.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_EggmanMysticMelody").First().Checked = Convert.ToBoolean(eggmanMM);

                    tpRouge.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_RougePickNails").First().Checked = Convert.ToBoolean(rougePN);
                    tpRouge.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_RougeTreasureScope").First().Checked = Convert.ToBoolean(rougeTS);
                    tpRouge.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_RougeIronBoots").First().Checked = Convert.ToBoolean(rougeIB);
                    tpRouge.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_RougeMysticMelody").First().Checked = Convert.ToBoolean(rougeMM);
                }
            }

            uc_Main ucMain = (uc_Main)Main.tc_Main.Controls[Main.tc_Main.SelectedIndex].Controls[0];

            //Emblems
            foreach (KeyValuePair<string, uint> keyValuePair in offsets.main.MissionOffsets)
            {
                uc_Mission uc = new uc_Mission();
                TabPage tp = new TabPage();
                uc.mainIndex = ucMain.mainIndex;
                uc.currentPair = keyValuePair;
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

                int M1S = 0;
                if (Main.isPC) { M1S = BitConverter.ToInt32(currentMission.Skip(Convert.ToInt32(offsets.mission.M1S)).Take(4).ToArray(), 0); }
                else { M1S = BitConverter.ToInt32(currentMission.Skip(Convert.ToInt32(offsets.mission.M1S)).Take(4).Reverse().ToArray(), 0); }
                int M4S = 0;
                if (Main.isPC) { M4S = BitConverter.ToInt32(currentMission.Skip(Convert.ToInt32(offsets.mission.M4S)).Take(4).ToArray(), 0); }
                else { M4S = BitConverter.ToInt32(currentMission.Skip(Convert.ToInt32(offsets.mission.M4S)).Take(4).Reverse().ToArray(), 0); }
                int M5S = 0;
                if (Main.isPC) { M5S = BitConverter.ToInt32(currentMission.Skip(Convert.ToInt16(offsets.mission.M5S)).Take(4).ToArray(), 0); }
                else { M5S = BitConverter.ToInt32(currentMission.Skip(Convert.ToInt16(offsets.mission.M5S)).Take(4).Reverse().ToArray(), 0); }

                uc.Controls.OfType<ComboBox>().Where(x => x.Name == "cb_1R").First().SelectedIndex = M1;
                uc.Controls.OfType<ComboBox>().Where(x => x.Name == "cb_2R").First().SelectedIndex = M2;
                uc.Controls.OfType<ComboBox>().Where(x => x.Name == "cb_3R").First().SelectedIndex = M3;
                uc.Controls.OfType<ComboBox>().Where(x => x.Name == "cb_4R").First().SelectedIndex = M4;
                uc.Controls.OfType<ComboBox>().Where(x => x.Name == "cb_5R").First().SelectedIndex = M5;

                uc.Controls.OfType<NumericUpDown>().Where(x => x.Name == "nud_1TimeMM").First().Value = M1MM;
                uc.Controls.OfType<NumericUpDown>().Where(x => x.Name == "nud_1TimeSS").First().Value = M1SS;
                uc.Controls.OfType<NumericUpDown>().Where(x => x.Name == "nud_1TimeMS").First().Value = M1MS;
                uc.Controls.OfType<NumericUpDown>().Where(x => x.Name == "nud_2TimeMM").First().Value = M2MM;
                uc.Controls.OfType<NumericUpDown>().Where(x => x.Name == "nud_2TimeSS").First().Value = M2SS;
                uc.Controls.OfType<NumericUpDown>().Where(x => x.Name == "nud_2TimeMS").First().Value = M2MS;
                uc.Controls.OfType<NumericUpDown>().Where(x => x.Name == "nud_3TimeMM").First().Value = M3MM;
                uc.Controls.OfType<NumericUpDown>().Where(x => x.Name == "nud_3TimeSS").First().Value = M3SS;
                uc.Controls.OfType<NumericUpDown>().Where(x => x.Name == "nud_3TimeMS").First().Value = M3MS;
                uc.Controls.OfType<NumericUpDown>().Where(x => x.Name == "nud_4TimeMM").First().Value = M4MM;
                uc.Controls.OfType<NumericUpDown>().Where(x => x.Name == "nud_4TimeSS").First().Value = M4SS;
                uc.Controls.OfType<NumericUpDown>().Where(x => x.Name == "nud_4TimeMS").First().Value = M4MS;
                uc.Controls.OfType<NumericUpDown>().Where(x => x.Name == "nud_5TimeMM").First().Value = M5MM;
                uc.Controls.OfType<NumericUpDown>().Where(x => x.Name == "nud_5TimeSS").First().Value = M5SS;
                uc.Controls.OfType<NumericUpDown>().Where(x => x.Name == "nud_5TimeMS").First().Value = M5MS;

                uc.Controls.OfType<NumericUpDown>().Where(x => x.Name == "nud_1S").First().Value = M1S;
                uc.Controls.OfType<NumericUpDown>().Where(x => x.Name == "nud_4S").First().Value = M4S;
                uc.Controls.OfType<NumericUpDown>().Where(x => x.Name == "nud_5S").First().Value = M5S;

                tp.Controls.Add(uc);
                tp.Text = keyValuePair.Key;
                controls[1].Controls.OfType<TabControl>().First().TabPages.Add(tp);
            }

            //Kart
            foreach (KeyValuePair<string, uint> keyValuePair in offsets.main.KartOffsets)
            {
                uc_Kart uc = new uc_Kart();
                TabPage tp = new TabPage();
                uc.mainIndex = ucMain.mainIndex;
                uc.currentPair = keyValuePair;
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

                uc.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_Emblem").First().Checked = Convert.ToBoolean(E);

                uc.Controls.OfType<ComboBox>().Where(x => x.Name == "cb_1stCharacter").First().SelectedIndex = M1C;
                uc.Controls.OfType<ComboBox>().Where(x => x.Name == "cb_2ndCharacter").First().SelectedIndex = M2C;
                uc.Controls.OfType<ComboBox>().Where(x => x.Name == "cb_3rdCharacter").First().SelectedIndex = M3C;

                uc.Controls.OfType<NumericUpDown>().Where(x => x.Name == "nud_1TimeMM").First().Value = M1MM;
                uc.Controls.OfType<NumericUpDown>().Where(x => x.Name == "nud_1TimeSS").First().Value = M1SS;
                uc.Controls.OfType<NumericUpDown>().Where(x => x.Name == "nud_1TimeMS").First().Value = M1MS;
                uc.Controls.OfType<NumericUpDown>().Where(x => x.Name == "nud_2TimeMM").First().Value = M2MM;
                uc.Controls.OfType<NumericUpDown>().Where(x => x.Name == "nud_2TimeSS").First().Value = M2SS;
                uc.Controls.OfType<NumericUpDown>().Where(x => x.Name == "nud_2TimeMS").First().Value = M2MS;
                uc.Controls.OfType<NumericUpDown>().Where(x => x.Name == "nud_3TimeMM").First().Value = M3MM;
                uc.Controls.OfType<NumericUpDown>().Where(x => x.Name == "nud_3TimeSS").First().Value = M3SS;
                uc.Controls.OfType<NumericUpDown>().Where(x => x.Name == "nud_3TimeMS").First().Value = M3MS;

                tp.Controls.Add(uc);
                tp.Text = keyValuePair.Key;
                controls[1].Controls.OfType<TabControl>().First().TabPages.Add(tp);
            }
            //Boss
            foreach (KeyValuePair<string, KeyValuePair<uint, uint>> keyValuePair in offsets.main.BossOffsets)
            {
                uc_Boss uc = new uc_Boss();
                TabPage tp = new TabPage();
                uc.mainIndex = ucMain.mainIndex;
                uc.currentPair = keyValuePair;
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

                uc.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_Emblem").First().Checked = Convert.ToBoolean(E);

                uc.Controls.OfType<NumericUpDown>().Where(x => x.Name == "nud_1TimeMM").First().Value = M1MM;
                uc.Controls.OfType<NumericUpDown>().Where(x => x.Name == "nud_1TimeSS").First().Value = M1SS;
                uc.Controls.OfType<NumericUpDown>().Where(x => x.Name == "nud_1TimeMS").First().Value = M1MS;
                uc.Controls.OfType<NumericUpDown>().Where(x => x.Name == "nud_2TimeMM").First().Value = M2MM;
                uc.Controls.OfType<NumericUpDown>().Where(x => x.Name == "nud_2TimeSS").First().Value = M2SS;
                uc.Controls.OfType<NumericUpDown>().Where(x => x.Name == "nud_2TimeMS").First().Value = M2MS;
                uc.Controls.OfType<NumericUpDown>().Where(x => x.Name == "nud_3TimeMM").First().Value = M3MM;
                uc.Controls.OfType<NumericUpDown>().Where(x => x.Name == "nud_3TimeSS").First().Value = M3SS;
                uc.Controls.OfType<NumericUpDown>().Where(x => x.Name == "nud_3TimeMS").First().Value = M3MS;

                tp.Controls.Add(uc);
                tp.Text = keyValuePair.Key;
                controls[1].Controls.OfType<TabControl>().First().TabPages.Add(tp);
            }

            //Chao Emblems
            uc_MainChao ucMC = new uc_MainChao();
            TabPage tpMC = new TabPage();
            ucMC.mainIndex = ucMain.mainIndex;
            ucMC.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_RaceBeginner").First().Checked = Convert.ToBoolean(raceB);
            ucMC.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_RaceJewel").First().Checked = Convert.ToBoolean(raceJ);
            ucMC.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_RaceChallenge").First().Checked = Convert.ToBoolean(raceC);
            ucMC.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_RaceHero").First().Checked = Convert.ToBoolean(raceH);
            ucMC.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_RaceDark").First().Checked = Convert.ToBoolean(raceD);
            ucMC.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_KarateBeginner").First().Checked = Convert.ToBoolean(karateB);
            ucMC.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_KarateStandard").First().Checked = Convert.ToBoolean(karateS);
            ucMC.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_KarateExpert").First().Checked = Convert.ToBoolean(karateE);
            ucMC.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_KarateSuper").First().Checked = Convert.ToBoolean(karateSu);
            tpMC.Controls.Add(ucMC);
            tpMC.Text = "Chao";
            controls[1].Controls.OfType<TabControl>().First().TabPages.Add(tpMC);

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
