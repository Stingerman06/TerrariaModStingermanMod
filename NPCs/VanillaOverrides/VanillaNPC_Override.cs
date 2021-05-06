using System;                                               //TODO: Check off abilities gained for each boss death.
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using StingermanMod.Items.Misc;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace StingermanMod.NPCs.VanillaOverrides
{
    public class VanillaNPC_Override : GlobalNPC
    {
        public override bool InstancePerEntity => true;

        public bool brokenHilt;
        public bool brokenRod;
        public bool brokenTip;

        public override void ResetEffects(NPC npc)
        {
            brokenHilt = false;
            brokenRod = false;
            brokenTip = false;
        }
        public override bool CheckDead(NPC npc)
        {
            int bloodZombieDeadCount = 0;
            int dripplerDeadCount = 0;

            //Blood Moon Checks
            if (!Main.dayTime)
            {
                if (Main.bloodMoon)
                {
                    if (!StingermanMod.bloodMoonSurvivalist)
                    {
                        if (npc.type == NPCID.BloodZombie || npc.type == NPCID.Drippler)
                        {
                            if (bloodZombieDeadCount == 0 && dripplerDeadCount == 0)
                            {
                                Main.NewText("'Can you defeat a total of 20 Blood Zombies and 10 Dripplers?'");
                            }
                        }
                        if (npc.type == NPCID.BloodZombie)
                        {
                            bloodZombieDeadCount++;
                            if (bloodZombieDeadCount == 10)
                            {
                                Main.NewText("...10 zombies killed, 10 left...");
                            }
                            if (bloodZombieDeadCount >= 20 && !StingermanMod.bloodMoonEnemyZombieDeath)
                            {
                                Main.NewText("You brutalized these creatures quite well enough...");
                                StingermanMod.bloodMoonEnemyZombieDeath = true;
                            }
                        }
                        if (npc.type == NPCID.Drippler)
                        {
                            dripplerDeadCount++;
                            if (bloodZombieDeadCount == 5)
                            {
                                Main.NewText("...5 more dripplers to go...");
                            }
                            if (dripplerDeadCount >= 10 && !StingermanMod.bloodMoonEnemyDrippler)
                            {
                                Main.NewText("Dripplers are no more...");
                                StingermanMod.bloodMoonEnemyDrippler = true;
                            }
                        }
                        if (!StingermanMod.bloodMoonSurvivalist && StingermanMod.bloodMoonEnemyZombieDeath && StingermanMod.bloodMoonEnemyDrippler && Main.dayTime)
                        {
                            Main.NewText("'Bloody creatures stir in the night. Having the power to cut through enemies...\nThose who are made of flesh will feel my fury.'");
                            StingermanMod.bloodMoonSurvivalist = true;
                        }
                    }
                }
            }
            if (Main.dayTime && !StingermanMod.bloodMoonSurvivalist && (dripplerDeadCount != 0 | bloodZombieDeadCount != 0))
            {
                StingermanMod.bloodMoonEnemyZombieDeath = false;
                StingermanMod.bloodMoonEnemyDrippler = false;
                dripplerDeadCount = 0;
                bloodZombieDeadCount = 0;
            }
            //Blood Moon Checks

            //Slime King Kill checks
            if (npc.type == NPCID.KingSlime && !NPC.downedSlimeKing && !Main.hardMode)
            {
                Main.NewText("'Essence of slime. I can use this to bounce off walls.'", 255, 128, 0); //Projectiles bounce                                                                                                                                      DONE
            }
            else if (npc.type == NPCID.KingSlime && !NPC.downedSlimeKing && Main.hardMode)
            {
                Main.NewText("'Hmm... Slime is bouncy, but I cannot use this feature.'", 255, 128, 0); //Projectiles inflict on fire or burning alive debuff. Dunno yet...                                                                                      DONE
            }
            //Slime King kill checks

            //Eye of Cthulhu Kill checks
            if (npc.type == NPCID.EyeofCthulhu && !NPC.downedBoss1)
            {
                Main.NewText("'The all seeing eye, which now belongs to me.'", 255, 128, 0); //Adds homing effect to weapon.                                                                                                                                    DONE
            }
            //Eye of Cthulhu Kill checks

            //Eater of Worlds Kill checks
            if (npc.boss && Array.IndexOf(new int[] { NPCID.EaterofWorldsBody, NPCID.EaterofWorldsHead, NPCID.EaterofWorldsTail }, npc.type) > -1 && !StingermanMod.eaterOfWorldsFirstKill)
            {
                StingermanMod.eaterOfWorldsFirstKill = true;
                Main.NewText("'Corruption... Evil... I will assist you even better.'", 255, 128, 0); //Slow Enemies on hit.                                                                                                                                     DONE
            }
            //Eater of Worlds Kill checks

            //Brain of Cthulhu Kill checks
            if (npc.type == NPCID.BrainofCthulhu && !StingermanMod.brainOfCthulhuFirstKill)
            {
                StingermanMod.brainOfCthulhuFirstKill = true;
                Main.NewText("'What a confusing creature...\nThe brain needs an army, yet all you needed was me.'"); //Add confusion on enemy hits                                                                                                              DONE
            }
            //Brain of Cthulhu Kill checks

            //Skeletron Kill checks
            if (npc.type == NPCID.SkeletronHead && !NPC.downedBoss3)
            {
                Main.NewText("'No need to tire yourself out. I shall make it easier for you.'", 255, 128, 0); //Enables autoswing.                                                                                                                              DONE
            }
            //Skeletron Kill checks

            //Queen Bee Kill checks
            if (npc.type == NPCID.QueenBee && !NPC.downedQueenBee)
            {
                Main.NewText("'I wonder if I can aid you in other ways...\nI have something in mind, but it's all I can do for now.'", 255, 128, 0); //Honey buff on enemy hit.                                                                                 DONE
            }
            //Queen Bee Kill checks

            //Wall of Flesh Kill checks
            if (npc.type == NPCID.WallofFlesh && !Main.hardMode)
            {
                Main.NewText("'Hahaha! Of course I forgot all about collision.'", 255, 128, 0); //Ignores tile collision upon killing the Wall of Flesh.                                                                                                        DONE
            }
            //Wall of Flesh Kill checks

            //Twins Kill checks
            if ((npc.type == NPCID.Retinazer || npc.type == NPCID.Spazmatism) && !StingermanMod.mechTwinsFirstKill)
            {
                StingermanMod.mechTwinsFirstKill = true;
                Main.NewText("'Have you ever wondered what it's like to see double?\nI will require much more power, however...'", 255, 128, 0); //Shoot a 2nd/3rd projectile.                                                                                  DONE
            }
            //Twin Kill checks

            //Destroyer Kill checks
            if (npc.type == NPCID.TheDestroyer && !StingermanMod.mechDestroyerFirstKill)
            {
                StingermanMod.mechDestroyerFirstKill = true;
                Main.NewText("'Lasers are quite powerful, but alas...\nI cannot in this current modded state.'", 255, 128, 0); //Add laser firing to projectile.                                                                                                INCOMPLETE
            }
            //Destroyer Kill checks

            //Skeletron Prime Kill checks
            if (npc.type == NPCID.SkeletronPrime && !StingermanMod.mechSkeletronPrimeFirstKill)
            {
                StingermanMod.mechSkeletronPrimeFirstKill = true;
                Main.NewText("'Rough fight, though I learned much from this.'", 255, 128, 0); //Strengthen homing effect range. Can target through walls.                                                                                                       INCOMPLETE
            }
            //Skeletron Prime Kill checks

            //Plantera Kill checks
            if (npc.type == NPCID.Plantera && !NPC.downedPlantBoss)
            {
                Main.NewText("'This plant... It seamlessly heals itself when enraged.\nI can only step up my game a little at a time.'", 255, 128, 0); //Heal on hitting NPC                                                                                    DONE
            }
            //Plantera Kill checks

            //Golem Kill checks
            if (npc.type == NPCID.Golem && !NPC.downedGolemBoss)
            {
                Main.NewText("'A destroyed head breaks into additional forms? I can only shrapnel myself.'", 255, 128, 0); //Add shrapnel effect to weapon projectiles.                                                                                         INCOMPLETE
            }
            //Golem Kill checks

            //Betsy Kill checks
            if (npc.type == NPCID.DD2Betsy && !StingermanMod.DD2BetsyFirstKill)
            {
                StingermanMod.DD2BetsyFirstKill = true;
                Main.NewText("'You think an army is capable of harming us?\nAll the more reason to regain my powers...'", 255, 128, 0); //Buff damage during DD2 event by 20%                                                                                   INCOMPLETE
            }
            //Betsy Kill checks

            //Duke Fishron Kill checks
            if (npc.type == NPCID.DukeFishron && !NPC.downedFishron)
            {
                Main.NewText("'Elegant fish, effortless in air and water alike...'", 255, 128, 0); //Projectiles ignore water collision.                                                                                                                        DONE
            }
            //Duke Fishron Kill checks

            //Lunatic Cultist Kill checks
            if (npc.type == NPCID.CultistBoss && !StingermanMod.ancientCultistFirstKill)
            {
                StingermanMod.ancientCultistFirstKill = true;
                Main.NewText("'You may assume that this is detremental to you. However,\nthis new energy can actually help reduce my power requirements!'", 255, 128, 0); //Lower mana usage by a flat %.                                                       DONE
            }
            //Lunatic Cultist Kill Checks

            //Pillar Kill checks
            if (npc.type == NPCID.LunarTowerNebula && !StingermanMod.lunarPillarNebulaFirstKill)
            {
                StingermanMod.lunarPillarNebulaFirstKill = true;
                Main.NewText("'This is extremely nice. This one in particular fills me heavily.'", 255, 128, 0); //Lower base mana used by 4                                                                                                                    INCOMPLETE
            }
            if (npc.type == NPCID.LunarTowerSolar && !StingermanMod.lunarPillarSolarFirstKill)
            {
                StingermanMod.lunarPillarSolarFirstKill = true;
                Main.NewText("'Warriors, with that sharpest of blades. I shall not disappoint...'", 255, 128, 0); //Sharply increase damage(+5 base attack) after striking through flesh for 3 seconds. Can only happen once per projectile.                    INCOMPLETE
            }
            if (npc.type == NPCID.LunarTowerStardust && !StingermanMod.lunarPillarStardustFirstKill)
            {
                StingermanMod.lunarPillarStardustFirstKill = true;
                if (!NPC.downedGolemBoss)
                {
                    Main.NewText("'This is an unseen situation, far beyond what we both know.\nGo forth and find the one who\ndetatches themselves to protect their treasures...'", 255, 0, 0); //Does nothing. Except maybe change the rod graphic? idfk       INCOMPLETE
                }
                else
                {
                    Main.NewText("'Hone the horde, become the horde......'", 255, 128, 0); //Shrapnel no longer flies around aimlesssly, but instead lingers. After 1 second has passed, home in on the nearest enemy. Only after Golem.                        INCOMPLETE
                }
            }
            if (npc.type == NPCID.LunarTowerVortex && !StingermanMod.lunarPillarVortexFirstKill)
            {
                StingermanMod.lunarPillarVortexFirstKill = true;
                Main.NewText("'Distorting one's magnetic field... I could use this most definitely...'", 255, 128, 0); //Add distort gravity on hit. 5% chance to activate for 5 seconds.                                                                       KINDA DONE
            }
            //Piilar Kill checks

            //Moon Lord Kill checks
            if ((npc.type == NPCID.MoonLordCore && !NPC.downedMoonlord && StingermanMod.mechTwinsFirstKill) || ((npc.type == NPCID.Retinazer) || npc.type == NPCID.Spazmatism) && NPC.downedMoonlord && !StingermanMod.mechTwinsFirstKill)
            {
                Main.NewText("'3 eyes? I will match this, and as an added bonus,\nI won't require much more power from you.'", 255, 128, 0); //Add a third projectile to shoot.                                                                                 DONE
            }
            //Moon Lord Kill checks

            return true;
        }
        public override void SetupShop(int type, Chest shop, ref int nextSlot)
        {
            if (type == NPCID.Merchant && !Main.dayTime && Main.expertMode && (Main.moonPhase == 4 || Main.moonPhase == 0))
            {
                shop.item[nextSlot].SetDefaults(ModContent.ItemType<BrokenHilt>());
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ModContent.ItemType<BrokenRod>());
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ModContent.ItemType<BrokenTip>());
                nextSlot++;
            }
        }
        public override void GetChat(NPC npc, ref string chat)
        {
            if (npc.type == NPCID.Merchant && !Main.dayTime && Main.expertMode && (Main.moonPhase == 4 || Main.moonPhase == 0))
            {
                chat = "I found a few odd items you might\nwant to take a look at. I get an eerie chill\njust holding them, but it'll cost ya.";
                return;
            }
        }
        public override void NPCLoot(NPC npc)
        {
            if (npc.type == NPCID.Krampus)
            {
                if (Main.rand.Next(9) == 0)
                {
                    //Format for Vanilla item drops
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.SnowGlobe);


                    //Format for modded item drops
                    //Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("WaterKnife"));

                }
            }
        }
    }
}