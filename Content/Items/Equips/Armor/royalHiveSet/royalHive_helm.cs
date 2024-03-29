﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using iriesmod.Common.Players;
using iriesmod.Common.Utils;
using iriesmod.Content.Items.Equips.Armor.HiveSet;

namespace iriesmod.Content.Items.Equips.Armor.royalHiveSet
{
    [AutoloadEquip(EquipType.Head)]
    public class royalHive_helm : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Royal Hive Helmet");
            Tooltip.SetDefault("Increases bee damage by 8%\nIncreases your max number of sentries by 1");
        }
        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 34;
            item.value = Item.sellPrice(gold: 5);
            item.rare = ItemRarityID.LightRed;
            item.defense = 5;
        }

        public override void UpdateEquip(Player player)
        {
            iriesplayer modPlayer = player.Getiriesplayer();

            modPlayer.beeDamage += 0.08f;
            player.maxTurrets++;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<royalHive_breastplate>() && legs.type == ModContent.ItemType<royalHive_greaves>();
        }

        public override void UpdateArmorSet(Player player)
        {
            iriesplayer modPlayer = player.Getiriesplayer();

            player.setBonus = "Increases bee damage by 15%\nIncreases your max number of sentries by 1";

            modPlayer.beeDamage += 0.15f;
            player.maxTurrets++;

        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);

            recipe.AddIngredient(ModContent.ItemType<HiveHeadgear>());
            recipe.AddIngredient(ModContent.ItemType<Materials.QueenBeeStinger>(), 4);
            recipe.AddIngredient(ItemID.BeeWax, 12);
            recipe.AddIngredient(ModContent.ItemType<Materials.RoyalJelly>(), 6);

            recipe.AddTile(TileID.HoneyDispenser);

            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}