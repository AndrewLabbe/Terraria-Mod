using VoyagerMod.Content.Items.Placeable;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace VoyagerMod.Content.Items.Placeable
{
    public class InterstellarAlloyBar : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Items.Materials";
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 25;
			ItemID.Sets.SortingPriorityMaterials[Type] = 99; // Luminite
            ItemID.Sets.AnimatesAsSoul[Type] = true;
            Main.RegisterItemAnimation(Type, new DrawAnimationVertical(5, 12));
        }

        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.InterstellarAlloyBar>());
            Item.rare = ItemRarityID.Cyan;
            Item.value = Item.sellPrice(gold: 1, silver: 20);
        }

        public override void AddRecipes()
        {
            CreateRecipe().
                AddIngredient<FluoriteBar>(3).
                AddIngredient<AstroniumBar>(3).
                AddIngredient<MalachiteBar>(3).
                // AddTile(TileID.LunarCraftingStation).
                Register();
        }
    }
}