using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ID;

namespace iriesmod.Common.List
{
    public class irieList
    {
        public static List<int> friendlyBees;
        public static void InitList()
        {
            friendlyBees = new List<int>()
            {
                ProjectileID.Bee,
                ProjectileID.Wasp,
                ProjectileID.GiantBee
            };
        }
    }
}
