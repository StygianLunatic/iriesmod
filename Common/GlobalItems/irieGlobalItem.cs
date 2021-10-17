using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using iriesmod.Common.Utils;
using iriesmod.Common.players;
using Microsoft.Xna.Framework;
using iriesmod.Content.Projectiles.Weapons.Ranged;
using Terraria.DataStructures;

namespace iriesmod.Common.GlobalItems
{
    public class irieGlobalItem : GlobalItem
    {
        public override void SetDefaults(Item item)
        {
            if (item.type == ItemID.BeeCloak)
            {
                item.defense = 5;
            }
        }
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            if (item.type == ItemID.HoneyBalloon)
            {
                tooltips.Add(new TooltipLine(Mod, "Tooltip2", "Allows the holder to do an improved double jump"));
            }
            else if (item.type == ItemID.BalloonHorseshoeHoney)
            {
                tooltips.Add(new TooltipLine(Mod, "Tooltip2", "Allows the holder to do an improved double jump"));
            }
            else if (item.type == ItemID.BeeCloak)
            {
                foreach (TooltipLine line in tooltips)
                {
                    if (line.mod == "Terraria" && line.Name == "Tooltip0")
                    {
                        line.text = "Increases bee damage by 8%";
                    }
                }
                tooltips.Add(new TooltipLine(Mod, "Toolip2", "Releases bees when damaged"));
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
                player.hasJumpOption_Sandstorm = true;
            }
            else if (item.type == ItemID.BalloonHorseshoeHoney)
            {
                player.hasJumpOption_Sandstorm = true;
            }
        }

        public override string IsArmorSet(Item head, Item body, Item legs)
        {
            if (head.type == ItemID.BeeHeadgear && body.type == ItemID.BeeBreastplate && legs.type == ItemID.BeeGreaves)
            {
                return "Bee";
            }

            return "";
        }
        public override void UpdateArmorSet(Player player, string set)
        {
            iriesplayer modplayer = player.GetModPlayer<iriesplayer>();
            switch (set)
            {
                case "Bee":
                    player.setBonus = "Increases minion damage by 5%\nIncreases bee damage by 5%";
                    player.GetDamage(DamageClass.Summon) -= 0.05f;
                    modplayer.beeDamage += 0.05f;
                    break;
            }
        }

        public override void ModifyShootStats(Item item, Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            if (item.type == ItemID.Beenade)
            {
                type = ModContent.ProjectileType<BeenadeFix>();
            }
        }
    }
}
