using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using VoyagerMod.Content.Items.Placeable;
using VoyagerMod.Content.Utilities;
using Terraria.DataStructures;

namespace VoyagerMod.Content.Armor
{
    [AutoloadEquip(EquipType.Head)]
    public class InterstellarHelmet : ModItem, ILocalizedModType
    {
        public static readonly int AdditiveGenericDamageBonus = 30;
		public static readonly int CritBonus = 25;
        public new string LocalizationCategory => "Items.Armor.PostMoonLord";
        public static LocalizedText SetBonusText { get; private set; }
		public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(AdditiveGenericDamageBonus, CritBonus);

        public override void SetStaticDefaults() {
			SetBonusText = this.GetLocalization("SetBonus");
		}

        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 18;
            Item.value = 15;
            Item.defense = 30; //132
            Item.rare = ItemRarityID.Purple;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<InterstellarBreastplate>() && legs.type == ModContent.ItemType<InterstellarLeggings>();
        }

        public override void ArmorSetShadows(Player player)
        {
            player.armorEffectDrawOutlines = true;
        }

        public override void UpdateEquip(Player player)
        {
            var modPlayer = player.Voyager();
            player.GetDamage<GenericDamageClass>() += AdditiveGenericDamageBonus / 100f;
            player.GetCritChance<MeleeDamageClass>() += 25;
        }

        public override void AddRecipes()
        {
            CreateRecipe().
                AddIngredient<AstroniumHelmet>().
                AddIngredient<InterstellarAlloyBar>(12).
                AddTile(ModContent.TileType<Tiles.TemporalAltar>()).
                Register();
        }
    }
}