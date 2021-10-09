using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace iriesserver.Items.Equips.Accessories
{
	public class PutridGauntlet : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Putrid Gauntlet");
			Tooltip.SetDefault("Enemies are less likely to target you\n"
							 + "5% increased damage and critical strike chance\n"
							 + "Increases melee knockback\n"
							 + "12% increased melee speed");
		}

		public override void SetDefaults()
		{
			item.width = 26;
			item.height = 30;
			item.accessory = true;
			item.value = Item.sellPrice(gold: 20);
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.aggro -= 400;
			player.allDamage += 0.05f;
			player.magicCrit += 5;
			player.meleeCrit += 5;
			player.rangedCrit += 5;
			player.thrownCrit += 5;
			player.kbGlove = true;
			player.meleeSpeed += 0.12f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);

			recipe.AddIngredient(ItemID.PowerGlove);
			recipe.AddIngredient(ItemID.PutridScent);
			recipe.AddTile(TileID.TinkerersWorkbench);

			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
