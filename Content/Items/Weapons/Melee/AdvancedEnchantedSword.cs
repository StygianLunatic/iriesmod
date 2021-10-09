using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using iriesmod.Content.Projectiles.Weapons.Melee;
using System;

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
			item.width = 56;
			item.height = 57;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.useTime = 30;
			item.useAnimation = 30;
			item.autoReuse = true;
			item.melee = true;
			item.damage = 50;
			item.knockBack = 6;
			item.crit = 10;
			item.value = Item.sellPrice(gold: 15);
			item.rare = ItemRarityID.Pink;
			item.UseSound = SoundID.Item1;
			
			item.shoot = ModContent.ProjectileType<AdvancedEnchantedSword_non_crit>();
			item.shootSpeed = 13f;
		}

		
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            type = (Main.rand.Next(1, 101) >= player.meleeCrit) ? ModContent.ProjectileType<AdvancedEnchantedSword_non_crit>() : ModContent.ProjectileType<AdvancedEnchantedSword_crit>();
			int projectile = Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage, knockBack, Main.myPlayer, 0f, 0f);

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
			ModRecipe recipe = new ModRecipe(mod);

			recipe.AddIngredient(ItemID.EnchantedSword);
			recipe.AddIngredient(ItemID.SoulofLight, 5);
			recipe.AddIngredient(ItemID.SoulofNight, 5);
			recipe.AddTile(TileID.MythrilAnvil);

			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
