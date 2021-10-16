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
			EditHornetStaffRecipe();
			EditHoneyBalloonRecipe();
			EditBeeCloakRecipe();

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
        private static void EditHornetStaffRecipe()
        {
			RecipeFinder hornetstaffFinder = new RecipeFinder();

			hornetstaffFinder.AddIngredient(ItemID.BeeWax, 14);
			hornetstaffFinder.AddTile(TileID.Anvils);
			hornetstaffFinder.SetResult(ItemID.HornetStaff);
			Recipe hornetstaffRecipe = hornetstaffFinder.FindExactRecipe();

			if (hornetstaffRecipe != null)
			{
				RecipeEditor editor = new RecipeEditor(hornetstaffRecipe);
				editor.DeleteIngredient(ItemID.BeeWax);
				editor.AddIngredient(ItemID.Stinger, 8);
				editor.AddIngredient(ItemID.Hive, 15);
				editor.AddIngredient(ItemID.HoneyBlock, 8);
			}
		}
		private static void EditHoneyBalloonRecipe()
        {
			RecipeFinder recipeFinder = new RecipeFinder();

			recipeFinder.AddIngredient(ItemID.ShinyRedBalloon);
			recipeFinder.AddIngredient(ItemID.HoneyComb);
			recipeFinder.AddTile(TileID.TinkerersWorkbench);
			recipeFinder.SetResult(ItemID.HoneyBalloon);
			Recipe exactRecipe = recipeFinder.FindExactRecipe();

			if (exactRecipe != null)
            {
				RecipeEditor editor = new RecipeEditor(exactRecipe);
				editor.DeleteIngredient(ItemID.ShinyRedBalloon);
				editor.DeleteIngredient(ItemID.HoneyComb);
				editor.AddIngredient(ItemID.CloudinaBalloon);
				editor.AddIngredient(ItemID.HoneyBlock, 25);
				editor.AddIngredient(ItemID.BottledHoney, 12);
            }
		}
		private static void EditBeeCloakRecipe()
        {
			RecipeFinder recipeFinder = new RecipeFinder();

			recipeFinder.AddIngredient(ItemID.HoneyComb);
			recipeFinder.AddIngredient(ItemID.StarCloak);
			recipeFinder.AddTile(TileID.TinkerersWorkbench);
			recipeFinder.SetResult(ItemID.BeeCloak);

			Recipe exactRecipe = recipeFinder.FindExactRecipe();

			if (exactRecipe != null)
            {
				RecipeEditor editor = new RecipeEditor(exactRecipe);
				editor.DeleteIngredient(ItemID.HoneyComb);
				editor.DeleteIngredient(ItemID.StarCloak);
				editor.AddIngredient(ModContent.ItemType<HoneyCloak>());
				editor.AddIngredient(ItemID.BeeWax, 9);
            }
        }
        #endregion
        #region AddRecipes
        private static void AddBeeKeeperRecipe(Mod mod)
        {
			ModRecipe recipe = new ModRecipe(mod);

			recipe.AddRecipeGroup("AnyGoldBroadSword");
			recipe.AddIngredient(ItemID.BeeWax, 10);
			recipe.AddIngredient(ItemID.Hive, 5);
			recipe.AddIngredient(ItemID.HoneyBlock, 5);

			recipe.AddTile(TileID.HoneyDispenser);

			recipe.SetResult(ItemID.BeeKeeper);
			recipe.AddRecipe();
		}
		private static void AddBeesKneesRecipe(Mod mod)
		{
			ModRecipe recipe = new ModRecipe(mod);

			recipe.AddRecipeGroup("AnyGoldBow");
			recipe.AddIngredient(ItemID.BeeWax, 10);
			recipe.AddIngredient(ItemID.Hive, 5);
			recipe.AddIngredient(ItemID.HoneyBlock, 5);

			recipe.AddTile(TileID.HoneyDispenser);

			recipe.SetResult(ItemID.BeesKnees);
			recipe.AddRecipe();
		}
		private static void AddBeeGunRecipe(Mod mod)
        {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<beePistol>());
			recipe.AddIngredient(ItemID.BeeWax, 10);
			recipe.AddIngredient(ItemID.Hive, 5);
			recipe.AddIngredient(ItemID.HoneyBlock, 5);

			recipe.AddTile(TileID.HoneyDispenser);

			recipe.SetResult(ItemID.BeeGun);
			recipe.AddRecipe();
        }
		private static void AddHoneyDispenserRecipe(Mod mod)
        {
			ModRecipe recipe = new ModRecipe(mod);

			recipe.AddIngredient(ItemID.Hive, 25);
			recipe.AddIngredient(ItemID.HoneyBlock, 25);
			recipe.AddIngredient(ItemID.BeeWax, 4);

			recipe.SetResult(ItemID.HoneyDispenser);
			recipe.AddRecipe();
        }
		private static void AddHoneyCombRecipe(Mod mod)
        {
			ModRecipe recipe = new ModRecipe(mod);

			recipe.AddIngredient(ItemID.BeeWax, 8);
			recipe.AddIngredient(ModContent.ItemType<RoyalJelly>(), 4);

			recipe.SetResult(ItemID.HoneyComb);
			recipe.AddRecipe();
        }
        #endregion

    }
}
