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

namespace iriesmod.Common.Players
{
    public class iriesplayer : ModPlayer
    {

        // Bee backpack
        public short BeeBackpack;
        public float beeDamage;
        public bool HiveSetHurtBonus;
        public bool QueenBeeScroll;
        public bool WaspNecklace;
        public bool SweetheartKnuckles;
        public bool beeCloak;
        public bool QueenStingerNecklace;
        public bool RoyalCloak;
        public bool BurningRoyalCloak;

        public override void ResetEffects()
        {
            // Bee backpack updrades
            BeeBackpack = 0;
            beeDamage = 0f;
            HiveSetHurtBonus = false;
            QueenBeeScroll = false;
            WaspNecklace = false;
            SweetheartKnuckles = false;
            beeCloak = false;
            QueenStingerNecklace = false;
            RoyalCloak = false;
            BurningRoyalCloak = false;
        }

        public override void UpdateLifeRegen()
        {
        }

        public override void OnHitNPCWithProj(Projectile proj, NPC target, int damage, float knockback, bool crit)
        {
            if (irieList.friendlyBees.Contains(proj.type) || irieList.friendlyBeesProj.Contains(proj.type))
            {
                int[] debuffs = irieUtils.BeeDebuff(player);

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
                int[] debuffs = irieUtils.BeeDebuff(player);

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
            if (player.whoAmI == Main.myPlayer)
            {
                if (HiveSetHurtBonus)
                {
                    irieUtils.BeeSpawn(player, 6, 8);
                }
                if (QueenBeeScroll)
                {
                    irieUtils.BeeSpawn(player, 42, 52);
                    player.AddBuff(BuffID.Honey, 720);
                }
                if (WaspNecklace)
                {
                    irieUtils.BeeSpawn(player, 6, 8);
                    player.AddBuff(BuffID.Honey, 300);
                }
                if (SweetheartKnuckles)
                {
                    irieUtils.BeeSpawn(player, 26, 38);
                    player.AddBuff(BuffID.Honey, 720);
                }
                if (beeCloak)
                {
                    irieUtils.BeeSpawn(player, 10, 12);
                }
                if (QueenStingerNecklace)
                {
                    irieUtils.BeeSpawn(player, 8, 14);
                    player.AddBuff(BuffID.Honey, 240);
                }
                if (RoyalCloak)
                {
                    irieUtils.BeeSpawn(player, 14, 18);
                    player.AddBuff(BuffID.Honey, 360);
                }
                if (BurningRoyalCloak)
                {
                    irieUtils.BeeSpawn(player, 32, 32, ModContent.ProjectileType<beeLava>());
                }
            }
        }
    }
}
