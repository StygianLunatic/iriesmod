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

			Main.projFrames[Projectile.type] = 3;
			ProjectileID.Sets.MinionTargettingFeature[Projectile.type] = true;

			Main.projPet[Projectile.type] = true;
			ProjectileID.Sets.MinionSacrificable[Projectile.type] = true;
			ProjectileID.Sets.CountsAsHoming[Projectile.type] = true;
		}

		public override void SetDefaults()
		{
			Projectile.CloneDefaults(ProjectileID.Hornet);
			AIType = ProjectileID.Hornet;
			// Projectile.aiStyle = 62;
			Projectile.friendly = true;
			Projectile.minion = true;
			Projectile.DamageType = DamageClass.Summon;
			Projectile.minionSlots = 1f;
			Projectile.penetrate = -1;
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
				player.ClearBuff(ModContent.BuffType<Buffs.Minions.AngryHornet>());
			}
			if (player.HasBuff(ModContent.BuffType<Buffs.Minions.AngryHornet>()))
			{
				Projectile.timeLeft = 2;
			}

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
