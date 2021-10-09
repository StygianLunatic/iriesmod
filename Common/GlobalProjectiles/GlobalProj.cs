using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using iriesmod.Common.List;
using iriesmod.Common.Players;
using iriesmod.Common.ID;

namespace iriesmod.Common.GlobalProjectiles
{
    public class GlobalProj : GlobalProjectile
    {
        static int addedDamage = 0;
        static float damageMultiplier = 1f;


        public override void SetDefaults(Projectile projectile)
        {
            addedDamage = 0;
            damageMultiplier = 1f;
            int penetration = 0;


            if (irieList.friendlyBees.Contains(projectile.type))
            {
                switch (iriesplayer.BeeBackpack)
                {
                    case irieItemID.ObsidianBeeBackpack:
                        penetration += 1;
                        addedDamage += Main.rand.Next(2, 9);
                        break;
                }

                damageMultiplier = 1f + iriesplayer.beeDamage;
            }

            projectile.penetrate += penetration;
        }

        public override void ModifyHitNPC(Projectile projectile, NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
            damage = (int)((projectile.damage + addedDamage) * damageMultiplier);
        }
    }
}
