using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using iriesmod.Common.Players;
using iriesmod.Common.Utils;
using iriesmod.Content.Items.Materials;

namespace iriesmod.Content.Items.Equips.Accessories.HoneyRose
{
	public class HoneyRose : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Honey Rose");
			Tooltip.SetDefault("Increases life by 20\nIncreases life regen by 3 when you have Honey buff");
		}

		public override void SetDefaults()
		{
			item.width = 34;
			item.height = 30;
			item.accessory = true;
			item.value = Item.sellPrice(silver: 30);
			item.rare = ItemRarityID.Blue;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			iriesplayer modPlayer = player.Getiriesplayer();
			modPlayer.HoneyRose = true;

			player.statLifeMax2 += 20;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);

			recipe.AddIngredient(ItemID.JungleRose);
			recipe.AddIngredient(ItemID.HoneyBlock, 25);
			recipe.AddIngredient(ItemID.HoneyBucket, 5);

			recipe.AddTile(TileID.Anvils);

			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
