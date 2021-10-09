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
	public class HoneyCloak : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Honey Cloak");
			Tooltip.SetDefault("Increases bee damage by 8%");
		}

		public override void SetDefaults()
		{
			item.width = 24;
			item.height = 30;
			item.accessory = true;
			item.value = Item.sellPrice(silver: 30);
			item.rare = ItemRarityID.Blue;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			iriesplayer.beeDamage += 0.08f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Stinger, 8);
			recipe.AddIngredient(ItemID.HoneyBlock, 18);
			recipe.AddIngredient(ItemID.Silk, 20);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
