using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace iriesmod.Content.Buffs
{
    public class SweetDefence : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Sweet Defence");
            Description.SetDefault("Grants +12 defence while doused in honey");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            if (player.HasBuff(BuffID.Honey))
            {
                player.statDefense += 12;
            }
        }
    }
}
