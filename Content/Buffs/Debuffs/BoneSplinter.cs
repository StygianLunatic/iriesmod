using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace iriesmod.Content.Buffs.Debuffs
{
    public class BoneSplinter : ModBuff
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bone Splinter");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = true;
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.defense -= 5;
        }
        public override void Update(Player player, ref int buffIndex)
        {
            player.statDefense -= 5;
        }
    }
}
