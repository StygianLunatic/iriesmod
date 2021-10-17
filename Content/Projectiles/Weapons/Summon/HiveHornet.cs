using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace iriesmod.Content.Projectiles.Weapons.Summon
{
	public class HiveHornet : ModProjectile
	{
        public override string Texture => "Terraria/Projectile_" + 198;
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Hive Hornet");

			Main.projFrames[projectile.type] = 4;
			ProjectileID.Sets.MinionTargettingFeature[projectile.type] = true;
			ProjectileID.Sets.MinionSacrificable[projectile.type] = true;
			ProjectileID.Sets.Homing[projectile.type] = true;
		}

		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.Bee);
			aiType = ProjectileID.Bee;
			projectile.friendly = true;
			projectile.minion = true;
			projectile.minionSlots = 0f;
			projectile.penetrate = 3;
			projectile.netImportant = true;
			projectile.tileCollide = true;
			projectile.ignoreWater = true;
			projectile.scale = 1f;
			projectile.timeLeft = 360;
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

			Color drawColor = projectile.GetAlpha(lightColor);
			Main.spriteBatch.Draw(texture,
			 	projectile.Center - Main.screenPosition + new Vector2(0f, projectile.gfxOffY),
			 	sourceRectangle, drawColor, projectile.rotation, origin, projectile.scale, spriteEffects, 0f);

			return false;
		}

		public override bool? CanCutTiles()
		{
			return false;
		}
		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			return false;
		}
	}
}
