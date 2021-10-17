using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using iriesmod.Common.Players;
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
			item.width = 21;
			item.height = 27;
			item.accessory = true;
			item.value = Item.sellPrice(gold: 5);
			item.rare = ItemRarityID.Orange;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			iriesplayer modPlayer = player.Getiriesplayer();
			modPlayer.beeDamage += 0.08f;
			modPlayer.QueenStingerNecklace = true;
			player.armorPenetration += 8;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.SharkToothNecklace);
			recipe.AddIngredient(ItemID.HoneyComb, 2);
			recipe.AddIngredient(ModContent.ItemType<QueenBeeStinger>(), 12);
			recipe.AddTile(TileID.HoneyDispenser);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
