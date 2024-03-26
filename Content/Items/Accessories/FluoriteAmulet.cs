using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using VoyagerMod.Content.VoyPlayer;
using VoyagerMod.Content.Utilities;
using VoyagerMod.Content.Items.Placeable;

namespace VoyagerMod.Content.Items.Accessories
{
    [AutoloadEquip(EquipType.Neck)]
    public class FluoriteAmulet : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Items.Accessories";
        public override void SetDefaults()
        {
            Item.width = 26;
            Item.height = 26;
            Item.value = 1000;
            Item.rare = ItemRarityID.Orange;
            Item.accessory = true;

            Item.lifeRegen = 20;
            Item.defense = 5;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetDamage(DamageClass.Generic) += 1f;
            player.manaRegenBuff = true;
            VoyagerPlayer modPlayer = player.Voyager();
            // modPlayer.abyssalAmulet = true;
            // player.buffImmune[ModContent.BuffType<RiptideDebuff>()] = true;
        }

        public override void AddRecipes() {
			CreateRecipe()
				.AddIngredient<FluoriteBar>(24)
				.AddTile(TileID.Anvils)
				.Register();
		}
    }
}