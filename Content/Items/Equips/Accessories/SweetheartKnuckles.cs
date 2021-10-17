using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using iriesmod.Common.players;
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
            Item.width = 30;
            Item.height = 26;
            Item.accessory = true;
            Item.value = Item.sellPrice(silver: 30);
            Item.rare = ItemRarityID.Blue;
            Item.defense = 8;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            iriesplayer modplayer = player.Getiriesplayer();

            modplayer.SweetheartKnuckles = Item;
            player.panic = true;
        }
    }
}
