using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using iriesmod.Common.Players;
using iriesmod.Common.Utils;

namespace iriesmod.Content.Items.Equips.Accessories.BeeNecklace
{
	public class HornetNecklace : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Hornet Necklace");
			Tooltip.SetDefault("Increases bee damage by 8%\nIncreases your max number of minions by 1");
		}

		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 30;
			item.accessory = true;
			item.value = Item.sellPrice(silver: 60);
			item.rare = ItemRarityID.Green;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			iriesplayer modPlayer = player.Getiriesplayer();
			modPlayer.beeDamage += 0.08f;
			player.maxMinions++;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);

			recipe.AddIngredient(ModContent.ItemType<BeeNecklace>());
			recipe.AddIngredient(ItemID.BeeWax, 18);

			recipe.AddTile(TileID.HoneyDispenser);

			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
