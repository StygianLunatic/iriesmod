using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace iriesmod.Content.Projectiles.Weapons.Summon
{
	public class QueenBeeStaff : ModProjectile
	{
        public override string Texture => "Terraria/Images/NPC_" + 222;
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Queen Bee summon");

			Main.projFrames[Projectile.type] = 12;

			// drawOffsetX = -40;

			ProjectileID.Sets.MinionTargettingFeature[Projectile.type] = true;
			Main.projPet[Projectile.type] = true;
			ProjectileID.Sets.MinionSacrificable[Projectile.type] = true;
			ProjectileID.Sets.CountsAsHoming[Projectile.type] = true;
		}

		public override void SetDefaults()
		{
			Projectile.width = 172;
			Projectile.height = 152;
			Projectile.friendly = true;
			Projectile.minion = true;
			Projectile.minionSlots = 2f;
			Projectile.penetrate = -1;
			Projectile.netImportant = true;
			Projectile.tileCollide = true;
			Projectile.ignoreWater = true;
			Projectile.scale = 0.7f;
		}

		public override bool? CanCutTiles()
		{
			return false;
		}

		public override void AI()
		{
			Player player = Main.player[Projectile.owner];
			if (player.dead || !(player.active))
			{
				player.ClearBuff(ModContent.BuffType<Buffs.Minions.QueenBeeStaff>());
			}
			if (player.HasBuff(ModContent.BuffType<Buffs.Minions.QueenBeeStaff>()))
			{
				Projectile.timeLeft = 2;
			}


			Vector2 vector = Projectile.position;
			float distance;

			distance = 1000f;
			bool is_target = false;
			Projectile.tileCollide = true;

			float velocityPower = (float)Math.Sqrt(Projectile.velocity.X * Projectile.velocity.X + Projectile.velocity.Y * Projectile.velocity.Y);
			if (velocityPower < 15f)
            {
				Projectile.localAI[0] = 0f;
            }

            #region 타겟 결정부분
            NPC ownerMinionAttackTargetNPC2 = Projectile.OwnerMinionAttackTargetNPC;
			if (ownerMinionAttackTargetNPC2 != null && ownerMinionAttackTargetNPC2.CanBeChasedBy(this))
			{
				float distanceCompare = Vector2.Distance(ownerMinionAttackTargetNPC2.Center, Projectile.Center);
				float tiledistance = distance * 3f;
				if (distanceCompare < tiledistance && !is_target && Collision.CanHitLine(Projectile.position, Projectile.width, Projectile.height, ownerMinionAttackTargetNPC2.position, ownerMinionAttackTargetNPC2.width, ownerMinionAttackTargetNPC2.height))
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
						float distanceCompare2 = Vector2.Distance(nPC2.Center, Projectile.Center);
						if (!(distanceCompare2 >= distance) && Collision.CanHitLine(Projectile.position, Projectile.width, Projectile.height, nPC2.position, nPC2.width, nPC2.height))
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
            int limitDistanceBetweenplayerProj = 500;
			if (is_target)
				limitDistanceBetweenplayerProj = 1000;

			if (Vector2.Distance(player.Center, Projectile.Center) > limitDistanceBetweenplayerProj) // 플레이어와 미니언 간의 거리가 최대 간격 초과일 때
			{
				Projectile.ai[0] = 1f; // ai[0]을 1f로 설정하고
				Projectile.netUpdate = true;  // 동기화한다.
			}

			if (Projectile.ai[0] == 1f) // 플레이어와 미니언 간의 거리가 최대 간격 초과일 때
				Projectile.tileCollide = false; // 미니언은 타일과 부딪히지 않는다.

			if (is_target && Projectile.ai[0] == 0f) // 타겟이 있고 플레이어와 미니언 간의 거리가 최대 간격 이하일 때
			{
				Vector2 ToTarget = vector - Projectile.Center;
				float distanceProj2Target = ToTarget.Length();
				ToTarget.Normalize();

				if (distanceProj2Target > 200f)
				{
					float ToTargetVelocity = 20f;
					ToTarget *= ToTargetVelocity;
					Projectile.velocity.X = (Projectile.velocity.X * 40f + ToTarget.X) / 41f;
					Projectile.velocity.Y = (Projectile.velocity.Y * 40f + ToTarget.Y) / 41f;
				}
				else if (Projectile.velocity.Y > -1f)
				{
					Projectile.velocity.Y -= 0.1f;
				}
			}
			else // 타겟이 없거나 플레이어와 미니언 간의 거리가 최대 간격 초과일 때
			{
				if (!Collision.CanHitLine(Projectile.Center, 1, 1, Main.player[Projectile.owner].Center, 1, 1))
					Projectile.ai[0] = 1f;


				float projPlaceSpeed = 6f;
				if (Projectile.ai[0] == 1f)
					projPlaceSpeed = 15f;


				Vector2 center2 = Projectile.Center;
				Vector2 aboveplayerHead = player.Center - center2 + new Vector2(0f, -40f);

				float AboveplayerHeadLength = aboveplayerHead.Length();
				if (AboveplayerHeadLength > 200f && projPlaceSpeed < 9f)
					projPlaceSpeed = 9f;


				if (AboveplayerHeadLength < 100f && Projectile.ai[0] == 1f && !Collision.SolidCollision(Projectile.position, Projectile.width, Projectile.height))
				{
					Projectile.ai[0] = 0f;
					Projectile.netUpdate = true;
				}

				if (AboveplayerHeadLength > 2000f)
				{
					Projectile.position.X = Main.player[Projectile.owner].Center.X - (Projectile.width / 2);
					Projectile.position.Y = Main.player[Projectile.owner].Center.Y - (Projectile.width / 2);
				}

				if (AboveplayerHeadLength > 70f)
				{
					aboveplayerHead.Normalize();
					aboveplayerHead *= projPlaceSpeed;
					Projectile.velocity = (Projectile.velocity * 20f + aboveplayerHead) / 21f;
				}
				else
				{
					if (Projectile.velocity.X == 0f && Projectile.velocity.Y == 0f)
					{
						Projectile.velocity.X = -0.15f;
						Projectile.velocity.Y = -0.05f;
					}

					Projectile.velocity *= 1.01f;
				}
			}
            #endregion


            #region 미니언 애니메이션 부분
            // 미니언의 X속도에 따라 기울게 한다.
            Projectile.rotation = Projectile.velocity.X * 0.05f;


			// 애니메이션 재생
			int frameSpeed = 5;
			Projectile.frameCounter++;
			if (Projectile.frameCounter >= frameSpeed)
			{
				Projectile.frameCounter = 0;
				Projectile.frame++;
				if (Projectile.frame >= Main.projFrames[Projectile.type])
				{
					Projectile.frame = 4;
				}
			}


			// 미니언의 진행 방향에 따라 스프라이트를 좌우반전 시킨다.
			if (Projectile.velocity.X > 0f)
				Projectile.spriteDirection = Projectile.direction = -1;
			else if (Projectile.velocity.X < 0f)
				Projectile.spriteDirection = Projectile.direction = 1;

            #endregion


            #region 미니언 투사체 부분
            if (Projectile.ai[1] > 0f)
				Projectile.ai[1] += Main.rand.Next(1, 4);

			if (Projectile.ai[1] > 90f)
			{
				Projectile.ai[1] = 0f;
				if (Main.rand.NextBool(5))
                {
					Projectile.ai[1] = 100f;
                }
				Projectile.netUpdate = true;
			}

			if (Projectile.ai[0] != 0f)
				return;



			float newProjSpeedMult = 10f; // 생성할 투사체의 속도
			int new_projectile_type = ProjectileID.HornetStinger; // 생성할 투사체의 종류

			if (!is_target)
				return;
			if (Projectile.ai[1] == 0f)
			{
				Vector2 newProjectileSpeed = vector - Projectile.Center;
				Projectile.ai[1] += 1f;
				if (Main.myPlayer == Projectile.owner)
				{
					newProjectileSpeed.Normalize();
					newProjectileSpeed *= newProjSpeedMult;
					int newProjRet = Projectile.NewProjectile(Projectile.GetProjectileSource_FromThis(), Projectile.Center, newProjectileSpeed, new_projectile_type, Projectile.damage, Projectile.knockBack, Main.myPlayer);
					Main.projectile[newProjRet].timeLeft = 300;
					Main.projectile[newProjRet].netUpdate = true;

					Projectile.netUpdate = true;
				}
			}

            #endregion


            #region 미니언 돌진 부분
            if (Projectile.ai[1] == 100f)
            {
				Projectile.localAI[0] = 1f;
				float proj2targetX = vector.X - Projectile.Center.X;
				float proj2targetY = vector.Y - Projectile.Center.Y;
				float proj2targetDistance = (float)Math.Sqrt(proj2targetX * proj2targetX + proj2targetY * proj2targetY);
				proj2targetDistance = 20f / proj2targetDistance;
				Projectile.velocity.X = proj2targetX * proj2targetDistance;
				Projectile.velocity.Y = proj2targetY * proj2targetDistance;

				Projectile.frame = 0;
				Projectile.spriteDirection = Projectile.direction;

				SoundEngine.PlaySound(SoundID.Roar, (int)Projectile.position.X, (int)Projectile.position.Y, 0);
            }
            #endregion
        }

        public override bool PreDraw(ref Color lightColor)
		{
			SpriteEffects spriteEffects = SpriteEffects.None;
			if (Projectile.spriteDirection == -1)
			{
				spriteEffects = SpriteEffects.FlipHorizontally;
			}
			Texture2D texture = Terraria.GameContent.TextureAssets.Projectile[Projectile.type].Value;
			int frameHeight = Terraria.GameContent.TextureAssets.Projectile[Projectile.type].Value.Height / Main.projFrames[Projectile.type];
			int startY = frameHeight * Projectile.frame;
			Rectangle sourceRectangle = new Rectangle(0, startY, texture.Width, frameHeight);
			Vector2 origin = sourceRectangle.Size() / 2f;
			origin.X = (float)(Projectile.spriteDirection == 1 ? sourceRectangle.Width - 90 : 90);

			Color drawColor = Projectile.GetAlpha(lightColor);
			Main.spriteBatch.Draw(texture,
			 	Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY),
			 	sourceRectangle, drawColor, Projectile.rotation, origin, Projectile.scale, spriteEffects, 0f);
			// spriteBatch.Draw(texture, Projectile.Center - Main.screenPosition, null, Projectile.GetAlpha(lightColor), Projectile.rotation, Utils.Size(texture) / 2f, Projectile.scale, SpriteEffects.None, 0f);


			return false;
		}

        public override bool MinionContactDamage()
        {
			if (Projectile.localAI[0] == 1f)
            {
				return true;
            }
			return false;
        }
        public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
			damage = (int)(damage * 1.5f);
			target.AddBuff(BuffID.Poisoned, 480);
        }

    }
}
