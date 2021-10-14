using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using iriesmod.Common.Players;
using iriesmod.Common.Utils;

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
			item.width = 22;
			item.height = 18;
			item.value = Item.sellPrice(gold: 5);
			item.rare = ItemRarityID.LightRed;
			item.defense = 5;
		}

		public override void UpdateEquip(Player player)
		{
			iriesplayer modPlayer = player.Getiriesplayer();
			modPlayer.beeDamage += 0.05f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);

			recipe.AddIngredient(ModContent.ItemType<HiveGreaves>());
			recipe.AddIngredient(ModContent.ItemType<Materials.QueenBeeStinger>(), 6);
			recipe.AddIngredient(ItemID.BeeWax, 14);
			recipe.AddIngredient(ModContent.ItemType<Materials.RoyalJelly>(), 6);

			recipe.AddTile(TileID.HoneyDispenser);

			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
