using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using iriesmod.Common.List;
using iriesmod.Common.Players;
using iriesmod.Common.ID;
using iriesmod.Common.Utils;

namespace iriesmod.Common.GlobalProjectiles
{
    public class GlobalProj : GlobalProjectile
    {

        public override void SetDefaults(Projectile projectile)
        {
            int penetration = 0;

            if (irieList.friendlyBees.Contains(projectile.type))
            {
                iriesplayer modPlayer = Main.player[projectile.owner].GetModPlayer<iriesplayer>();
                penetration += irieUtils.BeePenetrate(modPlayer.BeeBackpack);
            }

            projectile.penetrate += penetration;
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
