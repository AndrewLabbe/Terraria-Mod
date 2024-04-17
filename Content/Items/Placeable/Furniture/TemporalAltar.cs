using VoyagerMod.Content.Items;
using Terraria.ID;
using Terraria.ModLoader;

namespace VoyagerMod.Content.Items.Placeable.Furniture
{
    [LegacyName("TemporalBasin")]
    public class TemporalAltar : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Content.Placeables";
        public override void SetDefaults()
        {
            Item.width = 8;
            Item.height = 10;
            Item.maxStack = 9999;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.consumable = true;
            Item.createTile = ModContent.TileType<Content.Tiles.TemporalAltar>();
        }

		public override void ModifyResearchSorting(ref ContentSamples.CreativeHelper.ItemGroup itemGroup)
		{
			itemGroup = ContentSamples.CreativeHelper.ItemGroup.CraftingObjects;
		}

        public override void AddRecipes()
        {
            CreateRecipe().
                AddIngredient<AstroniumBar>(10).
                AddIngredient<FluoriteBar>(10).
                AddIngredient<MalachiteBar>(10).
                AddIngredient(ItemID.Hellforge, 2).
                AddTile(TileID.LunarCraftingStation).
                Register();
        }
    }
}