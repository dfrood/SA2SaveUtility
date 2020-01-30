using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SA2SaveUtility
{
    class ChaoSave
    {
        public static Offsets offsets = new Offsets();
        public static Dictionary<uint, TabPage> activeChao = new Dictionary<uint, TabPage>();

        public static Dictionary<string, int> animalParts = new Dictionary<string, int>()
        {
            {  "None", 255 },
            {  "Penguin", 0 },
            {  "Seal", 1 },
            {  "Otter", 2 },
            {  "Rabbit", 3 },
            {  "Cheetah", 4 },
            {  "Warthog", 5 },
            {  "Bear", 6 },
            {  "Tiger", 7 },
            {  "Gorilla", 8 },
            {  "Peacock", 9 },
            {  "Parrot", 10 },
            {  "Condor", 11 },
            {  "Skunk", 12 },
            {  "Sheep", 13 },
            {  "Raccoon", 14 },
            {  "Half Fish", 15 },
            {  "Skeleton Dog", 16 },
            {  "Bat", 17 },
            {  "Dragon", 18 },
            {  "Unicorn", 19 },
            {  "Phoenix", 20 }
    };

        public static Dictionary<string, int> chaoColours = new Dictionary<string, int>()
        {
            {  "Normal", 0 },
            {  "Yellow", 1 },
            {  "White", 2 },
            {  "Brown", 3 },
            {  "Sky Blue", 4 },
            {  "Pink", 5 },
            {  "Blue", 6 },
            {  "Grey", 7 },
            {  "Green", 8 },
            {  "Red", 9 },
            {  "Lime Green", 10 },
            {  "Purple", 11 },
            {  "Orange", 12 },
            {  "Black", 13 },
            {  "Powder Blue", 21 },
            {  "Deep Dark Blue", 82 },
            {  "Darker Grey", 30 },
            {  "Indian Red (Transparent)", 133 },
            {  "Light Coral (Transparent)", 140 },
            {  "Salmon (Transparent)", 177 },
            {  "Dark Salmon (Transparent)", 237 },
            {  "Crimson (Transparent)", 157 },
            {  "Pink (Transparent)", 203 },
            {  "Light Pink (Transparent)", 217 },
            {  "Hot Pink (Transparent)", 151 },
            {  "Medium Violet Red (Transparent)", 211 },
            {  "Pale Violet Red (Transparent)", 187 },
            {  "Light Violet Red (Transparent)", 213 },
            {  "Violet Red (Transparent)", 226 },
            {  "Pale Goldenrod (Transparent)", 193 },
            {  "Thistle (Transparent)", 247 },
            {  "Plum (Transparent)", 171 },
            {  "Violet (Transparent)", 202 },
            {  "Orchid (Transparent)", 238 },
            {  "Magenta (Transparent)", 248 },
            {  "Medium Orchid (Transparent)", 176 },
            {  "Medium Purple (Transparent)", 165 },
            {  "Blue Violet (Transparent)", 196 },
            {  "Dark Violet (Transparent)", 191 },
            {  "Dark Magenta (Transparent)", 229 },
            {  "Purple (Transparent)", 17 },
            {  "Dark Purple (Transparent)", 145 },
            {  "Dark Slate Blue (Transparent)", 153 },
            {  "Slate Blue (Transparent)", 146 },
            {  "Green Yellow (Transparent)", 224 },
            {  "Lawn Green (Transparent)", 215 },
            {  "Pale Lime Green (Transparent)", 220 },
            {  "Lime Green (Transparent)", 239 },
            {  "Light Pale Green (Transparent)", 189 },
            {  "Pale Green (Transparent)", 205 },
            {  "Light Green (Transparent)", 147 },
            {  "Pale Spring Green (Transparent)", 250 },
            {  "Light Spring Green (Transparent)", 253 },
            {  "Spring Green (Transparent)", 139 },
            {  "Medium Sea Green (Transparent)", 163 },
            {  "Sea Green (Transparent)", 128 },
            {  "Forest Green (Transparent)", 169 },
            {  "Green (Transparent)", 200 },
            {  "Dark Green (Transparent)", 219 },
            {  "Olive Drab (Transparent)", 183 },
            {  "Dark Olive Drab (Transparent)", 231 },
            {  "Dark Olive (Transparent)", 178 },
            {  "Dark Olive Green (Transparent)", 123 },
            {  "Dark Olive Green-Grey (Transparent)", 184 },
            {  "Medium Aquamarine (Transparent)", 223 },
            {  "Pale Turquoise (Transparent)", 143 },
            {  "Pale Aquamarine (Transparent)", 241 },
            {  "Light Aquamarine (Transparent)", 181 },
            {  "Aquamarine (Transparent)", 175 },
            {  "Turquoise (Transparent)", 212 },
            {  "Medium Turquoise (Transparent)", 199 },
            {  "Steel Blue (Transparent)", 235 },
            {  "Powder Blue (Transparent)", 120 },
            {  "Cornflower Blue (Transparent)", 236 },
            {  "Navy Blue (Transparent)", 251 },
            {  "Wheat (Transparent)", 152 },
            {  "Burlywood (Transparent)", 155 },
            {  "Tan (Transparent)", 149 },
            {  "Rosy Brown (Transparent)", 214 },
            {  "Medium Goldenrod (Transparent)", 131 },
            {  "Goldenrod (Transparent)", 190 },
            {  "Dark Goldenrod (Transparent)", 232 },
            {  "Peru (Transparent)", 244 },
            {  "Dark Grey (Transparent)", 127 },
            {  "Invisible 1", 14 },
            {  "Invisible 2", 15 },
            {  "Invisible 3", 16 },
            {  "Invisible 4", 18 },
            {  "Invisible 5", 19 },
            {  "Invisible 6", 20 },
            {  "Invisible 7", 22 },
            {  "Invisible 8", 23 },
            {  "Invisible 9", 24 },
            {  "Invisible 10", 25 },
            {  "Invisible 11", 26 },
            {  "Invisible 12", 27 },
            {  "Invisible 13", 28 },
            {  "Invisible 14", 31 },
            {  "Invisible 15", 32 },
            {  "Invisible 16", 33 },
            {  "Invisible 17", 34 },
            {  "Invisible 18", 35 },
            {  "Invisible 19", 36 },
            {  "Invisible 20", 37 },
            {  "Invisible 21", 38 },
            {  "Invisible 22", 39 },
            {  "Invisible 23", 40 },
            {  "Invisible 24", 41 },
            {  "Invisible 25", 42 },
            {  "Invisible 26", 43 },
            {  "Invisible 27", 44 },
            {  "Invisible 28", 45 },
            {  "Invisible 29", 46 },
            {  "Invisible 30", 47 },
            {  "Invisible 31", 48 },
            {  "Invisible 32", 49 },
            {  "Invisible 33", 50 },
            {  "Invisible 34", 51 },
            {  "Invisible 35", 52 },
            {  "Invisible 36", 53 },
            {  "Invisible 37", 54 },
            {  "Invisible 38", 55 },
            {  "Invisible 39", 56 },
            {  "Invisible 40", 57 },
            {  "Invisible 41", 58 },
            {  "Invisible 42", 59 },
            {  "Invisible 43", 60 },
            {  "Invisible 44", 61 },
            {  "Invisible 45", 62 },
            {  "Invisible 46", 63 },
            {  "Invisible 47", 64 },
            {  "Invisible 48", 65 },
            {  "Invisible 49", 66 },
            {  "Invisible 50", 67 },
            {  "Invisible 51", 68 },
            {  "Invisible 52", 69 },
            {  "Invisible 53", 70 },
            {  "Invisible 54", 71 },
            {  "Invisible 55", 72 },
            {  "Invisible 56", 73 },
            {  "Invisible 57", 74 },
            {  "Invisible 58", 75 },
            {  "Invisible 59", 76 },
            {  "Invisible 60", 77 },
            {  "Invisible 61", 78 },
            {  "Invisible 62", 79 },
            {  "Invisible 63", 80 },
            {  "Invisible 64", 81 },
            {  "Invisible 65", 83 },
            {  "Invisible 66", 84 },
            {  "Invisible 67", 85 },
            {  "Invisible 68", 86 },
            {  "Invisible 69", 87 },
            {  "Invisible 70", 88 },
            {  "Invisible 71", 89 },
            {  "Invisible 72", 90 },
            {  "Invisible 73", 91 },
            {  "Invisible 74", 92 },
            {  "Invisible 75", 93 },
            {  "Invisible 76", 94 },
            {  "Invisible 77", 95 },
            {  "Invisible 78", 96 },
            {  "Invisible 79", 97 },
            {  "Invisible 80", 98 },
            {  "Invisible 81", 99 },
            {  "Invisible 82", 100 },
            {  "Invisible 83", 101 },
            {  "Invisible 84", 102 },
            {  "Invisible 85", 103 },
            {  "Invisible 86", 104 },
            {  "Invisible 87", 105 },
            {  "Invisible 88", 106 },
            {  "Invisible 89", 107 },
            {  "Invisible 90", 108 },
            {  "Invisible 91", 109 },
            {  "Invisible 92", 110 },
            {  "Invisible 93", 111 },
            {  "Invisible 94", 112 },
            {  "Invisible 95", 113 },
            {  "Invisible 96", 114 },
            {  "Invisible 97", 115 },
            {  "Invisible 98", 116 },
            {  "Invisible 99", 117 },
            {  "Invisible 100", 118 },
            {  "Invisible 101", 119 },
            {  "Invisible 102", 121 },
            {  "Invisible 103", 122 },
            {  "Invisible 104", 124 },
            {  "Invisible 105", 125 },
            {  "Invisible 106", 126 },
            {  "Invisible 107", 129 },
            {  "Invisible 108", 130 },
            {  "Invisible 109", 132 },
            {  "Invisible 110", 134 },
            {  "Invisible 111", 135 },
            {  "Invisible 112", 136 },
            {  "Invisible 113", 137 },
            {  "Invisible 114", 138 },
            {  "Invisible 115", 141 },
            {  "Invisible 116", 142 },
            {  "Invisible 117", 144 },
            {  "Invisible 118", 148 },
            {  "Invisible 119", 150 },
            {  "Invisible 120", 154 },
            {  "Invisible 121", 156 },
            {  "Invisible 122", 158 },
            {  "Invisible 123", 159 },
            {  "Invisible 124", 160 },
            {  "Invisible 125", 161 },
            {  "Invisible 126", 162 },
            {  "Invisible 127", 164 },
            {  "Invisible 128", 166 },
            {  "Invisible 129", 167 },
            {  "Invisible 130", 168 },
            {  "Invisible 131", 170 },
            {  "Invisible 132", 172 },
            {  "Invisible 133", 173 },
            {  "Invisible 134", 174 },
            {  "Invisible 135", 179 },
            {  "Invisible 136", 180 },
            {  "Invisible 137", 182 },
            {  "Invisible 138", 185 },
            {  "Invisible 139", 186 },
            {  "Invisible 140", 188 },
            {  "Invisible 141", 192 },
            {  "Invisible 142", 194 },
            {  "Invisible 143", 195 },
            {  "Invisible 144", 197 },
            {  "Invisible 145", 198 },
            {  "Invisible 146", 201 },
            {  "Invisible 147", 204 },
            {  "Invisible 148", 206 },
            {  "Invisible 149", 208 },
            {  "Invisible 150", 209 },
            {  "Invisible 151", 210 },
            {  "Invisible 152", 216 },
            {  "Invisible 153", 218 },
            {  "Invisible 154", 221 },
            {  "Invisible 155", 222 },
            {  "Invisible 156", 225 },
            {  "Invisible 157", 227 },
            {  "Invisible 158", 228 },
            {  "Invisible 159", 230 },
            {  "Invisible 160", 233 },
            {  "Invisible 161", 234 },
            {  "Invisible 162", 240 },
            {  "Invisible 163", 242 },
            {  "Invisible 164", 243 },
            {  "Invisible 165", 245 },
            {  "Invisible 166", 246 },
            {  "Invisible 167", 249 },
            {  "Invisible 168", 252 },
            {  "Invisible 169", 254 },
            {  "Invisible 170", 255 },
            {  "White (UNUSED)", 29 }
    };

        public enum Portals
        {
            Kindergarten = 0x06,
            Hero = 0x10,
            Dark = 0x40
        }
        public enum Toys
        {
            Rattle = 0x01,
            Car = 1 << 1,
            PictureBook = 1 << 2,
            SonicDoll = 1 << 4,
            Broomstick = 1 << 5,
            Glitch = 1 << 6,
            PogoStick = 1 << 7,
            Crayons = 1 << 8,
            BubbleWand = 1 << 9,
            Shovel = 1 << 10,
            WateringCan = 1 << 11
        }

        public enum SAAnimalBehaviours
        {
            Seal = 0x01,
            Penguin = 1 << 1,
            Otter = 1 << 2,
            Peacock = 1 << 3,
            Swallow = 1 << 4,
            Parrot = 1 << 5,
            Deer = 1 << 6,
            Rabbit = 1 << 7,
            Kangaroo = 1 << 8,
            Gorilla = 1 << 9,
            Lion = 1 << 10,
            Elephant = 1 << 11,
            Mole = 1 << 12,
            Koala = 1 << 13,
            Skunk = 1 << 14
        }

        public enum AnimalBehaviours
        {
            Penguin = 0x01,
            Seal = 1 << 1,
            Otter = 1 << 2,
            Rabbit = 1 << 3,
            Cheetah = 1 << 4,
            Warthog = 1 << 5,
            Bear = 1 << 6,
            Tiger = 1 << 7,
            Gorilla = 1 << 8,
            Peacock = 1 << 9,
            Parrot = 1 << 10,
            Condor = 1 << 11,
            Skunk = 1 << 12,
            Sheep = 1 << 13,
            Raccoon = 1 << 14,
            HalfFish = 1 << 15,
            SkeletonDog = 1 << 16,
            Bat = 1 << 17,
            Dragon = 1 << 18,
            Unicorn = 1 << 19,
            Phoenix = 1 << 20
        }

        public enum ClassroomSkills
        {
            Drawing1 = 0x01,
            Drawing2 = 1 << 1,
            Drawing3 = 1 << 2,
            Drawing4 = 1 << 3,
            Drawing5 = 1 << 4,
            Shake = 1 << 8,
            Spin = 1 << 9,
            Step = 1 << 10,
            GoGo = 1 << 11,
            Exercise = 1 << 12,
            Song1 = 1 << 16,
            Song2 = 1 << 17,
            Song3 = 1 << 18,
            Song4 = 1 << 19,
            Song5 = 1 << 20,
            Bell = 1 << 24,
            Castanets = 1 << 25,
            Cymbals = 1 << 26,
            Drum = 1 << 27,
            Flute = 1 << 28,
            Maracas = 1 << 29,
            Trumpet = 1 << 30,
            Tambourine = 1 << 31
        }

        public static void UpdateChaoWorld()
        {
            TabPage currentTab = Main.tc_Main.TabPages[0];
            bool focused = true;
            currentTab.InvokeCheck(() => focused = (Main.tc_Main.SelectedTab == currentTab));

            if (!Main.isRTE || focused)
            {
                Portals portals;
                if (Main.isRTE) { portals = (Portals)Enum.Parse(typeof(Portals), Memory.ReadBytes((int)offsets.chaoSave.GardensRTE, 1)[0].ToString()); }
                else { portals = (Portals)Enum.Parse(typeof(Portals), Main.loadedSave[(int)offsets.chaoSave.Gardens].ToString()); }
                if (!Main.isPC) { portals = (Portals)Enum.Parse(typeof(Portals), Main.loadedSave[(int)offsets.chaoSave.Gardens + 3].ToString()); }

                Control.ControlCollection controls = Main.tc_Main.TabPages[0].Controls;
                foreach (GroupBox gb in controls[0].Controls.OfType<GroupBox>())
                {
                    if (gb.Name == "gb_GardensUnlocked")
                    {
                        CheckBox checkb_DarkGarden = gb.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_DarkGarden").First();
                        CheckBox checkb_HeroGarden = gb.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_HeroGarden").First();

                        checkb_DarkGarden.InvokeCheck(() => checkb_DarkGarden.Checked = (portals & Portals.Dark) == Portals.Dark);
                        checkb_HeroGarden.InvokeCheck(() => checkb_HeroGarden.Checked = (portals & Portals.Hero) == Portals.Hero);
                    }
                }
            }
        }


        public static void UpdateChaoRTE(TabControl tc, byte[] chaoData)
        {
            uc_ChaoSave ucChaoSave = new uc_ChaoSave();
            TabPage tpChaoSave = new TabPage();
            tpChaoSave.Controls.Add(ucChaoSave);
            tpChaoSave.Text = "Chao World";
            if (Main.tc_Main.TabPages[0].Text != "Chao World") { Main.tc_Main.InvokeCheck(() => Main.tc_Main.TabPages.Insert(0, tpChaoSave)); }

            int index = 0;
            foreach (byte[] chao in Main.SplitByteArray(chaoData, 0x800))
            {
                UpdateChao(tc, activeChao.Where(x => x.Key == index).First(), chao);
                index++;
            }
            UpdateChaoWorld();
        }

        public static void UpdateChao(TabControl tc, KeyValuePair<uint, TabPage> currentChao, byte[] chao)
        {
            Control.ControlCollection controls = tc.TabPages[tc.TabPages.IndexOf(currentChao.Value)].Controls[0].Controls[0].Controls;
            TabPage currentTab = tc.TabPages[tc.TabPages.IndexOf(currentChao.Value)];
            bool focused = true;
            currentTab.InvokeCheck(() => focused = (Main.tc_Main.SelectedTab == currentTab));

            byte[] nameBytes = chao.Skip(Convert.ToInt32(offsets.chao.Name)).Take(7).ToArray();
            string name = GetName(nameBytes);
            TextBox tb_Name = controls[0].Controls.OfType<TextBox>().Where(x => x.Name == "tb_Name").First();
            tb_Name.InvokeCheck(() => tb_Name.Text(name));

            if ((int)chao[offsets.chao.ChaoType] == 0)
            {
                foreach (Control ctl in currentTab.Controls) ctl.InvokeCheck(() => ctl.Enabled = false);
                foreach (Control ctl in currentTab.Controls) ctl.InvokeCheck(() => ctl.Visible = false);
                if (currentTab.Text != "Empty Slot")
                {
                    currentTab.InvokeCheck(() => currentTab.Text = "Empty Slot");
                }
            }
            else
            {
                foreach (Control ctl in currentTab.Controls) ctl.InvokeCheck(() => ctl.Enabled = true);
                foreach (Control ctl in currentTab.Controls) ctl.InvokeCheck(() => ctl.Visible = true);
                if (currentTab.Text != name)
                {
                    currentTab.InvokeCheck(() => currentTab.Text = name);
                }
            }

            if (focused || !Main.rteUpdates)
            {
                int garden = (int)(chao[offsets.chao.Garden]);
                int happiness = 0;
                if (Main.isPC) { happiness = BitConverter.ToInt16(chao.Skip(Convert.ToInt16(offsets.chao.Happiness)).Take(2).ToArray(), 0); }
                else { happiness = BitConverter.ToInt16(chao.Skip(Convert.ToInt16(offsets.chao.Happiness)).Take(2).Reverse().ToArray(), 0); }
                int lifespan1 = 0;
                if (Main.isPC) { lifespan1 = BitConverter.ToInt16(chao.Skip(Convert.ToInt16(offsets.chao.Lifespan1)).Take(2).ToArray(), 0); }
                else { lifespan1 = BitConverter.ToInt16(chao.Skip(Convert.ToInt16(offsets.chao.Lifespan1)).Take(2).Reverse().ToArray(), 0); }
                int lifespan2 = 0;
                if (Main.isPC) { lifespan2 = BitConverter.ToInt16(chao.Skip(Convert.ToInt16(offsets.chao.Lifespan2)).Take(2).ToArray(), 0); }
                else { lifespan2 = BitConverter.ToInt16(chao.Skip(Convert.ToInt16(offsets.chao.Lifespan2)).Take(2).Reverse().ToArray(), 0); }
                uint reincarnations = 0;
                if (Main.isPC) { reincarnations = BitConverter.ToUInt16(chao.Skip(Convert.ToUInt16(offsets.chao.Reincarnations)).Take(2).ToArray(), 0); }
                else { reincarnations = BitConverter.ToUInt16(chao.Skip(Convert.ToUInt16(offsets.chao.Reincarnations)).Take(2).Reverse().ToArray(), 0); }
                Toys toys = 0;
                if (!Main.isSA)
                {
                    if (Main.isPC) { toys = (Toys)Enum.Parse(typeof(Toys), BitConverter.ToUInt32(chao.Skip(Convert.ToInt32(offsets.chao.SA2Toys)).Take(4).ToArray(), 0).ToString()); }
                    else { toys = (Toys)Enum.Parse(typeof(Toys), BitConverter.ToUInt32(chao.Skip(Convert.ToInt32(offsets.chao.SA2Toys)).Take(4).Reverse().ToArray(), 0).ToString()); }
                }
                SAAnimalBehaviours saAnimalBehaviours = 0;
                if (Main.isPC) { saAnimalBehaviours = (SAAnimalBehaviours)Enum.Parse(typeof(SAAnimalBehaviours), BitConverter.ToUInt32(chao.Skip(Convert.ToInt32(offsets.chao.SAAnimalBehaviours)).Take(4).ToArray(), 0).ToString()); }
                else { saAnimalBehaviours = (SAAnimalBehaviours)Enum.Parse(typeof(SAAnimalBehaviours), BitConverter.ToUInt32(chao.Skip(Convert.ToInt32(offsets.chao.SAAnimalBehaviours)).Take(4).Reverse().ToArray(), 0).ToString()); }
                AnimalBehaviours animalBehaviours = 0;
                if (Main.isPC) { animalBehaviours = (AnimalBehaviours)Enum.Parse(typeof(AnimalBehaviours), BitConverter.ToUInt32(chao.Skip(Convert.ToInt32(offsets.chao.SA2AnimalBehaviours)).Take(4).ToArray(), 0).ToString()); }
                else { animalBehaviours = (AnimalBehaviours)Enum.Parse(typeof(AnimalBehaviours), BitConverter.ToUInt32(chao.Skip(Convert.ToInt32(offsets.chao.SA2AnimalBehaviours)).Take(4).Reverse().ToArray(), 0).ToString()); }
                ClassroomSkills classroomSkills = 0;
                classroomSkills = (ClassroomSkills)Enum.Parse(typeof(ClassroomSkills), BitConverter.ToInt32(chao.Skip(Convert.ToInt32(offsets.chao.SA2ClassroomSkills)).Take(4).ToArray(), 0).ToString());

                int swimLevel = (int)chao[offsets.chao.SwimLevel];
                int flyLevel = (int)chao[offsets.chao.FlyLevel];
                int runLevel = (int)chao[offsets.chao.RunLevel];
                int powerLevel = (int)chao[offsets.chao.PowerLevel];
                int staminaLevel = (int)chao[offsets.chao.StaminaLevel];
                int luckLevel = (int)chao[offsets.chao.LuckLevel];
                int intelligenceLevel = (int)chao[offsets.chao.IntelligenceLevel];

                int swimBar = (int)chao[offsets.chao.SwimBar];
                int flyBar = (int)chao[offsets.chao.FlyBar];
                int runBar = (int)chao[offsets.chao.RunBar];
                int powerBar = (int)chao[offsets.chao.PowerBar];
                int staminaBar = (int)chao[offsets.chao.StaminaBar];
                int luckBar = (int)chao[offsets.chao.LuckBar];
                int intelligenceBar = (int)chao[offsets.chao.IntelligenceBar];

                uint swimPoints = 0;
                if (Main.isPC) { swimPoints = BitConverter.ToUInt16(chao.Skip(Convert.ToUInt16(offsets.chao.SwimPoints)).Take(2).ToArray(), 0); }
                else { swimPoints = BitConverter.ToUInt16(chao.Skip(Convert.ToUInt16(offsets.chao.SwimPoints)).Take(2).Reverse().ToArray(), 0); }
                uint flyPoints = 0;
                if (Main.isPC) { flyPoints = BitConverter.ToUInt16(chao.Skip(Convert.ToUInt16(offsets.chao.FlyPoints)).Take(2).ToArray(), 0); }
                else { flyPoints = BitConverter.ToUInt16(chao.Skip(Convert.ToUInt16(offsets.chao.FlyPoints)).Take(2).Reverse().ToArray(), 0); }
                uint runPoints = 0;
                if (Main.isPC) { runPoints = BitConverter.ToUInt16(chao.Skip(Convert.ToUInt16(offsets.chao.RunPoints)).Take(2).ToArray(), 0); }
                else { runPoints = BitConverter.ToUInt16(chao.Skip(Convert.ToUInt16(offsets.chao.RunPoints)).Take(2).Reverse().ToArray(), 0); }
                uint powerPoints = 0;
                if (Main.isPC) { powerPoints = BitConverter.ToUInt16(chao.Skip(Convert.ToUInt16(offsets.chao.PowerPoints)).Take(2).ToArray(), 0); }
                else { powerPoints = BitConverter.ToUInt16(chao.Skip(Convert.ToUInt16(offsets.chao.PowerPoints)).Take(2).Reverse().ToArray(), 0); }
                uint staminaPoints = 0;
                if (Main.isPC) { staminaPoints = BitConverter.ToUInt16(chao.Skip(Convert.ToUInt16(offsets.chao.StaminaPoints)).Take(2).ToArray(), 0); }
                else { staminaPoints = BitConverter.ToUInt16(chao.Skip(Convert.ToUInt16(offsets.chao.StaminaPoints)).Take(2).Reverse().ToArray(), 0); }
                uint luckPoints = 0;
                if (Main.isPC) { luckPoints = BitConverter.ToUInt16(chao.Skip(Convert.ToUInt16(offsets.chao.LuckPoints)).Take(2).ToArray(), 0); }
                else { luckPoints = BitConverter.ToUInt16(chao.Skip(Convert.ToUInt16(offsets.chao.LuckPoints)).Take(2).Reverse().ToArray(), 0); }
                uint intelligencePoints = 0;
                if (Main.isPC) { intelligencePoints = BitConverter.ToUInt16(chao.Skip(Convert.ToUInt16(offsets.chao.IntelligencePoints)).Take(2).ToArray(), 0); }
                else { intelligencePoints = BitConverter.ToUInt16(chao.Skip(Convert.ToUInt16(offsets.chao.IntelligencePoints)).Take(2).Reverse().ToArray(), 0); }

                int swimGrade = (int)chao[offsets.chao.SwimGrade];
                int flyGrade = (int)chao[offsets.chao.FlyGrade];
                int runGrade = (int)chao[offsets.chao.RunGrade];
                if (runGrade == 7) { runGrade = 6; }
                int powerGrade = (int)chao[offsets.chao.PowerGrade];
                int staminaGrade = (int)chao[offsets.chao.StaminaGrade];
                int luckGrade = (int)chao[offsets.chao.LuckGrade];
                int intelligenceGrade = (int)chao[offsets.chao.IntelligenceGrade];

                int colour = (int)chao[offsets.chao.Colour];
                int texture = (int)chao[offsets.chao.Texture];
                int bodyType = (int)chao[offsets.chao.BodyType];
                int shiny = (int)chao[offsets.chao.Shiny];
                int monoTone = (int)chao[offsets.chao.MonoTone];
                int hat = (int)chao[offsets.chao.Hat];
                int medal = (int)chao[offsets.chao.Medal];
                int bodyTypeAnimal = (int)chao[offsets.chao.BodyTypeAnimal];
                int eyes = (int)chao[offsets.chao.Eyes];
                int emotiball = (int)chao[offsets.chao.Emotiball];
                int mouth = (int)chao[offsets.chao.Mouth];
                int feetHidden = (int)chao[offsets.chao.HiddenFeet];
                int armsPart = (int)chao[offsets.chao.SA2ArmsPart];
                int earsPart = (int)chao[offsets.chao.SA2EarsPart];
                int foreheadPart = (int)chao[offsets.chao.SA2ForeheadPart];
                int hornsPart = (int)chao[offsets.chao.SA2HornsPart];
                int legsPart = (int)chao[offsets.chao.SA2LegsPart];
                int tailPart = (int)chao[offsets.chao.SA2TailPart];
                int wingsPart = (int)chao[offsets.chao.SA2WingsPart];
                int facePart = (int)chao[offsets.chao.SA2FacePart];
                int eggColour = (int)chao[offsets.chao.EggColour];

                int chaoType = (int)chao[offsets.chao.ChaoType];
                if (chaoType < 3) { chaoType -= 1; }
                if (chaoType > 2) { chaoType -= 3; }
                float alignment = 0;
                if (Main.isPC) { alignment = BitConverter.ToSingle(chao.Skip(Convert.ToInt32(offsets.chao.Alignment)).Take(4).ToArray(), 0); }
                else { alignment = BitConverter.ToSingle(chao.Skip(Convert.ToInt32(offsets.chao.Alignment)).Take(4).Reverse().ToArray(), 0); }
                float run2Power = 0;
                if (Main.isPC) { run2Power = BitConverter.ToSingle(chao.Skip(Convert.ToInt32(offsets.chao.Run2PowerTranformation)).Take(4).ToArray(), 0); }
                else { run2Power = BitConverter.ToSingle(chao.Skip(Convert.ToInt32(offsets.chao.Run2PowerTranformation)).Take(4).Reverse().ToArray(), 0); }
                float swim2Fly = 0;
                if (Main.isPC) { swim2Fly = BitConverter.ToSingle(chao.Skip(Convert.ToInt32(offsets.chao.Swim2FlyTransformation)).Take(4).ToArray(), 0); }
                else { swim2Fly = BitConverter.ToSingle(chao.Skip(Convert.ToInt32(offsets.chao.Swim2FlyTransformation)).Take(4).Reverse().ToArray(), 0); }
                float transformationMagnitude = 0;
                if (Main.isPC) { transformationMagnitude = BitConverter.ToSingle(chao.Skip(Convert.ToInt32(offsets.chao.TransformationMagnitude)).Take(4).ToArray(), 0); }
                else { transformationMagnitude = BitConverter.ToSingle(chao.Skip(Convert.ToInt32(offsets.chao.TransformationMagnitude)).Take(4).Reverse().ToArray(), 0); }


                int desireToMate = 0;
                if (Main.isPC) { desireToMate = BitConverter.ToInt16(chao.Skip(Convert.ToInt16(offsets.chao.DesireToMate)).Take(2).ToArray(), 0); }
                else { desireToMate = BitConverter.ToInt16(chao.Skip(Convert.ToInt16(offsets.chao.DesireToMate)).Take(2).Reverse().ToArray(), 0); }
                int hunger = 0;
                if (Main.isPC) { hunger = BitConverter.ToInt16(chao.Skip(Convert.ToInt16(offsets.chao.Hunger)).Take(2).ToArray(), 0); }
                else { hunger = BitConverter.ToInt16(chao.Skip(Convert.ToInt16(offsets.chao.Hunger)).Take(2).Reverse().ToArray(), 0); }
                int sleepiness = 0;
                if (Main.isPC) { sleepiness = BitConverter.ToInt16(chao.Skip(Convert.ToInt16(offsets.chao.Sleepiness)).Take(2).ToArray(), 0); }
                else { sleepiness = BitConverter.ToInt16(chao.Skip(Convert.ToInt16(offsets.chao.Sleepiness)).Take(2).Reverse().ToArray(), 0); }
                int tiredness = 0;
                if (Main.isPC) { tiredness = BitConverter.ToInt16(chao.Skip(Convert.ToInt16(offsets.chao.Tiredness)).Take(2).ToArray(), 0); }
                else { tiredness = BitConverter.ToInt16(chao.Skip(Convert.ToInt16(offsets.chao.Tiredness)).Take(2).Reverse().ToArray(), 0); }
                int boredom = 0;
                if (Main.isPC) { boredom = BitConverter.ToInt16(chao.Skip(Convert.ToInt16(offsets.chao.Boredom)).Take(2).ToArray(), 0); }
                else { boredom = BitConverter.ToInt16(chao.Skip(Convert.ToInt16(offsets.chao.Boredom)).Take(2).Reverse().ToArray(), 0); }
                int energy = 0;
                if (Main.isPC) { energy = BitConverter.ToInt16(chao.Skip(Convert.ToInt16(offsets.chao.Energy)).Take(2).ToArray(), 0); }
                else { energy = BitConverter.ToInt16(chao.Skip(Convert.ToInt16(offsets.chao.Energy)).Take(2).Reverse().ToArray(), 0); }
                int joy = (int)chao[offsets.chao.Joy];
                int urgeToCry = (int)chao[offsets.chao.UrgeToCry];
                int fear = (int)chao[offsets.chao.Fear];
                int dizziness = (int)chao[offsets.chao.Dizziness];

                int sonicBond = (sbyte)chao[offsets.chao.SA2SonicBond];
                int tailsBond = (sbyte)chao[offsets.chao.SA2TailsBond];
                int knucklesBond = (sbyte)chao[offsets.chao.SA2KnucklesBond];
                int shadowBond = (sbyte)chao[offsets.chao.SA2ShadowBond];
                int eggmanBond = (sbyte)chao[offsets.chao.SA2EggmanBond];
                int rougeBond = (sbyte)chao[offsets.chao.SA2RougeBond];

                int normal2Curious = (sbyte)chao[offsets.chao.Normal2Curious];
                int cryBaby2Energetic = (sbyte)chao[offsets.chao.CryBaby2Energetic];
                int naive2Normal = (sbyte)chao[offsets.chao.Naive2Normal];
                int normal2BigEater = (sbyte)chao[offsets.chao.Normal2BigEater];
                int normal2Carefree = (sbyte)chao[offsets.chao.Normal2Carefree];
                int favouriteFruit = (byte)chao[offsets.chao.FavouriteFruit];

                sbyte cough = (sbyte)chao[offsets.chao.Cough];
                sbyte cold = (sbyte)chao[offsets.chao.Cold];
                sbyte rash = (sbyte)chao[offsets.chao.Rash];
                sbyte runnyNose = (sbyte)chao[offsets.chao.RunnyNose];
                sbyte hiccups = (sbyte)chao[offsets.chao.Hiccups];
                sbyte stomachAche = (sbyte)chao[offsets.chao.StomachAche];


                int swimDNAGrade1 = (int)chao[offsets.chao.DNASwimGrade1];
                int flyDNAGrade1 = (int)chao[offsets.chao.DNAFlyGrade1];
                int runDNAGrade1 = (int)chao[offsets.chao.DNARunGrade1];
                if (runDNAGrade1 == 7) { runDNAGrade1 = 6; }
                int powerDNAGrade1 = (int)chao[offsets.chao.DNAPowerGrade1];
                int staminaDNAGrade1 = (int)chao[offsets.chao.DNAStaminaGrade1];
                int luckDNAGrade1 = (int)chao[offsets.chao.DNALuckGrade1];
                int intelligenceDNAGrade1 = (int)chao[offsets.chao.DNAIntelligenceGrade1];
                int swimDNAGrade2 = (int)chao[offsets.chao.DNASwimGrade2];
                int flyDNAGrade2 = (int)chao[offsets.chao.DNAFlyGrade2];
                int runDNAGrade2 = (int)chao[offsets.chao.DNARunGrade2];
                if (runDNAGrade2 == 7) { runDNAGrade2 = 6; }
                int powerDNAGrade2 = (int)chao[offsets.chao.DNAPowerGrade2];
                int staminaDNAGrade2 = (int)chao[offsets.chao.DNAStaminaGrade2];
                int luckDNAGrade2 = (int)chao[offsets.chao.DNALuckGrade2];
                int intelligenceDNAGrade2 = (int)chao[offsets.chao.DNAIntelligenceGrade2];
                int fruit1 = (byte)chao[offsets.chao.DNAFavouriteFruit1];
                int fruit2 = (byte)chao[offsets.chao.DNAFavouriteFruit2];
                int colour1 = (byte)chao[offsets.chao.DNAColour1];
                int colour2 = (byte)chao[offsets.chao.DNAColour2];
                int eggColour1 = (byte)chao[offsets.chao.DNAEggColour1];
                int eggColour2 = (byte)chao[offsets.chao.DNAEggColour2];
                int texture1 = (byte)chao[offsets.chao.DNATexture1];
                int texture2 = (byte)chao[offsets.chao.DNATexture2];
                int shiny1 = (int)chao[offsets.chao.DNAShiny1];
                int shiny2 = (int)chao[offsets.chao.DNAShiny2];
                int monoTone1 = (int)chao[offsets.chao.DNAMonoTone1];
                int monoTone2 = (int)chao[offsets.chao.DNAMonoTone2];

                //General
                ComboBox cb_Garden = controls[0].Controls.OfType<ComboBox>().Where(x => x.Name == "cb_Garden").First();
                NumericUpDown nud_Happiness = controls[0].Controls.OfType<NumericUpDown>().Where(x => x.Name == "nud_Happiness").First();
                NumericUpDown nud_Reincarnations = controls[0].Controls.OfType<NumericUpDown>().Where(x => x.Name == "nud_Reincarnations").First();
                GroupBox gb_Toys = controls[0].Controls.OfType<GroupBox>().Where(x => x.Name == "gb_Toys").First();
                CheckBox checkb_Rattle = gb_Toys.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_Rattle").First();
                CheckBox checkb_Car = gb_Toys.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_Car").First();
                CheckBox checkb_PictureBook = gb_Toys.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_PictureBook").First();
                CheckBox checkb_SonicDoll = gb_Toys.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_SonicDoll").First();
                CheckBox checkb_Broomstick = gb_Toys.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_Broomstick").First();
                CheckBox checkb_Glitch = gb_Toys.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_Glitch").First();
                CheckBox checkb_PogoStick = gb_Toys.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_PogoStick").First();
                CheckBox checkb_Crayons = gb_Toys.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_Crayons").First();
                CheckBox checkb_BubbleWand = gb_Toys.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_BubbleWand").First();
                CheckBox checkb_Shovel = gb_Toys.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_Shovel").First();
                CheckBox checkb_WateringCan = gb_Toys.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_WateringCan").First();
                TabControl tc_AnimalBehaviours = controls[0].Controls.OfType<TabControl>().Where(x => x.Name == "tc_AnimalBehaviours").First();
                TabPage tp_SAAnimalBehaviours = tc_AnimalBehaviours.TabPages[tc_AnimalBehaviours.TabPages.IndexOfKey("tp_SAAnimalBehaviours")];
                CheckBox checkb_SASeal = tp_SAAnimalBehaviours.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_SASeal").First();
                CheckBox checkb_SAPenguin = tp_SAAnimalBehaviours.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_SAPenguin").First();
                CheckBox checkb_SAOtter = tp_SAAnimalBehaviours.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_SAOtter").First();
                CheckBox checkb_SAPeacock = tp_SAAnimalBehaviours.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_SAPeacock").First();
                CheckBox checkb_SASwallow = tp_SAAnimalBehaviours.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_SASwallow").First();
                CheckBox checkb_SAParrot = tp_SAAnimalBehaviours.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_SAParrot").First();
                CheckBox checkb_SADeer = tp_SAAnimalBehaviours.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_SADeer").First();
                CheckBox checkb_SARabbit = tp_SAAnimalBehaviours.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_SARabbit").First();
                CheckBox checkb_SAKangaroo = tp_SAAnimalBehaviours.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_SAKangaroo").First();
                CheckBox checkb_SAGorilla = tp_SAAnimalBehaviours.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_SAGorilla").First();
                CheckBox checkb_SALion = tp_SAAnimalBehaviours.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_SALion").First();
                CheckBox checkb_SAElephant = tp_SAAnimalBehaviours.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_SAElephant").First();
                CheckBox checkb_SAMole = tp_SAAnimalBehaviours.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_SAMole").First();
                CheckBox checkb_SAKoala = tp_SAAnimalBehaviours.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_SAKoala").First();
                CheckBox checkb_SASkunk = tp_SAAnimalBehaviours.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_SASkunk").First();
                TabPage tp_SA2AnimalBehaviours = tc_AnimalBehaviours.TabPages[tc_AnimalBehaviours.TabPages.IndexOfKey("tp_SA2AnimalBehaviours")];
                CheckBox checkb_Penguin = tp_SA2AnimalBehaviours.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_Penguin").First();
                CheckBox checkb_Seal = tp_SA2AnimalBehaviours.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_Seal").First();
                CheckBox checkb_Otter = tp_SA2AnimalBehaviours.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_Otter").First();
                CheckBox checkb_Rabbit = tp_SA2AnimalBehaviours.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_Rabbit").First();
                CheckBox checkb_Cheetah = tp_SA2AnimalBehaviours.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_Cheetah").First();
                CheckBox checkb_Warthog = tp_SA2AnimalBehaviours.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_Warthog").First();
                CheckBox checkb_Bear = tp_SA2AnimalBehaviours.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_Bear").First();
                CheckBox checkb_Tiger = tp_SA2AnimalBehaviours.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_Tiger").First();
                CheckBox checkb_Gorilla = tp_SA2AnimalBehaviours.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_Gorilla").First();
                CheckBox checkb_Peacock = tp_SA2AnimalBehaviours.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_Peacock").First();
                CheckBox checkb_Parrot = tp_SA2AnimalBehaviours.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_Parrot").First();
                CheckBox checkb_Condor = tp_SA2AnimalBehaviours.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_Condor").First();
                CheckBox checkb_Skunk = tp_SA2AnimalBehaviours.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_Skunk").First();
                CheckBox checkb_Sheep = tp_SA2AnimalBehaviours.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_Sheep").First();
                CheckBox checkb_Raccoon = tp_SA2AnimalBehaviours.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_Raccoon").First();
                CheckBox checkb_HalfFish = tp_SA2AnimalBehaviours.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_HalfFish").First();
                CheckBox checkb_SkeletonDog = tp_SA2AnimalBehaviours.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_SkeletonDog").First();
                CheckBox checkb_Bat = tp_SA2AnimalBehaviours.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_Bat").First();
                CheckBox checkb_Dragon = tp_SA2AnimalBehaviours.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_Dragon").First();
                CheckBox checkb_Unicorn = tp_SA2AnimalBehaviours.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_Unicorn").First();
                CheckBox checkb_Phoenix = tp_SA2AnimalBehaviours.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_Phoenix").First();
                GroupBox gb_ClassroomSkills = controls[0].Controls.OfType<GroupBox>().Where(x => x.Name == "gb_ClassroomSkills").First();
                CheckBox checkb_Drawing1 = gb_ClassroomSkills.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_Drawing1").First();
                CheckBox checkb_Drawing2 = gb_ClassroomSkills.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_Drawing2").First();
                CheckBox checkb_Drawing3 = gb_ClassroomSkills.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_Drawing3").First();
                CheckBox checkb_Drawing4 = gb_ClassroomSkills.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_Drawing4").First();
                CheckBox checkb_Drawing5 = gb_ClassroomSkills.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_Drawing5").First();
                CheckBox checkb_ShakeDance = gb_ClassroomSkills.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_ShakeDance").First();
                CheckBox checkb_SpinDance = gb_ClassroomSkills.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_SpinDance").First();
                CheckBox checkb_StepDance = gb_ClassroomSkills.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_StepDance").First();
                CheckBox checkb_GoGoDance = gb_ClassroomSkills.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_GoGoDance").First();
                CheckBox checkb_Exercise = gb_ClassroomSkills.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_Exercise").First();
                CheckBox checkb_Drum = gb_ClassroomSkills.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_Drum").First();
                CheckBox checkb_Song1 = gb_ClassroomSkills.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_Song1").First();
                CheckBox checkb_Song2 = gb_ClassroomSkills.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_Song2").First();
                CheckBox checkb_Song3 = gb_ClassroomSkills.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_Song3").First();
                CheckBox checkb_Song4 = gb_ClassroomSkills.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_Song4").First();
                CheckBox checkb_Song5 = gb_ClassroomSkills.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_Song5").First();
                CheckBox checkb_Bell = gb_ClassroomSkills.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_Bell").First();
                CheckBox checkb_Castanets = gb_ClassroomSkills.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_Castanets").First();
                CheckBox checkb_Cymbals = gb_ClassroomSkills.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_Cymbals").First();
                CheckBox checkb_Flute = gb_ClassroomSkills.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_Flute").First();
                CheckBox checkb_Maracas = gb_ClassroomSkills.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_Maracas").First();
                CheckBox checkb_Trumpet = gb_ClassroomSkills.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_Trumpet").First();
                CheckBox checkb_Tambourine = gb_ClassroomSkills.Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_Tambourine").First();

                if (garden != 255) { cb_Garden.InvokeCheck(() => cb_Garden.SelectedIndex(garden - 1)); }
                nud_Happiness.InvokeCheck(() => nud_Happiness.Value(happiness));
                nud_Reincarnations.InvokeCheck(() => nud_Reincarnations.Value((int)reincarnations));
                checkb_Rattle.InvokeCheck(() => checkb_Rattle.Checked((toys & Toys.Rattle) == Toys.Rattle));
                checkb_Car.InvokeCheck(() => checkb_Car.Checked((toys & Toys.Car) == Toys.Car));
                checkb_PictureBook.InvokeCheck(() => checkb_PictureBook.Checked((toys & Toys.PictureBook) == Toys.PictureBook));
                checkb_SonicDoll.InvokeCheck(() => checkb_SonicDoll.Checked((toys & Toys.SonicDoll) == Toys.SonicDoll));
                checkb_Broomstick.InvokeCheck(() => checkb_Broomstick.Checked((toys & Toys.Broomstick) == Toys.Broomstick));
                checkb_Glitch.InvokeCheck(() => checkb_Glitch.Checked((toys & Toys.Glitch) == Toys.Glitch));
                checkb_PogoStick.InvokeCheck(() => checkb_PogoStick.Checked((toys & Toys.PogoStick) == Toys.PogoStick));
                checkb_Crayons.InvokeCheck(() => checkb_Crayons.Checked((toys & Toys.Crayons) == Toys.Crayons));
                checkb_BubbleWand.InvokeCheck(() => checkb_BubbleWand.Checked((toys & Toys.BubbleWand) == Toys.BubbleWand));
                checkb_Shovel.InvokeCheck(() => checkb_Shovel.Checked((toys & Toys.Shovel) == Toys.Shovel));
                checkb_WateringCan.InvokeCheck(() => checkb_WateringCan.Checked((toys & Toys.WateringCan) == Toys.WateringCan));
                checkb_SASeal.InvokeCheck(() => checkb_SASeal.Checked((saAnimalBehaviours & SAAnimalBehaviours.Seal) == SAAnimalBehaviours.Seal));
                checkb_SAPenguin.InvokeCheck(() => checkb_SAPenguin.Checked((saAnimalBehaviours & SAAnimalBehaviours.Penguin) == SAAnimalBehaviours.Penguin));
                checkb_SAOtter.InvokeCheck(() => checkb_SAOtter.Checked((saAnimalBehaviours & SAAnimalBehaviours.Otter) == SAAnimalBehaviours.Otter));
                checkb_SAPeacock.InvokeCheck(() => checkb_SAPeacock.Checked((saAnimalBehaviours & SAAnimalBehaviours.Peacock) == SAAnimalBehaviours.Peacock));
                checkb_SASwallow.InvokeCheck(() => checkb_SASwallow.Checked((saAnimalBehaviours & SAAnimalBehaviours.Swallow) == SAAnimalBehaviours.Swallow));
                checkb_SAParrot.InvokeCheck(() => checkb_SAParrot.Checked((saAnimalBehaviours & SAAnimalBehaviours.Parrot) == SAAnimalBehaviours.Parrot));
                checkb_SADeer.InvokeCheck(() => checkb_SADeer.Checked((saAnimalBehaviours & SAAnimalBehaviours.Deer) == SAAnimalBehaviours.Deer));
                checkb_SARabbit.InvokeCheck(() => checkb_SARabbit.Checked((saAnimalBehaviours & SAAnimalBehaviours.Rabbit) == SAAnimalBehaviours.Rabbit));
                checkb_SAKangaroo.InvokeCheck(() => checkb_SAKangaroo.Checked((saAnimalBehaviours & SAAnimalBehaviours.Kangaroo) == SAAnimalBehaviours.Kangaroo));
                checkb_SAGorilla.InvokeCheck(() => checkb_SAGorilla.Checked((saAnimalBehaviours & SAAnimalBehaviours.Gorilla) == SAAnimalBehaviours.Gorilla));
                checkb_SALion.InvokeCheck(() => checkb_SALion.Checked((saAnimalBehaviours & SAAnimalBehaviours.Lion) == SAAnimalBehaviours.Lion));
                checkb_SAElephant.InvokeCheck(() => checkb_SAElephant.Checked((saAnimalBehaviours & SAAnimalBehaviours.Elephant) == SAAnimalBehaviours.Elephant));
                checkb_SAMole.InvokeCheck(() => checkb_SAMole.Checked((saAnimalBehaviours & SAAnimalBehaviours.Mole) == SAAnimalBehaviours.Mole));
                checkb_SAKoala.InvokeCheck(() => checkb_SAKoala.Checked((saAnimalBehaviours & SAAnimalBehaviours.Koala) == SAAnimalBehaviours.Koala));
                checkb_SASkunk.InvokeCheck(() => checkb_SASkunk.Checked((saAnimalBehaviours & SAAnimalBehaviours.Skunk) == SAAnimalBehaviours.Skunk));
                checkb_Penguin.InvokeCheck(() => checkb_Penguin.Checked((animalBehaviours & AnimalBehaviours.Penguin) == AnimalBehaviours.Penguin));
                checkb_Seal.InvokeCheck(() => checkb_Seal.Checked((animalBehaviours & AnimalBehaviours.Seal) == AnimalBehaviours.Seal));
                checkb_Otter.InvokeCheck(() => checkb_Otter.Checked((animalBehaviours & AnimalBehaviours.Otter) == AnimalBehaviours.Otter));
                checkb_Rabbit.InvokeCheck(() => checkb_Rabbit.Checked((animalBehaviours & AnimalBehaviours.Rabbit) == AnimalBehaviours.Rabbit));
                checkb_Cheetah.InvokeCheck(() => checkb_Cheetah.Checked((animalBehaviours & AnimalBehaviours.Cheetah) == AnimalBehaviours.Cheetah));
                checkb_Warthog.InvokeCheck(() => checkb_Warthog.Checked((animalBehaviours & AnimalBehaviours.Warthog) == AnimalBehaviours.Warthog));
                checkb_Bear.InvokeCheck(() => checkb_Bear.Checked((animalBehaviours & AnimalBehaviours.Bear) == AnimalBehaviours.Bear));
                checkb_Tiger.InvokeCheck(() => checkb_Tiger.Checked((animalBehaviours & AnimalBehaviours.Tiger) == AnimalBehaviours.Tiger));
                checkb_Gorilla.InvokeCheck(() => checkb_Gorilla.Checked((animalBehaviours & AnimalBehaviours.Gorilla) == AnimalBehaviours.Gorilla));
                checkb_Peacock.InvokeCheck(() => checkb_Peacock.Checked((animalBehaviours & AnimalBehaviours.Peacock) == AnimalBehaviours.Peacock));
                checkb_Parrot.InvokeCheck(() => checkb_Parrot.Checked((animalBehaviours & AnimalBehaviours.Parrot) == AnimalBehaviours.Parrot));
                checkb_Condor.InvokeCheck(() => checkb_Condor.Checked((animalBehaviours & AnimalBehaviours.Condor) == AnimalBehaviours.Condor));
                checkb_Skunk.InvokeCheck(() => checkb_Skunk.Checked((animalBehaviours & AnimalBehaviours.Skunk) == AnimalBehaviours.Skunk));
                checkb_Sheep.InvokeCheck(() => checkb_Sheep.Checked((animalBehaviours & AnimalBehaviours.Sheep) == AnimalBehaviours.Sheep));
                checkb_Raccoon.InvokeCheck(() => checkb_Raccoon.Checked((animalBehaviours & AnimalBehaviours.Raccoon) == AnimalBehaviours.Raccoon));
                checkb_HalfFish.InvokeCheck(() => checkb_HalfFish.Checked((animalBehaviours & AnimalBehaviours.HalfFish) == AnimalBehaviours.HalfFish));
                checkb_SkeletonDog.InvokeCheck(() => checkb_SkeletonDog.Checked((animalBehaviours & AnimalBehaviours.SkeletonDog) == AnimalBehaviours.SkeletonDog));
                checkb_Bat.InvokeCheck(() => checkb_Bat.Checked((animalBehaviours & AnimalBehaviours.Bat) == AnimalBehaviours.Bat));
                checkb_Dragon.InvokeCheck(() => checkb_Dragon.Checked((animalBehaviours & AnimalBehaviours.Dragon) == AnimalBehaviours.Dragon));
                checkb_Unicorn.InvokeCheck(() => checkb_Unicorn.Checked((animalBehaviours & AnimalBehaviours.Unicorn) == AnimalBehaviours.Unicorn));
                checkb_Phoenix.InvokeCheck(() => checkb_Phoenix.Checked((animalBehaviours & AnimalBehaviours.Phoenix) == AnimalBehaviours.Phoenix));
                checkb_Drawing1.InvokeCheck(() => checkb_Drawing1.Checked((classroomSkills & ClassroomSkills.Drawing1) == ClassroomSkills.Drawing1));
                checkb_Drawing2.InvokeCheck(() => checkb_Drawing2.Checked((classroomSkills & ClassroomSkills.Drawing2) == ClassroomSkills.Drawing2));
                checkb_Drawing3.InvokeCheck(() => checkb_Drawing3.Checked((classroomSkills & ClassroomSkills.Drawing3) == ClassroomSkills.Drawing3));
                checkb_Drawing4.InvokeCheck(() => checkb_Drawing4.Checked((classroomSkills & ClassroomSkills.Drawing4) == ClassroomSkills.Drawing4));
                checkb_Drawing5.InvokeCheck(() => checkb_Drawing5.Checked((classroomSkills & ClassroomSkills.Drawing5) == ClassroomSkills.Drawing5));
                checkb_ShakeDance.InvokeCheck(() => checkb_ShakeDance.Checked((classroomSkills & ClassroomSkills.Shake) == ClassroomSkills.Shake));
                checkb_SpinDance.InvokeCheck(() => checkb_SpinDance.Checked((classroomSkills & ClassroomSkills.Spin) == ClassroomSkills.Spin));
                checkb_StepDance.InvokeCheck(() => checkb_StepDance.Checked((classroomSkills & ClassroomSkills.Step) == ClassroomSkills.Step));
                checkb_GoGoDance.InvokeCheck(() => checkb_GoGoDance.Checked((classroomSkills & ClassroomSkills.GoGo) == ClassroomSkills.GoGo));
                checkb_Exercise.InvokeCheck(() => checkb_Exercise.Checked((classroomSkills & ClassroomSkills.Exercise) == ClassroomSkills.Exercise));
                checkb_Drum.InvokeCheck(() => checkb_Drum.Checked((classroomSkills & ClassroomSkills.Drum) == ClassroomSkills.Drum));
                checkb_Song1.InvokeCheck(() => checkb_Song1.Checked((classroomSkills & ClassroomSkills.Song1) == ClassroomSkills.Song1));
                checkb_Song2.InvokeCheck(() => checkb_Song2.Checked((classroomSkills & ClassroomSkills.Song2) == ClassroomSkills.Song2));
                checkb_Song3.InvokeCheck(() => checkb_Song3.Checked((classroomSkills & ClassroomSkills.Song3) == ClassroomSkills.Song3));
                checkb_Song4.InvokeCheck(() => checkb_Song4.Checked((classroomSkills & ClassroomSkills.Song4) == ClassroomSkills.Song4));
                checkb_Song5.InvokeCheck(() => checkb_Song5.Checked((classroomSkills & ClassroomSkills.Song5) == ClassroomSkills.Song5));
                checkb_Bell.InvokeCheck(() => checkb_Bell.Checked((classroomSkills & ClassroomSkills.Bell) == ClassroomSkills.Bell));
                checkb_Castanets.InvokeCheck(() => checkb_Castanets.Checked((classroomSkills & ClassroomSkills.Castanets) == ClassroomSkills.Castanets));
                checkb_Cymbals.InvokeCheck(() => checkb_Cymbals.Checked((classroomSkills & ClassroomSkills.Cymbals) == ClassroomSkills.Cymbals));
                checkb_Flute.InvokeCheck(() => checkb_Flute.Checked((classroomSkills & ClassroomSkills.Flute) == ClassroomSkills.Flute));
                checkb_Maracas.InvokeCheck(() => checkb_Maracas.Checked((classroomSkills & ClassroomSkills.Maracas) == ClassroomSkills.Maracas));
                checkb_Trumpet.InvokeCheck(() => checkb_Trumpet.Checked((classroomSkills & ClassroomSkills.Trumpet) == ClassroomSkills.Trumpet));
                checkb_Tambourine.InvokeCheck(() => checkb_Tambourine.Checked((classroomSkills & ClassroomSkills.Tambourine) == ClassroomSkills.Tambourine));

                //Stats
                NumericUpDown nud_SwimLevel = controls[1].Controls.OfType<NumericUpDown>().Where(x => x.Name == "nud_SwimLevel").First();
                NumericUpDown nud_FlyLevel = controls[1].Controls.OfType<NumericUpDown>().Where(x => x.Name == "nud_FlyLevel").First();
                NumericUpDown nud_RunLevel = controls[1].Controls.OfType<NumericUpDown>().Where(x => x.Name == "nud_RunLevel").First();
                NumericUpDown nud_PowerLevel = controls[1].Controls.OfType<NumericUpDown>().Where(x => x.Name == "nud_PowerLevel").First();
                NumericUpDown nud_StaminaLevel = controls[1].Controls.OfType<NumericUpDown>().Where(x => x.Name == "nud_StaminaLevel").First();
                NumericUpDown nud_LuckLevel = controls[1].Controls.OfType<NumericUpDown>().Where(x => x.Name == "nud_LuckLevel").First();
                NumericUpDown nud_IntelligenceLevel = controls[1].Controls.OfType<NumericUpDown>().Where(x => x.Name == "nud_IntelligenceLevel").First();
                NumericUpDown nud_SwimBar = controls[1].Controls.OfType<NumericUpDown>().Where(x => x.Name == "nud_SwimBar").First();
                NumericUpDown nud_FlyBar = controls[1].Controls.OfType<NumericUpDown>().Where(x => x.Name == "nud_FlyBar").First();
                NumericUpDown nud_RunBar = controls[1].Controls.OfType<NumericUpDown>().Where(x => x.Name == "nud_RunBar").First();
                NumericUpDown nud_PowerBar = controls[1].Controls.OfType<NumericUpDown>().Where(x => x.Name == "nud_PowerBar").First();
                NumericUpDown nud_StaminaBar = controls[1].Controls.OfType<NumericUpDown>().Where(x => x.Name == "nud_StaminaBar").First();
                NumericUpDown nud_LuckBar = controls[1].Controls.OfType<NumericUpDown>().Where(x => x.Name == "nud_LuckBar").First();
                NumericUpDown nud_IntelligenceBar = controls[1].Controls.OfType<NumericUpDown>().Where(x => x.Name == "nud_IntelligenceBar").First();
                NumericUpDown nud_SwimStat = controls[1].Controls.OfType<NumericUpDown>().Where(x => x.Name == "nud_SwimStat").First();
                NumericUpDown nud_FlyStat = controls[1].Controls.OfType<NumericUpDown>().Where(x => x.Name == "nud_FlyStat").First();
                NumericUpDown nud_RunStat = controls[1].Controls.OfType<NumericUpDown>().Where(x => x.Name == "nud_RunStat").First();
                NumericUpDown nud_PowerStat = controls[1].Controls.OfType<NumericUpDown>().Where(x => x.Name == "nud_PowerStat").First();
                NumericUpDown nud_StaminaStat = controls[1].Controls.OfType<NumericUpDown>().Where(x => x.Name == "nud_StaminaStat").First();
                NumericUpDown nud_LuckStat = controls[1].Controls.OfType<NumericUpDown>().Where(x => x.Name == "nud_LuckStat").First();
                NumericUpDown nud_IntelligenceStat = controls[1].Controls.OfType<NumericUpDown>().Where(x => x.Name == "nud_IntelligenceStat").First();
                ComboBox cb_SwimGrade = controls[1].Controls.OfType<ComboBox>().Where(x => x.Name == "cb_SwimGrade").First();
                ComboBox cb_FlyGrade = controls[1].Controls.OfType<ComboBox>().Where(x => x.Name == "cb_FlyGrade").First();
                ComboBox cb_RunGrade = controls[1].Controls.OfType<ComboBox>().Where(x => x.Name == "cb_RunGrade").First();
                ComboBox cb_PowerGrade = controls[1].Controls.OfType<ComboBox>().Where(x => x.Name == "cb_PowerGrade").First();
                ComboBox cb_StaminaGrade = controls[1].Controls.OfType<ComboBox>().Where(x => x.Name == "cb_StaminaGrade").First();
                NumericUpDown nud_LuckGrade = controls[1].Controls.OfType<NumericUpDown>().Where(x => x.Name == "nud_LuckGrade").First();
                NumericUpDown nud_IntelligenceGrade = controls[1].Controls.OfType<NumericUpDown>().Where(x => x.Name == "nud_IntelligenceGrade").First();

                nud_SwimLevel.InvokeCheck(() => nud_SwimLevel.Value(swimLevel));
                nud_FlyLevel.InvokeCheck(() => nud_FlyLevel.Value(flyLevel));
                nud_RunLevel.InvokeCheck(() => nud_RunLevel.Value(runLevel));
                nud_PowerLevel.InvokeCheck(() => nud_PowerLevel.Value(powerLevel));
                nud_StaminaLevel.InvokeCheck(() => nud_StaminaLevel.Value(staminaLevel));
                nud_LuckLevel.InvokeCheck(() => nud_LuckLevel.Value(luckLevel));
                nud_IntelligenceLevel.InvokeCheck(() => nud_IntelligenceLevel.Value(intelligenceLevel));
                nud_SwimBar.InvokeCheck(() => nud_SwimBar.Value(swimBar));
                nud_FlyBar.InvokeCheck(() => nud_FlyBar.Value(flyBar));
                nud_RunBar.InvokeCheck(() => nud_RunBar.Value(runBar));
                nud_PowerBar.InvokeCheck(() => nud_PowerBar.Value(powerBar));
                nud_StaminaBar.InvokeCheck(() => nud_StaminaBar.Value(staminaBar));
                nud_LuckBar.InvokeCheck(() => nud_LuckBar.Value(luckBar));
                nud_IntelligenceBar.InvokeCheck(() => nud_IntelligenceBar.Value(intelligenceBar));
                nud_SwimStat.InvokeCheck(() => nud_SwimStat.Value((int)swimPoints));
                nud_FlyStat.InvokeCheck(() => nud_FlyStat.Value((int)flyPoints));
                nud_RunStat.InvokeCheck(() => nud_RunStat.Value((int)runPoints));
                nud_PowerStat.InvokeCheck(() => nud_PowerStat.Value((int)powerPoints));
                nud_StaminaStat.InvokeCheck(() => nud_StaminaStat.Value((int)staminaPoints));
                nud_LuckStat.InvokeCheck(() => nud_LuckStat.Value((int)luckPoints));
                nud_IntelligenceStat.InvokeCheck(() => nud_IntelligenceStat.Value((int)intelligencePoints));

                if (swimGrade <= 5) { cb_SwimGrade.InvokeCheck(() => cb_SwimGrade.Items.Remove("X [CWE]")); }
                else
                {
                    bool hasX = false;
                    cb_SwimGrade.InvokeCheck(() => hasX = cb_SwimGrade.Items.Contains("X [CWE]"));
                    if (!hasX) { cb_SwimGrade.InvokeCheck(() => cb_SwimGrade.Items.Add("X [CWE]")); }
                }
                cb_SwimGrade.InvokeCheck(() => cb_SwimGrade.SelectedIndex(swimGrade));
                if (flyGrade <= 5) { cb_FlyGrade.InvokeCheck(() => cb_FlyGrade.Items.Remove("X [CWE]")); }
                else
                {
                    bool hasX = false;
                    cb_FlyGrade.InvokeCheck(() => hasX = cb_FlyGrade.Items.Contains("X [CWE]"));
                    if (!hasX) { cb_FlyGrade.InvokeCheck(() => cb_FlyGrade.Items.Add("X [CWE]")); }
                }
                cb_FlyGrade.InvokeCheck(() => cb_FlyGrade.SelectedIndex(flyGrade));
                if (runGrade <= 5) { cb_RunGrade.InvokeCheck(() => cb_RunGrade.Items.Remove("X [CWE]")); }
                else
                {
                    bool hasX = false;
                    cb_RunGrade.InvokeCheck(() => hasX = cb_RunGrade.Items.Contains("X [CWE]"));
                    if (!hasX) { cb_RunGrade.InvokeCheck(() => cb_RunGrade.Items.Add("X [CWE]")); }
                }
                cb_RunGrade.InvokeCheck(() => cb_RunGrade.SelectedIndex(runGrade));
                if (powerGrade <= 5) { cb_PowerGrade.InvokeCheck(() => cb_PowerGrade.Items.Remove("X [CWE]")); }
                else
                {
                    bool hasX = false;
                    cb_PowerGrade.InvokeCheck(() => hasX = cb_PowerGrade.Items.Contains("X [CWE]"));
                    if (!hasX) { cb_PowerGrade.InvokeCheck(() => cb_PowerGrade.Items.Add("X [CWE]")); }
                }
                cb_PowerGrade.InvokeCheck(() => cb_PowerGrade.SelectedIndex(powerGrade));
                if (staminaGrade <= 5) { cb_StaminaGrade.InvokeCheck(() => cb_StaminaGrade.Items.Remove("X [CWE]")); }
                else
                {
                    bool hasX = false;
                    cb_StaminaGrade.InvokeCheck(() => hasX = cb_StaminaGrade.Items.Contains("X [CWE]"));
                    if (!hasX) { cb_StaminaGrade.InvokeCheck(() => cb_StaminaGrade.Items.Add("X [CWE]")); }
                }
                cb_StaminaGrade.InvokeCheck(() => cb_StaminaGrade.SelectedIndex(staminaGrade));

                nud_LuckGrade.InvokeCheck(() => nud_LuckGrade.Value(luckGrade));
                nud_IntelligenceGrade.InvokeCheck(() => nud_IntelligenceGrade.Value(intelligenceGrade));

                //Appearance
                ComboBox cb_Colour = controls[2].Controls.OfType<ComboBox>().Where(x => x.Name == "cb_Colour").First();
                ComboBox cb_Texture = controls[2].Controls.OfType<ComboBox>().Where(x => x.Name == "cb_Texture").First();
                ComboBox cb_BodyType = controls[2].Controls.OfType<ComboBox>().Where(x => x.Name == "cb_BodyType").First();
                ComboBox cb_Hat = controls[2].Controls.OfType<ComboBox>().Where(x => x.Name == "cb_Hat").First();
                ComboBox cb_Medal = controls[2].Controls.OfType<ComboBox>().Where(x => x.Name == "cb_Medal").First();
                ComboBox cb_BodyTypeAnimal = controls[2].Controls.OfType<ComboBox>().Where(x => x.Name == "cb_BodyTypeAnimal").First();
                ComboBox cb_Eyes = controls[2].Controls.OfType<ComboBox>().Where(x => x.Name == "cb_Eyes").First();
                ComboBox cb_Emotiball = controls[2].Controls.OfType<ComboBox>().Where(x => x.Name == "cb_Emotiball").First();
                ComboBox cb_Mouth = controls[2].Controls.OfType<ComboBox>().Where(x => x.Name == "cb_Mouth").First();
                ComboBox cb_ArmsPart = controls[2].Controls.OfType<ComboBox>().Where(x => x.Name == "cb_ArmsPart").First();
                ComboBox cb_EarsPart = controls[2].Controls.OfType<ComboBox>().Where(x => x.Name == "cb_EarsPart").First();
                ComboBox cb_ForeheadPart = controls[2].Controls.OfType<ComboBox>().Where(x => x.Name == "cb_ForeheadPart").First();
                ComboBox cb_HornsPart = controls[2].Controls.OfType<ComboBox>().Where(x => x.Name == "cb_HornsPart").First();
                ComboBox cb_LegsPart = controls[2].Controls.OfType<ComboBox>().Where(x => x.Name == "cb_LegsPart").First();
                ComboBox cb_TailPart = controls[2].Controls.OfType<ComboBox>().Where(x => x.Name == "cb_TailPart").First();
                ComboBox cb_WingsPart = controls[2].Controls.OfType<ComboBox>().Where(x => x.Name == "cb_WingsPart").First();
                ComboBox cb_FacePart = controls[2].Controls.OfType<ComboBox>().Where(x => x.Name == "cb_FacePart").First();
                ComboBox cb_EggColour = controls[2].Controls.OfType<ComboBox>().Where(x => x.Name == "cb_EggColour").First();
                CheckBox checkb_Shiny = controls[2].Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_Shiny").First();
                CheckBox checkb_MonoTone = controls[2].Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_MonoTone").First();
                CheckBox checkb_FeetHidden = controls[2].Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_FeetHidden").First();

                cb_Colour.InvokeCheck(() => cb_Colour.SelectedIndex(cb_Colour.FindStringExact(chaoColours.Where(x => x.Value == colour).First().Key)));
                cb_Texture.InvokeCheck(() => cb_Texture.SelectedIndex(texture));
                cb_BodyType.InvokeCheck(() => cb_BodyType.SelectedIndex(bodyType));
                cb_Hat.InvokeCheck(() => cb_Hat.SelectedIndex(hat));
                cb_Medal.InvokeCheck(() => cb_Medal.SelectedIndex(medal));
                cb_BodyTypeAnimal.InvokeCheck(() => cb_BodyTypeAnimal.SelectedIndex(bodyTypeAnimal));
                cb_Eyes.InvokeCheck(() => cb_Eyes.SelectedIndex(eyes));
                cb_Emotiball.InvokeCheck(() => cb_Emotiball.SelectedIndex(emotiball));
                cb_Mouth.InvokeCheck(() => cb_Mouth.SelectedIndex(mouth));
                cb_ArmsPart.InvokeCheck(() => cb_ArmsPart.SelectedIndex(cb_ArmsPart.FindStringExact(animalParts.Where(x => x.Value == armsPart).First().Key)));
                cb_EarsPart.InvokeCheck(() => cb_EarsPart.SelectedIndex(cb_EarsPart.FindStringExact(animalParts.Where(x => x.Value == earsPart).First().Key)));
                cb_ForeheadPart.InvokeCheck(() => cb_ForeheadPart.SelectedIndex(cb_ForeheadPart.FindStringExact(animalParts.Where(x => x.Value == foreheadPart).First().Key)));
                cb_HornsPart.InvokeCheck(() => cb_HornsPart.SelectedIndex(cb_HornsPart.FindStringExact(animalParts.Where(x => x.Value == hornsPart).First().Key)));
                cb_LegsPart.InvokeCheck(() => cb_LegsPart.SelectedIndex(cb_LegsPart.FindStringExact(animalParts.Where(x => x.Value == legsPart).First().Key)));
                cb_TailPart.InvokeCheck(() => cb_TailPart.SelectedIndex(cb_TailPart.FindStringExact(animalParts.Where(x => x.Value == tailPart).First().Key)));
                cb_WingsPart.InvokeCheck(() => cb_WingsPart.SelectedIndex(cb_WingsPart.FindStringExact(animalParts.Where(x => x.Value == wingsPart).First().Key)));
                cb_FacePart.InvokeCheck(() => cb_FacePart.SelectedIndex(cb_FacePart.FindStringExact(animalParts.Where(x => x.Value == facePart).First().Key)));
                cb_EggColour.InvokeCheck(() => cb_EggColour.SelectedIndex(eggColour));
                checkb_Shiny.InvokeCheck(() => checkb_Shiny.Checked(Convert.ToBoolean(shiny)));
                checkb_MonoTone.InvokeCheck(() => checkb_MonoTone.Checked(Convert.ToBoolean(monoTone)));
                checkb_FeetHidden.InvokeCheck(() => checkb_FeetHidden.Checked(Convert.ToBoolean(feetHidden)));

                //Evolution
                ComboBox cb_ChaoType = controls[3].Controls.OfType<ComboBox>().Where(x => x.Name == "cb_ChaoType").First();
                CheckBox checkb_RealisticValues = controls[3].Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_RealisticValues").First();
                uc_Chao uc = tc.TabPages[tc.TabPages.IndexOf(currentChao.Value)].Controls.OfType<uc_Chao>().Where(x => x.chaoNumber == currentChao.Key).First();
                TrackBar trackb_Alignment = controls[3].Controls.OfType<TrackBar>().Where(x => x.Name == "trackb_Alignment").First();
                TrackBar trackb_Run2Power = controls[3].Controls.OfType<TrackBar>().Where(x => x.Name == "trackb_Run2Power").First();
                TrackBar trackb_Swim2Fly = controls[3].Controls.OfType<TrackBar>().Where(x => x.Name == "trackb_Swim2Fly").First();
                TrackBar trackb_TransformationMagnitude = controls[3].Controls.OfType<TrackBar>().Where(x => x.Name == "trackb_TransformationMagnitude").First();
                TrackBar trackb_Lifespan1 = controls[3].Controls.OfType<TrackBar>().Where(x => x.Name == "trackb_Lifespan1").First();
                TrackBar trackb_Lifespan2 = controls[3].Controls.OfType<TrackBar>().Where(x => x.Name == "trackb_Lifespan2").First();

                cb_ChaoType.InvokeCheck(() => cb_ChaoType.SelectedIndex(chaoType));
                if (alignment <= 1 && alignment >= -1 && run2Power <= 1 && run2Power >= -1 && swim2Fly <= 1 && swim2Fly >= -1) { checkb_RealisticValues.InvokeCheck(() => checkb_RealisticValues.Checked(true)); }
                else { checkb_RealisticValues.InvokeCheck(() => checkb_RealisticValues.Checked(false)); }
                uc.CheckRealistic();
                trackb_Alignment.InvokeCheck(() => trackb_Alignment.Value((int)(alignment * 10000000)));
                trackb_Run2Power.InvokeCheck(() => trackb_Run2Power.Value((int)(run2Power * 10000000)));
                trackb_Swim2Fly.InvokeCheck(() => trackb_Swim2Fly.Value((int)(swim2Fly * 10000000)));
                trackb_TransformationMagnitude.InvokeCheck(() => trackb_TransformationMagnitude.Value((int)(transformationMagnitude * 10000000)));
                trackb_Lifespan1.InvokeCheck(() => trackb_Lifespan1.Value(lifespan1));
                trackb_Lifespan2.InvokeCheck(() => trackb_Lifespan2.Value(lifespan2));
                if (lifespan1 > lifespan2) { trackb_Lifespan2.InvokeCheck(() => trackb_Lifespan2.Value(lifespan1)); }

                //Emotions
                TrackBar trackb_DesireToMate = controls[4].Controls.OfType<TrackBar>().Where(x => x.Name == "trackb_DesireToMate").First();
                TrackBar trackb_Hunger = controls[4].Controls.OfType<TrackBar>().Where(x => x.Name == "trackb_Hunger").First();
                TrackBar trackb_Sleepiness = controls[4].Controls.OfType<TrackBar>().Where(x => x.Name == "trackb_Sleepiness").First();
                TrackBar trackb_Tiredness = controls[4].Controls.OfType<TrackBar>().Where(x => x.Name == "trackb_Tiredness").First();
                TrackBar trackb_Boredom = controls[4].Controls.OfType<TrackBar>().Where(x => x.Name == "trackb_Boredom").First();
                TrackBar trackb_Energy = controls[4].Controls.OfType<TrackBar>().Where(x => x.Name == "trackb_Energy").First();
                TrackBar trackb_Joy = controls[4].Controls.OfType<TrackBar>().Where(x => x.Name == "trackb_Joy").First();
                TrackBar trackb_UrgeToCry = controls[4].Controls.OfType<TrackBar>().Where(x => x.Name == "trackb_UrgeToCry").First();
                TrackBar trackb_Fear = controls[4].Controls.OfType<TrackBar>().Where(x => x.Name == "trackb_Fear").First();
                TrackBar trackb_Dizziness = controls[4].Controls.OfType<TrackBar>().Where(x => x.Name == "trackb_Dizziness").First();

                trackb_DesireToMate.InvokeCheck(() => trackb_DesireToMate.Value(desireToMate));
                trackb_Hunger.InvokeCheck(() => trackb_Hunger.Value(hunger));
                trackb_Sleepiness.InvokeCheck(() => trackb_Sleepiness.Value(sleepiness));
                trackb_Tiredness.InvokeCheck(() => trackb_Tiredness.Value(tiredness));
                trackb_Boredom.InvokeCheck(() => trackb_Boredom.Value(boredom));
                trackb_Energy.InvokeCheck(() => trackb_Energy.Value(energy));
                trackb_Joy.InvokeCheck(() => trackb_Joy.Value(joy));
                trackb_UrgeToCry.InvokeCheck(() => trackb_UrgeToCry.Value(urgeToCry));
                trackb_Fear.InvokeCheck(() => trackb_Fear.Value(fear));
                trackb_Dizziness.InvokeCheck(() => trackb_Dizziness.Value(dizziness));

                //Character Bonds
                TrackBar trackb_SonicBond = controls[5].Controls.OfType<TrackBar>().Where(x => x.Name == "trackb_SonicBond").First();
                TrackBar trackb_TailsBond = controls[5].Controls.OfType<TrackBar>().Where(x => x.Name == "trackb_TailsBond").First();
                TrackBar trackb_KnucklesBond = controls[5].Controls.OfType<TrackBar>().Where(x => x.Name == "trackb_KnucklesBond").First();
                TrackBar trackb_ShadowBond = controls[5].Controls.OfType<TrackBar>().Where(x => x.Name == "trackb_ShadowBond").First();
                TrackBar trackb_EggmanBond = controls[5].Controls.OfType<TrackBar>().Where(x => x.Name == "trackb_EggmanBond").First();
                TrackBar trackb_RougeBond = controls[5].Controls.OfType<TrackBar>().Where(x => x.Name == "trackb_RougeBond").First();

                trackb_SonicBond.InvokeCheck(() => trackb_SonicBond.Value(sonicBond));
                trackb_TailsBond.InvokeCheck(() => trackb_TailsBond.Value(tailsBond));
                trackb_KnucklesBond.InvokeCheck(() => trackb_KnucklesBond.Value(knucklesBond));
                trackb_ShadowBond.InvokeCheck(() => trackb_ShadowBond.Value(shadowBond));
                trackb_EggmanBond.InvokeCheck(() => trackb_EggmanBond.Value(eggmanBond));
                trackb_RougeBond.InvokeCheck(() => trackb_RougeBond.Value(rougeBond));

                //Personality
                TrackBar trackb_Normal2Curious = controls[6].Controls.OfType<TrackBar>().Where(x => x.Name == "trackb_Normal2Curious").First();
                TrackBar trackb_CryBaby2Energetic = controls[6].Controls.OfType<TrackBar>().Where(x => x.Name == "trackb_CryBaby2Energetic").First();
                TrackBar trackb_Naive2Normal = controls[6].Controls.OfType<TrackBar>().Where(x => x.Name == "trackb_Naive2Normal").First();
                TrackBar trackb_Normal2BigEater = controls[6].Controls.OfType<TrackBar>().Where(x => x.Name == "trackb_Normal2BigEater").First();
                TrackBar trackb_Normal2Carefree = controls[6].Controls.OfType<TrackBar>().Where(x => x.Name == "trackb_Normal2Carefree").First();
                ComboBox cb_FavouriteFruit = controls[6].Controls.OfType<ComboBox>().Where(x => x.Name == "cb_FavouriteFruit").First();

                trackb_Normal2Curious.InvokeCheck(() => trackb_Normal2Curious.Value(normal2Curious));
                trackb_CryBaby2Energetic.InvokeCheck(() => trackb_CryBaby2Energetic.Value(cryBaby2Energetic));
                trackb_Naive2Normal.InvokeCheck(() => trackb_Naive2Normal.Value(naive2Normal));
                trackb_Normal2BigEater.InvokeCheck(() => trackb_Normal2BigEater.Value(normal2BigEater));
                trackb_Normal2Carefree.InvokeCheck(() => trackb_Normal2Carefree.Value(normal2Carefree));
                if (favouriteFruit == 16) { cb_FavouriteFruit.InvokeCheck(() => cb_FavouriteFruit.SelectedIndex(8)); }
                else { cb_FavouriteFruit.InvokeCheck(() => cb_FavouriteFruit.SelectedIndex(favouriteFruit)); }

                //Health
                TrackBar trackb_Cough = controls[7].Controls.OfType<TrackBar>().Where(x => x.Name == "trackb_Cough").First();
                TrackBar trackb_Cold = controls[7].Controls.OfType<TrackBar>().Where(x => x.Name == "trackb_Cold").First();
                TrackBar trackb_Rash = controls[7].Controls.OfType<TrackBar>().Where(x => x.Name == "trackb_Rash").First();
                TrackBar trackb_RunnyNose = controls[7].Controls.OfType<TrackBar>().Where(x => x.Name == "trackb_RunnyNose").First();
                TrackBar trackb_Hiccups = controls[7].Controls.OfType<TrackBar>().Where(x => x.Name == "trackb_Hiccups").First();
                TrackBar trackb_StomachAche = controls[7].Controls.OfType<TrackBar>().Where(x => x.Name == "trackb_StomachAche").First();

                trackb_Cough.InvokeCheck(() => trackb_Cough.Value(cough));
                trackb_Cold.InvokeCheck(() => trackb_Cold.Value(cold));
                trackb_Rash.InvokeCheck(() => trackb_Rash.Value(rash));
                trackb_RunnyNose.InvokeCheck(() => trackb_RunnyNose.Value(runnyNose));
                trackb_Hiccups.InvokeCheck(() => trackb_Hiccups.Value(hiccups));
                trackb_StomachAche.InvokeCheck(() => trackb_StomachAche.Value(stomachAche));

                //DNA
                ComboBox cb_Swim1 = controls[8].Controls.OfType<ComboBox>().Where(x => x.Name == "cb_Swim1").First();
                ComboBox cb_Swim2 = controls[8].Controls.OfType<ComboBox>().Where(x => x.Name == "cb_Swim2").First();
                ComboBox cb_Fly1 = controls[8].Controls.OfType<ComboBox>().Where(x => x.Name == "cb_Fly1").First();
                ComboBox cb_Fly2 = controls[8].Controls.OfType<ComboBox>().Where(x => x.Name == "cb_Fly2").First();
                ComboBox cb_Run1 = controls[8].Controls.OfType<ComboBox>().Where(x => x.Name == "cb_Run1").First();
                ComboBox cb_Run2 = controls[8].Controls.OfType<ComboBox>().Where(x => x.Name == "cb_Run2").First();
                ComboBox cb_Power1 = controls[8].Controls.OfType<ComboBox>().Where(x => x.Name == "cb_Power1").First();
                ComboBox cb_Power2 = controls[8].Controls.OfType<ComboBox>().Where(x => x.Name == "cb_Power2").First();
                ComboBox cb_Stamina1 = controls[8].Controls.OfType<ComboBox>().Where(x => x.Name == "cb_Stamina1").First();
                ComboBox cb_Stamina2 = controls[8].Controls.OfType<ComboBox>().Where(x => x.Name == "cb_Stamina2").First();
                NumericUpDown nud_Luck1 = controls[8].Controls.OfType<NumericUpDown>().Where(x => x.Name == "nud_Luck1").First();
                NumericUpDown nud_Luck2 = controls[8].Controls.OfType<NumericUpDown>().Where(x => x.Name == "nud_Luck2").First();
                NumericUpDown nud_Intelligence1 = controls[8].Controls.OfType<NumericUpDown>().Where(x => x.Name == "nud_Intelligence1").First();
                NumericUpDown nud_Intelligence2 = controls[8].Controls.OfType<NumericUpDown>().Where(x => x.Name == "nud_Intelligence2").First();
                ComboBox cb_Fruit1 = controls[8].Controls.OfType<ComboBox>().Where(x => x.Name == "cb_Fruit1").First();
                ComboBox cb_Fruit2 = controls[8].Controls.OfType<ComboBox>().Where(x => x.Name == "cb_Fruit2").First();
                ComboBox cb_Colour1 = controls[8].Controls.OfType<ComboBox>().Where(x => x.Name == "cb_Colour1").First();
                ComboBox cb_Colour2 = controls[8].Controls.OfType<ComboBox>().Where(x => x.Name == "cb_Colour2").First();
                ComboBox cb_EggColour1 = controls[8].Controls.OfType<ComboBox>().Where(x => x.Name == "cb_EggColour1").First();
                ComboBox cb_EggColour2 = controls[8].Controls.OfType<ComboBox>().Where(x => x.Name == "cb_EggColour2").First();
                ComboBox cb_Texture1 = controls[8].Controls.OfType<ComboBox>().Where(x => x.Name == "cb_Texture1").First();
                ComboBox cb_Texture2 = controls[8].Controls.OfType<ComboBox>().Where(x => x.Name == "cb_Texture2").First();
                CheckBox checkb_Shiny1 = controls[8].Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_Shiny1").First();
                CheckBox checkb_Shiny2 = controls[8].Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_Shiny2").First();
                CheckBox checkb_MonoTone1 = controls[8].Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_MonoTone1").First();
                CheckBox checkb_MonoTone2 = controls[8].Controls.OfType<CheckBox>().Where(x => x.Name == "checkb_MonoTone2").First();

                if (swimDNAGrade1 <= 5) { cb_Swim1.InvokeCheck(() => cb_Swim1.Items.Remove("X [CWE]")); }
                else
                {
                    bool hasX = false;
                    cb_Swim1.InvokeCheck(() => hasX = cb_Swim1.Items.Contains("X [CWE]"));
                    if (!hasX) { cb_Swim1.InvokeCheck(() => cb_Swim1.Items.Add("X [CWE]")); }
                }
                cb_Swim1.InvokeCheck(() => cb_Swim1.SelectedIndex(swimDNAGrade1));
                if (swimDNAGrade2 <= 5) { cb_Swim2.InvokeCheck(() => cb_Swim2.Items.Remove("X [CWE]")); }
                else
                {
                    bool hasX = false;
                    cb_Swim2.InvokeCheck(() => hasX = cb_Swim2.Items.Contains("X [CWE]"));
                    if (!hasX) { cb_Swim2.InvokeCheck(() => cb_Swim2.Items.Add("X [CWE]")); }
                }
                cb_Swim2.InvokeCheck(() => cb_Swim2.SelectedIndex(swimDNAGrade2));
                if (flyDNAGrade1 <= 5) { cb_Fly1.InvokeCheck(() => cb_Fly1.Items.Remove("X [CWE]")); }
                else
                {
                    bool hasX = false;
                    cb_Fly1.InvokeCheck(() => hasX = cb_Fly1.Items.Contains("X [CWE]"));
                    if (!hasX) { cb_Fly1.InvokeCheck(() => cb_Fly1.Items.Add("X [CWE]")); }
                }
                cb_Fly1.InvokeCheck(() => cb_Fly1.SelectedIndex(flyDNAGrade1));
                if (flyDNAGrade2 <= 5) { cb_Fly2.InvokeCheck(() => cb_Fly2.Items.Remove("X [CWE]")); }
                else
                {
                    bool hasX = false;
                    cb_Fly2.InvokeCheck(() => hasX = cb_Fly2.Items.Contains("X [CWE]"));
                    if (!hasX) { cb_Fly2.InvokeCheck(() => cb_Fly2.Items.Add("X [CWE]")); }
                }
                cb_Fly2.InvokeCheck(() => cb_Fly2.SelectedIndex(flyDNAGrade2));
                if (runDNAGrade1 <= 5) { cb_Run1.InvokeCheck(() => cb_Run1.Items.Remove("X [CWE]")); }
                else
                {
                    bool hasX = false;
                    cb_Run1.InvokeCheck(() => hasX = cb_Run1.Items.Contains("X [CWE]"));
                    if (!hasX) { cb_Run1.InvokeCheck(() => cb_Run1.Items.Add("X [CWE]")); }
                }
                cb_Run1.InvokeCheck(() => cb_Run1.SelectedIndex(runDNAGrade1));
                if (runDNAGrade2 <= 5) { cb_Run2.InvokeCheck(() => cb_Run2.Items.Remove("X [CWE]")); }
                else
                {
                    bool hasX = false;
                    cb_Run2.InvokeCheck(() => hasX = cb_Run2.Items.Contains("X [CWE]"));
                    if (!hasX) { cb_Run2.InvokeCheck(() => cb_Run2.Items.Add("X [CWE]")); }
                }
                cb_Run2.InvokeCheck(() => cb_Run2.SelectedIndex(runDNAGrade2));
                if (powerDNAGrade1 <= 5) { cb_Power1.InvokeCheck(() => cb_Power1.Items.Remove("X [CWE]")); }
                else
                {
                    bool hasX = false;
                    cb_Power1.InvokeCheck(() => hasX = cb_Power1.Items.Contains("X [CWE]"));
                    if (!hasX) { cb_Power1.InvokeCheck(() => cb_Power1.Items.Add("X [CWE]")); }
                }
                cb_Power1.InvokeCheck(() => cb_Power1.SelectedIndex(powerDNAGrade1));
                if (powerDNAGrade2 <= 5) { cb_Power2.InvokeCheck(() => cb_Power2.Items.Remove("X [CWE]")); }
                else
                {
                    bool hasX = false;
                    cb_Power2.InvokeCheck(() => hasX = cb_Power2.Items.Contains("X [CWE]"));
                    if (!hasX) { cb_Power2.InvokeCheck(() => cb_Power2.Items.Add("X [CWE]")); }
                }
                cb_Power2.InvokeCheck(() => cb_Power2.SelectedIndex(powerDNAGrade2));
                if (staminaDNAGrade1 <= 5) { cb_Stamina1.InvokeCheck(() => cb_Stamina1.Items.Remove("X [CWE]")); }
                else
                {
                    bool hasX = false;
                    cb_Stamina1.InvokeCheck(() => hasX = cb_Stamina1.Items.Contains("X [CWE]"));
                    if (!hasX) { cb_Stamina1.InvokeCheck(() => cb_Stamina1.Items.Add("X [CWE]")); }
                }
                cb_Stamina1.InvokeCheck(() => cb_Stamina1.SelectedIndex(staminaDNAGrade1));
                if (staminaDNAGrade2 <= 5) { cb_Stamina2.InvokeCheck(() => cb_Stamina2.Items.Remove("X [CWE]")); }
                else
                {
                    bool hasX = false;
                    cb_Stamina2.InvokeCheck(() => hasX = cb_Stamina2.Items.Contains("X [CWE]"));
                    if (!hasX) { cb_Stamina2.InvokeCheck(() => cb_Stamina2.Items.Add("X [CWE]")); }
                }
                cb_Stamina2.InvokeCheck(() => cb_Stamina2.SelectedIndex(staminaDNAGrade2));
                nud_Luck1.InvokeCheck(() => nud_Luck1.Value(luckDNAGrade1));
                nud_Luck2.InvokeCheck(() => nud_Luck2.Value(luckDNAGrade2));
                nud_Intelligence1.InvokeCheck(() => nud_Intelligence1.Value(intelligenceDNAGrade1));
                nud_Intelligence2.InvokeCheck(() => nud_Intelligence2.Value(intelligenceDNAGrade2));
                cb_Fruit1.InvokeCheck(() => cb_Fruit1.SelectedIndex(fruit1));
                cb_Fruit2.InvokeCheck(() => cb_Fruit2.SelectedIndex(fruit2));
                cb_Colour1.InvokeCheck(() => cb_Colour1.SelectedIndex(cb_Colour1.FindStringExact(chaoColours.Where(x => x.Value == colour1).First().Key)));
                cb_Colour2.InvokeCheck(() => cb_Colour2.SelectedIndex(cb_Colour2.FindStringExact(chaoColours.Where(x => x.Value == colour2).First().Key)));
                cb_EggColour1.InvokeCheck(() => cb_EggColour1.SelectedIndex(eggColour1));
                cb_EggColour2.InvokeCheck(() => cb_EggColour2.SelectedIndex(eggColour2));
                cb_Texture1.InvokeCheck(() => cb_Texture1.SelectedIndex(texture1));
                cb_Texture2.InvokeCheck(() => cb_Texture2.SelectedIndex(texture2));
                checkb_Shiny1.InvokeCheck(() => checkb_Shiny1.Checked(Convert.ToBoolean(shiny1)));
                checkb_Shiny2.InvokeCheck(() => checkb_Shiny2.Checked(Convert.ToBoolean(shiny2)));
                checkb_MonoTone1.InvokeCheck(() => checkb_MonoTone1.Checked(Convert.ToBoolean(monoTone1)));
                checkb_MonoTone2.InvokeCheck(() => checkb_MonoTone2.Checked(Convert.ToBoolean(monoTone2)));
            }
        }

        public static void GetChaoWorld()
        {
            uc_ChaoSave ucChaoSave = new uc_ChaoSave();
            TabPage tpChaoSave = new TabPage();
            tpChaoSave.Controls.Add(ucChaoSave);
            tpChaoSave.Text = "Chao World";
            Main.tc_Main.TabPages.Add(tpChaoSave);
            UpdateChaoWorld();
        }


        public static void EmptyChaoSelected(int index)
        {
            DialogResult result = MessageBox.Show("Would you like to create a chao in slot #" + (index) + "?", "Chao Slot #" + (index), MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                PopulateChaoMsgBox populateChaoMsgBox = new PopulateChaoMsgBox();
                populateChaoMsgBox.tabIndex = index;
                populateChaoMsgBox.ShowDialog();
            }
        }

        public static void GetChao()
        {
            uint chaoIndex = 0;
            List<byte[]> chaoArray = new List<byte[]>();
            if (Main.isRTE)
            {
                chaoArray = Main.SplitByteArray(Memory.ReadBytes(offsets.chaoMemoryStart, 0xC000), 0x800);
            }
            if (!Main.isSA && !Main.isRTE) { chaoArray = Main.SplitByteArray(Main.loadedSave.Skip(0x3AA4).Take(0xC000).ToArray(), 0x800); }
            if (Main.isSA && !Main.isRTE) { chaoArray = Main.SplitByteArray(Main.loadedSave.Skip(0x818).Take(0xC000).ToArray(), 0x800); }
            foreach (byte[] chao in chaoArray)
            {
                byte[] nameBytes = chao.Skip(Convert.ToInt32(offsets.chao.Name)).Take(7).ToArray();

                string name = GetName(nameBytes);
                if (!activeChao.ContainsKey(chaoIndex))
                {
                    uc_Chao uc = new uc_Chao();
                    TabPage tp = new TabPage();
                    uc.chaoNumber = chaoIndex;
                    tp.Controls.Add(uc);
                    tp.Text = name;
                    Main.tc_Main.TabPages.Add(tp);
                    activeChao.Add(chaoIndex, tp);
                }
                KeyValuePair<uint, TabPage> currentChao = activeChao.Where(x => x.Key == chaoIndex).First();
                UpdateChao(Main.tc_Main, currentChao, chao);
                chaoIndex++;
            }
        }

        public static byte[] ByteSwapChao(byte[] chao)
        {
            List<byte> byteArray = chao.ToList<byte>();
            byteArray.Reverse((int)offsets.chao.SwimPoints, 2);
            byteArray.Reverse((int)offsets.chao.FlyPoints, 2);
            byteArray.Reverse((int)offsets.chao.RunPoints, 2);
            byteArray.Reverse((int)offsets.chao.PowerPoints, 2);
            byteArray.Reverse((int)offsets.chao.StaminaPoints, 2);
            byteArray.Reverse((int)offsets.chao.LuckPoints, 2);
            byteArray.Reverse((int)offsets.chao.IntelligencePoints, 2);
            byteArray.Reverse((int)offsets.chao.Happiness, 2);
            byteArray.Reverse((int)offsets.chao.Lifespan1, 2);
            byteArray.Reverse((int)offsets.chao.Lifespan2, 2);
            byteArray.Reverse((int)offsets.chao.Reincarnations, 2);
            byteArray.Reverse((int)offsets.chao.SA2Toys, 4);
            byteArray.Reverse((int)offsets.chao.SA2AnimalBehaviours, 4);
            byteArray.Reverse((int)offsets.chao.SAAnimalBehaviours, 4);
            byteArray.Reverse((int)offsets.chao.Alignment, 4);
            byteArray.Reverse((int)offsets.chao.Run2PowerTranformation, 4);
            byteArray.Reverse((int)offsets.chao.Swim2FlyTransformation, 4);
            byteArray.Reverse((int)offsets.chao.TransformationMagnitude, 4);
            byteArray.Reverse((int)offsets.chao.DesireToMate, 2);
            byteArray.Reverse((int)offsets.chao.Hunger, 2);
            byteArray.Reverse((int)offsets.chao.Sleepiness, 2);
            byteArray.Reverse((int)offsets.chao.Tiredness, 2);
            byteArray.Reverse((int)offsets.chao.Boredom, 2);
            byteArray.Reverse((int)offsets.chao.Energy, 2);
            return byteArray.ToArray();
        }

        public static byte[] ByteSwapChaoWorld(byte[] save)
        {
            List<byte> byteArray = save.ToList();
            byteArray.Reverse((int)offsets.chaoSave.Gardens, 4);
            byteArray.Reverse((int)offsets.chaoSave.MarketCount, 4);
            byteArray.Reverse((int)offsets.chaoSave.HeldCount, 4);
            return byteArray.ToArray();
        }

        public static byte[] SetName(string nameString)
        {
            List<byte> byteList = new List<byte>();
            foreach (char c in nameString)
            {
                if (c == '!') { byteList.Add(0x01); }
                if (c == '"') { byteList.Add(0x02); }
                if (c == '#') { byteList.Add(0x03); }
                if (c == '$') { byteList.Add(0x04); }
                if (c == '%') { byteList.Add(0x05); }
                if (c == '&') { byteList.Add(0x06); }
                if (c == '\\') { byteList.Add(0x07); }
                if (c == '(') { byteList.Add(0x08); }
                if (c == ')') { byteList.Add(0x09); }
                if (c == '*') { byteList.Add(0x0A); }
                if (c == '+') { byteList.Add(0x0B); }
                if (c == ',') { byteList.Add(0x0C); }
                if (c == '-') { byteList.Add(0x0D); }
                if (c == '.') { byteList.Add(0x0E); }
                if (c == '/') { byteList.Add(0x0F); }
                if (c == '0') { byteList.Add(0x10); }
                if (c == '1') { byteList.Add(0x11); }
                if (c == '2') { byteList.Add(0x12); }
                if (c == '3') { byteList.Add(0x13); }
                if (c == '4') { byteList.Add(0x14); }
                if (c == '5') { byteList.Add(0x15); }
                if (c == '6') { byteList.Add(0x16); }
                if (c == '7') { byteList.Add(0x17); }
                if (c == '8') { byteList.Add(0x18); }
                if (c == '9') { byteList.Add(0x19); }
                if (c == ':') { byteList.Add(0x1A); }
                if (c == ';') { byteList.Add(0x1B); }
                if (c == '<') { byteList.Add(0x1C); }
                if (c == '=') { byteList.Add(0x1D); }
                if (c == '>') { byteList.Add(0x1E); }
                if (c == '?') { byteList.Add(0x1F); }
                if (c == '@') { byteList.Add(0x20); }
                if (c == 'A') { byteList.Add(0x21); }
                if (c == 'B') { byteList.Add(0x22); }
                if (c == 'C') { byteList.Add(0x23); }
                if (c == 'D') { byteList.Add(0x24); }
                if (c == 'E') { byteList.Add(0x25); }
                if (c == 'F') { byteList.Add(0x26); }
                if (c == 'G') { byteList.Add(0x27); }
                if (c == 'H') { byteList.Add(0x28); }
                if (c == 'I') { byteList.Add(0x29); }
                if (c == 'J') { byteList.Add(0x2A); }
                if (c == 'K') { byteList.Add(0x2B); }
                if (c == 'L') { byteList.Add(0x2C); }
                if (c == 'M') { byteList.Add(0x2D); }
                if (c == 'N') { byteList.Add(0x2E); }
                if (c == 'O') { byteList.Add(0x2F); }
                if (c == 'P') { byteList.Add(0x30); }
                if (c == 'Q') { byteList.Add(0x31); }
                if (c == 'R') { byteList.Add(0x32); }
                if (c == 'S') { byteList.Add(0x33); }
                if (c == 'T') { byteList.Add(0x34); }
                if (c == 'U') { byteList.Add(0x35); }
                if (c == 'V') { byteList.Add(0x36); }
                if (c == 'W') { byteList.Add(0x37); }
                if (c == 'X') { byteList.Add(0x38); }
                if (c == 'Y') { byteList.Add(0x39); }
                if (c == 'Z') { byteList.Add(0x3A); }
                if (c == '[') { byteList.Add(0x3B); }
                if (c == '¥') { byteList.Add(0x3C); }
                if (c == ']') { byteList.Add(0x3D); }
                if (c == '^') { byteList.Add(0x3E); }
                if (c == '_') { byteList.Add(0x3F); }
                if (c == '‘') { byteList.Add(0x40); }
                if (c == 'a') { byteList.Add(0x41); }
                if (c == 'b') { byteList.Add(0x42); }
                if (c == 'c') { byteList.Add(0x43); }
                if (c == 'd') { byteList.Add(0x44); }
                if (c == 'e') { byteList.Add(0x45); }
                if (c == 'f') { byteList.Add(0x46); }
                if (c == 'g') { byteList.Add(0x47); }
                if (c == 'h') { byteList.Add(0x48); }
                if (c == 'i') { byteList.Add(0x49); }
                if (c == 'j') { byteList.Add(0x4A); }
                if (c == 'k') { byteList.Add(0x4B); }
                if (c == 'l') { byteList.Add(0x4C); }
                if (c == 'm') { byteList.Add(0x4D); }
                if (c == 'n') { byteList.Add(0x4E); }
                if (c == 'o') { byteList.Add(0x4F); }
                if (c == 'p') { byteList.Add(0x50); }
                if (c == 'q') { byteList.Add(0x51); }
                if (c == 'r') { byteList.Add(0x52); }
                if (c == 's') { byteList.Add(0x53); }
                if (c == 't') { byteList.Add(0x54); }
                if (c == 'u') { byteList.Add(0x55); }
                if (c == 'v') { byteList.Add(0x56); }
                if (c == 'w') { byteList.Add(0x57); }
                if (c == 'x') { byteList.Add(0x58); }
                if (c == 'y') { byteList.Add(0x59); }
                if (c == 'z') { byteList.Add(0x5A); }
                if (c == '{') { byteList.Add(0x5B); }
                if (c == '|') { byteList.Add(0x5C); }
                if (c == '}') { byteList.Add(0x5D); }
                if (c == '~') { byteList.Add(0x5E); }
                if (c == ' ') { byteList.Add(0x5F); }
                if (c == 'À') { byteList.Add(0x60); }
                if (c == 'Á') { byteList.Add(0x61); }
                if (c == 'Â') { byteList.Add(0x62); }
                if (c == 'Ã') { byteList.Add(0x63); }
                if (c == 'Ä') { byteList.Add(0x64); }
                if (c == 'Å') { byteList.Add(0x65); }
                if (c == 'Æ') { byteList.Add(0x66); }
                if (c == 'Ç') { byteList.Add(0x67); }
                if (c == 'È') { byteList.Add(0x68); }
                if (c == 'É') { byteList.Add(0x69); }
                if (c == 'Ê') { byteList.Add(0x6A); }
                if (c == 'Ë') { byteList.Add(0x6B); }
                if (c == 'Ì') { byteList.Add(0x6C); }
                if (c == 'Í') { byteList.Add(0x6D); }
                if (c == 'Î') { byteList.Add(0x6E); }
                if (c == 'Ï') { byteList.Add(0x6F); }
                if (c == 'Ð') { byteList.Add(0x70); }
                if (c == 'Ñ') { byteList.Add(0x71); }
                if (c == 'Ò') { byteList.Add(0x72); }
                if (c == 'Ó') { byteList.Add(0x73); }
                if (c == 'Ô') { byteList.Add(0x74); }
                if (c == 'Õ') { byteList.Add(0x75); }
                if (c == 'Ö') { byteList.Add(0x76); }
                if (c == '¿') { byteList.Add(0x77); }
                if (c == 'Ø') { byteList.Add(0x78); }
                if (c == 'Ù') { byteList.Add(0x79); }
                if (c == 'Ú') { byteList.Add(0x7A); }
                if (c == 'Û') { byteList.Add(0x7B); }
                if (c == 'Ü') { byteList.Add(0x7C); }
                if (c == 'Ý') { byteList.Add(0x7D); }
                if (c == 'Þ') { byteList.Add(0x7E); }
                if (c == 'ß') { byteList.Add(0x7F); }
                if (c == 'à') { byteList.Add(0x80); }
                if (c == 'á') { byteList.Add(0x81); }
                if (c == 'â') { byteList.Add(0x82); }
                if (c == 'ã') { byteList.Add(0x83); }
                if (c == 'ä') { byteList.Add(0x84); }
                if (c == 'å') { byteList.Add(0x85); }
                if (c == 'æ') { byteList.Add(0x86); }
                if (c == 'ç') { byteList.Add(0x87); }
                if (c == 'è') { byteList.Add(0x88); }
                if (c == 'é') { byteList.Add(0x89); }
                if (c == 'ê') { byteList.Add(0x8A); }
                if (c == 'ë') { byteList.Add(0x8B); }
                if (c == 'ì') { byteList.Add(0x8C); }
                if (c == 'í') { byteList.Add(0x8D); }
                if (c == 'î') { byteList.Add(0x8E); }
                if (c == 'ï') { byteList.Add(0x8F); }
                if (c == 'ð') { byteList.Add(0x90); }
                if (c == 'ñ') { byteList.Add(0x91); }
                if (c == 'ò') { byteList.Add(0x92); }
                if (c == 'ó') { byteList.Add(0x93); }
                if (c == 'ô') { byteList.Add(0x94); }
                if (c == 'õ') { byteList.Add(0x95); }
                if (c == 'ö') { byteList.Add(0x96); }
                if (c == '¡') { byteList.Add(0x97); }
                if (c == 'ø') { byteList.Add(0x98); }
                if (c == 'ù') { byteList.Add(0x99); }
                if (c == 'ú') { byteList.Add(0x9A); }
                if (c == 'û') { byteList.Add(0x9B); }
                if (c == 'ü') { byteList.Add(0x9C); }
                if (c == 'ý') { byteList.Add(0x9D); }
                if (c == 'þ') { byteList.Add(0x9E); }
                if (c == 'ÿ') { byteList.Add(0x9F); }
                if (c == 'ァ') { byteList.Add(0xA0); }
                if (c == 'ア') { byteList.Add(0xA1); }
                if (c == 'ィ') { byteList.Add(0xA2); }
                if (c == 'イ') { byteList.Add(0xA3); }
                if (c == 'ゥ') { byteList.Add(0xA4); }
                if (c == 'ウ') { byteList.Add(0xA5); }
                if (c == 'ェ') { byteList.Add(0xA6); }
                if (c == 'エ') { byteList.Add(0xA7); }
                if (c == 'ォ') { byteList.Add(0xA8); }
                if (c == 'オ') { byteList.Add(0xA9); }
                if (c == 'カ') { byteList.Add(0xAA); }
                if (c == 'ガ') { byteList.Add(0xAB); }
                if (c == 'キ') { byteList.Add(0xAC); }
                if (c == 'ギ') { byteList.Add(0xAD); }
                if (c == 'ク') { byteList.Add(0xAE); }
                if (c == 'グ') { byteList.Add(0xAF); }
                if (c == 'ケ') { byteList.Add(0xB0); }
                if (c == 'ゲ') { byteList.Add(0xB1); }
                if (c == 'コ') { byteList.Add(0xB2); }
                if (c == 'ゴ') { byteList.Add(0xB3); }
                if (c == 'サ') { byteList.Add(0xB4); }
                if (c == 'ザ') { byteList.Add(0xB5); }
                if (c == 'シ') { byteList.Add(0xB6); }
                if (c == 'ジ') { byteList.Add(0xB7); }
                if (c == 'ス') { byteList.Add(0xB8); }
                if (c == 'ズ') { byteList.Add(0xB9); }
                if (c == 'セ') { byteList.Add(0xBA); }
                if (c == 'ゼ') { byteList.Add(0xBB); }
                if (c == 'ソ') { byteList.Add(0xBC); }
                if (c == 'ゾ') { byteList.Add(0xBD); }
                if (c == 'タ') { byteList.Add(0xBE); }
                if (c == 'ダ') { byteList.Add(0xBF); }
                if (c == 'チ') { byteList.Add(0xC0); }
                if (c == 'ヂ') { byteList.Add(0xC1); }
                if (c == 'ツ') { byteList.Add(0xC2); }
                if (c == 'ッ') { byteList.Add(0xC3); }
                if (c == 'ヅ') { byteList.Add(0xC4); }
                if (c == 'テ') { byteList.Add(0xC5); }
                if (c == 'デ') { byteList.Add(0xC6); }
                if (c == 'ト') { byteList.Add(0xC7); }
                if (c == 'ド') { byteList.Add(0xC8); }
                if (c == 'ナ') { byteList.Add(0xC9); }
                if (c == 'ニ') { byteList.Add(0xCA); }
                if (c == 'ヌ') { byteList.Add(0xCB); }
                if (c == 'ネ') { byteList.Add(0xCC); }
                if (c == 'ノ') { byteList.Add(0xCD); }
                if (c == 'ハ') { byteList.Add(0xCE); }
                if (c == 'バ') { byteList.Add(0xCF); }
                if (c == 'パ') { byteList.Add(0xD0); }
                if (c == 'ヒ') { byteList.Add(0xD1); }
                if (c == 'ビ') { byteList.Add(0xD2); }
                if (c == 'ピ') { byteList.Add(0xD3); }
                if (c == 'フ') { byteList.Add(0xD4); }
                if (c == 'ブ') { byteList.Add(0xD5); }
                if (c == 'プ') { byteList.Add(0xD6); }
                if (c == 'ヘ') { byteList.Add(0xD7); }
                if (c == 'ベ') { byteList.Add(0xD8); }
                if (c == 'ペ') { byteList.Add(0xD9); }
                if (c == 'ホ') { byteList.Add(0xDA); }
                if (c == 'ボ') { byteList.Add(0xDB); }
                if (c == 'ポ') { byteList.Add(0xDC); }
                if (c == 'マ') { byteList.Add(0xDD); }
                if (c == 'ミ') { byteList.Add(0xDE); }
                if (c == 'ム') { byteList.Add(0xDF); }
                if (c == 'メ') { byteList.Add(0xE0); }
                if (c == 'モ') { byteList.Add(0xE1); }
                if (c == 'ャ') { byteList.Add(0xE2); }
                if (c == 'ヤ') { byteList.Add(0xE3); }
                if (c == 'ュ') { byteList.Add(0xE4); }
                if (c == 'ユ') { byteList.Add(0xE5); }
                if (c == 'ョ') { byteList.Add(0xE6); }
                if (c == 'ヨ') { byteList.Add(0xE7); }
                if (c == 'ラ') { byteList.Add(0xE8); }
                if (c == 'リ') { byteList.Add(0xE9); }
                if (c == 'ル') { byteList.Add(0xEA); }
                if (c == 'レ') { byteList.Add(0xEB); }
                if (c == 'ロ') { byteList.Add(0xEC); }
                if (c == 'ヮ') { byteList.Add(0xED); }
                if (c == 'ワ') { byteList.Add(0xEE); }
                if (c == 'ﾞ') { byteList.Add(0xEF); }
                if (c == 'ﾟ') { byteList.Add(0xF0); }
                if (c == 'ヲ') { byteList.Add(0xF1); }
                if (c == 'ン') { byteList.Add(0xF2); }
                if (c == '。') { byteList.Add(0xF3); }
                if (c == '、') { byteList.Add(0xF4); }
                if (c == '〒') { byteList.Add(0xF5); }
                if (c == '・') { byteList.Add(0xF6); }
                if (c == '★') { byteList.Add(0xF7); }
                if (c == '♀') { byteList.Add(0xF8); }
                if (c == '♂') { byteList.Add(0xF9); }
                if (c == '♪') { byteList.Add(0xFA); }
                if (c == '…') { byteList.Add(0xFB); }
                if (c == '「') { byteList.Add(0xFC); }
                if (c == '」') { byteList.Add(0xFD); }
                if (c == 'ヴ') { byteList.Add(0xFE); }
            }
            if (byteList.Count < 7) { for (int i = byteList.Count; i < 7; i++) { byteList.Add(0x00); } }
            return byteList.ToArray();
        }

        public static string GetName(byte[] nameBytes)
        {
            string getName = "";

            foreach (byte character in nameBytes)
            {
                if (character == 0x00) { getName += ""; }
                if (character == 0x01) { getName += "!"; }
                if (character == 0x02) { getName += "\""; }
                if (character == 0x03) { getName += "#"; }
                if (character == 0x04) { getName += "$"; }
                if (character == 0x05) { getName += "%"; }
                if (character == 0x06) { getName += "&"; }
                if (character == 0x07) { getName += "\\"; }
                if (character == 0x08) { getName += "("; }
                if (character == 0x09) { getName += ")"; }
                if (character == 0x0A) { getName += "*"; }
                if (character == 0x0B) { getName += "+"; }
                if (character == 0x0C) { getName += ","; }
                if (character == 0x0D) { getName += "-"; }
                if (character == 0x0E) { getName += "."; }
                if (character == 0x0F) { getName += "/"; }
                if (character == 0x10) { getName += "0"; }
                if (character == 0x11) { getName += "1"; }
                if (character == 0x12) { getName += "2"; }
                if (character == 0x13) { getName += "3"; }
                if (character == 0x14) { getName += "4"; }
                if (character == 0x15) { getName += "5"; }
                if (character == 0x16) { getName += "6"; }
                if (character == 0x17) { getName += "7"; }
                if (character == 0x18) { getName += "8"; }
                if (character == 0x19) { getName += "9"; }
                if (character == 0x1A) { getName += ":"; }
                if (character == 0x1B) { getName += ";"; }
                if (character == 0x1C) { getName += "<"; }
                if (character == 0x1D) { getName += "="; }
                if (character == 0x1E) { getName += ">"; }
                if (character == 0x1F) { getName += "?"; }
                if (character == 0x20) { getName += "@"; }
                if (character == 0x21) { getName += "A"; }
                if (character == 0x22) { getName += "B"; }
                if (character == 0x23) { getName += "C"; }
                if (character == 0x24) { getName += "D"; }
                if (character == 0x25) { getName += "E"; }
                if (character == 0x26) { getName += "F"; }
                if (character == 0x27) { getName += "G"; }
                if (character == 0x28) { getName += "H"; }
                if (character == 0x29) { getName += "I"; }
                if (character == 0x2A) { getName += "J"; }
                if (character == 0x2B) { getName += "K"; }
                if (character == 0x2C) { getName += "L"; }
                if (character == 0x2D) { getName += "M"; }
                if (character == 0x2E) { getName += "N"; }
                if (character == 0x2F) { getName += "O"; }
                if (character == 0x30) { getName += "P"; }
                if (character == 0x31) { getName += "Q"; }
                if (character == 0x32) { getName += "R"; }
                if (character == 0x33) { getName += "S"; }
                if (character == 0x34) { getName += "T"; }
                if (character == 0x35) { getName += "U"; }
                if (character == 0x36) { getName += "V"; }
                if (character == 0x37) { getName += "W"; }
                if (character == 0x38) { getName += "X"; }
                if (character == 0x39) { getName += "Y"; }
                if (character == 0x3A) { getName += "Z"; }
                if (character == 0x3B) { getName += "["; }
                if (character == 0x3C) { getName += "¥"; }
                if (character == 0x3D) { getName += "]"; }
                if (character == 0x3E) { getName += "^"; }
                if (character == 0x3F) { getName += "_"; }
                if (character == 0x40) { getName += "‘"; }
                if (character == 0x41) { getName += "a"; }
                if (character == 0x42) { getName += "b"; }
                if (character == 0x43) { getName += "c"; }
                if (character == 0x44) { getName += "d"; }
                if (character == 0x45) { getName += "e"; }
                if (character == 0x46) { getName += "f"; }
                if (character == 0x47) { getName += "g"; }
                if (character == 0x48) { getName += "h"; }
                if (character == 0x49) { getName += "i"; }
                if (character == 0x4A) { getName += "j"; }
                if (character == 0x4B) { getName += "k"; }
                if (character == 0x4C) { getName += "l"; }
                if (character == 0x4D) { getName += "m"; }
                if (character == 0x4E) { getName += "n"; }
                if (character == 0x4F) { getName += "o"; }
                if (character == 0x50) { getName += "p"; }
                if (character == 0x51) { getName += "q"; }
                if (character == 0x52) { getName += "r"; }
                if (character == 0x53) { getName += "s"; }
                if (character == 0x54) { getName += "t"; }
                if (character == 0x55) { getName += "u"; }
                if (character == 0x56) { getName += "v"; }
                if (character == 0x57) { getName += "w"; }
                if (character == 0x58) { getName += "x"; }
                if (character == 0x59) { getName += "y"; }
                if (character == 0x5A) { getName += "z"; }
                if (character == 0x5B) { getName += "{"; }
                if (character == 0x5C) { getName += "|"; }
                if (character == 0x5D) { getName += "}"; }
                if (character == 0x5E) { getName += "~"; }
                if (character == 0x5F) { getName += " "; }
                if (character == 0x60) { getName += "À"; }
                if (character == 0x61) { getName += "Á"; }
                if (character == 0x62) { getName += "Â"; }
                if (character == 0x63) { getName += "Ã"; }
                if (character == 0x64) { getName += "Ä"; }
                if (character == 0x65) { getName += "Å"; }
                if (character == 0x66) { getName += "Æ"; }
                if (character == 0x67) { getName += "Ç"; }
                if (character == 0x68) { getName += "È"; }
                if (character == 0x69) { getName += "É"; }
                if (character == 0x6A) { getName += "Ê"; }
                if (character == 0x6B) { getName += "Ë"; }
                if (character == 0x6C) { getName += "Ì"; }
                if (character == 0x6D) { getName += "Í"; }
                if (character == 0x6E) { getName += "Î"; }
                if (character == 0x6F) { getName += "Ï"; }
                if (character == 0x70) { getName += "Ð"; }
                if (character == 0x71) { getName += "Ñ"; }
                if (character == 0x72) { getName += "Ò"; }
                if (character == 0x73) { getName += "Ó"; }
                if (character == 0x74) { getName += "Ô"; }
                if (character == 0x75) { getName += "Õ"; }
                if (character == 0x76) { getName += "Ö"; }
                if (character == 0x77) { getName += "¿"; }
                if (character == 0x78) { getName += "Ø"; }
                if (character == 0x79) { getName += "Ù"; }
                if (character == 0x7A) { getName += "Ú"; }
                if (character == 0x7B) { getName += "Û"; }
                if (character == 0x7C) { getName += "Ü"; }
                if (character == 0x7D) { getName += "Ý"; }
                if (character == 0x7E) { getName += "Þ"; }
                if (character == 0x7F) { getName += "ß"; }
                if (character == 0x80) { getName += "à"; }
                if (character == 0x81) { getName += "á"; }
                if (character == 0x82) { getName += "â"; }
                if (character == 0x83) { getName += "ã"; }
                if (character == 0x84) { getName += "ä"; }
                if (character == 0x85) { getName += "å"; }
                if (character == 0x86) { getName += "æ"; }
                if (character == 0x87) { getName += "ç"; }
                if (character == 0x88) { getName += "è"; }
                if (character == 0x89) { getName += "é"; }
                if (character == 0x8A) { getName += "ê"; }
                if (character == 0x8B) { getName += "ë"; }
                if (character == 0x8C) { getName += "ì"; }
                if (character == 0x8D) { getName += "í"; }
                if (character == 0x8E) { getName += "î"; }
                if (character == 0x8F) { getName += "ï"; }
                if (character == 0x90) { getName += "ð"; }
                if (character == 0x91) { getName += "ñ"; }
                if (character == 0x92) { getName += "ò"; }
                if (character == 0x93) { getName += "ó"; }
                if (character == 0x94) { getName += "ô"; }
                if (character == 0x95) { getName += "õ"; }
                if (character == 0x96) { getName += "ö"; }
                if (character == 0x97) { getName += "¡"; }
                if (character == 0x98) { getName += "ø"; }
                if (character == 0x99) { getName += "ù"; }
                if (character == 0x9A) { getName += "ú"; }
                if (character == 0x9B) { getName += "û"; }
                if (character == 0x9C) { getName += "ü"; }
                if (character == 0x9D) { getName += "ý"; }
                if (character == 0x9E) { getName += "þ"; }
                if (character == 0x9F) { getName += "ÿ"; }
                if (character == 0xA0) { getName += "ァ"; }
                if (character == 0xA1) { getName += "ア"; }
                if (character == 0xA2) { getName += "ィ"; }
                if (character == 0xA3) { getName += "イ"; }
                if (character == 0xA4) { getName += "ゥ"; }
                if (character == 0xA5) { getName += "ウ"; }
                if (character == 0xA6) { getName += "ェ"; }
                if (character == 0xA7) { getName += "エ"; }
                if (character == 0xA8) { getName += "ォ"; }
                if (character == 0xA9) { getName += "オ"; }
                if (character == 0xAA) { getName += "カ"; }
                if (character == 0xAB) { getName += "ガ"; }
                if (character == 0xAC) { getName += "キ"; }
                if (character == 0xAD) { getName += "ギ"; }
                if (character == 0xAE) { getName += "ク"; }
                if (character == 0xAF) { getName += "グ"; }
                if (character == 0xB0) { getName += "ケ"; }
                if (character == 0xB1) { getName += "ゲ"; }
                if (character == 0xB2) { getName += "コ"; }
                if (character == 0xB3) { getName += "ゴ"; }
                if (character == 0xB4) { getName += "サ"; }
                if (character == 0xB5) { getName += "ザ"; }
                if (character == 0xB6) { getName += "シ"; }
                if (character == 0xB7) { getName += "ジ"; }
                if (character == 0xB8) { getName += "ス"; }
                if (character == 0xB9) { getName += "ズ"; }
                if (character == 0xBA) { getName += "セ"; }
                if (character == 0xBB) { getName += "ゼ"; }
                if (character == 0xBC) { getName += "ソ"; }
                if (character == 0xBD) { getName += "ゾ"; }
                if (character == 0xBE) { getName += "タ"; }
                if (character == 0xBF) { getName += "ダ"; }
                if (character == 0xC0) { getName += "チ"; }
                if (character == 0xC1) { getName += "ヂ"; }
                if (character == 0xC2) { getName += "ツ"; }
                if (character == 0xC3) { getName += "ッ"; }
                if (character == 0xC4) { getName += "ヅ"; }
                if (character == 0xC5) { getName += "テ"; }
                if (character == 0xC6) { getName += "デ"; }
                if (character == 0xC7) { getName += "ト"; }
                if (character == 0xC8) { getName += "ド"; }
                if (character == 0xC9) { getName += "ナ"; }
                if (character == 0xCA) { getName += "ニ"; }
                if (character == 0xCB) { getName += "ヌ"; }
                if (character == 0xCC) { getName += "ネ"; }
                if (character == 0xCD) { getName += "ノ"; }
                if (character == 0xCE) { getName += "ハ"; }
                if (character == 0xCF) { getName += "バ"; }
                if (character == 0xD0) { getName += "パ"; }
                if (character == 0xD1) { getName += "ヒ"; }
                if (character == 0xD2) { getName += "ビ"; }
                if (character == 0xD3) { getName += "ピ"; }
                if (character == 0xD4) { getName += "フ"; }
                if (character == 0xD5) { getName += "ブ"; }
                if (character == 0xD6) { getName += "プ"; }
                if (character == 0xD7) { getName += "ヘ"; }
                if (character == 0xD8) { getName += "ベ"; }
                if (character == 0xD9) { getName += "ペ"; }
                if (character == 0xDA) { getName += "ホ"; }
                if (character == 0xDB) { getName += "ボ"; }
                if (character == 0xDC) { getName += "ポ"; }
                if (character == 0xDD) { getName += "マ"; }
                if (character == 0xDE) { getName += "ミ"; }
                if (character == 0xDF) { getName += "ム"; }
                if (character == 0xE0) { getName += "メ"; }
                if (character == 0xE1) { getName += "モ"; }
                if (character == 0xE2) { getName += "ャ"; }
                if (character == 0xE3) { getName += "ヤ"; }
                if (character == 0xE4) { getName += "ュ"; }
                if (character == 0xE5) { getName += "ユ"; }
                if (character == 0xE6) { getName += "ョ"; }
                if (character == 0xE7) { getName += "ヨ"; }
                if (character == 0xE8) { getName += "ラ"; }
                if (character == 0xE9) { getName += "リ"; }
                if (character == 0xEA) { getName += "ル"; }
                if (character == 0xEB) { getName += "レ"; }
                if (character == 0xEC) { getName += "ロ"; }
                if (character == 0xED) { getName += "ヮ"; }
                if (character == 0xEE) { getName += "ワ"; }
                if (character == 0xEF) { getName += "ﾞ"; }
                if (character == 0xF0) { getName += "ﾟ"; }
                if (character == 0xF1) { getName += "ヲ"; }
                if (character == 0xF2) { getName += "ン"; }
                if (character == 0xF3) { getName += "。"; }
                if (character == 0xF4) { getName += "、"; }
                if (character == 0xF5) { getName += "〒"; }
                if (character == 0xF6) { getName += "・"; }
                if (character == 0xF7) { getName += "★"; }
                if (character == 0xF8) { getName += "♀"; }
                if (character == 0xF9) { getName += "♂"; }
                if (character == 0xFA) { getName += "♪"; }
                if (character == 0xFB) { getName += "…"; }
                if (character == 0xFC) { getName += "「"; }
                if (character == 0xFD) { getName += "」"; }
                if (character == 0xFE) { getName += "ヴ"; }
                if (character == 0xFF) { getName += " "; }
            }
            return getName;
        }
    }
}
