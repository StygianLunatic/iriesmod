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
			ProjectileID.Sets.MinionTargettingFeature[Projectile.type] = true;
		}

		public override void SetDefaults()
		{
			Projectile.netImportant = true;
			Projectile.width = 68;
			Projectile.height = 34;
			Projectile.tileCollide = true;
			Projectile.sentry = true;
			Projectile.timeLeft = Projectile.SentryLifeTime;
			Projectile.penetrate = -1;
		}

		public override void AI()
		{
			NPC target = null;

			float distance = 1000f;
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

					int numberOfHornets = Main.rand.Next(1, 4);
					for (int i = 0; i < numberOfHornets; i++)
					{
						float speedX = Main.rand.Next(-12, 13) * 0.02f;
						float speedY = Main.rand.Next(-35, -12) * 0.02f;
						int proj = Projectile.NewProjectile(Projectile.GetProjectileSource_FromThis(), new Vector2(Projectile.Center.X, Projectile.position.Y + 10f), new Vector2(speedX, speedY), ModContent.ProjectileType<HiveHornet>(), Main.player[Projectile.owner].beeDamage(Projectile.damage), Main.player[Projectile.owner].beeKB(0f), Projectile.owner);
						Main.projectile[proj].DamageType = DamageClass.Summon;
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
