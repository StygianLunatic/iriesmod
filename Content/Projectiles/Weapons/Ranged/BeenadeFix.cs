﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;

namespace iriesmod.Content.Projectiles.Weapons.Ranged
{
	public class BeenadeFix : ModProjectile
	{
		public override string Texture => "Terraria/Images/Item_" + 1130;
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("beenade");
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

			int Gores = Gore.NewGore(new Vector2(Projectile.position.X, Projectile.position.Y), default(Vector2), Main.rand.Next(61, 64));
			Main.gore[Gores].velocity.X += 1f;
			Main.gore[Gores].velocity.Y += 1f;
			Gore gore = Main.gore[Gores];
			gore.velocity *= 0.3f;
			Gores = Gore.NewGore(new Vector2(Projectile.position.X, Projectile.position.Y), default(Vector2), Main.rand.Next(61, 64));
			Main.gore[Gores].velocity.X -= 1f;
			Main.gore[Gores].velocity.Y += 1f;
			gore = Main.gore[Gores];
			gore.velocity *= 0.3f;
			Gores = Gore.NewGore(new Vector2(Projectile.position.X, Projectile.position.Y), default(Vector2), Main.rand.Next(61, 64));
			Main.gore[Gores].velocity.X += 1f;
			Main.gore[Gores].velocity.Y -= 1f;
			gore = Main.gore[Gores];
			gore.velocity *= 0.3f;
			Gores = Gore.NewGore(new Vector2(Projectile.position.X, Projectile.position.Y), default(Vector2), Main.rand.Next(61, 64));
			Main.gore[Gores].velocity.X -= 1f;
			Main.gore[Gores].velocity.Y -= 1f;
			gore = Main.gore[Gores];
			gore.velocity *= 0.3f;
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
