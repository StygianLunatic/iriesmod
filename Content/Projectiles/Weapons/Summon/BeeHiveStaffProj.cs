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
			ProjectileID.Sets.MinionTargettingFeature[projectile.type] = true;
		}

		public override void SetDefaults()
		{
			projectile.netImportant = true;
			projectile.width = 40;
			projectile.height = 58;
			projectile.tileCollide = true;
			projectile.sentry = true;
			projectile.timeLeft = Projectile.SentryLifeTime;
			projectile.penetrate = -1;
		}

		public override void AI()
		{
			NPC target = null;

			float distance = 800f;
			Vector2 ProjCenter = projectile.Center;

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
				projectile.ai[0] += 1f;


				if (Main.netMode != NetmodeID.Server && Main.myPlayer == projectile.owner && projectile.ai[0] % 160f == 0f)
				{

					int numberOfBees = Main.rand.Next(2, 7);
					for (int beeIndex = 0; beeIndex < numberOfBees; beeIndex++)
					{
						float speedX = Main.rand.Next(-35, 36) * 0.02f;
						float speedY = Main.rand.Next(-35, 36) * 0.02f;
						Projectile.NewProjectile(new Vector2(projectile.position.X, projectile.position.Y), new Vector2(speedX, speedY), Main.player[projectile.owner].beeType(), Main.player[projectile.owner].beeDamage(projectile.damage), Main.player[projectile.owner].beeKB(0f), projectile.owner);
					}
				}
			}
			if (projectile.velocity.Y < 10f)
            {
				projectile.velocity.Y += 0.4f;
			}

		}

		public override bool CanDamage()
		{
			return false;
		}

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			return false;
		}
	}
}
