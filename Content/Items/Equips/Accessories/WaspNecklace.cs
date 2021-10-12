using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using iriesmod.Common.Players;
using iriesmod.Common.Utils;
using iriesmod.Content.Items.Materials;

namespace iriesmod.Content.Items.Equips.Accessories
{
	public class WaspNecklace : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Wasp Necklace");
			Tooltip.SetDefault("Increases bee damage by 10%\nIncreases armor penetration by 5\nIncreases your max number of minions by 1\nReleases bees, douses the user in honey and increases movement speed when damaged");
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
			modPlayer.beeDamage += 0.10f;
			modPlayer.WaspNecklace = true;

			player.armorPenetration += 10;
			player.maxMinions += 1;
			player.panic = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);

			recipe.AddIngredient(ItemID.SharkToothNecklace);
			recipe.AddIngredient(ItemID.HoneyComb);
			recipe.AddIngredient(ModContent.ItemType<BeeNecklace>());
			recipe.AddIngredient(ItemID.SweetheartNecklace);
			recipe.AddIngredient(ItemID.Bone, 25);
			recipe.AddTile(TileID.MythrilAnvil);

			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
