using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace iriesmod.Content.Items.Weapons.Summon
{
	public class HornetDefenderStaff : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Horent Defender Staff");
			Tooltip.SetDefault("Place a Hornet Defender that throws bee hive into the enemy");
		}

		public override void SetDefaults()
		{
			item.damage = 32;
			item.knockBack = 3f;
			item.mana = 10;
			item.width = 56;
			item.height = 52;
			item.useTime = 30;
			item.useAnimation = 30;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.value = Item.sellPrice(gold: 1, silver: 30);
			item.rare = ItemRarityID.Orange;
			item.UseSound = SoundID.Item44;

			item.noMelee = true;
			item.summon = true;
			item.sentry = true;
			item.shoot = ModContent.ProjectileType<Projectiles.Weapons.Summon.HornetDefender>();
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Projectile.NewProjectile(Main.MouseWorld, Vector2.Zero, type, damage, knockBack, player.whoAmI);
			player.UpdateMaxTurrets();

			return false;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);

			recipe.AddIngredient(ItemID.BeeWax, 18);
			recipe.AddIngredient(ItemID.Stinger, 6);

			recipe.AddTile(TileID.HoneyDispenser);

			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
