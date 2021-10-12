using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace iriesmod.Common.Players
{
    public class DashPlayer : ModPlayer
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

			if (player.controlRight && player.releaseRight && player.doubleTapCardinalTimer[DashRight] < 15)
			{
				DashDir = DashRight;
			}
			else if (player.controlLeft && player.releaseLeft && player.doubleTapCardinalTimer[DashLeft] < 15)
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
				Vector2 newVelocity = player.velocity;

				switch (DashDir)
				{
					case DashLeft when player.velocity.X > -DashVelocity:
					case DashRight when player.velocity.X < DashVelocity:
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
				player.velocity = newVelocity;
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


				player.eocDash = DashTimer;
				player.armorEffectDrawShadowEOCShield = true;


				DashTimer--;
			}
		}

		private bool CanUseDash()
		{
				return DashAccessoryEquipped
				&& player.dash == 0 // player doesn't have Tabi or EoCShield equipped (give priority to those dashes)
				&& !player.setSolar // player isn't wearing solar armor
				&& !player.mount.Active; // player isn't mounted, since dashes on a mount look weird
		}

		private void DoCollisionAttack(float damage, float knockback)
        {
			if (player.whoAmI == Main.myPlayer)
            {
				Rectangle rectangle = new Rectangle((int)((double)player.position.X + (double)player.velocity.X * 0.5 - 4.0), (int)((double)player.position.Y + (double)player.velocity.Y * 0.5 - 4.0), player.width + 8, player.height + 8);
				for (int i = 0; i < Main.npc.Length; i++)
				{
					NPC nPC = Main.npc[i];
					if (!nPC.active || nPC.dontTakeDamage || nPC.friendly)
						continue;

					Rectangle rect = nPC.getRect();
					if (rectangle.Intersects(rect) && (nPC.noTileCollide || player.CanHit(nPC)))
					{
						float shield_damage = damage * player.meleeDamage * player.allDamage;
						float shield_knockback = knockback;

						if (player.kbBuff)
						{
							shield_knockback *= 1.5f;
						}
						if (player.kbGlove)
						{
							shield_knockback *= 2f;
						}
						bool crit = false;

						if (Main.rand.Next(100) < player.meleeCrit)
							crit = true;

						int Direc = player.direction;
						if (player.velocity.X < 0f)
							Direc = -1;

						if (player.velocity.X > 0f)
							Direc = 1;

						if (player.whoAmI == Main.myPlayer)
							player.ApplyDamageToNPC(nPC, (int)shield_damage, shield_knockback, Direc, crit);

						player.velocity.X = -Direc * 5;
						player.velocity.Y = -2f;
						player.immuneTime += 4;
					}
				}
			}
			CanDashAttack = false;
		}
	}
}
