using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace iriesmod.Content.Tiles.Ores
{
	public class RoyalJelly : ModTile
	{
		public override void SetDefaults()
		{
			TileID.Sets.Ore[Type] = true;
			Main.tileSpelunker[Type] = true;
			Main.tileValue[Type] = 420;
			Main.tileSolid[Type] = true;
			Main.tileBlockLight[Type] = true;

			ModTranslation name = CreateMapEntryName();
			name.SetDefault("Royal Jelly");
			AddMapEntry(new Color(152, 171, 198), name);

			dustType = DustID.Platinum;
			drop = ModContent.ItemType<Items.Materials.RoyalJelly>();
			soundType = SoundID.Splash;
		}

        public override void FloorVisuals(Player player)
        {
			player.sticky = true;
        }
    }
}