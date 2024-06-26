using Terraria.ID;
using Terraria.ModLoader;
using VoyagerMod.Content.Items.Placeable;
using VoyagerMod.Content.Projectiles;

namespace VoyagerMod.Content.Items
{
    [LegacyName("FluoriteTome")]
    public class TomeOfFluorescence : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Items.Weapons.Magic";
        public override void SetDefaults()
        {
            Item.damage = 48;
            Item.DamageType = DamageClass.Magic;
            Item.mana = 2;
            Item.width = 28;
            Item.height = 30;
            Item.useTime = 4;
            Item.useAnimation = 3;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.noMelee = true;
            Item.knockBack = 3f;
            Item.value = 10000;
            Item.UseSound = SoundID.Item33;
            Item.autoReuse = true;
            Item.shoot = ModContent.ProjectileType<FluoriteLaser>();
            Item.shootSpeed = 20f;
            Item.rare = ItemRarityID.Cyan;
        }

        public override void AddRecipes()
        {
            CreateRecipe().
                AddIngredient<FluoriteBar>(16).
                AddIngredient(ItemID.SpellTome, 2).
                AddIngredient(ItemID.FallenStar, 10).
                AddIngredient(ItemID.Feather, 20).
                AddIngredient(ItemID.SoulofLight, 10).
                AddIngredient(ItemID.SoulofNight, 10).
                AddIngredient(ItemID.LightShard, 2).
                AddTile(TileID.Bookcases).
                Register();
        }
    }
}