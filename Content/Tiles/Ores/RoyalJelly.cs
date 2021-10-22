using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace iriesmod.Content.Tiles.Ores
{
	public class RoyalJelly : ModTile
	{
		public override void SetStaticDefaults()
		{
			TileID.Sets.Ore[Type] = true;
			Main.tileSpelunker[Type] = true;
			Main.tileOreFinderPriority[Type] = 420;
			Main.tileSolid[Type] = true;
			Main.tileBlockLight[Type] = true;

			ModTranslation name = CreateMapEntryName();
			name.SetDefault("Royal Jelly");
			AddMapEntry(new Color(152, 171, 198), name);

			DustType = DustID.Platinum;
			ItemDrop = ModContent.ItemType<Items.Materials.RoyalJelly>();
			SoundType = SoundID.Splash;
		}

        public override void FloorVisuals(Player player)
        {
			player.sticky = true;
        }
    }
}