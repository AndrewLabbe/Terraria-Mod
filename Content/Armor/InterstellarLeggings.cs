using Terraria;
using Terraria.Enums;
using Terraria.ID;
using Terraria.ModLoader;
using VoyagerMod.Content.Armor;
using VoyagerMod.Content.Items.Placeable;

namespace VoyagerMod.Content.Armor
{
    [AutoloadEquip(EquipType.Legs)]
    public class InterstellarLeggings : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Items.Armor.PostMoonLord";
        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 18;
            Item.value = 15;
            Item.defense = 44;
            Item.rare = ItemRarityID.LightPurple;
        }

        public override void UpdateEquip(Player player)
        {
            player.moveSpeed += 0.1f;
            player.carpet = true;
            player.GetDamage<GenericDamageClass>() += 0.12f;
            player.GetCritChance<GenericDamageClass>() += 5;
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