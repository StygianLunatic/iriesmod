using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace iriesmod.Content.Projectiles.Weapons.Summon
{
	public class RoyalHornetDefender : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Royal Hornet Defender");

			Main.projFrames[Projectile.type] = 4;

			ProjectileID.Sets.MinionTargettingFeature[Projectile.type] = true;
			ProjectileID.Sets.CountsAsHoming[Projectile.type] = true;
		}

		public override void SetDefaults()
		{
			Projectile.netImportant = true;
			Projectile.width = 52;
			Projectile.height = 156;
			Projectile.tileCollide = true;
			Projectile.sentry = true;
			Projectile.timeLeft = Projectile.SentryLifeTime;
			Projectile.penetrate = -1;
		}

		public override void AI()
		{
			NPC target = null;

			float distance = 600f;
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
				Projectile.ai[1] = 0f;
				if (Projectile.ai[0] % 3 == 0 && distance > 150f)
				{
					Projectile.velocity.X = (target.Center.X - ProjCenter.X) * 0.01f;
					Projectile.velocity.Y = (target.Center.Y - ProjCenter.Y) * 0.01f;
				}
                if (distance < 147f)
                {
					Projectile.velocity = new Vector2(0, 0);
					Projectile.ai[1]++;
                }

				if (Main.netMode != NetmodeID.Server && Main.myPlayer == Projectile.owner)
				{
					if (Projectile.ai[1] > 0f && Projectile.ai[0] % 150 == 0f)
                    {
						Projectile.NewProjectile(Projectile.GetProjectileSource_FromThis(), Projectile.Center, (target.Center - Projectile.Center) * new Vector2(0.1f, 0.1f) , ModContent.ProjectileType<BeeHive>(), Projectile.damage, Projectile.knockBack, Projectile.owner);
                    }
				}

				Projectile.ai[0]++;
			}

			int frameSpeed = 5;
			Projectile.frameCounter++;
			if (Projectile.frameCounter >= frameSpeed)
			{
				Projectile.frameCounter = 0;
				Projectile.frame++;
				if (Projectile.frame >= Main.projFrames[Projectile.type])
				{
					Projectile.frame = 0;
				}
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
