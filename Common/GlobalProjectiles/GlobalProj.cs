using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using iriesmod.Common.List;
using iriesmod.Common.players;
using iriesmod.Common.ID;
using iriesmod.Common.Utils;
using iriesmod.Content.Projectiles;

namespace iriesmod.Common.GlobalProjectiles
{
    public class GlobalProj : GlobalProjectile
    {
        public override void SetDefaults(Projectile projectile)
        {
            if (projectile.owner == Main.myPlayer)
            {
                int penetration = 0;
                Player player = Main.player[projectile.owner];

                if (irieList.friendlyBees.Contains(projectile.type))
                {
                    iriesplayer modplayer = player.Getiriesplayer();
                    penetration += irieUtils.BeePenetrate(modplayer.BeeBackpack);
                }

                projectile.penetrate += penetration;
            }
        }

        public override void ModifyHitNPC(Projectile projectile, NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
            Player player = Main.player[projectile.owner];


            if (irieList.friendlyBees.Contains(projectile.type) || irieList.friendlyBeesProj.Contains(projectile.type))
            {
                damage = irieUtils.BeeDamage(player, damage);
            }
        }
    }
}
