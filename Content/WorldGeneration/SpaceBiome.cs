using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.Graphics.Capture;
using Terraria.ModLoader;
using VoyagerMod.Common.Systems;
using VoyagerMod.Content.Buffs;

namespace VoyagerMod.Content.WorldGeneration
{
	public class SpaceBiome : ModBiome
	{

		// Calculate when the biome is active.
		public override bool IsBiomeActive(Player player) {
			// First, we will use the spaceDirtCount and spaceRockCount
			bool b1 = ModContent.GetInstance<BiomeTileCount>().spaceDirtCount >= 40 || ModContent.GetInstance<BiomeTileCount>().spaceStoneCount >= 40;

			// Finally, we will limit the height at which this biome can be active to above ground (ie sky and surface). Most (if not all) surface biomes will use this condition.
			bool b2 = player.ZoneSkyHeight;
			return b1 && b2;
		}

		public override void OnEnter(Player player){
			player.AddBuff(ModContent.BuffType<Suffocating>(), 600);
        }
		public override void OnInBiome(Player player){
			player.AddBuff(ModContent.BuffType<Suffocating>(), 600);
        }
		public override void OnLeave(Player player){
			player.ClearBuff(ModContent.BuffType<Suffocating>());
        }

		// Declare biome priority. The default is BiomeLow so this is only necessary if it needs a higher priority.
		public override SceneEffectPriority Priority => SceneEffectPriority.BiomeHigh;
	}
}