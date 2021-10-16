using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace iriesmod.Content.Projectiles.Weapons.Summon
{
	public class HornetDefender : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Hornet Defender");
			ProjectileID.Sets.MinionTargettingFeature[projectile.type] = true;
			ProjectileID.Sets.Homing[projectile.type] = true;
		}

		public override void SetDefaults()
		{
			projectile.netImportant = true;
			projectile.width = 46;
			projectile.height = 38;
			projectile.tileCollide = true;
			projectile.sentry = true;
			projectile.timeLeft = Projectile.SentryLifeTime;
			projectile.penetrate = -1;
		}

		public override void AI()
		{
			NPC target = null;

			float distance = 600f;
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
				projectile.ai[1] = 0f;
				if (projectile.ai[0] % 3 == 0 && distance > 150f)
				{
					projectile.velocity.X = (target.Center.X - ProjCenter.X) * 0.01f;
					projectile.velocity.Y = (target.Center.Y - ProjCenter.Y) * 0.01f;
				}
                if (distance < 147f)
                {
					projectile.velocity = new Vector2(0, 0);
					projectile.ai[1]++;
                }

				if (Main.netMode != NetmodeID.Server && Main.myPlayer == projectile.owner)
				{
					if (projectile.ai[1] > 0f && projectile.ai[0] % 150 == 0f)
                    {
						Projectile.NewProjectile(projectile.Center, (target.Center - projectile.Center) * new Vector2(0.1f, 0.1f) , ModContent.ProjectileType<BeeHive>(), projectile.damage, projectile.knockBack, projectile.owner);
                    }
				}

				projectile.ai[0]++;
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
