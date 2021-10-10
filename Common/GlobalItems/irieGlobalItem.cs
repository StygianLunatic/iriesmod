using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using iriesmod.Common.Utils;

namespace iriesmod.Common.GlobalItems
{
    public class irieGlobalItem : GlobalItem
    {
        public override void SetDefaults(Item item)
        {
            if (item.type == ItemID.BeeKeeper)
            {
                item.damage += irieUtils.beeDamage();
            }
        }
        public override void UpdateAccessory(Item item, Player player, bool hideVisual)
        {
            if (item.type == ItemID.HoneyBalloon)
            {
                player.doubleJumpSandstorm = true;
            }
            else if(item.type == ItemID.BalloonHorseshoeHoney)
            {
                player.doubleJumpSandstorm = true;
            }
        }
    }
}
