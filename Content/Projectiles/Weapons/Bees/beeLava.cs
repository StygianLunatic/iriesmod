using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
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
			Projectile.CloneDefaults(ProjectileID.GiantBee);
			Projectile.scale = 1f;
			Projectile.DamageType = DamageClass.Melee;
			AIType = ProjectileID.GiantBee;
			Main.projFrames[Projectile.type] = 3;
			Projectile.penetrate = 1;

		}
        public override void Kill(int timeLeft)
        {
			SoundEngine.PlaySound(SoundID.Item14, Projectile.position);
			for (int i = 0; i < 7; i++)
            {
				Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, DustID.Smoke, Alpha: 100, Scale: 1.5f);
			}
			for (int i = 0; i < 3; i++)
			{
				int newDust = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, DustID.Flare, 0f, 0f, 100, default(Color), 2.5f);
				Main.dust[newDust].noGravity = true;
				Dust dust = Main.dust[newDust];
				dust.velocity *= 3f;
				newDust = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, DustID.Flare, 0f, 0f, 100, default(Color), 1.5f);
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
