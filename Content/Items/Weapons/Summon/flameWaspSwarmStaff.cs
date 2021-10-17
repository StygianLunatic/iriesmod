using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
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
			Item.width = 32;
			Item.height = 32;
			Item.value = Item.sellPrice(gold: 2);
			Item.mana = 6;
			Item.damage = 22;
			Item.knockBack = 3;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.useTime = 30;
			Item.useAnimation = 30;
			Item.shoot = ModContent.ProjectileType<Projectiles.Weapons.Summon.WaspSwarm>();
			Item.DamageType = DamageClass.Summon;
			Item.noMelee = true;
			Item.UseSound = SoundID.Item44;
			Item.rare = ItemRarityID.Orange;
		}

        public override bool Shoot(Player player, ProjectileSource_Item_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			for (int i = 0; i < 2; i++)
			{
				Projectile.NewProjectile(source, Main.MouseWorld, new Vector2(velocity.X * i, velocity.Y * i * 2), type, damage, knockback, player.whoAmI);
			}
			return false;
		}

        public override void AddRecipes()
        {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<WaspSwarmStaff>());
			recipe.AddIngredient(ItemID.HellstoneBar, 12);
			recipe.AddIngredient(ItemID.Bone, 25);

			recipe.AddTile(TileID.HoneyDispenser);

			recipe.Register();
        }
    }
}