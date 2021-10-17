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
    public class HornetHiveStaff : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Hornet Hive Staff");
			Tooltip.SetDefault("Place a hornet hive don't want to be annoyed");
		}

		public override void SetDefaults()
		{
			item.damage = 18;
			item.knockBack = 3f;
			item.mana = 10;
			item.width = 34;
			item.height = 34;
			item.useTime = 36;
			item.useAnimation = 36;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.value = Item.sellPrice(gold: 4);
			item.rare = ItemRarityID.Orange;
			item.UseSound = SoundID.Item44;

			item.noMelee = true;
			item.summon = true;
			item.sentry = true;
			item.shoot = ModContent.ProjectileType<Projectiles.Weapons.Summon.HornetHive>();
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Projectile.NewProjectile(Main.MouseWorld, Vector2.Zero, type, damage, knockBack, player.whoAmI);
			player.UpdateMaxTurrets();

			return false;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);

			recipe.AddIngredient(ModContent.ItemType<BeeHiveStaff>());
			recipe.AddIngredient(ModContent.ItemType<QueenBeeStinger>(), 12);
			recipe.AddIngredient(ModContent.ItemType<RoyalJelly>(), 8);

			recipe.AddTile(TileID.HoneyDispenser);

			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
