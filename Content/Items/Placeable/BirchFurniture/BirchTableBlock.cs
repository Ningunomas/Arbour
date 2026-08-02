using Arbour.Content.Tiles.Multitiles.Furniture;
using Terraria.ID;
using Terraria.ModLoader;

namespace Arbour.Content.Items.Placeable.BirchFurniture;

public class BirchTableBlock : ModItem
{
    public override void SetStaticDefaults() => Item.ResearchUnlockCount = 3;
    public override void SetDefaults() => Item.DefaultToPlaceableTile(ModContent.TileType<BirchTable>());

    public override void AddRecipes()
    {
        CreateRecipe(1).
            AddIngredient<BirchWoodBlock>(10).
            AddTile(TileID.WorkBenches).
            Register();
    }
}