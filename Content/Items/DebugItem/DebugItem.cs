using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using iriesmod.Common.players;
using iriesmod.Common.Utils;

namespace iriesmod.Content.Items.DebugItem
{
	public class DebugItem : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("DebugItem");
		}

		public override void SetDefaults()
		{
			Item.width = 52;
			Item.height = 26;
		}

        public override bool CanRightClick()
        {
			return true;
        }
        public override void RightClick(Player player)
        {
			iriesplayer modplayer = player.Getiriesplayer();
			Main.NewText(modplayer.beeDamage.ToString());
		}
    }
}