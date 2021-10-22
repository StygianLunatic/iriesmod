using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace iriesmod.Common.Worlds
{
    public class DownedBosses : ModSystem
    {
        public static bool downedQueenBee = false;
        public static int QueenBeeKills = 0;

        public override void OnWorldLoad()
        {
            downedQueenBee = false;
            QueenBeeKills = 0;
        }
        public override void OnWorldUnload()
        {
            downedQueenBee = false;
            QueenBeeKills = 0;
        }
        public override void SaveWorldData(TagCompound tag)
        {
            var downed = new List<string>();

            if (downedQueenBee)
            {
                downed.Add("QueenBee");
            }


            tag["downed"] = downed;
            tag["QueenBeeKills"] = QueenBeeKills;
        }

        public override void LoadWorldData(TagCompound tag)
        {
            var downed = tag.GetList<string>("downed");

            QueenBeeKills = tag.GetInt("QueenBeeKills");
            downedQueenBee = downed.Contains("QueenBee");

        }

        public override void NetSend(BinaryWriter writer)
        {
            BitsByte flags = default(BitsByte);
            flags[0] = downedQueenBee;
            writer.Write(flags);
            writer.Write(QueenBeeKills);
        }
        public override void NetReceive(BinaryReader reader)
        {
            BitsByte flags = reader.ReadByte();
            downedQueenBee = flags[0];
            QueenBeeKills = reader.ReadInt32();
        }
    }
}
