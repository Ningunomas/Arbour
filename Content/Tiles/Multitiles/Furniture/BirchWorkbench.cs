using Arbour.Content.Items.Placeable.BirchFurniture;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace Arbour.Content.Tiles.Multitiles.Furniture;

public class BirchWorkbench : ModTile
{
	public override void SetStaticDefaults()
	{
		Main.tileTable[Type] = true;
		Main.tileSolidTop[Type] = true;
		Main.tileNoAttach[Type] = true;
		Main.tileLavaDeath[Type] = true;
		Main.tileFrameImportant[Type] = true;
		TileID.Sets.DisableSmartCursor[Type] = true;
		TileID.Sets.IgnoredByNpcStepUp[Type] = true;

		DustType = ModContent.DustType<Dusts.BirchDust>();
		AdjTiles = new int[] { TileID.WorkBenches };

		TileObjectData.newTile.CopyFrom(TileObjectData.Style2x1);
		TileObjectData.newTile.CoordinateHeights = new[] { 18 };
		TileObjectData.addTile(Type);

		AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTable);
        RegisterItemDrop(ModContent.ItemType<BirchWorkbenchBlock>());
		AddMapEntry(new Color(229, 208, 222), CreateMapEntryName());
    }

	public override void NumDust(int x, int y, bool fail, ref int num) => num = fail ? 1 : 3;
}