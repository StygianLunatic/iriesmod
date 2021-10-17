using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace iriesmod.Content.Items.Equips.Accessories
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
			Item.width = 26;
			Item.height = 30;
			Item.accessory = true;
			Item.value = Item.sellPrice(gold: 20);
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.aggro -= 400;
			player.GetDamage(DamageClass.Generic) += 0.05f;
			player.GetCritChance(DamageClass.Generic) += 5;
			player.kbGlove = true;
			player.meleeSpeed += 0.12f;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();

			recipe.AddIngredient(ItemID.PowerGlove);
			recipe.AddIngredient(ItemID.PutridScent);
			recipe.AddTile(TileID.TinkerersWorkbench);

			recipe.Register();
		}
	}
}
