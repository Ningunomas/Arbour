using Arbour.Content.Tiles.Multitiles.Furniture;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Arbour.Content.Items.Placeable.BirchFurniture;

public class BirchClockBlock : ModItem
{
    public override void SetStaticDefaults() => Item.ResearchUnlockCount = 3;
    public override void SetDefaults() => Item.DefaultToPlaceableTile(ModContent.TileType<BirchClock>());

    public override void AddRecipes()
    {
        Recipe r = CreateRecipe(1);
        r.AddIngredient(ModContent.ItemType<BirchWoodBlock>(), 10);
        r.AddRecipeGroup("IronBar", 3);
        r.AddIngredient(ItemID.Glass, 6);
        r.Register();
    }
}