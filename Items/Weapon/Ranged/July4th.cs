using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.GameContent.Creative;

namespace Infernus.Items.Weapon.Ranged
{
	public class July4th : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Celebration Chainshotgun");
			Tooltip.SetDefault("Shoot a barrage of Fireworks"
				+ "\n Yes this is a refrence to the 4th of July"
				+ "\n From the 4th of July of 2022");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.damage = 12;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 68;
			Item.height = 22;
			Item.useAnimation = 9;
			Item.useTime = 9;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 8;
			Item.value = Item.buyPrice(0, 12, 50, 0);
			Item.rare = ItemRarityID.Orange;
			Item.UseSound = SoundID.Item36;
			Item.autoReuse = true;
			Item.noMelee = true;
			Item.shoot = ProjectileID.RocketFireworkRed;
			Item.shootSpeed = 10f;
			Item.crit = 0;
		}
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-10, 0);
		}
		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			const int NumProjectiles = 3;

			for (int i = 0; i < NumProjectiles; i++)
			{
				type = Main.rand.Next(new int[] { type, ProjectileID.RocketFireworkYellow, ProjectileID.RocketFireworkRed, ProjectileID.RocketFireworkGreen, ProjectileID.RocketFireworkBlue, });

				Vector2 newVelocity = velocity.RotatedByRandom(MathHelper.ToRadians(15));


				newVelocity *= 1f - Main.rand.NextFloat(0.3f);

				Projectile.NewProjectileDirect(source, position, newVelocity, type, damage, knockback, player.whoAmI);
			}

			return false;
		}
		public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
		{
			velocity = velocity.RotatedByRandom(MathHelper.ToRadians(65));
		}


	}
}