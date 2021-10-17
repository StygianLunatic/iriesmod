using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace iriesmod.Content.Projectiles.Weapons.Bees
{
	public class beeLava : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("beeLava");
		}

		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.GiantBee);
			projectile.scale = 1f;
			projectile.melee = true;
			aiType = ProjectileID.GiantBee;
			Main.projFrames[projectile.type] = 3;
			projectile.penetrate = 1;

		}
        public override void Kill(int timeLeft)
        {
			Main.PlaySound(SoundID.Item14, projectile.position);
			for (int i = 0; i < 7; i++)
            {
				Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, DustID.Smoke, Alpha: 100, Scale: 1.5f);
			}
			for (int i = 0; i < 3; i++)
			{
				int newDust = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, DustID.Fire, 0f, 0f, 100, default(Color), 2.5f);
				Main.dust[newDust].noGravity = true;
				Dust dust = Main.dust[newDust];
				dust.velocity *= 3f;
				newDust = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, DustID.Fire, 0f, 0f, 100, default(Color), 1.5f);
				dust = Main.dust[newDust];
				dust.velocity *= 2f;
			}
		}

        public override bool OnTileCollide(Vector2 oldVelocity)
		{
			return false;
		}
	}
}
