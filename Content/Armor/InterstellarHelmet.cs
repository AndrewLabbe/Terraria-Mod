using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using VoyagerMod.Content.Items.Placeable;
using VoyagerMod.Content.Utilities;

namespace VoyagerMod.Content.Armor
{
    [AutoloadEquip(EquipType.Head)]
    [LegacyName("InterstellarPlayerHelmet")]
    public class InterstellarHelmet : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Items.Armor.PostMoonLord";
        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 18;
            Item.value = 15;
            Item.defense = 54; //132
            Item.rare = ItemRarityID.LightPurple;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<InterstellarBreastplate>() && legs.type == ModContent.ItemType<InterstellarLeggings>();
        }

        public override void ArmorSetShadows(Player player)
        {
            player.armorEffectDrawOutlines = true;
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = this.GetLocalizedValue("SetBonus");
            var modPlayer = player.Voyager();
            player.GetAttackSpeed<MeleeDamageClass>() += 0.28f;
            player.thorns += 3f;
            player.ignoreWater = true;
            player.crimsonRegen = true;
            player.aggro += 1200;
        }

        public override void UpdateEquip(Player player)
        {
            var modPlayer = player.Voyager();
            player.GetDamage<MeleeDamageClass>() += 0.2f;
            player.GetCritChance<MeleeDamageClass>() += 10;
        }

        public override void AddRecipes()
        {
            CreateRecipe().
                AddIngredient<AstroniumHelmet>().
                AddIngredient<InterstellarAlloyBar>(12).
                AddTile(ModContent.TileType<Tiles.TemporalAltar>()).
                Register();
        }
    }
}