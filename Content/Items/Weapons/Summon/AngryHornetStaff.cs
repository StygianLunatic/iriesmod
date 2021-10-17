using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace iriesmod.Content.Items.Weapons.Summon
{
    public class AngryHornetStaff : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Angry Hornet Staff");
			Tooltip.SetDefault("Summons an angry hornet to fight for you");
			ItemID.Sets.GamepadWholeScreenUseRange[Item.type] = true;
			ItemID.Sets.LockOnIgnoresCollision[Item.type] = true;
		}

		public override void SetDefaults()
		{
			Item.damage = 16;
			Item.knockBack = 3f;
			Item.mana = 10;
			Item.width = 34;
			Item.height = 34;
			Item.useTime = 36;
			Item.useAnimation = 36;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.value = Item.sellPrice(gold: 1, silver: 30);
			Item.rare = ItemRarityID.Orange;
			Item.UseSound = SoundID.Item44;

			Item.noMelee = true;
			Item.DamageType = DamageClass.Summon;
			Item.buffType = ModContent.BuffType<Buffs.Minions.AngryHornet>();
			Item.shoot = ModContent.ProjectileType<Projectiles.Weapons.Summon.AngryHornet>();
		}

        public override bool Shoot(Player player, ProjectileSource_Item_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			player.AddBuff(Item.buffType, 2);

			position = Main.MouseWorld;
			return true;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();

			recipe.AddIngredient(ItemID.HornetStaff);
			recipe.AddIngredient(ItemID.BeeWax, 16);
			recipe.AddIngredient(ItemID.Hive, 5);
			recipe.AddIngredient(ItemID.HoneyBlock, 5);

			recipe.AddTile(TileID.HoneyDispenser);

			recipe.Register();
		}
	}
}
