// 1. You'll need various using statements. Visual Studio will suggest these if they are missing, but most are listed here for convenience.
using Terraria;
using Terraria.ID;
using Terraria.WorldBuilding;
using Terraria.IO;
using VoyagerMod.Content.Tiles;
using Terraria.ModLoader;

namespace VoyagerMod.Content.WorldGeneration
{
	// 7. Make sure to inherit from the GenPass class.
	public class VoyagerModBiomePass : GenPass
	{
		public VoyagerModBiomePass(string name, float loadWeight) : base(name, loadWeight) {
		}

		// 8. The ApplyPass method is where the actual world generation code is placed.
		protected override void ApplyPass(GenerationProgress progress, GameConfiguration configuration) {
			// 9. Setting a progress message is always a good idea. This is the message the user sees during world generation and can be useful to help users and modders identify passes that are stuck.      
			progress.Message = VoyagerModSystem.VoyagerModBiomePassMessage.Value;

			// 10. Here we use a for loop to run the code inside the loop many times. This for loop scales to the product of Main.maxTilesX, Main.maxTilesY, and 2E-05. 2E-05 is scientific notation and equal to 0.00002. Sometimes scientific notation is easier to read when dealing with a lot of zeros.
			// 11. In a small world, this math results in 4200 * 1200 * 0.00002, which is about 100. This means that we'll run the code inside the for loop 100 times. This is the amount Crimtane or Demonite will spawn. Since we are scaling by both dimensions of the world size, the amount spawned will adjust automatically to different world sizes for a consistent distribution of ores.

			for (int i = 0; i < Main.maxTilesX; i++) {
				for(int j = 80; j < 130; j++){
					WorldGen.PlaceTile(i, j, ModContent.TileType<SpaceDirt>(), false, true);
				}
			}

			GenVars.structures.AddProtectedStructure(new Microsoft.Xna.Framework.Rectangle(0, 0, Main.maxTilesX, 50));
			
			/*
			if(Main.tile[0, 100].type == TileID.ColbaltBrick){
				Debug.WriteLine("");
			}
			*/
		}
	}
}