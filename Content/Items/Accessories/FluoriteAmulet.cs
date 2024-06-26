using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using VoyagerMod.Content.Items.Placeable;
using VoyagerMod.Content.Buffs;

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
            Item.rare = ItemRarityID.Cyan;
            Item.accessory = true;
            Item.defense = 8;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.endurance = 1f - (0.1f * (1f - player.endurance));  // The percentage of damage reduction
			player.GetModPlayer<ExampleDashPlayer>().DashAccessoryEquipped = true;
            player.manaRegenBuff = true;
            player.buffImmune[ModContent.BuffType<Suffocating>()] = true;
        }

        public override void AddRecipes() {
			CreateRecipe()
				.AddIngredient<FluoriteBar>(24)
                .AddIngredient<MalachiteShield>()
                .AddIngredient(ItemID.SoulofSight, 5)
                .AddIngredient(ItemID.SoulofMight, 5)
				.AddTile(TileID.Anvils)
				.Register();
		}
    }
}