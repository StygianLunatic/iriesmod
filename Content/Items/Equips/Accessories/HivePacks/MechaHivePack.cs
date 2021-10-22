using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using iriesmod.Common.players;
using iriesmod.Common.ID;
using iriesmod.Common.Utils;

namespace iriesmod.Content.Items.Equips.Accessories.HivePacks
{
	public class MechaHivePack : HivePackTemplate
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mecha Hive Pack");
			Tooltip.SetDefault("Increases the strength of friendly bees and wasps\n"
							 + "Friendly bee attacks inflict Cursed Inferno and Ichor");
		}

		public override void SetDefaults()
		{
			Item.width = 30;
			Item.height = 30;
			Item.maxStack = 1;
			Item.value = Item.sellPrice(gold: 20);
			Item.rare = ItemRarityID.LightRed;
			Item.accessory = true;
			Item.expert = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			iriesplayer modplayer = player.Getiriesplayer();

			player.strongBees = true;
			modplayer.BeeBackpack = irieItemID.MechaHivePack;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddRecipeGroup("AnyCursedFlameHivePack")
				.AddIngredient(ItemID.SoulofMight, 5)
				.AddIngredient(ItemID.SoulofSight, 5)
				.AddIngredient(ItemID.SoulofFright, 5)

				.AddTile(TileID.TinkerersWorkbench)

				.Register();
		}
	}
}
