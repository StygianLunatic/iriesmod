using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace iriesmod.Content.Items.Consumables.Potions
{
    public class DefenceHoneyPotion : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Defence Honey Potion");
            Tooltip.SetDefault("Grants +12 defence while you have Honey buff");
        }

		public override void SetDefaults()
		{
			Item.width = 20;
			Item.height = 26;
			Item.useStyle = ItemUseStyleID.EatFood;
			Item.useAnimation = 15;
			Item.useTime = 15;
			Item.useTurn = true;
			Item.UseSound = SoundID.Item3;
			Item.maxStack = 30;
			Item.consumable = true;
			Item.rare = ItemRarityID.Green;
			Item.value = Item.sellPrice(silver: 40);
			Item.buffType = ModContent.BuffType<Buffs.SweetDefence>();
			Item.buffTime = 36000;
		}
	}
}


