using Terraria;
using Terraria.ModLoader;
using iriesmod.Content.Tiles.Ores;
using Terraria.ID;

namespace iriesmod.Common.Worlds
{
    public static class OreGen
    {
        public static void RoyalJellyGen()
        {
			for (int i = 0; i < (int)((Main.maxTilesX * Main.maxTilesY) * 3E-03); i++)
			{
				int x = WorldGen.genRand.Next(0, Main.maxTilesX);
				int y = WorldGen.genRand.Next((int)WorldGen.worldSurfaceLow, Main.maxTilesY);

				Tile tile = Framing.GetTileSafely(x, y);
				if (tile.IsActive && tile.type == TileID.Hive)
				{
				    WorldGen.TileRunner(x, y, WorldGen.genRand.Next(4, 7), WorldGen.genRand.Next(2, 6), ModContent.TileType<RoyalJelly>());
				}
			}
			Main.NewText("The Royal Jelly started to flow...");
		}

    }
}
