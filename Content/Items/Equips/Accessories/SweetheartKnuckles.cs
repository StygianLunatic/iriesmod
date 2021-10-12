using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using iriesmod.Common.Players;
using iriesmod.Common.Utils;

namespace iriesmod.Content.Items.Equips.Accessories
{
    public class SweetheartKnuckles : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sweetheart Knuckles");
            Tooltip.SetDefault("Releases bees, douses the user in honey and increases movement speed when damaged");
        }

        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 26;
            item.accessory = true;
            item.value = Item.sellPrice(silver: 30);
            item.rare = ItemRarityID.Blue;
            item.defense = 8;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            iriesplayer modPlayer = player.Getiriesplayer();

            modPlayer.SweetheartKnuckles = true;
            player.panic = true;
        }
    }
}
