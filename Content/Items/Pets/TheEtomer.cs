using VoyagerMod.Projectiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using VoyagerMod.Content.Items.Placeable;
using VoyagerMod.Content.Projectiles.Pets;
using VoyagerMod.Content.Buffs;

namespace VoyagerMod.Content.Items.Pets
{
    [LegacyName("InterstellarRotomRemote")]
    public class TheEtomer : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Items.Pets";
        public override void SetDefaults()
        {
            Item.damage = 0;
            Item.useTime = Item.useAnimation = 20;
            Item.shoot = ModContent.ProjectileType<RotomPet>();
            Item.buffType = ModContent.BuffType<ElectricTroublemaker>();

            Item.width = 30;
            Item.height = 34;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.noMelee = true;
            Item.UseSound = SoundID.Item113;

            Item.value = Item.buyPrice(gold: 4);
            Item.rare = ItemRarityID.Orange;
        }

        public override void UseStyle(Player player, Rectangle heldItemFrame)
        {
            if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
            {
                player.AddBuff(Item.buffType, 3600, true);
            }
        }

        public override void AddRecipes()
        {
            CreateRecipe().
                AddIngredient<InterstellarAlloyBar>(12).
                AddTile(TileID.Anvils).
                Register();
        }
    }
}