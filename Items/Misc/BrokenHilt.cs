using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace StingermanMod.Items.Misc
{
    public class BrokenHilt : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Expert\nA hilt that appears murky.\nThe merchant didn't appear to care much for it.");
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
