using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace VoyagerMod.Content.Tiles
{
	public class SpaceStone : ModTile
	{
		public override void SetStaticDefaults() {
			Main.tileSolid[Type] = true;
			Main.tileMergeDirt[Type] = true;
			Main.tileBlockLight[Type] = true;
			AddMapEntry(new Color(300, 300, 300));
		}
	}
}