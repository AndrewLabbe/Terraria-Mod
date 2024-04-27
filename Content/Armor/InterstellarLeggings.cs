using Terraria;
using Terraria.Enums;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using VoyagerMod.Content.Armor;
using VoyagerMod.Content.Items.Placeable;

namespace VoyagerMod.Content.Armor
{
    [AutoloadEquip(EquipType.Legs)]
    public class InterstellarLeggings : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Items.Armor.PostMoonLord";
        public static int MoveSpeedBonus = 30;
        public static readonly int AdditiveGenericDamageBonus = 30;
        public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(AdditiveGenericDamageBonus, MoveSpeedBonus);

        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 18;
            Item.value = 15;
            Item.defense = 38;
            Item.rare = ItemRarityID.Purple;
        }

        public override void UpdateEquip(Player player)
        {
            player.carpet = true;
            player.GetDamage<GenericDamageClass>() += 0.15f;
            player.moveSpeed += MoveSpeedBonus / 100f;
            player.waterWalk = true;
        }

        public override void AddRecipes()
        {
            CreateRecipe().
                AddIngredient<AstroniumLeggings>().
                AddIngredient<InterstellarAlloyBar>(12).
                AddIngredient(ItemID.FlyingCarpet).
                AddTile(ModContent.TileType<Tiles.TemporalAltar>()).
                Register();
        }
    }
}