using Terraria;
using Terraria.ModLoader;

namespace iriesmod.Content.Buffs.Minions
{
	internal class RoyalHornet : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Royal Hornet");
			Description.SetDefault("Royal to you");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			if (player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Weapons.Summon.RoyalHornet>()] > 0)
			{
				player.buffTime[buffIndex] = 18000;
				return;
			}
			player.DelBuff(buffIndex);
			buffIndex--;
		}
	}
}
