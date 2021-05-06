using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace StingermanMod.Items.Special
{
    public class FrostLegionToggle : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Toggles Frost Legion Invasion Completion Flag.");
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
            if (!NPC.downedFrost)
            {
                NPC.downedFrost = true;
                Main.NewText("Frost Legion registered completed.");
                return true;
            }
            else if (NPC.downedFrost == true)
            {
                NPC.downedFrost = false;
                Main.NewText("Frost Legion registered not completed at all.");
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
