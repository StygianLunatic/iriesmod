using Terraria;
using Terraria.ModLoader;

namespace iriesmod.Content.Buffs.Minions
{
	internal class ImpHornet : ModBuff
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Imp Hornet");
			Description.SetDefault("Hot and crispy");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			if (player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Weapons.Summon.ImpHornet>()] > 0)
			{
				player.buffTime[buffIndex] = 18000;
				return;
			}
			player.DelBuff(buffIndex);
			buffIndex--;
		}
	}
}
