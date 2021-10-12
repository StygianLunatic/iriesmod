using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace iriesmod.Content.Items.Materials
{
	public class QueenBeeStinger : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Queen Bee Stinger");
		}

		public override void SetDefaults()
		{
			item.width = 16;
			item.height = 24;
			item.maxStack = 99;
			item.value = Item.sellPrice(silver: 40);
			item.rare = ItemRarityID.Green;
		}
	}
}
