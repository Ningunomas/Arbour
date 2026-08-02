using Arbour.Content.Dusts;
using Arbour.Content.Items.Placeable.BirchFurniture;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace Arbour.Content.Tiles.Multitiles.Furniture;

internal class BirchTable : ModTile
{
    public override void SetStaticDefaults()
    {
        Main.tileSolidTop[Type] = true;
        Main.tileFrameImportant[Type] = true;
        Main.tileNoAttach[Type] = true;
        Main.tileTable[Type] = true;
        Main.tileLavaDeath[Type] = true;

        TileObjectData.newTile.CopyFrom(TileObjectData.Style3x2);
        TileObjectData.newTile.CoordinateHeights = new[] { 16, 18 };
        TileObjectData.addTile(Type);

        AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTable);
        AddMapEntry(new Color(124, 93, 68), Language.GetText("MapObject.Table"));
        RegisterItemDrop(ModContent.ItemType<BirchTableBlock>());

        TileID.Sets.DisableSmartCursor[Type] = true;

        AdjTiles = new int[] { TileID.Tables };
        DustType = ModContent.DustType<BirchDust>();
    }

    public override void NumDust(int i, int j, bool fail, ref int num) => num = fail ? 1 : 3;
}