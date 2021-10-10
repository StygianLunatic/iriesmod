using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using iriesmod.Common.Players;
using iriesmod.Common.ID;

namespace iriesmod.Content.Items.Equips.Accessories
{
	public class CursedFlameHivePack : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cursed Flame Hive Pack");
			Tooltip.SetDefault("Increases the strength of friendly bees and wasps\n"
							 + "Friendly bee attacks inflict cursed inferno");
		}

		public override void SetDefaults()
		{
			item.width = 30;
			item.height = 30;
			item.maxStack = 1;
			item.value = Item.sellPrice(gold: 2);
			item.rare = ItemRarityID.LightRed;
			item.accessory = true;
			item.expert = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.strongBees = true;
			iriesplayer.BeeBackpack = irieItemID.CursedFlameHivePack;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);

			recipe.AddIngredient(ModContent.ItemType<ObsidianHivePack>());
			recipe.AddIngredient(ItemID.SoulofNight, 12);
			recipe.AddIngredient(ItemID.CursedFlame, 30);
			recipe.AddTile(TileID.TinkerersWorkbench);

			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
