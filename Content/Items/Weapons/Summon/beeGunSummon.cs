using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace iriesmod.Content.Items.Weapons.Summon
{
    public class beeGunSummon : ModItem
    {
        public override string Texture => $"Terraria/Item_{ItemID.BeeGun}";

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bee Gun - Summon");
            Tooltip.SetDefault("Shoots bees that will chase your enemy");
        }
        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.BeeGun);
            item.magic = false;
            item.summon = true;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
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
                speedX += (float)Main.rand.Next(-35, 36) * 0.02f;
                speedY += (float)Main.rand.Next(-35, 36) * 0.02f;
                int projectileIndex = Projectile.NewProjectile(position.X, position.Y, speedX, speedY, player.beeType(), player.beeDamage(damage), player.beeKB(knockBack), player.whoAmI);
                Main.projectile[projectileIndex].magic = false;
                Main.projectile[projectileIndex].minion = true;
            }

            return false;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);

            recipe.AddIngredient(ModContent.ItemType<beePistol>());
            recipe.AddIngredient(ItemID.BeeWax, 10);
            recipe.AddIngredient(ItemID.Hive, 5);
            recipe.AddIngredient(ItemID.HoneyBlock, 5);

            recipe.AddTile(TileID.HoneyDispenser);

            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
