// 1. You'll need various using statements. Visual Studio will suggest these if they are missing, but most are listed here for convenience.
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Generation;
using System.Collections.Generic;
using Terraria.WorldBuilding;
using Terraria.IO;
using Terraria.Localization;

namespace VoyagerMod.Content.WorldGeneration
{
	// 2. Our world generation code must start from a class extending ModSystem
	public class VoyagerModSystem : ModSystem
	{
		// 3. These lines setup the localization for the message shown during world generation. Update your localization files after building and reloading the mod to provide values for this.
		public static LocalizedText VoyagerModBiomePassMessage { get; private set; }

		public override void SetStaticDefaults() {
			VoyagerModBiomePassMessage = Language.GetOrRegister(Mod.GetLocalizationKey("Generating a Bigger Space..."));
		}

		// 4. We use the ModifyWorldGenTasks method to tell the game the order that our world generation code should run
		public override void ModifyWorldGenTasks(List<GenPass> tasks, ref double totalWeight) {
			// 5. We use FindIndex to locate the index of the vanilla world generation task called "Shinies". This ensures our code runs at the correct step.
			int ShiniesIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Cactus, Palm Trees, & Coral"));
			GenPass SkyIslandPass = tasks.Find(genpass => genpass.Name.Equals("Floating Islands"));
			SkyIslandPass.Disable();
			if (ShiniesIndex != -1) {
				// 6. We register our world generation pass by passing in an instance of our custom GenPass class below. The GenPass class will execute our world generation code.
				tasks.Insert(ShiniesIndex + 1, new VoyagerModBiomePass("World Gen Space Biome", 100f));
			}
		}
	}
}