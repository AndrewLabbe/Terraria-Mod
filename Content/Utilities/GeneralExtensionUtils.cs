using VoyagerMod.Content.VoyPlayer;
using Terraria;

namespace VoyagerMod.Content.Utilities
{
    public static partial class VoyagerUtils
    {
         public static VoyagerPlayer Voyager(this Player player) => player.GetModPlayer<VoyagerPlayer>();
         public static Item ActiveItem(this Player player) => Main.mouseItem.IsAir ? player.HeldItem : Main.mouseItem;
    }
}