using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using VoyagerMod.Content.Projectiles;
using VoyagerMod.Content.Tiles;

namespace VoyagerMod.Content.Items
{
    public class InterstellarBombardier : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Items.Weapons.Ranged";
        public override void SetDefaults()
        {
            Item.damage = 84;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 76;
            Item.height = 30;
            Item.useTime = 15;
            Item.useAnimation = 15;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.noMelee = true;
            Item.knockBack = 7.5f;
            Item.value = 12;
            Item.rare = ItemRarityID.Red;
            Item.UseSound = SoundID.Item11;
            Item.autoReuse = true;
            Item.shootSpeed = 24f;
            Item.shoot = ModContent.ProjectileType<Nuke>();
            Item.useAmmo = AmmoID.Rocket;
        }

        public override Vector2? HoldoutOffset() => new Vector2(-10, 0);

        // Figure out which rocket is used
        public int RocketType;
        public override void OnConsumeAmmo(Item ammo, Player player) => RocketType = ammo.type;

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Projectile.NewProjectile(source, position, velocity, ModContent.ProjectileType<Nuke>(), damage, knockback, player.whoAmI, RocketType);
            return false;
        }
        public override void AddRecipes()
        {
            CreateRecipe().
                AddIngredient<Placeable.InterstellarAlloyBar>(10).
                AddIngredient(ItemID.Celeb2).
                AddIngredient(ItemID.RocketLauncher).
                AddIngredient(ItemID.GrenadeLauncher).
                AddTile(ModContent.TileType<TemporalAltar>()).
                Register();
        }
    }
}