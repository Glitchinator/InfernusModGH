using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace Infernus.Items.Weapon.Ranged
{
	public class Equalbow : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Equal Recurver");
			Tooltip.SetDefault("Shoots piercing bolts");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.damage = 26;
			Item.DamageType = DamageClass.Ranged;
			Item.noMelee = true;
			Item.width = 20;
			Item.height = 40;
			Item.useTime = 26;
			Item.useAnimation = 26;
			Item.useStyle = 5;
			Item.knockBack = 3;
			Item.value = Item.buyPrice(0, 9, 50, 0);
			Item.rare = ItemRarityID.Orange;
			Item.UseSound = SoundID.Item5;
			Item.autoReuse = true;
			Item.shoot = ProjectileID.BoneArrowFromMerchant;
			Item.shootSpeed = 12f;
			Item.crit = 4;
			Item.useAmmo = AmmoID.Arrow;
		}
		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			Vector2 offset = new Vector2(velocity.X * 3, velocity.Y * 3);
			position += offset;
			Projectile.NewProjectile(Projectile.GetSource_NaturalSpawn(), position, velocity, ProjectileID.BoneArrowFromMerchant, damage, knockback, player.whoAmI);
			return false;
		}
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<Firebow>(), 1);
            recipe.AddIngredient(ModContent.ItemType<IceBow>(), 1);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}
