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
	public class MoltenRoyalCloak : HoneyCloakTemplate
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Burning Royal Cloak");
			Tooltip.SetDefault("Increases bee damage by 15%\nReleases bees and douses the user in honey when damaged");
		}

		public override void SetDefaults()
		{
			Item.width = 24;
			Item.height = 30;
			Item.accessory = true;
			Item.value = Item.sellPrice(gold: 6);
			Item.rare = ItemRarityID.Orange;
			Item.defense = 8;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			iriesplayer modplayer = player.Getiriesplayer();

			modplayer.beeDamage += 0.15f;
			modplayer.BurningRoyalCloak = Item;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<RoyalCloak>());
			recipe.AddIngredient(ItemID.Obsidian, 25);
			recipe.AddIngredient(ItemID.Bone, 25);
			recipe.AddIngredient(ItemID.HellstoneBar, 12);
			recipe.AddTile(TileID.HoneyDispenser);
			recipe.Register();
		}
	}
}
