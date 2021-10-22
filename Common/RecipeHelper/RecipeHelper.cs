using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using iriesmod.Content.Items.Weapons.Summon;
using iriesmod.Content.Items.Materials;
using iriesmod.Content.Items.Equips.Accessories.HoneyCloaks;

namespace iriesmod.Common.RecipeHelper
{
    internal class RecipeHelper
    {
        public static void EditRecipe(Mod mod)
        {
			for (int i = 0; i < Recipe.numRecipes; i++)
			{
				Recipe recipe = Main.recipe[i];

				if (recipe.HasResult(ItemID.HornetStaff))
				{
					// EditHornetStaffRecipe(recipe, mod);
				}
				else if (recipe.HasResult(ItemID.HoneyBalloon))
				{
					EditHoneyBalloonRecipe(recipe, mod);
				}
				else if (recipe.HasResult(ItemID.BeeCloak))
                {
					EditBeeCloakRecipe(recipe, mod);
				}
			}


		}
		public static void AddRecipe(Mod mod)
        {
			AddBeeKeeperRecipe(mod);
			AddBeesKneesRecipe(mod);
			AddBeeGunRecipe(mod);
			AddHoneyDispenserRecipe(mod);
			AddHoneyCombRecipe(mod);

		}



        #region EditRecipes
		/*
        private static void EditHornetStaffRecipe(Recipe recipe, Mod mod)
        {
			recipe.RemoveRecipe();
			recipe = mod.CreateRecipe(ItemID.HornetStaff);
			recipe.AddIngredient(ItemID.Stinger, 8);
			recipe.AddIngredient(ItemID.Hive, 15);
			recipe.AddIngredient(ItemID.HoneyBlock, 8);
			recipe.AddTile(TileID.HoneyDispenser);
			recipe.Register();
		}
		*/
		private static void EditHoneyBalloonRecipe(Recipe recipe, Mod mod)
        {
			recipe.RemoveRecipe();
			recipe = mod.CreateRecipe(ItemID.HoneyBalloon);
			recipe.AddIngredient(ItemID.CloudinaBalloon);
			recipe.AddIngredient(ItemID.HoneyBlock, 25);
			recipe.AddIngredient(ItemID.BottledHoney, 12);
			recipe.AddTile(TileID.TinkerersWorkbench);
			recipe.Register();
		}
		private static void EditBeeCloakRecipe(Recipe recipe, Mod mod)
        {
			recipe.RemoveRecipe();
			recipe = mod.CreateRecipe(ItemID.BeeCloak);
			recipe.AddIngredient(ModContent.ItemType<HoneyCloak>());
			recipe.AddIngredient(ItemID.BeeWax, 9);
			recipe.AddTile(TileID.HoneyDispenser);
			recipe.Register();
        }
        #endregion
        #region AddRecipes
        private static void AddBeeKeeperRecipe(Mod mod)
        {
			Recipe recipe = mod.CreateRecipe(ItemID.BeeKeeper);

			recipe.AddRecipeGroup("AnyGoldBroadSword");
			recipe.AddIngredient(ItemID.BeeWax, 10);
			recipe.AddIngredient(ItemID.Hive, 5);
			recipe.AddIngredient(ItemID.HoneyBlock, 5);

			recipe.AddTile(TileID.HoneyDispenser);

			recipe.Register();
		}
		private static void AddBeesKneesRecipe(Mod mod)
		{
			Recipe recipe = mod.CreateRecipe(ItemID.BeesKnees);

			recipe.AddRecipeGroup("AnyGoldBow");
			recipe.AddIngredient(ItemID.BeeWax, 10);
			recipe.AddIngredient(ItemID.Hive, 5);
			recipe.AddIngredient(ItemID.HoneyBlock, 5);

			recipe.AddTile(TileID.HoneyDispenser);

			recipe.Register();
		}
		private static void AddBeeGunRecipe(Mod mod)
        {
			Recipe recipe = mod.CreateRecipe(ItemID.BeeGun);
			recipe.AddIngredient(ModContent.ItemType<beePistol>());
			recipe.AddIngredient(ItemID.BeeWax, 10);
			recipe.AddIngredient(ItemID.Hive, 5);
			recipe.AddIngredient(ItemID.HoneyBlock, 5);

			recipe.AddTile(TileID.HoneyDispenser);

			recipe.Register();
        }
		private static void AddHoneyDispenserRecipe(Mod mod)
        {
			Recipe recipe = mod.CreateRecipe(ItemID.HoneyDispenser);

			recipe.AddIngredient(ItemID.Hive, 25);
			recipe.AddIngredient(ItemID.HoneyBlock, 25);
			recipe.AddIngredient(ItemID.BeeWax, 4);
			recipe.AddTile(TileID.Anvils);

			recipe.Register();
        }
		private static void AddHoneyCombRecipe(Mod mod)
        {
			Recipe recipe = mod.CreateRecipe(ItemID.HoneyComb);

			recipe.AddIngredient(ItemID.BeeWax, 8);
			recipe.AddIngredient(ModContent.ItemType<RoyalJelly>(), 4);
			recipe.AddTile(TileID.HoneyDispenser);

			recipe.Register();
        }
        #endregion

    }
}
