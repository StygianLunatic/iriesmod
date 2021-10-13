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
			projectile.CloneDefaults(ProjectileID.Bee);
			projectile.scale = 1f;
			projectile.minion = true;
			projectile.ignoreWater = true;
			aiType = ProjectileID.Bee;
			Main.projFrames[projectile.type] = 4;
			projectile.penetrate = 4;

		}
	}
}
