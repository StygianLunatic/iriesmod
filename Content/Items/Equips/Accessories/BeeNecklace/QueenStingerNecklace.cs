using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using iriesmod.Common.players;
using iriesmod.Common.Utils;
using iriesmod.Content.Items.Materials;

namespace iriesmod.Content.Items.Equips.Accessories.BeeNecklace
{
	public class QueenStingerNecklace : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Queen Stinger Necklace");
			Tooltip.SetDefault("Increases bee damage by 8%\nIncreases armor penetration by 8\nReleases bees and douses the user in honey when damaged");
		}

		public override void SetDefaults()
		{
			Item.width = 21;
			Item.height = 27;
			Item.accessory = true;
			Item.value = Item.sellPrice(gold: 5);
			Item.rare = ItemRarityID.Orange;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			iriesplayer modplayer = player.Getiriesplayer();
			modplayer.beeDamage += 0.08f;
			modplayer.QueenStingerNecklace = Item;
			player.armorPenetration += 8;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.StingerNecklace);
			recipe.AddIngredient(ItemID.HoneyComb);
			recipe.AddIngredient(ModContent.ItemType<QueenBeeStinger>(), 12);
			recipe.AddTile(TileID.HoneyDispenser);
			recipe.Register();
		}
	}
}
