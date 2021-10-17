using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace iriesmod.Content.Projectiles.Weapons.Bees
{
	public class beeBeetle : ModProjectile
	{
		public override string Texture => "Terraria/Images/" + "BeetleOrb";
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("beeBeetle");
		}

		public override void SetDefaults()
		{
			Projectile.CloneDefaults(ProjectileID.GiantBee);
			Projectile.scale = 1f;
			Projectile.minion = true;
			AIType = ProjectileID.GiantBee;
			Main.projFrames[Projectile.type] = 3;
			Projectile.penetrate = 3;

		}
		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			return false;
		}
	}
}
