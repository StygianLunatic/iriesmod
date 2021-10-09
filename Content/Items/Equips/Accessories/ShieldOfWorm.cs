using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using iriesmod.Common.Players;

namespace iriesmod.Content.Items.Equips.Accessories
{
	public class ShieldOfWorm : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Shield of the worm");
			Tooltip.SetDefault("Allows the player to dash into the enemy\nIncreases endurance by 12%");
		}

		public override void SetDefaults()
		{
			item.width = 30;
			item.height = 28;
			item.value = Item.buyPrice(gold:5);
			item.rare = ItemRarityID.Green;
			item.accessory = true;
			item.melee = true;
			item.damage = 35;
			item.knockBack = 9f;
			item.expert = true;
			
			item.defense = 4;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			DashPlayer dashPlayer = player.GetModPlayer<DashPlayer>();

			dashPlayer.DashAccessoryEquipped = true;
			dashPlayer.DashVelocity = 10f;
			dashPlayer.collisionDamage = 35f;
			dashPlayer.collisionKnockback = 9f;

			player.endurance += 0.12f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);

			recipe.AddIngredient(ItemID.EoCShield);
			recipe.AddIngredient(ItemID.WormScarf);
			recipe.AddIngredient(ItemID.DemoniteBar, 5);
			recipe.AddTile(TileID.TinkerersWorkbench);

			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
