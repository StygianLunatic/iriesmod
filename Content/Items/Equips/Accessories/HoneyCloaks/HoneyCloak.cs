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

namespace iriesmod.Content.Items.Equips.Accessories.HoneyCloaks
{
	public class HoneyCloak : HoneyCloakTemplate
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Honey Cloak");
			Tooltip.SetDefault("Increases bee damage by 8%");
		}

		public override void SetDefaults()
		{
			Item.width = 24;
			Item.height = 30;
			Item.accessory = true;
			Item.value = Item.sellPrice(silver: 30);
			Item.rare = ItemRarityID.Blue;
			Item.defense = 4;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			iriesplayer modplayer = player.Getiriesplayer();

			modplayer.beeDamage += 0.08f;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Stinger, 4);
			recipe.AddIngredient(ItemID.HoneyBlock, 18);
			recipe.AddIngredient(ItemID.Silk, 20);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}
