using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using iriesmod.Common.players;
using iriesmod.Common.Utils;
using iriesmod.Content.Items.Materials;

namespace iriesmod.Content.Items.Equips.Accessories.HoneyRoses
{
    public class HoneyRose : HoneyRose_Template
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Honey Rose");
			Tooltip.SetDefault("Increases life by 20\nIncreases life regen by 3 when you have Honey buff");
		}

		public override void SetDefaults()
		{
			Item.width = 34;
			Item.height = 30;
			Item.accessory = true;
			Item.value = Item.sellPrice(silver: 30);
			Item.rare = ItemRarityID.Blue;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			if (player.HasBuff(BuffID.Honey))
			{
				player.lifeRegen += 3;
			}
			player.statLifeMax2 += 20;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();

			recipe.AddIngredient(ItemID.JungleRose);
			recipe.AddIngredient(ItemID.HoneyBlock, 25);
			recipe.AddIngredient(ItemID.HoneyBucket, 5);

			recipe.AddTile(TileID.Anvils);

			recipe.Register();
		}
	}
}
