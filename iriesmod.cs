using Terraria.ModLoader;
using Terraria.ID;
using Terraria;
using iriesmod.Common.List;
using iriesmod.Common.RecipeHelper;
using iriesmod.Common.ILchanges;


namespace iriesmod
{
	public class iriesmod : Mod
	{
        public const string iriesmodName = "iriesmod";
        public static int mySelf;
        internal static iriesmod Instance;



        public override void Load()
        {
            Instance = this;
			irieList.InitList();
            ILChange.Load();
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
            ILChange.Unload();
            irieList.UnloadList();
            Instance = null;
        }
    }
}