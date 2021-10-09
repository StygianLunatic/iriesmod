using Terraria.ModLoader;
using Terraria.ID;
using Terraria;
using iriesmod.Common.List;

namespace iriesmod
{
	public class iriesmod : Mod
	{
        public override void Load()
        {
			irieList.InitList();
        }

        public override void AddRecipes()
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
	}
}