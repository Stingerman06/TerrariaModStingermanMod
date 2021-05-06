using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using StingermanMod.Items;
using Terraria.Utilities;
using Terraria.Localization;

namespace StingermanMod
{
	public class StingermanMod : Mod
	{
        public static bool ancientCultistFirstKill;             //Ancient Cultist
        public static bool bloodMoonEnemyDrippler;              //Drippler
        public static bool bloodMoonEnemyZombieDeath;           //Blood Moon Zombie
        public static bool bloodMoonSurvivalist;                //Must Survive Blood Moon
        public static bool brainOfCthulhuFirstKill;             //Brain of Cthulhu
        public static bool DD2BetsyFirstKill;                   //Dungeon Defenders 2's Betsy
        public static bool eaterOfWorldsFirstKill;              //Eater of Worlds
        public static bool lunarPillarNebulaFirstKill;          //Lunar Pillar Nebula
        public static bool lunarPillarSolarFirstKill;           //Lunar Pillar Solar
        public static bool lunarPillarStardustFirstKill;        //Lunar Pillar Stardust
        public static bool lunarPillarVortexFirstKill;          //Lunar Pillar Vortex
        public static bool mechDestroyerFirstKill;              //Mechanical Destroyer
        public static bool mechSkeletronPrimeFirstKill;         //Mechanical Skeletron Prime
        public static bool mechTwinsFirstKill;                  //Mechanical Twins
        public static bool vanillaAlllnvasions;                  //All invasions done(including the moon events)
        public static bool vanillaOptionalBosses;               //Optional bosses. Not required to beat the game at all.
        public static bool vanillaPillarsCompleted;             //Completion of all lunar events(including Lunatic Cultist.
        public static bool vanillaRequiredBosses;               //Required bosses to beat the game
        public void Initialize()
        {
            ancientCultistFirstKill = false;
            bloodMoonEnemyDrippler = false;
            bloodMoonEnemyZombieDeath = false;
            bloodMoonSurvivalist = false;
            brainOfCthulhuFirstKill = false;
            DD2BetsyFirstKill = false;
            eaterOfWorldsFirstKill = false;
            lunarPillarNebulaFirstKill = false;
            lunarPillarSolarFirstKill = false;
            lunarPillarStardustFirstKill = false;
            lunarPillarVortexFirstKill = false;
            mechDestroyerFirstKill = false;
            mechSkeletronPrimeFirstKill = false;
            mechTwinsFirstKill = false;
            vanillaAlllnvasions = false;
            vanillaOptionalBosses = false;
            vanillaPillarsCompleted = false;
            vanillaRequiredBosses = false;
        }
        public void EventSet()
        {
            if (bloodMoonSurvivalist && DD2BetsyFirstKill && NPC.downedChristmasIceQueen && NPC.downedHalloweenKing && NPC.downedFrost && NPC.downedPirates && NPC.downedGoblins)
            {
                vanillaAlllnvasions = true;
            }
            if (NPC.downedSlimeKing && NPC.downedBoss1 && (NPC.downedBoss2 || (brainOfCthulhuFirstKill && eaterOfWorldsFirstKill)) && NPC.downedQueenBee && NPC.downedFishron)
            {
                vanillaOptionalBosses = true;
            }
            if (lunarPillarNebulaFirstKill && lunarPillarSolarFirstKill && lunarPillarStardustFirstKill && lunarPillarVortexFirstKill)
            {
                vanillaPillarsCompleted = true;
            }
            if (NPC.downedBoss3 && Main.hardMode && mechDestroyerFirstKill && mechSkeletronPrimeFirstKill && mechTwinsFirstKill && NPC.downedPlantBoss && NPC.downedGolemBoss && ancientCultistFirstKill && NPC.downedMoonlord)
            {
                vanillaRequiredBosses = true;
            }
        }
        public override void AddRecipeGroups()
        {
            RecipeGroup group = new RecipeGroup(() => "Any Copper Bar", new int[]
            {
                ItemID.CopperBar,
                ItemID.TinBar
            });
            RecipeGroup.RegisterGroup("Any Copper Bar", group);

            group = new RecipeGroup(() => "Any Silver Bar", new int[]
            {
                ItemID.SilverBar,
                ItemID.TungstenBar
            });
            RecipeGroup.RegisterGroup("Any Silver Bar", group);

            group = new RecipeGroup(() => "Any Gold Bar", new int[]
            {
                ItemID.GoldBar,
                ItemID.PlatinumBar
            });
            RecipeGroup.RegisterGroup("Any Gold Bar", group);

            group = new RecipeGroup(() => "Any Evil Bag", new int[]
            {
                ItemID.EaterOfWorldsBossBag,
                ItemID.BrainOfCthulhuBossBag
            });
            RecipeGroup.RegisterGroup("Any Evil Bag", group);

            group = new RecipeGroup(() => "T1 Broken Sawblade Staff or T0 Slimy Sawblade Staff", new int[]
            {
                ItemType("SawbladeStaffGrayI"),
                ItemType("SawbladeStaffWhite")
            });
            RecipeGroup.RegisterGroup("WhiteTierI", group);

            group = new RecipeGroup(() => "Any Blood Moon Banner", new int[]
            {
                ItemID.DripplerBanner,
                ItemID.BloodZombieBanner
            });
            RecipeGroup.RegisterGroup("Any Blood Moon Banner", group);

            group = new RecipeGroup(() => "Any Goblin Banner", new int[]
            {
                ItemID.GoblinArcherBanner,
                ItemID.GoblinPeonBanner,
                ItemID.GoblinScoutBanner,
                ItemID.GoblinSorcererBanner,
                ItemID.GoblinSummonerBanner,
                ItemID.GoblinThiefBanner,
                ItemID.GoblinWarriorBanner
            });
            RecipeGroup.RegisterGroup("Any Goblin Banner", group);

            group = new RecipeGroup(() => "Any Old One's Army Banner", new int[]    //OOA
            {
                ItemID.DD2DrakinBanner,
                ItemID.DD2GoblinBanner,
                ItemID.DD2GoblinBomberBanner,
                ItemID.DD2JavelinThrowerBanner,
                ItemID.DD2KoboldBanner,
                ItemID.DD2KoboldFlyerBanner,
                ItemID.DD2SkeletonBanner,
                ItemID.DD2WitherBeastBanner,
                ItemID.DD2WyvernBanner
            });
            RecipeGroup.RegisterGroup("Any Old One's Army Banner", group);

            group = new RecipeGroup(() => "Any Underworld Banner", new int[]    //UNDERWORLD
            {
                ItemID.BoneSerpentBanner,
                ItemID.DemonBanner,
                ItemID.FireImpBanner,
                ItemID.HellbatBanner,
                ItemID.LavaBatBanner,
                ItemID.RedDevilBanner
            });
            RecipeGroup.RegisterGroup("Any Underworld Banner", group);

            group = new RecipeGroup(() => "Any Pirate Banner", new int[]    //PIRATE
            {
                ItemID.ParrotBanner,
                ItemID.PirateBanner,
                ItemID.PirateCaptainBanner,
                ItemID.PirateCorsairBanner,
                ItemID.PirateCrossbowerBanner,
                ItemID.PirateDeadeyeBanner
            });
            RecipeGroup.RegisterGroup("Any Pirate Banner", group);

            group = new RecipeGroup(() => "Any Solar Eclipse Banner", new int[]    //SOLAR ECLIPSE
            {
                ItemID.ButcherBanner,
                ItemID.CreatureFromTheDeepBanner,
                ItemID.DeadlySphereBanner,
                ItemID.DrManFlyBanner,
                ItemID.EyezorBanner,
                ItemID.FrankensteinBanner,
                ItemID.FritzBanner,
                ItemID.MothronBanner,
                ItemID.NailheadBanner,
                ItemID.PsychoBanner,
                ItemID.ReaperBanner,
                ItemID.SwampThingBanner,
                ItemID.ThePossessedBanner,
                ItemID.VampireBanner
            });
            RecipeGroup.RegisterGroup("Any Solar Eclipse Banner", group);

            group = new RecipeGroup(() => "Any Pumpkin Moon Banner", new int[]    //PUMPKIN MOON
            {
                ItemID.HeadlessHorsemanBanner,
                ItemID.HellhoundBanner,
                ItemID.PoltergeistBanner,
                ItemID.ScarecrowBanner,
                ItemID.SplinterlingBanner
            });
            RecipeGroup.RegisterGroup("Any Pumpkin Moon Banner", group);

            group = new RecipeGroup(() => "Any Frost Moon Banner", new int[]    //FROST MOON
            {
                ItemID.ElfArcherBanner,
                ItemID.ElfCopterBanner,
                ItemID.FlockoBanner,
                ItemID.GingerbreadManBanner,
                ItemID.KrampusBanner,
                ItemID.NutcrackerBanner,
                ItemID.PresentMimicBanner,
                ItemID.YetiBanner,
                ItemID.ZombieElfBanner
            });
            RecipeGroup.RegisterGroup("Any Frost Moon Banner", group);

            group = new RecipeGroup(() => "Any Martian Banner", new int[]    //MARTIAN
            {
                ItemID.MartianBrainscramblerBanner,
                ItemID.MartianDroneBanner,
                ItemID.MartianEngineerBanner,
                ItemID.MartianGigazapperBanner,
                ItemID.MartianGreyGruntBanner,
                ItemID.MartianOfficerBanner,
                ItemID.MartianRaygunnerBanner,
                ItemID.MartianScutlixGunnerBanner,
                ItemID.MartianTeslaTurretBanner,
                ItemID.MartianWalkerBanner,
                ItemID.ScutlixBanner
            });
            RecipeGroup.RegisterGroup("Any Martian Banner", group);

            group = new RecipeGroup(() => "Any Nebula Banner", new int[]    //NEBULA PILLAR
            {
                ItemID.NebulaBeastBanner,
                ItemID.NebulaBrainBanner,
                ItemID.NebulaHeadcrabBanner,
                ItemID.NebulaSoldierBanner
            });
            RecipeGroup.RegisterGroup("Any Nebula Banner", group);

            group = new RecipeGroup(() => "Any Solar Banner", new int[]    //SOLAR PILLAR
            {
                ItemID.SolarCoriteBanner,
                ItemID.SolarCrawltipedeBanner,
                ItemID.SolarDrakomireBanner,
                ItemID.SolarDrakomireRiderBanner,
                ItemID.SolarSolenianBanner,
                ItemID.SolarSrollerBanner
            });
            RecipeGroup.RegisterGroup("Any Solar Banner", group);

            group = new RecipeGroup(() => "Any Stardust Banner", new int[]    //STARDUST PILLAR
            {
                ItemID.StardustJellyfishBanner,
                ItemID.StardustLargeCellBanner,
                ItemID.StardustSmallCellBanner,
                ItemID.StardustSoldierBanner,
                ItemID.StardustSpiderBanner,
                ItemID.StardustWormBanner
            });
            RecipeGroup.RegisterGroup("Any Stardust Banner", group);

            group = new RecipeGroup(() => "Any Vortex Banner", new int[]    //VORTEX PILLAR
            {
                ItemID.VortexHornetBanner,
                ItemID.VortexHornetQueenBanner,
                ItemID.VortexLarvaBanner,
                ItemID.VortexRiflemanBanner,
                ItemID.VortexSoldierBanner
            });
            RecipeGroup.RegisterGroup("Any Vortex Banner", group);
        }
    }
}