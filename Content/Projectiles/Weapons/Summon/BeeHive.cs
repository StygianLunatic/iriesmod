using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;

namespace iriesmod.Content.Projectiles.Weapons.Summon
{
	public class BeeHive : ModProjectile
	{
		public override string Texture => "Terraria/Tiles_" + 444;
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("BeeHive");
		}

		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.Beenade);
			aiType = ProjectileID.Beenade;
		}

		public override void Kill(int timeLeft)
		{
			Main.PlaySound(SoundID.Item14, projectile.position);

			if (projectile.owner != Main.myPlayer)
			{
				return;
			}
			for (int i = 0; i < 20; i++)
			{
				int SmokeID = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, DustID.Smoke, 0f, 0f, 100, default(Color), 1.5f);
				Dust dust = Main.dust[SmokeID];
				dust.velocity *= 1f;
			}
			if (projectile.owner == Main.myPlayer)
			{
				int numberOfBees = Main.rand.Next(15, 25);
				for (int beeIndex = 0; beeIndex < numberOfBees; beeIndex++)
				{
					float speedX = (float)Main.rand.Next(-35, 36) * 0.02f;
					float speedY = (float)Main.rand.Next(-35, 36) * 0.02f;
					Projectile.NewProjectile(new Vector2(projectile.position.X, projectile.position.Y), new Vector2(speedX, speedY), Main.player[projectile.owner].beeType(), Main.player[projectile.owner].beeDamage(projectile.damage), Main.player[projectile.owner].beeKB(0f), projectile.owner);
				}
			}
		}
	}
}
