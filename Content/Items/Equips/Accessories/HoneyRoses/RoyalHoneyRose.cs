using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using iriesmod.Common.Players;
using iriesmod.Common.Utils;
using iriesmod.Content.Items.Materials;

namespace iriesmod.Content.Items.Equips.Accessories.HoneyRoses
{
    public class RoyalHoneyRose : HoneyRose_Template
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Royal Honey Rose");
			Tooltip.SetDefault("Increases life regen by 6 and reduce damage taken by 10% when you have Honey buff");
		}

		public override void SetDefaults()
		{
			item.width = 34;
			item.height = 30;
			item.accessory = true;
			item.value = Item.sellPrice(gold: 2);
			item.rare = ItemRarityID.Orange;
			item.defense = 7;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			if (player.HasBuff(BuffID.Honey))
			{
				player.lifeRegen += 6;
				player.endurance += 0.1f;
			}
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);

			recipe.AddIngredient(ModContent.ItemType<HoneyRose>());
			recipe.AddIngredient(ModContent.ItemType<RoyalJelly>(), 12);
			recipe.AddIngredient(ItemID.HoneyBlock, 25);
			recipe.AddIngredient(ItemID.HoneyBucket, 5);

			recipe.AddTile(TileID.HoneyDispenser);

			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
