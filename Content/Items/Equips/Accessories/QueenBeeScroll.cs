﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using iriesmod.Common.Players;
using iriesmod.Common.Utils;
using iriesmod.Content.Items.Materials;

namespace iriesmod.Content.Items.Equips.Accessories
{
    public class QueenBeeScroll : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Queen Bee Scroll");
			Tooltip.SetDefault("Increases bee damage by 15%\nIncreases your max number of minions by 2\nReleases bees and douses the user in honey when damaged");
		}

		public override void SetDefaults()
		{
			item.width = 36;
			item.height = 36;
			item.accessory = true;
			item.value = Item.sellPrice(silver: 30);
			item.rare = ItemRarityID.Blue;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			iriesplayer modPlayer = player.Getiriesplayer();
			modPlayer.beeDamage += 0.15f;
			modPlayer.QueenBeeScroll = true;

			player.maxMinions += 2;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);

			recipe.AddIngredient(ItemID.PapyrusScarab);
			recipe.AddIngredient(ItemID.HoneyComb);
			recipe.AddIngredient(ModContent.ItemType<QueenBeeStinger>(), 20);
			recipe.AddIngredient(ItemID.Stinger, 12);
			recipe.AddTile(TileID.MythrilAnvil);

			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
