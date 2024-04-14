using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.GameContent;
using Terraria.GameContent.Achievements;
using Terraria.GameContent.Events;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;
using Terraria.Utilities;
using static Terraria.ModLoader.ModContent;

namespace Content.Voyplayer
{
    public partial class VoyagerGlobalNPC : GlobalNPC
    {
        #region Variables

        public int cDepth = 0;

        public const double BaseDoTDamageMult = 1D;
        double waterDamageMult = BaseDoTDamageMult;

        #endregion

        #region Life Regen
        public override void UpdateLifeRegen(NPC npc, ref int damage)
        {

        if (cDepth > 0)
            {
                int baseCrushDepthDoTValue = (int)(100 * waterDamageMult);
                ApplyDPSDebuff(baseCrushDepthDoTValue, baseCrushDepthDoTValue / 2, ref npc.lifeRegen, ref damage);
            }
        
        }

        public void ApplyDPSDebuff(int lifeRegenValue, int damageValue, ref int lifeRegen, ref int damage)
        {
            if (lifeRegen > 0)
                lifeRegen = 0;

            lifeRegen -= lifeRegenValue;

            if (damage < damageValue)
                damage = damageValue;
        }

        #endregion
    }
}