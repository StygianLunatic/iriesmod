using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using iriesmod.Common.Players;
using iriesmod.Common.ID;

namespace iriesmod.Content.Items.Equips.Accessories
{
	public class ObsidianHivePack : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Obsidian Hive Pack");
			Tooltip.SetDefault("Increases the strength of friendly bees and wasps\n"
							 + "Friendly bee attacks inflict fire damage");
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
			iriesplayer.BeeBackpack = irieItemID.ObsidianHivePack;
        }

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);

			recipe.AddIngredient(ItemID.HiveBackpack);
			recipe.AddIngredient(ItemID.Bone, 25);
			recipe.AddIngredient(ItemID.Obsidian, 20);
			recipe.AddIngredient(ItemID.MagmaStone);
			recipe.AddTile(TileID.TinkerersWorkbench);

			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
