using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using iriesmod.Common.Players;

namespace iriesmod.Content.Items.Equips.Accessories
{
    public class BeeNecklace : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bee Necklace");
			Tooltip.SetDefault("Increases bee damage by 5%\nIncreases your max number of minions by 1");
		}

		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 30;
			item.accessory = true;
			item.value = Item.sellPrice(silver: 30);
			item.rare = ItemRarityID.Blue;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			iriesplayer.beeDamage += 0.05f;
			player.maxMinions++;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Stinger, 12);
			recipe.AddIngredient(ItemID.Vine, 2);
			recipe.AddIngredient(ItemID.Hive, 5);
			recipe.AddIngredient(ItemID.HoneyBlock, 5);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
