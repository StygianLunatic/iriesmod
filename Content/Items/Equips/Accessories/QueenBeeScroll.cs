using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using iriesmod.Common.players;
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
			Item.width = 36;
			Item.height = 36;
			Item.accessory = true;
			Item.value = Item.sellPrice(gold: 50);
			Item.rare = ItemRarityID.Blue;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			iriesplayer modplayer = player.Getiriesplayer();
			modplayer.beeDamage += 0.15f;
			modplayer.QueenBeeScroll = Item;

			player.maxMinions += 2;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();

			recipe.AddIngredient(ItemID.PapyrusScarab);
			recipe.AddIngredient(ItemID.HoneyComb);
			recipe.AddIngredient(ModContent.ItemType<QueenBeeStinger>(), 20);
			recipe.AddIngredient(ItemID.Stinger, 12);
			recipe.AddTile(TileID.MythrilAnvil);

			recipe.Register();
		}
	}
}
