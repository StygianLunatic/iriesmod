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

namespace iriesmod.Content.Items.DebugItem
{
	public class DebugAccessory : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("DebugAccessory");
		}

		public override void SetDefaults()
		{
			Item.width = 24;
			Item.height = 30;
			Item.accessory = true;
			Item.value = Item.sellPrice(silver: 30);
			Item.rare = ItemRarityID.Blue;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			iriesplayer modplayer = player.Getiriesplayer();

			modplayer.beeDamage += 8f;
		}
	}
}
