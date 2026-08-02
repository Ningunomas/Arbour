using Arbour.Content.Tiles.Blocks;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Arbour.Content.Items.Placeable;

public class ArborGrassSeeds : ModItem
{
	public override void SetStaticDefaults() => Item.ResearchUnlockCount = 25;

	public override void SetDefaults()
	{
		Item.autoReuse = true;
		Item.useTurn = true;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useAnimation = 15;
		Item.rare = ItemRarityID.White;
		Item.useTime = 15;
		Item.maxStack = 999;
		Item.width = 16;
		Item.height = 18;
		Item.consumable = true;
		Item.value = Item.buyPrice(0, 0, 0, 5);
	}

	public override bool? UseItem(Player player)
	{
		if (Main.myPlayer == player.whoAmI)
		{
			Tile tile = Framing.GetTileSafely(Player.tileTargetX, Player.tileTargetY);

			if (tile.HasTile && tile.TileType == TileID.Dirt && player.InInteractionRange(Player.tileTargetX, Player.tileTargetY, TileReachCheckSettings.Simple))
			{
				tile.TileType = (ushort)ModContent.TileType<ArborGrass>();
				WorldGen.SquareTileFrame(Player.tileTargetX, Player.tileTargetY, true);
				NetMessage.SendTileSquare(-1, Player.tileTargetX, Player.tileTargetY, 1, TileChangeType.None);
				return true;
			}
		}

		return false;
	}
}
