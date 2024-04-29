using VoyagerMod.Content.Projectiles;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using VoyagerMod.Content.Tiles;

namespace VoyagerMod.Content.Items
{
    public class AstroniumStaff : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Content.Items";
        public const int MaxDamageBoostTime = 180;
        public const float MaxDamageBoostFactor = 18f;
        public static readonly SoundStyle UseSound = SoundID.Item20; 
        public override void SetDefaults()
        {
            Item.damage = 0;
            Item.DamageType = DamageClass.Magic;
            Item.mana = 20;
            Item.width = 70;
            Item.height = 70;
            Item.useTime = Item.useAnimation = 24;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.noMelee = true;
            Item.knockBack = 2f;
            Item.value = 5;
            Item.rare = ItemRarityID.Lime;
            Item.UseSound = null;
            Item.autoReuse = true;
            Item.noUseGraphic = true;
            Item.shoot = ModContent.ProjectileType<AstroniumAttackHoldout>();
            Item.channel = true;
            Item.shootSpeed = 12f;
        }

        public override void AddRecipes()
        {
            CreateRecipe().
                AddIngredient<Placeable.AstroniumBar>(14).
                AddIngredient(ItemID.RainbowRod).
                AddIngredient(ItemID.LargeRuby).
                AddIngredient(ItemID.CrystalShard, 15).
                AddTile(ModContent.TileType<TemporalAltar>()).
                Register();
        }
    }
}