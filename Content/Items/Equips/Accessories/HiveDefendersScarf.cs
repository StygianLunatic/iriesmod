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

namespace iriesmod.Content.Items.Equips.Accessories
{
	public class HiveDefendersScarf : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Hive Defender's Scarf");
			Tooltip.SetDefault("Increases bee damage by 10%\nIncreases your max number of sentries by 1\nReduces damage taken by 15%");
		}

		public override void SetDefaults()
		{
			Item.width = 24;
			Item.height = 26;
			Item.accessory = true;
			Item.value = Item.sellPrice(gold: 4);
			Item.rare = ItemRarityID.Orange;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			iriesplayer modplayer = player.Getiriesplayer();

			modplayer.beeDamage += 0.1f;
			player.maxTurrets++;
			player.endurance += 0.15f;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.WormScarf);
			recipe.AddIngredient(ItemID.BeeWax, 18);
			recipe.AddIngredient(ModContent.ItemType<Items.Materials.RoyalJelly>(), 10);

			recipe.AddTile(TileID.HoneyDispenser);

			recipe.Register();
		}
	}
}
