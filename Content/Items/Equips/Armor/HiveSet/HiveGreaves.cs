using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using iriesmod.Common.players;
using iriesmod.Common.Utils;

namespace iriesmod.Content.Items.Equips.Armor.HiveSet
{
	[AutoloadEquip(EquipType.Legs)]
	public class HiveGreaves : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Hive Greaves");
			Tooltip.SetDefault("Increases bee damage by 2%");
		}

		public override void SetDefaults()
		{
			Item.width = 22;
			Item.height = 18;
			Item.value = Item.sellPrice(silver: 50);
			Item.rare = ItemRarityID.Green;
			Item.defense = 3;
		}

		public override void UpdateEquip(Player player)
		{
			iriesplayer modplayer = player.Getiriesplayer();
			modplayer.beeDamage += 0.02f;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Stinger, 2);
			recipe.AddIngredient(ItemID.Hive, 16);
			recipe.AddIngredient(ItemID.HoneyBlock, 10);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}