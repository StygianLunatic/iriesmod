using Terraria;
using Terraria.ModLoader;

namespace iriesmod.Content.Buffs.Minions
{
	internal class QueenBeeStaff : ModBuff
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Queen Bee");
			Description.SetDefault("Your own Queen Bee");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			if (player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Weapons.Summon.QueenBeeStaff>()] > 0)
			{
				player.buffTime[buffIndex] = 18000;
				return;
			}
			player.DelBuff(buffIndex);
			buffIndex--;
		}
	}
}
