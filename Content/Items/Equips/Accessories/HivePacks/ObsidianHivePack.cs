using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using iriesmod.Common.players;
using iriesmod.Common.ID;
using iriesmod.Common.Utils;

namespace iriesmod.Content.Items.Equips.Accessories.HivePacks
{
	public class ObsidianHivePack : HivePackTemplate
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Obsidian Hive Pack");
			Tooltip.SetDefault("Increases the strength of friendly bees and wasps\n"
							 + "Friendly bee attacks inflict fire damage");
		}

		public override void SetDefaults()
		{
			Item.width = 30;
			Item.height = 30;
			Item.maxStack = 1;
			Item.value = Item.sellPrice(gold: 2);
			Item.rare = ItemRarityID.LightRed;
			Item.accessory = true;
			Item.expert = true;
		}

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
			iriesplayer modplayer = player.Getiriesplayer();

			player.strongBees = true;
			modplayer.BeeBackpack = irieItemID.ObsidianHivePack;
        }

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();

			recipe.AddIngredient(ItemID.HiveBackpack);
			recipe.AddIngredient(ItemID.Bone, 25);
			recipe.AddIngredient(ItemID.Obsidian, 20);
			recipe.AddIngredient(ItemID.MagmaStone);
			recipe.AddTile(TileID.TinkerersWorkbench);

			recipe.Register();
		}
	}
}
