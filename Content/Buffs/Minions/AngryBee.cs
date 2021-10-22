using Terraria;
using Terraria.ModLoader;

namespace iriesmod.Content.Buffs.Minions
{
	internal class AngryBee : ModBuff
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Angry Bee");
			Description.SetDefault("This bee seems angry");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			if (player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Weapons.Summon.AngryBee>()] > 0)
			{
				player.buffTime[buffIndex] = 18000;
				return;
			}
			player.DelBuff(buffIndex);
			buffIndex--;
		}
	}
}
