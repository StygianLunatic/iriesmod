using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace iriesmod.Content.Buffs
{
    public class SweetAttack : ModBuff
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sweet Attack");
            // Description.SetDefault("Grants 10% damage while doused in honey");
            Description.SetDefault("Your attack is imbued with stickiness");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            if (player.HasBuff(BuffID.Honey))
            {
                player.GetDamage(DamageClass.Generic) += 0.1f;
            }
        }
    }
}
