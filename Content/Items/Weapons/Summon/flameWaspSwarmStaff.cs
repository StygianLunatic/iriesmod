﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
namespace iriesmod.Content.Items.Weapons.Summon
{
	public class flameWaspSwarmStaff : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Flame Wasp Swarm Wand");
			Tooltip.SetDefault("Summons two wasps to fight for you");
		}


		public override void SetDefaults()
		{
			item.width = 32;
			item.height = 32;
			item.value = Item.sellPrice(gold: 2);
			item.mana = 6;
			item.damage = 22;
			item.knockBack = 3;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.useTime = 30;
			item.useAnimation = 30;
			item.shoot = ModContent.ProjectileType<Projectiles.Weapons.Summon.WaspSwarm>();
			item.summon = true;
			item.noMelee = true;
			item.UseSound = SoundID.Item44;
			item.rare = ItemRarityID.Orange;
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			for (int i = 0; i < 2; i++)
			{
				Projectile.NewProjectile(Main.MouseWorld, new Vector2(speedX * i, speedY * i * 2), type, damage, knockBack, player.whoAmI);
			}
			return false;
		}

        public override void AddRecipes()
        {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<WaspSwarmStaff>());
			recipe.AddIngredient(ItemID.HellstoneBar, 12);
			recipe.AddIngredient(ItemID.Bone, 25);

			recipe.AddTile(TileID.HoneyDispenser);

			recipe.SetResult(this);
			recipe.AddRecipe();
        }
    }
}