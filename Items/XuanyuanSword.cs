using Microsoft.Xna.Framework;
using StarRailMod.Projectiles;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace StarRailMod.Items
{
	public class XuanyuanSword : ModItem
	{
        // The Display Name and Tooltip of this item can be edited in the Localization/en-US_Mods.StarRailMod.hjson file.

		public override void SetDefaults()
		{
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useAnimation = 20;
            Item.useTime = 20;
            Item.damage = 55;
            Item.knockBack = 5f;
            Item.width = 54;
            Item.height = 54;
            Item.scale = 1f;
            Item.UseSound = SoundID.Item1;
            Item.rare = ItemRarityID.Pink;
            Item.value = Item.buyPrice(gold: 23); // Sell price is 5 times less than the buy price.
            Item.DamageType = DamageClass.Melee;
            Item.shoot = ModContent.ProjectileType<XuanyuanSwordSwing>();
            Item.noMelee = true; // This is set the sword itself doesn't deal damage (only the projectile does).
            Item.shootsEveryUse = true; // This makes sure Player.ItemAnimationJustStarted is set when swinging.
            Item.autoReuse = true;
        }

        public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
        {

        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            float adjustedItemScale = player.GetAdjustedItemScale(Item); // Get the melee scale of the player and item.
            Projectile.NewProjectile(source, player.MountedCenter, new Vector2(player.direction, 0f), type, damage, knockback, player.whoAmI, player.direction * player.gravDir, player.itemAnimationMax, adjustedItemScale);
            NetMessage.SendData(MessageID.PlayerControls, -1, -1, null, player.whoAmI); // Sync the changes in multiplayer.

            return base.Shoot(player, source, position, velocity, type, damage, knockback);
        }

        public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Feather, 15);
            recipe.AddIngredient(ItemID.Excalibur);
            recipe.AddIngredient(ItemID.Cloud, 50);
            recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
        }
	}
}