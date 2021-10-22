using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using iriesmod.Common.players;
using iriesmod.Common.Utils;
using iriesmod.Content.Items.Materials;

namespace iriesmod.Content.Items.Equips.Accessories.BeeNecklace
{
	public class WaspNecklace : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Wasp Necklace");
			Tooltip.SetDefault("Increases bee damage by 10%\nIncreases armor penetration by 10\nIncreases your max number of minions by 1\nReleases bees, douses the user in honey and increases movement speed when damaged\nOne of the abandoned items");
		}

		public override void SetDefaults()
		{
			Item.width = 34;
			Item.height = 30;
			Item.accessory = true;
			Item.value = Item.sellPrice(silver: 30);
			Item.rare = ItemRarityID.Blue;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			iriesplayer modplayer = player.Getiriesplayer();
			modplayer.beeDamage += 0.10f;
			modplayer.WaspNecklace = Item;

			player.armorPenetration += 10;
			player.maxMinions += 1;
			player.panic = true;
		}
	}
}
