using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace iriesmod.Content.Items.Materials
{
	public class RoyalJelly : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Royal Jelly");
		}

		public override void SetDefaults()
		{
			item.width = 16;
			item.height = 16;
			item.maxStack = 99;
			item.value = Item.sellPrice(silver: 40);
			item.rare = ItemRarityID.Green;
		}
	}
}
