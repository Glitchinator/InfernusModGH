using Infernus.Buffs;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace Infernus.Items.Weapon.Summon
{
	public class BlizStaff : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Aurora Spear");
			Tooltip.SetDefault("Summon a Aurora shuriken that creates smaller shurikens on hit");
			ItemID.Sets.GamepadWholeScreenUseRange[Item.type] = true;
			ItemID.Sets.LockOnIgnoresCollision[Item.type] = true;
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.damage = 20;
			Item.DamageType = DamageClass.Summon;
			Item.mana = 11;
			Item.width = 42;
			Item.height = 42;
			Item.useTime = 36;
			Item.useAnimation = 36;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.noMelee = true;
			Item.knockBack = 3;
			Item.value = Item.buyPrice(0, 16, 50, 0);
			Item.rare = ItemRarityID.Orange;
			Item.UseSound = SoundID.Item96;
			Item.shoot = ModContent.ProjectileType<Projectiles.Blizzard>();
			Item.buffType = ModContent.BuffType<IceBuff>();
		}
		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			player.AddBuff(Item.buffType, 2);
			position = Main.MouseWorld;
			return true;
		}
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<Materials.IceSpikes>(), 37);
			recipe.AddIngredient(ItemID.IceBlock, 16);
			recipe.AddIngredient(ItemID.Shiverthorn, 1);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}