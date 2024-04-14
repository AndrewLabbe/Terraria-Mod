using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using VoyagerMod.Content.Items;
using VoyagerMod.Content.Items.Placeable;

namespace VoyagerMod.Content.Armor
{
	// The AutoloadEquip attribute automatically attaches an equip texture to this item.
	// Providing the EquipType.Body value here will result in TML expecting X_Arms.png, X_Body.png and X_FemaleBody.png sprite-sheet files to be placed next to the item's main texture.
	[AutoloadEquip(EquipType.Body)]
	public class FluoriteBreastplate : ModItem
	{
		public static readonly int ConsumeAmmo = 20;
		public static readonly int ManaCostReductionPercent = 10;
		public static int MaxManaIncrease = 20;
		public static int MeleeSpeedIncrease = 12;
		public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(ConsumeAmmo, ManaCostReductionPercent, MaxManaIncrease, MeleeSpeedIncrease);
		public override void SetDefaults() {
			Item.width = 18; // Width of the item
			Item.height = 18; // Height of the item
			Item.value = Item.sellPrice(gold: 1); // How many coins the item is worth
			Item.rare = ItemRarityID.Cyan; // The rarity of the item
			Item.defense = 13; // The amount of defense the item will give when equipped
		}

		public override void UpdateEquip(Player player) {
			player.statManaMax2 += MaxManaIncrease;
			player.manaCost -= ManaCostReductionPercent / 100f;
			player.ammoCost80 = true;
			player.GetAttackSpeed(DamageClass.Melee) += MeleeSpeedIncrease / 100f;
		}

		// Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.
		public override void AddRecipes() {
			CreateRecipe().AddIngredient<FluoriteBar>(24)
				.AddTile(TileID.Anvils)
				.Register();
		}
	}
}
