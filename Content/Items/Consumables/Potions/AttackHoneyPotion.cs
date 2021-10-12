using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace iriesmod.Content.Items.Consumables.Potions
{
    public class AttackHoneyPotion : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Attack Honey Potion");
            Tooltip.SetDefault("Increases damage by 10% when you have Honey buff");
        }

		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 26;
			item.useStyle = ItemUseStyleID.EatingUsing;
			item.useAnimation = 15;
			item.useTime = 15;
			item.useTurn = true;
			item.UseSound = SoundID.Item3;
			item.maxStack = 30;
			item.consumable = true;
			item.rare = ItemRarityID.Green;
			item.value = Item.sellPrice(silver: 40);
			item.buffType = ModContent.BuffType<Buffs.StickyAttackBuff>();
			item.buffTime = 36000;
		}
	}
}


