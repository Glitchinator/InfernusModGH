using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Infernus.Items.Weapon;
using Terraria.GameContent.Creative;
using Microsoft.Xna.Framework;
using Terraria.GameContent.ItemDropRules;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;

namespace Infernus.Items.BossSummon
{
    public class Mechbag : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Treasure Bag");
			Tooltip.SetDefault("{$CommonItemTooltip.RightClickToOpen}");
			ItemID.Sets.BossBag[Type] = true;
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 3;
		}

		public override void SetDefaults()
		{
			Item.maxStack = 999;
			Item.consumable = true;
			Item.width = 52;
			Item.height = 42;
			Item.rare = ItemRarityID.Expert;
		}
		public override bool CanRightClick()
		{
			return true;
		}

		public override Color? GetAlpha(Color lightColor)
		{
			return Color.Lerp(lightColor, Color.White, 0.4f);
		}
		public override void ModifyItemLoot(ItemLoot itemLoot)
		{

			itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Weapon.HardMode.Summon.Mecharmr>(), 2));
            itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Weapon.HardMode.Summon.MechWhip>(), 2));
            itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Weapon.HardMode.Melee.HolyRam>(), 2));
            itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Weapon.HardMode.Ranged.miniholy>(), 2));
            itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Weapon.HardMode.Magic.Cyclone>(), 2));
			itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Weapon.HardMode.Accessories.Mechwings>()));

			itemLoot.Add(ItemDropRule.CoinsBasedOnNPCValue(ModContent.NPCType<NPCs.Calypsical>()));
		}
		public override void PostUpdate()
		{
			Lighting.AddLight(Item.Center, Color.White.ToVector3() * 0.4f);

			if (Item.timeSinceItemSpawned % 12 == 0)
			{
				Vector2 center = Item.Center + new Vector2(0f, Item.height * -0.1f);
				Vector2 direction = Main.rand.NextVector2CircularEdge(Item.width * 0.6f, Item.height * 0.6f);
				float distance = 0.3f + Main.rand.NextFloat() * 0.5f;
				Vector2 velocity = new Vector2(0f, -Main.rand.NextFloat() * 0.3f - 1.5f);

				Dust dust = Dust.NewDustPerfect(center + direction * distance, DustID.SilverFlame, velocity);
				dust.scale = 0.5f;
				dust.fadeIn = 1.1f;
				dust.noGravity = true;
				dust.noLight = true;
				dust.alpha = 0;
			}
		}

		public override bool PreDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, ref float rotation, ref float scale, int whoAmI)
		{
			Texture2D texture = TextureAssets.Item[Item.type].Value;

			Rectangle frame;

			if (Main.itemAnimations[Item.type] != null)
			{
				frame = Main.itemAnimations[Item.type].GetFrame(texture, Main.itemFrameCounter[whoAmI]);
			}
			else
			{
				frame = texture.Frame();
			}

			Vector2 frameOrigin = frame.Size() / 2f;
			Vector2 offset = new Vector2(Item.width / 2 - frameOrigin.X, Item.height - frame.Height);
			Vector2 drawPos = Item.position - Main.screenPosition + frameOrigin + offset;

			float time = Main.GlobalTimeWrappedHourly;
			float timer = Item.timeSinceItemSpawned / 240f + time * 0.04f;

			time %= 4f;
			time /= 2f;

			if (time >= 1f)
			{
				time = 2f - time;
			}

			time = time * 0.5f + 0.5f;

			for (float i = 0f; i < 1f; i += 0.25f)
			{
				float radians = (i + timer) * MathHelper.TwoPi;

				spriteBatch.Draw(texture, drawPos + new Vector2(0f, 8f).RotatedBy(radians) * time, frame, new Color(90, 70, 255, 50), rotation, frameOrigin, scale, SpriteEffects.None, 0);
			}

			for (float i = 0f; i < 1f; i += 0.34f)
			{
				float radians = (i + timer) * MathHelper.TwoPi;

				spriteBatch.Draw(texture, drawPos + new Vector2(0f, 4f).RotatedBy(radians) * time, frame, new Color(140, 120, 255, 77), rotation, frameOrigin, scale, SpriteEffects.None, 0);
			}

			return true;
		}
	}
}