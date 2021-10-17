using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace iriesmod.Content.Projectiles.Weapons.Bees
{
	public class beeObsidian : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("beeObsidian");
		}

		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.GiantBee);
			projectile.scale = 1f;
			projectile.minion = true;
			aiType = ProjectileID.GiantBee;
			Main.projFrames[projectile.type] = 3;
			projectile.penetrate = 3;

		}

        public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
			target.AddBuff(BuffID.OnFire, 300);
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
		{
			return false;
		}
	}
}
