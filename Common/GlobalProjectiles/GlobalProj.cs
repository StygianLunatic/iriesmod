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
        public static int orig_damage;


        public override void SetDefaults(Projectile projectile)
        {
            int penetration = 0;
            orig_damage = projectile.damage;

            if (irieList.friendlyBees.Contains(projectile.type))
            {
                switch (iriesplayer.BeeBackpack)
                {
                    case irieItemID.ObsidianBeeBackpack:
                        penetration += 1;
                        break;
                }
            }


            projectile.penetrate += penetration;
        }


        public override void AI(Projectile projectile)
        {
            int damage = 0;
            float damageMultiplier = 1f;

            if (irieList.friendlyBees.Contains(projectile.type))
            {
                switch (iriesplayer.BeeBackpack)
                {
                    case irieItemID.ObsidianBeeBackpack:
                        damage += Main.rand.Next(2, 9);
                        break;
                }
                damageMultiplier = iriesplayer.beeDamage;
            }

            projectile.damage = (int)((orig_damage + damage) * damageMultiplier);
        }
    }
}
