using Terraria.ID;
using Terraria.ModLoader;

namespace Arbour.Content.Items.Placeable.BirchFurniture;

public class BirchChandelierBlock : ModItem
{
    public override void SetStaticDefaults() => Item.ResearchUnlockCount = 3;
    public override void SetDefaults() => Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.Multitiles.Furniture.BirchChandelier>());

    public override void AddRecipes()
    {
        CreateRecipe(1).
            AddIngredient<BirchWoodBlock>(4).
            AddIngredient(ItemID.FireflyinaBottle, 3).
            AddIngredient(ItemID.Chain, 1).
            AddTile(TileID.Anvils).
            Register();
    }
}