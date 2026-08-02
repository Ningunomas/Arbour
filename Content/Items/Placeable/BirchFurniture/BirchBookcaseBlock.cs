using Terraria.ID;
using Terraria.ModLoader;

namespace Arbour.Content.Items.Placeable.BirchFurniture;

public class BirchBookcaseBlock : ModItem
{
    public override void SetStaticDefaults() => Item.ResearchUnlockCount = 3;
    public override void SetDefaults() => Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.Multitiles.Furniture.BirchBookcase>());

    public override void AddRecipes()
    {
        CreateRecipe(1).
            AddIngredient<BirchWoodBlock>(20).
            AddIngredient(ItemID.Book, 10).
            AddTile(TileID.Sawmill).
            Register();
    }
}