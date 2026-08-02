using Terraria.ID;
using Terraria.ModLoader;

namespace Arbour.Content.Items.Placeable.BirchFurniture;

public class BirchChestBlock : ModItem
{
    public override void SetStaticDefaults() => Item.ResearchUnlockCount = 3;
    public override void SetDefaults() => Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.Multitiles.Furniture.BirchChest>());

    public override void AddRecipes() => CreateRecipe(1).
        AddIngredient<BirchWoodBlock>(8).
        AddIngredient(ItemID.IronBar, 2).
        AddTile(TileID.WorkBenches).
        Register();
}