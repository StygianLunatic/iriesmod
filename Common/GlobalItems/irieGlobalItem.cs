using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace iriesmod.Common.GlobalItems
{
    public class irieGlobalItem : GlobalItem
    {
        public override void UpdateAccessory(Item item, Player player, bool hideVisual)
        {
            if (item.type == ItemID.HoneyBalloon)
            {
                player.doubleJumpSandstorm = true;
            }
        }
    }
}
