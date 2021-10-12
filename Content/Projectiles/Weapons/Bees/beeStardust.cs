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
			projectile.CloneDefaults(ProjectileID.GiantBee);
			projectile.scale = 1f;
			projectile.minion = true;
			projectile.ignoreWater = true;
			aiType = ProjectileID.GiantBee;
			Main.projFrames[projectile.type] = 4;

		}
	}
}
