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

namespace iriesmod.Content.Items.Equips.Accessories
{
	public class DebugAccessory : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("DebugAccessory");
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
			iriesplayer modPlayer = player.Getiriesplayer();

			modPlayer.beeDamage += 8f;
		}
	}
}
