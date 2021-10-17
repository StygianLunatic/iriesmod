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
			Item.useStyle = ItemUseStyleID.Swing;
			Item.useTurn = true;
			Item.width = 16;
			Item.height = 16;
			Item.maxStack = 99;
			Item.value = Item.sellPrice(silver: 40);
			Item.rare = ItemRarityID.Green;
			Item.autoReuse = true;
			Item.consumable = true;
			Item.useAnimation = 15;
			Item.useTime = 10;
			Item.createTile = ModContent.TileType<Tiles.Ores.RoyalJelly>();

		}
	}
}
