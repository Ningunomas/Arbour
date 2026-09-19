using Arbour.Content.Tiles.Multitiles.Furniture;
using Terraria.ID;
using Terraria.ModLoader;

namespace Arbour.Content.Items.Placeable.BirchFurniture;

public class BirchSofaItem : ModItem
{
    public override void SetStaticDefaults() => Item.ResearchUnlockCount = 3;
    public override void SetDefaults() => Item.DefaultToPlaceableTile(ModContent.TileType<BirchSofa>());
    public override void AddRecipes() => CreateRecipe().AddIngredient(ModContent.ItemType<BirchWoodBlock>(), 5).AddIngredient(ItemID.Silk).AddTile(TileID.Sawmill).Register();
}