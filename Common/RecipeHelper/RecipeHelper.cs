using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace iriesmod.Common.RecipeHelper
{
    internal class RecipeHelper
    {
        public static void EditRecipe(Mod mod)
        {
			EditHornetStaffRecipe();
			EditHoneyBalloonRecipe();


		}

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
				editor.AddIngredient(ItemID.Stinger, 12);
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



    }
}
