using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace iriesmod.Content.Projectiles.Weapons.Summon
{
	public class BeeHiveStaffProj : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("BeeHive");
			ProjectileID.Sets.MinionTargettingFeature[Projectile.type] = true;
		}

		public override void SetDefaults()
		{
			Projectile.netImportant = true;
			Projectile.width = 40;
			Projectile.height = 58;
			Projectile.tileCollide = true;
			Projectile.sentry = true;
			Projectile.timeLeft = Projectile.SentryLifeTime;
			Projectile.penetrate = -1;
		}

		public override void AI()
		{
			NPC target = null;

			float distance = 800f;
			Vector2 ProjCenter = Projectile.Center;

			for (int index = 0; index < Main.npc.Length; index++)
			{
				if (Main.npc[index].CanBeChasedBy())
				{
					if (Vector2.Distance(ProjCenter, Main.npc[index].Center) < distance)
					{
						distance = Vector2.Distance(ProjCenter, Main.npc[index].Center);
						target = Main.npc[index];
					}
				}
			}

			if (target != null)
			{
				Projectile.ai[0] += 1f;


				if (Main.netMode != NetmodeID.Server && Main.myPlayer == Projectile.owner && Projectile.ai[0] % 160f == 0f)
				{

					int numberOfBees = Main.rand.Next(2, 7);
					for (int beeIndex = 0; beeIndex < numberOfBees; beeIndex++)
					{
						float speedX = Main.rand.Next(-35, 36) * 0.02f;
						float speedY = Main.rand.Next(-35, 36) * 0.02f;
						Projectile proj = Projectile.NewProjectileDirect(Projectile.GetProjectileSource_FromThis(), new Vector2(Projectile.position.X, Projectile.position.Y), new Vector2(speedX, speedY), Main.player[Projectile.owner].beeType(), Main.player[Projectile.owner].beeDamage(Projectile.damage), Main.player[Projectile.owner].beeKB(0f), Projectile.owner);
						proj.DamageType = DamageClass.Summon;
					}
				}
			}
			if (Projectile.velocity.Y < 10f)
            {
				Projectile.velocity.Y += 0.4f;
			}

		}

		public override bool? CanDamage()
		{
			return false;
		}

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			return false;
		}
	}
}
