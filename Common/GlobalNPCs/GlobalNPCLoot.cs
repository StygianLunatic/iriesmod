using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using iriesmod.Common.List;
using iriesmod.Common.Players;
using iriesmod.Common.ID;
using iriesmod.Common.Utils;

namespace iriesmod.Common.GlobalNPCs
{
    public class GlobalNPCLoot : GlobalNPC
    {
        public override void NPCLoot(NPC npc)
        {
            if (irieList.hornetList.Contains(npc.type))
            {
                if (NPC.downedBoss2)
                {
                    Item.NewItem(npc.getRect(), ItemID.BeeWax, Main.rand.Next(1, 4));
                }
            }
        }
    }
}
