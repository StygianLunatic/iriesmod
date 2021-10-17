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
using iriesmod.Content.Items.Materials;

namespace iriesmod.Content.Items.Equips.Accessories.BeeNecklace
{
	public class QueenBeeNecklace : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Queen Bee Necklace");
			Tooltip.SetDefault("Increases bee damage by 12%\nIncreases your max number of minions and sentries by 1");
		}

		public override void SetDefaults()
		{
			Item.width = 32;
			Item.height = 32;
			Item.accessory = true;
			Item.value = Item.sellPrice(gold: 2, silver: 60);
			Item.rare = ItemRarityID.Orange;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			iriesplayer modplayer = player.Getiriesplayer();
			modplayer.beeDamage += 0.12f;
			player.maxMinions++;
			player.maxTurrets++;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();

			recipe.AddIngredient(ModContent.ItemType<HornetNecklace>());
			recipe.AddIngredient(ModContent.ItemType<QueenBeeStinger>(), 12);
			recipe.AddIngredient(ModContent.ItemType<RoyalJelly>(), 8);

			recipe.AddTile(TileID.HoneyDispenser);

			recipe.Register();
		}
	}
}
