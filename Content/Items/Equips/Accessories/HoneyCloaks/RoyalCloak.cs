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

namespace iriesmod.Content.Items.Equips.Accessories.HoneyCloaks
{
	public class RoyalCloak : HoneyCloakTemplate
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Royal Cloak");
			Tooltip.SetDefault("Increases bee damage by 10%\nReleases bees and douses the user in honey when damaged");
		}

		public override void SetDefaults()
		{
			item.width = 24;
			item.height = 30;
			item.accessory = true;
			item.value = Item.sellPrice(gold: 4);
			item.rare = ItemRarityID.Orange;
			item.defense = 5;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			iriesplayer modPlayer = player.Getiriesplayer();

			modPlayer.beeDamage += 0.10f;
			modPlayer.RoyalCloak = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Stinger, 4);
			recipe.AddIngredient(ItemID.HoneyBlock, 18);
			recipe.AddIngredient(ItemID.Silk, 20);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
