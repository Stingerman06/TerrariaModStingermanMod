using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace StingermanMod.Items.Misc
{
    public class BrokenRod : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Expert\nA rod that appears to be withered beyond recognition.");
        }
        public override void SetDefaults()
        {
            item.maxStack = 1;
            item.width = 32;
            item.height = 32;
            item.rare = ItemRarityID.Blue;
            item.value = Item.buyPrice(0, 1, 0, 0);
        }
    }
}
