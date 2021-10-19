using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using iriesmod.Common.players;
using iriesmod.Common.ID;
using iriesmod.Common.Utils;

namespace iriesmod.Content.Items.Equips.Accessories.HivePacks
{
	public abstract class HivePackTemplate : ModItem
	{
		public override bool CanEquipAccessory(Player player, int slot, bool modded)
		{
			if (slot < 11)
			{
				int index = FindDifferentEquippedExclusiveAccessory().index;
				if (index != -1)
				{
					return slot == index;
				}
			}
			return base.CanEquipAccessory(player, slot, modded);
		}
		public override bool CanRightClick()
		{
			int maxAccessoryIndex = 5 + Main.LocalPlayer.extraAccessorySlots;
			for (int i = 13; i < 13 + maxAccessoryIndex; i++)
			{
				if (Main.LocalPlayer.armor[i].type == Item.type) return false;
			}

			if (FindDifferentEquippedExclusiveAccessory().accessory != null)
			{
				return true;
			}
			return base.CanRightClick();
		}
		public override void RightClick(Player player)
		{
			var (index, accessory) = FindDifferentEquippedExclusiveAccessory();
			if (accessory != null)
			{
				Main.LocalPlayer.QuickSpawnClonedItem(accessory);
				Main.LocalPlayer.armor[index] = Item.Clone();
			}
		}
		protected (int index, Item accessory) FindDifferentEquippedExclusiveAccessory()
		{
			int maxAccessoryIndex = 5 + Main.LocalPlayer.extraAccessorySlots;
			for (int i = 3; i < 3 + maxAccessoryIndex; i++)
			{
				Item otherAccessory = Main.LocalPlayer.armor[i];
				if (!otherAccessory.IsAir &&
					!Item.IsTheSameAs(otherAccessory) &&
					otherAccessory.ModItem is HivePackTemplate)
				{
					return (i, otherAccessory);
				}
			}
			return (-1, null);
		}

	}
}
