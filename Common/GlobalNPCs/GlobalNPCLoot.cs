using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using iriesmod.Common.List;
using iriesmod.Common.players;
using iriesmod.Common.ID;
using iriesmod.Common.Utils;
using iriesmod.Content.Items.Materials;
using iriesmod.Common.Worlds;
using Terraria.Localization;
using Microsoft.Xna.Framework;
using Terraria.Chat;

namespace iriesmod.Common.GlobalNPCs
{
    public class GlobalNPCLoot : GlobalNPC
    {
        public override void OnKill(NPC npc)
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
                if (DownedBosses.QueenBeeKills < 3)
                {
                    OreGen.RoyalJellyGen();
                    if (Main.netMode == NetmodeID.SinglePlayer)
                    {
                        Main.NewText("Royal Jelly Spawned", Color.Beige);
                    }
                    if (Main.netMode == NetmodeID.Server)
                    {
                        ChatHelper.BroadcastChatMessage(NetworkText.FromLiteral("Royal Jelly Spawned"), Color.Beige);
                    }
                }

                DownedBosses.downedQueenBee = true;
                DownedBosses.QueenBeeKills++;


                if (Main.netMode == NetmodeID.Server)
                {
                    NetMessage.SendData(MessageID.WorldData);
                }
            }
        }
    }
}
