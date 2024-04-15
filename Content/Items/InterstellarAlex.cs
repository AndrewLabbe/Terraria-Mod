using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using VoyagerMod.Content.Items.Placeable;
using VoyagerMod.Content.Projectiles;

namespace VoyagerMod.Content.Items
{
    public class InterstellarAlex : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Items.Weapons.Ranged";
        public override void SetDefaults()
        {
            Item.damage = 325;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 48;
            Item.height = 30;
            Item.useTime = 3;
            Item.useAnimation = 12;
            Item.reuseDelay = 8;
            Item.useLimitPerAnimation = 2;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.noMelee = true;
            Item.knockBack = 6f;

            Item.value = 15;
            Item.rare = ItemRarityID.Quest;

            Item.UseSound = SoundID.Item36;
            Item.autoReuse = true;
            Item.shootSpeed = 1;
            Item.shoot = ModContent.ProjectileType<SparklingBall>();

            Item.useAmmo = AmmoID.Bullet;
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-5, 0);
        }

        public override void AddRecipes()
        {
            CreateRecipe().
                AddIngredient(ItemID.Revolver).
                AddIngredient<InterstellarAlloyBar>(14).
                Register();
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            int card = Utils.SelectRandom(Main.rand, new int[]
            {
            
            Item.shoot = ModContent.ProjectileType<Nuke>(),
            Item.shoot = ModContent.ProjectileType<SparklingBall>(),
            Item.shoot = ModContent.ProjectileType<FluoriteLaser>(),
            Item.shoot = ModContent.ProjectileType<InterstellarSwordHoming>(),
            Item.shoot = ModContent.ProjectileType<FluoriteTridentWhirlpool>(),
            Item.shoot = ModContent.ProjectileType<InterstellarSwordMain>(),
            Item.shoot = ModContent.ProjectileType<InterstellarSwordSide>(),
            Item.shoot = ModContent.ProjectileType<InterstellarSwordSplit>(),
            Item.shoot = ModContent.ProjectileType<FluoriteTridentProj>()

            });

            Projectile.NewProjectile(source, position.X, position.Y, velocity.X, velocity.Y, card, damage, knockback, player.whoAmI, 0f, 0f);
            return false;
        }
    }
}