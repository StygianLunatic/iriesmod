using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
namespace iriesmod.Content.Items.Weapons.Summon
{
	public class flameWaspSwarmWand : ModItem
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
			Item.value = Item.sellPrice(gold: 4);
			Item.mana = 6;
			Item.damage = 26;
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
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
			position = Main.MouseWorld;
		}
        public override bool Shoot(Player player, ProjectileSource_Item_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			for (int i = 0; i < 2; i++)
            {
			var projectile = Projectile.NewProjectileDirect(source, position ,new Vector2(velocity.X * i, velocity.Y), type, damage, knockback, Main.myPlayer);
			projectile.originalDamage = Item.damage;
            }

			return false;
		}

        public override void AddRecipes()
        {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<WaspSwarmWand>());
			recipe.AddIngredient(ItemID.HellstoneBar, 12);
			recipe.AddIngredient(ItemID.Bone, 25);

			recipe.AddTile(TileID.HoneyDispenser);

			recipe.Register();
        }
    }
}