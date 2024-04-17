using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using VoyagerMod.Content.Projectiles;
using VoyagerMod.Content.Tiles;

namespace VoyagerMod.Content.Items
{
    public class AstroniumScythe : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Items.Weapons.Melee";
        public override void SetDefaults()
        {
            Item.width = 56;
            Item.height = 60;
            Item.damage = 130;
            Item.DamageType = DamageClass.Melee;
            Item.useTurn = true;
            Item.useAnimation = 20;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useTime = 20;
            Item.knockBack = 6f;
            Item.UseSound = SoundID.Item71;
            Item.autoReuse = true;
            Item.value = 10;
            Item.rare = ItemRarityID.Lime;
            Item.shoot = ModContent.ProjectileType<AstroniumScytheProjectile>();
            Item.shootSpeed = 5f;
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Projectile.NewProjectile(source, position, velocity, type, damage, knockback, player.whoAmI, 0f, 0f);
            return false;
        }

        public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
        {
            target.AddBuff(BuffID.OnFire, 300);
        }

        public override void OnHitPvp(Player player, Player target, Player.HurtInfo hurtInfo)
        {
            target.AddBuff(BuffID.OnFire, 300);
        }

        public override void AddRecipes()
        {
            CreateRecipe().
                AddIngredient<Placeable.AstroniumBar>(15).
                AddIngredient(ItemID.DeathSickle).
                AddIngredient(ItemID.Sickle).
                AddTile(ModContent.TileType<TemporalAltar>()).
                Register();
        }
    }
}