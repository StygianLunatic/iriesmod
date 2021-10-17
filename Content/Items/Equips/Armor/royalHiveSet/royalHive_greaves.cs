using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using iriesmod.Common.players;
using iriesmod.Common.Utils;
using iriesmod.Content.Items.Equips.Armor.HiveSet;

namespace iriesmod.Content.Items.Equips.Armor.royalHiveSet
{
	[AutoloadEquip(EquipType.Legs)]
	public class royalHive_greaves : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Royal Hive Greaves");
			Tooltip.SetDefault("Increases bee damage by 5%");
		}

		public override void SetDefaults()
		{
			Item.width = 22;
			Item.height = 18;
			Item.value = Item.sellPrice(gold: 5);
			Item.rare = ItemRarityID.LightRed;
			Item.defense = 5;
		}

		public override void UpdateEquip(Player player)
		{
			iriesplayer modplayer = player.Getiriesplayer();
			modplayer.beeDamage += 0.05f;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();

			recipe.AddIngredient(ModContent.ItemType<HiveGreaves>());
			recipe.AddIngredient(ModContent.ItemType<Materials.QueenBeeStinger>(), 6);
			recipe.AddIngredient(ItemID.BeeWax, 14);
			recipe.AddIngredient(ModContent.ItemType<Materials.RoyalJelly>(), 6);

			recipe.AddTile(TileID.HoneyDispenser);

			recipe.Register();
		}
	}
}
