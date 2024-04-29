using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using VoyagerMod.Content.Buffs;

namespace VoyagerMod.Content.Items.Accessories
{
    public class SpaceRing : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Items.Accessories";
        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 22;
            Item.value = 3;
            Item.rare = ItemRarityID.Gray;
            Item.accessory = true;
            Item.defense = 4;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.buffImmune[ModContent.BuffType<Suffocating>()] = true;
            player.moveSpeed += 0.1f;
        }

        public override void AddRecipes()
        {
            CreateRecipe().
                AddIngredient(TileID.Iron, 8).
                AddTile(TileID.Anvils).
                Register();
        }
    }
}