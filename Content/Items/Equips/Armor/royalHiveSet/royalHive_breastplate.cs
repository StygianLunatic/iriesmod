using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using iriesmod.Common.Players;
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
			item.width = 38;
			item.height = 20;
			item.value = Item.sellPrice(gold: 5);
			item.rare = ItemRarityID.LightRed;
			item.defense = 6;
		}

		public override void UpdateEquip(Player player)
		{
			iriesplayer modPlayer = player.Getiriesplayer();
			modPlayer.beeDamage += 0.07f;
			player.maxMinions++;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);

			recipe.AddIngredient(ModContent.ItemType<HiveBreastplate>());
			recipe.AddIngredient(ModContent.ItemType<Materials.QueenBeeStinger>(), 8);
			recipe.AddIngredient(ItemID.BeeWax, 18);
			recipe.AddIngredient(ModContent.ItemType<Materials.RoyalJelly>(), 6);

			recipe.AddTile(TileID.HoneyDispenser);

			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
