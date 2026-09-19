using Arbour.Content.Tiles.Multitiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Arbour.Content.Tiles.Blocks;

public class ArborGrass : ModTile
{
	public override void SetStaticDefaults()
	{
		Main.tileSolid[Type] = true;
		Main.tileMerge[Type][Type] = true;
		Main.tileBlockLight[Type] = true;
		Main.tileMerge[TileID.Dirt][Type] = true;

		TileID.Sets.Grass[Type] = true;
		TileID.Sets.Conversion.Grass[Type] = true;
		
		AddMapEntry(new Color(198, 98, 43));
		RegisterItemDrop(ItemID.DirtBlock);

        DustType = ModContent.DustType<Dusts.LeafDust>();
    }

    public override bool CanExplode(int i, int j)
	{
		WorldGen.KillTile(i, j);
		return true;
	}

    public override void KillTile(int i, int j, ref bool fail, ref bool effectOnly, ref bool noItem)
	{
		if (!fail) //Change self into dirt
		{
			fail = true;
			Framing.GetTileSafely(i, j).TileType = TileID.Dirt;
		}
	}

    public override void RandomUpdate(int i, int j)
    {
		Tile tile = Main.tile[i, j + 1];

		if (!tile.HasTile)
		{
			bool success = false;

			if (Main.rand.NextBool(220))
                success = WorldGen.PlaceTile(i, j + 1, ModContent.TileType<MicrobirchSapling>(), true);

			if (success)
                NetMessage.SendTileSquare(-1, i, j + 1, 1, TileChangeType.None);
        }

		//Try spread grass
		if (TileHelper.Spread(i, j, Type, 4, TileID.Dirt) && Main.netMode != NetmodeID.SinglePlayer)
			NetMessage.SendTileSquare(-1, i, j, 3, TileChangeType.None);

		//Spawn hay foliage
		if (Main.rand.NextBool(65) && TileHelper.TryPlaceProperly(i, j, ModContent.TileType<Hay1x3>(), forceIfPossible: false))
			return;

		if (Main.rand.NextBool(50) && TileHelper.TryPlaceProperly(i, j, ModContent.TileType<Hay1x2>(), forceIfPossible: false))
			return;

		if (Main.rand.NextBool(20) && TileHelper.TryPlaceProperly(i, j, ModContent.TileType<Hay1x1>(), forceIfPossible: false))
			return;
	}
}
