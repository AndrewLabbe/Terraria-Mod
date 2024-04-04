using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VoyagerMod.Content.Items.Placeable
{
	public class SpaceStone : ModItem
	{
		public override void SetStaticDefaults() {
			Item.ResearchUnlockCount = 100;
			ItemID.Sets.ExtractinatorMode[Item.type] = Item.type;
		}

		public override void SetDefaults() {
			Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.SpaceStone>());
			Item.width = 12;
			Item.height = 12;
		}

		public override void ExtractinatorUse(int extractinatorBlockType, ref int resultType, ref int resultStack) { // Calls upon use of an extractinator. Below is the chance you will get ExampleOre from the extractinator.
			if (Main.rand.NextBool(3)) {
				resultType = ModContent.ItemType<MalachiteOre>();
				if (Main.rand.NextBool(5)) {
					resultStack += Main.rand.Next(2);
				}
			}
		}
	}
}