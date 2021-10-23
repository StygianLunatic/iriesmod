using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace iriesmod.Content.Projectiles.Weapons.Summon
{
	public class AquaHornet : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Aqua Hornet");

			Main.projFrames[Projectile.type] = 3;
			ProjectileID.Sets.MinionTargettingFeature[Projectile.type] = true;

			Main.projPet[Projectile.type] = true;
			ProjectileID.Sets.MinionSacrificable[Projectile.type] = true;
			ProjectileID.Sets.CountsAsHoming[Projectile.type] = true;
		}

		public override void SetDefaults()
		{
			Projectile.CloneDefaults(ProjectileID.Hornet);
			Projectile.friendly = true;
			Projectile.minion = true;
			Projectile.DamageType = DamageClass.Summon;
			Projectile.minionSlots = 1f;
			Projectile.penetrate = 1;
			Projectile.netImportant = true;
			Projectile.tileCollide = false;
			Projectile.ignoreWater = true;
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
				player.ClearBuff(ModContent.BuffType<Buffs.Minions.AquaHornet>());
			}
			if (player.HasBuff(ModContent.BuffType<Buffs.Minions.AquaHornet>()))
			{
				Projectile.timeLeft = 2;
			}


			float velocityOperand = 0.03f;
			float projWidth = Projectile.width;

			for (int projectileIndex = 0; projectileIndex < 1000; projectileIndex++)
			{
				if (projectileIndex != Projectile.whoAmI && Main.projectile[projectileIndex].active && Main.projectile[projectileIndex].owner == Projectile.owner && Main.projectile[projectileIndex].type == Projectile.type && Math.Abs(Projectile.position.X - Main.projectile[projectileIndex].position.X) + Math.Abs(Projectile.position.Y - Main.projectile[projectileIndex].position.Y) < projWidth)
				{
					if (Projectile.position.X < Main.projectile[projectileIndex].position.X)
						Projectile.velocity.X -= velocityOperand;
					else
						Projectile.velocity.X += velocityOperand;

					if (Projectile.position.Y < Main.projectile[projectileIndex].position.Y)
						Projectile.velocity.Y -= velocityOperand;
					else
						Projectile.velocity.Y += velocityOperand;
				}
			}

			Vector2 vector = Projectile.position;
			float distance;

			distance = 1000f;
			bool is_target = false;
			Projectile.tileCollide = true;

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




			int limitDistanceBetweenplayerProj = 500;
			if (is_target)
				limitDistanceBetweenplayerProj = 1000;

			if (Vector2.Distance(player.Center, Projectile.Center) > limitDistanceBetweenplayerProj)
			{
				Projectile.ai[0] = 1f;
				Projectile.netUpdate = true;
			}

			if (Projectile.ai[0] == 1f)
				Projectile.tileCollide = false;

			if (is_target && Projectile.ai[0] == 0f)
			{
				Vector2 ToTarget = vector - Projectile.Center;
				float distanceProj2Target = ToTarget.Length();
				ToTarget.Normalize();

				if (distanceProj2Target > 200f)
				{
					float ToTargetVelocity = 6f;
					ToTarget *= ToTargetVelocity;
					Projectile.velocity.X = (Projectile.velocity.X * 40f + ToTarget.X) / 41f;
					Projectile.velocity.Y = (Projectile.velocity.Y * 40f + ToTarget.Y) / 41f;
				}
				else if (Projectile.velocity.Y > -1f)
				{
					Projectile.velocity.Y -= 0.1f;
				}
			}
			else
			{
				if (!Collision.CanHitLine(Projectile.Center, 1, 1, Main.player[Projectile.owner].Center, 1, 1))
					Projectile.ai[0] = 1f;

				float projPlaceSpeed = 6f;
				if (Projectile.ai[0] == 1f)
					projPlaceSpeed = 15f;


				Vector2 center2 = Projectile.Center;
				Vector2 aboveplayerHead = player.Center - center2 + new Vector2(0f, -60f);

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

			Projectile.rotation = Projectile.velocity.X * 0.05f;


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


			if (Projectile.velocity.X > 0f)
				Projectile.spriteDirection = Projectile.direction = -1;
			else if (Projectile.velocity.X < 0f)
				Projectile.spriteDirection = Projectile.direction = 1;

			if (Projectile.ai[1] > 0f)
				Projectile.ai[1] += Main.rand.Next(1, 4);

			if (Projectile.ai[1] > 90f)
			{
				Projectile.ai[1] = 0f;
				Projectile.netUpdate = true;
			}

			if (Projectile.ai[0] != 0f)
				return;

			float newProjSpeedMult = 10f;
			int new_projectile_type = ProjectileID.WaterStream;

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
		}
	}
}
