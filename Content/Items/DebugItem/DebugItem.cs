using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using iriesmod.Common.Players;
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
			item.width = 52;
			item.height = 26;
		}

        public override bool CanRightClick()
        {
			return true;
        }
        public override void RightClick(Player player)
        {
			iriesplayer modPlayer = player.Getiriesplayer();
			Main.NewText(modPlayer.beeDamage.ToString());
		}
    }
}