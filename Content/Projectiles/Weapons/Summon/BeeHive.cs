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

			Projectile.width = 18;
			Projectile.height = 28;
			// Projectile.tileCollide = false;

			Projectile.friendly = true;
			Projectile.minion = true;
			Projectile.DamageType = DamageClass.Summon;
			Projectile.minionSlots = 0f;
			Projectile.penetrate = 1;
			AIType = ProjectileID.Beenade;
		}

		public override void Kill(int timeLeft)
		{
			SoundEngine.PlaySound(SoundID.Item14, Projectile.position);

			if (Projectile.owner != Main.myPlayer)
			{
				return;
			}
			for (int i = 0; i < 10; i++)
			{
				int SmokeID = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, DustID.Smoke, 0f, 0f, 100, default(Color), 1.5f);
				Dust dust = Main.dust[SmokeID];
				dust.velocity *= 1f;
			}
			if (Projectile.owner == Main.myPlayer)
			{
				int numberOfBees = Main.rand.Next(3, 7);
				for (int beeIndex = 0; beeIndex < numberOfBees; beeIndex++)
				{
					float speedX = (float)Main.rand.Next(-35, 36) * 0.02f;
					float speedY = (float)Main.rand.Next(-35, 36) * 0.02f;
					int proj = Projectile.NewProjectile(Projectile.GetProjectileSource_FromThis(), new Vector2(Projectile.position.X, Projectile.position.Y), new Vector2(speedX, speedY), Main.player[Projectile.owner].beeType(), Main.player[Projectile.owner].beeDamage(Projectile.damage), Main.player[Projectile.owner].beeKB(0f), Projectile.owner);
					Main.projectile[proj].DamageType = DamageClass.Summon;
				}
			}
		}
	}
}
