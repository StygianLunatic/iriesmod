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
			Item.width = 16;
			Item.height = 24;
			Item.maxStack = 99;
			Item.value = Item.sellPrice(silver: 40);
			Item.rare = ItemRarityID.Green;
		}
	}
}
