using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using iriesmod.Content.Projectiles.Weapons.Melee;
using System;
using Terraria.DataStructures;

namespace iriesmod.Content.Items.Weapons.Melee
{
	public class AdvancedEnchantedSword : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Advanced Enchanted Sword");
			Tooltip.SetDefault("Shoot Projectile");
		}

		public override void SetDefaults()
		{
			Item.width = 56;
			Item.height = 57;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.useTime = 30;
			Item.useAnimation = 30;
			Item.autoReuse = true;
			Item.DamageType = DamageClass.Melee;
			Item.damage = 50;
			Item.knockBack = 6;
			Item.crit = 10;
			Item.value = Item.sellPrice(gold: 15);
			Item.rare = ItemRarityID.Pink;
			Item.UseSound = SoundID.Item1;
			
			Item.shoot = ModContent.ProjectileType<AdvancedEnchantedSword_non_crit>();
			Item.shootSpeed = 13f;
		}


		public override bool Shoot(Player player, ProjectileSource_Item_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			type = (Main.rand.Next(1, 101) >= player.GetCritChance(DamageClass.Melee) ? ModContent.ProjectileType<AdvancedEnchantedSword_non_crit>() : ModContent.ProjectileType<AdvancedEnchantedSword_crit>());
			int projectile = Projectile.NewProjectile(source, position.X, position.Y, velocity.X, velocity.Y, type, damage, knockback, Main.myPlayer, 0f, 0f);

			return false;
        }
		

        public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.NextBool(3))
			{
				Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.SpelunkerGlowstickSparkle);
			}
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();

			recipe.AddIngredient(ItemID.EnchantedSword);
			recipe.AddIngredient(ItemID.SoulofLight, 5);
			recipe.AddIngredient(ItemID.SoulofNight, 5);
			recipe.AddTile(TileID.MythrilAnvil);

			recipe.Register();
		}
	}
}
