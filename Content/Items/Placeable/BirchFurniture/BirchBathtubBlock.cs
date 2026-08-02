using Terraria.ID;
using Terraria.ModLoader;

namespace Arbour.Content.Items.Placeable.BirchFurniture;

public class BirchBathtubBlock : ModItem
{
    public override void SetStaticDefaults() => Item.ResearchUnlockCount = 3;
    public override void SetDefaults() => Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.Multitiles.Furniture.BirchBathtub>());

    public override void AddRecipes()
    {
        CreateRecipe(1).
            AddIngredient<BirchWoodBlock>(14).
            AddTile(TileID.Sawmill).
            Register();
    }
}