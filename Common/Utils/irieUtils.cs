using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Microsoft.Xna.Framework;


namespace iriesmod.Common.Utils
{
    public class irieUtils
    {
        public static void BeeSpawn(Vector2 player_pos, bool strongBees)
        {
            bool makeStrongBee;
            int HurtNumberBee = 1 + Main.rand.Next(3);
            float HurtBeeDamage = 10f;



            if (strongBees && Main.rand.Next(3) == 0)
            {
                HurtNumberBee++;
            }


            if (strongBees)
            {
                HurtBeeDamage = 15f;
            }
            if (Main.expertMode)
            {
                HurtBeeDamage *= 1.5f;
            }

            for (int i = 0; i < HurtNumberBee; i++)
            {
                float speedX = (float)Main.rand.Next(-35, 36) * 0.02f;
                float speedY = (float)Main.rand.Next(-35, 36) * 0.02f;
                Vector2 velocity = new Vector2(speedX, speedY);
                Projectile.NewProjectile(player_pos, velocity, beeType(), beeDamage((int)HurtBeeDamage), 0f, Main.myPlayer);
            }



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
        }

    }
}
