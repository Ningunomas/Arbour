using Arbour.Content.Tiles.Multitiles.Furniture;
using Terraria.ID;
using Terraria.ModLoader;

namespace Arbour.Content.Items.Placeable.BirchFurniture;

public class BirchWoodLampBlock : ModItem
{
    public override void SetStaticDefaults() => Item.ResearchUnlockCount = 3;
    public override void SetDefaults() => Item.DefaultToPlaceableTile(ModContent.TileType<BirchLamp>());

    public override void AddRecipes()
    {
        CreateRecipe().
            AddIngredient<BirchWoodBlock>(6).
            AddIngredient(ItemID.Torch).
            AddTile(TileID.WorkBenches).
            Register();
    }
}