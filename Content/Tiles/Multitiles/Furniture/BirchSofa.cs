using Arbour.Content.Items.Placeable.BirchFurniture;
using Arbour.Content.Tiles.Multitiles.FurnitureHelpers;
using Terraria.ID;
using Terraria.ModLoader;

namespace Arbour.Content.Tiles.Multitiles.Furniture;

public class BirchSofa : SofaTile<BirchSofaItem>
{
    protected override SpecificTileInfo SpecificInfo => new(ModContent.ItemType<BirchSofaItem>(), DustID.WoodFurniture, new(114, 69, 39));
}