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
			projectile.CloneDefaults(ProjectileID.EnchantedBeam);
			projectile.width = 28;
			projectile.height = 28;
			projectile.melee = true;
			projectile.penetrate = 2;
			projectile.timeLeft = 600;
			aiType = ProjectileID.EnchantedBeam;
		}

		public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
		{
			crit = false;
		}
	}
}
