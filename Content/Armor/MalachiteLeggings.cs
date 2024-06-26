﻿using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using VoyagerMod.Content.Items;
using VoyagerMod.Content.Items.Placeable;

namespace VoyagerMod.Content.Armor
{
	// The AutoloadEquip attribute automatically attaches an equip texture to this item.
	// Providing the EquipType.Legs value here will result in TML expecting a X_Legs.png file to be placed next to the item's main texture.
	[AutoloadEquip(EquipType.Legs)]
	public class MalachiteLeggings : ModItem
	{
		public static readonly int MoveSpeedBonus = 10;

		public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(MoveSpeedBonus);

		public override void SetDefaults() {
			Item.width = 18; // Width of the item
			Item.height = 18; // Height of the item
			Item.value = Item.sellPrice(gold: 1); // How many coins the item is worth
			Item.rare = ItemRarityID.Green; // The rarity of the item
			Item.defense = 7; // The amount of defense the item will give when equipped
		}

		public override void UpdateEquip(Player player) {
			player.moveSpeed += MoveSpeedBonus / 100f; // Increase the movement speed of the player
		}

		// Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.
		public override void AddRecipes() {
			CreateRecipe()
				.AddIngredient<MalachiteBar>(18)
				.AddIngredient(ItemID.GoldGreaves)
				.AddTile(TileID.Anvils)
				.Register();
		}
	}
}
