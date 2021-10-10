using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using iriesmod.Content.Items.Equips.Accessories.HivePacks;

namespace iriesmod.Common.RecipeHelper
{
    internal class RecipeGroupHelper
    {
        public static void AddRecipeGroup()
        {
            RecipeGroup group;

            group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " " + Lang.GetItemNameValue(ItemID.GoldBroadsword), new[]{ (int)ItemID.GoldBroadsword, ItemID.PlatinumBroadsword});
            RecipeGroup.RegisterGroup("AnyGoldBroadSword", group);

            group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " " + Lang.GetItemNameValue(ItemID.GoldBow), new[] { (int)ItemID.GoldBow, ItemID.PlatinumBow });
            RecipeGroup.RegisterGroup("AnyGoldBow", group);

            group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " " + Lang.GetItemNameValue(ModContent.ItemType<CursedFlameHivePack>()), new[] { ModContent.ItemType<CursedFlameHivePack>(), ModContent.ItemType<IchorHivePack>() });
            RecipeGroup.RegisterGroup("AnyCursedFlameHivePack", group);
        }
    }
}
