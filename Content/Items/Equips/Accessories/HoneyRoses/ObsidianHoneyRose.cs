using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using iriesmod.Common.Players;
using iriesmod.Common.Utils;
using iriesmod.Content.Items.Materials;

namespace iriesmod.Content.Items.Equips.Accessories.HoneyRoses
{
    public class ObsidianHoneyRose : HoneyRose_Template
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Obsidian Honey Rose");
			Tooltip.SetDefault("Reduces damage from touching lava\nIncreases life regen by 8 and reduce damage taken by 15% when you have Honey buff");
		}

		public override void SetDefaults()
		{
			item.width = 34;
			item.height = 30;
			item.accessory = true;
			item.value = Item.sellPrice(gold: 3);
			item.rare = ItemRarityID.Orange;
			item.defense = 9;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			if (player.HasBuff(BuffID.Honey))
			{
				player.lifeRegen += 8;
				player.endurance += 0.15f;
			}
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);

			recipe.AddIngredient(ModContent.ItemType<RoyalHoneyRose>());
			recipe.AddIngredient(ItemID.ObsidianRose);
			recipe.AddIngredient(ItemID.Obsidian, 25);
			recipe.AddIngredient(ItemID.HellstoneBar, 10);

			recipe.AddTile(TileID.HoneyDispenser);

			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
