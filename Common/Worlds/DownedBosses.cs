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
    public class DownedBosses : ModWorld
    {
        public static bool downedQueenBee;
        public static int QueenBeeKills;

        public override void Initialize()
        {
            downedQueenBee = false;
            QueenBeeKills = 0;
        }
        public override TagCompound Save()
        {
            TagCompound tag = new TagCompound();
            var downed = new List<string>();

            if (downedQueenBee)
            {
                downed.Add("QueenBee");
            }


            tag["downed"] = downed;
            tag["QueenBeeKills"] = QueenBeeKills;

            return tag;
        }
        public override void Load(TagCompound tag)
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
