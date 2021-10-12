using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using iriesmod.Common.List;
using iriesmod.Common.Players;
using iriesmod.Common.ID;
using iriesmod.Common.Utils;
using iriesmod.Content.Items.Materials;
using iriesmod.Common.Worlds;

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
            if (npc.type == NPCID.QueenBee)
            {
                npc.DropItemInstanced(npc.position, npc.Size, ModContent.ItemType<QueenBeeStinger>(), Main.rand.Next(15, 23));
                if (!DownedBosses.downedQueenBee)
                {
                    DownedBosses.downedQueenBee = true;
                    OreGen.RoyalJellyGen();
                }
            }
        }
    }
}
