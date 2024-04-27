using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using VoyagerMod.Content.Utilities;
using VoyagerMod.Content.Items.Placeable;
using Terraria.Localization;

namespace VoyagerMod.Content.Armor

{
    [AutoloadEquip(EquipType.Body)]
    public class InterstellarBreastplate : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Items.Armor.PostMoonLord";
        public static readonly int ConsumeAmmo = 20;
		public static readonly int ManaCostReductionPercent = 40;
		public static int MaxManaIncrease = 100;
        public static int MaxLifeIncrease = 100;
		public static int WeaponSpeedIncrease = 20;
        public static readonly int AdditiveGenericDamageBonus = 15;
        public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(MaxLifeIncrease, AdditiveGenericDamageBonus, MaxManaIncrease, ManaCostReductionPercent, ConsumeAmmo, WeaponSpeedIncrease);
        public override void Load()
        {
            // All code below runs only if we're not loading on a server
            if (Main.netMode != NetmodeID.Server)
            {
                // Add equip textures
                EquipLoader.AddEquipTexture(Mod, "VoyagerMod/Content/Armor/InterstellarBreastplate_Back", EquipType.Back, this);
            }
        }

        public override void SetDefaults()
        {
            Item.width = 38;
            Item.height = 34;
            Item.value = 15;
            Item.defense = 42;
            Item.rare = ItemRarityID.Purple;
        }

        public override void UpdateEquip(Player player)
        {
            player.statLifeMax2 += MaxLifeIncrease;
            player.GetDamage<GenericDamageClass>() += AdditiveGenericDamageBonus / 100f;
            player.statManaMax2 += MaxManaIncrease;
			player.manaCost -= ManaCostReductionPercent / 100f;
			player.ammoCost80 = true;
            player.GetAttackSpeed(DamageClass.Generic) += WeaponSpeedIncrease / 100f;
            player.lavaImmune = true;
        }

        public override void AddRecipes()
        {
            CreateRecipe().
                AddIngredient<AstroniumBreastplate>().
                AddIngredient<InterstellarAlloyBar>(12).
                AddTile(ModContent.TileType<Tiles.TemporalAltar>()).
                Register();
        }
    }
}