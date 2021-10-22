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
    public class beeGunSummon : ModItem
    {
        public override string Texture => $"Terraria/Images/Item_{ItemID.BeeGun}";

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bee Gun - Summon");
            Tooltip.SetDefault("Shoots bees that will chase your enemy");
        }
        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.BeeGun);
            Item.DamageType = DamageClass.Summon;
        }

        public override bool Shoot(Player player, ProjectileSource_Item_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            int beeNumber = Main.rand.Next(1, 4);

            if (Main.rand.Next(6) == 0)
                beeNumber++;
            if (Main.rand.Next(6) == 0)
                beeNumber++;

            if (player.strongBees && Main.rand.NextBool(3))
                beeNumber++;

            for (int i = 0; i < beeNumber; i++)
            {
                Vector2 perturbedSpeed = new Vector2(velocity.X, velocity.Y).RotatedByRandom(MathHelper.ToRadians(10));

                int projectileIndex = Projectile.NewProjectile(source, position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, player.beeType(), player.beeDamage(damage), player.beeKB(knockback), player.whoAmI);
                Main.projectile[projectileIndex].DamageType = DamageClass.Summon;
            }

            return false;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();

            recipe.AddIngredient(ModContent.ItemType<beePistol>());
            recipe.AddIngredient(ItemID.BeeWax, 10);
            recipe.AddIngredient(ItemID.Hive, 5);
            recipe.AddIngredient(ItemID.HoneyBlock, 5);

            recipe.AddTile(TileID.HoneyDispenser);

            recipe.Register();
        }
    }
}
