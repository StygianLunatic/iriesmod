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
    public class RoyalHornetStaff : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Royal Hornet Staff");
			Tooltip.SetDefault("Summons an royal hornet to fight for you");

			ItemID.Sets.GamepadWholeScreenUseRange[item.type] = true;
			ItemID.Sets.LockOnIgnoresCollision[item.type] = true;
		}

		public override void SetDefaults()
		{
			item.damage = 16;
			item.knockBack = 3f;
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
			item.buffType = ModContent.BuffType<Buffs.Minions.RoyalHornet>();
			item.shoot = ModContent.ProjectileType<Projectiles.Weapons.Summon.RoyalHornet>();
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

			recipe.AddIngredient(ModContent.ItemType<QueenBeeStinger>(), 12);
			recipe.AddIngredient(ItemID.BeeWax, 8);
			recipe.AddIngredient(ModContent.ItemType<RoyalJelly>(), 8);

			recipe.AddTile(TileID.HoneyDispenser);

			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
