using Arbour.Content.Tiles.TileEntity;
using Terraria.ModLoader;
using Terraria;

namespace Arbour.Content.Items.Placeable;

public class ArborPylonItem : ModItem
{
	public override void SetStaticDefaults() => Item.ResearchUnlockCount = 1;

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<ArborPylonTile>());
        Item.value = Item.buyPrice(0, 10, 0, 0);
    }
}