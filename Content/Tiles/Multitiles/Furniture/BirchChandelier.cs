using Arbour.Content.Items.Placeable.BirchFurniture;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace Arbour.Content.Tiles.Multitiles.Furniture;

internal class BirchChandelier : ModTile
{
    public override void SetStaticDefaults()
    {
        Main.tileLighted[Type] = true;
        Main.tileFrameImportant[Type] = true;
        Main.tileNoAttach[Type] = true;
        Main.tileWaterDeath[Type] = true;
        Main.tileLavaDeath[Type] = true;

        TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3);
        TileObjectData.newTile.WaterDeath = true;
        TileObjectData.newTile.WaterPlacement = LiquidPlacement.NotAllowed;
        TileObjectData.newTile.LavaDeath = true;
        TileObjectData.newTile.LavaPlacement = LiquidPlacement.NotAllowed;
        TileObjectData.newTile.AnchorTop = new AnchorData(AnchorType.SolidBottom | AnchorType.SolidTile, 1, 1);
        TileObjectData.newTile.AnchorBottom = AnchorData.Empty;
        TileObjectData.addTile(Type);

        AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTorch);
        AddMapEntry(new Color(253, 221, 3), Language.GetText("MapObject.Chandelier"));
        RegisterItemDrop(ModContent.ItemType<BirchChandelierBlock>());
    }

    public override void HitWire(int i, int j)
    {
        Tile tile = Main.tile[i, j];
        int topX = i - tile.TileFrameX / 18 % 3;
        int topY = j - tile.TileFrameY / 18 % 3;
        short frameAdjustment = (short)(Framing.GetTileSafely(topX, topY).TileFrameX > 0 ? -54 : 54);
        for (int k = 0; k < 3; ++k)
        {
            for (int b = 0; b < 3; ++b)
            {
                Main.tile[topX + k, topY + b].TileFrameX += frameAdjustment;
                Wiring.SkipWire(topX + k, topY + b);
            }
        }
        NetMessage.SendTileSquare(-1, i, topY + 1, 2, TileChangeType.None);
    }

    public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
    {
        Tile tile = Main.tile[i, j];
        (int frameX, int frameY) = (tile.TileFrameX, tile.TileFrameY);

        if ((frameX < 36 && frameY == 36) || (frameX == 36 && frameY == 18))
        {
            Vector3 light = new Vector3(0.5f, 0.36f, 0.18f) * 2;
            r = light.X;
            g = light.Y;
            b = light.Z;
        }
    }
}
