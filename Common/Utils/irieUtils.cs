using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Microsoft.Xna.Framework;
using iriesmod.Common.List;
using iriesmod.Common.ID;
using Terraria.ID;
using iriesmod.Common.Players;

namespace iriesmod.Common.Utils
{
    public static class irieUtils
    {
        public static iriesplayer Getiriesplayer(this Player player)
        {
            return player.GetModPlayer<iriesplayer>();
        }

        public static void BeeSpawn(Player player, int minBeeDamage, int maxBeeDamage, int typeofbee = -1)
        {
            // bool makeStrongBee;
            bool strongBees = player.strongBees;
            int HurtNumberBee = 1 + Main.rand.Next(3);
            float HurtBeeDamage = Main.rand.Next(minBeeDamage, maxBeeDamage + 1);


            if (strongBees && Main.rand.Next(3) == 0)
            {
                HurtNumberBee++;
            }


            if (strongBees)
            {
                HurtBeeDamage += 5f;
            }
            if (Main.expertMode)
            {
                HurtBeeDamage *= 1.5f;
            }
            if (typeofbee < 0)
            {
                typeofbee = player.beeType();
            }
            for (int i = 0; i < HurtNumberBee; i++)
            {
                float speedX = Main.rand.Next(-35, 36) * 0.02f;
                float speedY = Main.rand.Next(-35, 36) * 0.02f;
                Vector2 velocity = new Vector2(speedX, speedY);
                Projectile.NewProjectile(player.position, velocity, typeofbee, BeeDamage(player, (int)HurtBeeDamage), 0f, Main.myPlayer);
            }


            /*
            int beeType()
            {
                if (strongBees && Main.rand.Next(2) == 0)
                {
                    makeStrongBee = true;
                    return 566;
                }

                makeStrongBee = false;
                return 181;
            }
            int beeDamage(int damage)
            {
                if (makeStrongBee)
                {
                    return damage + Main.rand.Next(1, 4);
                }
                
                return damage + Main.rand.Next(2);
            }
            */


        }
        public static int[] BeeDebuff(Player player)
        {
            iriesplayer modPlayer = player.Getiriesplayer();
            switch (modPlayer.BeeBackpack)
            {
                case irieItemID.ObsidianHivePack:
                    return new int[]{ 1, BuffID.OnFire };
                case irieItemID.CursedFlameHivePack:
                    return new int[] { 1, BuffID.CursedInferno };
                case irieItemID.IchorHivePack:
                    return new int[] { 1, BuffID.Ichor };
                case irieItemID.MechaHivePack:
                    return new int[] { 1, BuffID.CursedInferno, BuffID.Ichor };
                case irieItemID.VenomHivePack:
                    return new int[] { 1, BuffID.Venom };
                case irieItemID.BeetleHivePack:
                    return new int[] { 1, BuffID.Venom };
                case irieItemID.StardustHivePack:
                    return new int[] { 1, BuffID.OnFire, BuffID.CursedInferno, BuffID.Ichor, BuffID.Venom };
            }
            return new int[] { 0 };
        }
        public static int BeeDamage(Player player, int damage)
        {
            iriesplayer modPlayer = player.Getiriesplayer();

            int beePackDamage = 0;

            switch (modPlayer.BeeBackpack)
            {
                case irieItemID.ObsidianHivePack:
                    beePackDamage += Main.rand.Next(2, 9);
                    break;
                case irieItemID.CursedFlameHivePack:
                    beePackDamage += Main.rand.Next(5, 11);
                    break;
                case irieItemID.IchorHivePack:
                    beePackDamage += Main.rand.Next(5, 11);
                    break;
                case irieItemID.MechaHivePack:
                    beePackDamage += Main.rand.Next(10, 16);
                    break;
                case irieItemID.VenomHivePack:
                    beePackDamage += Main.rand.Next(17, 23);
                    break;
                case irieItemID.BeetleHivePack:
                    beePackDamage += Main.rand.Next(26, 32);
                    break;
                case irieItemID.StardustHivePack:
                    beePackDamage += Main.rand.Next(36, 42);
                    break;
            }

            return (int)((damage + beePackDamage) * (1f + modPlayer.beeDamage));
        }
        public static int BeePenetrate(short BeeBackpack)
        {
            switch (BeeBackpack)
            {
                case irieItemID.ObsidianHivePack:
                    return 1;
                case irieItemID.CursedFlameHivePack:
                case irieItemID.IchorHivePack:
                    return 2;
                case irieItemID.MechaHivePack:
                    return 3;
                case irieItemID.VenomHivePack:
                case irieItemID.BeetleHivePack:
                case irieItemID.StardustHivePack:
                    return 4;
            }

            return 0;
        }

    }
}
