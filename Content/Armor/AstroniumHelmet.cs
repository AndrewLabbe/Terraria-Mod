using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using VoyagerMod.Content.Armor;
using VoyagerMod.Content.Items;
using VoyagerMod.Content.Items.Placeable;

namespace VoyagerMod.Content.Armor
{
	// The AutoloadEquip attribute automatically attaches an equip texture to this item.
	// Providing the EquipType.Head value here will result in TML expecting a X_Head.png file to be placed next to the item's main texture.
	[AutoloadEquip(EquipType.Head)]
	public class AstroniumHelmet : ModItem
	{
		public static readonly int AdditiveGenericDamageBonus = 30;
		public static readonly int CritBonus = 15;

		public static LocalizedText SetBonusText { get; private set; }
		public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(CritBonus);

		public override void SetStaticDefaults() {
			SetBonusText = this.GetLocalization("SetBonus").WithFormatArgs(AdditiveGenericDamageBonus);
		}

		public override void SetDefaults() {
			Item.width = 18; // Width of the item
			Item.height = 18; // Height of the item
			Item.value = Item.sellPrice(gold: 1); // How many coins the item is worth
			Item.rare = ItemRarityID.Cyan; // The rarity of the item
			Item.defense = 22; // The amount of defense the item will give when equipped
		}

		public override void UpdateEquip(Player player) {
			player.GetCritChance(DamageClass.Generic) += CritBonus;	
		}

		// IsArmorSet determines what armor pieces are needed for the setbonus to take effect
		public override bool IsArmorSet(Item head, Item body, Item legs) {
			return body.type == ModContent.ItemType<AstroniumBreastplate>() && legs.type == ModContent.ItemType<AstroniumLeggings>();
		}

		// UpdateArmorSet allows you to give set bonuses to the armor.
		public override void UpdateArmorSet(Player player) {
			player.buffImmune[BuffID.OnFire] = true;
			player.setBonus = SetBonusText.Value; // This is the setbonus tooltip: "Increases dealt damage by 30%"
			player.GetDamage(DamageClass.Generic) += AdditiveGenericDamageBonus / 100f; // Increase dealt damage for all weapon classes by 30%
		}

		// Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.
		public override void AddRecipes() {
			CreateRecipe()
				.AddIngredient<AstroniumBar>(15)
				.AddIngredient(ItemID.BeetleHelmet)
				.AddIngredient<FluoriteHelmet>()
				.AddTile(ModContent.TileType<Tiles.TemporalAltar>())
				.Register();
		}
	}
}
