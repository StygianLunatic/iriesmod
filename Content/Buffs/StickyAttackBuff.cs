using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace iriesmod.Content.Buffs
{
    public class StickyAttackBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Sticky Attack!");
            // Description.SetDefault("Grants 10% damage when doused in honey");
            Description.SetDefault("Your attack is imbued with stickiness");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            if (player.HasBuff(BuffID.Honey))
            {
                player.allDamage += 10;
            }
        }
    }
}
