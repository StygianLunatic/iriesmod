using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using iriesmod.Content.Items.Materials;

namespace iriesmod.Content.Items.Weapons.Summon
{
    public class flameHornetStaff : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Imp Hornet Staff");
			Tooltip.SetDefault("Summons a imp hornet to fight for you");

			ItemID.Sets.GamepadWholeScreenUseRange[item.type] = true;
			ItemID.Sets.LockOnIgnoresCollision[item.type] = true;
		}

		public override void SetDefaults()
		{
			item.damage = 30;
			item.knockBack = 5f;
			item.mana = 10;
			item.width = 34;
			item.height = 34;
			item.useTime = 36;
			item.useAnimation = 36;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.value = Item.sellPrice(gold: 1, silver: 30);
			item.rare = ItemRarityID.Orange;
			item.UseSound = SoundID.Item44;

			item.noMelee = true;
			item.summon = true;
			item.buffType = ModContent.BuffType <Buffs.Minions.flameHornet> ();
			item.shoot = ModContent.ProjectileType<Projectiles.Weapons.Summon.flameHornet>();
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			player.AddBuff(item.buffType, 2);

			position = Main.MouseWorld;
			return true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);

			recipe.AddIngredient(ItemID.HellstoneBar, 18);
			recipe.AddIngredient(ItemID.BeeWax, 10);
			recipe.AddIngredient(ItemID.Bone, 25);

			recipe.AddTile(TileID.HoneyDispenser);

			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
