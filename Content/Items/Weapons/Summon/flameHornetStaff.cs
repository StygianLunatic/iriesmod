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
using Terraria.DataStructures;

namespace iriesmod.Content.Items.Weapons.Summon
{
    public class flameHornetStaff : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Flame Hornet Staff");
			Tooltip.SetDefault("Summons a flame hornet to fight for you");

			ItemID.Sets.GamepadWholeScreenUseRange[Item.type] = true;
			ItemID.Sets.LockOnIgnoresCollision[Item.type] = true;
		}

		public override void SetDefaults()
		{
			Item.damage = 30;
			Item.knockBack = 5f;
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
			Item.buffType = ModContent.BuffType <Buffs.Minions.flameHornet> ();
			Item.shoot = ModContent.ProjectileType<Projectiles.Weapons.Summon.flameHornet>();
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

			recipe.AddIngredient(ItemID.HellstoneBar, 18);
			recipe.AddIngredient(ItemID.BeeWax, 10);
			recipe.AddIngredient(ItemID.Bone, 25);

			recipe.AddTile(TileID.HoneyDispenser);

			recipe.Register();
		}
	}
}
