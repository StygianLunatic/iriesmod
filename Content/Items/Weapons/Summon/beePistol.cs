using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace iriesmod.Content.Items.Weapons.Summon
{
	public class beePistol : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bee Pistol");
			Tooltip.SetDefault("Shoots bees that will chase your enemy");
		}

		public override void SetDefaults()
		{
			Item.damage = 5;
			Item.mana = 3;
			Item.DamageType = DamageClass.Summon;
			Item.width = 52;
			Item.height = 26;
			Item.useTime = 20;
			Item.useAnimation = 20;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.value = 10000;
			Item.rare = ItemRarityID.Blue;
			Item.UseSound = SoundID.Item11;
			Item.autoReuse = true;
			Item.shoot = ProjectileID.Bee;
			Item.shootSpeed = 8f;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.FlintlockPistol);
			recipe.AddIngredient(ItemID.Stinger, 6);
			recipe.AddIngredient(ItemID.Hive, 8);
			recipe.AddIngredient(ItemID.HoneyBlock, 8);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}


        public override bool Shoot(Player player, ProjectileSource_Item_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			int numberProjectiles = 1 + Main.rand.Next(2);
			for (int i = 0; i < numberProjectiles; i++)
			{
				Vector2 muzzleOffset = Vector2.Normalize(new Vector2(velocity.X, velocity.Y - 1f)) * 51f;
				if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
				{
					position += muzzleOffset;
				}
				Vector2 perturbedSpeed = new Vector2(velocity.X, velocity.Y).RotatedByRandom(MathHelper.ToRadians(10));
				float scale = 1f - (Main.rand.NextFloat() * .3f);
				perturbedSpeed = perturbedSpeed * scale;
				type = player.beeType();
				int proj = Projectile.NewProjectile(source, position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockback, player.whoAmI);

				Main.projectile[proj].usesLocalNPCImmunity = true;
			}
			return false;
		}
	}
}