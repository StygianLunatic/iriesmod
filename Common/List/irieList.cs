﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ID;
using Terraria.ModLoader;
using iriesmod.Content.Projectiles.Weapons.Bees;
using iriesmod.Content.Projectiles.Weapons.Summon;

namespace iriesmod.Common.List
{
    public class irieList
    {
        public static List<int> friendlyBees;
        public static List<int> friendlyBeesProj;
        public static List<int> hornetList;


        public static void InitList()
        {
            friendlyBees = new List<int>()
            {
                ProjectileID.Bee,
                ProjectileID.Wasp,
                ProjectileID.GiantBee,
                ModContent.ProjectileType<beeBeetle>(),
                ModContent.ProjectileType<beeStardust>(),
                ModContent.ProjectileType<WaspSwarm>(),
                ModContent.ProjectileType<beeObsidian>()
            };

            friendlyBeesProj = new List<int>()
            {
                ProjectileID.Stinger,
                ProjectileID.HornetStinger
            };
            hornetList = new List<int>()
            {
                NPCID.Hornet,
                NPCID.LittleStinger,
                NPCID.BigStinger,
                NPCID.HornetFatty,
                NPCID.LittleHornetFatty,
                NPCID.BigHornetFatty,
                NPCID.HornetHoney,
                NPCID.LittleHornetHoney,
                NPCID.BigHornetHoney,
                NPCID.HornetLeafy,
                NPCID.LittleHornetLeafy,
                NPCID.BigHornetLeafy,
                NPCID.HornetSpikey,
                NPCID.LittleHornetSpikey,
                NPCID.BigHornetSpikey,
                NPCID.HornetStingy,
                NPCID.LittleHornetStingy,
                NPCID.BigHornetStingy,
            };
        }

        public static void UnloadList()
        {
            friendlyBees = null;
            friendlyBeesProj = null;
            hornetList = null;
        }
    }
}
