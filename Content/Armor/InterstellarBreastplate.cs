using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using VoyagerMod.Content.Utilities;
using VoyagerMod.Content.Items.Placeable;

namespace VoyagerMod.Content.Armor

{
    [AutoloadEquip(EquipType.Body)]
    public class InterstellarBreastplate : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Items.Armor.PostMoonLord";
        public override void Load()
        {
            // All code below runs only if we're not loading on a server
            if (Main.netMode != NetmodeID.Server)
            {
                // Add equip textures
                EquipLoader.AddEquipTexture(Mod, "VoyagerMod/Content/Armor/InterstellarBreastplate_Back", EquipType.Back, this);
            }
        }

        public override void SetDefaults()
        {
            Item.width = 38;
            Item.height = 34;
            Item.value = 15;
            Item.defense = 48;
            Item.rare = ItemRarityID.LightPurple;
        }

        public override void UpdateEquip(Player player)
        {
            var modPlayer = player.Voyager();
            player.statLifeMax2 += 100;
            player.GetDamage<GenericDamageClass>() += 0.08f;
            player.GetCritChance<GenericDamageClass>() += 5;
        }

        public override void AddRecipes()
        {
            CreateRecipe().
                AddIngredient<AstroniumBreastplate>().
                AddIngredient<InterstellarAlloyBar>(12).
                AddTile(ModContent.TileType<Tiles.TemporalAltar>()).
                Register();
        }
    }
}