using System;
using Terraria.ModLoader;
using VoyagerMod.Content.Tiles;

namespace VoyagerMod.Common.Systems
{
	public class BiomeTileCount : ModSystem
	{
		public int spaceDirtCount;

		public override void TileCountsAvailable(ReadOnlySpan<int> tileCounts) {
            spaceDirtCount = tileCounts[ModContent.TileType<SpaceDirt>()];
			//spaceRockCount = tileCounts[ModContent.TileType<SpaceRock>()];
		}
	}
}