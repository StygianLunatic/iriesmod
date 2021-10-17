using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace iriesmod.Common.players
{
    public class Dashplayer : ModPlayer
    {
		public const int DashRight = 2;
		public const int DashLeft = 3;

		public const int DashCooldown = 50;
		public const int DashDuration = 35;

		public float DashVelocity;

		public int DashDir = -1;

		public bool DashAccessoryEquipped;
		public int DashDelay = 0;
		public int DashTimer = 0;

		public float collisionDamage;
		public float collisionKnockback;
		public bool CanDashAttack;

		public override void ResetEffects()
		{
			DashVelocity = 0;
			DashAccessoryEquipped = false;

			collisionDamage = 0;
			collisionKnockback = 0;
			CanDashAttack = false;

			if (Player.controlRight && Player.releaseRight && Player.doubleTapCardinalTimer[DashRight] < 15)
			{
				DashDir = DashRight;
			}
			else if (Player.controlLeft && Player.releaseLeft && Player.doubleTapCardinalTimer[DashLeft] < 15)
			{
				DashDir = DashLeft;
			}
			else
			{
				DashDir = -1;
			}
		}

		public override void PreUpdateMovement()
		{
			if (CanUseDash() && DashDir != -1 && DashDelay == 0)
			{
				Vector2 newVelocity = Player.velocity;

				switch (DashDir)
				{
					case DashLeft when Player.velocity.X > -DashVelocity:
					case DashRight when Player.velocity.X < DashVelocity:
						{
							float dashDirection = DashDir == DashRight ? 1 : -1;
							newVelocity.X = dashDirection * DashVelocity;
							break;
						}
					default:
						return;
				}

				DashDelay = DashCooldown;
				DashTimer = DashDuration;
				Player.velocity = newVelocity;
				CanDashAttack = true;
			}



			if (DashDelay > 0)
				DashDelay--;

			if (DashTimer > 0)
			{
				if (CanDashAttack)
                {
					DoCollisionAttack(collisionDamage, collisionKnockback);
				}


				Player.eocDash = DashTimer;
				Player.armorEffectDrawShadowEOCShield = true;


				DashTimer--;
			}
		}

		private bool CanUseDash()
		{
				return DashAccessoryEquipped
				&& Player.dash == 0 // Player doesn't have Tabi or EoCShield equipped (give priority to those dashes)
				&& !Player.setSolar // Player isn't wearing solar armor
				&& !Player.mount.Active; // Player isn't mounted, since dashes on a mount look weird
		}

		private void DoCollisionAttack(float damage, float knockback)
        {
			if (Player.whoAmI == Main.myPlayer)
            {
				Rectangle rectangle = new Rectangle((int)((double)Player.position.X + (double)Player.velocity.X * 0.5 - 4.0), (int)((double)Player.position.Y + (double)Player.velocity.Y * 0.5 - 4.0), Player.width + 8, Player.height + 8);
				for (int i = 0; i < Main.npc.Length; i++)
				{
					NPC nPC = Main.npc[i];
					if (!nPC.active || nPC.dontTakeDamage || nPC.friendly)
						continue;

					Rectangle rect = nPC.getRect();
					if (rectangle.Intersects(rect) && (nPC.noTileCollide || Player.CanHit(nPC)))
					{
						float shield_damage = damage * Player.GetDamage(DamageClass.Melee).CombineWith(Player.GetDamage(DamageClass.Generic));
						float shield_knockback = knockback;

						if (Player.kbBuff)
						{
							shield_knockback *= 1.5f;
						}
						if (Player.kbGlove)
						{
							shield_knockback *= 2f;
						}
						bool crit = false;

						if (Main.rand.Next(100) < Player.GetCritChance(DamageClass.Melee))
							crit = true;

						int Direc = Player.direction;
						if (Player.velocity.X < 0f)
							Direc = -1;

						if (Player.velocity.X > 0f)
							Direc = 1;

						if (Player.whoAmI == Main.myPlayer)
							Player.ApplyDamageToNPC(nPC, (int)shield_damage, shield_knockback, Direc, crit);

						Player.velocity.X = -Direc * 5;
						Player.velocity.Y = -2f;
						Player.immuneTime += 4;
					}
				}
			}
			CanDashAttack = false;
		}
	}
}
