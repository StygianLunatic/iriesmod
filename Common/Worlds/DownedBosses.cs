using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace iriesmod.Common.Worlds
{
    public class DownedBosses : ModWorld
    {
        public static bool downedQueenBee;

        public override void Initialize()
        {
            downedQueenBee = false;
        }
        public override TagCompound Save()
        {
            var downed = new List<string>();

            if (downedQueenBee)
            {
                downed.Add("QueenBee");
            }

            return new TagCompound
            {
                ["downed"] = downed
            };
        }
        public override void Load(TagCompound tag)
        {
            var downed = tag.GetList<string>("downed");

            downedQueenBee = downed.Contains("QueenBee");
        }
    }
}
