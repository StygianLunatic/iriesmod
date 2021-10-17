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
        public override string Texture => "Terraria/Images/Projectile_" + 198;
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Hive Hornet");

			Main.projFrames[Projectile.type] = 4;
			ProjectileID.Sets.MinionTargettingFeature[Projectile.type] = true;
			ProjectileID.Sets.MinionSacrificable[Projectile.type] = true;
			ProjectileID.Sets.CountsAsHoming[Projectile.type] = true;
		}

		public override void SetDefaults()
		{
			Projectile.CloneDefaults(ProjectileID.Bee);
			AIType = ProjectileID.Bee;
			Projectile.friendly = true;
			Projectile.minion = true;
			Projectile.minionSlots = 0f;
			Projectile.penetrate = 3;
			Projectile.netImportant = true;
			Projectile.tileCollide = true;
			Projectile.ignoreWater = true;
			Projectile.scale = 1f;
			Projectile.timeLeft = 360;
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

			Color drawColor = Projectile.GetAlpha(lightColor);
			Main.spriteBatch.Draw(texture,
			 	Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY),
			 	sourceRectangle, drawColor, Projectile.rotation, origin, Projectile.scale, spriteEffects, 0f);

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
