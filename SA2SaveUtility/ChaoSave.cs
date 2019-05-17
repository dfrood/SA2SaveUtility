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

        public static void UpdateChao(TabControl tc, KeyValuePair<uint, TabPage> currentChao, byte[] chao)
        {
            byte[] nameBytes = chao.Skip(Convert.ToInt32(offsets.chao.Name)).Take(7).ToArray();
            string name = GetName(nameBytes);
            int garden = (int)(chao[offsets.chao.Garden] - 1);
            int happiness = 0;
            if (Main.saveIsPC) { happiness = BitConverter.ToInt16(chao.Skip(Convert.ToInt16(offsets.chao.Happiness)).Take(2).ToArray(), 0); }
            else { happiness = BitConverter.ToInt16(chao.Skip(Convert.ToInt16(offsets.chao.Happiness)).Take(2).Reverse().ToArray(), 0); }
            int lifespan1 = 0;
            if (Main.saveIsPC) { lifespan1 = BitConverter.ToInt16(chao.Skip(Convert.ToInt16(offsets.chao.Lifespan1)).Take(2).ToArray(), 0); }
            else { lifespan1 = BitConverter.ToInt16(chao.Skip(Convert.ToInt16(offsets.chao.Lifespan1)).Take(2).Reverse().ToArray(), 0); }
            int lifespan2 = 0;
            if (Main.saveIsPC) { lifespan2 = BitConverter.ToInt16(chao.Skip(Convert.ToInt16(offsets.chao.Lifespan2)).Take(2).ToArray(), 0); }
            else { lifespan2 = BitConverter.ToInt16(chao.Skip(Convert.ToInt16(offsets.chao.Lifespan2)).Take(2).Reverse().ToArray(), 0); }
            uint reincarnations = 0;
            if (Main.saveIsPC) { reincarnations = BitConverter.ToUInt16(chao.Skip(Convert.ToUInt16(offsets.chao.Reincarnations)).Take(2).ToArray(), 0); }
            else { reincarnations = BitConverter.ToUInt16(chao.Skip(Convert.ToUInt16(offsets.chao.Reincarnations)).Take(2).Reverse().ToArray(), 0); }
            Toys toys = 0;
            if (Main.saveIsPC) { toys = (Toys)Enum.Parse(typeof(Toys), BitConverter.ToUInt32(chao.Skip(Convert.ToInt32(offsets.chao.SA2Toys)).Take(4).ToArray(), 0).ToString()); }
            else { toys = (Toys)Enum.Parse(typeof(Toys), BitConverter.ToUInt32(chao.Skip(Convert.ToInt32(offsets.chao.SA2Toys)).Take(4).Reverse().ToArray(), 0).ToString()); }
            AnimalBehaviours animalBehaviours = 0;
            if (Main.saveIsPC) { animalBehaviours = (AnimalBehaviours)Enum.Parse(typeof(AnimalBehaviours), BitConverter.ToUInt32(chao.Skip(Convert.ToInt32(offsets.chao.SA2AnimalBehaviours)).Take(4).ToArray(), 0).ToString()); }
            else { animalBehaviours = (AnimalBehaviours)Enum.Parse(typeof(AnimalBehaviours), BitConverter.ToUInt32(chao.Skip(Convert.ToInt32(offsets.chao.SA2AnimalBehaviours)).Take(4).Reverse().ToArray(), 0).ToString()); }
            ClassroomSkills classroomSkills = (ClassroomSkills)Enum.Parse(typeof(ClassroomSkills), BitConverter.ToInt32(chao.Skip(Convert.ToInt32(offsets.chao.SA2ClassroomSkills)).Take(4).ToArray(), 0).ToString());


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
            if (Main.saveIsPC) { swimPoints = BitConverter.ToUInt16(chao.Skip(Convert.ToUInt16(offsets.chao.SwimPoints)).Take(2).ToArray(), 0); }
            else { swimPoints = BitConverter.ToUInt16(chao.Skip(Convert.ToUInt16(offsets.chao.SwimPoints)).Take(2).Reverse().ToArray(), 0); }
            uint flyPoints = 0;
            if (Main.saveIsPC) { flyPoints = BitConverter.ToUInt16(chao.Skip(Convert.ToUInt16(offsets.chao.FlyPoints)).Take(2).ToArray(), 0); }
            else { flyPoints = BitConverter.ToUInt16(chao.Skip(Convert.ToUInt16(offsets.chao.FlyPoints)).Take(2).Reverse().ToArray(), 0); }
            uint runPoints = 0;
            if (Main.saveIsPC) { runPoints = BitConverter.ToUInt16(chao.Skip(Convert.ToUInt16(offsets.chao.RunPoints)).Take(2).ToArray(), 0); }
            else { runPoints = BitConverter.ToUInt16(chao.Skip(Convert.ToUInt16(offsets.chao.RunPoints)).Take(2).Reverse().ToArray(), 0); }
            uint powerPoints = 0;
            if (Main.saveIsPC) { powerPoints = BitConverter.ToUInt16(chao.Skip(Convert.ToUInt16(offsets.chao.PowerPoints)).Take(2).ToArray(), 0); }
            else { powerPoints = BitConverter.ToUInt16(chao.Skip(Convert.ToUInt16(offsets.chao.PowerPoints)).Take(2).Reverse().ToArray(), 0); }
            uint staminaPoints = 0;
            if (Main.saveIsPC) { staminaPoints = BitConverter.ToUInt16(chao.Skip(Convert.ToUInt16(offsets.chao.StaminaPoints)).Take(2).ToArray(), 0); }
            else { staminaPoints = BitConverter.ToUInt16(chao.Skip(Convert.ToUInt16(offsets.chao.StaminaPoints)).Take(2).Reverse().ToArray(), 0); }
            uint luckPoints = 0;
            if (Main.saveIsPC) { luckPoints = BitConverter.ToUInt16(chao.Skip(Convert.ToUInt16(offsets.chao.LuckPoints)).Take(2).ToArray(), 0); }
            else { luckPoints = BitConverter.ToUInt16(chao.Skip(Convert.ToUInt16(offsets.chao.LuckPoints)).Take(2).Reverse().ToArray(), 0); }
            uint intelligencePoints = 0;
            if (Main.saveIsPC) { intelligencePoints = BitConverter.ToUInt16(chao.Skip(Convert.ToUInt16(offsets.chao.IntelligencePoints)).Take(2).ToArray(), 0); }
            else { intelligencePoints = BitConverter.ToUInt16(chao.Skip(Convert.ToUInt16(offsets.chao.IntelligencePoints)).Take(2).Reverse().ToArray(), 0); }

            int swimGrade = (int)chao[offsets.chao.SwimGrade];
            int flyGrade = (int)chao[offsets.chao.FlyGrade];
            int runGrade = (int)chao[offsets.chao.RunGrade];
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
            float alignment = 0;
            if (Main.saveIsPC) { alignment = BitConverter.ToSingle(chao.Skip(Convert.ToInt32(offsets.chao.Alignment)).Take(4).ToArray(), 0); }
            else { alignment = BitConverter.ToSingle(chao.Skip(Convert.ToInt32(offsets.chao.Alignment)).Take(4).Reverse().ToArray(), 0); }
            float run2Power = 0;
            if (Main.saveIsPC) { run2Power = BitConverter.ToSingle(chao.Skip(Convert.ToInt32(offsets.chao.Run2PowerTranformation)).Take(4).ToArray(), 0); }
            else { run2Power = BitConverter.ToSingle(chao.Skip(Convert.ToInt32(offsets.chao.Run2PowerTranformation)).Take(4).Reverse().ToArray(), 0); }
            float swim2Fly = 0;
            if (Main.saveIsPC) { swim2Fly = BitConverter.ToSingle(chao.Skip(Convert.ToInt32(offsets.chao.Swim2FlyTransformation)).Take(4).ToArray(), 0); }
            else { swim2Fly = BitConverter.ToSingle(chao.Skip(Convert.ToInt32(offsets.chao.Swim2FlyTransformation)).Take(4).Reverse().ToArray(), 0); }
            float transformationMagnitude = 0;
            if (Main.saveIsPC) { transformationMagnitude = BitConverter.ToSingle(chao.Skip(Convert.ToInt32(offsets.chao.TransformationMagnitude)).Take(4).ToArray(), 0); }
            else { transformationMagnitude = BitConverter.ToSingle(chao.Skip(Convert.ToInt32(offsets.chao.TransformationMagnitude)).Take(4).Reverse().ToArray(), 0); }


            int desireToMate = 0;
            if (Main.saveIsPC) { desireToMate = BitConverter.ToInt16(chao.Skip(Convert.ToInt16(offsets.chao.DesireToMate)).Take(2).ToArray(), 0); }
            else { desireToMate = BitConverter.ToInt16(chao.Skip(Convert.ToInt16(offsets.chao.DesireToMate)).Take(2).Reverse().ToArray(), 0); }
            int hunger = 0;
            if (Main.saveIsPC) { hunger = BitConverter.ToInt16(chao.Skip(Convert.ToInt16(offsets.chao.Hunger)).Take(2).ToArray(), 0); }
            else { hunger = BitConverter.ToInt16(chao.Skip(Convert.ToInt16(offsets.chao.Hunger)).Take(2).Reverse().ToArray(), 0); }
            int sleepiness = 0;
            if (Main.saveIsPC) { sleepiness = BitConverter.ToInt16(chao.Skip(Convert.ToInt16(offsets.chao.Sleepiness)).Take(2).ToArray(), 0); }
            else { sleepiness = BitConverter.ToInt16(chao.Skip(Convert.ToInt16(offsets.chao.Sleepiness)).Take(2).Reverse().ToArray(), 0); }
            int tiredness = 0;
            if (Main.saveIsPC) { tiredness = BitConverter.ToInt16(chao.Skip(Convert.ToInt16(offsets.chao.Tiredness)).Take(2).ToArray(), 0); }
            else { tiredness = BitConverter.ToInt16(chao.Skip(Convert.ToInt16(offsets.chao.Tiredness)).Take(2).Reverse().ToArray(), 0); }
            int boredom = 0;
            if (Main.saveIsPC) { boredom = BitConverter.ToInt16(chao.Skip(Convert.ToInt16(offsets.chao.Boredom)).Take(2).ToArray(), 0); }
            else { boredom = BitConverter.ToInt16(chao.Skip(Convert.ToInt16(offsets.chao.Boredom)).Take(2).Reverse().ToArray(), 0); }
            int energy = 0;
            if (Main.saveIsPC) { energy = BitConverter.ToInt16(chao.Skip(Convert.ToInt16(offsets.chao.Energy)).Take(2).ToArray(), 0); }
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
            int powerDNAGrade1 = (int)chao[offsets.chao.DNAPowerGrade1];
            int staminaDNAGrade1 = (int)chao[offsets.chao.DNAStaminaGrade1];
            int luckDNAGrade1 = (int)chao[offsets.chao.DNALuckGrade1];
            int intelligenceDNAGrade1 = (int)chao[offsets.chao.DNAIntelligenceGrade1];
            int swimDNAGrade2 = (int)chao[offsets.chao.DNASwimGrade2];
            int flyDNAGrade2 = (int)chao[offsets.chao.DNAFlyGrade2];
            int runDNAGrade2 = (int)chao[offsets.chao.DNARunGrade2];
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

            Control.ControlCollection controls = tc.TabPages[tc.TabPages.IndexOf(currentChao.Value)].Controls[0].Controls[0].Controls;

            //Tab Name
            if (tc.TabPages[tc.TabPages.IndexOf(currentChao.Value)].Text != name) { tc.TabPages[tc.TabPages.IndexOf(currentChao.Value)].Text = name; }

            //General
            foreach (TextBox tb in controls[0].Controls.OfType<TextBox>())
            {
                if (tb.Name == "tb_Name" && tb.Text != name) { tb.Text = name; }
            }
            foreach (ComboBox cb in controls[0].Controls.OfType<ComboBox>())
            {
                if (cb.Name == "cb_Garden" && cb.SelectedIndex != garden) { cb.SelectedIndex = garden; }
            }
            foreach (NumericUpDown nud in controls[0].Controls.OfType<NumericUpDown>())
            {
                if (nud.Name == "nud_Happiness" && (int)nud.Value != happiness) { nud.Value = happiness; }
                if (nud.Name == "nud_Reincarnations" && nud.Value != reincarnations) { nud.Value = reincarnations; }
            }

            foreach (CheckBox checkb in controls[0].Controls.OfType<GroupBox>().Where(x => x.Name == "gb_Toys").First().Controls.OfType<CheckBox>())
            {
                if (checkb.Name == "checkb_Rattle" && checkb.Checked != ((toys & Toys.Rattle) == Toys.Rattle)) { checkb.Checked = (toys & Toys.Rattle) == Toys.Rattle; }
                if (checkb.Name == "checkb_Car" && checkb.Checked != ((toys & Toys.Car) == Toys.Car)) { checkb.Checked = (toys & Toys.Car) == Toys.Car; }
                if (checkb.Name == "checkb_PictureBook" && checkb.Checked != ((toys & Toys.PictureBook) == Toys.PictureBook)) { checkb.Checked = (toys & Toys.PictureBook) == Toys.PictureBook; }
                if (checkb.Name == "checkb_SonicDoll" && checkb.Checked != ((toys & Toys.SonicDoll) == Toys.SonicDoll)) { checkb.Checked = (toys & Toys.SonicDoll) == Toys.SonicDoll; }
                if (checkb.Name == "checkb_Broomstick" && checkb.Checked != ((toys & Toys.Broomstick) == Toys.Broomstick)) { checkb.Checked = (toys & Toys.Broomstick) == Toys.Broomstick; }
                if (checkb.Name == "checkb_Glitch" && checkb.Checked != ((toys & Toys.Glitch) == Toys.Glitch)) { checkb.Checked = (toys & Toys.Glitch) == Toys.Glitch; }
                if (checkb.Name == "checkb_PogoStick" && checkb.Checked != ((toys & Toys.PogoStick) == Toys.PogoStick)) { checkb.Checked = (toys & Toys.PogoStick) == Toys.PogoStick; }
                if (checkb.Name == "checkb_Crayons" && checkb.Checked != ((toys & Toys.Crayons) == Toys.Crayons)) { checkb.Checked = (toys & Toys.Crayons) == Toys.Crayons; }
                if (checkb.Name == "checkb_BubbleWand" && checkb.Checked != ((toys & Toys.BubbleWand) == Toys.BubbleWand)) { checkb.Checked = (toys & Toys.BubbleWand) == Toys.BubbleWand; }
                if (checkb.Name == "checkb_Shovel" && checkb.Checked != ((toys & Toys.Shovel) == Toys.Shovel)) { checkb.Checked = (toys & Toys.Shovel) == Toys.Shovel; }
                if (checkb.Name == "checkb_WateringCan" && checkb.Checked != ((toys & Toys.WateringCan) == Toys.WateringCan)) { checkb.Checked = (toys & Toys.WateringCan) == Toys.WateringCan; }
            }
            foreach (CheckBox checkb in controls[0].Controls.OfType<GroupBox>().Where(x => x.Name == "gb_AnimalBehaviours").First().Controls.OfType<CheckBox>())
            {
                if (checkb.Name == "checkb_Penguin" && checkb.Checked != ((animalBehaviours & AnimalBehaviours.Penguin) == AnimalBehaviours.Penguin)) { checkb.Checked = (animalBehaviours & AnimalBehaviours.Penguin) == AnimalBehaviours.Penguin; }
                if (checkb.Name == "checkb_Seal" && checkb.Checked != ((animalBehaviours & AnimalBehaviours.Seal) == AnimalBehaviours.Seal)) { checkb.Checked = (animalBehaviours & AnimalBehaviours.Seal) == AnimalBehaviours.Seal; }
                if (checkb.Name == "checkb_Otter" && checkb.Checked != ((animalBehaviours & AnimalBehaviours.Otter) == AnimalBehaviours.Otter)) { checkb.Checked = (animalBehaviours & AnimalBehaviours.Otter) == AnimalBehaviours.Otter; }
                if (checkb.Name == "checkb_Rabbit" && checkb.Checked != ((animalBehaviours & AnimalBehaviours.Rabbit) == AnimalBehaviours.Rabbit)) { checkb.Checked = (animalBehaviours & AnimalBehaviours.Rabbit) == AnimalBehaviours.Rabbit; }
                if (checkb.Name == "checkb_Cheetah" && checkb.Checked != ((animalBehaviours & AnimalBehaviours.Cheetah) == AnimalBehaviours.Cheetah)) { checkb.Checked = (animalBehaviours & AnimalBehaviours.Cheetah) == AnimalBehaviours.Cheetah; }
                if (checkb.Name == "checkb_Warthog" && checkb.Checked != ((animalBehaviours & AnimalBehaviours.Warthog) == AnimalBehaviours.Warthog)) { checkb.Checked = (animalBehaviours & AnimalBehaviours.Warthog) == AnimalBehaviours.Warthog; }
                if (checkb.Name == "checkb_Bear" && checkb.Checked != ((animalBehaviours & AnimalBehaviours.Bear) == AnimalBehaviours.Bear)) { checkb.Checked = (animalBehaviours & AnimalBehaviours.Bear) == AnimalBehaviours.Bear; }
                if (checkb.Name == "checkb_Tiger" && checkb.Checked != ((animalBehaviours & AnimalBehaviours.Tiger) == AnimalBehaviours.Tiger)) { checkb.Checked = (animalBehaviours & AnimalBehaviours.Tiger) == AnimalBehaviours.Tiger; }
                if (checkb.Name == "checkb_Gorilla" && checkb.Checked != ((animalBehaviours & AnimalBehaviours.Gorilla) == AnimalBehaviours.Gorilla)) { checkb.Checked = (animalBehaviours & AnimalBehaviours.Gorilla) == AnimalBehaviours.Gorilla; }
                if (checkb.Name == "checkb_Peacock" && checkb.Checked != ((animalBehaviours & AnimalBehaviours.Peacock) == AnimalBehaviours.Peacock)) { checkb.Checked = (animalBehaviours & AnimalBehaviours.Peacock) == AnimalBehaviours.Peacock; }
                if (checkb.Name == "checkb_Parrot" && checkb.Checked != ((animalBehaviours & AnimalBehaviours.Parrot) == AnimalBehaviours.Parrot)) { checkb.Checked = (animalBehaviours & AnimalBehaviours.Parrot) == AnimalBehaviours.Parrot; }
                if (checkb.Name == "checkb_Condor" && checkb.Checked != ((animalBehaviours & AnimalBehaviours.Condor) == AnimalBehaviours.Condor)) { checkb.Checked = (animalBehaviours & AnimalBehaviours.Condor) == AnimalBehaviours.Condor; }
                if (checkb.Name == "checkb_Skunk" && checkb.Checked != ((animalBehaviours & AnimalBehaviours.Skunk) == AnimalBehaviours.Skunk)) { checkb.Checked = (animalBehaviours & AnimalBehaviours.Skunk) == AnimalBehaviours.Skunk; }
                if (checkb.Name == "checkb_Sheep" && checkb.Checked != ((animalBehaviours & AnimalBehaviours.Sheep) == AnimalBehaviours.Sheep)) { checkb.Checked = (animalBehaviours & AnimalBehaviours.Sheep) == AnimalBehaviours.Sheep; }
                if (checkb.Name == "checkb_Raccoon" && checkb.Checked != ((animalBehaviours & AnimalBehaviours.Raccoon) == AnimalBehaviours.Raccoon)) { checkb.Checked = (animalBehaviours & AnimalBehaviours.Raccoon) == AnimalBehaviours.Raccoon; }
                if (checkb.Name == "checkb_HalfFish" && checkb.Checked != ((animalBehaviours & AnimalBehaviours.HalfFish) == AnimalBehaviours.HalfFish)) { checkb.Checked = (animalBehaviours & AnimalBehaviours.HalfFish) == AnimalBehaviours.HalfFish; }
                if (checkb.Name == "checkb_SkeletonDog" && checkb.Checked != ((animalBehaviours & AnimalBehaviours.SkeletonDog) == AnimalBehaviours.SkeletonDog)) { checkb.Checked = (animalBehaviours & AnimalBehaviours.SkeletonDog) == AnimalBehaviours.SkeletonDog; }
                if (checkb.Name == "checkb_Bat" && checkb.Checked != ((animalBehaviours & AnimalBehaviours.Bat) == AnimalBehaviours.Bat)) { checkb.Checked = (animalBehaviours & AnimalBehaviours.Bat) == AnimalBehaviours.Bat; }
                if (checkb.Name == "checkb_Dragon" && checkb.Checked != ((animalBehaviours & AnimalBehaviours.Dragon) == AnimalBehaviours.Dragon)) { checkb.Checked = (animalBehaviours & AnimalBehaviours.Dragon) == AnimalBehaviours.Dragon; }
                if (checkb.Name == "checkb_Unicorn" && checkb.Checked != ((animalBehaviours & AnimalBehaviours.Unicorn) == AnimalBehaviours.Unicorn)) { checkb.Checked = (animalBehaviours & AnimalBehaviours.Unicorn) == AnimalBehaviours.Unicorn; }
                if (checkb.Name == "checkb_Phoenix" && checkb.Checked != ((animalBehaviours & AnimalBehaviours.Phoenix) == AnimalBehaviours.Phoenix)) { checkb.Checked = (animalBehaviours & AnimalBehaviours.Phoenix) == AnimalBehaviours.Phoenix; }
            }
            foreach (CheckBox checkb in controls[0].Controls.OfType<GroupBox>().Where(x => x.Name == "gb_ClassroomSkills").First().Controls.OfType<CheckBox>())
            {
                if (checkb.Name == "checkb_Drawing1" && checkb.Checked != ((classroomSkills & ClassroomSkills.Drawing1) == ClassroomSkills.Drawing1)) { checkb.Checked = (classroomSkills & ClassroomSkills.Drawing1) == ClassroomSkills.Drawing1; }
                if (checkb.Name == "checkb_Drawing2" && checkb.Checked != ((classroomSkills & ClassroomSkills.Drawing2) == ClassroomSkills.Drawing2)) { checkb.Checked = (classroomSkills & ClassroomSkills.Drawing2) == ClassroomSkills.Drawing2; }
                if (checkb.Name == "checkb_Drawing3" && checkb.Checked != ((classroomSkills & ClassroomSkills.Drawing3) == ClassroomSkills.Drawing3)) { checkb.Checked = (classroomSkills & ClassroomSkills.Drawing3) == ClassroomSkills.Drawing3; }
                if (checkb.Name == "checkb_Drawing4" && checkb.Checked != ((classroomSkills & ClassroomSkills.Drawing4) == ClassroomSkills.Drawing4)) { checkb.Checked = (classroomSkills & ClassroomSkills.Drawing4) == ClassroomSkills.Drawing4; }
                if (checkb.Name == "checkb_Drawing5" && checkb.Checked != ((classroomSkills & ClassroomSkills.Drawing5) == ClassroomSkills.Drawing5)) { checkb.Checked = (classroomSkills & ClassroomSkills.Drawing5) == ClassroomSkills.Drawing5; }
                if (checkb.Name == "checkb_ShakeDance" && checkb.Checked != ((classroomSkills & ClassroomSkills.Shake) == ClassroomSkills.Shake)) { checkb.Checked = (classroomSkills & ClassroomSkills.Shake) == ClassroomSkills.Shake; }
                if (checkb.Name == "checkb_SpinDance" && checkb.Checked != ((classroomSkills & ClassroomSkills.Spin) == ClassroomSkills.Spin)) { checkb.Checked = (classroomSkills & ClassroomSkills.Spin) == ClassroomSkills.Spin; }
                if (checkb.Name == "checkb_StepDance" && checkb.Checked != ((classroomSkills & ClassroomSkills.Step) == ClassroomSkills.Step)) { checkb.Checked = (classroomSkills & ClassroomSkills.Step) == ClassroomSkills.Step; }
                if (checkb.Name == "checkb_GoGoDance" && checkb.Checked != ((classroomSkills & ClassroomSkills.GoGo) == ClassroomSkills.GoGo)) { checkb.Checked = (classroomSkills & ClassroomSkills.GoGo) == ClassroomSkills.GoGo; }
                if (checkb.Name == "checkb_Exercise" && checkb.Checked != ((classroomSkills & ClassroomSkills.Exercise) == ClassroomSkills.Exercise)) { checkb.Checked = (classroomSkills & ClassroomSkills.Exercise) == ClassroomSkills.Exercise; }
                if (checkb.Name == "checkb_Song1" && checkb.Checked != ((classroomSkills & ClassroomSkills.Song1) == ClassroomSkills.Song1)) { checkb.Checked = (classroomSkills & ClassroomSkills.Song1) == ClassroomSkills.Song1; }
                if (checkb.Name == "checkb_Song2" && checkb.Checked != ((classroomSkills & ClassroomSkills.Song2) == ClassroomSkills.Song2)) { checkb.Checked = (classroomSkills & ClassroomSkills.Song2) == ClassroomSkills.Song2; }
                if (checkb.Name == "checkb_Song3" && checkb.Checked != ((classroomSkills & ClassroomSkills.Song3) == ClassroomSkills.Song3)) { checkb.Checked = (classroomSkills & ClassroomSkills.Song3) == ClassroomSkills.Song3; }
                if (checkb.Name == "checkb_Song4" && checkb.Checked != ((classroomSkills & ClassroomSkills.Song4) == ClassroomSkills.Song4)) { checkb.Checked = (classroomSkills & ClassroomSkills.Song4) == ClassroomSkills.Song4; }
                if (checkb.Name == "checkb_Song5" && checkb.Checked != ((classroomSkills & ClassroomSkills.Song5) == ClassroomSkills.Song5)) { checkb.Checked = (classroomSkills & ClassroomSkills.Song5) == ClassroomSkills.Song5; }
                if (checkb.Name == "checkb_Bell" && checkb.Checked != ((classroomSkills & ClassroomSkills.Bell) == ClassroomSkills.Bell)) { checkb.Checked = (classroomSkills & ClassroomSkills.Bell) == ClassroomSkills.Bell; }
                if (checkb.Name == "checkb_Castanets" && checkb.Checked != ((classroomSkills & ClassroomSkills.Castanets) == ClassroomSkills.Castanets)) { checkb.Checked = (classroomSkills & ClassroomSkills.Castanets) == ClassroomSkills.Castanets; }
                if (checkb.Name == "checkb_Cymbals" && checkb.Checked != ((classroomSkills & ClassroomSkills.Cymbals) == ClassroomSkills.Cymbals)) { checkb.Checked = (classroomSkills & ClassroomSkills.Cymbals) == ClassroomSkills.Cymbals; }
                if (checkb.Name == "checkb_Drum" && checkb.Checked != ((classroomSkills & ClassroomSkills.Drum) == ClassroomSkills.Drum)) { checkb.Checked = (classroomSkills & ClassroomSkills.Drum) == ClassroomSkills.Drum; }
                if (checkb.Name == "checkb_Flute" && checkb.Checked != ((classroomSkills & ClassroomSkills.Flute) == ClassroomSkills.Flute)) { checkb.Checked = (classroomSkills & ClassroomSkills.Flute) == ClassroomSkills.Flute; }
                if (checkb.Name == "checkb_Maracas" && checkb.Checked != ((classroomSkills & ClassroomSkills.Maracas) == ClassroomSkills.Maracas)) { checkb.Checked = (classroomSkills & ClassroomSkills.Maracas) == ClassroomSkills.Maracas; }
                if (checkb.Name == "checkb_Trumpet" && checkb.Checked != ((classroomSkills & ClassroomSkills.Trumpet) == ClassroomSkills.Trumpet)) { checkb.Checked = (classroomSkills & ClassroomSkills.Trumpet) == ClassroomSkills.Trumpet; }
                if (checkb.Name == "checkb_Tambourine" && checkb.Checked != ((classroomSkills & ClassroomSkills.Tambourine) == ClassroomSkills.Tambourine)) { checkb.Checked = (classroomSkills & ClassroomSkills.Tambourine) == ClassroomSkills.Tambourine; }
            }

            //Stats
            foreach (NumericUpDown nud in controls[1].Controls.OfType<NumericUpDown>())
            {
                if (nud.Name == "nud_SwimLevel" && nud.Value != swimLevel) { nud.Value = swimLevel; }
                if (nud.Name == "nud_FlyLevel" && nud.Value != flyLevel) { nud.Value = flyLevel; }
                if (nud.Name == "nud_RunLevel" && nud.Value != runLevel) { nud.Value = runLevel; }
                if (nud.Name == "nud_PowerLevel" && nud.Value != powerLevel) { nud.Value = powerLevel; }
                if (nud.Name == "nud_StaminaLevel" && nud.Value != staminaLevel) { nud.Value = staminaLevel; }
                if (nud.Name == "nud_LuckLevel" && nud.Value != luckLevel) { nud.Value = luckLevel; }
                if (nud.Name == "nud_IntelligenceLevel" && nud.Value != intelligenceLevel) { nud.Value = intelligenceLevel; }

                if (nud.Name == "nud_SwimBar" && nud.Value != swimBar) { nud.Value = swimBar; }
                if (nud.Name == "nud_FlyBar" && nud.Value != flyBar) { nud.Value = flyBar; }
                if (nud.Name == "nud_RunBar" && nud.Value != runBar) { nud.Value = runBar; }
                if (nud.Name == "nud_PowerBar" && nud.Value != powerBar) { nud.Value = powerBar; }
                if (nud.Name == "nud_StaminaBar" && nud.Value != staminaBar) { nud.Value = staminaBar; }
                if (nud.Name == "nud_LuckBar" && nud.Value != luckBar) { nud.Value = luckBar; }
                if (nud.Name == "nud_IntelligenceBar" && nud.Value != intelligenceBar) { nud.Value = intelligenceBar; }

                if (nud.Name == "nud_LuckGrade" && nud.Value != luckGrade) { nud.Value = luckGrade; }
                if (nud.Name == "nud_IntelligenceGrade" && nud.Value != intelligenceGrade) { nud.Value = intelligenceGrade; }

                if (nud.Name == "nud_SwimStat" && nud.Value != swimPoints) { nud.Value = swimPoints; }
                if (nud.Name == "nud_FlyStat" && nud.Value != flyPoints) { nud.Value = flyPoints; }
                if (nud.Name == "nud_RunStat" && nud.Value != runPoints) { nud.Value = runPoints; }
                if (nud.Name == "nud_PowerStat" && nud.Value != powerPoints) { nud.Value = powerPoints; }
                if (nud.Name == "nud_StaminaStat" && nud.Value != staminaPoints) { nud.Value = staminaPoints; }
                if (nud.Name == "nud_LuckStat" && nud.Value != luckPoints) { nud.Value = luckPoints; }
                if (nud.Name == "nud_IntelligenceStat" && nud.Value != intelligencePoints) { nud.Value = intelligencePoints; }
            }
            foreach (ComboBox cb in controls[1].Controls.OfType<ComboBox>())
            {
                if (cb.Name == "cb_SwimGrade" && cb.SelectedIndex != swimGrade) { cb.SelectedIndex = swimGrade; }
                if (cb.Name == "cb_FlyGrade" && cb.SelectedIndex != flyGrade) { cb.SelectedIndex = flyGrade; }
                if (cb.Name == "cb_RunGrade" && cb.SelectedIndex != runGrade) { cb.SelectedIndex = runGrade; }
                if (cb.Name == "cb_PowerGrade" && cb.SelectedIndex != powerGrade) { cb.SelectedIndex = powerGrade; }
                if (cb.Name == "cb_StaminaGrade" && cb.SelectedIndex != staminaGrade) { cb.SelectedIndex = staminaGrade; }
            }

            //Appearance
            foreach (ComboBox cb in controls[2].Controls.OfType<ComboBox>())
            {
                if (cb.Name == "cb_Colour" && cb.SelectedIndex != colour) { cb.SelectedIndex = colour; }
                if (cb.Name == "cb_Texture" && cb.SelectedIndex != texture) { cb.SelectedIndex = texture; }
                if (cb.Name == "cb_BodyType" && cb.SelectedIndex != bodyType) { cb.SelectedIndex = bodyType; }
                if (cb.Name == "cb_Hat" && cb.SelectedIndex != hat) { cb.SelectedIndex = hat; }
                if (cb.Name == "cb_Medal" && cb.SelectedIndex != medal) { cb.SelectedIndex = medal; }
                if (cb.Name == "cb_BodyTypeAnimal" && cb.SelectedIndex != bodyTypeAnimal) { cb.SelectedIndex = bodyTypeAnimal; }
                if (cb.Name == "cb_Eyes" && cb.SelectedIndex != eyes) { cb.SelectedIndex = eyes; }
                if (cb.Name == "cb_Emotiball" && cb.SelectedIndex != emotiball) { cb.SelectedIndex = emotiball; }
                if (cb.Name == "cb_Mouth" && cb.SelectedIndex != mouth) { cb.SelectedIndex = mouth; }
                if (cb.Name == "cb_ArmsPart" && cb.SelectedIndex != armsPart)
                {
                    if (armsPart == 0xFF) { cb.SelectedIndex = 0; }
                    if (armsPart != 0xFF) { cb.SelectedIndex = armsPart + 1; }
                }
                if (cb.Name == "cb_EarsPart" && cb.SelectedIndex != earsPart)
                {
                    if (earsPart == 0xFF) { cb.SelectedIndex = 0; }
                    if (earsPart != 0xFF) { cb.SelectedIndex = earsPart + 1; }
                }
                if (cb.Name == "cb_ForeheadPart" && cb.SelectedIndex != foreheadPart)
                {
                    if (foreheadPart == 0xFF) { cb.SelectedIndex = 0; }
                    if (foreheadPart != 0xFF) { cb.SelectedIndex = foreheadPart + 1; }
                }
                if (cb.Name == "cb_HornsPart" && cb.SelectedIndex != hornsPart)
                {
                    if (hornsPart == 0xFF) { cb.SelectedIndex = 0; }
                    if (hornsPart != 0xFF) { cb.SelectedIndex = hornsPart + 1; }
                }
                if (cb.Name == "cb_LegsPart" && cb.SelectedIndex != legsPart)
                {
                    if (legsPart == 0xFF) { cb.SelectedIndex = 0; }
                    if (legsPart != 0xFF) { cb.SelectedIndex = legsPart + 1; }
                }
                if (cb.Name == "cb_TailPart" && cb.SelectedIndex != tailPart)
                {
                    if (tailPart == 0xFF) { cb.SelectedIndex = 0; }
                    if (tailPart != 0xFF) { cb.SelectedIndex = tailPart + 1; }
                }
                if (cb.Name == "cb_WingsPart" && cb.SelectedIndex != wingsPart)
                {
                    if (wingsPart == 0xFF) { cb.SelectedIndex = 0; }
                    if (wingsPart != 0xFF) { cb.SelectedIndex = wingsPart + 1; }
                }
                if (cb.Name == "cb_FacePart" && cb.SelectedIndex != facePart)
                {
                    if (facePart == 0xFF) { cb.SelectedIndex = 0; }
                    if (facePart != 0xFF) { cb.SelectedIndex = facePart + 1; }
                }
                if (cb.Name == "cb_EggColour" && cb.SelectedIndex != eggColour) { cb.SelectedIndex = eggColour; }
            }
            foreach (CheckBox checkb in controls[2].Controls.OfType<CheckBox>())
            {
                if (checkb.Name == "checkb_Shiny" && Convert.ToUInt32(checkb.Checked) != shiny) { checkb.Checked = Convert.ToBoolean(shiny); }
                if (checkb.Name == "checkb_MonoTone" && Convert.ToUInt32(checkb.Checked) != monoTone) { checkb.Checked = Convert.ToBoolean(monoTone); }
                if (checkb.Name == "checkb_FeetHidden" && Convert.ToUInt32(checkb.Checked) != feetHidden) { checkb.Checked = Convert.ToBoolean(feetHidden); }
            }

            //Evolution
            foreach (ComboBox cb in controls[3].Controls.OfType<ComboBox>())
            {
                if (cb.Name == "cb_ChaoType" && cb.SelectedIndex != chaoType)
                {
                    if (chaoType < 3) { chaoType -= 1; }
                    if (chaoType > 2) { chaoType -= 3; }
                    cb.SelectedIndex = chaoType;
                }
            }
            foreach (TrackBar trackb in controls[3].Controls.OfType<TrackBar>())
            {
                if (trackb.Name == "trackb_Alignment" && (float)(trackb.Value * 0.1) != alignment) { trackb.Value = (int)(alignment * 100); }
                if (trackb.Name == "trackb_Run2Power" && (float)(trackb.Value * 0.1) != run2Power) { trackb.Value = (int)(run2Power * 100); }
                if (trackb.Name == "trackb_Swim2Fly" && (float)(trackb.Value * 0.1) != swim2Fly) { trackb.Value = (int)(swim2Fly * 100); }
                if (trackb.Name == "trackb_TransformationMagnitude" && (float)(trackb.Value * 0.1) != transformationMagnitude) { trackb.Value = (int)(transformationMagnitude * 100); }
                if (trackb.Name == "trackb_Lifespan1" && trackb.Value != lifespan1)
                {
                    trackb.Value = lifespan1;
                    if (lifespan1 > lifespan2) { controls[0].Controls.OfType<TrackBar>().Where(x => x.Name == "trackb_Lifespan2").First().Value = lifespan1; }
                }
                if (trackb.Name == "trackb_Lifespan2" && trackb.Value != lifespan2) { trackb.Value = lifespan2; }
            }

            //Emotions
            foreach (TrackBar trackb in controls[4].Controls.OfType<TrackBar>())
            {
                if (trackb.Name == "trackb_DesireToMate" && trackb.Value != desireToMate) { trackb.Value = desireToMate; }
                if (trackb.Name == "trackb_Hunger" && trackb.Value != hunger) { trackb.Value = hunger; }
                if (trackb.Name == "trackb_Sleepiness" && trackb.Value != sleepiness) { trackb.Value = sleepiness; }
                if (trackb.Name == "trackb_Tiredness" && trackb.Value != tiredness) { trackb.Value = tiredness; }
                if (trackb.Name == "trackb_Boredom" && trackb.Value != boredom) { trackb.Value = boredom; }
                if (trackb.Name == "trackb_Energy" && trackb.Value != energy) { trackb.Value = energy; }
                if (trackb.Name == "trackb_Joy" && trackb.Value != joy) { trackb.Value = joy; }
                if (trackb.Name == "trackb_UrgeToCry" && trackb.Value != urgeToCry) { trackb.Value = urgeToCry; }
                if (trackb.Name == "trackb_Fear" && trackb.Value != fear) { trackb.Value = fear; }
                if (trackb.Name == "trackb_Dizziness" && trackb.Value != dizziness) { trackb.Value = dizziness; }
            }

            //Character Bonds
            foreach (TrackBar trackb in controls[5].Controls.OfType<TrackBar>())
            {
                if (trackb.Name == "trackb_SonicBond" && (int)trackb.Value != sonicBond) { trackb.Value = sonicBond; }
                if (trackb.Name == "trackb_TailsBond" && (int)trackb.Value != tailsBond) { trackb.Value = tailsBond; }
                if (trackb.Name == "trackb_KnucklesBond" && (int)trackb.Value != knucklesBond) { trackb.Value = knucklesBond; }
                if (trackb.Name == "trackb_ShadowBond" && (int)trackb.Value != shadowBond) { trackb.Value = shadowBond; }
                if (trackb.Name == "trackb_EggmanBond" && (int)trackb.Value != eggmanBond) { trackb.Value = eggmanBond; }
                if (trackb.Name == "trackb_RougeBond" && (int)trackb.Value != rougeBond) { trackb.Value = rougeBond; }
            }

            //Personality
            foreach (TrackBar trackb in controls[6].Controls.OfType<TrackBar>())
            {
                if (trackb.Name == "trackb_Normal2Curious" && (int)trackb.Value != normal2Curious) { trackb.Value = normal2Curious; }
                if (trackb.Name == "trackb_CryBaby2Energetic" && (int)trackb.Value != cryBaby2Energetic) { trackb.Value = cryBaby2Energetic; }
                if (trackb.Name == "trackb_Naive2Normal" && (int)trackb.Value != naive2Normal) { trackb.Value = naive2Normal; }
                if (trackb.Name == "trackb_Normal2BigEater" && (int)trackb.Value != normal2BigEater) { trackb.Value = normal2BigEater; }
                if (trackb.Name == "trackb_Normal2Carefree" && (int)trackb.Value != normal2Carefree) { trackb.Value = normal2Carefree; }
            }
            foreach (ComboBox cb in controls[6].Controls.OfType<ComboBox>())
            {
                if (cb.Name == "cb_FavouriteFruit" && cb.SelectedIndex != favouriteFruit) { cb.SelectedIndex = favouriteFruit; }
            }

            //Health
            foreach (TrackBar trackb in controls[7].Controls.OfType<TrackBar>())
            {
                if (trackb.Name == "trackb_Cough" && (sbyte)trackb.Value != cough) { trackb.Value = cough; }
                if (trackb.Name == "trackb_Cold" && (sbyte)trackb.Value != cold) { trackb.Value = cold; }
                if (trackb.Name == "trackb_Rash" && (sbyte)trackb.Value != rash) { trackb.Value = rash; }
                if (trackb.Name == "trackb_RunnyNose" && (sbyte)trackb.Value != runnyNose) { trackb.Value = runnyNose; }
                if (trackb.Name == "trackb_Hiccups" && (sbyte)trackb.Value != hiccups) { trackb.Value = hiccups; }
                if (trackb.Name == "trackb_StomachAche" && (sbyte)trackb.Value != stomachAche) { trackb.Value = stomachAche; }
            }

            //DNA
            foreach (ComboBox cb in controls[8].Controls.OfType<ComboBox>())
            {
                if (cb.Name == "cb_Swim1" && cb.SelectedIndex != swimDNAGrade1) { cb.SelectedIndex = swimDNAGrade1; }
                if (cb.Name == "cb_Fly1" && cb.SelectedIndex != flyDNAGrade1) { cb.SelectedIndex = flyDNAGrade1; }
                if (cb.Name == "cb_Run1" && cb.SelectedIndex != runDNAGrade1) { cb.SelectedIndex = runDNAGrade1; }
                if (cb.Name == "cb_Power1" && cb.SelectedIndex != powerDNAGrade1) { cb.SelectedIndex = powerDNAGrade1; }
                if (cb.Name == "cb_Stamina1" && cb.SelectedIndex != staminaDNAGrade1) { cb.SelectedIndex = staminaDNAGrade1; }
                if (cb.Name == "cb_Swim2" && cb.SelectedIndex != swimDNAGrade2) { cb.SelectedIndex = swimDNAGrade2; }
                if (cb.Name == "cb_Fly2" && cb.SelectedIndex != flyDNAGrade2) { cb.SelectedIndex = flyDNAGrade2; }
                if (cb.Name == "cb_Run2" && cb.SelectedIndex != runDNAGrade2) { cb.SelectedIndex = runDNAGrade2; }
                if (cb.Name == "cb_Power2" && cb.SelectedIndex != powerDNAGrade2) { cb.SelectedIndex = powerDNAGrade2; }
                if (cb.Name == "cb_Stamina2" && cb.SelectedIndex != staminaDNAGrade2) { cb.SelectedIndex = staminaDNAGrade2; }
                if (cb.Name == "cb_Fruit1" && cb.SelectedIndex != fruit1) { cb.SelectedIndex = fruit1; }
                if (cb.Name == "cb_Fruit2" && cb.SelectedIndex != fruit2) { cb.SelectedIndex = fruit2; }
                if (cb.Name == "cb_Colour1" && cb.SelectedIndex != colour1) { cb.SelectedIndex = colour1; }
                if (cb.Name == "cb_Colour2" && cb.SelectedIndex != colour2) { cb.SelectedIndex = colour2; }
                if (cb.Name == "cb_EggColour1" && cb.SelectedIndex != eggColour1) { cb.SelectedIndex = eggColour1; }
                if (cb.Name == "cb_EggColour2" && cb.SelectedIndex != eggColour2) { cb.SelectedIndex = eggColour2; }
                if (cb.Name == "cb_Texture1" && cb.SelectedIndex != texture1) { cb.SelectedIndex = texture1; }
                if (cb.Name == "cb_Texture2" && cb.SelectedIndex != texture2) { cb.SelectedIndex = texture2; }
            }
            foreach (NumericUpDown nud in controls[8].Controls.OfType<NumericUpDown>())
            {
                if (nud.Name == "nud_Luck1" && nud.Value != luckDNAGrade1) { nud.Value = luckDNAGrade1; }
                if (nud.Name == "nud_Intelligence1" && nud.Value != intelligenceDNAGrade1) { nud.Value = intelligenceDNAGrade1; }
                if (nud.Name == "nud_Luck2" && nud.Value != luckDNAGrade2) { nud.Value = luckDNAGrade2; }
                if (nud.Name == "nud_Intelligence2" && nud.Value != intelligenceDNAGrade2) { nud.Value = intelligenceDNAGrade2; }
            }
            foreach (CheckBox checkb in controls[8].Controls.OfType<CheckBox>())
            {
                if (checkb.Name == "checkb_Shiny1" && Convert.ToUInt32(checkb.Checked) != shiny1) { checkb.Checked = Convert.ToBoolean(shiny1); }
                if (checkb.Name == "checkb_Shiny2" && Convert.ToUInt32(checkb.Checked) != shiny2) { checkb.Checked = Convert.ToBoolean(shiny2); }
                if (checkb.Name == "checkb_MonoTone1" && Convert.ToUInt32(checkb.Checked) != monoTone1) { checkb.Checked = Convert.ToBoolean(monoTone1); }
                if (checkb.Name == "checkb_MonoTone2" && Convert.ToUInt32(checkb.Checked) != monoTone1) { checkb.Checked = Convert.ToBoolean(monoTone2); }
            }
        }

        public static void GetChao()
        {
            uint chaoIndex = 0;
            foreach (byte[] chao in Main.SplitByteArray(Main.loadedSave.Skip(0x3AA4).Take(0xC000).ToArray(), 0x800))
            {
                byte[] nameBytes = chao.Skip(Convert.ToInt32(offsets.chao.Name)).Take(7).ToArray();
                if (chao[offsets.chao.Garden] != 0 && chao[offsets.chao.Garden] != 255)
                {
                    string name = GetName(nameBytes);
                    if (!activeChao.ContainsKey(chaoIndex))
                    {
                        uc_Chao uc = new uc_Chao();
                        TabPage tp = new TabPage();
                        uc.chaoNumber = chaoIndex;
                        tp.Controls.Add(uc);
                        tp.Text = name;
                        Main.tc_Main.TabPages.Add(tp);
                        if (chaoIndex == 0) { Main.tc_Main.SelectedTab = tp; }
                        activeChao.Add(chaoIndex, tp);
                    }
                    KeyValuePair<uint, TabPage> currentChao = activeChao.Where(x => x.Key == chaoIndex).First();
                    UpdateChao(Main.tc_Main, currentChao, chao);
                }
                else
                {
                    if (activeChao.ContainsKey(chaoIndex))
                    {
                        KeyValuePair<uint, TabPage> currentChao = activeChao.Where(x => x.Key == chaoIndex).First();
                        Main.tc_Main.TabPages.Remove(currentChao.Value);
                        activeChao.Remove(currentChao.Key);

                    }
                }
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

        public static void WriteChecksum(byte[] a1, bool isSA2)
        {
            Random rand = new Random();
            int off = isSA2 ? 0x24C : 0;
            a1[51229 + off] = 0;
            a1[51224 + off] = 0;
            a1[51231 + off] = 0;
            a1[51226 + off] = 0;
            a1[51227 + off] = 0;
            a1[51225 + off] = (byte)BitConverter.DoubleToInt64Bits(rand.NextDouble() * 0.000030517578125 * 255.9998931884766);
            a1[51228 + off] = (byte)BitConverter.DoubleToInt64Bits(rand.NextDouble() * 0.000030517578125 * 255.9998931884766);
            a1[51230 + off] = (byte)BitConverter.DoubleToInt64Bits(rand.NextDouble() * 0.000030517578125 * 255.9998931884766);
            uint v1 = sub_7172B0(51232 + off, a1);
            a1[51229 + off] = (byte)v1;
            a1[51224 + off] = (byte)(v1 >> 8);
            a1[51231 + off] = (byte)(v1 >> 16);
            a1[51226 + off] = (byte)(v1 >> 24);
            a1[51227 + off] = (byte)BitConverter.DoubleToInt64Bits(rand.NextDouble() * 0.000030517578125 * 255.9998931884766);
        }

        static uint sub_7172B0(int length, byte[] data)
        {
            return sub_721B10(data, length, 0x6368616Fu, 0x686F6765u);
        }


        static uint[] dword_884D98 = new uint[] {
            0, 0x0C9073096, 0x920E612C, 0x0A50951BA, 0x0FF6DC419, 0x0CA6AF48F,
            0x9163A535, 0x0A66495A3, 0x0FEDB8832, 0x0CFDCB8A4, 0x94D5E91E,
            0x0A3D2D988, 0x0F9B64C2B, 0x0CCB17CBD, 0x97B82D07, 0x0A0BF1D91,
            0x0FDB71064, 0x0C4B020F2, 0x9FB97148, 0x0A8BE41DE, 0x0F2DAD47D,
            0x0C7DDE4EB, 0x9CD4B551, 0x0ABD385C7, 0x0F36C9856, 0x0C26BA8C0,
            0x9962F97A, 0x0AE65C9EC, 0x0F4015C4F, 0x0C1066CD9, 0x9A0F3D63,
            0x0AD080DF5, 0x0FB6E20C8, 0x0D269105E, 0x896041E4, 0x0BE677172,
            0x0E403E4D1, 0x0D104D447, 0x8A0D85FD, 0x0BD0AB56B, 0x0E5B5A8FA,
            0x0D4B2986C, 0x8FBBC9D6, 0x0B8BCF940, 0x0E2D86CE3, 0x0D7DF5C75,
            0x8CD60DCF, 0x0BBD13D59, 0x0E6D930AC, 0x0DFDE003A, 0x84D75180,
            0x0B3D06116, 0x0E9B4F4B5, 0x0DCB3C423, 0x87BA9599, 0x0B0BDA50F,
            0x0E802B89E, 0x0D9058808, 0x820CD9B2, 0x0B50BE924, 0x0EF6F7C87,
            0x0DA684C11, 0x81611DAB, 0x0B6662D3D, 0x0F6DC4190, 0x0FFDB7106,
            0x0A4D220BC, 0x93D5102A, 0x0C9B18589, 0x0FCB6B51F, 0x0A7BFE4A5,
            0x90B8D433, 0x0C807C9A2, 0x0F900F934, 0x0A209A88E, 0x950E9818,
            0x0CF6A0DBB, 0x0FA6D3D2D, 0x0A1646C97, 0x96635C01, 0x0CB6B51F4,
            0x0F26C6162, 0x0A96530D8, 0x9E62004E, 0x0C40695ED, 0x0F101A57B,
            0x0AA08F4C1, 0x9D0FC457, 0x0C5B0D9C6, 0x0F4B7E950, 0x0AFBEB8EA,
            0x98B9887C, 0x0C2DD1DDF, 0x0F7DA2D49, 0x0ACD37CF3, 0x9BD44C65,
            0x0CDB26158, 0x0E4B551CE, 0x0BFBC0074, 0x88BB30E2, 0x0D2DFA541,
            0x0E7D895D7, 0x0BCD1C46D, 0x8BD6F4FB, 0x0D369E96A, 0x0E26ED9FC,
            0x0B9678846, 0x8E60B8D0, 0x0D4042D73, 0x0E1031DE5, 0x0BA0A4C5F,
            0x8D0D7CC9, 0x0D005713C, 0x0E90241AA, 0x0B20B1010, 0x850C2086,
            0x0DF68B525, 0x0EA6F85B3, 0x0B166D409, 0x8661E49F, 0x0DEDEF90E,
            0x0EFD9C998, 0x0B4D09822, 0x83D7A8B4, 0x0D9B33D17, 0x0ECB40D81,
            0x0B7BD5C3B, 0x80BA6CAD, 0x0EDB88320, 0x0A4BFB3B6, 0x0FFB6E20C,
            0x0C8B1D29A, 0x92D54739, 0x0A7D277AF, 0x0FCDB2615, 0x0CBDC1683,
            0x93630B12, 0x0A2643B84, 0x0F96D6A3E, 0x0CE6A5AA8, 0x940ECF0B,
            0x0A109FF9D, 0x0FA00AE27, 0x0CD079EB1, 0x900F9344, 0x0A908A3D2,
            0x0F201F268, 0x0C506C2FE, 0x9F62575D, 0x0AA6567CB, 0x0F16C3671,
            0x0C66B06E7, 0x9ED41B76, 0x0AFD32BE0, 0x0F4DA7A5A, 0x0C3DD4ACC,
            0x99B9DF6F, 0x0ACBEEFF9, 0x0F7B7BE43, 0x0C0B08ED5, 0x96D6A3E8,
            0x0BFD1937E, 0x0E4D8C2C4, 0x0D3DFF252, 0x89BB67F1, 0x0BCBC5767,
            0x0E7B506DD, 0x0D0B2364B, 0x880D2BDA, 0x0B90A1B4C, 0x0E2034AF6,
            0x0D5047A60, 0x8F60EFC3, 0x0BA67DF55, 0x0E16E8EEF, 0x0D669BE79,
            0x8B61B38C, 0x0B266831A, 0x0E96FD2A0, 0x0DE68E236, 0x840C7795,
            0x0B10B4703, 0x0EA0216B9, 0x0DD05262F, 0x85BA3BBE, 0x0B4BD0B28,
            0x0EFB45A92, 0x0D8B36A04, 0x82D7FFA7, 0x0B7D0CF31, 0x0ECD99E8B,
            0x0DBDEAE1D, 0x9B64C2B0, 0x9263F226, 0x0C96AA39C, 0x0FE6D930A,
            0x0A40906A9, 0x910E363F, 0x0CA076785, 0x0FD005713, 0x0A5BF4A82,
            0x94B87A14, 0x0CFB12BAE, 0x0F8B61B38, 0x0A2D28E9B, 0x97D5BE0D,
            0x0CCDCEFB7, 0x0FBDBDF21, 0x0A6D3D2D4, 0x9FD4E242, 0x0C4DDB3F8,
            0x0F3DA836E, 0x0A9BE16CD, 0x9CB9265B, 0x0C7B077E1, 0x0F0B74777,
            0x0A8085AE6, 0x990F6A70, 0x0C2063BCA, 0x0F5010B5C, 0x0AF659EFF,
            0x9A62AE69, 0x0C16BFFD3, 0x0F66CCF45, 0x0A00AE278, 0x890DD2EE,
            0x0D2048354, 0x0E503B3C2, 0x0BF672661, 0x8A6016F7, 0x0D169474D,
            0x0E66E77DB, 0x0BED16A4A, 0x8FD65ADC, 0x0D4DF0B66, 0x0E3D83BF0,
            0x0B9BCAE53, 0x8CBB9EC5, 0x0D7B2CF7F, 0x0E0B5FFE9, 0x0BDBDF21C,
            0x84BAC28A, 0x0DFB39330, 0x0E8B4A3A6, 0x0B2D03605, 0x87D70693,
            0x0DCDE5729, 0x0EBD967BF, 0x0B3667A2E, 0x82614AB8, 0x0D9681B02,
            0x0EE6F2B94, 0x0B40BBE37, 0x810C8EA1, 0x0DA05DF1B, 0x0ED02EF8D };

        static uint sub_721B10(byte[] data, int length, uint a3, uint a4)
        {
            uint v4; // eax@1
            int v5; // edx@1
            int v6; // ecx@2

            v5 = length;
            v4 = a3;
            if (length > 0)
            {
                v6 = 0;
                do
                {
                    v4 = dword_884D98[data[v6++] ^ (byte)v4] ^ ((uint)v4 >> 8);
                    --v5;
                }
                while (v5 > 0);
            }
            return a4 ^ v4;
        }
    }
}
