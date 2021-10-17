using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using iriesmod.Common.players;

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
			Item.width = 30;
			Item.height = 28;
			Item.value = Item.buyPrice(gold:5);
			Item.rare = ItemRarityID.Green;
			Item.accessory = true;
			Item.DamageType = DamageClass.Melee;
			Item.damage = 35;
			Item.knockBack = 9f;
			Item.expert = true;
			
			Item.defense = 4;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			Dashplayer dashplayer = player.GetModPlayer<Dashplayer>();

			dashplayer.DashAccessoryEquipped = true;
			dashplayer.DashVelocity = 10f;
			dashplayer.collisionDamage = 35f;
			dashplayer.collisionKnockback = 9f;

			player.endurance += 0.12f;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();

			recipe.AddIngredient(ItemID.EoCShield);
			recipe.AddIngredient(ItemID.WormScarf);
			recipe.AddIngredient(ItemID.DemoniteBar, 5);
			recipe.AddTile(TileID.TinkerersWorkbench);

			recipe.Register();
		}
	}
}
