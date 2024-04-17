using VoyagerMod.Content.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using VoyagerMod.Content.Items.Placeable;

namespace VoyagerMod.Content.Items
{
    public class FluoriteTrident : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Items.Weapons.Melee";
        public override void SetStaticDefaults()
        {
            ItemID.Sets.Spears[Item.type] = true;
        }

        public override void SetDefaults()
        {
            Item.width = 44;
            Item.damage = 78;
            Item.DamageType = DamageClass.Melee;
            Item.noMelee = true;
            Item.useTurn = true;
            Item.noUseGraphic = true;
            Item.useAnimation = 17;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.useTime = 12;
            Item.knockBack = 4.5f;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.height = 44;
            Item.value = 100000;
            Item.rare = ItemRarityID.Cyan;
            Item.shoot = ModContent.ProjectileType<FluoriteTridentProj>();
            Item.shootSpeed = 6f;
        }

        public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient<FluoriteBar>(18);
            recipe.AddIngredient(ItemID.TitaniumTrident);
            recipe.AddIngredient(ItemID.Trident);
            recipe.AddIngredient(ItemID.SoulofMight, 10);
            recipe.AddIngredient(ItemID.SoulofNight, 10);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}

        public override bool CanUseItem(Player player) => player.ownedProjectileCounts[Item.shoot] <= 0;
    }
}