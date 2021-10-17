using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;

namespace iriesmod.Content.Projectiles.Weapons.Summon
{
	public class BeeHive : ModProjectile
	{
		public override string Texture => "Terraria/Images/Projectile_" + 655;
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("BeeHive");
		}

		public override void SetDefaults()
		{
			Projectile.CloneDefaults(ProjectileID.Beenade);
			AIType = ProjectileID.Beenade;
		}

		public override void Kill(int timeLeft)
		{
			SoundEngine.PlaySound(SoundID.Item14, Projectile.position);

			if (Projectile.owner != Main.myPlayer)
			{
				return;
			}
			for (int i = 0; i < 20; i++)
			{
				int SmokeID = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, DustID.Smoke, 0f, 0f, 100, default(Color), 1.5f);
				Dust dust = Main.dust[SmokeID];
				dust.velocity *= 1f;
			}
			if (Projectile.owner == Main.myPlayer)
			{
				int numberOfBees = Main.rand.Next(15, 25);
				for (int beeIndex = 0; beeIndex < numberOfBees; beeIndex++)
				{
					float speedX = (float)Main.rand.Next(-35, 36) * 0.02f;
					float speedY = (float)Main.rand.Next(-35, 36) * 0.02f;
					Projectile.NewProjectile(Projectile.GetProjectileSource_FromThis(), new Vector2(Projectile.position.X, Projectile.position.Y), new Vector2(speedX, speedY), Main.player[Projectile.owner].beeType(), Main.player[Projectile.owner].beeDamage(Projectile.damage), Main.player[Projectile.owner].beeKB(0f), Projectile.owner);
				}
			}
		}
	}
}
