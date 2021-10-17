using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using iriesmod.Content.Items.Materials;
using Terraria.DataStructures;

namespace iriesmod.Content.Items.Weapons.Summon
{
	public class WaspSwarmStaff : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Wasp Swarm Wand");
			Tooltip.SetDefault("Summons a wasp to fight for you");
		}


		public override void SetDefaults()
		{
			Item.width = 32;
			Item.height = 32;
			Item.value = Item.sellPrice(gold: 2);
			Item.mana = 6;
			Item.damage = 18;
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
			Projectile.NewProjectile(source, Main.MouseWorld, new Vector2(velocity.X, velocity.Y), type, damage, knockback, player.whoAmI);

			return false;
		}

        public override void AddRecipes()
        {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<QueenBeeStinger>(), 16);
			recipe.AddIngredient(ItemID.BeeWax, 5);
			recipe.AddIngredient(ModContent.ItemType<RoyalJelly>(), 5);

			recipe.AddTile(TileID.HoneyDispenser);

			recipe.Register();
        }
    }
}