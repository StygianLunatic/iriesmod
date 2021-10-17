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
    public class BeeNecklace : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bee Necklace");
			Tooltip.SetDefault("Increases bee damage by 5%\nIncreases your max number of minions by 1");
		}

		public override void SetDefaults()
		{
			Item.width = 22;
			Item.height = 30;
			Item.accessory = true;
			Item.value = Item.sellPrice(silver: 30);
			Item.rare = ItemRarityID.Blue;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			iriesplayer modplayer = player.Getiriesplayer();
			modplayer.beeDamage += 0.05f;
			player.maxMinions++;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Stinger, 6);
			recipe.AddIngredient(ItemID.Vine, 2);
			recipe.AddIngredient(ItemID.Hive, 5);
			recipe.AddIngredient(ItemID.HoneyBlock, 5);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}
