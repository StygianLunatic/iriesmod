﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using IL.Terraria;
using MonoMod.Cil;
using Mono.Cecil.Cil;
using Terraria.ModLoader;
using iriesmod.Common.ID;
using iriesmod.Common.players;
using iriesmod.Content.Projectiles.Weapons.Bees;

namespace iriesmod.Common.ILchanges
{
    public class ILChange
    {
        public static void Load()
        {
			// IL.Terraria.player.beeType += HookBeeType;
			On.Terraria.Player.beeType += HookBeeType; // Bee alt type insert
			
			IL.Terraria.Player.ApplyEquipFunctional += HookApplyEquipFunctional; // Bee Cloak Star falling, bee releasing remove.
        }
		public static void Unload()
        {
			// IL.Terraria.player.beeType -= HookBeeType;
			On.Terraria.Player.beeType -= HookBeeType;
			IL.Terraria.Player.ApplyEquipFunctional -= HookApplyEquipFunctional;

		}


		/*
		// This IL editing (Intermediate Language editing) example is walked through in the guide: https://github.com/tModLoader/tModLoader/wiki/Expert-IL-Editing#example---hive-pack-upgrade
		private static void HookBeeType(ILContext il)
		{
			var c = new ILCursor(il);
			if (!c.TryGotoNext(i => i.MatchLdcI4(566)))
			c.Index++;
			c.Emit(OpCodes.Ldarg_0);
			c.EmitDelegate<Func<int, Terraria.player, int>>((returnValue, player) =>
			{
				//if (Terraria.Main.ProjectileUpdateLoopIndex == -1)
                //{
                    switch (player.GetModPlayer<iriesplayer>().BeeBackpack)
                    {
						case irieItemID.BeetleHivePack:
							return ModContent.ProjectileType<beeBeetle>();
						case irieItemID.StardustHivePack:
							return ModContent.ProjectileType<beeStardust>();
                    }
                // }

				return returnValue;
			});
		}
		*/

		private static int HookBeeType(On.Terraria.Player.orig_beeType orig, Terraria.Player player)
        {
			int ret = orig(player);
			if (ret == 566)
            {
				switch (player.GetModPlayer<iriesplayer>().BeeBackpack)
                {
					case irieItemID.BeetleHivePack:
						ret = ModContent.ProjectileType<beeBeetle>();
						break;
					case irieItemID.StardustHivePack:
						ret = ModContent.ProjectileType<beeStardust>();
						break;
				}
            }
			if (ret == 181)
            {
				switch (player.GetModPlayer<iriesplayer>().BeeBackpack)
                {
					case irieItemID.ObsidianHivePack:
						ret = ModContent.ProjectileType<beeObsidian>();
						break;
                }
            }

			return ret;
		}

		private static void HookApplyEquipFunctional(ILContext il)
        {
			var c = new ILCursor(il);

			if (!c.TryGotoNext(i => i.MatchLdcI4(1247)))
            {
				return;
            }
			c.Index += 6;
			c.RemoveRange(9);
			c.Emit(OpCodes.Ldarg_0);
			c.Emit(OpCodes.Ldarg_1);
			// https://stackoverflow.com/questions/917551/func-delegate-with-no-return-type
			c.EmitDelegate<Action<Terraria.Player, Terraria.Item >> ((player, item) =>
			{
				player.GetModPlayer<iriesplayer>().beeCloak = item;
				player.GetModPlayer<iriesplayer>().beeDamage += 0.08f;
			});
		} 

	}
}