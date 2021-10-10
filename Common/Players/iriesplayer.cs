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

namespace iriesmod.Common.Players
{
    public class iriesplayer : ModPlayer
    {

        // Bee backpack
        public short BeeBackpack;
        public float beeDamage;
        public bool HurtBee;


        public override void ResetEffects()
        {
            // Bee backpack updrades
            BeeBackpack = 0;
            beeDamage = 0f;
            HurtBee = false;
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
            if (HurtBee)
            {
                irieUtils.BeeSpawn(player.position, player.strongBees);
            }
        }
    }
}
