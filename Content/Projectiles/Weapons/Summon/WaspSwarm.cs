using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace iriesmod.Content.Projectiles.Weapons.Summon
{
	public class WaspSwarm : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Wasp Swarm");

			Main.projFrames[Projectile.type] = 3;
			ProjectileID.Sets.MinionTargettingFeature[Projectile.type] = true;
			ProjectileID.Sets.MinionSacrificable[Projectile.type] = true;
			ProjectileID.Sets.CountsAsHoming[Projectile.type] = true;
		}

		public override void SetDefaults()
		{
			Projectile.CloneDefaults(ProjectileID.GiantBee);
			AIType = ProjectileID.GiantBee;
			Projectile.scale = 0.6f;
			Projectile.friendly = true;
			Projectile.minion = true;
			Projectile.minionSlots = 0f;
			Projectile.penetrate = 3;
			Projectile.netImportant = true;
			Projectile.timeLeft = 600;
			Projectile.tileCollide = false;
			Projectile.ignoreWater = true;
		}

		public override bool? CanCutTiles()
		{
			return false;
		}
		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			return false;
		}

		public override void AI()
		{
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
	}
}
