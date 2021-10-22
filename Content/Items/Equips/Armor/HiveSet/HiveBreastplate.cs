using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using iriesmod.Common.players;
using iriesmod.Common.Utils;

namespace iriesmod.Content.Items.Equips.Armor.HiveSet
{
	[AutoloadEquip(EquipType.Body)]
	public class HiveBreastplate : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Hive Breastplate");
			Tooltip.SetDefault("Increases bee damage by 4%\nIncreases your max number of minions by 1");
		}

		public override void SetDefaults()
		{
			Item.width = 30;
			Item.height = 20;
			Item.value = Item.sellPrice(silver: 50);
			Item.rare = ItemRarityID.Green;
			Item.defense = 4;
		}

		public override void UpdateEquip(Player player)
		{
			iriesplayer modplayer = player.Getiriesplayer();
			modplayer.beeDamage += 0.04f;
			player.maxMinions++;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Stinger, 4);
			recipe.AddIngredient(ItemID.Hive, 20);
			recipe.AddIngredient(ItemID.HoneyBlock, 12);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}