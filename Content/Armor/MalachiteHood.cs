﻿using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using VoyagerMod.Content.Armor;
using VoyagerMod.Content.Items;

namespace VoyagerMod.Content.Armor
{
	// The AutoloadEquip attribute automatically attaches an equip texture to this item.
	// Providing the EquipType.Head value here will result in TML expecting a X_Head.png file to be placed next to the item's main texture.
	[AutoloadEquip(EquipType.Head)]
	public class MalachiteHood : ModItem
	{
		public static readonly int ManaCostReductionPercent = 10;

		public static LocalizedText SetBonusText { get; private set; }

		public override void SetStaticDefaults() {
			SetBonusText = this.GetLocalization("SetBonus").WithFormatArgs(ManaCostReductionPercent);
		}

		public override void SetDefaults() {
			Item.width = 18; // Width of the item
			Item.height = 18; // Height of the item
			Item.value = Item.sellPrice(gold: 1); // How many coins the item is worth
			Item.rare = ItemRarityID.Green; // The rarity of the item
			Item.defense = 4; // The amount of defense the item will give when equipped
		}

		// IsArmorSet determines what armor pieces are needed for the setbonus to take effect
		public override bool IsArmorSet(Item head, Item body, Item legs) {
			return body.type == ModContent.ItemType<MalachiteBreastplate>() && legs.type == ModContent.ItemType<MalachiteLeggings>();
		}

		// UpdateArmorSet allows you to give set bonuses to the armor.
		public override void UpdateArmorSet(Player player) {
			player.setBonus = SetBonusText.Value; // This is the setbonus tooltip: "10% reduced mana cost"
			player.manaCost -= ManaCostReductionPercent / 100f; // Reduces mana cost by 10%
		}

		// Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.
		public override void AddRecipes() {
			CreateRecipe()
				.AddIngredient<MalachiteOre>()
				// .AddTile<Tiles.Furniture.ExampleWorkbench>()
				.Register();
		}
	}
}
