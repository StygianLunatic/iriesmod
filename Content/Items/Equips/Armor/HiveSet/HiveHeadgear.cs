using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using iriesmod.Common.players;
using iriesmod.Common.Utils;

namespace iriesmod.Content.Items.Equips.Armor.HiveSet
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
            Item.width = 22;
            Item.height = 16;
            Item.value = Item.sellPrice(silver: 50);
            Item.rare = ItemRarityID.Green;
            Item.defense = 2;
        }

        public override void UpdateEquip(Player player)
        {
            iriesplayer modplayer = player.Getiriesplayer();

            modplayer.beeDamage += 0.02f;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<HiveBreastplate>() && legs.type == ModContent.ItemType<HiveGreaves>();
        }

        public override void UpdateArmorSet(Player player)
        {
            iriesplayer modplayer = player.Getiriesplayer();

            player.setBonus = "Releases bees when damaged\nIncreases your max number of minions by 1";
            modplayer.HiveSetHurtBonus = Item; ;
            player.maxMinions++;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Stinger, 2);
            recipe.AddIngredient(ItemID.Hive, 12);
            recipe.AddIngredient(ItemID.HoneyBlock, 8);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}
