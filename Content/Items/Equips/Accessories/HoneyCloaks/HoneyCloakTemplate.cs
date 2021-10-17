using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using iriesmod.Common.Players;
using iriesmod.Common.ID;
using iriesmod.Common.Utils;

namespace iriesmod.Content.Items.Equips.Accessories.HoneyCloaks
{
	public abstract class HoneyCloakTemplate : ModItem
	{
		public override bool CanEquipAccessory(Player player, int slot)
		{
			if (slot < 10)
			{
				int index = FindDifferentEquippedExclusiveAccessory().index;
				if (index != -1)
				{
					return slot == index;
				}
			}
			return base.CanEquipAccessory(player, slot);
		}
		public override bool CanRightClick()
		{
			int maxAccessoryIndex = 5 + Main.LocalPlayer.extraAccessorySlots;
			for (int i = 13; i < 13 + maxAccessoryIndex; i++)
			{
				if (Main.LocalPlayer.armor[i].type == item.type) return false;
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
				Main.LocalPlayer.armor[index] = item.Clone();
			}
		}
		protected (int index, Item accessory) FindDifferentEquippedExclusiveAccessory()
		{
			int maxAccessoryIndex = 5 + Main.LocalPlayer.extraAccessorySlots;
			for (int i = 3; i < 3 + maxAccessoryIndex; i++)
			{
				Item otherAccessory = Main.LocalPlayer.armor[i];
				if (!otherAccessory.IsAir &&
					!item.IsTheSameAs(otherAccessory) &&
					otherAccessory.modItem is HoenyCloakTemplate)
				{
					return (i, otherAccessory);
				}
			}
			return (-1, null);
		}

	}
}
