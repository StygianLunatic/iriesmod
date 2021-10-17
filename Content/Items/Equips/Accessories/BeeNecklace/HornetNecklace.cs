using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using iriesmod.Common.players;
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
			Item.width = 32;
			Item.height = 32;
			Item.accessory = true;
			Item.value = Item.sellPrice(silver: 60);
			Item.rare = ItemRarityID.Green;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			iriesplayer modplayer = player.Getiriesplayer();
			modplayer.beeDamage += 0.08f;
			player.maxMinions++;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();

			recipe.AddIngredient(ModContent.ItemType<BeeNecklace>());
			recipe.AddIngredient(ItemID.BeeWax, 18);

			recipe.AddTile(TileID.HoneyDispenser);

			recipe.Register();
		}
	}
}
