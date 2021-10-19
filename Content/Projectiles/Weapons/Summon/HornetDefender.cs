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
			ProjectileID.Sets.MinionTargettingFeature[Projectile.type] = true;
			ProjectileID.Sets.CountsAsHoming[Projectile.type] = true;
		}

		public override void SetDefaults()
		{
			Projectile.netImportant = true;
			Projectile.width = 46;
			Projectile.height = 38;
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
				float stopDistance = 150f;

				if (Projectile.ai[0] % 3 == 0 && distance > stopDistance)
				{
					Projectile.velocity.X = (target.Center.X - ProjCenter.X) * 0.01f;
					Projectile.velocity.Y = (target.Center.Y - ProjCenter.Y) * 0.01f;
				}
                if (distance < 160f)
                {
					Projectile.ai[1]++;
                }
				if (distance < 150f)
                {
					Projectile.velocity = new(0f, 0f);
                }
				if (Main.myPlayer == Projectile.owner)
				{
					if (Projectile.ai[1] > 0f && Projectile.ai[0] % 150 == 0f)
                    {
						Projectile.NewProjectile(Projectile.GetProjectileSource_FromThis(), Projectile.Center, (target.Center - Projectile.Center) * new Vector2(0.1f, 0.1f) , ModContent.ProjectileType<BeeHive>(), Projectile.damage, Projectile.knockBack, Projectile.owner);
                    }
				}

				Projectile.ai[0]++;
			}
            else
            {
				Projectile.velocity = new Vector2(0, 0);
            }

			// 미니언의 진행 방향에 따라 스프라이트를 좌우반전 시킨다.
			if (Projectile.velocity.X > 0f)
				Projectile.spriteDirection = Projectile.direction = -1;
			else if (Projectile.velocity.X < 0f)
				Projectile.spriteDirection = Projectile.direction = 1;
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
