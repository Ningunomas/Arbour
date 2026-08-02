using Arbour.Content.Tiles.Multitiles.Furniture;
using Terraria.ID;
using Terraria.ModLoader;

namespace Arbour.Content.Items.Placeable.BirchFurniture;

public class BirchSinkItem : ModItem
{
    public override void SetStaticDefaults() => Item.ResearchUnlockCount = 3;
    public override void SetDefaults() => Item.DefaultToPlaceableTile(ModContent.TileType<BirchSink>());
    public override void AddRecipes() => CreateRecipe().AddIngredient<BirchWoodBlock>(6).AddIngredient(ItemID.WaterBucket).AddTile(TileID.WorkBenches).Register();
}