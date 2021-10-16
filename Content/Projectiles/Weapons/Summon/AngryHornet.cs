using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace iriesmod.Content.Projectiles.Weapons.Summon
{
	public class AngryHornet : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Angry Hornet");

			Main.projFrames[projectile.type] = 3;
			ProjectileID.Sets.MinionTargettingFeature[projectile.type] = true;

			Main.projPet[projectile.type] = true;
			ProjectileID.Sets.MinionSacrificable[projectile.type] = true;
			ProjectileID.Sets.Homing[projectile.type] = true;
		}

		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.Hornet);
			aiType = ProjectileID.Hornet;
			// projectile.aiStyle = 62;
			projectile.friendly = true;
			projectile.minion = true;
			projectile.minionSlots = 1f;
			projectile.penetrate = -1;
			projectile.netImportant = true;
			projectile.tileCollide = false;
			projectile.ignoreWater = true;
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
				player.ClearBuff(ModContent.BuffType<Buffs.Minions.AngryHornet>());
			}
			if (player.HasBuff(ModContent.BuffType<Buffs.Minions.AngryHornet>()))
			{
				projectile.timeLeft = 2;
			}

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
