using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace SA2SaveUtility
{
    public partial class HeldItems : Form
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

        public HeldItems()
        {
            InitializeComponent();
            if (Main.isPC) { itemCount = Main.loadedSave[offsets.chaoSave.HeldCount]; }
            else { itemCount = Main.loadedSave[offsets.chaoSave.HeldCount + 3]; }
            switch (Main.loadedSave[offsets.chaoSave.HeldItemsStart])
            {
                case 255:
                    cb_Category1.SelectedIndex = 0;
                    Main.loadedSave[offsets.chaoSave.HeldItemsStart] = 0;
                    Main.loadedSave[offsets.chaoSave.HeldItemsStart + 1] = 0;
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
            }
            switch (Main.loadedSave[offsets.chaoSave.HeldItemsStart + 2])
            {
                case 255:
                    cb_Category2.SelectedIndex = 0;
                    Main.loadedSave[offsets.chaoSave.HeldItemsStart + 2] = 0;
                    Main.loadedSave[offsets.chaoSave.HeldItemsStart + 3] = 0;
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
            }
            switch (Main.loadedSave[offsets.chaoSave.HeldItemsStart + 4])
            {
                case 255:
                    cb_Category3.SelectedIndex = 0;
                    Main.loadedSave[offsets.chaoSave.HeldItemsStart + 4] = 0;
                    Main.loadedSave[offsets.chaoSave.HeldItemsStart + 5] = 0;
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
            }
            switch (Main.loadedSave[offsets.chaoSave.HeldItemsStart + 6])
            {
                case 255:
                    cb_Category4.SelectedIndex = 0;
                    Main.loadedSave[offsets.chaoSave.HeldItemsStart + 6] = 0;
                    Main.loadedSave[offsets.chaoSave.HeldItemsStart + 7] = 0;
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
            }
            switch (Main.loadedSave[offsets.chaoSave.HeldItemsStart + 8])
            {
                case 255:
                    cb_Category5.SelectedIndex = 0;
                    Main.loadedSave[offsets.chaoSave.HeldItemsStart + 8] = 0;
                    Main.loadedSave[offsets.chaoSave.HeldItemsStart + 9] = 0;
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
            }
            SetSize();
            loaded = true;
        }


        private void SetSize()
        {
            switch (itemCount)
            {
                case 0:
                    Height = 133;
                    Width = 346;
                    lb_Item.Visible = false;
                    lb_Category.Visible = false;
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
                    btn_RemoveItem.Enabled = false;
                    btn_AddItem.Enabled = true;
                    break;
                case 1:
                    Height = 133;
                    Width = 346;
                    lb_Item.Visible = true;
                    lb_Category.Visible = true;
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
                    btn_RemoveItem.Enabled = true;
                    btn_AddItem.Enabled = true;
                    break;
                case 2:
                    Height = 133;
                    Width = 346;
                    lb_Item.Visible = true;
                    lb_Category.Visible = true;
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
                    btn_RemoveItem.Enabled = true;
                    btn_AddItem.Enabled = true;
                    break;
                case 3:
                    Height = 133;
                    Width = 346;
                    lb_Item.Visible = true;
                    lb_Category.Visible = true;
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
                    btn_RemoveItem.Enabled = true;
                    btn_AddItem.Enabled = true;
                    break;
                case 4:
                    Height = 158;
                    Width = 346;
                    lb_Item.Visible = true;
                    lb_Category.Visible = true;
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
                    btn_RemoveItem.Enabled = true;
                    btn_AddItem.Enabled = true;
                    break;
                case 5:
                    Height = 185;
                    Width = 346;
                    lb_Item.Visible = true;
                    lb_Category.Visible = true;
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
                    btn_RemoveItem.Enabled = true;
                    btn_AddItem.Enabled = false;
                    break;
            }
        }

        private void Cb_Category1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cb_Item1.Items.Clear();
            switch (cb_Category1.SelectedIndex)
            {
                case 0:
                    cb_Item1.Items.AddRange(Eggs.ToArray());
                    Main.loadedSave[offsets.chaoSave.HeldItemsStart] = 1;
                    break;
                case 1:
                    cb_Item1.Items.AddRange(Fruit.Keys.ToArray());
                    Main.loadedSave[offsets.chaoSave.HeldItemsStart] = 3;
                    break;
                case 2:
                    cb_Item1.Items.AddRange(Seed.ToArray());
                    Main.loadedSave[offsets.chaoSave.HeldItemsStart] = 7;
                    break;
                case 3:
                    cb_Item1.Items.AddRange(Hat.ToArray());
                    Main.loadedSave[offsets.chaoSave.HeldItemsStart] = 9;
                    break;
            }
            if (loaded) { Main.loadedSave[offsets.chaoSave.HeldItemsStart + 1] = 0; }
            if (cb_Category1.SelectedIndex == 1) { cb_Item1.SelectedIndex = Fruit.Where(x => x.Value == Main.loadedSave[offsets.chaoSave.HeldItemsStart + 1]).First().Value; }
            if (cb_Category1.SelectedIndex == 3)
            {
                cb_Item1.SelectedIndex = (Main.loadedSave[offsets.chaoSave.HeldItemsStart + 1] - 1);
                if (cb_Item1.SelectedItem == null) { cb_Item1.SelectedIndex = 0; }
            }
            if (cb_Category1.SelectedIndex != 1 && cb_Category1.SelectedIndex != 3) { cb_Item1.SelectedIndex = Main.loadedSave[offsets.chaoSave.HeldItemsStart + 1]; }
        }

        private void Cb_Category2_SelectedIndexChanged(object sender, EventArgs e)
        {
            cb_Item2.Items.Clear();
            switch (cb_Category2.SelectedIndex)
            {
                case 0:
                    cb_Item2.Items.AddRange(Eggs.ToArray());
                    Main.loadedSave[offsets.chaoSave.HeldItemsStart + 2] = 1;
                    break;
                case 1:
                    cb_Item2.Items.AddRange(Fruit.Keys.ToArray());
                    Main.loadedSave[offsets.chaoSave.HeldItemsStart + 2] = 3;
                    break;
                case 2:
                    cb_Item2.Items.AddRange(Seed.ToArray());
                    Main.loadedSave[offsets.chaoSave.HeldItemsStart + 2] = 7;
                    break;
                case 3:
                    cb_Item2.Items.AddRange(Hat.ToArray());
                    Main.loadedSave[offsets.chaoSave.HeldItemsStart + 2] = 9;
                    break;
            }
            if (loaded) { Main.loadedSave[offsets.chaoSave.HeldItemsStart + 3] = 0; }
            if (cb_Category2.SelectedIndex == 1) { cb_Item2.SelectedIndex = Fruit.Where(x => x.Value == Main.loadedSave[offsets.chaoSave.HeldItemsStart + 3]).First().Value; }
            if (cb_Category2.SelectedIndex == 3)
            {
                cb_Item2.SelectedIndex = (Main.loadedSave[offsets.chaoSave.HeldItemsStart + 3] - 1);
                if (cb_Item2.SelectedItem == null) { cb_Item2.SelectedIndex = 0; }
            }
            if (cb_Category2.SelectedIndex != 1 && cb_Category2.SelectedIndex != 3) { cb_Item2.SelectedIndex = Main.loadedSave[offsets.chaoSave.HeldItemsStart + 3]; }
        }

        private void Cb_Category3_SelectedIndexChanged(object sender, EventArgs e)
        {
            cb_Item3.Items.Clear();
            switch (cb_Category3.SelectedIndex)
            {
                case 0:
                    cb_Item3.Items.AddRange(Eggs.ToArray());
                    Main.loadedSave[offsets.chaoSave.HeldItemsStart + 4] = 1;
                    break;
                case 1:
                    cb_Item3.Items.AddRange(Fruit.Keys.ToArray());
                    Main.loadedSave[offsets.chaoSave.HeldItemsStart + 4] = 3;
                    break;
                case 2:
                    cb_Item3.Items.AddRange(Seed.ToArray());
                    Main.loadedSave[offsets.chaoSave.HeldItemsStart + 4] = 7;
                    break;
                case 3:
                    cb_Item3.Items.AddRange(Hat.ToArray());
                    Main.loadedSave[offsets.chaoSave.HeldItemsStart + 4] = 9;
                    break;
            }
            if (loaded) { Main.loadedSave[offsets.chaoSave.HeldItemsStart + 5] = 0; }
            if (cb_Category3.SelectedIndex == 1) { cb_Item3.SelectedIndex = Fruit.Where(x => x.Value == Main.loadedSave[offsets.chaoSave.HeldItemsStart + 5]).First().Value; }
            if (cb_Category3.SelectedIndex == 3)
            {
                cb_Item3.SelectedIndex = (Main.loadedSave[offsets.chaoSave.HeldItemsStart + 5] - 1);
                if (cb_Item3.SelectedItem == null) { cb_Item3.SelectedIndex = 0; }
            }
            if (cb_Category3.SelectedIndex != 1 && cb_Category3.SelectedIndex != 3) { cb_Item3.SelectedIndex = Main.loadedSave[offsets.chaoSave.HeldItemsStart + 5]; }
        }

        private void Cb_Category4_SelectedIndexChanged(object sender, EventArgs e)
        {
            cb_Item4.Items.Clear();
            switch (cb_Category4.SelectedIndex)
            {
                case 0:
                    cb_Item4.Items.AddRange(Eggs.ToArray());
                    Main.loadedSave[offsets.chaoSave.HeldItemsStart + 6] = 1;
                    break;
                case 1:
                    cb_Item4.Items.AddRange(Fruit.Keys.ToArray());
                    Main.loadedSave[offsets.chaoSave.HeldItemsStart + 6] = 3;
                    break;
                case 2:
                    cb_Item4.Items.AddRange(Seed.ToArray());
                    Main.loadedSave[offsets.chaoSave.HeldItemsStart + 6] = 7;
                    break;
                case 3:
                    cb_Item4.Items.AddRange(Hat.ToArray());
                    Main.loadedSave[offsets.chaoSave.HeldItemsStart + 6] = 9;
                    break;
            }
            if (loaded) { Main.loadedSave[offsets.chaoSave.HeldItemsStart + 7] = 0; }
            if (cb_Category4.SelectedIndex == 1) { cb_Item4.SelectedIndex = Fruit.Where(x => x.Value == Main.loadedSave[offsets.chaoSave.HeldItemsStart + 7]).First().Value; }
            if (cb_Category4.SelectedIndex == 3)
            {
                cb_Item4.SelectedIndex = (Main.loadedSave[offsets.chaoSave.HeldItemsStart + 7] - 1);
                if (cb_Item4.SelectedItem == null) { cb_Item4.SelectedIndex = 0; }
            }
            if (cb_Category4.SelectedIndex != 1 && cb_Category4.SelectedIndex != 3) { cb_Item4.SelectedIndex = Main.loadedSave[offsets.chaoSave.HeldItemsStart + 7]; }
        }

        private void Cb_Category5_SelectedIndexChanged(object sender, EventArgs e)
        {
            cb_Item5.Items.Clear();
            switch (cb_Category5.SelectedIndex)
            {
                case 0:
                    cb_Item5.Items.AddRange(Eggs.ToArray());
                    Main.loadedSave[offsets.chaoSave.HeldItemsStart + 8] = 1;
                    break;
                case 1:
                    cb_Item5.Items.AddRange(Fruit.Keys.ToArray());
                    Main.loadedSave[offsets.chaoSave.HeldItemsStart + 8] = 3;
                    break;
                case 2:
                    cb_Item5.Items.AddRange(Seed.ToArray());
                    Main.loadedSave[offsets.chaoSave.HeldItemsStart + 8] = 7;
                    break;
                case 3:
                    cb_Item5.Items.AddRange(Hat.ToArray());
                    Main.loadedSave[offsets.chaoSave.HeldItemsStart + 8] = 9;
                    break;
            }
            if (loaded) { Main.loadedSave[offsets.chaoSave.HeldItemsStart + 9] = 0; }
            if (cb_Category5.SelectedIndex == 1) { cb_Item5.SelectedIndex = Fruit.Where(x => x.Value == Main.loadedSave[offsets.chaoSave.HeldItemsStart + 9]).First().Value; }
            if (cb_Category5.SelectedIndex == 3)
            {
                cb_Item5.SelectedIndex = (Main.loadedSave[offsets.chaoSave.HeldItemsStart + 9] - 1);
                if (cb_Item5.SelectedItem == null) { cb_Item5.SelectedIndex = 0; }
            }
            if (cb_Category5.SelectedIndex != 1 && cb_Category5.SelectedIndex != 3) { cb_Item5.SelectedIndex = Main.loadedSave[offsets.chaoSave.HeldItemsStart + 9]; }
        }

        private void Btn_AddItem_Click(object sender, EventArgs e)
        {
            if (itemCount < 5) { itemCount++; }
            if (itemCount == 5) { btn_AddItem.Enabled = false; }
            if (itemCount > 0) { btn_RemoveItem.Enabled = true; }
            SetSize();
            if (Main.isPC) { Main.loadedSave[offsets.chaoSave.HeldCount] = (byte)itemCount; }
            else { Main.loadedSave[offsets.chaoSave.HeldCount + 3] = (byte)itemCount; }
        }

        private void Btn_RemoveItem_Click(object sender, EventArgs e)
        {
            if (itemCount > 0) { itemCount--; }
            if (itemCount == 0) { btn_RemoveItem.Enabled = false; }
            if (itemCount < 5) { btn_AddItem.Enabled = true; }
            SetSize();
            if (Main.isPC) { Main.loadedSave[offsets.chaoSave.HeldCount] = (byte)itemCount; }
            else { Main.loadedSave[offsets.chaoSave.HeldCount + 3] = (byte)itemCount; }
        }

        private void Cb_Item1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_Category1.SelectedIndex == 1) { Main.loadedSave[offsets.chaoSave.HeldItemsStart + 1] = (byte)Fruit.Where(x => x.Key == cb_Item1.SelectedItem.ToString()).First().Value; }
            if (cb_Category1.SelectedIndex == 3) { Main.loadedSave[offsets.chaoSave.HeldItemsStart + 1] = (byte)(cb_Item1.SelectedIndex + 1); }
            if (cb_Category1.SelectedIndex != 1 && cb_Category1.SelectedIndex != 3) { Main.loadedSave[offsets.chaoSave.HeldItemsStart + 1] = (byte)cb_Item1.SelectedIndex; }
        }

        private void Cb_Item2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_Category2.SelectedIndex == 1) { Main.loadedSave[offsets.chaoSave.HeldItemsStart + 3] = (byte)Fruit.Where(x => x.Key == cb_Item2.SelectedItem.ToString()).First().Value; }
            if (cb_Category2.SelectedIndex == 3) { Main.loadedSave[offsets.chaoSave.HeldItemsStart + 3] = (byte)(cb_Item2.SelectedIndex + 1); }
            if (cb_Category2.SelectedIndex != 1 && cb_Category2.SelectedIndex != 3) { Main.loadedSave[offsets.chaoSave.HeldItemsStart + 3] = (byte)cb_Item2.SelectedIndex; }
        }

        private void Cb_Item3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_Category3.SelectedIndex == 1) { Main.loadedSave[offsets.chaoSave.HeldItemsStart + 5] = (byte)Fruit.Where(x => x.Key == cb_Item3.SelectedItem.ToString()).First().Value; }
            if (cb_Category3.SelectedIndex == 3) { Main.loadedSave[offsets.chaoSave.HeldItemsStart + 5] = (byte)(cb_Item3.SelectedIndex + 1); }
            if (cb_Category3.SelectedIndex != 1 && cb_Category3.SelectedIndex != 3) { Main.loadedSave[offsets.chaoSave.HeldItemsStart + 5] = (byte)cb_Item3.SelectedIndex; }
        }

        private void Cb_Item4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_Category4.SelectedIndex == 1) { Main.loadedSave[offsets.chaoSave.HeldItemsStart + 7] = (byte)Fruit.Where(x => x.Key == cb_Item4.SelectedItem.ToString()).First().Value; }
            if (cb_Category4.SelectedIndex == 3) { Main.loadedSave[offsets.chaoSave.HeldItemsStart + 7] = (byte)(cb_Item4.SelectedIndex + 1); }
            if (cb_Category4.SelectedIndex != 1 && cb_Category4.SelectedIndex != 3) { Main.loadedSave[offsets.chaoSave.HeldItemsStart + 7] = (byte)cb_Item4.SelectedIndex; }
        }

        private void Cb_Item5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_Category5.SelectedIndex == 1) { Main.loadedSave[offsets.chaoSave.HeldItemsStart + 9] = (byte)Fruit.Where(x => x.Key == cb_Item5.SelectedItem.ToString()).First().Value; }
            if (cb_Category5.SelectedIndex == 3) { Main.loadedSave[offsets.chaoSave.HeldItemsStart + 9] = (byte)(cb_Item5.SelectedIndex + 1); }
            if (cb_Category5.SelectedIndex != 1 && cb_Category5.SelectedIndex != 3) { Main.loadedSave[offsets.chaoSave.HeldItemsStart + 9] = (byte)cb_Item5.SelectedIndex; }
        }
    }
}
