using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using iriesmod.Common.Utils;
using iriesmod.Common.Players;

namespace iriesmod.Common.GlobalItems
{
    public class irieGlobalItem : GlobalItem
    {
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            if (item.type == ItemID.HoneyBalloon)
            {
                foreach (TooltipLine line in tooltips)
                {
                    if (line.mod == "Terraria" && line.Name == "Tooltip1")
                    {
                        line.text += "\nAllows the holder to do an improved double jump";
                    }
                }
            }
            else if (item.type == ItemID.BalloonHorseshoeHoney)
            {
                foreach (TooltipLine line in tooltips)
                {
                    if (line.mod == "Terraria" && line.Name == "Tooltip1")
                    {
                        line.text += "\nAllows the holder to do an improved double jump";
                    }
                }
            }
        }

        public override void ModifyHitNPC(Item item, Player player, NPC target, ref int damage, ref float knockBack, ref bool crit)
        {
            if (item.type == ItemID.BeeKeeper)
            {
                damage = irieUtils.BeeDamage(player, damage);
            }
        }

        public override void OnHitNPC(Item item, Player player, NPC target, int damage, float knockBack, bool crit)
        {
            if (item.type == ItemID.BeeKeeper)
            {
                player.AddBuff(BuffID.Honey, 300);
            }
        }
        public override void UpdateAccessory(Item item, Player player, bool hideVisual)
        {
            if (item.type == ItemID.HoneyBalloon)
            {
                player.doubleJumpSandstorm = true;
            }
            else if (item.type == ItemID.BalloonHorseshoeHoney)
            {
                player.doubleJumpSandstorm = true;
            }
        }

        public override void UpdateArmorSet(Player player, string set)
        {
            /*
            switch (set)
            {
                case "Bee":
                    player.setBonus = "Increases minion damage by 5%\nIncreases bee damage by 5%";
                    player.minionDamage -= 0.05f;
                    iriesplayer.beeDamage += 0.05f;
                    break;
            }
            */
        }
    }
}
