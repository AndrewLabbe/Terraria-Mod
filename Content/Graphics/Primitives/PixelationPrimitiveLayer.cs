using Microsoft.Xna.Framework.Graphics;

namespace VoyagerMod.Content.Graphics.Primitives
{
    /// <summary>
    /// Controls what layer the <see cref="IPixelatedPrimitiveRenderer.RenderPixelatedPrimitives"/> renders to.
    /// </summary>
    public enum PixelationPrimitiveLayer
    {
        BeforeNPCs,
        AfterNPCs,
        BeforeProjectiles,
        AfterProjectiles
    }
}