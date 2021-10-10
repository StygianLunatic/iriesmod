using Terraria.ModLoader;
using Terraria.ID;
using Terraria;
using iriesmod.Common.List;
using iriesmod.Common.RecipeHelper;


namespace iriesmod
{
	public class iriesmod : Mod
	{
        public override void Load()
        {
			irieList.InitList();
        }

        public override void AddRecipeGroups()
        {
            RecipeGroupHelper.AddRecipeGroup();
        }
        public override void AddRecipes()
		{
			RecipeHelper.AddRecipe(this);
			RecipeHelper.EditRecipe(this);
		}

        public override void Unload()
        {
            irieList.UnloadList();
        }
    }
}