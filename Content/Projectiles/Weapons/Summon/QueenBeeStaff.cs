using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace iriesmod.Content.Projectiles.Weapons.Summon
{
	public class QueenBeeStaff : ModProjectile
	{
        public override string Texture => "Terraria/NPC_" + 222;
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Queen Bee summon");

			Main.projFrames[projectile.type] = 12;

			// drawOffsetX = -40;

			ProjectileID.Sets.MinionTargettingFeature[projectile.type] = true;
			Main.projPet[projectile.type] = true;
			ProjectileID.Sets.MinionSacrificable[projectile.type] = true;
			ProjectileID.Sets.Homing[projectile.type] = true;
		}

		public override void SetDefaults()
		{
			projectile.width = 172;
			projectile.height = 152;
			projectile.friendly = true;
			projectile.minion = true;
			projectile.minionSlots = 2f;
			projectile.penetrate = -1;
			projectile.netImportant = true;
			projectile.tileCollide = true;
			projectile.ignoreWater = true;
			projectile.scale = 0.7f;
		}

		public override bool? CanCutTiles()
		{
			return false;
		}

		public override void AI()
		{
			Player player = Main.player[projectile.owner];
			if (player.dead || !(player.active))
			{
				player.ClearBuff(ModContent.BuffType<Buffs.Minions.QueenBeeStaff>());
			}
			if (player.HasBuff(ModContent.BuffType<Buffs.Minions.QueenBeeStaff>()))
			{
				projectile.timeLeft = 2;
			}


			Vector2 vector = projectile.position;
			float distance;

			distance = 1000f;
			bool is_target = false;
			projectile.tileCollide = true;

			float velocityPower = (float)Math.Sqrt(projectile.velocity.X * projectile.velocity.X + projectile.velocity.Y * projectile.velocity.Y);
			if (velocityPower < 15f)
            {
				projectile.localAI[0] = 0f;
            }

            #region 타겟 결정부분
            NPC ownerMinionAttackTargetNPC2 = projectile.OwnerMinionAttackTargetNPC;
			if (ownerMinionAttackTargetNPC2 != null && ownerMinionAttackTargetNPC2.CanBeChasedBy(this))
			{
				float distanceCompare = Vector2.Distance(ownerMinionAttackTargetNPC2.Center, projectile.Center);
				float tiledistance = distance * 3f;
				if (distanceCompare < tiledistance && !is_target && Collision.CanHitLine(projectile.position, projectile.width, projectile.height, ownerMinionAttackTargetNPC2.position, ownerMinionAttackTargetNPC2.width, ownerMinionAttackTargetNPC2.height))
				{
					distance = distanceCompare;
					vector = ownerMinionAttackTargetNPC2.Center;
					is_target = true;
				}
			}

			if (!is_target)
			{
				for (int nPCindex = 0; nPCindex < 200; nPCindex++)
				{
					NPC nPC2 = Main.npc[nPCindex];
					if (nPC2.CanBeChasedBy(this))
					{
						float distanceCompare2 = Vector2.Distance(nPC2.Center, projectile.Center);
						if (!(distanceCompare2 >= distance) && Collision.CanHitLine(projectile.position, projectile.width, projectile.height, nPC2.position, nPC2.width, nPC2.height))
						{
							distance = distanceCompare2;
							vector = nPC2.Center;
							is_target = true;
						}
					}
				}
			}

            #endregion


            #region 미니언 위치 유지 부분
            int limitDistanceBetweenPlayerProj = 500;
			if (is_target)
				limitDistanceBetweenPlayerProj = 1000;

			if (Vector2.Distance(player.Center, projectile.Center) > limitDistanceBetweenPlayerProj) // 플레이어와 미니언 간의 거리가 최대 간격 초과일 때
			{
				projectile.ai[0] = 1f; // ai[0]을 1f로 설정하고
				projectile.netUpdate = true;  // 동기화한다.
			}

			if (projectile.ai[0] == 1f) // 플레이어와 미니언 간의 거리가 최대 간격 초과일 때
				projectile.tileCollide = false; // 미니언은 타일과 부딪히지 않는다.

			if (is_target && projectile.ai[0] == 0f) // 타겟이 있고 플레이어와 미니언 간의 거리가 최대 간격 이하일 때
			{
				Vector2 ToTarget = vector - projectile.Center;
				float distanceProj2Target = ToTarget.Length();
				ToTarget.Normalize();

				if (distanceProj2Target > 200f)
				{
					float ToTargetVelocity = 20f;
					ToTarget *= ToTargetVelocity;
					projectile.velocity.X = (projectile.velocity.X * 40f + ToTarget.X) / 41f;
					projectile.velocity.Y = (projectile.velocity.Y * 40f + ToTarget.Y) / 41f;
				}
				else if (projectile.velocity.Y > -1f)
				{
					projectile.velocity.Y -= 0.1f;
				}
			}
			else // 타겟이 없거나 플레이어와 미니언 간의 거리가 최대 간격 초과일 때
			{
				if (!Collision.CanHitLine(projectile.Center, 1, 1, Main.player[projectile.owner].Center, 1, 1))
					projectile.ai[0] = 1f;


				float projPlaceSpeed = 6f;
				if (projectile.ai[0] == 1f)
					projPlaceSpeed = 15f;


				Vector2 center2 = projectile.Center;
				Vector2 abovePlayerHead = player.Center - center2 + new Vector2(0f, -40f);

				float AboveplayerHeadLength = abovePlayerHead.Length();
				if (AboveplayerHeadLength > 200f && projPlaceSpeed < 9f)
					projPlaceSpeed = 9f;


				if (AboveplayerHeadLength < 100f && projectile.ai[0] == 1f && !Collision.SolidCollision(projectile.position, projectile.width, projectile.height))
				{
					projectile.ai[0] = 0f;
					projectile.netUpdate = true;
				}

				if (AboveplayerHeadLength > 2000f)
				{
					projectile.position.X = Main.player[projectile.owner].Center.X - (projectile.width / 2);
					projectile.position.Y = Main.player[projectile.owner].Center.Y - (projectile.width / 2);
				}

				if (AboveplayerHeadLength > 70f)
				{
					abovePlayerHead.Normalize();
					abovePlayerHead *= projPlaceSpeed;
					projectile.velocity = (projectile.velocity * 20f + abovePlayerHead) / 21f;
				}
				else
				{
					if (projectile.velocity.X == 0f && projectile.velocity.Y == 0f)
					{
						projectile.velocity.X = -0.15f;
						projectile.velocity.Y = -0.05f;
					}

					projectile.velocity *= 1.01f;
				}
			}
            #endregion


            #region 미니언 애니메이션 부분
            // 미니언의 X속도에 따라 기울게 한다.
            projectile.rotation = projectile.velocity.X * 0.05f;


			// 애니메이션 재생
			int frameSpeed = 5;
			projectile.frameCounter++;
			if (projectile.frameCounter >= frameSpeed)
			{
				projectile.frameCounter = 0;
				projectile.frame++;
				if (projectile.frame >= Main.projFrames[projectile.type])
				{
					projectile.frame = 4;
				}
			}


			// 미니언의 진행 방향에 따라 스프라이트를 좌우반전 시킨다.
			if (projectile.velocity.X > 0f)
				projectile.spriteDirection = projectile.direction = -1;
			else if (projectile.velocity.X < 0f)
				projectile.spriteDirection = projectile.direction = 1;

            #endregion


            #region 미니언 투사체 부분
            if (projectile.ai[1] > 0f)
				projectile.ai[1] += Main.rand.Next(1, 4);

			if (projectile.ai[1] > 90f)
			{
				projectile.ai[1] = 0f;
				if (Main.rand.NextBool(5))
                {
					projectile.ai[1] = 100f;
                }
				projectile.netUpdate = true;
			}

			if (projectile.ai[0] != 0f)
				return;



			float newProjSpeedMult = 10f; // 생성할 투사체의 속도
			int new_projectile_type = ProjectileID.HornetStinger; // 생성할 투사체의 종류

			if (!is_target)
				return;
			if (projectile.ai[1] == 0f)
			{
				Vector2 newProjectileSpeed = vector - projectile.Center;
				projectile.ai[1] += 1f;
				if (Main.myPlayer == projectile.owner && false)
				{
					newProjectileSpeed.Normalize();
					newProjectileSpeed *= newProjSpeedMult;
					int newProjRet = Projectile.NewProjectile(projectile.Center, newProjectileSpeed, new_projectile_type, projectile.damage, projectile.knockBack, Main.myPlayer);
					Main.projectile[newProjRet].timeLeft = 300;
					Main.projectile[newProjRet].netUpdate = true;

					projectile.netUpdate = true;
				}
			}

            #endregion


            #region 미니언 돌진 부분
            if (projectile.ai[1] == 100f)
            {
				projectile.localAI[0] = 1f;
				float proj2targetX = vector.X - projectile.Center.X;
				float proj2targetY = vector.Y - projectile.Center.Y;
				float proj2targetDistance = (float)Math.Sqrt(proj2targetX * proj2targetX + proj2targetY * proj2targetY);
				proj2targetDistance = 20f / proj2targetDistance;
				projectile.velocity.X = proj2targetX * proj2targetDistance;
				projectile.velocity.Y = proj2targetY * proj2targetDistance;

				projectile.frame = 0;
				projectile.spriteDirection = projectile.direction;

				Main.PlaySound(SoundID.Roar, (int)projectile.position.X, (int)projectile.position.Y, 0);
            }
            #endregion
        }

        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			SpriteEffects spriteEffects = SpriteEffects.None;
			if (projectile.spriteDirection == -1)
			{
				spriteEffects = SpriteEffects.FlipHorizontally;
			}
			Texture2D texture = Main.projectileTexture[projectile.type];
			int frameHeight = Main.projectileTexture[projectile.type].Height / Main.projFrames[projectile.type];
			int startY = frameHeight * projectile.frame;
			Rectangle sourceRectangle = new Rectangle(0, startY, texture.Width, frameHeight);
			Vector2 origin = sourceRectangle.Size() / 2f;
			origin.X = (float)(projectile.spriteDirection == 1 ? sourceRectangle.Width - 90 : 90);

			Color drawColor = projectile.GetAlpha(lightColor);
			Main.spriteBatch.Draw(texture,
			 	projectile.Center - Main.screenPosition + new Vector2(0f, projectile.gfxOffY),
			 	sourceRectangle, drawColor, projectile.rotation, origin, projectile.scale, spriteEffects, 0f);
			// spriteBatch.Draw(texture, projectile.Center - Main.screenPosition, null, projectile.GetAlpha(lightColor), projectile.rotation, Utils.Size(texture) / 2f, projectile.scale, SpriteEffects.None, 0f);


			return false;
		}

        public override bool MinionContactDamage()
        {
			if (projectile.localAI[0] == 1f)
            {
				return true;
            }
			return false;
        }
        public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
			damage = (int)(damage * 1.5f);
        }

    }
}
