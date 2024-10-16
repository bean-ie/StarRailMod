using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace StarRailMod.Projectiles
{
    internal class SoulsteelSwordProjectile : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 40;
            Projectile.height = 40;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = -1;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = true;
            Projectile.timeLeft = 120;
        }

        public override void AI()
        {
            if (Projectile.ai[0] == 0)
            {
                Projectile.velocity *= 0.01f;
            }
            if (Projectile.ai[0] <= 30)
            {
                Projectile.ai[0]++;
                Projectile.Opacity = Projectile.ai[0] / 30;
            }
            if (Projectile.ai[0] == 30)
            {
                Projectile.velocity *= 100f;
            }
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver4;
        }
    }
}
