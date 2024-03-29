﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace iriesmod.Content.Projectiles.Weapons.Bees
{
	public class beeBeetle : ModProjectile
	{
		public override string Texture => "Terraria/" + "BeetleOrb";
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("beeBeetle");
		}

		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.GiantBee);
			projectile.scale = 1f;
			projectile.minion = true;
			aiType = ProjectileID.GiantBee;
			Main.projFrames[projectile.type] = 3;
			projectile.penetrate = 3;

		}
		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			return false;
		}
	}
}
