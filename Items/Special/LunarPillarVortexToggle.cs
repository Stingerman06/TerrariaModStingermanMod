﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace StingermanMod.Items.Special
{
    public class LunarPillarVortexToggle : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Toggles Vortex Pillar's First Destruction Flag.");
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
            if (!StingermanMod.lunarPillarVortexFirstKill)
            {
                StingermanMod.lunarPillarVortexFirstKill = true;
                Main.NewText("Vortex Pillar registered destroyed.");
                return true;
            }
            else if (StingermanMod.lunarPillarVortexFirstKill == true)
            {
                StingermanMod.lunarPillarVortexFirstKill = false;
                Main.NewText("Vortex Pillar registered not destroyed at all.");
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
