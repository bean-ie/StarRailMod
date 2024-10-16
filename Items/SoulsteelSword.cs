using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using Microsoft.Xna.Framework;
using StarRailMod.Projectiles;
using Terraria.DataStructures;

namespace StarRailMod.Items
{
    internal class SoulsteelSword : ModItem
    {
        public override void SetStaticDefaults()
        {
            ItemID.Sets.ItemsThatAllowRepeatedRightClick[Type] = true;
        }
        public override void SetDefaults()
        {
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useAnimation = 20;
            Item.useTime = 20;
            Item.damage = 55;
            Item.knockBack = 5f;
            Item.width = 60;
            Item.height = 60;
            Item.scale = 1f;
            Item.UseSound = SoundID.Item1;
            Item.rare = ItemRarityID.Pink;
            Item.value = Item.buyPrice(gold: 23); // Sell price is 5 times less than the buy price.
            Item.DamageType = DamageClass.Melee;
            Item.autoReuse = true;
            
        }

        public override bool AltFunctionUse(Player player)
        {
            return true;
        }

        public override bool CanUseItem(Player player)
        {
            if (player.altFunctionUse == 2)
            {
                Item.staff[Type] = true;
                Item.shoot = ModContent.ProjectileType<SoulsteelSwordProjectile>();
                Item.shootSpeed = 15;
                Item.useTime = 15;
                Item.useAnimation = 15;
                Item.useStyle = ItemUseStyleID.Shoot;
                Item.width = 60;
                Item.height = 60;
                Item.DamageType = DamageClass.Melee;
                Item.UseSound = SoundID.Item8;
            } else
            {
                Item.staff[Type] = false;
                Item.useStyle = ItemUseStyleID.Swing;
                Item.shoot = ProjectileID.None;
                Item.useAnimation = 20;
                Item.useTime = 20;
                Item.DamageType = DamageClass.Melee;
                Item.UseSound = SoundID.Item1;
                Item.noMelee = false;
            }
            return base.CanUseItem(player);
        }

        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            position += -Vector2.UnitY.RotatedByRandom(MathHelper.Pi) * 50f;
        }
    }
}
