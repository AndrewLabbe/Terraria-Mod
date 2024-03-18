using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using VoyagerMod.Content.Items.Ammo;
using VoyagerMod.Content.Items.Placeable;
using VoyagerMod.Content.Projectiles;

namespace VoyagerMod.Content.Items.Ammo
{
	public class MalachiteBullet : ModItem
	{
		public override void SetStaticDefaults() {
			Item.ResearchUnlockCount = 99;
		}

		public override void SetDefaults() {
			Item.damage = 12; // The damage for projectiles isn't actually 12, it actually is the damage combined with the projectile and the item together.
			Item.DamageType = DamageClass.Ranged;
			Item.width = 8;
			Item.height = 8;
			Item.maxStack = Item.CommonMaxStack;
			Item.consumable = true; // This marks the item as consumable, making it automatically be consumed when it's used as ammunition, or something else, if possible.
			Item.knockBack = 1.5f;
			Item.value = 10;
			Item.rare = ItemRarityID.Green;
			Item.shoot = ModContent.ProjectileType<Projectiles.MalachiteBullet>(); // The projectile that weapons fire when using this item as ammunition.
			Item.shootSpeed = 16f; // The speed of the projectile.
			Item.ammo = AmmoID.Bullet; // The ammo class this ammo belongs to.
		}

		// Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.
		public override void AddRecipes() {
			CreateRecipe()
				.AddIngredient<MalachiteBar>()
				.AddTile(TileID.WorkBenches)
				.Register();
		}
	}
}
