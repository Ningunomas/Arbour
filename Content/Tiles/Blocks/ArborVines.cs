using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Arbour.Content.Tiles.Blocks;

[TileTag(TileTags.NeedsTopAnchor)]
internal class ArborVines : ModTile
{
    public class ArborVineGlobalTile : GlobalTile
    {
        private int Vine;
        private int Grass;

        public override void SetStaticDefaults()
        {
            Vine = ModContent.TileType<ArborVines>();
            Grass = ModContent.TileType<ArborGrass>();
        }

        public override void RandomUpdate(int i, int j, int type)
        {
            Tile tile = Main.tile[i, j];

            if (!tile.HasUnactuatedTile)
                return;

            if ((tile.TileType == Vine || tile.TileType == Grass) && WorldGen.GrowMoreVines(i, j))
            {
                int growChance = 20;

                if (tile.TileType == Vine)
                    growChance = 5;

                int below = j + 1;
                Tile tileBelow = Main.tile[i, below];

                if (WorldGen.genRand.NextBool(growChance) && !tileBelow.HasTile && tileBelow.LiquidType != LiquidID.Lava)
                {
                    bool vineIsHangingOffValidTile = false;

                    for (int above = j; above > j - 10; above--)
                    {
                        Tile tileAbove = Main.tile[i, above];

                        if (tileAbove.BottomSlope)
                            return;

                        if (tileAbove.HasTile && tileAbove.TileType == Grass && !tileAbove.BottomSlope)
                        {
                            vineIsHangingOffValidTile = true;
                            break;
                        }
                    }

                    if (vineIsHangingOffValidTile)
                    {
                        tileBelow.TileType = (ushort)Vine;
                        tileBelow.HasTile = true;
                        tileBelow.CopyPaintAndCoating(tile);
                        WorldGen.SquareTileFrame(i, below);

                        if (Main.netMode == NetmodeID.Server)
                            NetMessage.SendTileSquare(-1, i, below);
                    }
                }
            }
        }

        public override bool TileFrame(int i, int j, int type, ref bool resetFrame, ref bool noBreak)
        {
            if (!TileID.Sets.IsVine[type])
                return true;

            Tile tile = Main.tile[i, j];
            Tile tileAbove = Main.tile[i, j - 1];
            int aboveTileType = tileAbove.HasUnactuatedTile && !tileAbove.BottomSlope ? tileAbove.TileType : -1;

            if (type != aboveTileType)
            {
                if ((aboveTileType == Grass || aboveTileType == Vine) && type != Vine)
                {
                    tile.TileType = (ushort)Vine;
                    WorldGen.SquareTileFrame(i, j);
                    return true;
                }

                if (type == Vine && aboveTileType != Grass)
                {
                    if (aboveTileType == -1)
                        WorldGen.KillTile(i, j);
                    else
                        tile.TileType = TileID.Vines;
                }
            }

            return true;
        }
    }

    public override void SetStaticDefaults()
    {
        Main.tileCut[Type] = true;
        Main.tileBlockLight[Type] = true;
        Main.tileLavaDeath[Type] = true;
        Main.tileNoFail[Type] = true;

        TileID.Sets.TileCutIgnore.Regrowth[Type] = true;

        TileID.Sets.IsVine[Type] = true;
        TileID.Sets.ReplaceTileBreakDown[Type] = true;
        TileID.Sets.VineThreads[Type] = true;

        AddMapEntry(Color.OrangeRed);

        DustType = DustID.Pumpkin;
        HitSound = SoundID.Grass;
    }

    public override bool PreDraw(int i, int j, SpriteBatch spriteBatch)
    {
        Main.instance.TilesRenderer.CrawlToTopOfVineAndAddSpecialPoint(j, i);
        return false;
    }

    public override void SetDrawPositions(int i, int j, ref int width, ref int offsetY, ref int height, ref short tileFrameX, ref short tileFrameY) => offsetY = -2;

    public override void SetSpriteEffects(int i, int j, ref SpriteEffects spriteEffects)
    {
        if (i % 2 == 0)
            spriteEffects = SpriteEffects.FlipHorizontally;
    }

    public override IEnumerable<Item> GetItemDrops(int i, int j)
    {
        if (Main.rand.NextBool(2) && WorldGen.GetPlayerForTile(i, j).cordage)
            yield return new Item(ItemID.VineRope);
    }

    public override bool TileFrame(int i, int j, ref bool resetFrame, ref bool noBreak)
    {
        Tile tile = Main.tile[i, j];
        tile.TileFrameX = (short)(18 * Main.rand.Next(2));

        if (Main.rand.NextBool(3))
            tile.TileFrameX += (short)(18 * Main.rand.Next(2));

        tile.TileFrameY = (short)(Main.rand.Next(3) * 18);

        if (!Main.tile[i, j + 1].HasTile)
            tile.TileFrameY = 3 * 18;

        return false;
    }
}