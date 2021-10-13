using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace iriesmod.Content.Projectiles.Weapons.Bees
{
	public class beeBeetle : ModProjectile
	{
		public override string Texture => "Terraria/" + "BeetleOrb";
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("beeBeetle");
		}

		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.Bee);
			projectile.scale = 1f;
			projectile.minion = true;
			aiType = ProjectileID.Bee;
			Main.projFrames[projectile.type] = 3;
			projectile.penetrate = 3;

		}
	}
}
