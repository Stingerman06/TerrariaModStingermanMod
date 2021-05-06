using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace StingermanMod.Items.Special
{
    public class EyeofCthulhuToggle : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Toggles Eye of Cthulhu's Death Flag.");
        }
        public override void SetDefaults()
        {
            Main.PlaySound(SoundID.Item14, item.position);
            item.width = 32;
            item.height = 32;
            item.maxStack = 1;
            item.useTime = 10;
            item.useAnimation = 10;
            item.useTurn = false;
            item.useStyle = ItemUseStyleID.EatingUsing;
            item.consumable = false;
            item.value = Item.buyPrice(0, 0, 0, 0);
            item.rare = ItemRarityID.LightRed;
        }
        public override bool UseItem(Player player)
        {
            if (!NPC.downedBoss1)
            {
                NPC.downedBoss1 = true;
                Main.NewText("Eye of Cthulhu registered killed.");
                return true;
            }
            else if (NPC.downedBoss1 == true)
            {
                NPC.downedBoss1 = false;
                Main.NewText("Eye of Cthulhu registered not at all dead.");
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
