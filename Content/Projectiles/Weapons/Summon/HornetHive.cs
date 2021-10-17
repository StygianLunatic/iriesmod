using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace iriesmod.Content.Projectiles.Weapons.Summon
{
	public class HornetHive : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Hornet Hive");
			ProjectileID.Sets.MinionTargettingFeature[projectile.type] = true;
		}

		public override void SetDefaults()
		{
			projectile.netImportant = true;
			projectile.width = 68;
			projectile.height = 34;
			projectile.tileCollide = true;
			projectile.sentry = true;
			projectile.timeLeft = Projectile.SentryLifeTime;
			projectile.penetrate = -1;
		}

		public override void AI()
		{
			NPC target = null;

			float distance = 1000f;
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

					int numberOfHornets = Main.rand.Next(1, 4);
					for (int i = 0; i < numberOfHornets; i++)
					{
						float speedX = Main.rand.Next(-12, 13) * 0.02f;
						float speedY = Main.rand.Next(-35, -12) * 0.02f;
						Projectile.NewProjectile(new Vector2(projectile.Center.X, projectile.position.Y + 10f), new Vector2(speedX, speedY), ModContent.ProjectileType<HiveHornet>(), Main.player[projectile.owner].beeDamage(projectile.damage), Main.player[projectile.owner].beeKB(0f), projectile.owner);
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
