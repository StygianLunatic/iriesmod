using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using iriesmod.Common.players;
using iriesmod.Common.Utils;
using iriesmod.Content.Items.Equips.Armor.HiveSet;

namespace iriesmod.Content.Items.Equips.Armor.royalHiveSet
{
	[AutoloadEquip(EquipType.Body)]
	public class royalHive_breastplate : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Royal Hive Breastplate");
			Tooltip.SetDefault("Increases bee damage by 7%\nIncreases your max number of minions by 1");
		}

		public override void SetDefaults()
		{
			Item.width = 38;
			Item.height = 20;
			Item.value = Item.sellPrice(gold: 5);
			Item.rare = ItemRarityID.LightRed;
			Item.defense = 6;
		}

		public override void UpdateEquip(Player player)
		{
			iriesplayer modplayer = player.Getiriesplayer();
			modplayer.beeDamage += 0.07f;
			player.maxMinions++;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();

			recipe.AddIngredient(ModContent.ItemType<HiveBreastplate>());
			recipe.AddIngredient(ModContent.ItemType<Materials.QueenBeeStinger>(), 8);
			recipe.AddIngredient(ItemID.BeeWax, 18);
			recipe.AddIngredient(ModContent.ItemType<Materials.RoyalJelly>(), 6);

			recipe.AddTile(TileID.HoneyDispenser);

			recipe.Register();
		}
	}
}
