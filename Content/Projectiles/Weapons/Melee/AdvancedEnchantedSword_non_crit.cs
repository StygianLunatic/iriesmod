using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace iriesmod.Content.Projectiles.Weapons.Melee
{
	public class AdvancedEnchantedSword_non_crit : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("AdvancedEnchantedSword_non_critProjectile");
		}

		public override void SetDefaults()
		{
			Projectile.CloneDefaults(ProjectileID.EnchantedBeam);
			Projectile.width = 28;
			Projectile.height = 28;
			Projectile.DamageType = DamageClass.Melee;
			Projectile.penetrate = 2;
			Projectile.timeLeft = 600;
			AIType = ProjectileID.EnchantedBeam;
		}

		public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
		{
			crit = false;
		}
	}
}
