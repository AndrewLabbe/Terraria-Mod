using VoyagerMod.Content.Items;
using VoyagerMod.Projectiles.BaseProjectiles;
using VoyagerMod.Content.Projectiles;
using System;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace VoyagerMod.Content.Projectiles
{
    public class FluoriteTridentProj : BaseSpearProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = Projectile.height = 28;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.timeLeft = 90;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = true;
            Projectile.penetrate = -1;
            Projectile.ownerHitCheck = true;
            Projectile.hide = true;
        }

        public override float InitialSpeed => 3f;
        public override float ReelbackSpeed => 1f;
        public override float ForwardSpeed => 0.75f;
        public override Action<Projectile> EffectBeforeReelback => (proj) =>
        {
            Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, Projectile.velocity * 0.8f, ModContent.ProjectileType<FluoriteTridentWhirlpool>(), Projectile.damage, Projectile.knockBack * 0.85f, Projectile.owner, 0f, 0f);
        };
    }
}