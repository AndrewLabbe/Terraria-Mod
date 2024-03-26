using VoyagerMod.Projectiles;
using VoyagerMod.Content.VoyPlayer;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using VoyagerMod.Content.Utilities;
using VoyagerMod.Content.Projectiles.Pets;

namespace VoyagerMod.Content.Buffs
{
    public class ElectricTroublemaker : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.buffNoTimeDisplay[Type] = true;
            Main.vanityPet[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.buffTime[buffIndex] = 18000;
            player.Voyager().rotomPet = true;
            bool PetProjectileNotSpawned = player.ownedProjectileCounts[ModContent.ProjectileType<RotomPet>()] <= 0;
            if (PetProjectileNotSpawned && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.Center, Vector2.Zero, ModContent.ProjectileType<RotomPet>(), 0, 0f, player.whoAmI);
            }
        }
    }
}