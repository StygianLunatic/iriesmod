using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using iriesmod.Common.ID;
using iriesmod.Common.List;
using iriesmod.Common.Utils;
using iriesmod.Content.Projectiles.Weapons.Bees;

namespace iriesmod.Common.players
{
    public class iriesplayer : ModPlayer
    {

        // Bee backpack
        public short BeeBackpack;
        public float beeDamage;
        public Item HiveSetHurtBonus;
        public Item QueenBeeScroll;
        public Item WaspNecklace;
        public Item SweetheartKnuckles;
        public Item beeCloak;
        public Item QueenStingerNecklace;
        public Item RoyalCloak;
        public Item BurningRoyalCloak;

        public override void ResetEffects()
        {
            // Bee backpack updrades
            BeeBackpack = 0;
            beeDamage = 0f;
            HiveSetHurtBonus = null;
            QueenBeeScroll = null;
            WaspNecklace = null;
            SweetheartKnuckles = null;
            beeCloak = null;
            QueenStingerNecklace = null;
            RoyalCloak = null;
            BurningRoyalCloak = null;
        }

        public override void UpdateLifeRegen()
        {
        }

        public override void OnHitNPCWithProj(Projectile proj, NPC target, int damage, float knockback, bool crit)
        {
            if (irieList.friendlyBees.Contains(proj.type) || irieList.friendlyBeesProj.Contains(proj.type))
            {
                int[] debuffs = irieUtils.BeeDebuff(Player);

                if (debuffs[0] > 0)
                {
                    foreach(int debuff in debuffs.Skip(1))
                    {
                        target.AddBuff(debuff, 180);
                    }
                }
            }
        }

        public override void OnHitPvpWithProj(Projectile proj, Player target, int damage, bool crit)
        {
            if (irieList.friendlyBees.Contains(proj.type) || irieList.friendlyBeesProj.Contains(proj.type))
            {
                int[] debuffs = irieUtils.BeeDebuff(Player);

                if (debuffs[0] > 0)
                {
                    foreach (int debuff in debuffs.Skip(1))
                    {
                        target.AddBuff(debuff, 180);
                    }
                }
            }
        }
        public override void PostHurt(bool pvp, bool quiet, double damage, int hitDirection, bool crit)
        {
            if (Player.whoAmI == Main.myPlayer)
            {
                if (HiveSetHurtBonus != null)
                {
                    irieUtils.BeeSpawn(Player, 6, 8, HiveSetHurtBonus);
                }
                if (QueenBeeScroll != null)
                {
                    irieUtils.BeeSpawn(Player, 42, 52, QueenBeeScroll);
                    Player.AddBuff(BuffID.Honey, 720);
                }
                if (WaspNecklace != null)
                {
                    irieUtils.BeeSpawn(Player, 6, 8, WaspNecklace);
                    Player.AddBuff(BuffID.Honey, 300);
                }
                if (SweetheartKnuckles != null)
                {
                    irieUtils.BeeSpawn(Player, 26, 38, SweetheartKnuckles);
                    Player.AddBuff(BuffID.Honey, 720);
                }
                if (beeCloak != null)
                {
                    irieUtils.BeeSpawn(Player, 10, 12, beeCloak);
                }
                if (QueenStingerNecklace != null)
                {
                    irieUtils.BeeSpawn(Player, 8, 14, QueenStingerNecklace);
                    Player.AddBuff(BuffID.Honey, 240);
                }
                if (RoyalCloak != null)
                {
                    irieUtils.BeeSpawn(Player, 14, 18, RoyalCloak);
                    Player.AddBuff(BuffID.Honey, 360);
                }
                if (BurningRoyalCloak != null)
                {
                    irieUtils.BeeSpawn(Player, 32, 32, BurningRoyalCloak, ModContent.ProjectileType<beeLava>());
                }
            }
        }
    }
}
