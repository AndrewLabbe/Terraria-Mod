using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VoyagerMod.Content.Items
{
	public class MalachiteOre : ModItem
	{
		public override void SetStaticDefaults() {
			Item.ResearchUnlockCount = 100;
			ItemID.Sets.SortingPriorityMaterials[Item.type] = 58;
		}

		public override void SetDefaults() {
			Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.MalachiteOre>());
			Item.width = 12;
			Item.height = 12;
			Item.value = 3000;
		}
	}
}