using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using iriesmod.Common.Players;
using iriesmod.Common.Utils;

namespace iriesmod.Content.Items.Equips.Armor
{
    [AutoloadEquip(EquipType.Head)]
    public class HiveHeadgear :ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Hive Headgear");
            Tooltip.SetDefault("Increases bee damage by 2%");
        }
        public override void SetDefaults()
        {
            item.width = 22;
            item.height = 16;
            item.value = Item.sellPrice(silver: 50);
            item.rare = ItemRarityID.Green;
            item.defense = 2;
        }

        public override void UpdateEquip(Player player)
        {
            iriesplayer modPlayer = player.Getiriesplayer();

            modPlayer.beeDamage += 0.02f;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<HiveBreastplate>() && legs.type == ModContent.ItemType<HiveGreaves>();
        }

        public override void UpdateArmorSet(Player player)
        {
            iriesplayer modPlayer = player.Getiriesplayer();

            player.setBonus = "Releases bees when damaged\nIncreases your max number of minions by 1";
            modPlayer.HiveSetHurtBonus = true;
            player.maxMinions++;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Stinger, 2);
            recipe.AddIngredient(ItemID.Hive, 12);
            recipe.AddIngredient(ItemID.HoneyBlock, 8);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
