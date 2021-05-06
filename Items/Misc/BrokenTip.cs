using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace StingermanMod.Items.Misc
{
    public class BrokenTip : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Expert\nThe tip of what looks to be of an ancient staff.");
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