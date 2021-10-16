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

			Main.projFrames[projectile.type] = 3;
			ProjectileID.Sets.MinionTargettingFeature[projectile.type] = true;
			ProjectileID.Sets.MinionSacrificable[projectile.type] = true;
			ProjectileID.Sets.Homing[projectile.type] = true;
		}

		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.GiantBee);
			aiType = ProjectileID.GiantBee;
			projectile.scale = 0.6f;
			projectile.friendly = true;
			projectile.minion = true;
			projectile.minionSlots = 0f;
			projectile.penetrate = 3;
			projectile.netImportant = true;
			projectile.timeLeft = 600;
			projectile.tileCollide = false;
			projectile.ignoreWater = true;
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
			projectile.frameCounter++;
			if (projectile.frameCounter >= frameSpeed)
			{
				projectile.frameCounter = 0;
				projectile.frame++;
				if (projectile.frame >= Main.projFrames[projectile.type])
				{
					projectile.frame = 0;
				}
			}
		}
	}
}
