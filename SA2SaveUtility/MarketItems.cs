using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SA2SaveUtility
{
    public partial class MarketItems : Form
    {
        public int itemCount { get; set; }
        bool loaded = false;
        private Offsets offsets = new Offsets();

        public List<string> Eggs = new List<string>(new string[]{
            "Normal",
            "Yellow",
            "White",
            "Brown",
            "Sky Blue",
            "Pink",
            "Blue",
            "Grey",
            "Green",
            "Red",
            "Lime Green",
            "Purple",
            "Orange",
            "Black",
            "Yellow Two-Tone",
            "White Two-Tone",
            "Brown Two-Tone",
            "Sky Blue Two-Tone",
            "Pink Two-Tone",
            "Blue Two-Tone",
            "Grey Two-Tone",
            "Green Two-Tone",
            "Red Two-Tone",
            "Lime Green Two-Tone",
            "Purple Two-Tone",
            "Orange Two-Tone",
            "Black Two-Tone",
            "Normal Shiny",
            "Yellow Shiny",
            "White Shiny",
            "Brown Shiny",
            "Sky Blue Shiny",
            "Pink Shiny",
            "Blue Shiny",
            "Grey Shiny",
            "Green Shiny",
            "Red Shiny",
            "Lime Green Shiny",
            "Purple Shiny",
            "Orange Shiny",
            "Black Shiny",
            "Yellow Shiny Two-Tone",
            "White Shiny Two-Tone",
            "Brown Shiny Two-Tone",
            "Sky Blue Shiny Two-Tone",
            "Pink Shiny Two-Tone",
            "Blue Shiny Two-Tone",
            "Grey Shiny Two-Tone",
            "Green Shiny Two-Tone",
            "Red Shiny Two-Tone",
            "Lime Green Shiny Two-Tone",
            "Purple Shiny Two-Tone",
            "Orange Shiny Two-Tone",
            "Black Shiny Two-Tone",
            "Gold",
            "Silver",
            "Ruby",
            "Sapphire",
            "Emerald",
            "Amethyst",
            "Aquamarine",
            "Garnet",
            "Onyx",
            "Peridot",
            "Topaz",
            "Pearl",
            "Metal 1",
            "Metal 2",
            "Glass"});

        public Dictionary<string, int> Fruit = new Dictionary<string, int>()
        {
            { "Chao Garden Fruit", 0 },
            { "Hero Garden Fruit", 1 },
            { "Dark Garden Fruit", 2 },
            { "Strong Fruit", 3 },
            { "Tasty Fruit", 4 },
            { "Hero Fruit", 5 },
            { "Dark Fruit", 6 },
            { "Round Fruit", 7 },
            { "Triangle Fruit", 8 },
            { "Square Fruit", 9 },
            { "Heart Fruit", 10 },
            { "Chao Fruit", 11 },
            { "Mushroom", 20 },
            { "Mushroom (x2 Bonus)", 21 },
            { "Orange Fruit", 13 },
            { "Blue Fruit", 14 },
            { "Pink Fruit", 15 },
            { "Green Fruit", 16 },
            { "Purple Fruit", 17 },
            { "Yellow Fruit", 18 },
            { "Red Fruit", 19 },
            { "Smart Fruit", 12 },
            { "Mint Candy", 22 },
            { "Grapes", 23 }
        };

        public List<string> Seed = new List<string>(new string[]{
            "Strong Seed",
            "Tasty Seed",
            "Hero Seed",
            "Dark Seed",
            "Round Seed",
            "Triangle Seed",
            "Square Seed"
        });

        public List<string> Hat = new List<string>(new string[]{
            "Pumpkin",
            "Skull",
            "Apple",
            "Bucket",
            "Empty Can",
            "Cardboard Box",
            "Flower Pot",
            "Paper Bag",
            "Pan",
            "Stump",
            "Watermelon",
            "Red Wool Beanie",
            "Blue Wool Beanie",
            "Black Wool Beanie",
            "Pacifier",
            "Normal Egg Shell",
            "Yellow Egg Shell",
            "White Egg Shell",
            "Brown Egg Shell",
            "Sky Blue Egg Shell",
            "Pink Egg Shell",
            "Blue Egg Shell",
            "Grey Egg Shell",
            "Green Egg Shell",
            "Red Egg Shell",
            "Lime Green Egg Shell",
            "Purple Egg Shell",
            "Orange Egg Shell",
            "Black Egg Shell",
            "Yellow Two-Tone Egg Shell",
            "White Two-Tone Egg Shell",
            "Brown Two-Tone Egg Shell",
            "Sky Blue Two-Tone Egg Shell",
            "Pink Two-Tone Egg Shell",
            "Blue Two-Tone Egg Shell",
            "Grey Two-Tone Egg Shell",
            "Green Two-Tone Egg Shell",
            "Red Two-Tone Egg Shell",
            "Lime Green Two-Tone Egg Shell",
            "Purple Two-Tone Egg Shell",
            "Orange Two-Tone Egg Shell",
            "Black Two-Tone Egg Shell",
            "Normal Shiny Egg Shell",
            "Yellow Shiny Egg Shell",
            "White Shiny  Egg Shell",
            "Brown Shiny Egg Shell",
            "Sky Blue Shiny Egg Shell",
            "Pink Shiny Egg Shell",
            "Blue Shiny Egg Shell",
            "Grey Shiny Egg Shell",
            "Green Shiny Egg Shell",
            "Red Shiny Egg Shell",
            "Lime Green Shiny Egg Shell",
            "Purple Shiny Egg Shell",
            "Orange Shiny Egg Shell",
            "Black Shiny Egg Shell",
            "Yellow Shiny Two-Tone Egg Shell",
            "White Shiny Two-Tone Egg Shell",
            "Brown Shiny Two-Tone Egg Shell",
            "Sky Blue Shiny Two-Tone Egg Shell",
            "Pink Shiny Two-Tone Egg Shell",
            "Blue Shiny Two-Tone Egg Shell",
            "Grey Shiny Two-Tone Egg Shell",
            "Green Shiny Two-Tone Egg Shell",
            "Red Shiny Two-Tone Egg Shell",
            "Lime Green Shiny Two-Tone Egg Shell",
            "Purple Shiny Two-Tone Egg Shell",
            "Orange Shiny Two-Tone Egg Shell",
            "Black Shiny Two-Tone Egg Shell",
            "Gold Egg Shell",
            "Silver Egg Shell",
            "Ruby Egg Shell",
            "Sapphire Egg Shell",
            "Emerald Egg Shell",
            "Amethyst Egg Shell",
            "Aquamarine Egg Shell",
            "Garnet Egg Shell",
            "Onyx Egg Shell",
            "Peridot Egg Shell",
            "Topaz Egg Shell",
            "Pearl Egg Shell",
            "Metal 1 Egg Shell",
            "Metal 2 Egg Shell",
            "Glass Egg Shell"
        });

        public List<string> Themes = new List<string>(new string[]{
            "Omochao's Theme",
            "Amy's Theme",
            "Maria's Theme"
        });

        public MarketItems()
        {
            InitializeComponent();
            if (Main.saveIsPC) { itemCount = Main.loadedSave[offsets.chaoSave.MarketCount]; }
            else { itemCount = Main.loadedSave[offsets.chaoSave.MarketCount + 3]; }
            switch (Main.loadedSave[offsets.chaoSave.MarketItemsStart])
            {
                case 255:
                    cb_Category1.SelectedIndex = 0;
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 1] = 0;
                    break;
                case 0:
                    cb_Category1.SelectedIndex = 0;
                    break;
                case 1:
                    cb_Category1.SelectedIndex = 0;
                    break;
                case 3:
                    cb_Category1.SelectedIndex = 1;
                    break;
                case 7:
                    cb_Category1.SelectedIndex = 2;
                    break;
                case 9:
                    cb_Category1.SelectedIndex = 3;
                    break;
                case 16:
                    cb_Category1.SelectedIndex = 4;
                    break;
            }
            switch (Main.loadedSave[offsets.chaoSave.MarketItemsStart + 2])
            {
                case 255:
                    cb_Category2.SelectedIndex = 0;
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 3] = 0;
                    break;
                case 0:
                    cb_Category2.SelectedIndex = 0;
                    break;
                case 1:
                    cb_Category2.SelectedIndex = 0;
                    break;
                case 3:
                    cb_Category2.SelectedIndex = 1;
                    break;
                case 7:
                    cb_Category2.SelectedIndex = 2;
                    break;
                case 9:
                    cb_Category2.SelectedIndex = 3;
                    break;
                case 16:
                    cb_Category2.SelectedIndex = 4;
                    break;
            }
            switch (Main.loadedSave[offsets.chaoSave.MarketItemsStart + 4])
            {
                case 255:
                    cb_Category3.SelectedIndex = 0;
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 5] = 0;
                    break;
                case 0:
                    cb_Category3.SelectedIndex = 0;
                    break;
                case 1:
                    cb_Category3.SelectedIndex = 0;
                    break;
                case 3:
                    cb_Category3.SelectedIndex = 1;
                    break;
                case 7:
                    cb_Category3.SelectedIndex = 2;
                    break;
                case 9:
                    cb_Category3.SelectedIndex = 3;
                    break;
                case 16:
                    cb_Category3.SelectedIndex = 4;
                    break;
            }
            switch (Main.loadedSave[offsets.chaoSave.MarketItemsStart + 6])
            {
                case 255:
                    cb_Category4.SelectedIndex = 0;
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 7] = 0;
                    break;
                case 0:
                    cb_Category4.SelectedIndex = 0;
                    break;
                case 1:
                    cb_Category4.SelectedIndex = 0;
                    break;
                case 3:
                    cb_Category4.SelectedIndex = 1;
                    break;
                case 7:
                    cb_Category4.SelectedIndex = 2;
                    break;
                case 9:
                    cb_Category4.SelectedIndex = 3;
                    break;
                case 16:
                    cb_Category4.SelectedIndex = 4;
                    break;
            }
            switch (Main.loadedSave[offsets.chaoSave.MarketItemsStart + 8])
            {
                case 255:
                    cb_Category5.SelectedIndex = 0;
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 9] = 0;
                    break;
                case 0:
                    cb_Category5.SelectedIndex = 0;
                    break;
                case 1:
                    cb_Category5.SelectedIndex = 0;
                    break;
                case 3:
                    cb_Category5.SelectedIndex = 1;
                    break;
                case 7:
                    cb_Category5.SelectedIndex = 2;
                    break;
                case 9:
                    cb_Category5.SelectedIndex = 3;
                    break;
                case 16:
                    cb_Category5.SelectedIndex = 4;
                    break;
            }
            switch (Main.loadedSave[offsets.chaoSave.MarketItemsStart + 10])
            {
                case 255:
                    cb_Category6.SelectedIndex = 0;
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 11] = 0;
                    break;
                case 0:
                    cb_Category6.SelectedIndex = 0;
                    break;
                case 1:
                    cb_Category6.SelectedIndex = 0;
                    break;
                case 3:
                    cb_Category6.SelectedIndex = 1;
                    break;
                case 7:
                    cb_Category6.SelectedIndex = 2;
                    break;
                case 9:
                    cb_Category6.SelectedIndex = 3;
                    break;
                case 16:
                    cb_Category6.SelectedIndex = 4;
                    break;
            }
            switch (Main.loadedSave[offsets.chaoSave.MarketItemsStart + 12])
            {
                case 255:
                    cb_Category7.SelectedIndex = 0;
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 13] = 0;
                    break;
                case 0:
                    cb_Category7.SelectedIndex = 0;
                    break;
                case 1:
                    cb_Category7.SelectedIndex = 0;
                    break;
                case 3:
                    cb_Category7.SelectedIndex = 1;
                    break;
                case 7:
                    cb_Category7.SelectedIndex = 2;
                    break;
                case 9:
                    cb_Category7.SelectedIndex = 3;
                    break;
                case 16:
                    cb_Category7.SelectedIndex = 4;
                    break;
            }
            switch (Main.loadedSave[offsets.chaoSave.MarketItemsStart + 14])
            {
                case 255:
                    cb_Category8.SelectedIndex = 0;
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 15] = 0;
                    break;
                case 0:
                    cb_Category8.SelectedIndex = 0;
                    break;
                case 1:
                    cb_Category8.SelectedIndex = 0;
                    break;
                case 3:
                    cb_Category8.SelectedIndex = 1;
                    break;
                case 7:
                    cb_Category8.SelectedIndex = 2;
                    break;
                case 9:
                    cb_Category8.SelectedIndex = 3;
                    break;
                case 16:
                    cb_Category8.SelectedIndex = 4;
                    break;
            }
            switch (Main.loadedSave[offsets.chaoSave.MarketItemsStart + 16])
            {
                case 255:
                    cb_Category9.SelectedIndex = 0;
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 17] = 0;
                    break;
                case 0:
                    cb_Category9.SelectedIndex = 0;
                    break;
                case 1:
                    cb_Category9.SelectedIndex = 0;
                    break;
                case 3:
                    cb_Category9.SelectedIndex = 1;
                    break;
                case 7:
                    cb_Category9.SelectedIndex = 2;
                    break;
                case 9:
                    cb_Category9.SelectedIndex = 3;
                    break;
                case 16:
                    cb_Category9.SelectedIndex = 4;
                    break;
            }
            switch (Main.loadedSave[offsets.chaoSave.MarketItemsStart + 18])
            {
                case 255:
                    cb_Category10.SelectedIndex = 0;
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 19] = 0;
                    break;
                case 0:
                    cb_Category10.SelectedIndex = 0;
                    break;
                case 1:
                    cb_Category10.SelectedIndex = 0;
                    break;
                case 3:
                    cb_Category10.SelectedIndex = 1;
                    break;
                case 7:
                    cb_Category10.SelectedIndex = 2;
                    break;
                case 9:
                    cb_Category10.SelectedIndex = 3;
                    break;
                case 16:
                    cb_Category10.SelectedIndex = 4;
                    break;
            }
            switch (Main.loadedSave[offsets.chaoSave.MarketItemsStart + 20])
            {
                case 255:
                    cb_Category11.SelectedIndex = 0;
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 21] = 0;
                    break;
                case 0:
                    cb_Category11.SelectedIndex = 0;
                    break;
                case 1:
                    cb_Category11.SelectedIndex = 0;
                    break;
                case 3:
                    cb_Category11.SelectedIndex = 1;
                    break;
                case 7:
                    cb_Category11.SelectedIndex = 2;
                    break;
                case 9:
                    cb_Category11.SelectedIndex = 3;
                    break;
                case 16:
                    cb_Category11.SelectedIndex = 4;
                    break;
            }
            switch (Main.loadedSave[offsets.chaoSave.MarketItemsStart + 22])
            {
                case 255:
                    cb_Category12.SelectedIndex = 0;
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 22] = 0;
                    break;
                case 0:
                    cb_Category12.SelectedIndex = 0;
                    break;
                case 1:
                    cb_Category12.SelectedIndex = 0;
                    break;
                case 3:
                    cb_Category12.SelectedIndex = 1;
                    break;
                case 7:
                    cb_Category12.SelectedIndex = 2;
                    break;
                case 9:
                    cb_Category12.SelectedIndex = 3;
                    break;
                case 16:
                    cb_Category12.SelectedIndex = 4;
                    break;
            }
            switch (Main.loadedSave[offsets.chaoSave.MarketItemsStart + 24])
            {
                case 255:
                    cb_Category13.SelectedIndex = 0;
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 25] = 0;
                    break;
                case 0:
                    cb_Category13.SelectedIndex = 0;
                    break;
                case 1:
                    cb_Category13.SelectedIndex = 0;
                    break;
                case 3:
                    cb_Category13.SelectedIndex = 1;
                    break;
                case 7:
                    cb_Category13.SelectedIndex = 2;
                    break;
                case 9:
                    cb_Category13.SelectedIndex = 3;
                    break;
                case 16:
                    cb_Category13.SelectedIndex = 4;
                    break;
            }
            switch (Main.loadedSave[offsets.chaoSave.MarketItemsStart + 26])
            {
                case 255:
                    cb_Category14.SelectedIndex = 0;
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 27] = 0;
                    break;
                case 0:
                    cb_Category14.SelectedIndex = 0;
                    break;
                case 1:
                    cb_Category14.SelectedIndex = 0;
                    break;
                case 3:
                    cb_Category14.SelectedIndex = 1;
                    break;
                case 7:
                    cb_Category14.SelectedIndex = 2;
                    break;
                case 9:
                    cb_Category14.SelectedIndex = 3;
                    break;
                case 16:
                    cb_Category14.SelectedIndex = 4;
                    break;
            }
            switch (Main.loadedSave[offsets.chaoSave.MarketItemsStart + 28])
            {
                case 255:
                    cb_Category15.SelectedIndex = 0;
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 29] = 0;
                    break;
                case 0:
                    cb_Category15.SelectedIndex = 0;
                    break;
                case 1:
                    cb_Category15.SelectedIndex = 0;
                    break;
                case 3:
                    cb_Category15.SelectedIndex = 1;
                    break;
                case 7:
                    cb_Category15.SelectedIndex = 2;
                    break;
                case 9:
                    cb_Category15.SelectedIndex = 3;
                    break;
                case 16:
                    cb_Category15.SelectedIndex = 4;
                    break;
            }
            switch (Main.loadedSave[offsets.chaoSave.MarketItemsStart + 30])
            {
                case 255:
                    cb_Category16.SelectedIndex = 0;
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 31] = 0;
                    break;
                case 0:
                    cb_Category16.SelectedIndex = 0;
                    break;
                case 1:
                    cb_Category16.SelectedIndex = 0;
                    break;
                case 3:
                    cb_Category16.SelectedIndex = 1;
                    break;
                case 7:
                    cb_Category16.SelectedIndex = 2;
                    break;
                case 9:
                    cb_Category16.SelectedIndex = 3;
                    break;
                case 16:
                    cb_Category16.SelectedIndex = 4;
                    break;
            }
            switch (Main.loadedSave[offsets.chaoSave.MarketItemsStart + 32])
            {
                case 255:
                    cb_Category17.SelectedIndex = 0;
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 33] = 0;
                    break;
                case 0:
                    cb_Category17.SelectedIndex = 0;
                    break;
                case 1:
                    cb_Category17.SelectedIndex = 0;
                    break;
                case 3:
                    cb_Category17.SelectedIndex = 1;
                    break;
                case 7:
                    cb_Category17.SelectedIndex = 2;
                    break;
                case 9:
                    cb_Category17.SelectedIndex = 3;
                    break;
                case 16:
                    cb_Category17.SelectedIndex = 4;
                    break;
            }
            switch (Main.loadedSave[offsets.chaoSave.MarketItemsStart + 34])
            {
                case 255:
                    cb_Category18.SelectedIndex = 0;
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 35] = 0;
                    break;
                case 0:
                    cb_Category18.SelectedIndex = 0;
                    break;
                case 1:
                    cb_Category18.SelectedIndex = 0;
                    break;
                case 3:
                    cb_Category18.SelectedIndex = 1;
                    break;
                case 7:
                    cb_Category18.SelectedIndex = 2;
                    break;
                case 9:
                    cb_Category18.SelectedIndex = 3;
                    break;
                case 16:
                    cb_Category18.SelectedIndex = 4;
                    break;
            }
            switch (Main.loadedSave[offsets.chaoSave.MarketItemsStart + 36])
            {
                case 255:
                    cb_Category19.SelectedIndex = 0;
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 37] = 0;
                    break;
                case 0:
                    cb_Category19.SelectedIndex = 0;
                    break;
                case 1:
                    cb_Category19.SelectedIndex = 0;
                    break;
                case 3:
                    cb_Category19.SelectedIndex = 1;
                    break;
                case 7:
                    cb_Category19.SelectedIndex = 2;
                    break;
                case 9:
                    cb_Category19.SelectedIndex = 3;
                    break;
                case 16:
                    cb_Category19.SelectedIndex = 4;
                    break;
            }
            switch (Main.loadedSave[offsets.chaoSave.MarketItemsStart + 38])
            {
                case 255:
                    cb_Category20.SelectedIndex = 0;
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 39] = 0;
                    break;
                case 0:
                    cb_Category20.SelectedIndex = 0;
                    break;
                case 1:
                    cb_Category20.SelectedIndex = 0;
                    break;
                case 3:
                    cb_Category20.SelectedIndex = 1;
                    break;
                case 7:
                    cb_Category20.SelectedIndex = 2;
                    break;
                case 9:
                    cb_Category20.SelectedIndex = 3;
                    break;
                case 16:
                    cb_Category20.SelectedIndex = 4;
                    break;
            }
            switch (Main.loadedSave[offsets.chaoSave.MarketItemsStart + 40])
            {
                case 255:
                    cb_Category21.SelectedIndex = 0;
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 41] = 0;
                    break;
                case 0:
                    cb_Category21.SelectedIndex = 0;
                    break;
                case 1:
                    cb_Category21.SelectedIndex = 0;
                    break;
                case 3:
                    cb_Category21.SelectedIndex = 1;
                    break;
                case 7:
                    cb_Category21.SelectedIndex = 2;
                    break;
                case 9:
                    cb_Category21.SelectedIndex = 3;
                    break;
                case 16:
                    cb_Category21.SelectedIndex = 4;
                    break;
            }
            switch (Main.loadedSave[offsets.chaoSave.MarketItemsStart + 42])
            {
                case 255:
                    cb_Category22.SelectedIndex = 0;
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 43] = 0;
                    break;
                case 0:
                    cb_Category22.SelectedIndex = 0;
                    break;
                case 1:
                    cb_Category22.SelectedIndex = 0;
                    break;
                case 3:
                    cb_Category22.SelectedIndex = 1;
                    break;
                case 7:
                    cb_Category22.SelectedIndex = 2;
                    break;
                case 9:
                    cb_Category22.SelectedIndex = 3;
                    break;
                case 16:
                    cb_Category22.SelectedIndex = 4;
                    break;
            }
            switch (Main.loadedSave[offsets.chaoSave.MarketItemsStart + 44])
            {
                case 255:
                    cb_Category23.SelectedIndex = 0;
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 45] = 0;
                    break;
                case 0:
                    cb_Category23.SelectedIndex = 0;
                    break;
                case 1:
                    cb_Category23.SelectedIndex = 0;
                    break;
                case 3:
                    cb_Category23.SelectedIndex = 1;
                    break;
                case 7:
                    cb_Category23.SelectedIndex = 2;
                    break;
                case 9:
                    cb_Category23.SelectedIndex = 3;
                    break;
                case 16:
                    cb_Category23.SelectedIndex = 4;
                    break;
            }
            switch (Main.loadedSave[offsets.chaoSave.MarketItemsStart + 46])
            {
                case 255:
                    cb_Category24.SelectedIndex = 0;
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 47] = 0;
                    break;
                case 0:
                    cb_Category24.SelectedIndex = 0;
                    break;
                case 1:
                    cb_Category24.SelectedIndex = 0;
                    break;
                case 3:
                    cb_Category24.SelectedIndex = 1;
                    break;
                case 7:
                    cb_Category24.SelectedIndex = 2;
                    break;
                case 9:
                    cb_Category24.SelectedIndex = 3;
                    break;
                case 16:
                    cb_Category24.SelectedIndex = 4;
                    break;
            }
            switch (Main.loadedSave[offsets.chaoSave.MarketItemsStart + 48])
            {
                case 255:
                    cb_Category25.SelectedIndex = 0;
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 49] = 0;
                    break;
                case 0:
                    cb_Category25.SelectedIndex = 0;
                    break;
                case 1:
                    cb_Category25.SelectedIndex = 0;
                    break;
                case 3:
                    cb_Category25.SelectedIndex = 1;
                    break;
                case 7:
                    cb_Category25.SelectedIndex = 2;
                    break;
                case 9:
                    cb_Category25.SelectedIndex = 3;
                    break;
                case 16:
                    cb_Category25.SelectedIndex = 4;
                    break;
            }
            switch (Main.loadedSave[offsets.chaoSave.MarketItemsStart + 50])
            {
                case 255:
                    cb_Category26.SelectedIndex = 0;
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 51] = 0;
                    break;
                case 0:
                    cb_Category26.SelectedIndex = 0;
                    break;
                case 1:
                    cb_Category26.SelectedIndex = 0;
                    break;
                case 3:
                    cb_Category26.SelectedIndex = 1;
                    break;
                case 7:
                    cb_Category26.SelectedIndex = 2;
                    break;
                case 9:
                    cb_Category26.SelectedIndex = 3;
                    break;
                case 16:
                    cb_Category26.SelectedIndex = 4;
                    break;
            }
            switch (Main.loadedSave[offsets.chaoSave.MarketItemsStart + 52])
            {
                case 255:
                    cb_Category27.SelectedIndex = 0;
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 53] = 0;
                    break;
                case 0:
                    cb_Category27.SelectedIndex = 0;
                    break;
                case 1:
                    cb_Category27.SelectedIndex = 0;
                    break;
                case 3:
                    cb_Category27.SelectedIndex = 1;
                    break;
                case 7:
                    cb_Category27.SelectedIndex = 2;
                    break;
                case 9:
                    cb_Category27.SelectedIndex = 3;
                    break;
                case 16:
                    cb_Category27.SelectedIndex = 4;
                    break;
            }
            switch (Main.loadedSave[offsets.chaoSave.MarketItemsStart + 54])
            {
                case 255:
                    cb_Category28.SelectedIndex = 0;
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 55] = 0;
                    break;
                case 0:
                    cb_Category28.SelectedIndex = 0;
                    break;
                case 1:
                    cb_Category28.SelectedIndex = 0;
                    break;
                case 3:
                    cb_Category28.SelectedIndex = 1;
                    break;
                case 7:
                    cb_Category28.SelectedIndex = 2;
                    break;
                case 9:
                    cb_Category28.SelectedIndex = 3;
                    break;
                case 16:
                    cb_Category28.SelectedIndex = 4;
                    break;
            }
            switch (Main.loadedSave[offsets.chaoSave.MarketItemsStart + 56])
            {
                case 255:
                    cb_Category29.SelectedIndex = 0;
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 57] = 0;
                    break;
                case 0:
                    cb_Category29.SelectedIndex = 0;
                    break;
                case 1:
                    cb_Category29.SelectedIndex = 0;
                    break;
                case 3:
                    cb_Category29.SelectedIndex = 1;
                    break;
                case 7:
                    cb_Category29.SelectedIndex = 2;
                    break;
                case 9:
                    cb_Category29.SelectedIndex = 3;
                    break;
                case 16:
                    cb_Category29.SelectedIndex = 4;
                    break;
            }
            switch (Main.loadedSave[offsets.chaoSave.MarketItemsStart + 58])
            {
                case 255:
                    cb_Category30.SelectedIndex = 0;
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 59] = 0;
                    break;
                case 0:
                    cb_Category30.SelectedIndex = 0;
                    break;
                case 1:
                    cb_Category30.SelectedIndex = 0;
                    break;
                case 3:
                    cb_Category30.SelectedIndex = 1;
                    break;
                case 7:
                    cb_Category30.SelectedIndex = 2;
                    break;
                case 9:
                    cb_Category30.SelectedIndex = 3;
                    break;
                case 16:
                    cb_Category30.SelectedIndex = 4;
                    break;
            }
            switch (Main.loadedSave[offsets.chaoSave.MarketItemsStart + 60])
            {
                case 255:
                    cb_Category31.SelectedIndex = 0;
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 61] = 0;
                    break;
                case 0:
                    cb_Category31.SelectedIndex = 0;
                    break;
                case 1:
                    cb_Category31.SelectedIndex = 0;
                    break;
                case 3:
                    cb_Category31.SelectedIndex = 1;
                    break;
                case 7:
                    cb_Category31.SelectedIndex = 2;
                    break;
                case 9:
                    cb_Category31.SelectedIndex = 3;
                    break;
                case 16:
                    cb_Category31.SelectedIndex = 4;
                    break;
            }
            switch (Main.loadedSave[offsets.chaoSave.MarketItemsStart + 62])
            {
                case 255:
                    cb_Category32.SelectedIndex = 0;
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 63] = 0;
                    break;
                case 0:
                    cb_Category32.SelectedIndex = 0;
                    break;
                case 1:
                    cb_Category32.SelectedIndex = 0;
                    break;
                case 3:
                    cb_Category32.SelectedIndex = 1;
                    break;
                case 7:
                    cb_Category32.SelectedIndex = 2;
                    break;
                case 9:
                    cb_Category32.SelectedIndex = 3;
                    break;
                case 16:
                    cb_Category32.SelectedIndex = 4;
                    break;
            }
            SetSize();
            loaded = true;
        }

        private void SetSize()
        {
            switch (itemCount)
            {
                case 0:
                    Height = 134;
                    Width = 346;
                    btn_AddItem.Location = new Point(251, 19);
                    btn_RemoveItem.Location = new Point(251, 44);
                    lb_Item.Visible = false;
                    lb_Category.Visible = false;
                    lb_ItemB.Visible = false;
                    lb_CategoryB.Visible = false;
                    cb_Item1.Visible = false;
                    cb_Category1.Visible = false;
                    lb_Item1.Visible = false;
                    cb_Item2.Visible = false;
                    cb_Category2.Visible = false;
                    lb_Item2.Visible = false;
                    cb_Item3.Visible = false;
                    cb_Category3.Visible = false;
                    lb_Item3.Visible = false;
                    cb_Item4.Visible = false;
                    cb_Category4.Visible = false;
                    lb_Item4.Visible = false;
                    cb_Item5.Visible = false;
                    cb_Category5.Visible = false;
                    lb_Item5.Visible = false;
                    cb_Item6.Visible = false;
                    cb_Category6.Visible = false;
                    lb_Item6.Visible = false;
                    cb_Item7.Visible = false;
                    cb_Category7.Visible = false;
                    lb_Item7.Visible = false;
                    cb_Item8.Visible = false;
                    cb_Category8.Visible = false;
                    lb_Item8.Visible = false;
                    cb_Item9.Visible = false;
                    cb_Category9.Visible = false;
                    lb_Item9.Visible = false;
                    cb_Item10.Visible = false;
                    cb_Category10.Visible = false;
                    lb_Item10.Visible = false;
                    cb_Item11.Visible = false;
                    cb_Category11.Visible = false;
                    lb_Item11.Visible = false;
                    cb_Item12.Visible = false;
                    cb_Category12.Visible = false;
                    lb_Item12.Visible = false;
                    cb_Item13.Visible = false;
                    cb_Category13.Visible = false;
                    lb_Item13.Visible = false;
                    cb_Item14.Visible = false;
                    cb_Category14.Visible = false;
                    lb_Item14.Visible = false;
                    cb_Item15.Visible = false;
                    cb_Category15.Visible = false;
                    lb_Item15.Visible = false;
                    cb_Item16.Visible = false;
                    cb_Category16.Visible = false;
                    lb_Item16.Visible = false;
                    cb_Item17.Visible = false;
                    cb_Category17.Visible = false;
                    lb_Item17.Visible = false;
                    cb_Item18.Visible = false;
                    cb_Category18.Visible = false;
                    lb_Item18.Visible = false;
                    cb_Item19.Visible = false;
                    cb_Category19.Visible = false;
                    lb_Item19.Visible = false;
                    cb_Item20.Visible = false;
                    cb_Category20.Visible = false;
                    lb_Item20.Visible = false;
                    cb_Item21.Visible = false;
                    cb_Category21.Visible = false;
                    lb_Item21.Visible = false;
                    cb_Item22.Visible = false;
                    cb_Category22.Visible = false;
                    lb_Item22.Visible = false;
                    cb_Item23.Visible = false;
                    cb_Category23.Visible = false;
                    lb_Item23.Visible = false;
                    cb_Item24.Visible = false;
                    cb_Category24.Visible = false;
                    lb_Item24.Visible = false;
                    cb_Item25.Visible = false;
                    cb_Category25.Visible = false;
                    lb_Item25.Visible = false;
                    cb_Item26.Visible = false;
                    cb_Category26.Visible = false;
                    lb_Item26.Visible = false;
                    cb_Item27.Visible = false;
                    cb_Category27.Visible = false;
                    lb_Item27.Visible = false;
                    cb_Item28.Visible = false;
                    cb_Category28.Visible = false;
                    lb_Item28.Visible = false;
                    cb_Item29.Visible = false;
                    cb_Category29.Visible = false;
                    lb_Item29.Visible = false;
                    cb_Item30.Visible = false;
                    cb_Category30.Visible = false;
                    lb_Item30.Visible = false;
                    cb_Item31.Visible = false;
                    cb_Category31.Visible = false;
                    lb_Item31.Visible = false;
                    cb_Item32.Visible = false;
                    cb_Category32.Visible = false;
                    lb_Item32.Visible = false;
                    btn_RemoveItem.Enabled = false;
                    btn_AddItem.Enabled = true;
                    break;
                case 1:
                    Height = 134;
                    Width = 346;
                    btn_AddItem.Location = new Point(251, 19);
                    btn_RemoveItem.Location = new Point(251, 44);
                    lb_Item.Visible = true;
                    lb_Category.Visible = true;
                    lb_ItemB.Visible = false;
                    lb_CategoryB.Visible = false;
                    cb_Item1.Visible = true;
                    cb_Category1.Visible = true;
                    lb_Item1.Visible = true;
                    cb_Item2.Visible = false;
                    cb_Category2.Visible = false;
                    lb_Item2.Visible = false;
                    cb_Item3.Visible = false;
                    cb_Category3.Visible = false;
                    lb_Item3.Visible = false;
                    cb_Item4.Visible = false;
                    cb_Category4.Visible = false;
                    lb_Item4.Visible = false;
                    cb_Item5.Visible = false;
                    cb_Category5.Visible = false;
                    lb_Item5.Visible = false;
                    cb_Item6.Visible = false;
                    cb_Category6.Visible = false;
                    lb_Item6.Visible = false;
                    cb_Item7.Visible = false;
                    cb_Category7.Visible = false;
                    lb_Item7.Visible = false;
                    cb_Item8.Visible = false;
                    cb_Category8.Visible = false;
                    lb_Item8.Visible = false;
                    cb_Item9.Visible = false;
                    cb_Category9.Visible = false;
                    lb_Item9.Visible = false;
                    cb_Item10.Visible = false;
                    cb_Category10.Visible = false;
                    lb_Item10.Visible = false;
                    cb_Item11.Visible = false;
                    cb_Category11.Visible = false;
                    lb_Item11.Visible = false;
                    cb_Item12.Visible = false;
                    cb_Category12.Visible = false;
                    lb_Item12.Visible = false;
                    cb_Item13.Visible = false;
                    cb_Category13.Visible = false;
                    lb_Item13.Visible = false;
                    cb_Item14.Visible = false;
                    cb_Category14.Visible = false;
                    lb_Item14.Visible = false;
                    cb_Item15.Visible = false;
                    cb_Category15.Visible = false;
                    lb_Item15.Visible = false;
                    cb_Item16.Visible = false;
                    cb_Category16.Visible = false;
                    lb_Item16.Visible = false;
                    cb_Item17.Visible = false;
                    cb_Category17.Visible = false;
                    lb_Item17.Visible = false;
                    cb_Item18.Visible = false;
                    cb_Category18.Visible = false;
                    lb_Item18.Visible = false;
                    cb_Item19.Visible = false;
                    cb_Category19.Visible = false;
                    lb_Item19.Visible = false;
                    cb_Item20.Visible = false;
                    cb_Category20.Visible = false;
                    lb_Item20.Visible = false;
                    cb_Item21.Visible = false;
                    cb_Category21.Visible = false;
                    lb_Item21.Visible = false;
                    cb_Item22.Visible = false;
                    cb_Category22.Visible = false;
                    lb_Item22.Visible = false;
                    cb_Item23.Visible = false;
                    cb_Category23.Visible = false;
                    lb_Item23.Visible = false;
                    cb_Item24.Visible = false;
                    cb_Category24.Visible = false;
                    lb_Item24.Visible = false;
                    cb_Item25.Visible = false;
                    cb_Category25.Visible = false;
                    lb_Item25.Visible = false;
                    cb_Item26.Visible = false;
                    cb_Category26.Visible = false;
                    lb_Item26.Visible = false;
                    cb_Item27.Visible = false;
                    cb_Category27.Visible = false;
                    lb_Item27.Visible = false;
                    cb_Item28.Visible = false;
                    cb_Category28.Visible = false;
                    lb_Item28.Visible = false;
                    cb_Item29.Visible = false;
                    cb_Category29.Visible = false;
                    lb_Item29.Visible = false;
                    cb_Item30.Visible = false;
                    cb_Category30.Visible = false;
                    lb_Item30.Visible = false;
                    cb_Item31.Visible = false;
                    cb_Category31.Visible = false;
                    lb_Item31.Visible = false;
                    cb_Item32.Visible = false;
                    cb_Category32.Visible = false;
                    lb_Item32.Visible = false;
                    btn_RemoveItem.Enabled = true;
                    btn_AddItem.Enabled = true;
                    break;
                case 2:
                    Height = 134;
                    Width = 346;
                    btn_AddItem.Location = new Point(251, 19);
                    btn_RemoveItem.Location = new Point(251, 44);
                    lb_Item.Visible = true;
                    lb_Category.Visible = true;
                    lb_ItemB.Visible = false;
                    lb_CategoryB.Visible = false;
                    cb_Item1.Visible = true;
                    cb_Category1.Visible = true;
                    lb_Item1.Visible = true;
                    cb_Item2.Visible = true;
                    cb_Category2.Visible = true;
                    lb_Item2.Visible = true;
                    cb_Item3.Visible = false;
                    cb_Category3.Visible = false;
                    lb_Item3.Visible = false;
                    cb_Item4.Visible = false;
                    cb_Category4.Visible = false;
                    lb_Item4.Visible = false;
                    cb_Item5.Visible = false;
                    cb_Category5.Visible = false;
                    lb_Item5.Visible = false;
                    cb_Item6.Visible = false;
                    cb_Category6.Visible = false;
                    lb_Item6.Visible = false;
                    cb_Item7.Visible = false;
                    cb_Category7.Visible = false;
                    lb_Item7.Visible = false;
                    cb_Item8.Visible = false;
                    cb_Category8.Visible = false;
                    lb_Item8.Visible = false;
                    cb_Item9.Visible = false;
                    cb_Category9.Visible = false;
                    lb_Item9.Visible = false;
                    cb_Item10.Visible = false;
                    cb_Category10.Visible = false;
                    lb_Item10.Visible = false;
                    cb_Item11.Visible = false;
                    cb_Category11.Visible = false;
                    lb_Item11.Visible = false;
                    cb_Item12.Visible = false;
                    cb_Category12.Visible = false;
                    lb_Item12.Visible = false;
                    cb_Item13.Visible = false;
                    cb_Category13.Visible = false;
                    lb_Item13.Visible = false;
                    cb_Item14.Visible = false;
                    cb_Category14.Visible = false;
                    lb_Item14.Visible = false;
                    cb_Item15.Visible = false;
                    cb_Category15.Visible = false;
                    lb_Item15.Visible = false;
                    cb_Item16.Visible = false;
                    cb_Category16.Visible = false;
                    lb_Item16.Visible = false;
                    cb_Item17.Visible = false;
                    cb_Category17.Visible = false;
                    lb_Item17.Visible = false;
                    cb_Item18.Visible = false;
                    cb_Category18.Visible = false;
                    lb_Item18.Visible = false;
                    cb_Item19.Visible = false;
                    cb_Category19.Visible = false;
                    lb_Item19.Visible = false;
                    cb_Item20.Visible = false;
                    cb_Category20.Visible = false;
                    lb_Item20.Visible = false;
                    cb_Item21.Visible = false;
                    cb_Category21.Visible = false;
                    lb_Item21.Visible = false;
                    cb_Item22.Visible = false;
                    cb_Category22.Visible = false;
                    lb_Item22.Visible = false;
                    cb_Item23.Visible = false;
                    cb_Category23.Visible = false;
                    lb_Item23.Visible = false;
                    cb_Item24.Visible = false;
                    cb_Category24.Visible = false;
                    lb_Item24.Visible = false;
                    cb_Item25.Visible = false;
                    cb_Category25.Visible = false;
                    lb_Item25.Visible = false;
                    cb_Item26.Visible = false;
                    cb_Category26.Visible = false;
                    lb_Item26.Visible = false;
                    cb_Item27.Visible = false;
                    cb_Category27.Visible = false;
                    lb_Item27.Visible = false;
                    cb_Item28.Visible = false;
                    cb_Category28.Visible = false;
                    lb_Item28.Visible = false;
                    cb_Item29.Visible = false;
                    cb_Category29.Visible = false;
                    lb_Item29.Visible = false;
                    cb_Item30.Visible = false;
                    cb_Category30.Visible = false;
                    lb_Item30.Visible = false;
                    cb_Item31.Visible = false;
                    cb_Category31.Visible = false;
                    lb_Item31.Visible = false;
                    cb_Item32.Visible = false;
                    cb_Category32.Visible = false;
                    lb_Item32.Visible = false;
                    btn_RemoveItem.Enabled = true;
                    btn_AddItem.Enabled = true;
                    break;
                case 3:
                    Height = 134;
                    Width = 346;
                    btn_AddItem.Location = new Point(251, 19);
                    btn_RemoveItem.Location = new Point(251, 44);
                    lb_Item.Visible = true;
                    lb_Category.Visible = true;
                    lb_ItemB.Visible = false;
                    lb_CategoryB.Visible = false;
                    cb_Item1.Visible = true;
                    cb_Category1.Visible = true;
                    lb_Item1.Visible = true;
                    cb_Item2.Visible = true;
                    cb_Category2.Visible = true;
                    lb_Item2.Visible = true;
                    cb_Item3.Visible = true;
                    cb_Category3.Visible = true;
                    lb_Item3.Visible = true;
                    cb_Item4.Visible = false;
                    cb_Category4.Visible = false;
                    lb_Item4.Visible = false;
                    cb_Item5.Visible = false;
                    cb_Category5.Visible = false;
                    lb_Item5.Visible = false;
                    cb_Item6.Visible = false;
                    cb_Category6.Visible = false;
                    lb_Item6.Visible = false;
                    cb_Item7.Visible = false;
                    cb_Category7.Visible = false;
                    lb_Item7.Visible = false;
                    cb_Item8.Visible = false;
                    cb_Category8.Visible = false;
                    lb_Item8.Visible = false;
                    cb_Item9.Visible = false;
                    cb_Category9.Visible = false;
                    lb_Item9.Visible = false;
                    cb_Item10.Visible = false;
                    cb_Category10.Visible = false;
                    lb_Item10.Visible = false;
                    cb_Item11.Visible = false;
                    cb_Category11.Visible = false;
                    lb_Item11.Visible = false;
                    cb_Item12.Visible = false;
                    cb_Category12.Visible = false;
                    lb_Item12.Visible = false;
                    cb_Item13.Visible = false;
                    cb_Category13.Visible = false;
                    lb_Item13.Visible = false;
                    cb_Item14.Visible = false;
                    cb_Category14.Visible = false;
                    lb_Item14.Visible = false;
                    cb_Item15.Visible = false;
                    cb_Category15.Visible = false;
                    lb_Item15.Visible = false;
                    cb_Item16.Visible = false;
                    cb_Category16.Visible = false;
                    lb_Item16.Visible = false;
                    cb_Item17.Visible = false;
                    cb_Category17.Visible = false;
                    lb_Item17.Visible = false;
                    cb_Item18.Visible = false;
                    cb_Category18.Visible = false;
                    lb_Item18.Visible = false;
                    cb_Item19.Visible = false;
                    cb_Category19.Visible = false;
                    lb_Item19.Visible = false;
                    cb_Item20.Visible = false;
                    cb_Category20.Visible = false;
                    lb_Item20.Visible = false;
                    cb_Item21.Visible = false;
                    cb_Category21.Visible = false;
                    lb_Item21.Visible = false;
                    cb_Item22.Visible = false;
                    cb_Category22.Visible = false;
                    lb_Item22.Visible = false;
                    cb_Item23.Visible = false;
                    cb_Category23.Visible = false;
                    lb_Item23.Visible = false;
                    cb_Item24.Visible = false;
                    cb_Category24.Visible = false;
                    lb_Item24.Visible = false;
                    cb_Item25.Visible = false;
                    cb_Category25.Visible = false;
                    lb_Item25.Visible = false;
                    cb_Item26.Visible = false;
                    cb_Category26.Visible = false;
                    lb_Item26.Visible = false;
                    cb_Item27.Visible = false;
                    cb_Category27.Visible = false;
                    lb_Item27.Visible = false;
                    cb_Item28.Visible = false;
                    cb_Category28.Visible = false;
                    lb_Item28.Visible = false;
                    cb_Item29.Visible = false;
                    cb_Category29.Visible = false;
                    lb_Item29.Visible = false;
                    cb_Item30.Visible = false;
                    cb_Category30.Visible = false;
                    lb_Item30.Visible = false;
                    cb_Item31.Visible = false;
                    cb_Category31.Visible = false;
                    lb_Item31.Visible = false;
                    cb_Item32.Visible = false;
                    cb_Category32.Visible = false;
                    lb_Item32.Visible = false;
                    btn_RemoveItem.Enabled = true;
                    btn_AddItem.Enabled = true;
                    break;
                case 4:
                    Height = 159;
                    Width = 346;
                    btn_AddItem.Location = new Point(251, 19);
                    btn_RemoveItem.Location = new Point(251, 44);
                    lb_Item.Visible = true;
                    lb_Category.Visible = true;
                    lb_ItemB.Visible = false;
                    lb_CategoryB.Visible = false;
                    cb_Item1.Visible = true;
                    cb_Category1.Visible = true;
                    lb_Item1.Visible = true;
                    cb_Item2.Visible = true;
                    cb_Category2.Visible = true;
                    lb_Item2.Visible = true;
                    cb_Item3.Visible = true;
                    cb_Category3.Visible = true;
                    lb_Item3.Visible = true;
                    cb_Item4.Visible = true;
                    cb_Category4.Visible = true;
                    lb_Item4.Visible = true;
                    cb_Item5.Visible = false;
                    cb_Category5.Visible = false;
                    lb_Item5.Visible = false;
                    cb_Item6.Visible = false;
                    cb_Category6.Visible = false;
                    lb_Item6.Visible = false;
                    cb_Item7.Visible = false;
                    cb_Category7.Visible = false;
                    lb_Item7.Visible = false;
                    cb_Item8.Visible = false;
                    cb_Category8.Visible = false;
                    lb_Item8.Visible = false;
                    cb_Item9.Visible = false;
                    cb_Category9.Visible = false;
                    lb_Item9.Visible = false;
                    cb_Item10.Visible = false;
                    cb_Category10.Visible = false;
                    lb_Item10.Visible = false;
                    cb_Item11.Visible = false;
                    cb_Category11.Visible = false;
                    lb_Item11.Visible = false;
                    cb_Item12.Visible = false;
                    cb_Category12.Visible = false;
                    lb_Item12.Visible = false;
                    cb_Item13.Visible = false;
                    cb_Category13.Visible = false;
                    lb_Item13.Visible = false;
                    cb_Item14.Visible = false;
                    cb_Category14.Visible = false;
                    lb_Item14.Visible = false;
                    cb_Item15.Visible = false;
                    cb_Category15.Visible = false;
                    lb_Item15.Visible = false;
                    cb_Item16.Visible = false;
                    cb_Category16.Visible = false;
                    lb_Item16.Visible = false;
                    cb_Item17.Visible = false;
                    cb_Category17.Visible = false;
                    lb_Item17.Visible = false;
                    cb_Item18.Visible = false;
                    cb_Category18.Visible = false;
                    lb_Item18.Visible = false;
                    cb_Item19.Visible = false;
                    cb_Category19.Visible = false;
                    lb_Item19.Visible = false;
                    cb_Item20.Visible = false;
                    cb_Category20.Visible = false;
                    lb_Item20.Visible = false;
                    cb_Item21.Visible = false;
                    cb_Category21.Visible = false;
                    lb_Item21.Visible = false;
                    cb_Item22.Visible = false;
                    cb_Category22.Visible = false;
                    lb_Item22.Visible = false;
                    cb_Item23.Visible = false;
                    cb_Category23.Visible = false;
                    lb_Item23.Visible = false;
                    cb_Item24.Visible = false;
                    cb_Category24.Visible = false;
                    lb_Item24.Visible = false;
                    cb_Item25.Visible = false;
                    cb_Category25.Visible = false;
                    lb_Item25.Visible = false;
                    cb_Item26.Visible = false;
                    cb_Category26.Visible = false;
                    lb_Item26.Visible = false;
                    cb_Item27.Visible = false;
                    cb_Category27.Visible = false;
                    lb_Item27.Visible = false;
                    cb_Item28.Visible = false;
                    cb_Category28.Visible = false;
                    lb_Item28.Visible = false;
                    cb_Item29.Visible = false;
                    cb_Category29.Visible = false;
                    lb_Item29.Visible = false;
                    cb_Item30.Visible = false;
                    cb_Category30.Visible = false;
                    lb_Item30.Visible = false;
                    cb_Item31.Visible = false;
                    cb_Category31.Visible = false;
                    lb_Item31.Visible = false;
                    cb_Item32.Visible = false;
                    cb_Category32.Visible = false;
                    lb_Item32.Visible = false;
                    btn_RemoveItem.Enabled = true;
                    btn_AddItem.Enabled = true;
                    break;
                case 5:
                    Height = 184;
                    Width = 346;
                    btn_AddItem.Location = new Point(251, 19);
                    btn_RemoveItem.Location = new Point(251, 44);
                    lb_Item.Visible = true;
                    lb_Category.Visible = true;
                    lb_ItemB.Visible = false;
                    lb_CategoryB.Visible = false;
                    cb_Item1.Visible = true;
                    cb_Category1.Visible = true;
                    lb_Item1.Visible = true;
                    cb_Item2.Visible = true;
                    cb_Category2.Visible = true;
                    lb_Item2.Visible = true;
                    cb_Item3.Visible = true;
                    cb_Category3.Visible = true;
                    lb_Item3.Visible = true;
                    cb_Item4.Visible = true;
                    cb_Category4.Visible = true;
                    lb_Item4.Visible = true;
                    cb_Item5.Visible = true;
                    cb_Category5.Visible = true;
                    lb_Item5.Visible = true;
                    cb_Item6.Visible = false;
                    cb_Category6.Visible = false;
                    lb_Item6.Visible = false;
                    cb_Item7.Visible = false;
                    cb_Category7.Visible = false;
                    lb_Item7.Visible = false;
                    cb_Item8.Visible = false;
                    cb_Category8.Visible = false;
                    lb_Item8.Visible = false;
                    cb_Item9.Visible = false;
                    cb_Category9.Visible = false;
                    lb_Item9.Visible = false;
                    cb_Item10.Visible = false;
                    cb_Category10.Visible = false;
                    lb_Item10.Visible = false;
                    cb_Item11.Visible = false;
                    cb_Category11.Visible = false;
                    lb_Item11.Visible = false;
                    cb_Item12.Visible = false;
                    cb_Category12.Visible = false;
                    lb_Item12.Visible = false;
                    cb_Item13.Visible = false;
                    cb_Category13.Visible = false;
                    lb_Item13.Visible = false;
                    cb_Item14.Visible = false;
                    cb_Category14.Visible = false;
                    lb_Item14.Visible = false;
                    cb_Item15.Visible = false;
                    cb_Category15.Visible = false;
                    lb_Item15.Visible = false;
                    cb_Item16.Visible = false;
                    cb_Category16.Visible = false;
                    lb_Item16.Visible = false;
                    cb_Item17.Visible = false;
                    cb_Category17.Visible = false;
                    lb_Item17.Visible = false;
                    cb_Item18.Visible = false;
                    cb_Category18.Visible = false;
                    lb_Item18.Visible = false;
                    cb_Item19.Visible = false;
                    cb_Category19.Visible = false;
                    lb_Item19.Visible = false;
                    cb_Item20.Visible = false;
                    cb_Category20.Visible = false;
                    lb_Item20.Visible = false;
                    cb_Item21.Visible = false;
                    cb_Category21.Visible = false;
                    lb_Item21.Visible = false;
                    cb_Item22.Visible = false;
                    cb_Category22.Visible = false;
                    lb_Item22.Visible = false;
                    cb_Item23.Visible = false;
                    cb_Category23.Visible = false;
                    lb_Item23.Visible = false;
                    cb_Item24.Visible = false;
                    cb_Category24.Visible = false;
                    lb_Item24.Visible = false;
                    cb_Item25.Visible = false;
                    cb_Category25.Visible = false;
                    lb_Item25.Visible = false;
                    cb_Item26.Visible = false;
                    cb_Category26.Visible = false;
                    lb_Item26.Visible = false;
                    cb_Item27.Visible = false;
                    cb_Category27.Visible = false;
                    lb_Item27.Visible = false;
                    cb_Item28.Visible = false;
                    cb_Category28.Visible = false;
                    lb_Item28.Visible = false;
                    cb_Item29.Visible = false;
                    cb_Category29.Visible = false;
                    lb_Item29.Visible = false;
                    cb_Item30.Visible = false;
                    cb_Category30.Visible = false;
                    lb_Item30.Visible = false;
                    cb_Item31.Visible = false;
                    cb_Category31.Visible = false;
                    lb_Item31.Visible = false;
                    cb_Item32.Visible = false;
                    cb_Category32.Visible = false;
                    lb_Item32.Visible = false;
                    btn_RemoveItem.Enabled = true;
                    btn_AddItem.Enabled = true;
                    break;
                case 6:
                    Height = 209;
                    Width = 346;
                    btn_AddItem.Location = new Point(251, 19);
                    btn_RemoveItem.Location = new Point(251, 44);
                    lb_Item.Visible = true;
                    lb_Category.Visible = true;
                    lb_ItemB.Visible = false;
                    lb_CategoryB.Visible = false;
                    cb_Item1.Visible = true;
                    cb_Category1.Visible = true;
                    lb_Item1.Visible = true;
                    cb_Item2.Visible = true;
                    cb_Category2.Visible = true;
                    lb_Item2.Visible = true;
                    cb_Item3.Visible = true;
                    cb_Category3.Visible = true;
                    lb_Item3.Visible = true;
                    cb_Item4.Visible = true;
                    cb_Category4.Visible = true;
                    lb_Item4.Visible = true;
                    cb_Item5.Visible = true;
                    cb_Category5.Visible = true;
                    lb_Item5.Visible = true;
                    cb_Item6.Visible = true;
                    cb_Category6.Visible = true;
                    lb_Item6.Visible = true;
                    cb_Item7.Visible = false;
                    cb_Category7.Visible = false;
                    lb_Item7.Visible = false;
                    cb_Item8.Visible = false;
                    cb_Category8.Visible = false;
                    lb_Item8.Visible = false;
                    cb_Item9.Visible = false;
                    cb_Category9.Visible = false;
                    lb_Item9.Visible = false;
                    cb_Item10.Visible = false;
                    cb_Category10.Visible = false;
                    lb_Item10.Visible = false;
                    cb_Item11.Visible = false;
                    cb_Category11.Visible = false;
                    lb_Item11.Visible = false;
                    cb_Item12.Visible = false;
                    cb_Category12.Visible = false;
                    lb_Item12.Visible = false;
                    cb_Item13.Visible = false;
                    cb_Category13.Visible = false;
                    lb_Item13.Visible = false;
                    cb_Item14.Visible = false;
                    cb_Category14.Visible = false;
                    lb_Item14.Visible = false;
                    cb_Item15.Visible = false;
                    cb_Category15.Visible = false;
                    lb_Item15.Visible = false;
                    cb_Item16.Visible = false;
                    cb_Category16.Visible = false;
                    lb_Item16.Visible = false;
                    cb_Item17.Visible = false;
                    cb_Category17.Visible = false;
                    lb_Item17.Visible = false;
                    cb_Item18.Visible = false;
                    cb_Category18.Visible = false;
                    lb_Item18.Visible = false;
                    cb_Item19.Visible = false;
                    cb_Category19.Visible = false;
                    lb_Item19.Visible = false;
                    cb_Item20.Visible = false;
                    cb_Category20.Visible = false;
                    lb_Item20.Visible = false;
                    cb_Item21.Visible = false;
                    cb_Category21.Visible = false;
                    lb_Item21.Visible = false;
                    cb_Item22.Visible = false;
                    cb_Category22.Visible = false;
                    lb_Item22.Visible = false;
                    cb_Item23.Visible = false;
                    cb_Category23.Visible = false;
                    lb_Item23.Visible = false;
                    cb_Item24.Visible = false;
                    cb_Category24.Visible = false;
                    lb_Item24.Visible = false;
                    cb_Item25.Visible = false;
                    cb_Category25.Visible = false;
                    lb_Item25.Visible = false;
                    cb_Item26.Visible = false;
                    cb_Category26.Visible = false;
                    lb_Item26.Visible = false;
                    cb_Item27.Visible = false;
                    cb_Category27.Visible = false;
                    lb_Item27.Visible = false;
                    cb_Item28.Visible = false;
                    cb_Category28.Visible = false;
                    lb_Item28.Visible = false;
                    cb_Item29.Visible = false;
                    cb_Category29.Visible = false;
                    lb_Item29.Visible = false;
                    cb_Item30.Visible = false;
                    cb_Category30.Visible = false;
                    lb_Item30.Visible = false;
                    cb_Item31.Visible = false;
                    cb_Category31.Visible = false;
                    lb_Item31.Visible = false;
                    cb_Item32.Visible = false;
                    cb_Category32.Visible = false;
                    lb_Item32.Visible = false;
                    btn_RemoveItem.Enabled = true;
                    btn_AddItem.Enabled = true;
                    break;
                case 7:
                    Height = 234;
                    Width = 346;
                    btn_AddItem.Location = new Point(251, 19);
                    btn_RemoveItem.Location = new Point(251, 44);
                    lb_Item.Visible = true;
                    lb_Category.Visible = true;
                    lb_ItemB.Visible = false;
                    lb_CategoryB.Visible = false;
                    cb_Item1.Visible = true;
                    cb_Category1.Visible = true;
                    lb_Item1.Visible = true;
                    cb_Item2.Visible = true;
                    cb_Category2.Visible = true;
                    lb_Item2.Visible = true;
                    cb_Item3.Visible = true;
                    cb_Category3.Visible = true;
                    lb_Item3.Visible = true;
                    cb_Item4.Visible = true;
                    cb_Category4.Visible = true;
                    lb_Item4.Visible = true;
                    cb_Item5.Visible = true;
                    cb_Category5.Visible = true;
                    lb_Item5.Visible = true;
                    cb_Item6.Visible = true;
                    cb_Category6.Visible = true;
                    lb_Item6.Visible = true;
                    cb_Item7.Visible = true;
                    cb_Category7.Visible = true;
                    lb_Item7.Visible = true;
                    cb_Item8.Visible = false;
                    cb_Category8.Visible = false;
                    lb_Item8.Visible = false;
                    cb_Item9.Visible = false;
                    cb_Category9.Visible = false;
                    lb_Item9.Visible = false;
                    cb_Item10.Visible = false;
                    cb_Category10.Visible = false;
                    lb_Item10.Visible = false;
                    cb_Item11.Visible = false;
                    cb_Category11.Visible = false;
                    lb_Item11.Visible = false;
                    cb_Item12.Visible = false;
                    cb_Category12.Visible = false;
                    lb_Item12.Visible = false;
                    cb_Item13.Visible = false;
                    cb_Category13.Visible = false;
                    lb_Item13.Visible = false;
                    cb_Item14.Visible = false;
                    cb_Category14.Visible = false;
                    lb_Item14.Visible = false;
                    cb_Item15.Visible = false;
                    cb_Category15.Visible = false;
                    lb_Item15.Visible = false;
                    cb_Item16.Visible = false;
                    cb_Category16.Visible = false;
                    lb_Item16.Visible = false;
                    cb_Item17.Visible = false;
                    cb_Category17.Visible = false;
                    lb_Item17.Visible = false;
                    cb_Item18.Visible = false;
                    cb_Category18.Visible = false;
                    lb_Item18.Visible = false;
                    cb_Item19.Visible = false;
                    cb_Category19.Visible = false;
                    lb_Item19.Visible = false;
                    cb_Item20.Visible = false;
                    cb_Category20.Visible = false;
                    lb_Item20.Visible = false;
                    cb_Item21.Visible = false;
                    cb_Category21.Visible = false;
                    lb_Item21.Visible = false;
                    cb_Item22.Visible = false;
                    cb_Category22.Visible = false;
                    lb_Item22.Visible = false;
                    cb_Item23.Visible = false;
                    cb_Category23.Visible = false;
                    lb_Item23.Visible = false;
                    cb_Item24.Visible = false;
                    cb_Category24.Visible = false;
                    lb_Item24.Visible = false;
                    cb_Item25.Visible = false;
                    cb_Category25.Visible = false;
                    lb_Item25.Visible = false;
                    cb_Item26.Visible = false;
                    cb_Category26.Visible = false;
                    lb_Item26.Visible = false;
                    cb_Item27.Visible = false;
                    cb_Category27.Visible = false;
                    lb_Item27.Visible = false;
                    cb_Item28.Visible = false;
                    cb_Category28.Visible = false;
                    lb_Item28.Visible = false;
                    cb_Item29.Visible = false;
                    cb_Category29.Visible = false;
                    lb_Item29.Visible = false;
                    cb_Item30.Visible = false;
                    cb_Category30.Visible = false;
                    lb_Item30.Visible = false;
                    cb_Item31.Visible = false;
                    cb_Category31.Visible = false;
                    lb_Item31.Visible = false;
                    cb_Item32.Visible = false;
                    cb_Category32.Visible = false;
                    lb_Item32.Visible = false;
                    btn_RemoveItem.Enabled = true;
                    btn_AddItem.Enabled = true;
                    break;
                case 8:
                    Height = 259;
                    Width = 346;
                    btn_AddItem.Location = new Point(251, 19);
                    btn_RemoveItem.Location = new Point(251, 44);
                    lb_Item.Visible = true;
                    lb_Category.Visible = true;
                    lb_ItemB.Visible = false;
                    lb_CategoryB.Visible = false;
                    cb_Item1.Visible = true;
                    cb_Category1.Visible = true;
                    lb_Item1.Visible = true;
                    cb_Item2.Visible = true;
                    cb_Category2.Visible = true;
                    lb_Item2.Visible = true;
                    cb_Item3.Visible = true;
                    cb_Category3.Visible = true;
                    lb_Item3.Visible = true;
                    cb_Item4.Visible = true;
                    cb_Category4.Visible = true;
                    lb_Item4.Visible = true;
                    cb_Item5.Visible = true;
                    cb_Category5.Visible = true;
                    lb_Item5.Visible = true;
                    cb_Item6.Visible = true;
                    cb_Category6.Visible = true;
                    lb_Item6.Visible = true;
                    cb_Item7.Visible = true;
                    cb_Category7.Visible = true;
                    lb_Item7.Visible = true;
                    cb_Item8.Visible = true;
                    cb_Category8.Visible = true;
                    lb_Item8.Visible = true;
                    cb_Item9.Visible = false;
                    cb_Category9.Visible = false;
                    lb_Item9.Visible = false;
                    cb_Item10.Visible = false;
                    cb_Category10.Visible = false;
                    lb_Item10.Visible = false;
                    cb_Item11.Visible = false;
                    cb_Category11.Visible = false;
                    lb_Item11.Visible = false;
                    cb_Item12.Visible = false;
                    cb_Category12.Visible = false;
                    lb_Item12.Visible = false;
                    cb_Item13.Visible = false;
                    cb_Category13.Visible = false;
                    lb_Item13.Visible = false;
                    cb_Item14.Visible = false;
                    cb_Category14.Visible = false;
                    lb_Item14.Visible = false;
                    cb_Item15.Visible = false;
                    cb_Category15.Visible = false;
                    lb_Item15.Visible = false;
                    cb_Item16.Visible = false;
                    cb_Category16.Visible = false;
                    lb_Item16.Visible = false;
                    cb_Item17.Visible = false;
                    cb_Category17.Visible = false;
                    lb_Item17.Visible = false;
                    cb_Item18.Visible = false;
                    cb_Category18.Visible = false;
                    lb_Item18.Visible = false;
                    cb_Item19.Visible = false;
                    cb_Category19.Visible = false;
                    lb_Item19.Visible = false;
                    cb_Item20.Visible = false;
                    cb_Category20.Visible = false;
                    lb_Item20.Visible = false;
                    cb_Item21.Visible = false;
                    cb_Category21.Visible = false;
                    lb_Item21.Visible = false;
                    cb_Item22.Visible = false;
                    cb_Category22.Visible = false;
                    lb_Item22.Visible = false;
                    cb_Item23.Visible = false;
                    cb_Category23.Visible = false;
                    lb_Item23.Visible = false;
                    cb_Item24.Visible = false;
                    cb_Category24.Visible = false;
                    lb_Item24.Visible = false;
                    cb_Item25.Visible = false;
                    cb_Category25.Visible = false;
                    lb_Item25.Visible = false;
                    cb_Item26.Visible = false;
                    cb_Category26.Visible = false;
                    lb_Item26.Visible = false;
                    cb_Item27.Visible = false;
                    cb_Category27.Visible = false;
                    lb_Item27.Visible = false;
                    cb_Item28.Visible = false;
                    cb_Category28.Visible = false;
                    lb_Item28.Visible = false;
                    cb_Item29.Visible = false;
                    cb_Category29.Visible = false;
                    lb_Item29.Visible = false;
                    cb_Item30.Visible = false;
                    cb_Category30.Visible = false;
                    lb_Item30.Visible = false;
                    cb_Item31.Visible = false;
                    cb_Category31.Visible = false;
                    lb_Item31.Visible = false;
                    cb_Item32.Visible = false;
                    cb_Category32.Visible = false;
                    lb_Item32.Visible = false;
                    btn_RemoveItem.Enabled = true;
                    btn_AddItem.Enabled = true;
                    break;
                case 9:
                    Height = 284;
                    Width = 346;
                    btn_AddItem.Location = new Point(251, 19);
                    btn_RemoveItem.Location = new Point(251, 44);
                    lb_Item.Visible = true;
                    lb_Category.Visible = true;
                    lb_ItemB.Visible = false;
                    lb_CategoryB.Visible = false;
                    cb_Item1.Visible = true;
                    cb_Category1.Visible = true;
                    lb_Item1.Visible = true;
                    cb_Item2.Visible = true;
                    cb_Category2.Visible = true;
                    lb_Item2.Visible = true;
                    cb_Item3.Visible = true;
                    cb_Category3.Visible = true;
                    lb_Item3.Visible = true;
                    cb_Item4.Visible = true;
                    cb_Category4.Visible = true;
                    lb_Item4.Visible = true;
                    cb_Item5.Visible = true;
                    cb_Category5.Visible = true;
                    lb_Item5.Visible = true;
                    cb_Item6.Visible = true;
                    cb_Category6.Visible = true;
                    lb_Item6.Visible = true;
                    cb_Item7.Visible = true;
                    cb_Category7.Visible = true;
                    lb_Item7.Visible = true;
                    cb_Item8.Visible = true;
                    cb_Category8.Visible = true;
                    lb_Item8.Visible = true;
                    cb_Item9.Visible = true;
                    cb_Category9.Visible = true;
                    lb_Item9.Visible = true;
                    cb_Item10.Visible = false;
                    cb_Category10.Visible = false;
                    lb_Item10.Visible = false;
                    cb_Item11.Visible = false;
                    cb_Category11.Visible = false;
                    lb_Item11.Visible = false;
                    cb_Item12.Visible = false;
                    cb_Category12.Visible = false;
                    lb_Item12.Visible = false;
                    cb_Item13.Visible = false;
                    cb_Category13.Visible = false;
                    lb_Item13.Visible = false;
                    cb_Item14.Visible = false;
                    cb_Category14.Visible = false;
                    lb_Item14.Visible = false;
                    cb_Item15.Visible = false;
                    cb_Category15.Visible = false;
                    lb_Item15.Visible = false;
                    cb_Item16.Visible = false;
                    cb_Category16.Visible = false;
                    lb_Item16.Visible = false;
                    cb_Item17.Visible = false;
                    cb_Category17.Visible = false;
                    lb_Item17.Visible = false;
                    cb_Item18.Visible = false;
                    cb_Category18.Visible = false;
                    lb_Item18.Visible = false;
                    cb_Item19.Visible = false;
                    cb_Category19.Visible = false;
                    lb_Item19.Visible = false;
                    cb_Item20.Visible = false;
                    cb_Category20.Visible = false;
                    lb_Item20.Visible = false;
                    cb_Item21.Visible = false;
                    cb_Category21.Visible = false;
                    lb_Item21.Visible = false;
                    cb_Item22.Visible = false;
                    cb_Category22.Visible = false;
                    lb_Item22.Visible = false;
                    cb_Item23.Visible = false;
                    cb_Category23.Visible = false;
                    lb_Item23.Visible = false;
                    cb_Item24.Visible = false;
                    cb_Category24.Visible = false;
                    lb_Item24.Visible = false;
                    cb_Item25.Visible = false;
                    cb_Category25.Visible = false;
                    lb_Item25.Visible = false;
                    cb_Item26.Visible = false;
                    cb_Category26.Visible = false;
                    lb_Item26.Visible = false;
                    cb_Item27.Visible = false;
                    cb_Category27.Visible = false;
                    lb_Item27.Visible = false;
                    cb_Item28.Visible = false;
                    cb_Category28.Visible = false;
                    lb_Item28.Visible = false;
                    cb_Item29.Visible = false;
                    cb_Category29.Visible = false;
                    lb_Item29.Visible = false;
                    cb_Item30.Visible = false;
                    cb_Category30.Visible = false;
                    lb_Item30.Visible = false;
                    cb_Item31.Visible = false;
                    cb_Category31.Visible = false;
                    lb_Item31.Visible = false;
                    cb_Item32.Visible = false;
                    cb_Category32.Visible = false;
                    lb_Item32.Visible = false;
                    btn_RemoveItem.Enabled = true;
                    btn_AddItem.Enabled = true;
                    break;
                case 10:
                    Height = 309;
                    Width = 346;
                    btn_AddItem.Location = new Point(251, 19);
                    btn_RemoveItem.Location = new Point(251, 44);
                    lb_Item.Visible = true;
                    lb_Category.Visible = true;
                    lb_ItemB.Visible = false;
                    lb_CategoryB.Visible = false;
                    cb_Item1.Visible = true;
                    cb_Category1.Visible = true;
                    lb_Item1.Visible = true;
                    cb_Item2.Visible = true;
                    cb_Category2.Visible = true;
                    lb_Item2.Visible = true;
                    cb_Item3.Visible = true;
                    cb_Category3.Visible = true;
                    lb_Item3.Visible = true;
                    cb_Item4.Visible = true;
                    cb_Category4.Visible = true;
                    lb_Item4.Visible = true;
                    cb_Item5.Visible = true;
                    cb_Category5.Visible = true;
                    lb_Item5.Visible = true;
                    cb_Item6.Visible = true;
                    cb_Category6.Visible = true;
                    lb_Item6.Visible = true;
                    cb_Item7.Visible = true;
                    cb_Category7.Visible = true;
                    lb_Item7.Visible = true;
                    cb_Item8.Visible = true;
                    cb_Category8.Visible = true;
                    lb_Item8.Visible = true;
                    cb_Item9.Visible = true;
                    cb_Category9.Visible = true;
                    lb_Item9.Visible = true;
                    cb_Item10.Visible = true;
                    cb_Category10.Visible = true;
                    lb_Item10.Visible = true;
                    cb_Item11.Visible = false;
                    cb_Category11.Visible = false;
                    lb_Item11.Visible = false;
                    cb_Item12.Visible = false;
                    cb_Category12.Visible = false;
                    lb_Item12.Visible = false;
                    cb_Item13.Visible = false;
                    cb_Category13.Visible = false;
                    lb_Item13.Visible = false;
                    cb_Item14.Visible = false;
                    cb_Category14.Visible = false;
                    lb_Item14.Visible = false;
                    cb_Item15.Visible = false;
                    cb_Category15.Visible = false;
                    lb_Item15.Visible = false;
                    cb_Item16.Visible = false;
                    cb_Category16.Visible = false;
                    lb_Item16.Visible = false;
                    cb_Item17.Visible = false;
                    cb_Category17.Visible = false;
                    lb_Item17.Visible = false;
                    cb_Item18.Visible = false;
                    cb_Category18.Visible = false;
                    lb_Item18.Visible = false;
                    cb_Item19.Visible = false;
                    cb_Category19.Visible = false;
                    lb_Item19.Visible = false;
                    cb_Item20.Visible = false;
                    cb_Category20.Visible = false;
                    lb_Item20.Visible = false;
                    cb_Item21.Visible = false;
                    cb_Category21.Visible = false;
                    lb_Item21.Visible = false;
                    cb_Item22.Visible = false;
                    cb_Category22.Visible = false;
                    lb_Item22.Visible = false;
                    cb_Item23.Visible = false;
                    cb_Category23.Visible = false;
                    lb_Item23.Visible = false;
                    cb_Item24.Visible = false;
                    cb_Category24.Visible = false;
                    lb_Item24.Visible = false;
                    cb_Item25.Visible = false;
                    cb_Category25.Visible = false;
                    lb_Item25.Visible = false;
                    cb_Item26.Visible = false;
                    cb_Category26.Visible = false;
                    lb_Item26.Visible = false;
                    cb_Item27.Visible = false;
                    cb_Category27.Visible = false;
                    lb_Item27.Visible = false;
                    cb_Item28.Visible = false;
                    cb_Category28.Visible = false;
                    lb_Item28.Visible = false;
                    cb_Item29.Visible = false;
                    cb_Category29.Visible = false;
                    lb_Item29.Visible = false;
                    cb_Item30.Visible = false;
                    cb_Category30.Visible = false;
                    lb_Item30.Visible = false;
                    cb_Item31.Visible = false;
                    cb_Category31.Visible = false;
                    lb_Item31.Visible = false;
                    cb_Item32.Visible = false;
                    cb_Category32.Visible = false;
                    lb_Item32.Visible = false;
                    btn_RemoveItem.Enabled = true;
                    btn_AddItem.Enabled = true;
                    break;
                case 11:
                    Height = 334;
                    Width = 346;
                    btn_AddItem.Location = new Point(251, 19);
                    btn_RemoveItem.Location = new Point(251, 44);
                    lb_Item.Visible = true;
                    lb_Category.Visible = true;
                    lb_ItemB.Visible = false;
                    lb_CategoryB.Visible = false;
                    cb_Item1.Visible = true;
                    cb_Category1.Visible = true;
                    lb_Item1.Visible = true;
                    cb_Item2.Visible = true;
                    cb_Category2.Visible = true;
                    lb_Item2.Visible = true;
                    cb_Item3.Visible = true;
                    cb_Category3.Visible = true;
                    lb_Item3.Visible = true;
                    cb_Item4.Visible = true;
                    cb_Category4.Visible = true;
                    lb_Item4.Visible = true;
                    cb_Item5.Visible = true;
                    cb_Category5.Visible = true;
                    lb_Item5.Visible = true;
                    cb_Item6.Visible = true;
                    cb_Category6.Visible = true;
                    lb_Item6.Visible = true;
                    cb_Item7.Visible = true;
                    cb_Category7.Visible = true;
                    lb_Item7.Visible = true;
                    cb_Item8.Visible = true;
                    cb_Category8.Visible = true;
                    lb_Item8.Visible = true;
                    cb_Item9.Visible = true;
                    cb_Category9.Visible = true;
                    lb_Item9.Visible = true;
                    cb_Item10.Visible = true;
                    cb_Category10.Visible = true;
                    lb_Item10.Visible = true;
                    cb_Item11.Visible = true;
                    cb_Category11.Visible = true;
                    lb_Item11.Visible = true;
                    cb_Item12.Visible = false;
                    cb_Category12.Visible = false;
                    lb_Item12.Visible = false;
                    cb_Item13.Visible = false;
                    cb_Category13.Visible = false;
                    lb_Item13.Visible = false;
                    cb_Item14.Visible = false;
                    cb_Category14.Visible = false;
                    lb_Item14.Visible = false;
                    cb_Item15.Visible = false;
                    cb_Category15.Visible = false;
                    lb_Item15.Visible = false;
                    cb_Item16.Visible = false;
                    cb_Category16.Visible = false;
                    lb_Item16.Visible = false;
                    cb_Item17.Visible = false;
                    cb_Category17.Visible = false;
                    lb_Item17.Visible = false;
                    cb_Item18.Visible = false;
                    cb_Category18.Visible = false;
                    lb_Item18.Visible = false;
                    cb_Item19.Visible = false;
                    cb_Category19.Visible = false;
                    lb_Item19.Visible = false;
                    cb_Item20.Visible = false;
                    cb_Category20.Visible = false;
                    lb_Item20.Visible = false;
                    cb_Item21.Visible = false;
                    cb_Category21.Visible = false;
                    lb_Item21.Visible = false;
                    cb_Item22.Visible = false;
                    cb_Category22.Visible = false;
                    lb_Item22.Visible = false;
                    cb_Item23.Visible = false;
                    cb_Category23.Visible = false;
                    lb_Item23.Visible = false;
                    cb_Item24.Visible = false;
                    cb_Category24.Visible = false;
                    lb_Item24.Visible = false;
                    cb_Item25.Visible = false;
                    cb_Category25.Visible = false;
                    lb_Item25.Visible = false;
                    cb_Item26.Visible = false;
                    cb_Category26.Visible = false;
                    lb_Item26.Visible = false;
                    cb_Item27.Visible = false;
                    cb_Category27.Visible = false;
                    lb_Item27.Visible = false;
                    cb_Item28.Visible = false;
                    cb_Category28.Visible = false;
                    lb_Item28.Visible = false;
                    cb_Item29.Visible = false;
                    cb_Category29.Visible = false;
                    lb_Item29.Visible = false;
                    cb_Item30.Visible = false;
                    cb_Category30.Visible = false;
                    lb_Item30.Visible = false;
                    cb_Item31.Visible = false;
                    cb_Category31.Visible = false;
                    lb_Item31.Visible = false;
                    cb_Item32.Visible = false;
                    cb_Category32.Visible = false;
                    lb_Item32.Visible = false;
                    btn_RemoveItem.Enabled = true;
                    btn_AddItem.Enabled = true;
                    break;
                case 12:
                    Height = 359;
                    Width = 346;
                    btn_AddItem.Location = new Point(251, 19);
                    btn_RemoveItem.Location = new Point(251, 44);
                    lb_Item.Visible = true;
                    lb_Category.Visible = true;
                    lb_ItemB.Visible = false;
                    lb_CategoryB.Visible = false;
                    cb_Item1.Visible = true;
                    cb_Category1.Visible = true;
                    lb_Item1.Visible = true;
                    cb_Item2.Visible = true;
                    cb_Category2.Visible = true;
                    lb_Item2.Visible = true;
                    cb_Item3.Visible = true;
                    cb_Category3.Visible = true;
                    lb_Item3.Visible = true;
                    cb_Item4.Visible = true;
                    cb_Category4.Visible = true;
                    lb_Item4.Visible = true;
                    cb_Item5.Visible = true;
                    cb_Category5.Visible = true;
                    lb_Item5.Visible = true;
                    cb_Item6.Visible = true;
                    cb_Category6.Visible = true;
                    lb_Item6.Visible = true;
                    cb_Item7.Visible = true;
                    cb_Category7.Visible = true;
                    lb_Item7.Visible = true;
                    cb_Item8.Visible = true;
                    cb_Category8.Visible = true;
                    lb_Item8.Visible = true;
                    cb_Item9.Visible = true;
                    cb_Category9.Visible = true;
                    lb_Item9.Visible = true;
                    cb_Item10.Visible = true;
                    cb_Category10.Visible = true;
                    lb_Item10.Visible = true;
                    cb_Item11.Visible = true;
                    cb_Category11.Visible = true;
                    lb_Item11.Visible = true;
                    cb_Item12.Visible = true;
                    cb_Category12.Visible = true;
                    lb_Item12.Visible = true;
                    cb_Item13.Visible = false;
                    cb_Category13.Visible = false;
                    lb_Item13.Visible = false;
                    cb_Item14.Visible = false;
                    cb_Category14.Visible = false;
                    lb_Item14.Visible = false;
                    cb_Item15.Visible = false;
                    cb_Category15.Visible = false;
                    lb_Item15.Visible = false;
                    cb_Item16.Visible = false;
                    cb_Category16.Visible = false;
                    lb_Item16.Visible = false;
                    cb_Item17.Visible = false;
                    cb_Category17.Visible = false;
                    lb_Item17.Visible = false;
                    cb_Item18.Visible = false;
                    cb_Category18.Visible = false;
                    lb_Item18.Visible = false;
                    cb_Item19.Visible = false;
                    cb_Category19.Visible = false;
                    lb_Item19.Visible = false;
                    cb_Item20.Visible = false;
                    cb_Category20.Visible = false;
                    lb_Item20.Visible = false;
                    cb_Item21.Visible = false;
                    cb_Category21.Visible = false;
                    lb_Item21.Visible = false;
                    cb_Item22.Visible = false;
                    cb_Category22.Visible = false;
                    lb_Item22.Visible = false;
                    cb_Item23.Visible = false;
                    cb_Category23.Visible = false;
                    lb_Item23.Visible = false;
                    cb_Item24.Visible = false;
                    cb_Category24.Visible = false;
                    lb_Item24.Visible = false;
                    cb_Item25.Visible = false;
                    cb_Category25.Visible = false;
                    lb_Item25.Visible = false;
                    cb_Item26.Visible = false;
                    cb_Category26.Visible = false;
                    lb_Item26.Visible = false;
                    cb_Item27.Visible = false;
                    cb_Category27.Visible = false;
                    lb_Item27.Visible = false;
                    cb_Item28.Visible = false;
                    cb_Category28.Visible = false;
                    lb_Item28.Visible = false;
                    cb_Item29.Visible = false;
                    cb_Category29.Visible = false;
                    lb_Item29.Visible = false;
                    cb_Item30.Visible = false;
                    cb_Category30.Visible = false;
                    lb_Item30.Visible = false;
                    cb_Item31.Visible = false;
                    cb_Category31.Visible = false;
                    lb_Item31.Visible = false;
                    cb_Item32.Visible = false;
                    cb_Category32.Visible = false;
                    lb_Item32.Visible = false;
                    btn_RemoveItem.Enabled = true;
                    btn_AddItem.Enabled = true;
                    break;
                case 13:
                    Height = 384;
                    Width = 346;
                    btn_AddItem.Location = new Point(251, 19);
                    btn_RemoveItem.Location = new Point(251, 44);
                    lb_Item.Visible = true;
                    lb_Category.Visible = true;
                    lb_ItemB.Visible = false;
                    lb_CategoryB.Visible = false;
                    cb_Item1.Visible = true;
                    cb_Category1.Visible = true;
                    lb_Item1.Visible = true;
                    cb_Item2.Visible = true;
                    cb_Category2.Visible = true;
                    lb_Item2.Visible = true;
                    cb_Item3.Visible = true;
                    cb_Category3.Visible = true;
                    lb_Item3.Visible = true;
                    cb_Item4.Visible = true;
                    cb_Category4.Visible = true;
                    lb_Item4.Visible = true;
                    cb_Item5.Visible = true;
                    cb_Category5.Visible = true;
                    lb_Item5.Visible = true;
                    cb_Item6.Visible = true;
                    cb_Category6.Visible = true;
                    lb_Item6.Visible = true;
                    cb_Item7.Visible = true;
                    cb_Category7.Visible = true;
                    lb_Item7.Visible = true;
                    cb_Item8.Visible = true;
                    cb_Category8.Visible = true;
                    lb_Item8.Visible = true;
                    cb_Item9.Visible = true;
                    cb_Category9.Visible = true;
                    lb_Item9.Visible = true;
                    cb_Item10.Visible = true;
                    cb_Category10.Visible = true;
                    lb_Item10.Visible = true;
                    cb_Item11.Visible = true;
                    cb_Category11.Visible = true;
                    lb_Item11.Visible = true;
                    cb_Item12.Visible = true;
                    cb_Category12.Visible = true;
                    lb_Item12.Visible = true;
                    cb_Item13.Visible = true;
                    cb_Category13.Visible = true;
                    lb_Item13.Visible = true;
                    cb_Item14.Visible = false;
                    cb_Category14.Visible = false;
                    lb_Item14.Visible = false;
                    cb_Item15.Visible = false;
                    cb_Category15.Visible = false;
                    lb_Item15.Visible = false;
                    cb_Item16.Visible = false;
                    cb_Category16.Visible = false;
                    lb_Item16.Visible = false;
                    cb_Item17.Visible = false;
                    cb_Category17.Visible = false;
                    lb_Item17.Visible = false;
                    cb_Item18.Visible = false;
                    cb_Category18.Visible = false;
                    lb_Item18.Visible = false;
                    cb_Item19.Visible = false;
                    cb_Category19.Visible = false;
                    lb_Item19.Visible = false;
                    cb_Item20.Visible = false;
                    cb_Category20.Visible = false;
                    lb_Item20.Visible = false;
                    cb_Item21.Visible = false;
                    cb_Category21.Visible = false;
                    lb_Item21.Visible = false;
                    cb_Item22.Visible = false;
                    cb_Category22.Visible = false;
                    lb_Item22.Visible = false;
                    cb_Item23.Visible = false;
                    cb_Category23.Visible = false;
                    lb_Item23.Visible = false;
                    cb_Item24.Visible = false;
                    cb_Category24.Visible = false;
                    lb_Item24.Visible = false;
                    cb_Item25.Visible = false;
                    cb_Category25.Visible = false;
                    lb_Item25.Visible = false;
                    cb_Item26.Visible = false;
                    cb_Category26.Visible = false;
                    lb_Item26.Visible = false;
                    cb_Item27.Visible = false;
                    cb_Category27.Visible = false;
                    lb_Item27.Visible = false;
                    cb_Item28.Visible = false;
                    cb_Category28.Visible = false;
                    lb_Item28.Visible = false;
                    cb_Item29.Visible = false;
                    cb_Category29.Visible = false;
                    lb_Item29.Visible = false;
                    cb_Item30.Visible = false;
                    cb_Category30.Visible = false;
                    lb_Item30.Visible = false;
                    cb_Item31.Visible = false;
                    cb_Category31.Visible = false;
                    lb_Item31.Visible = false;
                    cb_Item32.Visible = false;
                    cb_Category32.Visible = false;
                    lb_Item32.Visible = false;
                    btn_RemoveItem.Enabled = true;
                    btn_AddItem.Enabled = true;
                    break;
                case 14:
                    Height = 409;
                    Width = 346;
                    btn_AddItem.Location = new Point(251, 19);
                    btn_RemoveItem.Location = new Point(251, 44);
                    lb_Item.Visible = true;
                    lb_Category.Visible = true;
                    lb_ItemB.Visible = false;
                    lb_CategoryB.Visible = false;
                    cb_Item1.Visible = true;
                    cb_Category1.Visible = true;
                    lb_Item1.Visible = true;
                    cb_Item2.Visible = true;
                    cb_Category2.Visible = true;
                    lb_Item2.Visible = true;
                    cb_Item3.Visible = true;
                    cb_Category3.Visible = true;
                    lb_Item3.Visible = true;
                    cb_Item4.Visible = true;
                    cb_Category4.Visible = true;
                    lb_Item4.Visible = true;
                    cb_Item5.Visible = true;
                    cb_Category5.Visible = true;
                    lb_Item5.Visible = true;
                    cb_Item6.Visible = true;
                    cb_Category6.Visible = true;
                    lb_Item6.Visible = true;
                    cb_Item7.Visible = true;
                    cb_Category7.Visible = true;
                    lb_Item7.Visible = true;
                    cb_Item8.Visible = true;
                    cb_Category8.Visible = true;
                    lb_Item8.Visible = true;
                    cb_Item9.Visible = true;
                    cb_Category9.Visible = true;
                    lb_Item9.Visible = true;
                    cb_Item10.Visible = true;
                    cb_Category10.Visible = true;
                    lb_Item10.Visible = true;
                    cb_Item11.Visible = true;
                    cb_Category11.Visible = true;
                    lb_Item11.Visible = true;
                    cb_Item12.Visible = true;
                    cb_Category12.Visible = true;
                    lb_Item12.Visible = true;
                    cb_Item13.Visible = true;
                    cb_Category13.Visible = true;
                    lb_Item13.Visible = true;
                    cb_Item14.Visible = true;
                    cb_Category14.Visible = true;
                    lb_Item14.Visible = true;
                    cb_Item15.Visible = false;
                    cb_Category15.Visible = false;
                    lb_Item15.Visible = false;
                    cb_Item16.Visible = false;
                    cb_Category16.Visible = false;
                    lb_Item16.Visible = false;
                    cb_Item17.Visible = false;
                    cb_Category17.Visible = false;
                    lb_Item17.Visible = false;
                    cb_Item18.Visible = false;
                    cb_Category18.Visible = false;
                    lb_Item18.Visible = false;
                    cb_Item19.Visible = false;
                    cb_Category19.Visible = false;
                    lb_Item19.Visible = false;
                    cb_Item20.Visible = false;
                    cb_Category20.Visible = false;
                    lb_Item20.Visible = false;
                    cb_Item21.Visible = false;
                    cb_Category21.Visible = false;
                    lb_Item21.Visible = false;
                    cb_Item22.Visible = false;
                    cb_Category22.Visible = false;
                    lb_Item22.Visible = false;
                    cb_Item23.Visible = false;
                    cb_Category23.Visible = false;
                    lb_Item23.Visible = false;
                    cb_Item24.Visible = false;
                    cb_Category24.Visible = false;
                    lb_Item24.Visible = false;
                    cb_Item25.Visible = false;
                    cb_Category25.Visible = false;
                    lb_Item25.Visible = false;
                    cb_Item26.Visible = false;
                    cb_Category26.Visible = false;
                    lb_Item26.Visible = false;
                    cb_Item27.Visible = false;
                    cb_Category27.Visible = false;
                    lb_Item27.Visible = false;
                    cb_Item28.Visible = false;
                    cb_Category28.Visible = false;
                    lb_Item28.Visible = false;
                    cb_Item29.Visible = false;
                    cb_Category29.Visible = false;
                    lb_Item29.Visible = false;
                    cb_Item30.Visible = false;
                    cb_Category30.Visible = false;
                    lb_Item30.Visible = false;
                    cb_Item31.Visible = false;
                    cb_Category31.Visible = false;
                    lb_Item31.Visible = false;
                    cb_Item32.Visible = false;
                    cb_Category32.Visible = false;
                    lb_Item32.Visible = false;
                    btn_RemoveItem.Enabled = true;
                    btn_AddItem.Enabled = true;
                    break;
                case 15:
                    Height = 434;
                    Width = 346;
                    btn_AddItem.Location = new Point(251, 19);
                    btn_RemoveItem.Location = new Point(251, 44);
                    lb_Item.Visible = true;
                    lb_Category.Visible = true;
                    lb_ItemB.Visible = false;
                    lb_CategoryB.Visible = false;
                    cb_Item1.Visible = true;
                    cb_Category1.Visible = true;
                    lb_Item1.Visible = true;
                    cb_Item2.Visible = true;
                    cb_Category2.Visible = true;
                    lb_Item2.Visible = true;
                    cb_Item3.Visible = true;
                    cb_Category3.Visible = true;
                    lb_Item3.Visible = true;
                    cb_Item4.Visible = true;
                    cb_Category4.Visible = true;
                    lb_Item4.Visible = true;
                    cb_Item5.Visible = true;
                    cb_Category5.Visible = true;
                    lb_Item5.Visible = true;
                    cb_Item6.Visible = true;
                    cb_Category6.Visible = true;
                    lb_Item6.Visible = true;
                    cb_Item7.Visible = true;
                    cb_Category7.Visible = true;
                    lb_Item7.Visible = true;
                    cb_Item8.Visible = true;
                    cb_Category8.Visible = true;
                    lb_Item8.Visible = true;
                    cb_Item9.Visible = true;
                    cb_Category9.Visible = true;
                    lb_Item9.Visible = true;
                    cb_Item10.Visible = true;
                    cb_Category10.Visible = true;
                    lb_Item10.Visible = true;
                    cb_Item11.Visible = true;
                    cb_Category11.Visible = true;
                    lb_Item11.Visible = true;
                    cb_Item12.Visible = true;
                    cb_Category12.Visible = true;
                    lb_Item12.Visible = true;
                    cb_Item13.Visible = true;
                    cb_Category13.Visible = true;
                    lb_Item13.Visible = true;
                    cb_Item14.Visible = true;
                    cb_Category14.Visible = true;
                    lb_Item14.Visible = true;
                    cb_Item15.Visible = true;
                    cb_Category15.Visible = true;
                    lb_Item15.Visible = true;
                    cb_Item16.Visible = false;
                    cb_Category16.Visible = false;
                    lb_Item16.Visible = false;
                    cb_Item17.Visible = false;
                    cb_Category17.Visible = false;
                    lb_Item17.Visible = false;
                    cb_Item18.Visible = false;
                    cb_Category18.Visible = false;
                    lb_Item18.Visible = false;
                    cb_Item19.Visible = false;
                    cb_Category19.Visible = false;
                    lb_Item19.Visible = false;
                    cb_Item20.Visible = false;
                    cb_Category20.Visible = false;
                    lb_Item20.Visible = false;
                    cb_Item21.Visible = false;
                    cb_Category21.Visible = false;
                    lb_Item21.Visible = false;
                    cb_Item22.Visible = false;
                    cb_Category22.Visible = false;
                    lb_Item22.Visible = false;
                    cb_Item23.Visible = false;
                    cb_Category23.Visible = false;
                    lb_Item23.Visible = false;
                    cb_Item24.Visible = false;
                    cb_Category24.Visible = false;
                    lb_Item24.Visible = false;
                    cb_Item25.Visible = false;
                    cb_Category25.Visible = false;
                    lb_Item25.Visible = false;
                    cb_Item26.Visible = false;
                    cb_Category26.Visible = false;
                    lb_Item26.Visible = false;
                    cb_Item27.Visible = false;
                    cb_Category27.Visible = false;
                    lb_Item27.Visible = false;
                    cb_Item28.Visible = false;
                    cb_Category28.Visible = false;
                    lb_Item28.Visible = false;
                    cb_Item29.Visible = false;
                    cb_Category29.Visible = false;
                    lb_Item29.Visible = false;
                    cb_Item30.Visible = false;
                    cb_Category30.Visible = false;
                    lb_Item30.Visible = false;
                    cb_Item31.Visible = false;
                    cb_Category31.Visible = false;
                    lb_Item31.Visible = false;
                    cb_Item32.Visible = false;
                    cb_Category32.Visible = false;
                    lb_Item32.Visible = false;
                    btn_RemoveItem.Enabled = true;
                    btn_AddItem.Enabled = true;
                    break;
                case 16:
                    Height = 461;
                    Width = 346;
                    btn_AddItem.Location = new Point(251, 19);
                    btn_RemoveItem.Location = new Point(251, 44);
                    lb_Item.Visible = true;
                    lb_Category.Visible = true;
                    lb_ItemB.Visible = false;
                    lb_CategoryB.Visible = false;
                    cb_Item1.Visible = true;
                    cb_Category1.Visible = true;
                    lb_Item1.Visible = true;
                    cb_Item2.Visible = true;
                    cb_Category2.Visible = true;
                    lb_Item2.Visible = true;
                    cb_Item3.Visible = true;
                    cb_Category3.Visible = true;
                    lb_Item3.Visible = true;
                    cb_Item4.Visible = true;
                    cb_Category4.Visible = true;
                    lb_Item4.Visible = true;
                    cb_Item5.Visible = true;
                    cb_Category5.Visible = true;
                    lb_Item5.Visible = true;
                    cb_Item6.Visible = true;
                    cb_Category6.Visible = true;
                    lb_Item6.Visible = true;
                    cb_Item7.Visible = true;
                    cb_Category7.Visible = true;
                    lb_Item7.Visible = true;
                    cb_Item8.Visible = true;
                    cb_Category8.Visible = true;
                    lb_Item8.Visible = true;
                    cb_Item9.Visible = true;
                    cb_Category9.Visible = true;
                    lb_Item9.Visible = true;
                    cb_Item10.Visible = true;
                    cb_Category10.Visible = true;
                    lb_Item10.Visible = true;
                    cb_Item11.Visible = true;
                    cb_Category11.Visible = true;
                    lb_Item11.Visible = true;
                    cb_Item12.Visible = true;
                    cb_Category12.Visible = true;
                    lb_Item12.Visible = true;
                    cb_Item13.Visible = true;
                    cb_Category13.Visible = true;
                    lb_Item13.Visible = true;
                    cb_Item14.Visible = true;
                    cb_Category14.Visible = true;
                    lb_Item14.Visible = true;
                    cb_Item15.Visible = true;
                    cb_Category15.Visible = true;
                    lb_Item15.Visible = true;
                    cb_Item16.Visible = true;
                    cb_Category16.Visible = true;
                    lb_Item16.Visible = true;
                    cb_Item17.Visible = false;
                    cb_Category17.Visible = false;
                    lb_Item17.Visible = false;
                    cb_Item18.Visible = false;
                    cb_Category18.Visible = false;
                    lb_Item18.Visible = false;
                    cb_Item19.Visible = false;
                    cb_Category19.Visible = false;
                    lb_Item19.Visible = false;
                    cb_Item20.Visible = false;
                    cb_Category20.Visible = false;
                    lb_Item20.Visible = false;
                    cb_Item21.Visible = false;
                    cb_Category21.Visible = false;
                    lb_Item21.Visible = false;
                    cb_Item22.Visible = false;
                    cb_Category22.Visible = false;
                    lb_Item22.Visible = false;
                    cb_Item23.Visible = false;
                    cb_Category23.Visible = false;
                    lb_Item23.Visible = false;
                    cb_Item24.Visible = false;
                    cb_Category24.Visible = false;
                    lb_Item24.Visible = false;
                    cb_Item25.Visible = false;
                    cb_Category25.Visible = false;
                    lb_Item25.Visible = false;
                    cb_Item26.Visible = false;
                    cb_Category26.Visible = false;
                    lb_Item26.Visible = false;
                    cb_Item27.Visible = false;
                    cb_Category27.Visible = false;
                    lb_Item27.Visible = false;
                    cb_Item28.Visible = false;
                    cb_Category28.Visible = false;
                    lb_Item28.Visible = false;
                    cb_Item29.Visible = false;
                    cb_Category29.Visible = false;
                    lb_Item29.Visible = false;
                    cb_Item30.Visible = false;
                    cb_Category30.Visible = false;
                    lb_Item30.Visible = false;
                    cb_Item31.Visible = false;
                    cb_Category31.Visible = false;
                    lb_Item31.Visible = false;
                    cb_Item32.Visible = false;
                    cb_Category32.Visible = false;
                    lb_Item32.Visible = false;
                    btn_RemoveItem.Enabled = true;
                    btn_AddItem.Enabled = true;
                    break;
                case 17:
                    Height = 461;
                    Width = 594;
                    btn_AddItem.Location = new Point(499, 19);
                    btn_RemoveItem.Location = new Point(499, 44);
                    lb_Item.Visible = true;
                    lb_Category.Visible = true;
                    lb_ItemB.Visible = true;
                    lb_CategoryB.Visible = true;
                    cb_Item1.Visible = true;
                    cb_Category1.Visible = true;
                    lb_Item1.Visible = true;
                    cb_Item2.Visible = true;
                    cb_Category2.Visible = true;
                    lb_Item2.Visible = true;
                    cb_Item3.Visible = true;
                    cb_Category3.Visible = true;
                    lb_Item3.Visible = true;
                    cb_Item4.Visible = true;
                    cb_Category4.Visible = true;
                    lb_Item4.Visible = true;
                    cb_Item5.Visible = true;
                    cb_Category5.Visible = true;
                    lb_Item5.Visible = true;
                    cb_Item6.Visible = true;
                    cb_Category6.Visible = true;
                    lb_Item6.Visible = true;
                    cb_Item7.Visible = true;
                    cb_Category7.Visible = true;
                    lb_Item7.Visible = true;
                    cb_Item8.Visible = true;
                    cb_Category8.Visible = true;
                    lb_Item8.Visible = true;
                    cb_Item9.Visible = true;
                    cb_Category9.Visible = true;
                    lb_Item9.Visible = true;
                    cb_Item10.Visible = true;
                    cb_Category10.Visible = true;
                    lb_Item10.Visible = true;
                    cb_Item11.Visible = true;
                    cb_Category11.Visible = true;
                    lb_Item11.Visible = true;
                    cb_Item12.Visible = true;
                    cb_Category12.Visible = true;
                    lb_Item12.Visible = true;
                    cb_Item13.Visible = true;
                    cb_Category13.Visible = true;
                    lb_Item13.Visible = true;
                    cb_Item14.Visible = true;
                    cb_Category14.Visible = true;
                    lb_Item14.Visible = true;
                    cb_Item15.Visible = true;
                    cb_Category15.Visible = true;
                    lb_Item15.Visible = true;
                    cb_Item16.Visible = true;
                    cb_Category16.Visible = true;
                    lb_Item16.Visible = true;
                    cb_Item17.Visible = true;
                    cb_Category17.Visible = true;
                    lb_Item17.Visible = true;
                    cb_Item18.Visible = false;
                    cb_Category18.Visible = false;
                    lb_Item18.Visible = false;
                    cb_Item19.Visible = false;
                    cb_Category19.Visible = false;
                    lb_Item19.Visible = false;
                    cb_Item20.Visible = false;
                    cb_Category20.Visible = false;
                    lb_Item20.Visible = false;
                    cb_Item21.Visible = false;
                    cb_Category21.Visible = false;
                    lb_Item21.Visible = false;
                    cb_Item22.Visible = false;
                    cb_Category22.Visible = false;
                    lb_Item22.Visible = false;
                    cb_Item23.Visible = false;
                    cb_Category23.Visible = false;
                    lb_Item23.Visible = false;
                    cb_Item24.Visible = false;
                    cb_Category24.Visible = false;
                    lb_Item24.Visible = false;
                    cb_Item25.Visible = false;
                    cb_Category25.Visible = false;
                    lb_Item25.Visible = false;
                    cb_Item26.Visible = false;
                    cb_Category26.Visible = false;
                    lb_Item26.Visible = false;
                    cb_Item27.Visible = false;
                    cb_Category27.Visible = false;
                    lb_Item27.Visible = false;
                    cb_Item28.Visible = false;
                    cb_Category28.Visible = false;
                    lb_Item28.Visible = false;
                    cb_Item29.Visible = false;
                    cb_Category29.Visible = false;
                    lb_Item29.Visible = false;
                    cb_Item30.Visible = false;
                    cb_Category30.Visible = false;
                    lb_Item30.Visible = false;
                    cb_Item31.Visible = false;
                    cb_Category31.Visible = false;
                    lb_Item31.Visible = false;
                    cb_Item32.Visible = false;
                    cb_Category32.Visible = false;
                    lb_Item32.Visible = false;
                    btn_RemoveItem.Enabled = true;
                    btn_AddItem.Enabled = true;
                    break;
                case 18:
                    Height = 461;
                    Width = 594;
                    btn_AddItem.Location = new Point(499, 19);
                    btn_RemoveItem.Location = new Point(499, 44);
                    lb_Item.Visible = true;
                    lb_Category.Visible = true;
                    lb_ItemB.Visible = true;
                    lb_CategoryB.Visible = true;
                    cb_Item1.Visible = true;
                    cb_Category1.Visible = true;
                    lb_Item1.Visible = true;
                    cb_Item2.Visible = true;
                    cb_Category2.Visible = true;
                    lb_Item2.Visible = true;
                    cb_Item3.Visible = true;
                    cb_Category3.Visible = true;
                    lb_Item3.Visible = true;
                    cb_Item4.Visible = true;
                    cb_Category4.Visible = true;
                    lb_Item4.Visible = true;
                    cb_Item5.Visible = true;
                    cb_Category5.Visible = true;
                    lb_Item5.Visible = true;
                    cb_Item6.Visible = true;
                    cb_Category6.Visible = true;
                    lb_Item6.Visible = true;
                    cb_Item7.Visible = true;
                    cb_Category7.Visible = true;
                    lb_Item7.Visible = true;
                    cb_Item8.Visible = true;
                    cb_Category8.Visible = true;
                    lb_Item8.Visible = true;
                    cb_Item9.Visible = true;
                    cb_Category9.Visible = true;
                    lb_Item9.Visible = true;
                    cb_Item10.Visible = true;
                    cb_Category10.Visible = true;
                    lb_Item10.Visible = true;
                    cb_Item11.Visible = true;
                    cb_Category11.Visible = true;
                    lb_Item11.Visible = true;
                    cb_Item12.Visible = true;
                    cb_Category12.Visible = true;
                    lb_Item12.Visible = true;
                    cb_Item13.Visible = true;
                    cb_Category13.Visible = true;
                    lb_Item13.Visible = true;
                    cb_Item14.Visible = true;
                    cb_Category14.Visible = true;
                    lb_Item14.Visible = true;
                    cb_Item15.Visible = true;
                    cb_Category15.Visible = true;
                    lb_Item15.Visible = true;
                    cb_Item16.Visible = true;
                    cb_Category16.Visible = true;
                    lb_Item16.Visible = true;
                    cb_Item17.Visible = true;
                    cb_Category17.Visible = true;
                    lb_Item17.Visible = true;
                    cb_Item18.Visible = true;
                    cb_Category18.Visible = true;
                    lb_Item18.Visible = true;
                    cb_Item19.Visible = false;
                    cb_Category19.Visible = false;
                    lb_Item19.Visible = false;
                    cb_Item20.Visible = false;
                    cb_Category20.Visible = false;
                    lb_Item20.Visible = false;
                    cb_Item21.Visible = false;
                    cb_Category21.Visible = false;
                    lb_Item21.Visible = false;
                    cb_Item22.Visible = false;
                    cb_Category22.Visible = false;
                    lb_Item22.Visible = false;
                    cb_Item23.Visible = false;
                    cb_Category23.Visible = false;
                    lb_Item23.Visible = false;
                    cb_Item24.Visible = false;
                    cb_Category24.Visible = false;
                    lb_Item24.Visible = false;
                    cb_Item25.Visible = false;
                    cb_Category25.Visible = false;
                    lb_Item25.Visible = false;
                    cb_Item26.Visible = false;
                    cb_Category26.Visible = false;
                    lb_Item26.Visible = false;
                    cb_Item27.Visible = false;
                    cb_Category27.Visible = false;
                    lb_Item27.Visible = false;
                    cb_Item28.Visible = false;
                    cb_Category28.Visible = false;
                    lb_Item28.Visible = false;
                    cb_Item29.Visible = false;
                    cb_Category29.Visible = false;
                    lb_Item29.Visible = false;
                    cb_Item30.Visible = false;
                    cb_Category30.Visible = false;
                    lb_Item30.Visible = false;
                    cb_Item31.Visible = false;
                    cb_Category31.Visible = false;
                    lb_Item31.Visible = false;
                    cb_Item32.Visible = false;
                    cb_Category32.Visible = false;
                    lb_Item32.Visible = false;
                    btn_RemoveItem.Enabled = true;
                    btn_AddItem.Enabled = true;
                    break;
                case 19:
                    Height = 461;
                    Width = 594;
                    btn_AddItem.Location = new Point(499, 19);
                    btn_RemoveItem.Location = new Point(499, 44);
                    lb_Item.Visible = true;
                    lb_Category.Visible = true;
                    lb_ItemB.Visible = true;
                    lb_CategoryB.Visible = true;
                    cb_Item1.Visible = true;
                    cb_Category1.Visible = true;
                    lb_Item1.Visible = true;
                    cb_Item2.Visible = true;
                    cb_Category2.Visible = true;
                    lb_Item2.Visible = true;
                    cb_Item3.Visible = true;
                    cb_Category3.Visible = true;
                    lb_Item3.Visible = true;
                    cb_Item4.Visible = true;
                    cb_Category4.Visible = true;
                    lb_Item4.Visible = true;
                    cb_Item5.Visible = true;
                    cb_Category5.Visible = true;
                    lb_Item5.Visible = true;
                    cb_Item6.Visible = true;
                    cb_Category6.Visible = true;
                    lb_Item6.Visible = true;
                    cb_Item7.Visible = true;
                    cb_Category7.Visible = true;
                    lb_Item7.Visible = true;
                    cb_Item8.Visible = true;
                    cb_Category8.Visible = true;
                    lb_Item8.Visible = true;
                    cb_Item9.Visible = true;
                    cb_Category9.Visible = true;
                    lb_Item9.Visible = true;
                    cb_Item10.Visible = true;
                    cb_Category10.Visible = true;
                    lb_Item10.Visible = true;
                    cb_Item11.Visible = true;
                    cb_Category11.Visible = true;
                    lb_Item11.Visible = true;
                    cb_Item12.Visible = true;
                    cb_Category12.Visible = true;
                    lb_Item12.Visible = true;
                    cb_Item13.Visible = true;
                    cb_Category13.Visible = true;
                    lb_Item13.Visible = true;
                    cb_Item14.Visible = true;
                    cb_Category14.Visible = true;
                    lb_Item14.Visible = true;
                    cb_Item15.Visible = true;
                    cb_Category15.Visible = true;
                    lb_Item15.Visible = true;
                    cb_Item16.Visible = true;
                    cb_Category16.Visible = true;
                    lb_Item16.Visible = true;
                    cb_Item17.Visible = true;
                    cb_Category17.Visible = true;
                    lb_Item17.Visible = true;
                    cb_Item18.Visible = true;
                    cb_Category18.Visible = true;
                    lb_Item18.Visible = true;
                    cb_Item19.Visible = true;
                    cb_Category19.Visible = true;
                    lb_Item19.Visible = true;
                    cb_Item20.Visible = false;
                    cb_Category20.Visible = false;
                    lb_Item20.Visible = false;
                    cb_Item21.Visible = false;
                    cb_Category21.Visible = false;
                    lb_Item21.Visible = false;
                    cb_Item22.Visible = false;
                    cb_Category22.Visible = false;
                    lb_Item22.Visible = false;
                    cb_Item23.Visible = false;
                    cb_Category23.Visible = false;
                    lb_Item23.Visible = false;
                    cb_Item24.Visible = false;
                    cb_Category24.Visible = false;
                    lb_Item24.Visible = false;
                    cb_Item25.Visible = false;
                    cb_Category25.Visible = false;
                    lb_Item25.Visible = false;
                    cb_Item26.Visible = false;
                    cb_Category26.Visible = false;
                    lb_Item26.Visible = false;
                    cb_Item27.Visible = false;
                    cb_Category27.Visible = false;
                    lb_Item27.Visible = false;
                    cb_Item28.Visible = false;
                    cb_Category28.Visible = false;
                    lb_Item28.Visible = false;
                    cb_Item29.Visible = false;
                    cb_Category29.Visible = false;
                    lb_Item29.Visible = false;
                    cb_Item30.Visible = false;
                    cb_Category30.Visible = false;
                    lb_Item30.Visible = false;
                    cb_Item31.Visible = false;
                    cb_Category31.Visible = false;
                    lb_Item31.Visible = false;
                    cb_Item32.Visible = false;
                    cb_Category32.Visible = false;
                    lb_Item32.Visible = false;
                    btn_RemoveItem.Enabled = true;
                    btn_AddItem.Enabled = true;
                    break;
                case 20:
                    Height = 461;
                    Width = 594;
                    btn_AddItem.Location = new Point(499, 19);
                    btn_RemoveItem.Location = new Point(499, 44);
                    lb_Item.Visible = true;
                    lb_Category.Visible = true;
                    lb_ItemB.Visible = true;
                    lb_CategoryB.Visible = true;
                    cb_Item1.Visible = true;
                    cb_Category1.Visible = true;
                    lb_Item1.Visible = true;
                    cb_Item2.Visible = true;
                    cb_Category2.Visible = true;
                    lb_Item2.Visible = true;
                    cb_Item3.Visible = true;
                    cb_Category3.Visible = true;
                    lb_Item3.Visible = true;
                    cb_Item4.Visible = true;
                    cb_Category4.Visible = true;
                    lb_Item4.Visible = true;
                    cb_Item5.Visible = true;
                    cb_Category5.Visible = true;
                    lb_Item5.Visible = true;
                    cb_Item6.Visible = true;
                    cb_Category6.Visible = true;
                    lb_Item6.Visible = true;
                    cb_Item7.Visible = true;
                    cb_Category7.Visible = true;
                    lb_Item7.Visible = true;
                    cb_Item8.Visible = true;
                    cb_Category8.Visible = true;
                    lb_Item8.Visible = true;
                    cb_Item9.Visible = true;
                    cb_Category9.Visible = true;
                    lb_Item9.Visible = true;
                    cb_Item10.Visible = true;
                    cb_Category10.Visible = true;
                    lb_Item10.Visible = true;
                    cb_Item11.Visible = true;
                    cb_Category11.Visible = true;
                    lb_Item11.Visible = true;
                    cb_Item12.Visible = true;
                    cb_Category12.Visible = true;
                    lb_Item12.Visible = true;
                    cb_Item13.Visible = true;
                    cb_Category13.Visible = true;
                    lb_Item13.Visible = true;
                    cb_Item14.Visible = true;
                    cb_Category14.Visible = true;
                    lb_Item14.Visible = true;
                    cb_Item15.Visible = true;
                    cb_Category15.Visible = true;
                    lb_Item15.Visible = true;
                    cb_Item16.Visible = true;
                    cb_Category16.Visible = true;
                    lb_Item16.Visible = true;
                    cb_Item17.Visible = true;
                    cb_Category17.Visible = true;
                    lb_Item17.Visible = true;
                    cb_Item18.Visible = true;
                    cb_Category18.Visible = true;
                    lb_Item18.Visible = true;
                    cb_Item19.Visible = true;
                    cb_Category19.Visible = true;
                    lb_Item19.Visible = true;
                    cb_Item20.Visible = true;
                    cb_Category20.Visible = true;
                    lb_Item20.Visible = true;
                    cb_Item21.Visible = false;
                    cb_Category21.Visible = false;
                    lb_Item21.Visible = false;
                    cb_Item22.Visible = false;
                    cb_Category22.Visible = false;
                    lb_Item22.Visible = false;
                    cb_Item23.Visible = false;
                    cb_Category23.Visible = false;
                    lb_Item23.Visible = false;
                    cb_Item24.Visible = false;
                    cb_Category24.Visible = false;
                    lb_Item24.Visible = false;
                    cb_Item25.Visible = false;
                    cb_Category25.Visible = false;
                    lb_Item25.Visible = false;
                    cb_Item26.Visible = false;
                    cb_Category26.Visible = false;
                    lb_Item26.Visible = false;
                    cb_Item27.Visible = false;
                    cb_Category27.Visible = false;
                    lb_Item27.Visible = false;
                    cb_Item28.Visible = false;
                    cb_Category28.Visible = false;
                    lb_Item28.Visible = false;
                    cb_Item29.Visible = false;
                    cb_Category29.Visible = false;
                    lb_Item29.Visible = false;
                    cb_Item30.Visible = false;
                    cb_Category30.Visible = false;
                    lb_Item30.Visible = false;
                    cb_Item31.Visible = false;
                    cb_Category31.Visible = false;
                    lb_Item31.Visible = false;
                    cb_Item32.Visible = false;
                    cb_Category32.Visible = false;
                    lb_Item32.Visible = false;
                    btn_RemoveItem.Enabled = true;
                    btn_AddItem.Enabled = true;
                    break;
                case 21:
                    Height = 461;
                    Width = 594;
                    btn_AddItem.Location = new Point(499, 19);
                    btn_RemoveItem.Location = new Point(499, 44);
                    lb_Item.Visible = true;
                    lb_Category.Visible = true;
                    lb_ItemB.Visible = true;
                    lb_CategoryB.Visible = true;
                    cb_Item1.Visible = true;
                    cb_Category1.Visible = true;
                    lb_Item1.Visible = true;
                    cb_Item2.Visible = true;
                    cb_Category2.Visible = true;
                    lb_Item2.Visible = true;
                    cb_Item3.Visible = true;
                    cb_Category3.Visible = true;
                    lb_Item3.Visible = true;
                    cb_Item4.Visible = true;
                    cb_Category4.Visible = true;
                    lb_Item4.Visible = true;
                    cb_Item5.Visible = true;
                    cb_Category5.Visible = true;
                    lb_Item5.Visible = true;
                    cb_Item6.Visible = true;
                    cb_Category6.Visible = true;
                    lb_Item6.Visible = true;
                    cb_Item7.Visible = true;
                    cb_Category7.Visible = true;
                    lb_Item7.Visible = true;
                    cb_Item8.Visible = true;
                    cb_Category8.Visible = true;
                    lb_Item8.Visible = true;
                    cb_Item9.Visible = true;
                    cb_Category9.Visible = true;
                    lb_Item9.Visible = true;
                    cb_Item10.Visible = true;
                    cb_Category10.Visible = true;
                    lb_Item10.Visible = true;
                    cb_Item11.Visible = true;
                    cb_Category11.Visible = true;
                    lb_Item11.Visible = true;
                    cb_Item12.Visible = true;
                    cb_Category12.Visible = true;
                    lb_Item12.Visible = true;
                    cb_Item13.Visible = true;
                    cb_Category13.Visible = true;
                    lb_Item13.Visible = true;
                    cb_Item14.Visible = true;
                    cb_Category14.Visible = true;
                    lb_Item14.Visible = true;
                    cb_Item15.Visible = true;
                    cb_Category15.Visible = true;
                    lb_Item15.Visible = true;
                    cb_Item16.Visible = true;
                    cb_Category16.Visible = true;
                    lb_Item16.Visible = true;
                    cb_Item17.Visible = true;
                    cb_Category17.Visible = true;
                    lb_Item17.Visible = true;
                    cb_Item18.Visible = true;
                    cb_Category18.Visible = true;
                    lb_Item18.Visible = true;
                    cb_Item19.Visible = true;
                    cb_Category19.Visible = true;
                    lb_Item19.Visible = true;
                    cb_Item20.Visible = true;
                    cb_Category20.Visible = true;
                    lb_Item20.Visible = true;
                    cb_Item21.Visible = true;
                    cb_Category21.Visible = true;
                    lb_Item21.Visible = true;
                    cb_Item22.Visible = false;
                    cb_Category22.Visible = false;
                    lb_Item22.Visible = false;
                    cb_Item23.Visible = false;
                    cb_Category23.Visible = false;
                    lb_Item23.Visible = false;
                    cb_Item24.Visible = false;
                    cb_Category24.Visible = false;
                    lb_Item24.Visible = false;
                    cb_Item25.Visible = false;
                    cb_Category25.Visible = false;
                    lb_Item25.Visible = false;
                    cb_Item26.Visible = false;
                    cb_Category26.Visible = false;
                    lb_Item26.Visible = false;
                    cb_Item27.Visible = false;
                    cb_Category27.Visible = false;
                    lb_Item27.Visible = false;
                    cb_Item28.Visible = false;
                    cb_Category28.Visible = false;
                    lb_Item28.Visible = false;
                    cb_Item29.Visible = false;
                    cb_Category29.Visible = false;
                    lb_Item29.Visible = false;
                    cb_Item30.Visible = false;
                    cb_Category30.Visible = false;
                    lb_Item30.Visible = false;
                    cb_Item31.Visible = false;
                    cb_Category31.Visible = false;
                    lb_Item31.Visible = false;
                    cb_Item32.Visible = false;
                    cb_Category32.Visible = false;
                    lb_Item32.Visible = false;
                    btn_RemoveItem.Enabled = true;
                    btn_AddItem.Enabled = true;
                    break;
                case 22:
                    Height = 461;
                    Width = 594;
                    btn_AddItem.Location = new Point(499, 19);
                    btn_RemoveItem.Location = new Point(499, 44);
                    lb_Item.Visible = true;
                    lb_Category.Visible = true;
                    lb_ItemB.Visible = true;
                    lb_CategoryB.Visible = true;
                    cb_Item1.Visible = true;
                    cb_Category1.Visible = true;
                    lb_Item1.Visible = true;
                    cb_Item2.Visible = true;
                    cb_Category2.Visible = true;
                    lb_Item2.Visible = true;
                    cb_Item3.Visible = true;
                    cb_Category3.Visible = true;
                    lb_Item3.Visible = true;
                    cb_Item4.Visible = true;
                    cb_Category4.Visible = true;
                    lb_Item4.Visible = true;
                    cb_Item5.Visible = true;
                    cb_Category5.Visible = true;
                    lb_Item5.Visible = true;
                    cb_Item6.Visible = true;
                    cb_Category6.Visible = true;
                    lb_Item6.Visible = true;
                    cb_Item7.Visible = true;
                    cb_Category7.Visible = true;
                    lb_Item7.Visible = true;
                    cb_Item8.Visible = true;
                    cb_Category8.Visible = true;
                    lb_Item8.Visible = true;
                    cb_Item9.Visible = true;
                    cb_Category9.Visible = true;
                    lb_Item9.Visible = true;
                    cb_Item10.Visible = true;
                    cb_Category10.Visible = true;
                    lb_Item10.Visible = true;
                    cb_Item11.Visible = true;
                    cb_Category11.Visible = true;
                    lb_Item11.Visible = true;
                    cb_Item12.Visible = true;
                    cb_Category12.Visible = true;
                    lb_Item12.Visible = true;
                    cb_Item13.Visible = true;
                    cb_Category13.Visible = true;
                    lb_Item13.Visible = true;
                    cb_Item14.Visible = true;
                    cb_Category14.Visible = true;
                    lb_Item14.Visible = true;
                    cb_Item15.Visible = true;
                    cb_Category15.Visible = true;
                    lb_Item15.Visible = true;
                    cb_Item16.Visible = true;
                    cb_Category16.Visible = true;
                    lb_Item16.Visible = true;
                    cb_Item17.Visible = true;
                    cb_Category17.Visible = true;
                    lb_Item17.Visible = true;
                    cb_Item18.Visible = true;
                    cb_Category18.Visible = true;
                    lb_Item18.Visible = true;
                    cb_Item19.Visible = true;
                    cb_Category19.Visible = true;
                    lb_Item19.Visible = true;
                    cb_Item20.Visible = true;
                    cb_Category20.Visible = true;
                    lb_Item20.Visible = true;
                    cb_Item21.Visible = true;
                    cb_Category21.Visible = true;
                    lb_Item21.Visible = true;
                    cb_Item22.Visible = true;
                    cb_Category22.Visible = true;
                    lb_Item22.Visible = true;
                    cb_Item23.Visible = false;
                    cb_Category23.Visible = false;
                    lb_Item23.Visible = false;
                    cb_Item24.Visible = false;
                    cb_Category24.Visible = false;
                    lb_Item24.Visible = false;
                    cb_Item25.Visible = false;
                    cb_Category25.Visible = false;
                    lb_Item25.Visible = false;
                    cb_Item26.Visible = false;
                    cb_Category26.Visible = false;
                    lb_Item26.Visible = false;
                    cb_Item27.Visible = false;
                    cb_Category27.Visible = false;
                    lb_Item27.Visible = false;
                    cb_Item28.Visible = false;
                    cb_Category28.Visible = false;
                    lb_Item28.Visible = false;
                    cb_Item29.Visible = false;
                    cb_Category29.Visible = false;
                    lb_Item29.Visible = false;
                    cb_Item30.Visible = false;
                    cb_Category30.Visible = false;
                    lb_Item30.Visible = false;
                    cb_Item31.Visible = false;
                    cb_Category31.Visible = false;
                    lb_Item31.Visible = false;
                    cb_Item32.Visible = false;
                    cb_Category32.Visible = false;
                    lb_Item32.Visible = false;
                    btn_RemoveItem.Enabled = true;
                    btn_AddItem.Enabled = true;
                    break;
                case 23:
                    Height = 461;
                    Width = 594;
                    btn_AddItem.Location = new Point(499, 19);
                    btn_RemoveItem.Location = new Point(499, 44);
                    lb_Item.Visible = true;
                    lb_Category.Visible = true;
                    lb_ItemB.Visible = true;
                    lb_CategoryB.Visible = true;
                    cb_Item1.Visible = true;
                    cb_Category1.Visible = true;
                    lb_Item1.Visible = true;
                    cb_Item2.Visible = true;
                    cb_Category2.Visible = true;
                    lb_Item2.Visible = true;
                    cb_Item3.Visible = true;
                    cb_Category3.Visible = true;
                    lb_Item3.Visible = true;
                    cb_Item4.Visible = true;
                    cb_Category4.Visible = true;
                    lb_Item4.Visible = true;
                    cb_Item5.Visible = true;
                    cb_Category5.Visible = true;
                    lb_Item5.Visible = true;
                    cb_Item6.Visible = true;
                    cb_Category6.Visible = true;
                    lb_Item6.Visible = true;
                    cb_Item7.Visible = true;
                    cb_Category7.Visible = true;
                    lb_Item7.Visible = true;
                    cb_Item8.Visible = true;
                    cb_Category8.Visible = true;
                    lb_Item8.Visible = true;
                    cb_Item9.Visible = true;
                    cb_Category9.Visible = true;
                    lb_Item9.Visible = true;
                    cb_Item10.Visible = true;
                    cb_Category10.Visible = true;
                    lb_Item10.Visible = true;
                    cb_Item11.Visible = true;
                    cb_Category11.Visible = true;
                    lb_Item11.Visible = true;
                    cb_Item12.Visible = true;
                    cb_Category12.Visible = true;
                    lb_Item12.Visible = true;
                    cb_Item13.Visible = true;
                    cb_Category13.Visible = true;
                    lb_Item13.Visible = true;
                    cb_Item14.Visible = true;
                    cb_Category14.Visible = true;
                    lb_Item14.Visible = true;
                    cb_Item15.Visible = true;
                    cb_Category15.Visible = true;
                    lb_Item15.Visible = true;
                    cb_Item16.Visible = true;
                    cb_Category16.Visible = true;
                    lb_Item16.Visible = true;
                    cb_Item17.Visible = true;
                    cb_Category17.Visible = true;
                    lb_Item17.Visible = true;
                    cb_Item18.Visible = true;
                    cb_Category18.Visible = true;
                    lb_Item18.Visible = true;
                    cb_Item19.Visible = true;
                    cb_Category19.Visible = true;
                    lb_Item19.Visible = true;
                    cb_Item20.Visible = true;
                    cb_Category20.Visible = true;
                    lb_Item20.Visible = true;
                    cb_Item21.Visible = true;
                    cb_Category21.Visible = true;
                    lb_Item21.Visible = true;
                    cb_Item22.Visible = true;
                    cb_Category22.Visible = true;
                    lb_Item22.Visible = true;
                    cb_Item23.Visible = true;
                    cb_Category23.Visible = true;
                    lb_Item23.Visible = true;
                    cb_Item24.Visible = false;
                    cb_Category24.Visible = false;
                    lb_Item24.Visible = false;
                    cb_Item25.Visible = false;
                    cb_Category25.Visible = false;
                    lb_Item25.Visible = false;
                    cb_Item26.Visible = false;
                    cb_Category26.Visible = false;
                    lb_Item26.Visible = false;
                    cb_Item27.Visible = false;
                    cb_Category27.Visible = false;
                    lb_Item27.Visible = false;
                    cb_Item28.Visible = false;
                    cb_Category28.Visible = false;
                    lb_Item28.Visible = false;
                    cb_Item29.Visible = false;
                    cb_Category29.Visible = false;
                    lb_Item29.Visible = false;
                    cb_Item30.Visible = false;
                    cb_Category30.Visible = false;
                    lb_Item30.Visible = false;
                    cb_Item31.Visible = false;
                    cb_Category31.Visible = false;
                    lb_Item31.Visible = false;
                    cb_Item32.Visible = false;
                    cb_Category32.Visible = false;
                    lb_Item32.Visible = false;
                    btn_RemoveItem.Enabled = true;
                    btn_AddItem.Enabled = true;
                    break;
                case 24:
                    Height = 461;
                    Width = 594;
                    btn_AddItem.Location = new Point(499, 19);
                    btn_RemoveItem.Location = new Point(499, 44);
                    lb_Item.Visible = true;
                    lb_Category.Visible = true;
                    lb_ItemB.Visible = true;
                    lb_CategoryB.Visible = true;
                    cb_Item1.Visible = true;
                    cb_Category1.Visible = true;
                    lb_Item1.Visible = true;
                    cb_Item2.Visible = true;
                    cb_Category2.Visible = true;
                    lb_Item2.Visible = true;
                    cb_Item3.Visible = true;
                    cb_Category3.Visible = true;
                    lb_Item3.Visible = true;
                    cb_Item4.Visible = true;
                    cb_Category4.Visible = true;
                    lb_Item4.Visible = true;
                    cb_Item5.Visible = true;
                    cb_Category5.Visible = true;
                    lb_Item5.Visible = true;
                    cb_Item6.Visible = true;
                    cb_Category6.Visible = true;
                    lb_Item6.Visible = true;
                    cb_Item7.Visible = true;
                    cb_Category7.Visible = true;
                    lb_Item7.Visible = true;
                    cb_Item8.Visible = true;
                    cb_Category8.Visible = true;
                    lb_Item8.Visible = true;
                    cb_Item9.Visible = true;
                    cb_Category9.Visible = true;
                    lb_Item9.Visible = true;
                    cb_Item10.Visible = true;
                    cb_Category10.Visible = true;
                    lb_Item10.Visible = true;
                    cb_Item11.Visible = true;
                    cb_Category11.Visible = true;
                    lb_Item11.Visible = true;
                    cb_Item12.Visible = true;
                    cb_Category12.Visible = true;
                    lb_Item12.Visible = true;
                    cb_Item13.Visible = true;
                    cb_Category13.Visible = true;
                    lb_Item13.Visible = true;
                    cb_Item14.Visible = true;
                    cb_Category14.Visible = true;
                    lb_Item14.Visible = true;
                    cb_Item15.Visible = true;
                    cb_Category15.Visible = true;
                    lb_Item15.Visible = true;
                    cb_Item16.Visible = true;
                    cb_Category16.Visible = true;
                    lb_Item16.Visible = true;
                    cb_Item17.Visible = true;
                    cb_Category17.Visible = true;
                    lb_Item17.Visible = true;
                    cb_Item18.Visible = true;
                    cb_Category18.Visible = true;
                    lb_Item18.Visible = true;
                    cb_Item19.Visible = true;
                    cb_Category19.Visible = true;
                    lb_Item19.Visible = true;
                    cb_Item20.Visible = true;
                    cb_Category20.Visible = true;
                    lb_Item20.Visible = true;
                    cb_Item21.Visible = true;
                    cb_Category21.Visible = true;
                    lb_Item21.Visible = true;
                    cb_Item22.Visible = true;
                    cb_Category22.Visible = true;
                    lb_Item22.Visible = true;
                    cb_Item23.Visible = true;
                    cb_Category23.Visible = true;
                    lb_Item23.Visible = true;
                    cb_Item24.Visible = true;
                    cb_Category24.Visible = true;
                    lb_Item24.Visible = true;
                    cb_Item25.Visible = false;
                    cb_Category25.Visible = false;
                    lb_Item25.Visible = false;
                    cb_Item26.Visible = false;
                    cb_Category26.Visible = false;
                    lb_Item26.Visible = false;
                    cb_Item27.Visible = false;
                    cb_Category27.Visible = false;
                    lb_Item27.Visible = false;
                    cb_Item28.Visible = false;
                    cb_Category28.Visible = false;
                    lb_Item28.Visible = false;
                    cb_Item29.Visible = false;
                    cb_Category29.Visible = false;
                    lb_Item29.Visible = false;
                    cb_Item30.Visible = false;
                    cb_Category30.Visible = false;
                    lb_Item30.Visible = false;
                    cb_Item31.Visible = false;
                    cb_Category31.Visible = false;
                    lb_Item31.Visible = false;
                    cb_Item32.Visible = false;
                    cb_Category32.Visible = false;
                    lb_Item32.Visible = false;
                    btn_RemoveItem.Enabled = true;
                    btn_AddItem.Enabled = true;
                    break;
                case 25:
                    Height = 461;
                    Width = 594;
                    btn_AddItem.Location = new Point(499, 19);
                    btn_RemoveItem.Location = new Point(499, 44);
                    lb_Item.Visible = true;
                    lb_Category.Visible = true;
                    lb_ItemB.Visible = true;
                    lb_CategoryB.Visible = true;
                    cb_Item1.Visible = true;
                    cb_Category1.Visible = true;
                    lb_Item1.Visible = true;
                    cb_Item2.Visible = true;
                    cb_Category2.Visible = true;
                    lb_Item2.Visible = true;
                    cb_Item3.Visible = true;
                    cb_Category3.Visible = true;
                    lb_Item3.Visible = true;
                    cb_Item4.Visible = true;
                    cb_Category4.Visible = true;
                    lb_Item4.Visible = true;
                    cb_Item5.Visible = true;
                    cb_Category5.Visible = true;
                    lb_Item5.Visible = true;
                    cb_Item6.Visible = true;
                    cb_Category6.Visible = true;
                    lb_Item6.Visible = true;
                    cb_Item7.Visible = true;
                    cb_Category7.Visible = true;
                    lb_Item7.Visible = true;
                    cb_Item8.Visible = true;
                    cb_Category8.Visible = true;
                    lb_Item8.Visible = true;
                    cb_Item9.Visible = true;
                    cb_Category9.Visible = true;
                    lb_Item9.Visible = true;
                    cb_Item10.Visible = true;
                    cb_Category10.Visible = true;
                    lb_Item10.Visible = true;
                    cb_Item11.Visible = true;
                    cb_Category11.Visible = true;
                    lb_Item11.Visible = true;
                    cb_Item12.Visible = true;
                    cb_Category12.Visible = true;
                    lb_Item12.Visible = true;
                    cb_Item13.Visible = true;
                    cb_Category13.Visible = true;
                    lb_Item13.Visible = true;
                    cb_Item14.Visible = true;
                    cb_Category14.Visible = true;
                    lb_Item14.Visible = true;
                    cb_Item15.Visible = true;
                    cb_Category15.Visible = true;
                    lb_Item15.Visible = true;
                    cb_Item16.Visible = true;
                    cb_Category16.Visible = true;
                    lb_Item16.Visible = true;
                    cb_Item17.Visible = true;
                    cb_Category17.Visible = true;
                    lb_Item17.Visible = true;
                    cb_Item18.Visible = true;
                    cb_Category18.Visible = true;
                    lb_Item18.Visible = true;
                    cb_Item19.Visible = true;
                    cb_Category19.Visible = true;
                    lb_Item19.Visible = true;
                    cb_Item20.Visible = true;
                    cb_Category20.Visible = true;
                    lb_Item20.Visible = true;
                    cb_Item21.Visible = true;
                    cb_Category21.Visible = true;
                    lb_Item21.Visible = true;
                    cb_Item22.Visible = true;
                    cb_Category22.Visible = true;
                    lb_Item22.Visible = true;
                    cb_Item23.Visible = true;
                    cb_Category23.Visible = true;
                    lb_Item23.Visible = true;
                    cb_Item24.Visible = true;
                    cb_Category24.Visible = true;
                    lb_Item24.Visible = true;
                    cb_Item25.Visible = true;
                    cb_Category25.Visible = true;
                    lb_Item25.Visible = true;
                    cb_Item26.Visible = false;
                    cb_Category26.Visible = false;
                    lb_Item26.Visible = false;
                    cb_Item27.Visible = false;
                    cb_Category27.Visible = false;
                    lb_Item27.Visible = false;
                    cb_Item28.Visible = false;
                    cb_Category28.Visible = false;
                    lb_Item28.Visible = false;
                    cb_Item29.Visible = false;
                    cb_Category29.Visible = false;
                    lb_Item29.Visible = false;
                    cb_Item30.Visible = false;
                    cb_Category30.Visible = false;
                    lb_Item30.Visible = false;
                    cb_Item31.Visible = false;
                    cb_Category31.Visible = false;
                    lb_Item31.Visible = false;
                    cb_Item32.Visible = false;
                    cb_Category32.Visible = false;
                    lb_Item32.Visible = false;
                    btn_RemoveItem.Enabled = true;
                    btn_AddItem.Enabled = true;
                    break;
                case 26:
                    Height = 461;
                    Width = 594;
                    btn_AddItem.Location = new Point(499, 19);
                    btn_RemoveItem.Location = new Point(499, 44);
                    lb_Item.Visible = true;
                    lb_Category.Visible = true;
                    lb_ItemB.Visible = true;
                    lb_CategoryB.Visible = true;
                    cb_Item1.Visible = true;
                    cb_Category1.Visible = true;
                    lb_Item1.Visible = true;
                    cb_Item2.Visible = true;
                    cb_Category2.Visible = true;
                    lb_Item2.Visible = true;
                    cb_Item3.Visible = true;
                    cb_Category3.Visible = true;
                    lb_Item3.Visible = true;
                    cb_Item4.Visible = true;
                    cb_Category4.Visible = true;
                    lb_Item4.Visible = true;
                    cb_Item5.Visible = true;
                    cb_Category5.Visible = true;
                    lb_Item5.Visible = true;
                    cb_Item6.Visible = true;
                    cb_Category6.Visible = true;
                    lb_Item6.Visible = true;
                    cb_Item7.Visible = true;
                    cb_Category7.Visible = true;
                    lb_Item7.Visible = true;
                    cb_Item8.Visible = true;
                    cb_Category8.Visible = true;
                    lb_Item8.Visible = true;
                    cb_Item9.Visible = true;
                    cb_Category9.Visible = true;
                    lb_Item9.Visible = true;
                    cb_Item10.Visible = true;
                    cb_Category10.Visible = true;
                    lb_Item10.Visible = true;
                    cb_Item11.Visible = true;
                    cb_Category11.Visible = true;
                    lb_Item11.Visible = true;
                    cb_Item12.Visible = true;
                    cb_Category12.Visible = true;
                    lb_Item12.Visible = true;
                    cb_Item13.Visible = true;
                    cb_Category13.Visible = true;
                    lb_Item13.Visible = true;
                    cb_Item14.Visible = true;
                    cb_Category14.Visible = true;
                    lb_Item14.Visible = true;
                    cb_Item15.Visible = true;
                    cb_Category15.Visible = true;
                    lb_Item15.Visible = true;
                    cb_Item16.Visible = true;
                    cb_Category16.Visible = true;
                    lb_Item16.Visible = true;
                    cb_Item17.Visible = true;
                    cb_Category17.Visible = true;
                    lb_Item17.Visible = true;
                    cb_Item18.Visible = true;
                    cb_Category18.Visible = true;
                    lb_Item18.Visible = true;
                    cb_Item19.Visible = true;
                    cb_Category19.Visible = true;
                    lb_Item19.Visible = true;
                    cb_Item20.Visible = true;
                    cb_Category20.Visible = true;
                    lb_Item20.Visible = true;
                    cb_Item21.Visible = true;
                    cb_Category21.Visible = true;
                    lb_Item21.Visible = true;
                    cb_Item22.Visible = true;
                    cb_Category22.Visible = true;
                    lb_Item22.Visible = true;
                    cb_Item23.Visible = true;
                    cb_Category23.Visible = true;
                    lb_Item23.Visible = true;
                    cb_Item24.Visible = true;
                    cb_Category24.Visible = true;
                    lb_Item24.Visible = true;
                    cb_Item25.Visible = true;
                    cb_Category25.Visible = true;
                    lb_Item25.Visible = true;
                    cb_Item26.Visible = true;
                    cb_Category26.Visible = true;
                    lb_Item26.Visible = true;
                    cb_Item27.Visible = false;
                    cb_Category27.Visible = false;
                    lb_Item27.Visible = false;
                    cb_Item28.Visible = false;
                    cb_Category28.Visible = false;
                    lb_Item28.Visible = false;
                    cb_Item29.Visible = false;
                    cb_Category29.Visible = false;
                    lb_Item29.Visible = false;
                    cb_Item30.Visible = false;
                    cb_Category30.Visible = false;
                    lb_Item30.Visible = false;
                    cb_Item31.Visible = false;
                    cb_Category31.Visible = false;
                    lb_Item31.Visible = false;
                    cb_Item32.Visible = false;
                    cb_Category32.Visible = false;
                    lb_Item32.Visible = false;
                    btn_RemoveItem.Enabled = true;
                    btn_AddItem.Enabled = true;
                    break;
                case 27:
                    Height = 461;
                    Width = 594;
                    btn_AddItem.Location = new Point(499, 19);
                    btn_RemoveItem.Location = new Point(499, 44);
                    lb_Item.Visible = true;
                    lb_Category.Visible = true;
                    lb_ItemB.Visible = true;
                    lb_CategoryB.Visible = true;
                    cb_Item1.Visible = true;
                    cb_Category1.Visible = true;
                    lb_Item1.Visible = true;
                    cb_Item2.Visible = true;
                    cb_Category2.Visible = true;
                    lb_Item2.Visible = true;
                    cb_Item3.Visible = true;
                    cb_Category3.Visible = true;
                    lb_Item3.Visible = true;
                    cb_Item4.Visible = true;
                    cb_Category4.Visible = true;
                    lb_Item4.Visible = true;
                    cb_Item5.Visible = true;
                    cb_Category5.Visible = true;
                    lb_Item5.Visible = true;
                    cb_Item6.Visible = true;
                    cb_Category6.Visible = true;
                    lb_Item6.Visible = true;
                    cb_Item7.Visible = true;
                    cb_Category7.Visible = true;
                    lb_Item7.Visible = true;
                    cb_Item8.Visible = true;
                    cb_Category8.Visible = true;
                    lb_Item8.Visible = true;
                    cb_Item9.Visible = true;
                    cb_Category9.Visible = true;
                    lb_Item9.Visible = true;
                    cb_Item10.Visible = true;
                    cb_Category10.Visible = true;
                    lb_Item10.Visible = true;
                    cb_Item11.Visible = true;
                    cb_Category11.Visible = true;
                    lb_Item11.Visible = true;
                    cb_Item12.Visible = true;
                    cb_Category12.Visible = true;
                    lb_Item12.Visible = true;
                    cb_Item13.Visible = true;
                    cb_Category13.Visible = true;
                    lb_Item13.Visible = true;
                    cb_Item14.Visible = true;
                    cb_Category14.Visible = true;
                    lb_Item14.Visible = true;
                    cb_Item15.Visible = true;
                    cb_Category15.Visible = true;
                    lb_Item15.Visible = true;
                    cb_Item16.Visible = true;
                    cb_Category16.Visible = true;
                    lb_Item16.Visible = true;
                    cb_Item17.Visible = true;
                    cb_Category17.Visible = true;
                    lb_Item17.Visible = true;
                    cb_Item18.Visible = true;
                    cb_Category18.Visible = true;
                    lb_Item18.Visible = true;
                    cb_Item19.Visible = true;
                    cb_Category19.Visible = true;
                    lb_Item19.Visible = true;
                    cb_Item20.Visible = true;
                    cb_Category20.Visible = true;
                    lb_Item20.Visible = true;
                    cb_Item21.Visible = true;
                    cb_Category21.Visible = true;
                    lb_Item21.Visible = true;
                    cb_Item22.Visible = true;
                    cb_Category22.Visible = true;
                    lb_Item22.Visible = true;
                    cb_Item23.Visible = true;
                    cb_Category23.Visible = true;
                    lb_Item23.Visible = true;
                    cb_Item24.Visible = true;
                    cb_Category24.Visible = true;
                    lb_Item24.Visible = true;
                    cb_Item25.Visible = true;
                    cb_Category25.Visible = true;
                    lb_Item25.Visible = true;
                    cb_Item26.Visible = true;
                    cb_Category26.Visible = true;
                    lb_Item26.Visible = true;
                    cb_Item27.Visible = true;
                    cb_Category27.Visible = true;
                    lb_Item27.Visible = true;
                    cb_Item28.Visible = false;
                    cb_Category28.Visible = false;
                    lb_Item28.Visible = false;
                    cb_Item29.Visible = false;
                    cb_Category29.Visible = false;
                    lb_Item29.Visible = false;
                    cb_Item30.Visible = false;
                    cb_Category30.Visible = false;
                    lb_Item30.Visible = false;
                    cb_Item31.Visible = false;
                    cb_Category31.Visible = false;
                    lb_Item31.Visible = false;
                    cb_Item32.Visible = false;
                    cb_Category32.Visible = false;
                    lb_Item32.Visible = false;
                    btn_RemoveItem.Enabled = true;
                    btn_AddItem.Enabled = true;
                    break;
                case 28:
                    Height = 461;
                    Width = 594;
                    btn_AddItem.Location = new Point(499, 19);
                    btn_RemoveItem.Location = new Point(499, 44);
                    lb_Item.Visible = true;
                    lb_Category.Visible = true;
                    lb_ItemB.Visible = true;
                    lb_CategoryB.Visible = true;
                    cb_Item1.Visible = true;
                    cb_Category1.Visible = true;
                    lb_Item1.Visible = true;
                    cb_Item2.Visible = true;
                    cb_Category2.Visible = true;
                    lb_Item2.Visible = true;
                    cb_Item3.Visible = true;
                    cb_Category3.Visible = true;
                    lb_Item3.Visible = true;
                    cb_Item4.Visible = true;
                    cb_Category4.Visible = true;
                    lb_Item4.Visible = true;
                    cb_Item5.Visible = true;
                    cb_Category5.Visible = true;
                    lb_Item5.Visible = true;
                    cb_Item6.Visible = true;
                    cb_Category6.Visible = true;
                    lb_Item6.Visible = true;
                    cb_Item7.Visible = true;
                    cb_Category7.Visible = true;
                    lb_Item7.Visible = true;
                    cb_Item8.Visible = true;
                    cb_Category8.Visible = true;
                    lb_Item8.Visible = true;
                    cb_Item9.Visible = true;
                    cb_Category9.Visible = true;
                    lb_Item9.Visible = true;
                    cb_Item10.Visible = true;
                    cb_Category10.Visible = true;
                    lb_Item10.Visible = true;
                    cb_Item11.Visible = true;
                    cb_Category11.Visible = true;
                    lb_Item11.Visible = true;
                    cb_Item12.Visible = true;
                    cb_Category12.Visible = true;
                    lb_Item12.Visible = true;
                    cb_Item13.Visible = true;
                    cb_Category13.Visible = true;
                    lb_Item13.Visible = true;
                    cb_Item14.Visible = true;
                    cb_Category14.Visible = true;
                    lb_Item14.Visible = true;
                    cb_Item15.Visible = true;
                    cb_Category15.Visible = true;
                    lb_Item15.Visible = true;
                    cb_Item16.Visible = true;
                    cb_Category16.Visible = true;
                    lb_Item16.Visible = true;
                    cb_Item17.Visible = true;
                    cb_Category17.Visible = true;
                    lb_Item17.Visible = true;
                    cb_Item18.Visible = true;
                    cb_Category18.Visible = true;
                    lb_Item18.Visible = true;
                    cb_Item19.Visible = true;
                    cb_Category19.Visible = true;
                    lb_Item19.Visible = true;
                    cb_Item20.Visible = true;
                    cb_Category20.Visible = true;
                    lb_Item20.Visible = true;
                    cb_Item21.Visible = true;
                    cb_Category21.Visible = true;
                    lb_Item21.Visible = true;
                    cb_Item22.Visible = true;
                    cb_Category22.Visible = true;
                    lb_Item22.Visible = true;
                    cb_Item23.Visible = true;
                    cb_Category23.Visible = true;
                    lb_Item23.Visible = true;
                    cb_Item24.Visible = true;
                    cb_Category24.Visible = true;
                    lb_Item24.Visible = true;
                    cb_Item25.Visible = true;
                    cb_Category25.Visible = true;
                    lb_Item25.Visible = true;
                    cb_Item26.Visible = true;
                    cb_Category26.Visible = true;
                    lb_Item26.Visible = true;
                    cb_Item27.Visible = true;
                    cb_Category27.Visible = true;
                    lb_Item27.Visible = true;
                    cb_Item28.Visible = true;
                    cb_Category28.Visible = true;
                    lb_Item28.Visible = true;
                    cb_Item29.Visible = false;
                    cb_Category29.Visible = false;
                    lb_Item29.Visible = false;
                    cb_Item30.Visible = false;
                    cb_Category30.Visible = false;
                    lb_Item30.Visible = false;
                    cb_Item31.Visible = false;
                    cb_Category31.Visible = false;
                    lb_Item31.Visible = false;
                    cb_Item32.Visible = false;
                    cb_Category32.Visible = false;
                    lb_Item32.Visible = false;
                    btn_RemoveItem.Enabled = true;
                    btn_AddItem.Enabled = true;
                    break;
                case 29:
                    Height = 461;
                    Width = 594;
                    btn_AddItem.Location = new Point(499, 19);
                    btn_RemoveItem.Location = new Point(499, 44);
                    lb_Item.Visible = true;
                    lb_Category.Visible = true;
                    lb_ItemB.Visible = true;
                    lb_CategoryB.Visible = true;
                    cb_Item1.Visible = true;
                    cb_Category1.Visible = true;
                    lb_Item1.Visible = true;
                    cb_Item2.Visible = true;
                    cb_Category2.Visible = true;
                    lb_Item2.Visible = true;
                    cb_Item3.Visible = true;
                    cb_Category3.Visible = true;
                    lb_Item3.Visible = true;
                    cb_Item4.Visible = true;
                    cb_Category4.Visible = true;
                    lb_Item4.Visible = true;
                    cb_Item5.Visible = true;
                    cb_Category5.Visible = true;
                    lb_Item5.Visible = true;
                    cb_Item6.Visible = true;
                    cb_Category6.Visible = true;
                    lb_Item6.Visible = true;
                    cb_Item7.Visible = true;
                    cb_Category7.Visible = true;
                    lb_Item7.Visible = true;
                    cb_Item8.Visible = true;
                    cb_Category8.Visible = true;
                    lb_Item8.Visible = true;
                    cb_Item9.Visible = true;
                    cb_Category9.Visible = true;
                    lb_Item9.Visible = true;
                    cb_Item10.Visible = true;
                    cb_Category10.Visible = true;
                    lb_Item10.Visible = true;
                    cb_Item11.Visible = true;
                    cb_Category11.Visible = true;
                    lb_Item11.Visible = true;
                    cb_Item12.Visible = true;
                    cb_Category12.Visible = true;
                    lb_Item12.Visible = true;
                    cb_Item13.Visible = true;
                    cb_Category13.Visible = true;
                    lb_Item13.Visible = true;
                    cb_Item14.Visible = true;
                    cb_Category14.Visible = true;
                    lb_Item14.Visible = true;
                    cb_Item15.Visible = true;
                    cb_Category15.Visible = true;
                    lb_Item15.Visible = true;
                    cb_Item16.Visible = true;
                    cb_Category16.Visible = true;
                    lb_Item16.Visible = true;
                    cb_Item17.Visible = true;
                    cb_Category17.Visible = true;
                    lb_Item17.Visible = true;
                    cb_Item18.Visible = true;
                    cb_Category18.Visible = true;
                    lb_Item18.Visible = true;
                    cb_Item19.Visible = true;
                    cb_Category19.Visible = true;
                    lb_Item19.Visible = true;
                    cb_Item20.Visible = true;
                    cb_Category20.Visible = true;
                    lb_Item20.Visible = true;
                    cb_Item21.Visible = true;
                    cb_Category21.Visible = true;
                    lb_Item21.Visible = true;
                    cb_Item22.Visible = true;
                    cb_Category22.Visible = true;
                    lb_Item22.Visible = true;
                    cb_Item23.Visible = true;
                    cb_Category23.Visible = true;
                    lb_Item23.Visible = true;
                    cb_Item24.Visible = true;
                    cb_Category24.Visible = true;
                    lb_Item24.Visible = true;
                    cb_Item25.Visible = true;
                    cb_Category25.Visible = true;
                    lb_Item25.Visible = true;
                    cb_Item26.Visible = true;
                    cb_Category26.Visible = true;
                    lb_Item26.Visible = true;
                    cb_Item27.Visible = true;
                    cb_Category27.Visible = true;
                    lb_Item27.Visible = true;
                    cb_Item28.Visible = true;
                    cb_Category28.Visible = true;
                    lb_Item28.Visible = true;
                    cb_Item29.Visible = true;
                    cb_Category29.Visible = true;
                    lb_Item29.Visible = true;
                    cb_Item30.Visible = false;
                    cb_Category30.Visible = false;
                    lb_Item30.Visible = false;
                    cb_Item31.Visible = false;
                    cb_Category31.Visible = false;
                    lb_Item31.Visible = false;
                    cb_Item32.Visible = false;
                    cb_Category32.Visible = false;
                    lb_Item32.Visible = false;
                    btn_RemoveItem.Enabled = true;
                    btn_AddItem.Enabled = true;
                    break;
                case 30:
                    Height = 461;
                    Width = 594;
                    btn_AddItem.Location = new Point(499, 19);
                    btn_RemoveItem.Location = new Point(499, 44);
                    lb_Item.Visible = true;
                    lb_Category.Visible = true;
                    lb_ItemB.Visible = true;
                    lb_CategoryB.Visible = true;
                    cb_Item1.Visible = true;
                    cb_Category1.Visible = true;
                    lb_Item1.Visible = true;
                    cb_Item2.Visible = true;
                    cb_Category2.Visible = true;
                    lb_Item2.Visible = true;
                    cb_Item3.Visible = true;
                    cb_Category3.Visible = true;
                    lb_Item3.Visible = true;
                    cb_Item4.Visible = true;
                    cb_Category4.Visible = true;
                    lb_Item4.Visible = true;
                    cb_Item5.Visible = true;
                    cb_Category5.Visible = true;
                    lb_Item5.Visible = true;
                    cb_Item6.Visible = true;
                    cb_Category6.Visible = true;
                    lb_Item6.Visible = true;
                    cb_Item7.Visible = true;
                    cb_Category7.Visible = true;
                    lb_Item7.Visible = true;
                    cb_Item8.Visible = true;
                    cb_Category8.Visible = true;
                    lb_Item8.Visible = true;
                    cb_Item9.Visible = true;
                    cb_Category9.Visible = true;
                    lb_Item9.Visible = true;
                    cb_Item10.Visible = true;
                    cb_Category10.Visible = true;
                    lb_Item10.Visible = true;
                    cb_Item11.Visible = true;
                    cb_Category11.Visible = true;
                    lb_Item11.Visible = true;
                    cb_Item12.Visible = true;
                    cb_Category12.Visible = true;
                    lb_Item12.Visible = true;
                    cb_Item13.Visible = true;
                    cb_Category13.Visible = true;
                    lb_Item13.Visible = true;
                    cb_Item14.Visible = true;
                    cb_Category14.Visible = true;
                    lb_Item14.Visible = true;
                    cb_Item15.Visible = true;
                    cb_Category15.Visible = true;
                    lb_Item15.Visible = true;
                    cb_Item16.Visible = true;
                    cb_Category16.Visible = true;
                    lb_Item16.Visible = true;
                    cb_Item17.Visible = true;
                    cb_Category17.Visible = true;
                    lb_Item17.Visible = true;
                    cb_Item18.Visible = true;
                    cb_Category18.Visible = true;
                    lb_Item18.Visible = true;
                    cb_Item19.Visible = true;
                    cb_Category19.Visible = true;
                    lb_Item19.Visible = true;
                    cb_Item20.Visible = true;
                    cb_Category20.Visible = true;
                    lb_Item20.Visible = true;
                    cb_Item21.Visible = true;
                    cb_Category21.Visible = true;
                    lb_Item21.Visible = true;
                    cb_Item22.Visible = true;
                    cb_Category22.Visible = true;
                    lb_Item22.Visible = true;
                    cb_Item23.Visible = true;
                    cb_Category23.Visible = true;
                    lb_Item23.Visible = true;
                    cb_Item24.Visible = true;
                    cb_Category24.Visible = true;
                    lb_Item24.Visible = true;
                    cb_Item25.Visible = true;
                    cb_Category25.Visible = true;
                    lb_Item25.Visible = true;
                    cb_Item26.Visible = true;
                    cb_Category26.Visible = true;
                    lb_Item26.Visible = true;
                    cb_Item27.Visible = true;
                    cb_Category27.Visible = true;
                    lb_Item27.Visible = true;
                    cb_Item28.Visible = true;
                    cb_Category28.Visible = true;
                    lb_Item28.Visible = true;
                    cb_Item29.Visible = true;
                    cb_Category29.Visible = true;
                    lb_Item29.Visible = true;
                    cb_Item30.Visible = true;
                    cb_Category30.Visible = true;
                    lb_Item30.Visible = true;
                    cb_Item31.Visible = false;
                    cb_Category31.Visible = false;
                    lb_Item31.Visible = false;
                    cb_Item32.Visible = false;
                    cb_Category32.Visible = false;
                    lb_Item32.Visible = false;
                    btn_RemoveItem.Enabled = true;
                    btn_AddItem.Enabled = true;
                    break;
                case 31:
                    Height = 461;
                    Width = 594;
                    btn_AddItem.Location = new Point(499, 19);
                    btn_RemoveItem.Location = new Point(499, 44);
                    lb_Item.Visible = true;
                    lb_Category.Visible = true;
                    lb_ItemB.Visible = true;
                    lb_CategoryB.Visible = true;
                    cb_Item1.Visible = true;
                    cb_Category1.Visible = true;
                    lb_Item1.Visible = true;
                    cb_Item2.Visible = true;
                    cb_Category2.Visible = true;
                    lb_Item2.Visible = true;
                    cb_Item3.Visible = true;
                    cb_Category3.Visible = true;
                    lb_Item3.Visible = true;
                    cb_Item4.Visible = true;
                    cb_Category4.Visible = true;
                    lb_Item4.Visible = true;
                    cb_Item5.Visible = true;
                    cb_Category5.Visible = true;
                    lb_Item5.Visible = true;
                    cb_Item6.Visible = true;
                    cb_Category6.Visible = true;
                    lb_Item6.Visible = true;
                    cb_Item7.Visible = true;
                    cb_Category7.Visible = true;
                    lb_Item7.Visible = true;
                    cb_Item8.Visible = true;
                    cb_Category8.Visible = true;
                    lb_Item8.Visible = true;
                    cb_Item9.Visible = true;
                    cb_Category9.Visible = true;
                    lb_Item9.Visible = true;
                    cb_Item10.Visible = true;
                    cb_Category10.Visible = true;
                    lb_Item10.Visible = true;
                    cb_Item11.Visible = true;
                    cb_Category11.Visible = true;
                    lb_Item11.Visible = true;
                    cb_Item12.Visible = true;
                    cb_Category12.Visible = true;
                    lb_Item12.Visible = true;
                    cb_Item13.Visible = true;
                    cb_Category13.Visible = true;
                    lb_Item13.Visible = true;
                    cb_Item14.Visible = true;
                    cb_Category14.Visible = true;
                    lb_Item14.Visible = true;
                    cb_Item15.Visible = true;
                    cb_Category15.Visible = true;
                    lb_Item15.Visible = true;
                    cb_Item16.Visible = true;
                    cb_Category16.Visible = true;
                    lb_Item16.Visible = true;
                    cb_Item17.Visible = true;
                    cb_Category17.Visible = true;
                    lb_Item17.Visible = true;
                    cb_Item18.Visible = true;
                    cb_Category18.Visible = true;
                    lb_Item18.Visible = true;
                    cb_Item19.Visible = true;
                    cb_Category19.Visible = true;
                    lb_Item19.Visible = true;
                    cb_Item20.Visible = true;
                    cb_Category20.Visible = true;
                    lb_Item20.Visible = true;
                    cb_Item21.Visible = true;
                    cb_Category21.Visible = true;
                    lb_Item21.Visible = true;
                    cb_Item22.Visible = true;
                    cb_Category22.Visible = true;
                    lb_Item22.Visible = true;
                    cb_Item23.Visible = true;
                    cb_Category23.Visible = true;
                    lb_Item23.Visible = true;
                    cb_Item24.Visible = true;
                    cb_Category24.Visible = true;
                    lb_Item24.Visible = true;
                    cb_Item25.Visible = true;
                    cb_Category25.Visible = true;
                    lb_Item25.Visible = true;
                    cb_Item26.Visible = true;
                    cb_Category26.Visible = true;
                    lb_Item26.Visible = true;
                    cb_Item27.Visible = true;
                    cb_Category27.Visible = true;
                    lb_Item27.Visible = true;
                    cb_Item28.Visible = true;
                    cb_Category28.Visible = true;
                    lb_Item28.Visible = true;
                    cb_Item29.Visible = true;
                    cb_Category29.Visible = true;
                    lb_Item29.Visible = true;
                    cb_Item30.Visible = true;
                    cb_Category30.Visible = true;
                    lb_Item30.Visible = true;
                    cb_Item31.Visible = true;
                    cb_Category31.Visible = true;
                    lb_Item31.Visible = true;
                    cb_Item32.Visible = false;
                    cb_Category32.Visible = false;
                    lb_Item32.Visible = false;
                    btn_RemoveItem.Enabled = true;
                    btn_AddItem.Enabled = true;
                    break;
                case 32:
                    Height = 461;
                    Width = 594;
                    btn_AddItem.Location = new Point(499, 19);
                    btn_RemoveItem.Location = new Point(499, 44);
                    lb_Item.Visible = true;
                    lb_Category.Visible = true;
                    lb_ItemB.Visible = true;
                    lb_CategoryB.Visible = true;
                    cb_Item1.Visible = true;
                    cb_Category1.Visible = true;
                    lb_Item1.Visible = true;
                    cb_Item2.Visible = true;
                    cb_Category2.Visible = true;
                    lb_Item2.Visible = true;
                    cb_Item3.Visible = true;
                    cb_Category3.Visible = true;
                    lb_Item3.Visible = true;
                    cb_Item4.Visible = true;
                    cb_Category4.Visible = true;
                    lb_Item4.Visible = true;
                    cb_Item5.Visible = true;
                    cb_Category5.Visible = true;
                    lb_Item5.Visible = true;
                    cb_Item6.Visible = true;
                    cb_Category6.Visible = true;
                    lb_Item6.Visible = true;
                    cb_Item7.Visible = true;
                    cb_Category7.Visible = true;
                    lb_Item7.Visible = true;
                    cb_Item8.Visible = true;
                    cb_Category8.Visible = true;
                    lb_Item8.Visible = true;
                    cb_Item9.Visible = true;
                    cb_Category9.Visible = true;
                    lb_Item9.Visible = true;
                    cb_Item10.Visible = true;
                    cb_Category10.Visible = true;
                    lb_Item10.Visible = true;
                    cb_Item11.Visible = true;
                    cb_Category11.Visible = true;
                    lb_Item11.Visible = true;
                    cb_Item12.Visible = true;
                    cb_Category12.Visible = true;
                    lb_Item12.Visible = true;
                    cb_Item13.Visible = true;
                    cb_Category13.Visible = true;
                    lb_Item13.Visible = true;
                    cb_Item14.Visible = true;
                    cb_Category14.Visible = true;
                    lb_Item14.Visible = true;
                    cb_Item15.Visible = true;
                    cb_Category15.Visible = true;
                    lb_Item15.Visible = true;
                    cb_Item16.Visible = true;
                    cb_Category16.Visible = true;
                    lb_Item16.Visible = true;
                    cb_Item17.Visible = true;
                    cb_Category17.Visible = true;
                    lb_Item17.Visible = true;
                    cb_Item18.Visible = true;
                    cb_Category18.Visible = true;
                    lb_Item18.Visible = true;
                    cb_Item19.Visible = true;
                    cb_Category19.Visible = true;
                    lb_Item19.Visible = true;
                    cb_Item20.Visible = true;
                    cb_Category20.Visible = true;
                    lb_Item20.Visible = true;
                    cb_Item21.Visible = true;
                    cb_Category21.Visible = true;
                    lb_Item21.Visible = true;
                    cb_Item22.Visible = true;
                    cb_Category22.Visible = true;
                    lb_Item22.Visible = true;
                    cb_Item23.Visible = true;
                    cb_Category23.Visible = true;
                    lb_Item23.Visible = true;
                    cb_Item24.Visible = true;
                    cb_Category24.Visible = true;
                    lb_Item24.Visible = true;
                    cb_Item25.Visible = true;
                    cb_Category25.Visible = true;
                    lb_Item25.Visible = true;
                    cb_Item26.Visible = true;
                    cb_Category26.Visible = true;
                    lb_Item26.Visible = true;
                    cb_Item27.Visible = true;
                    cb_Category27.Visible = true;
                    lb_Item27.Visible = true;
                    cb_Item28.Visible = true;
                    cb_Category28.Visible = true;
                    lb_Item28.Visible = true;
                    cb_Item29.Visible = true;
                    cb_Category29.Visible = true;
                    lb_Item29.Visible = true;
                    cb_Item30.Visible = true;
                    cb_Category30.Visible = true;
                    lb_Item30.Visible = true;
                    cb_Item31.Visible = true;
                    cb_Category31.Visible = true;
                    lb_Item31.Visible = true;
                    cb_Item32.Visible = true;
                    cb_Category32.Visible = true;
                    lb_Item32.Visible = true;
                    btn_RemoveItem.Enabled = true;
                    btn_AddItem.Enabled = false;
                    break;
            }
        }

        private void Btn_AddItem_Click(object sender, EventArgs e)
        {
            if (itemCount < 32) { itemCount++; }
            if (itemCount == 32) { btn_AddItem.Enabled = false; }
            if (itemCount > 0) { btn_RemoveItem.Enabled = true; }
            SetSize();
            if (Main.saveIsPC) { Main.loadedSave[offsets.chaoSave.MarketCount] = (byte)itemCount; }
            else { Main.loadedSave[offsets.chaoSave.MarketCount + 3] = (byte)itemCount; }
        }

        private void Btn_RemoveItem_Click(object sender, EventArgs e)
        {
            if (itemCount > 0) { itemCount--; }
            if (itemCount == 0) { btn_RemoveItem.Enabled = false; }
            if (itemCount < 32) { btn_AddItem.Enabled = true; }
            SetSize();
            if (Main.saveIsPC) { Main.loadedSave[offsets.chaoSave.MarketCount] = (byte)itemCount; }
            else { Main.loadedSave[offsets.chaoSave.MarketCount + 3] = (byte)itemCount; }
        }

        private void Cb_Category1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cb_Item1.Items.Clear();
            switch (cb_Category1.SelectedIndex)
            {
                case 0:
                    cb_Item1.Items.AddRange(Eggs.ToArray());
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart] = 1;
                    break;
                case 1:
                    cb_Item1.Items.AddRange(Fruit.Keys.ToArray());
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart] = 3;
                    break;
                case 2:
                    cb_Item1.Items.AddRange(Seed.ToArray());
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart] = 7;
                    break;
                case 3:
                    cb_Item1.Items.AddRange(Hat.ToArray());
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart] = 9;
                    break;
                case 4:
                    cb_Item1.Items.AddRange(Themes.ToArray());
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart] = 16;
                    break;
            }
            if (loaded) { Main.loadedSave[offsets.chaoSave.MarketItemsStart + 1] = 0; }
            if (cb_Category1.SelectedIndex == 1) { cb_Item1.SelectedIndex = Fruit.Where(x => x.Value == Main.loadedSave[offsets.chaoSave.MarketItemsStart + 1]).First().Value; }
            if (cb_Category1.SelectedIndex == 3)
            {
                cb_Item1.SelectedIndex = (Main.loadedSave[offsets.chaoSave.MarketItemsStart + 1] - 1);
                if (cb_Item1.SelectedItem == null) { cb_Item1.SelectedIndex = 0; }
            }
            if (cb_Category1.SelectedIndex != 1 && cb_Category1.SelectedIndex != 3) { cb_Item1.SelectedIndex = Main.loadedSave[offsets.chaoSave.MarketItemsStart + 1]; }
        }

        private void Cb_Category2_SelectedIndexChanged(object sender, EventArgs e)
        {
            cb_Item2.Items.Clear();
            switch (cb_Category2.SelectedIndex)
            {
                case 0:
                    cb_Item2.Items.AddRange(Eggs.ToArray());
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 2] = 1;
                    break;
                case 1:
                    cb_Item2.Items.AddRange(Fruit.Keys.ToArray());
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 2] = 3;
                    break;
                case 2:
                    cb_Item2.Items.AddRange(Seed.ToArray());
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 2] = 7;
                    break;
                case 3:
                    cb_Item2.Items.AddRange(Hat.ToArray());
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 2] = 9;
                    break;
                case 4:
                    cb_Item2.Items.AddRange(Themes.ToArray());
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 2] = 16;
                    break;
            }
            if (loaded) { Main.loadedSave[offsets.chaoSave.MarketItemsStart + 3] = 0; }
            if (cb_Category2.SelectedIndex == 1) { cb_Item2.SelectedIndex = Fruit.Where(x => x.Value == Main.loadedSave[offsets.chaoSave.MarketItemsStart + 3]).First().Value; }
            if (cb_Category2.SelectedIndex == 3)
            {
                cb_Item2.SelectedIndex = (Main.loadedSave[offsets.chaoSave.MarketItemsStart + 3] - 1);
                if (cb_Item2.SelectedItem == null) { cb_Item2.SelectedIndex = 0; }
            }
            if (cb_Category2.SelectedIndex != 1 && cb_Category2.SelectedIndex != 3) { cb_Item2.SelectedIndex = Main.loadedSave[offsets.chaoSave.MarketItemsStart + 3]; }
        }

        private void Cb_Category3_SelectedIndexChanged(object sender, EventArgs e)
        {
            cb_Item3.Items.Clear();
            switch (cb_Category3.SelectedIndex)
            {
                case 0:
                    cb_Item3.Items.AddRange(Eggs.ToArray());
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 4] = 1;
                    break;
                case 1:
                    cb_Item3.Items.AddRange(Fruit.Keys.ToArray());
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 4] = 3;
                    break;
                case 2:
                    cb_Item3.Items.AddRange(Seed.ToArray());
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 4] = 7;
                    break;
                case 3:
                    cb_Item3.Items.AddRange(Hat.ToArray());
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 4] = 9;
                    break;
                case 4:
                    cb_Item3.Items.AddRange(Themes.ToArray());
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 4] = 16;
                    break;
            }
            if (loaded) { Main.loadedSave[offsets.chaoSave.MarketItemsStart + 5] = 0; }
            if (cb_Category3.SelectedIndex == 1) { cb_Item3.SelectedIndex = Fruit.Where(x => x.Value == Main.loadedSave[offsets.chaoSave.MarketItemsStart + 5]).First().Value; }
            if (cb_Category3.SelectedIndex == 3)
            {
                cb_Item3.SelectedIndex = (Main.loadedSave[offsets.chaoSave.MarketItemsStart + 5] - 1);
                if (cb_Item3.SelectedItem == null) { cb_Item3.SelectedIndex = 0; }
            }
            if (cb_Category3.SelectedIndex != 1 && cb_Category3.SelectedIndex != 3) { cb_Item3.SelectedIndex = Main.loadedSave[offsets.chaoSave.MarketItemsStart + 5]; }
        }

        private void Cb_Category4_SelectedIndexChanged(object sender, EventArgs e)
        {
            cb_Item4.Items.Clear();
            switch (cb_Category4.SelectedIndex)
            {
                case 0:
                    cb_Item4.Items.AddRange(Eggs.ToArray());
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 6] = 1;
                    break;
                case 1:
                    cb_Item4.Items.AddRange(Fruit.Keys.ToArray());
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 6] = 3;
                    break;
                case 2:
                    cb_Item4.Items.AddRange(Seed.ToArray());
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 6] = 7;
                    break;
                case 3:
                    cb_Item4.Items.AddRange(Hat.ToArray());
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 6] = 9;
                    break;
                case 4:
                    cb_Item4.Items.AddRange(Themes.ToArray());
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 6] = 16;
                    break;
            }
            if (loaded) { Main.loadedSave[offsets.chaoSave.MarketItemsStart + 7] = 0; }
            if (cb_Category4.SelectedIndex == 1) { cb_Item4.SelectedIndex = Fruit.Where(x => x.Value == Main.loadedSave[offsets.chaoSave.MarketItemsStart + 7]).First().Value; }
            if (cb_Category4.SelectedIndex == 3)
            {
                cb_Item4.SelectedIndex = (Main.loadedSave[offsets.chaoSave.MarketItemsStart + 7] - 1);
                if (cb_Item4.SelectedItem == null) { cb_Item4.SelectedIndex = 0; }
            }
            if (cb_Category4.SelectedIndex != 1 && cb_Category4.SelectedIndex != 3) { cb_Item4.SelectedIndex = Main.loadedSave[offsets.chaoSave.MarketItemsStart + 7]; }
        }

        private void Cb_Category5_SelectedIndexChanged(object sender, EventArgs e)
        {
            cb_Item5.Items.Clear();
            switch (cb_Category5.SelectedIndex)
            {

                case 0:
                    cb_Item5.Items.AddRange(Eggs.ToArray());
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 8] = 1;
                    break;
                case 1:
                    cb_Item5.Items.AddRange(Fruit.Keys.ToArray());
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 8] = 3;
                    break;
                case 2:
                    cb_Item5.Items.AddRange(Seed.ToArray());
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 8] = 7;
                    break;
                case 3:
                    cb_Item5.Items.AddRange(Hat.ToArray());
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 8] = 9;
                    break;
                case 4:
                    cb_Item5.Items.AddRange(Themes.ToArray());
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 8] = 16;
                    break;
            }
            if (loaded) { Main.loadedSave[offsets.chaoSave.MarketItemsStart + 9] = 0; }
            if (cb_Category5.SelectedIndex == 1) { cb_Item5.SelectedIndex = Fruit.Where(x => x.Value == Main.loadedSave[offsets.chaoSave.MarketItemsStart + 9]).First().Value; }
            if (cb_Category5.SelectedIndex == 3)
            {
                cb_Item5.SelectedIndex = (Main.loadedSave[offsets.chaoSave.MarketItemsStart + 9] - 1);
                if (cb_Item5.SelectedItem == null) { cb_Item5.SelectedIndex = 0; }
            }
            if (cb_Category5.SelectedIndex != 1 && cb_Category5.SelectedIndex != 3) { cb_Item5.SelectedIndex = Main.loadedSave[offsets.chaoSave.MarketItemsStart + 9]; }
        }

        private void Cb_Category6_SelectedIndexChanged(object sender, EventArgs e)
        {
            cb_Item6.Items.Clear();
            switch (cb_Category6.SelectedIndex)
            {
                case 0:
                    cb_Item6.Items.AddRange(Eggs.ToArray());
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 10] = 1;
                    break;
                case 1:
                    cb_Item6.Items.AddRange(Fruit.Keys.ToArray());
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 10] = 3;
                    break;
                case 2:
                    cb_Item6.Items.AddRange(Seed.ToArray());
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 10] = 7;
                    break;
                case 3:
                    cb_Item6.Items.AddRange(Hat.ToArray());
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 10] = 9;
                    break;
                case 4:
                    cb_Item6.Items.AddRange(Themes.ToArray());
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 10] = 16;
                    break;
            }
            if (loaded) { Main.loadedSave[offsets.chaoSave.MarketItemsStart + 11] = 0; }
            if (cb_Category6.SelectedIndex == 1) { cb_Item6.SelectedIndex = Fruit.Where(x => x.Value == Main.loadedSave[offsets.chaoSave.MarketItemsStart + 11]).First().Value; }
            if (cb_Category6.SelectedIndex == 3)
            {
                cb_Item6.SelectedIndex = (Main.loadedSave[offsets.chaoSave.MarketItemsStart + 11] - 1);
                if (cb_Item6.SelectedItem == null) { cb_Item6.SelectedIndex = 0; }
            }
            if (cb_Category6.SelectedIndex != 1 && cb_Category6.SelectedIndex != 3) { cb_Item6.SelectedIndex = Main.loadedSave[offsets.chaoSave.MarketItemsStart + 11]; }
        }

        private void Cb_Category7_SelectedIndexChanged(object sender, EventArgs e)
        {
            cb_Item7.Items.Clear();
            switch (cb_Category7.SelectedIndex)
            {
                case 0:
                    cb_Item7.Items.AddRange(Eggs.ToArray());
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 12] = 1;
                    break;
                case 1:
                    cb_Item7.Items.AddRange(Fruit.Keys.ToArray());
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 12] = 3;
                    break;
                case 2:
                    cb_Item7.Items.AddRange(Seed.ToArray());
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 12] = 7;
                    break;
                case 3:
                    cb_Item7.Items.AddRange(Hat.ToArray());
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 12] = 9;
                    break;
                case 4:
                    cb_Item7.Items.AddRange(Themes.ToArray());
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 12] = 16;
                    break;
            }
            if (loaded) { Main.loadedSave[offsets.chaoSave.MarketItemsStart + 13] = 0; }
            if (cb_Category7.SelectedIndex == 1) { cb_Item7.SelectedIndex = Fruit.Where(x => x.Value == Main.loadedSave[offsets.chaoSave.MarketItemsStart + 13]).First().Value; }
            if (cb_Category7.SelectedIndex == 3)
            {
                cb_Item7.SelectedIndex = (Main.loadedSave[offsets.chaoSave.MarketItemsStart + 13] - 1);
                if (cb_Item7.SelectedItem == null) { cb_Item7.SelectedIndex = 0; }
            }
            if (cb_Category7.SelectedIndex != 1 && cb_Category7.SelectedIndex != 3) { cb_Item7.SelectedIndex = Main.loadedSave[offsets.chaoSave.MarketItemsStart + 13]; }
        }

        private void Cb_Category8_SelectedIndexChanged(object sender, EventArgs e)
        {
            cb_Item8.Items.Clear();
            switch (cb_Category8.SelectedIndex)
            {
                case 0:
                    cb_Item8.Items.AddRange(Eggs.ToArray());
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 14] = 1;
                    break;
                case 1:
                    cb_Item8.Items.AddRange(Fruit.Keys.ToArray());
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 14] = 3;
                    break;
                case 2:
                    cb_Item8.Items.AddRange(Seed.ToArray());
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 14] = 7;
                    break;
                case 3:
                    cb_Item8.Items.AddRange(Hat.ToArray());
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 14] = 9;
                    break;
                case 4:
                    cb_Item8.Items.AddRange(Themes.ToArray());
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 14] = 16;
                    break;
            }
            if (loaded) { Main.loadedSave[offsets.chaoSave.MarketItemsStart + 15] = 0; }
            if (cb_Category8.SelectedIndex == 1) { cb_Item8.SelectedIndex = Fruit.Where(x => x.Value == Main.loadedSave[offsets.chaoSave.MarketItemsStart + 15]).First().Value; }
            if (cb_Category8.SelectedIndex == 3)
            {
                cb_Item8.SelectedIndex = (Main.loadedSave[offsets.chaoSave.MarketItemsStart + 15] - 1);
                if (cb_Item8.SelectedItem == null) { cb_Item8.SelectedIndex = 0; }
            }
            if (cb_Category8.SelectedIndex != 1 && cb_Category8.SelectedIndex != 3) { cb_Item8.SelectedIndex = Main.loadedSave[offsets.chaoSave.MarketItemsStart + 15]; }
        }

        private void Cb_Category9_SelectedIndexChanged(object sender, EventArgs e)
        {
            cb_Item9.Items.Clear();
            switch (cb_Category9.SelectedIndex)
            {
                case 0:
                    cb_Item9.Items.AddRange(Eggs.ToArray());
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 16] = 1;
                    break;
                case 1:
                    cb_Item9.Items.AddRange(Fruit.Keys.ToArray());
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 16] = 3;
                    break;
                case 2:
                    cb_Item9.Items.AddRange(Seed.ToArray());
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 16] = 7;
                    break;
                case 3:
                    cb_Item9.Items.AddRange(Hat.ToArray());
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 16] = 9;
                    break;
                case 4:
                    cb_Item9.Items.AddRange(Themes.ToArray());
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 16] = 16;
                    break;
            }
            if (loaded) { Main.loadedSave[offsets.chaoSave.MarketItemsStart + 17] = 0; }
            if (cb_Category9.SelectedIndex == 1) { cb_Item9.SelectedIndex = Fruit.Where(x => x.Value == Main.loadedSave[offsets.chaoSave.MarketItemsStart + 17]).First().Value; }
            if (cb_Category9.SelectedIndex == 3)
            {
                cb_Item9.SelectedIndex = (Main.loadedSave[offsets.chaoSave.MarketItemsStart + 17] - 1);
                if (cb_Item9.SelectedItem == null) { cb_Item9.SelectedIndex = 0; }
            }
            if (cb_Category9.SelectedIndex != 1 && cb_Category9.SelectedIndex != 3) { cb_Item9.SelectedIndex = Main.loadedSave[offsets.chaoSave.MarketItemsStart + 17]; }
        }

        private void Cb_Category10_SelectedIndexChanged(object sender, EventArgs e)
        {
            cb_Item10.Items.Clear();
            switch (cb_Category10.SelectedIndex)
            {
                case 0:
                    cb_Item10.Items.AddRange(Eggs.ToArray());
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 18] = 1;
                    break;
                case 1:
                    cb_Item10.Items.AddRange(Fruit.Keys.ToArray());
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 18] = 3;
                    break;
                case 2:
                    cb_Item10.Items.AddRange(Seed.ToArray());
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 18] = 7;
                    break;
                case 3:
                    cb_Item10.Items.AddRange(Hat.ToArray());
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 18] = 9;
                    break;
                case 4:
                    cb_Item10.Items.AddRange(Themes.ToArray());
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 18] = 16;
                    break;
            }
            if (loaded) { Main.loadedSave[offsets.chaoSave.MarketItemsStart + 19] = 0; }
            if (cb_Category10.SelectedIndex == 1) { cb_Item10.SelectedIndex = Fruit.Where(x => x.Value == Main.loadedSave[offsets.chaoSave.MarketItemsStart + 19]).First().Value; }
            if (cb_Category10.SelectedIndex == 3)
            {
                cb_Item10.SelectedIndex = (Main.loadedSave[offsets.chaoSave.MarketItemsStart + 19] - 1);
                if (cb_Item10.SelectedItem == null) { cb_Item10.SelectedIndex = 0; }
            }
            if (cb_Category10.SelectedIndex != 1 && cb_Category10.SelectedIndex != 3) { cb_Item10.SelectedIndex = Main.loadedSave[offsets.chaoSave.MarketItemsStart + 19]; }
        }

        private void Cb_Category11_SelectedIndexChanged(object sender, EventArgs e)
        {
            cb_Item11.Items.Clear();
            switch (cb_Category11.SelectedIndex)
            {
                case 0:
                    cb_Item11.Items.AddRange(Eggs.ToArray());
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 20] = 1;
                    break;
                case 1:
                    cb_Item11.Items.AddRange(Fruit.Keys.ToArray());
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 20] = 3;
                    break;
                case 2:
                    cb_Item11.Items.AddRange(Seed.ToArray());
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 20] = 7;
                    break;
                case 3:
                    cb_Item11.Items.AddRange(Hat.ToArray());
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 20] = 9;
                    break;
                case 4:
                    cb_Item11.Items.AddRange(Themes.ToArray());
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 20] = 16;
                    break;
            }
            if (loaded) { Main.loadedSave[offsets.chaoSave.MarketItemsStart + 21] = 0; }
            if (cb_Category11.SelectedIndex == 1) { cb_Item11.SelectedIndex = Fruit.Where(x => x.Value == Main.loadedSave[offsets.chaoSave.MarketItemsStart + 21]).First().Value; }
            if (cb_Category11.SelectedIndex == 3)
            {
                cb_Item11.SelectedIndex = (Main.loadedSave[offsets.chaoSave.MarketItemsStart + 21] - 1);
                if (cb_Item11.SelectedItem == null) { cb_Item11.SelectedIndex = 0; }
            }
            if (cb_Category11.SelectedIndex != 1 && cb_Category11.SelectedIndex != 3) { cb_Item11.SelectedIndex = Main.loadedSave[offsets.chaoSave.MarketItemsStart + 21]; }
        }

        private void Cb_Category12_SelectedIndexChanged(object sender, EventArgs e)
        {
            cb_Item12.Items.Clear();
            switch (cb_Category12.SelectedIndex)
            {
                case 0:
                    cb_Item12.Items.AddRange(Eggs.ToArray());
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 22] = 1;
                    break;
                case 1:
                    cb_Item12.Items.AddRange(Fruit.Keys.ToArray());
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 22] = 3;
                    break;
                case 2:
                    cb_Item12.Items.AddRange(Seed.ToArray());
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 22] = 7;
                    break;
                case 3:
                    cb_Item12.Items.AddRange(Hat.ToArray());
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 22] = 9;
                    break;
                case 4:
                    cb_Item12.Items.AddRange(Themes.ToArray());
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 22] = 16;
                    break;
            }
            if (loaded) { Main.loadedSave[offsets.chaoSave.MarketItemsStart + 23] = 0; }
            if (cb_Category12.SelectedIndex == 1) { cb_Item12.SelectedIndex = Fruit.Where(x => x.Value == Main.loadedSave[offsets.chaoSave.MarketItemsStart + 23]).First().Value; }
            if (cb_Category12.SelectedIndex == 3)
            {
                cb_Item12.SelectedIndex = (Main.loadedSave[offsets.chaoSave.MarketItemsStart + 23] - 1);
                if (cb_Item12.SelectedItem == null) { cb_Item12.SelectedIndex = 0; }
            }
            if (cb_Category12.SelectedIndex != 1 && cb_Category12.SelectedIndex != 3) { cb_Item12.SelectedIndex = Main.loadedSave[offsets.chaoSave.MarketItemsStart + 23]; }
        }

        private void Cb_Category13_SelectedIndexChanged(object sender, EventArgs e)
        {
            cb_Item13.Items.Clear();
            switch (cb_Category13.SelectedIndex)
            {
                case 0:
                    cb_Item13.Items.AddRange(Eggs.ToArray());
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 24] = 1;
                    break;
                case 1:
                    cb_Item13.Items.AddRange(Fruit.Keys.ToArray());
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 24] = 3;
                    break;
                case 2:
                    cb_Item13.Items.AddRange(Seed.ToArray());
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 24] = 7;
                    break;
                case 3:
                    cb_Item13.Items.AddRange(Hat.ToArray());
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 24] = 9;
                    break;
                case 4:
                    cb_Item13.Items.AddRange(Themes.ToArray());
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 24] = 16;
                    break;
            }
            if (loaded) { Main.loadedSave[offsets.chaoSave.MarketItemsStart + 25] = 0; }
            if (cb_Category13.SelectedIndex == 1) { cb_Item13.SelectedIndex = Fruit.Where(x => x.Value == Main.loadedSave[offsets.chaoSave.MarketItemsStart + 25]).First().Value; }
            if (cb_Category13.SelectedIndex == 3)
            {
                cb_Item13.SelectedIndex = (Main.loadedSave[offsets.chaoSave.MarketItemsStart + 25] - 1);
                if (cb_Item13.SelectedItem == null) { cb_Item13.SelectedIndex = 0; }
            }
            if (cb_Category13.SelectedIndex != 1 && cb_Category13.SelectedIndex != 3) { cb_Item13.SelectedIndex = Main.loadedSave[offsets.chaoSave.MarketItemsStart + 25]; }
        }

        private void Cb_Category14_SelectedIndexChanged(object sender, EventArgs e)
        {
            cb_Item14.Items.Clear();
            switch (cb_Category14.SelectedIndex)
            {
                case 0:
                    cb_Item14.Items.AddRange(Eggs.ToArray());
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 26] = 1;
                    break;
                case 1:
                    cb_Item14.Items.AddRange(Fruit.Keys.ToArray());
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 26] = 3;
                    break;
                case 2:
                    cb_Item14.Items.AddRange(Seed.ToArray());
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 26] = 7;
                    break;
                case 3:
                    cb_Item14.Items.AddRange(Hat.ToArray());
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 26] = 9;
                    break;
                case 4:
                    cb_Item14.Items.AddRange(Themes.ToArray());
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 26] = 16;
                    break;
            }
            if (loaded) { Main.loadedSave[offsets.chaoSave.MarketItemsStart + 27] = 0; }
            if (cb_Category14.SelectedIndex == 1) { cb_Item14.SelectedIndex = Fruit.Where(x => x.Value == Main.loadedSave[offsets.chaoSave.MarketItemsStart + 27]).First().Value; }
            if (cb_Category14.SelectedIndex == 3)
            {
                cb_Item14.SelectedIndex = (Main.loadedSave[offsets.chaoSave.MarketItemsStart + 27] - 1);
                if (cb_Item14.SelectedItem == null) { cb_Item14.SelectedIndex = 0; }
            }
            if (cb_Category14.SelectedIndex != 1 && cb_Category14.SelectedIndex != 3) { cb_Item14.SelectedIndex = Main.loadedSave[offsets.chaoSave.MarketItemsStart + 27]; }
        }

        private void Cb_Category15_SelectedIndexChanged(object sender, EventArgs e)
        {
            cb_Item15.Items.Clear();
            switch (cb_Category15.SelectedIndex)
            {
                case 0:
                    cb_Item15.Items.AddRange(Eggs.ToArray());
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 28] = 1;
                    break;
                case 1:
                    cb_Item15.Items.AddRange(Fruit.Keys.ToArray());
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 28] = 3;
                    break;
                case 2:
                    cb_Item15.Items.AddRange(Seed.ToArray());
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 28] = 7;
                    break;
                case 3:
                    cb_Item15.Items.AddRange(Hat.ToArray());
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 28] = 9;
                    break;
                case 4:
                    cb_Item15.Items.AddRange(Themes.ToArray());
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 28] = 16;
                    break;
            }
            if (loaded) { Main.loadedSave[offsets.chaoSave.MarketItemsStart + 29] = 0; }
            if (cb_Category15.SelectedIndex == 1) { cb_Item15.SelectedIndex = Fruit.Where(x => x.Value == Main.loadedSave[offsets.chaoSave.MarketItemsStart + 29]).First().Value; }
            if (cb_Category15.SelectedIndex == 3)
            {
                cb_Item15.SelectedIndex = (Main.loadedSave[offsets.chaoSave.MarketItemsStart + 29] - 1);
                if (cb_Item15.SelectedItem == null) { cb_Item15.SelectedIndex = 0; }
            }
            if (cb_Category15.SelectedIndex != 1 && cb_Category15.SelectedIndex != 3) { cb_Item15.SelectedIndex = Main.loadedSave[offsets.chaoSave.MarketItemsStart + 29]; }
        }

        private void Cb_Category16_SelectedIndexChanged(object sender, EventArgs e)
        {
            cb_Item16.Items.Clear();
            switch (cb_Category16.SelectedIndex)
            {
                case 0:
                    cb_Item16.Items.AddRange(Eggs.ToArray());
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 30] = 1;
                    break;
                case 1:
                    cb_Item16.Items.AddRange(Fruit.Keys.ToArray());
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 30] = 3;
                    break;
                case 2:
                    cb_Item16.Items.AddRange(Seed.ToArray());
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 30] = 7;
                    break;
                case 3:
                    cb_Item16.Items.AddRange(Hat.ToArray());
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 30] = 9;
                    break;
                case 4:
                    cb_Item16.Items.AddRange(Themes.ToArray());
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 30] = 16;
                    break;
            }
            if (loaded) { Main.loadedSave[offsets.chaoSave.MarketItemsStart + 31] = 0; }
            if (cb_Category16.SelectedIndex == 1) { cb_Item16.SelectedIndex = Fruit.Where(x => x.Value == Main.loadedSave[offsets.chaoSave.MarketItemsStart + 31]).First().Value; }
            if (cb_Category16.SelectedIndex == 3)
            {
                cb_Item16.SelectedIndex = (Main.loadedSave[offsets.chaoSave.MarketItemsStart + 31] - 1);
                if (cb_Item16.SelectedItem == null) { cb_Item16.SelectedIndex = 0; }
            }
            if (cb_Category16.SelectedIndex != 1 && cb_Category16.SelectedIndex != 3) { cb_Item16.SelectedIndex = Main.loadedSave[offsets.chaoSave.MarketItemsStart + 31]; }
        }

        private void Cb_Category17_SelectedIndexChanged(object sender, EventArgs e)
        {
            cb_Item17.Items.Clear();
            switch (cb_Category17.SelectedIndex)
            {
                case 0:
                    cb_Item17.Items.AddRange(Eggs.ToArray());
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 32] = 1;
                    break;
                case 1:
                    cb_Item17.Items.AddRange(Fruit.Keys.ToArray());
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 32] = 3;
                    break;
                case 2:
                    cb_Item17.Items.AddRange(Seed.ToArray());
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 32] = 7;
                    break;
                case 3:
                    cb_Item17.Items.AddRange(Hat.ToArray());
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 32] = 9;
                    break;
                case 4:
                    cb_Item17.Items.AddRange(Themes.ToArray());
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 32] = 16;
                    break;
            }
            if (loaded) { Main.loadedSave[offsets.chaoSave.MarketItemsStart + 33] = 0; }
            if (cb_Category17.SelectedIndex == 1) { cb_Item17.SelectedIndex = Fruit.Where(x => x.Value == Main.loadedSave[offsets.chaoSave.MarketItemsStart + 33]).First().Value; }
            if (cb_Category17.SelectedIndex == 3)
            {
                cb_Item17.SelectedIndex = (Main.loadedSave[offsets.chaoSave.MarketItemsStart + 33] - 1);
                if (cb_Item17.SelectedItem == null) { cb_Item17.SelectedIndex = 0; }
            }
            if (cb_Category17.SelectedIndex != 1 && cb_Category17.SelectedIndex != 3) { cb_Item17.SelectedIndex = Main.loadedSave[offsets.chaoSave.MarketItemsStart + 33]; }
        }

        private void Cb_Category18_SelectedIndexChanged(object sender, EventArgs e)
        {
            cb_Item18.Items.Clear();
            switch (cb_Category18.SelectedIndex)
            {
                case 0:
                    cb_Item18.Items.AddRange(Eggs.ToArray());
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 34] = 1;
                    break;
                case 1:
                    cb_Item18.Items.AddRange(Fruit.Keys.ToArray());
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 34] = 3;
                    break;
                case 2:
                    cb_Item18.Items.AddRange(Seed.ToArray());
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 34] = 7;
                    break;
                case 3:
                    cb_Item18.Items.AddRange(Hat.ToArray());
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 34] = 9;
                    break;
                case 4:
                    cb_Item18.Items.AddRange(Themes.ToArray());
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 34] = 16;
                    break;
            }
            if (loaded) { Main.loadedSave[offsets.chaoSave.MarketItemsStart + 35] = 0; }
            if (cb_Category18.SelectedIndex == 1) { cb_Item18.SelectedIndex = Fruit.Where(x => x.Value == Main.loadedSave[offsets.chaoSave.MarketItemsStart + 35]).First().Value; }
            if (cb_Category18.SelectedIndex == 3)
            {
                cb_Item18.SelectedIndex = (Main.loadedSave[offsets.chaoSave.MarketItemsStart + 35] - 1);
                if (cb_Item18.SelectedItem == null) { cb_Item18.SelectedIndex = 0; }
            }
            if (cb_Category18.SelectedIndex != 1 && cb_Category18.SelectedIndex != 3) { cb_Item18.SelectedIndex = Main.loadedSave[offsets.chaoSave.MarketItemsStart + 35]; }
        }

        private void Cb_Category19_SelectedIndexChanged(object sender, EventArgs e)
        {
            cb_Item19.Items.Clear();
            switch (cb_Category19.SelectedIndex)
            {
                case 0:
                    cb_Item19.Items.AddRange(Eggs.ToArray());
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 36] = 1;
                    break;
                case 1:
                    cb_Item19.Items.AddRange(Fruit.Keys.ToArray());
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 36] = 3;
                    break;
                case 2:
                    cb_Item19.Items.AddRange(Seed.ToArray());
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 36] = 7;
                    break;
                case 3:
                    cb_Item19.Items.AddRange(Hat.ToArray());
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 36] = 9;
                    break;
                case 4:
                    cb_Item19.Items.AddRange(Themes.ToArray());
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 36] = 16;
                    break;
            }
            if (loaded) { Main.loadedSave[offsets.chaoSave.MarketItemsStart + 37] = 0; }
            if (cb_Category19.SelectedIndex == 1) { cb_Item19.SelectedIndex = Fruit.Where(x => x.Value == Main.loadedSave[offsets.chaoSave.MarketItemsStart + 37]).First().Value; }
            if (cb_Category19.SelectedIndex == 3)
            {
                cb_Item19.SelectedIndex = (Main.loadedSave[offsets.chaoSave.MarketItemsStart + 37] - 1);
                if (cb_Item19.SelectedItem == null) { cb_Item19.SelectedIndex = 0; }
            }
            if (cb_Category19.SelectedIndex != 1 && cb_Category19.SelectedIndex != 3) { cb_Item19.SelectedIndex = Main.loadedSave[offsets.chaoSave.MarketItemsStart + 37]; }
        }

        private void Cb_Category20_SelectedIndexChanged(object sender, EventArgs e)
        {
            cb_Item20.Items.Clear();
            switch (cb_Category20.SelectedIndex)
            {
                case 0:
                    cb_Item20.Items.AddRange(Eggs.ToArray());
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 38] = 1;
                    break;
                case 1:
                    cb_Item20.Items.AddRange(Fruit.Keys.ToArray());
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 38] = 3;
                    break;
                case 2:
                    cb_Item20.Items.AddRange(Seed.ToArray());
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 38] = 7;
                    break;
                case 3:
                    cb_Item20.Items.AddRange(Hat.ToArray());
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 38] = 9;
                    break;
                case 4:
                    cb_Item20.Items.AddRange(Themes.ToArray());
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 38] = 16;
                    break;
            }
            if (loaded) { Main.loadedSave[offsets.chaoSave.MarketItemsStart + 39] = 0; }
            if (cb_Category20.SelectedIndex == 1) { cb_Item20.SelectedIndex = Fruit.Where(x => x.Value == Main.loadedSave[offsets.chaoSave.MarketItemsStart + 39]).First().Value; }
            if (cb_Category20.SelectedIndex == 3)
            {
                cb_Item20.SelectedIndex = (Main.loadedSave[offsets.chaoSave.MarketItemsStart + 39] - 1);
                if (cb_Item20.SelectedItem == null) { cb_Item20.SelectedIndex = 0; }
            }
            if (cb_Category20.SelectedIndex != 1 && cb_Category20.SelectedIndex != 3) { cb_Item20.SelectedIndex = Main.loadedSave[offsets.chaoSave.MarketItemsStart + 39]; }
        }

        private void Cb_Category21_SelectedIndexChanged(object sender, EventArgs e)
        {
            cb_Item21.Items.Clear();
            switch (cb_Category21.SelectedIndex)
            {
                case 0:
                    cb_Item21.Items.AddRange(Eggs.ToArray());
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 40] = 1;
                    break;
                case 1:
                    cb_Item21.Items.AddRange(Fruit.Keys.ToArray());
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 40] = 3;
                    break;
                case 2:
                    cb_Item21.Items.AddRange(Seed.ToArray());
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 40] = 7;
                    break;
                case 3:
                    cb_Item21.Items.AddRange(Hat.ToArray());
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 40] = 9;
                    break;
                case 4:
                    cb_Item21.Items.AddRange(Themes.ToArray());
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 40] = 16;
                    break;
            }
            if (loaded) { Main.loadedSave[offsets.chaoSave.MarketItemsStart + 41] = 0; }
            if (cb_Category21.SelectedIndex == 1) { cb_Item21.SelectedIndex = Fruit.Where(x => x.Value == Main.loadedSave[offsets.chaoSave.MarketItemsStart + 41]).First().Value; }
            if (cb_Category21.SelectedIndex == 3)
            {
                cb_Item21.SelectedIndex = (Main.loadedSave[offsets.chaoSave.MarketItemsStart + 41] - 1);
                if (cb_Item21.SelectedItem == null) { cb_Item21.SelectedIndex = 0; }
            }
            if (cb_Category21.SelectedIndex != 1 && cb_Category21.SelectedIndex != 3) { cb_Item21.SelectedIndex = Main.loadedSave[offsets.chaoSave.MarketItemsStart + 41]; }
        }

        private void Cb_Category22_SelectedIndexChanged(object sender, EventArgs e)
        {
            cb_Item22.Items.Clear();
            switch (cb_Category22.SelectedIndex)
            {
                case 0:
                    cb_Item22.Items.AddRange(Eggs.ToArray());
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 42] = 1;
                    break;
                case 1:
                    cb_Item22.Items.AddRange(Fruit.Keys.ToArray());
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 42] = 3;
                    break;
                case 2:
                    cb_Item22.Items.AddRange(Seed.ToArray());
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 42] = 7;
                    break;
                case 3:
                    cb_Item22.Items.AddRange(Hat.ToArray());
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 42] = 9;
                    break;
                case 4:
                    cb_Item22.Items.AddRange(Themes.ToArray());
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 42] = 16;
                    break;
            }
            if (loaded) { Main.loadedSave[offsets.chaoSave.MarketItemsStart + 43] = 0; }
            if (cb_Category22.SelectedIndex == 1) { cb_Item22.SelectedIndex = Fruit.Where(x => x.Value == Main.loadedSave[offsets.chaoSave.MarketItemsStart + 43]).First().Value; }
            if (cb_Category22.SelectedIndex == 3)
            {
                cb_Item22.SelectedIndex = (Main.loadedSave[offsets.chaoSave.MarketItemsStart + 43] - 1);
                if (cb_Item22.SelectedItem == null) { cb_Item22.SelectedIndex = 0; }
            }
            if (cb_Category22.SelectedIndex != 1 && cb_Category22.SelectedIndex != 3) { cb_Item22.SelectedIndex = Main.loadedSave[offsets.chaoSave.MarketItemsStart + 43]; }
        }

        private void Cb_Category23_SelectedIndexChanged(object sender, EventArgs e)
        {
            cb_Item23.Items.Clear();
            switch (cb_Category23.SelectedIndex)
            {
                case 0:
                    cb_Item23.Items.AddRange(Eggs.ToArray());
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 44] = 1;
                    break;
                case 1:
                    cb_Item23.Items.AddRange(Fruit.Keys.ToArray());
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 44] = 3;
                    break;
                case 2:
                    cb_Item23.Items.AddRange(Seed.ToArray());
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 44] = 7;
                    break;
                case 3:
                    cb_Item23.Items.AddRange(Hat.ToArray());
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 44] = 9;
                    break;
                case 4:
                    cb_Item23.Items.AddRange(Themes.ToArray());
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 44] = 16;
                    break;
            }
            if (loaded) { Main.loadedSave[offsets.chaoSave.MarketItemsStart + 45] = 0; }
            if (cb_Category23.SelectedIndex == 1) { cb_Item23.SelectedIndex = Fruit.Where(x => x.Value == Main.loadedSave[offsets.chaoSave.MarketItemsStart + 45]).First().Value; }
            if (cb_Category23.SelectedIndex == 3)
            {
                cb_Item23.SelectedIndex = (Main.loadedSave[offsets.chaoSave.MarketItemsStart + 45] - 1);
                if (cb_Item23.SelectedItem == null) { cb_Item23.SelectedIndex = 0; }
            }
            if (cb_Category23.SelectedIndex != 1 && cb_Category23.SelectedIndex != 3) { cb_Item23.SelectedIndex = Main.loadedSave[offsets.chaoSave.MarketItemsStart + 45]; }
        }

        private void Cb_Category24_SelectedIndexChanged(object sender, EventArgs e)
        {
            cb_Item24.Items.Clear();
            switch (cb_Category24.SelectedIndex)
            {
                case 0:
                    cb_Item24.Items.AddRange(Eggs.ToArray());
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 46] = 1;
                    break;
                case 1:
                    cb_Item24.Items.AddRange(Fruit.Keys.ToArray());
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 46] = 3;
                    break;
                case 2:
                    cb_Item24.Items.AddRange(Seed.ToArray());
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 46] = 7;
                    break;
                case 3:
                    cb_Item24.Items.AddRange(Hat.ToArray());
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 46] = 9;
                    break;
                case 4:
                    cb_Item24.Items.AddRange(Themes.ToArray());
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 46] = 16;
                    break;
            }
            if (loaded) { Main.loadedSave[offsets.chaoSave.MarketItemsStart + 47] = 0; }
            if (cb_Category24.SelectedIndex == 1) { cb_Item24.SelectedIndex = Fruit.Where(x => x.Value == Main.loadedSave[offsets.chaoSave.MarketItemsStart + 47]).First().Value; }
            if (cb_Category24.SelectedIndex == 3)
            {
                cb_Item24.SelectedIndex = (Main.loadedSave[offsets.chaoSave.MarketItemsStart + 47] - 1);
                if (cb_Item24.SelectedItem == null) { cb_Item24.SelectedIndex = 0; }
            }
            if (cb_Category24.SelectedIndex != 1 && cb_Category24.SelectedIndex != 3) { cb_Item24.SelectedIndex = Main.loadedSave[offsets.chaoSave.MarketItemsStart + 47]; }
        }

        private void Cb_Category25_SelectedIndexChanged(object sender, EventArgs e)
        {
            cb_Item25.Items.Clear();
            switch (cb_Category25.SelectedIndex)
            {
                case 0:
                    cb_Item25.Items.AddRange(Eggs.ToArray());
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 48] = 1;
                    break;
                case 1:
                    cb_Item25.Items.AddRange(Fruit.Keys.ToArray());
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 48] = 3;
                    break;
                case 2:
                    cb_Item25.Items.AddRange(Seed.ToArray());
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 48] = 7;
                    break;
                case 3:
                    cb_Item25.Items.AddRange(Hat.ToArray());
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 48] = 9;
                    break;
                case 4:
                    cb_Item25.Items.AddRange(Themes.ToArray());
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 48] = 16;
                    break;
            }
            if (loaded) { Main.loadedSave[offsets.chaoSave.MarketItemsStart + 49] = 0; }
            if (cb_Category25.SelectedIndex == 1) { cb_Item25.SelectedIndex = Fruit.Where(x => x.Value == Main.loadedSave[offsets.chaoSave.MarketItemsStart + 49]).First().Value; }
            if (cb_Category25.SelectedIndex == 3)
            {
                cb_Item25.SelectedIndex = (Main.loadedSave[offsets.chaoSave.MarketItemsStart + 49] - 1);
                if (cb_Item25.SelectedItem == null) { cb_Item25.SelectedIndex = 0; }
            }
            if (cb_Category25.SelectedIndex != 1 && cb_Category25.SelectedIndex != 3) { cb_Item25.SelectedIndex = Main.loadedSave[offsets.chaoSave.MarketItemsStart + 49]; }
        }

        private void Cb_Category26_SelectedIndexChanged(object sender, EventArgs e)
        {
            cb_Item26.Items.Clear();
            switch (cb_Category26.SelectedIndex)
            {
                case 0:
                    cb_Item26.Items.AddRange(Eggs.ToArray());
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 50] = 1;
                    break;
                case 1:
                    cb_Item26.Items.AddRange(Fruit.Keys.ToArray());
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 50] = 3;
                    break;
                case 2:
                    cb_Item26.Items.AddRange(Seed.ToArray());
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 50] = 7;
                    break;
                case 3:
                    cb_Item26.Items.AddRange(Hat.ToArray());
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 50] = 9;
                    break;
                case 4:
                    cb_Item26.Items.AddRange(Themes.ToArray());
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 50] = 16;
                    break;
            }
            if (loaded) { Main.loadedSave[offsets.chaoSave.MarketItemsStart + 51] = 0; }
            if (cb_Category26.SelectedIndex == 1) { cb_Item26.SelectedIndex = Fruit.Where(x => x.Value == Main.loadedSave[offsets.chaoSave.MarketItemsStart + 51]).First().Value; }
            if (cb_Category26.SelectedIndex == 3)
            {
                cb_Item26.SelectedIndex = (Main.loadedSave[offsets.chaoSave.MarketItemsStart + 51] - 1);
                if (cb_Item26.SelectedItem == null) { cb_Item26.SelectedIndex = 0; }
            }
            if (cb_Category26.SelectedIndex != 1 && cb_Category26.SelectedIndex != 3) { cb_Item26.SelectedIndex = Main.loadedSave[offsets.chaoSave.MarketItemsStart + 51]; }
        }

        private void Cb_Category27_SelectedIndexChanged(object sender, EventArgs e)
        {
            cb_Item27.Items.Clear();
            switch (cb_Category27.SelectedIndex)
            {
                case 0:
                    cb_Item27.Items.AddRange(Eggs.ToArray());
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 52] = 1;
                    break;
                case 1:
                    cb_Item27.Items.AddRange(Fruit.Keys.ToArray());
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 52] = 3;
                    break;
                case 2:
                    cb_Item27.Items.AddRange(Seed.ToArray());
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 52] = 7;
                    break;
                case 3:
                    cb_Item27.Items.AddRange(Hat.ToArray());
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 52] = 9;
                    break;
                case 4:
                    cb_Item27.Items.AddRange(Themes.ToArray());
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 52] = 16;
                    break;
            }
            if (loaded) { Main.loadedSave[offsets.chaoSave.MarketItemsStart + 53] = 0; }
            if (cb_Category27.SelectedIndex == 1) { cb_Item27.SelectedIndex = Fruit.Where(x => x.Value == Main.loadedSave[offsets.chaoSave.MarketItemsStart + 53]).First().Value; }
            if (cb_Category27.SelectedIndex == 3)
            {
                cb_Item27.SelectedIndex = (Main.loadedSave[offsets.chaoSave.MarketItemsStart + 53] - 1);
                if (cb_Item27.SelectedItem == null) { cb_Item27.SelectedIndex = 0; }
            }
            if (cb_Category27.SelectedIndex != 1 && cb_Category27.SelectedIndex != 3) { cb_Item27.SelectedIndex = Main.loadedSave[offsets.chaoSave.MarketItemsStart + 53]; }
        }

        private void Cb_Category28_SelectedIndexChanged(object sender, EventArgs e)
        {
            cb_Item28.Items.Clear();
            switch (cb_Category28.SelectedIndex)
            {
                case 0:
                    cb_Item28.Items.AddRange(Eggs.ToArray());
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 54] = 1;
                    break;
                case 1:
                    cb_Item28.Items.AddRange(Fruit.Keys.ToArray());
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 54] = 3;
                    break;
                case 2:
                    cb_Item28.Items.AddRange(Seed.ToArray());
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 54] = 7;
                    break;
                case 3:
                    cb_Item28.Items.AddRange(Hat.ToArray());
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 54] = 9;
                    break;
                case 4:
                    cb_Item28.Items.AddRange(Themes.ToArray());
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 54] = 16;
                    break;
            }
            if (loaded) { Main.loadedSave[offsets.chaoSave.MarketItemsStart + 55] = 0; }
            if (cb_Category28.SelectedIndex == 1) { cb_Item28.SelectedIndex = Fruit.Where(x => x.Value == Main.loadedSave[offsets.chaoSave.MarketItemsStart + 55]).First().Value; }
            if (cb_Category28.SelectedIndex == 3)
            {
                cb_Item28.SelectedIndex = (Main.loadedSave[offsets.chaoSave.MarketItemsStart + 55] - 1);
                if (cb_Item28.SelectedItem == null) { cb_Item28.SelectedIndex = 0; }
            }
            if (cb_Category28.SelectedIndex != 1 && cb_Category28.SelectedIndex != 3) { cb_Item28.SelectedIndex = Main.loadedSave[offsets.chaoSave.MarketItemsStart + 55]; }
        }

        private void Cb_Category29_SelectedIndexChanged(object sender, EventArgs e)
        {
            cb_Item29.Items.Clear();
            switch (cb_Category29.SelectedIndex)
            {
                case 0:
                    cb_Item29.Items.AddRange(Eggs.ToArray());
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 56] = 1;
                    break;
                case 1:
                    cb_Item29.Items.AddRange(Fruit.Keys.ToArray());
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 56] = 3;
                    break;
                case 2:
                    cb_Item29.Items.AddRange(Seed.ToArray());
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 56] = 7;
                    break;
                case 3:
                    cb_Item29.Items.AddRange(Hat.ToArray());
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 56] = 9;
                    break;
                case 4:
                    cb_Item29.Items.AddRange(Themes.ToArray());
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 56] = 16;
                    break;
            }
            if (loaded) { Main.loadedSave[offsets.chaoSave.MarketItemsStart + 57] = 0; }
            if (cb_Category29.SelectedIndex == 1) { cb_Item29.SelectedIndex = Fruit.Where(x => x.Value == Main.loadedSave[offsets.chaoSave.MarketItemsStart + 57]).First().Value; }
            if (cb_Category29.SelectedIndex == 3)
            {
                cb_Item29.SelectedIndex = (Main.loadedSave[offsets.chaoSave.MarketItemsStart + 57] - 1);
                if (cb_Item29.SelectedItem == null) { cb_Item29.SelectedIndex = 0; }
            }
            if (cb_Category29.SelectedIndex != 1 && cb_Category29.SelectedIndex != 3) { cb_Item29.SelectedIndex = Main.loadedSave[offsets.chaoSave.MarketItemsStart + 57]; }
        }

        private void Cb_Category30_SelectedIndexChanged(object sender, EventArgs e)
        {
            cb_Item30.Items.Clear();
            switch (cb_Category30.SelectedIndex)
            {
                case 0:
                    cb_Item30.Items.AddRange(Eggs.ToArray());
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 58] = 1;
                    break;
                case 1:
                    cb_Item30.Items.AddRange(Fruit.Keys.ToArray());
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 58] = 3;
                    break;
                case 2:
                    cb_Item30.Items.AddRange(Seed.ToArray());
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 58] = 7;
                    break;
                case 3:
                    cb_Item30.Items.AddRange(Hat.ToArray());
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 58] = 9;
                    break;
                case 4:
                    cb_Item30.Items.AddRange(Themes.ToArray());
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 58] = 16;
                    break;
            }
            if (loaded) { Main.loadedSave[offsets.chaoSave.MarketItemsStart + 59] = 0; }
            if (cb_Category30.SelectedIndex == 1) { cb_Item30.SelectedIndex = Fruit.Where(x => x.Value == Main.loadedSave[offsets.chaoSave.MarketItemsStart + 59]).First().Value; }
            if (cb_Category30.SelectedIndex == 3)
            {
                cb_Item30.SelectedIndex = (Main.loadedSave[offsets.chaoSave.MarketItemsStart + 59] - 1);
                if (cb_Item30.SelectedItem == null) { cb_Item30.SelectedIndex = 0; }
            }
            if (cb_Category30.SelectedIndex != 1 && cb_Category30.SelectedIndex != 3) { cb_Item30.SelectedIndex = Main.loadedSave[offsets.chaoSave.MarketItemsStart + 59]; }
        }

        private void Cb_Category31_SelectedIndexChanged(object sender, EventArgs e)
        {
            cb_Item31.Items.Clear();
            switch (cb_Category31.SelectedIndex)
            {
                case 0:
                    cb_Item31.Items.AddRange(Eggs.ToArray());
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 60] = 1;
                    break;
                case 1:
                    cb_Item31.Items.AddRange(Fruit.Keys.ToArray());
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 60] = 3;
                    break;
                case 2:
                    cb_Item31.Items.AddRange(Seed.ToArray());
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 60] = 7;
                    break;
                case 3:
                    cb_Item31.Items.AddRange(Hat.ToArray());
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 60] = 9;
                    break;
                case 4:
                    cb_Item31.Items.AddRange(Themes.ToArray());
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 60] = 16;
                    break;
            }
            if (loaded) { Main.loadedSave[offsets.chaoSave.MarketItemsStart + 61] = 0; }
            if (cb_Category31.SelectedIndex == 1) { cb_Item31.SelectedIndex = Fruit.Where(x => x.Value == Main.loadedSave[offsets.chaoSave.MarketItemsStart + 61]).First().Value; }
            if (cb_Category31.SelectedIndex == 3)
            {
                cb_Item31.SelectedIndex = (Main.loadedSave[offsets.chaoSave.MarketItemsStart + 61] - 1);
                if (cb_Item31.SelectedItem == null) { cb_Item31.SelectedIndex = 0; }
            }
            if (cb_Category31.SelectedIndex != 1 && cb_Category31.SelectedIndex != 3) { cb_Item31.SelectedIndex = Main.loadedSave[offsets.chaoSave.MarketItemsStart + 61]; }
        }

        private void Cb_Category32_SelectedIndexChanged(object sender, EventArgs e)
        {
            cb_Item32.Items.Clear();
            switch (cb_Category32.SelectedIndex)
            {
                case 0:
                    cb_Item32.Items.AddRange(Eggs.ToArray());
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 62] = 1;
                    break;
                case 1:
                    cb_Item32.Items.AddRange(Fruit.Keys.ToArray());
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 62] = 3;
                    break;
                case 2:
                    cb_Item32.Items.AddRange(Seed.ToArray());
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 62] = 7;
                    break;
                case 3:
                    cb_Item32.Items.AddRange(Hat.ToArray());
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 62] = 9;
                    break;
                case 4:
                    cb_Item32.Items.AddRange(Themes.ToArray());
                    Main.loadedSave[offsets.chaoSave.MarketItemsStart + 62] = 16;
                    break;
            }
            if (loaded) { Main.loadedSave[offsets.chaoSave.MarketItemsStart + 63] = 0; }
            if (cb_Category32.SelectedIndex == 1) { cb_Item32.SelectedIndex = Fruit.Where(x => x.Value == Main.loadedSave[offsets.chaoSave.MarketItemsStart + 63]).First().Value; }
            if (cb_Category32.SelectedIndex == 3)
            {
                cb_Item32.SelectedIndex = (Main.loadedSave[offsets.chaoSave.MarketItemsStart + 63] - 1);
                if (cb_Item32.SelectedItem == null) { cb_Item32.SelectedIndex = 0; }
            }
            if (cb_Category32.SelectedIndex != 1 && cb_Category32.SelectedIndex != 3) { cb_Item32.SelectedIndex = Main.loadedSave[offsets.chaoSave.MarketItemsStart + 63]; }
        }

        private void Cb_Item1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_Category1.SelectedIndex == 1) { Main.loadedSave[offsets.chaoSave.MarketItemsStart + 1] = (byte)Fruit.Where(x => x.Key == cb_Item1.SelectedItem.ToString()).First().Value; }
            if (cb_Category1.SelectedIndex == 3) { Main.loadedSave[offsets.chaoSave.MarketItemsStart + 1] = (byte)(cb_Item1.SelectedIndex + 1); }
            if (cb_Category1.SelectedIndex != 1 && cb_Category1.SelectedIndex != 3) { Main.loadedSave[offsets.chaoSave.MarketItemsStart + 1] = (byte)cb_Item1.SelectedIndex; }
        }

        private void Cb_Item2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_Category2.SelectedIndex == 1) { Main.loadedSave[offsets.chaoSave.MarketItemsStart + 3] = (byte)Fruit.Where(x => x.Key == cb_Item2.SelectedItem.ToString()).First().Value; }
            if (cb_Category2.SelectedIndex == 3) { Main.loadedSave[offsets.chaoSave.MarketItemsStart + 3] = (byte)(cb_Item2.SelectedIndex + 1); }
            if (cb_Category2.SelectedIndex != 1 && cb_Category2.SelectedIndex != 3) { Main.loadedSave[offsets.chaoSave.MarketItemsStart + 3] = (byte)cb_Item2.SelectedIndex; }
        }

        private void Cb_Item3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_Category3.SelectedIndex == 1) { Main.loadedSave[offsets.chaoSave.MarketItemsStart + 5] = (byte)Fruit.Where(x => x.Key == cb_Item3.SelectedItem.ToString()).First().Value; }
            if (cb_Category3.SelectedIndex == 3) { Main.loadedSave[offsets.chaoSave.MarketItemsStart + 5] = (byte)(cb_Item3.SelectedIndex + 1); }
            if (cb_Category3.SelectedIndex != 1 && cb_Category3.SelectedIndex != 3) { Main.loadedSave[offsets.chaoSave.MarketItemsStart + 5] = (byte)cb_Item3.SelectedIndex; }
        }

        private void Cb_Item4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_Category4.SelectedIndex == 1) { Main.loadedSave[offsets.chaoSave.MarketItemsStart + 7] = (byte)Fruit.Where(x => x.Key == cb_Item4.SelectedItem.ToString()).First().Value; }
            if (cb_Category4.SelectedIndex == 3) { Main.loadedSave[offsets.chaoSave.MarketItemsStart + 7] = (byte)(cb_Item4.SelectedIndex + 1); }
            if (cb_Category4.SelectedIndex != 1 && cb_Category4.SelectedIndex != 3) { Main.loadedSave[offsets.chaoSave.MarketItemsStart + 7] = (byte)cb_Item4.SelectedIndex; }
        }

        private void Cb_Item5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_Category5.SelectedIndex == 1) { Main.loadedSave[offsets.chaoSave.MarketItemsStart + 9] = (byte)Fruit.Where(x => x.Key == cb_Item5.SelectedItem.ToString()).First().Value; }
            if (cb_Category5.SelectedIndex == 3) { Main.loadedSave[offsets.chaoSave.MarketItemsStart + 9] = (byte)(cb_Item5.SelectedIndex + 1); }
            if (cb_Category5.SelectedIndex != 1 && cb_Category5.SelectedIndex != 3) { Main.loadedSave[offsets.chaoSave.MarketItemsStart + 9] = (byte)cb_Item5.SelectedIndex; }
        }

        private void Cb_Item6_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_Category6.SelectedIndex == 1) { Main.loadedSave[offsets.chaoSave.MarketItemsStart + 11] = (byte)Fruit.Where(x => x.Key == cb_Item6.SelectedItem.ToString()).First().Value; }
            if (cb_Category6.SelectedIndex == 3) { Main.loadedSave[offsets.chaoSave.MarketItemsStart + 11] = (byte)(cb_Item6.SelectedIndex + 1); }
            if (cb_Category6.SelectedIndex != 1 && cb_Category6.SelectedIndex != 3) { Main.loadedSave[offsets.chaoSave.MarketItemsStart + 11] = (byte)cb_Item6.SelectedIndex; }
        }

        private void Cb_Item7_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_Category7.SelectedIndex == 1) { Main.loadedSave[offsets.chaoSave.MarketItemsStart + 13] = (byte)Fruit.Where(x => x.Key == cb_Item7.SelectedItem.ToString()).First().Value; }
            if (cb_Category7.SelectedIndex == 3) { Main.loadedSave[offsets.chaoSave.MarketItemsStart + 13] = (byte)(cb_Item7.SelectedIndex + 1); }
            if (cb_Category7.SelectedIndex != 1 && cb_Category7.SelectedIndex != 3) { Main.loadedSave[offsets.chaoSave.MarketItemsStart + 13] = (byte)cb_Item7.SelectedIndex; }
        }

        private void Cb_Item8_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_Category8.SelectedIndex == 1) { Main.loadedSave[offsets.chaoSave.MarketItemsStart + 15] = (byte)Fruit.Where(x => x.Key == cb_Item8.SelectedItem.ToString()).First().Value; }
            if (cb_Category8.SelectedIndex == 3) { Main.loadedSave[offsets.chaoSave.MarketItemsStart + 15] = (byte)(cb_Item8.SelectedIndex + 1); }
            if (cb_Category8.SelectedIndex != 1 && cb_Category8.SelectedIndex != 3) { Main.loadedSave[offsets.chaoSave.MarketItemsStart + 15] = (byte)cb_Item8.SelectedIndex; }
        }

        private void Cb_Item9_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_Category9.SelectedIndex == 1) { Main.loadedSave[offsets.chaoSave.MarketItemsStart + 17] = (byte)Fruit.Where(x => x.Key == cb_Item9.SelectedItem.ToString()).First().Value; }
            if (cb_Category9.SelectedIndex == 3) { Main.loadedSave[offsets.chaoSave.MarketItemsStart + 17] = (byte)(cb_Item9.SelectedIndex + 1); }
            if (cb_Category9.SelectedIndex != 1 && cb_Category9.SelectedIndex != 3) { Main.loadedSave[offsets.chaoSave.MarketItemsStart + 17] = (byte)cb_Item9.SelectedIndex; }
        }

        private void Cb_Item10_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_Category10.SelectedIndex == 1) { Main.loadedSave[offsets.chaoSave.MarketItemsStart + 19] = (byte)Fruit.Where(x => x.Key == cb_Item10.SelectedItem.ToString()).First().Value; }
            if (cb_Category10.SelectedIndex == 3) { Main.loadedSave[offsets.chaoSave.MarketItemsStart + 19] = (byte)(cb_Item10.SelectedIndex + 1); }
            if (cb_Category10.SelectedIndex != 1 && cb_Category10.SelectedIndex != 3) { Main.loadedSave[offsets.chaoSave.MarketItemsStart + 19] = (byte)cb_Item10.SelectedIndex; }
        }

        private void Cb_Item11_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_Category11.SelectedIndex == 1) { Main.loadedSave[offsets.chaoSave.MarketItemsStart + 21] = (byte)Fruit.Where(x => x.Key == cb_Item11.SelectedItem.ToString()).First().Value; }
            if (cb_Category11.SelectedIndex == 3) { Main.loadedSave[offsets.chaoSave.MarketItemsStart + 21] = (byte)(cb_Item11.SelectedIndex + 1); }
            if (cb_Category11.SelectedIndex != 1 && cb_Category11.SelectedIndex != 3) { Main.loadedSave[offsets.chaoSave.MarketItemsStart + 21] = (byte)cb_Item11.SelectedIndex; }
        }

        private void Cb_Item12_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_Category12.SelectedIndex == 1) { Main.loadedSave[offsets.chaoSave.MarketItemsStart + 23] = (byte)Fruit.Where(x => x.Key == cb_Item12.SelectedItem.ToString()).First().Value; }
            if (cb_Category12.SelectedIndex == 3) { Main.loadedSave[offsets.chaoSave.MarketItemsStart + 23] = (byte)(cb_Item12.SelectedIndex + 1); }
            if (cb_Category12.SelectedIndex != 1 && cb_Category12.SelectedIndex != 3) { Main.loadedSave[offsets.chaoSave.MarketItemsStart + 23] = (byte)cb_Item12.SelectedIndex; }
        }

        private void Cb_Item13_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_Category13.SelectedIndex == 1) { Main.loadedSave[offsets.chaoSave.MarketItemsStart + 25] = (byte)Fruit.Where(x => x.Key == cb_Item13.SelectedItem.ToString()).First().Value; }
            if (cb_Category13.SelectedIndex == 3) { Main.loadedSave[offsets.chaoSave.MarketItemsStart + 25] = (byte)(cb_Item13.SelectedIndex + 1); }
            if (cb_Category13.SelectedIndex != 1 && cb_Category13.SelectedIndex != 3) { Main.loadedSave[offsets.chaoSave.MarketItemsStart + 25] = (byte)cb_Item13.SelectedIndex; }
        }

        private void Cb_Item14_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_Category14.SelectedIndex == 1) { Main.loadedSave[offsets.chaoSave.MarketItemsStart + 27] = (byte)Fruit.Where(x => x.Key == cb_Item14.SelectedItem.ToString()).First().Value; }
            if (cb_Category14.SelectedIndex == 3) { Main.loadedSave[offsets.chaoSave.MarketItemsStart + 27] = (byte)(cb_Item14.SelectedIndex + 1); }
            if (cb_Category14.SelectedIndex != 1 && cb_Category14.SelectedIndex != 3) { Main.loadedSave[offsets.chaoSave.MarketItemsStart + 27] = (byte)cb_Item14.SelectedIndex; }
        }

        private void Cb_Item15_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_Category15.SelectedIndex == 1) { Main.loadedSave[offsets.chaoSave.MarketItemsStart + 29] = (byte)Fruit.Where(x => x.Key == cb_Item15.SelectedItem.ToString()).First().Value; }
            if (cb_Category15.SelectedIndex == 3) { Main.loadedSave[offsets.chaoSave.MarketItemsStart + 29] = (byte)(cb_Item15.SelectedIndex + 1); }
            if (cb_Category15.SelectedIndex != 1 && cb_Category15.SelectedIndex != 3) { Main.loadedSave[offsets.chaoSave.MarketItemsStart + 29] = (byte)cb_Item15.SelectedIndex; }
        }

        private void Cb_Item16_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_Category16.SelectedIndex == 1) { Main.loadedSave[offsets.chaoSave.MarketItemsStart + 31] = (byte)Fruit.Where(x => x.Key == cb_Item16.SelectedItem.ToString()).First().Value; }
            if (cb_Category16.SelectedIndex == 3) { Main.loadedSave[offsets.chaoSave.MarketItemsStart + 31] = (byte)(cb_Item16.SelectedIndex + 1); }
            if (cb_Category16.SelectedIndex != 1 && cb_Category16.SelectedIndex != 3) { Main.loadedSave[offsets.chaoSave.MarketItemsStart + 31] = (byte)cb_Item16.SelectedIndex; }
        }

        private void Cb_Item17_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_Category17.SelectedIndex == 1) { Main.loadedSave[offsets.chaoSave.MarketItemsStart + 33] = (byte)Fruit.Where(x => x.Key == cb_Item17.SelectedItem.ToString()).First().Value; }
            if (cb_Category17.SelectedIndex == 3) { Main.loadedSave[offsets.chaoSave.MarketItemsStart + 33] = (byte)(cb_Item17.SelectedIndex + 1); }
            if (cb_Category17.SelectedIndex != 1 && cb_Category17.SelectedIndex != 3) { Main.loadedSave[offsets.chaoSave.MarketItemsStart + 33] = (byte)cb_Item17.SelectedIndex; }
        }

        private void Cb_Item18_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_Category18.SelectedIndex == 1) { Main.loadedSave[offsets.chaoSave.MarketItemsStart + 35] = (byte)Fruit.Where(x => x.Key == cb_Item18.SelectedItem.ToString()).First().Value; }
            if (cb_Category18.SelectedIndex == 3) { Main.loadedSave[offsets.chaoSave.MarketItemsStart + 35] = (byte)(cb_Item18.SelectedIndex + 1); }
            if (cb_Category18.SelectedIndex != 1 && cb_Category18.SelectedIndex != 3) { Main.loadedSave[offsets.chaoSave.MarketItemsStart + 35] = (byte)cb_Item18.SelectedIndex; }
        }

        private void Cb_Item19_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_Category19.SelectedIndex == 1) { Main.loadedSave[offsets.chaoSave.MarketItemsStart + 37] = (byte)Fruit.Where(x => x.Key == cb_Item19.SelectedItem.ToString()).First().Value; }
            if (cb_Category19.SelectedIndex == 3) { Main.loadedSave[offsets.chaoSave.MarketItemsStart + 37] = (byte)(cb_Item19.SelectedIndex + 1); }
            if (cb_Category19.SelectedIndex != 1 && cb_Category19.SelectedIndex != 3) { Main.loadedSave[offsets.chaoSave.MarketItemsStart + 37] = (byte)cb_Item19.SelectedIndex; }
        }

        private void Cb_Item20_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_Category20.SelectedIndex == 1) { Main.loadedSave[offsets.chaoSave.MarketItemsStart + 39] = (byte)Fruit.Where(x => x.Key == cb_Item20.SelectedItem.ToString()).First().Value; }
            if (cb_Category20.SelectedIndex == 3) { Main.loadedSave[offsets.chaoSave.MarketItemsStart + 39] = (byte)(cb_Item20.SelectedIndex + 1); }
            if (cb_Category20.SelectedIndex != 1 && cb_Category20.SelectedIndex != 3) { Main.loadedSave[offsets.chaoSave.MarketItemsStart + 39] = (byte)cb_Item20.SelectedIndex; }
        }

        private void Cb_Item21_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_Category21.SelectedIndex == 1) { Main.loadedSave[offsets.chaoSave.MarketItemsStart + 41] = (byte)Fruit.Where(x => x.Key == cb_Item21.SelectedItem.ToString()).First().Value; }
            if (cb_Category21.SelectedIndex == 3) { Main.loadedSave[offsets.chaoSave.MarketItemsStart + 41] = (byte)(cb_Item21.SelectedIndex + 1); }
            if (cb_Category21.SelectedIndex != 1 && cb_Category21.SelectedIndex != 3) { Main.loadedSave[offsets.chaoSave.MarketItemsStart + 41] = (byte)cb_Item21.SelectedIndex; }
        }

        private void Cb_Item22_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_Category22.SelectedIndex == 1) { Main.loadedSave[offsets.chaoSave.MarketItemsStart + 43] = (byte)Fruit.Where(x => x.Key == cb_Item22.SelectedItem.ToString()).First().Value; }
            if (cb_Category22.SelectedIndex == 3) { Main.loadedSave[offsets.chaoSave.MarketItemsStart + 43] = (byte)(cb_Item22.SelectedIndex + 1); }
            if (cb_Category22.SelectedIndex != 1 && cb_Category22.SelectedIndex != 3) { Main.loadedSave[offsets.chaoSave.MarketItemsStart + 43] = (byte)cb_Item22.SelectedIndex; }
        }

        private void Cb_Item23_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_Category23.SelectedIndex == 1) { Main.loadedSave[offsets.chaoSave.MarketItemsStart + 45] = (byte)Fruit.Where(x => x.Key == cb_Item23.SelectedItem.ToString()).First().Value; }
            if (cb_Category23.SelectedIndex == 3) { Main.loadedSave[offsets.chaoSave.MarketItemsStart + 45] = (byte)(cb_Item23.SelectedIndex + 1); }
            if (cb_Category23.SelectedIndex != 1 && cb_Category23.SelectedIndex != 3) { Main.loadedSave[offsets.chaoSave.MarketItemsStart + 45] = (byte)cb_Item23.SelectedIndex; }
        }

        private void Cb_Item24_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_Category24.SelectedIndex == 1) { Main.loadedSave[offsets.chaoSave.MarketItemsStart + 47] = (byte)Fruit.Where(x => x.Key == cb_Item24.SelectedItem.ToString()).First().Value; }
            if (cb_Category24.SelectedIndex == 3) { Main.loadedSave[offsets.chaoSave.MarketItemsStart + 47] = (byte)(cb_Item24.SelectedIndex + 1); }
            if (cb_Category24.SelectedIndex != 1 && cb_Category24.SelectedIndex != 3) { Main.loadedSave[offsets.chaoSave.MarketItemsStart + 47] = (byte)cb_Item24.SelectedIndex; }
        }

        private void Cb_Item25_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_Category25.SelectedIndex == 1) { Main.loadedSave[offsets.chaoSave.MarketItemsStart + 49] = (byte)Fruit.Where(x => x.Key == cb_Item25.SelectedItem.ToString()).First().Value; }
            if (cb_Category25.SelectedIndex == 3) { Main.loadedSave[offsets.chaoSave.MarketItemsStart + 49] = (byte)(cb_Item25.SelectedIndex + 1); }
            if (cb_Category25.SelectedIndex != 1 && cb_Category25.SelectedIndex != 3) { Main.loadedSave[offsets.chaoSave.MarketItemsStart + 49] = (byte)cb_Item25.SelectedIndex; }
        }

        private void Cb_Item26_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_Category26.SelectedIndex == 1) { Main.loadedSave[offsets.chaoSave.MarketItemsStart + 51] = (byte)Fruit.Where(x => x.Key == cb_Item26.SelectedItem.ToString()).First().Value; }
            if (cb_Category26.SelectedIndex == 3) { Main.loadedSave[offsets.chaoSave.MarketItemsStart + 51] = (byte)(cb_Item26.SelectedIndex + 1); }
            if (cb_Category26.SelectedIndex != 1 && cb_Category26.SelectedIndex != 3) { Main.loadedSave[offsets.chaoSave.MarketItemsStart + 51] = (byte)cb_Item26.SelectedIndex; }
        }

        private void Cb_Item27_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_Category27.SelectedIndex == 1) { Main.loadedSave[offsets.chaoSave.MarketItemsStart + 53] = (byte)Fruit.Where(x => x.Key == cb_Item27.SelectedItem.ToString()).First().Value; }
            if (cb_Category27.SelectedIndex == 3) { Main.loadedSave[offsets.chaoSave.MarketItemsStart + 53] = (byte)(cb_Item27.SelectedIndex + 1); }
            if (cb_Category27.SelectedIndex != 1 && cb_Category27.SelectedIndex != 3) { Main.loadedSave[offsets.chaoSave.MarketItemsStart + 53] = (byte)cb_Item27.SelectedIndex; }
        }

        private void Cb_Item28_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_Category28.SelectedIndex == 1) { Main.loadedSave[offsets.chaoSave.MarketItemsStart + 55] = (byte)Fruit.Where(x => x.Key == cb_Item28.SelectedItem.ToString()).First().Value; }
            if (cb_Category28.SelectedIndex == 3) { Main.loadedSave[offsets.chaoSave.MarketItemsStart + 55] = (byte)(cb_Item28.SelectedIndex + 1); }
            if (cb_Category28.SelectedIndex != 1 && cb_Category28.SelectedIndex != 3) { Main.loadedSave[offsets.chaoSave.MarketItemsStart + 55] = (byte)cb_Item28.SelectedIndex; }
        }

        private void Cb_Item29_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_Category29.SelectedIndex == 1) { Main.loadedSave[offsets.chaoSave.MarketItemsStart + 57] = (byte)Fruit.Where(x => x.Key == cb_Item29.SelectedItem.ToString()).First().Value; }
            if (cb_Category29.SelectedIndex == 3) { Main.loadedSave[offsets.chaoSave.MarketItemsStart + 57] = (byte)(cb_Item29.SelectedIndex + 1); }
            if (cb_Category29.SelectedIndex != 1 && cb_Category29.SelectedIndex != 3) { Main.loadedSave[offsets.chaoSave.MarketItemsStart + 57] = (byte)cb_Item29.SelectedIndex; }
        }

        private void Cb_Item30_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_Category30.SelectedIndex == 1) { Main.loadedSave[offsets.chaoSave.MarketItemsStart + 59] = (byte)Fruit.Where(x => x.Key == cb_Item30.SelectedItem.ToString()).First().Value; }
            if (cb_Category30.SelectedIndex == 3) { Main.loadedSave[offsets.chaoSave.MarketItemsStart + 59] = (byte)(cb_Item30.SelectedIndex + 1); }
            if (cb_Category30.SelectedIndex != 1 && cb_Category30.SelectedIndex != 3) { Main.loadedSave[offsets.chaoSave.MarketItemsStart + 59] = (byte)cb_Item30.SelectedIndex; }
        }

        private void Cb_Item31_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_Category31.SelectedIndex == 1) { Main.loadedSave[offsets.chaoSave.MarketItemsStart + 61] = (byte)Fruit.Where(x => x.Key == cb_Item31.SelectedItem.ToString()).First().Value; }
            if (cb_Category31.SelectedIndex == 3) { Main.loadedSave[offsets.chaoSave.MarketItemsStart + 61] = (byte)(cb_Item31.SelectedIndex + 1); }
            if (cb_Category31.SelectedIndex != 1 && cb_Category31.SelectedIndex != 3) { Main.loadedSave[offsets.chaoSave.MarketItemsStart + 61] = (byte)cb_Item31.SelectedIndex; }
        }

        private void Cb_Item32_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_Category32.SelectedIndex == 1) { Main.loadedSave[offsets.chaoSave.MarketItemsStart + 63] = (byte)Fruit.Where(x => x.Key == cb_Item32.SelectedItem.ToString()).First().Value; }
            if (cb_Category32.SelectedIndex == 3) { Main.loadedSave[offsets.chaoSave.MarketItemsStart + 63] = (byte)(cb_Item32.SelectedIndex + 1); }
            if (cb_Category32.SelectedIndex != 1 && cb_Category32.SelectedIndex != 3) { Main.loadedSave[offsets.chaoSave.MarketItemsStart + 63] = (byte)cb_Item32.SelectedIndex; }
        }
    }
}
