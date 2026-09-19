using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Arbour.Content.Tiles.Blocks;

public class VineRopeTile : ModTile
{
    // To be done later. I'm lazy!
    public override bool IsLoadingEnabled(Mod mod) => false;

    public override void SetStaticDefaults()
    {
        Main.tileSolid[Type] = false;
        Main.tileCut[Type] = false;
        Main.tileMergeDirt[Type] = false;
        Main.tileBlockLight[Type] = false;
        Main.tileRope[Type] = true;
        Main.tileFrameImportant[Type] = false;

        AddMapEntry(new Color(23, 102, 32));

        DustType = DustID.Grass;
        HitSound = SoundID.Grass;
    }

    public override void NumDust(int i, int j, bool fail, ref int num) => num = 3;
}