using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using VoyagerMod.Content.Items.Placeable;
using VoyagerMod.Content.Items.Ammo;
using VoyagerMod.Content.Projectiles;

namespace VoyagerMod.Content.Items
{
	public class MalachiteMinigun : ModItem
	{
		public override void SetDefaults() {
			// Modders can use Item.DefaultToRangedWeapon to quickly set many common properties, such as: useTime, useAnimation, useStyle, autoReuse, DamageType, shoot, shootSpeed, useAmmo, and noMelee.
			// See ExampleGun.SetDefaults to see comments explaining those properties
			Item.DefaultToRangedWeapon(ProjectileID.PurificationPowder, AmmoID.Bullet, 5, 16f, true);

			// Item.SetWeaponValues can quickly set damage, knockBack, and crit
			Item.SetWeaponValues(11, 1f);

			Item.width = 54; // Hitbox width of the item.
			Item.height = 22; // Hitbox height of the item.
			Item.rare = ItemRarityID.Green; // The color that the item's name will be in-game.
			Item.UseSound = SoundID.Item11; // The sound that this item plays when used.
		}

		// Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.
		public override void AddRecipes() {
			CreateRecipe()
				.AddIngredient<MalachiteBar>(30)
				.AddTile(TileID.Anvils)
				.Register();
		}

		// The following method gives this gun a 38% chance to not consume ammo
		public override bool CanConsumeAmmo(Item ammo, Player player) {
			return Main.rand.NextFloat() >= 0.38f;
		}

		// The following method makes the gun slightly inaccurate
		public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback) {
			velocity = velocity.RotatedByRandom(MathHelper.ToRadians(10));
		}

		// This method lets you adjust position of the gun in the player's hands. Play with these values until it looks good with your graphics.
		public override Vector2? HoldoutOffset() {
			return new Vector2(-6f, -2f);
		}
	}
}
