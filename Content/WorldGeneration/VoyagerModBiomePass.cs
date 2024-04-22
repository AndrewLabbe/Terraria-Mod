// 1. You'll need various using statements. Visual Studio will suggest these if they are missing, but most are listed here for convenience.
using Terraria;
using Terraria.ID;
using Terraria.WorldBuilding;
using Terraria.IO;
using VoyagerMod.Content.Tiles;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

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

			//initial "rectangle" biome
			for (int i = 0; i < Main.maxTilesX; i++) {
				for(int j = 70; j < 125; j++){
					WorldGen.PlaceTile(i, j, ModContent.TileType<SpaceDirt>(), true);
				}
			}

			//spawning space stone
			for (int k = 0; k < (int)((Main.maxTilesX * Main.maxTilesY) * 9E-05); k++) {
				int x = WorldGen.genRand.Next(12, Main.maxTilesX-12);
				int y = WorldGen.genRand.Next(70, 128); 

				int randW = WorldGen.genRand.Next(4, 10);
				int randH = WorldGen.genRand.Next(4, 10);

				Point point = new Point(x, y);
				WorldUtils.Gen(point, new Shapes.Circle(randW, randH), new Actions.SetTile((ushort)ModContent.TileType<SpaceStone>()));
			}

			//removing excess stone
			for (int i = 0; i < Main.maxTilesX; i++) {
				for(int j = 40; j <= 69; j++){
					WorldGen.KillTile(i, j, false, false, false);
				}
			}

			//shaping biome bottom
			for (int i = 0; i < Main.maxTilesX; i+=15) {
				int strength = WorldGen.genRand.Next(5, 10);
				int steps = WorldGen.genRand.Next(50, 60); 
				WorldGen.TileRunner(i, 125, strength, steps, ModContent.TileType<SpaceDirt>(), true, 1);
			}
			for (int i = 0; i < Main.maxTilesX; i+=15) {
				int strength = WorldGen.genRand.Next(5, 10);
				int steps = WorldGen.genRand.Next(50, 60); 
				WorldGen.TileRunner(i, 125, strength, steps, ModContent.TileType<SpaceDirt>(), true, -1);
			}
			for (int i = 0; i < Main.maxTilesX; i++) {
				for(int j = 125; j < 130; j++){
					WorldGen.PlaceTile(i, j, ModContent.TileType<SpaceDirt>(), true);
				}
			}
			for(int i = 0; i < Main.maxTilesX; i++){
				int randLength = WorldGen.genRand.Next(5, 10);
				for(int c = 0; c < randLength; c++){
					WorldGen.PlaceTile(i+c, 130, ModContent.TileType<SpaceDirt>(), true);
				}
				i+=randLength+WorldGen.genRand.Next(0, 7);
			}

			//Adding "divots" into the biome by removing slabs of terrain
			int numDivots = WorldGen.genRand.Next(20, 25);
			for (int i = 0; i < numDivots; i++){
    			int randLength = WorldGen.genRand.Next(5, Main.maxTilesX / numDivots);
   			 	int startX = Main.maxTilesX / numDivots * i;

    			int startY = 70;
    			int endY = WorldGen.genRand.Next(90, 105);

    			// Adjust startY and endY if you want divots only in a certain area of the world
				for (int y = startY; y < endY; y++){
					for (int x = startX; x < startX+randLength; x++){
						WorldGen.KillTile(x, y, false, false, false);
    				}	
					if(startX >= startX+randLength){}
					else{
						int val = WorldGen.genRand.Next(0, 3);
						startX += val;
						randLength -= WorldGen.genRand.Next(val, val+3);
					}
        		}
			}

			//malachite ore
			for (int k = 0; k < (int)((Main.maxTilesX * Main.maxTilesY) * 6E-05); k++) {
				// The inside of this for loop corresponds to one single splotch of our Ore.
				// First, we randomly choose any coordinate in the world by choosing a random x and y value.
				int x = WorldGen.genRand.Next(0, Main.maxTilesX);
				int y = WorldGen.genRand.Next(70, 120); // WorldGen.worldSurfaceLow is actually the highest surface tile. In practice you might want to use WorldGen.rockLayer or other WorldGen values.

				// Then, we call WorldGen.TileRunner with random "strength" and random "steps", as well as the Tile we wish to place. Feel free to experiment with strength and step to see the shape they generate.
				WorldGen.TileRunner(x, y, WorldGen.genRand.Next(3, 6), WorldGen.genRand.Next(2, 6), ModContent.TileType<MalachiteOre>());
			}

			//fluorite ore
			for (int k = 0; k < (int)((Main.maxTilesX * Main.maxTilesY) * 6E-05); k++) {
				// The inside of this for loop corresponds to one single splotch of our Ore.
				// First, we randomly choose any coordinate in the world by choosing a random x and y value.
				int x = WorldGen.genRand.Next(0, Main.maxTilesX);
				int y = WorldGen.genRand.Next(70, 120); // WorldGen.worldSurfaceLow is actually the highest surface tile. In practice you might want to use WorldGen.rockLayer or other WorldGen values.

				// Then, we call WorldGen.TileRunner with random "strength" and random "steps", as well as the Tile we wish to place. Feel free to experiment with strength and step to see the shape they generate.
				WorldGen.TileRunner(x, y, WorldGen.genRand.Next(3, 6), WorldGen.genRand.Next(2, 6), ModContent.TileType<FluoriteOre>());
			}

			//astronium ore
			for (int k = 0; k < (int)((Main.maxTilesX * Main.maxTilesY) * 6E-05); k++) {
				// The inside of this for loop corresponds to one single splotch of our Ore.
				// First, we randomly choose any coordinate in the world by choosing a random x and y value.
				int x = WorldGen.genRand.Next(0, Main.maxTilesX);
				int y = WorldGen.genRand.Next(70, 120); // WorldGen.worldSurfaceLow is actually the highest surface tile. In practice you might want to use WorldGen.rockLayer or other WorldGen values.

				// Then, we call WorldGen.TileRunner with random "strength" and random "steps", as well as the Tile we wish to place. Feel free to experiment with strength and step to see the shape they generate.
				WorldGen.TileRunner(x, y, WorldGen.genRand.Next(3, 6), WorldGen.genRand.Next(2, 6), ModContent.TileType<AstroniumOre>());
			}

			//Space Trees
			WorldGen.AddTrees();


			GenVars.structures.AddProtectedStructure(new Microsoft.Xna.Framework.Rectangle(0, 0, Main.maxTilesX, 50));
		}
	}
}