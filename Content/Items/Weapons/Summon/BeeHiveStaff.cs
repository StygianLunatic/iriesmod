using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace iriesmod.Content.Items.Weapons.Summon
{
    public class BeeHiveStaff : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bee Hive Staff");
			Tooltip.SetDefault("Place a bee hive don't want to be annoyed");
		}

		public override void SetDefaults()
		{
			Item.damage = 6;
			Item.knockBack = 3f;
			Item.mana = 10;
			Item.width = 34;
			Item.height = 34;
			Item.useTime = 36;
			Item.useAnimation = 36;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.value = Item.sellPrice(gold: 1, silver: 30);
			Item.rare = ItemRarityID.Orange;
			Item.UseSound = SoundID.Item44;

			Item.noMelee = true;
			Item.DamageType = DamageClass.Summon;
			Item.sentry = true;
			Item.shoot = ModContent.ProjectileType<Projectiles.Weapons.Summon.BeeHiveStaffProj>();
		}

        public override bool Shoot(Player player, ProjectileSource_Item_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			var projectile = Projectile.NewProjectileDirect(source, Main.MouseWorld, Vector2.Zero, type, damage, knockback, player.whoAmI);
			projectile.originalDamage = Item.damage;

			player.UpdateMaxTurrets();

			return false;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();

			recipe.AddIngredient(ItemID.BeeWax, 18);
			recipe.AddIngredient(ItemID.Hive, 8);
			recipe.AddIngredient(ItemID.HoneyBlock, 8);

			recipe.AddTile(TileID.HoneyDispenser);

			recipe.Register();
		}
	}
}
