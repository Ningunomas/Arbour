using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Terraria.ObjectData;
using Arbour.Content.Items.Placeable.BirchFurniture;

namespace Arbour.Content.Tiles.Multitiles.Furniture;

public class BirchBookcase : ModTile
{
    public override void SetStaticDefaults()
    {
        Main.tileFrameImportant[Type] = true;
        Main.tileNoAttach[Type] = true;
        Main.tileLavaDeath[Type] = true;
        Main.tileSolidTop[Type] = true;
        Main.tileTable[Type] = true;

        TileID.Sets.DisableSmartCursor[Type] = true;

        TileObjectData.newTile.CopyFrom(TileObjectData.Style3x4);
        TileObjectData.newTile.CoordinateHeights = [16, 16, 16, 18];
        TileObjectData.addTile(Type);

        AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTable);
        AddMapEntry(new Color(114, 69, 39), Terraria.Localization.Language.GetText("ItemName.Bookcase"));
        RegisterItemDrop(ModContent.ItemType<BirchBookcaseBlock>());

        DustType = DustID.Grass;
        AdjTiles = [TileID.Bookcases];
    }

    public override void NumDust(int i, int j, bool fail, ref int num) => num = fail ? 1 : 3;
}
