using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using iriesmod.Common.players;
using iriesmod.Common.ID;
using iriesmod.Common.Utils;

namespace iriesmod.Content.Items.Equips.Accessories.HivePacks
{
	public class CursedFlameHivePack : HivePackTemplate
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cursed Flame Hive Pack");
			Tooltip.SetDefault("Increases the strength of friendly bees and wasps\n"
							 + "Friendly bee attacks inflict Cursed Inferno");
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
			modplayer.BeeBackpack = irieItemID.CursedFlameHivePack;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();

			recipe.AddIngredient(ModContent.ItemType<ObsidianHivePack>());
			recipe.AddIngredient(ItemID.SoulofNight, 12);
			recipe.AddIngredient(ItemID.CursedFlame, 30);
			recipe.AddTile(TileID.TinkerersWorkbench);

			recipe.Register();
		}
	}
}
