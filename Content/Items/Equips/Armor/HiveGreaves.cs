﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using iriesmod.Common.Players;

namespace iriesmod.Content.Items.Equips.Armor
{
	[AutoloadEquip(EquipType.Legs)]
	public class HiveGreaves : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Hive Greaves");
			Tooltip.SetDefault("Increases bee damage by 2%");
		}

		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 18;
			item.value = Item.sellPrice(silver: 50);
			item.rare = ItemRarityID.Green;
		}

		public override void UpdateEquip(Player player)
		{
			iriesplayer.beeDamage += 0.02f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Stinger, 6);
			recipe.AddIngredient(ItemID.Hive, 16);
			recipe.AddIngredient(ItemID.HoneyBlock, 10);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}