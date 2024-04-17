using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using System.Collections.Generic;
using VoyagerMod.Content.VoyPlayer;
using VoyagerMod.Content.Utilities;
using VoyagerMod.Content.Items.Placeable;
using VoyagerMod.Content.Items.Accessories;

namespace VoyagerMod.Content.Items.Accessories
{
    [LegacyName("AstroInsignia")]
    public class AstroniumInsignia : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Items.Accessories";
        // public override void ModifyTooltips(List<TooltipLine> list) => list.IntegrateHotkey(CalamityKeybinds.AscendantInsigniaHotKey);
        public override void SetDefaults()
        {
            Item.width = 46;
            Item.height = 36;
            Item.value = 10;
            Item.accessory = true;
            Item.rare = ItemRarityID.Purple;
            Item.defense = 12;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.endurance = 1f - (0.1f * (1f - player.endurance));  // The percentage of damage reduction
			player.GetModPlayer<ExampleDashPlayer>().DashAccessoryEquipped = true;
            player.lifeRegen += 8;
            player.manaRegenBuff = true;
            VoyagerPlayer modPlayer = player.Voyager();
            // modPlayer.ascendantInsignia = true;
            // player.empressBrooch = true;
        }

        public override void AddRecipes()
        {
            CreateRecipe().
                AddIngredient<AstroniumBar>(20).
                AddIngredient<FluoriteAmulet>(1).
                AddIngredient(ItemID.Ectoplasm, 15).
                AddIngredient(ItemID.SoulofFright, 10).
                AddTile(TileID.Anvils).
                Register();
        }
    }
}