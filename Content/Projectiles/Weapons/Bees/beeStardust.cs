using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace iriesmod.Content.Projectiles.Weapons.Bees
{
	public class beeStardust : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("beeStardust");
		}

		public override void SetDefaults()
		{
			Projectile.CloneDefaults(ProjectileID.GiantBee);
			Projectile.scale = 1f;
			Projectile.minion = true;
			Projectile.ignoreWater = true;
			AIType = ProjectileID.GiantBee;
			Main.projFrames[Projectile.type] = 4;
			Projectile.penetrate = 4;

		}

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			return false;
		}
	}
}
