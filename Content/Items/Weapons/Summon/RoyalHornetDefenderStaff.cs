using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using iriesmod.Content.Items.Materials;
using Terraria.DataStructures;

namespace iriesmod.Content.Items.Weapons.Summon
{
	public class RoyalHornetDefenderStaff : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Royal Horent Defender Staff");
			Tooltip.SetDefault("Place a Royal Hornet Defender that throws bee hive into the enemy");
		}

		public override void SetDefaults()
		{
			Item.damage = 32;
			Item.knockBack = 3f;
			Item.mana = 10;
			Item.width = 56;
			Item.height = 52;
			Item.useTime = 30;
			Item.useAnimation = 30;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.value = Item.sellPrice(gold: 4, silver: 50);
			Item.rare = ItemRarityID.Orange;
			Item.UseSound = SoundID.Item44;

			Item.noMelee = true;
			Item.DamageType = DamageClass.Summon;
			Item.sentry = true;
			Item.shoot = ModContent.ProjectileType<Projectiles.Weapons.Summon.RoyalHornetDefender>();
		}

        public override bool Shoot(Player player, ProjectileSource_Item_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			Projectile.NewProjectile(source, Main.MouseWorld, Vector2.Zero, type, damage, knockback, player.whoAmI);
			player.UpdateMaxTurrets();

			return false;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();

			recipe.AddIngredient(ModContent.ItemType<QueenBeeStinger>(), 12);
			recipe.AddIngredient(ModContent.ItemType<RoyalJelly>(), 8);

			recipe.AddTile(TileID.HoneyDispenser);

			recipe.Register();
		}
	}
}
