using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;

namespace iriesmod.Common.Utils
{
    public static class ProjectileUtils
    { 
        public static void ProjectileStickToPlatform(this Projectile proj)
        {
            Tile tile = Framing.GetTileSafely((int)proj.position.X, (int)proj.position.Y);
            if (TileID.Sets.Platforms[tile.type])
            {
                proj.velocity = new(0, 0);
            }
        }

        public static NPC GetTarget(this Projectile proj, float maxDistance, out float distance, out Vector2 TargetCenter, out bool is_target)
        {

            distance = maxDistance;
            is_target = false;
            TargetCenter = proj.Center;
            NPC retNPC;


            retNPC = proj.OwnerMinionAttackTargetNPC;
            if (retNPC != null && retNPC.CanBeChasedBy(proj))
            {
                float distanceCompare = Vector2.Distance(retNPC.Center, proj.Center);
                float tiledistance = distance * 3f;
                if (distanceCompare < tiledistance && !is_target && Collision.CanHitLine(proj.position, proj.width, proj.height, retNPC.position, retNPC.width, retNPC.height))
                {
                    distance = distanceCompare;
                    TargetCenter = retNPC.Center;
                    is_target = true;
                }
            }

            if (!is_target)
            {
                for (int nPCindex = 0; nPCindex < 200; nPCindex++)
                {
                    retNPC = Main.npc[nPCindex];
                    if (retNPC.CanBeChasedBy(proj))
                    {
                        float distanceCompare2 = Vector2.Distance(retNPC.Center, proj.Center);
                        if (!(distanceCompare2 >= distance) && Collision.CanHitLine(proj.position, proj.width, proj.height, retNPC.position, retNPC.width, retNPC.height))
                        {
                            distance = distanceCompare2;
                            TargetCenter = retNPC.Center;
                            is_target = true;
                        }
                    }
                }
            }


            return retNPC;
        }

    }
}
