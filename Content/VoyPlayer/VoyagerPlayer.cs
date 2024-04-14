using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameInput;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace VoyagerMod.Content.VoyPlayer
{
    public partial class VoyagerPlayer : ModPlayer
    {
        #region Pets
        public bool rotomPet = false;

        #endregion

        #region ResetEffects
        public override void ResetEffects()
        {
            rotomPet = false;
        }
        #endregion

        #region Debuffs

        public bool cDepth = false;
        
        #endregion
    }
}