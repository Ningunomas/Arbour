using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Arbour.Content.NPCs.Mispirit;

internal class MispiritLeaves : ModProjectile
{
    public override bool IsLoadingEnabled(Mod mod) => false;

    const float WaveMod = 0.02f;

    private NPC Owner => Main.npc[(int)Projectile.ai[0]];

    internal int _timer = 0;
    internal Vector2 _velScaling = Vector2.One;

    float WaveAdjustment => _timer * WaveMod;

    public override void SetStaticDefaults()
    {
        // DisplayName.SetDefault("Mispirit Leaf");

        Main.projFrames[Type] = 4;
    }

    public override void SetDefaults()
    {
        Projectile.hostile = false;
        Projectile.friendly = true;
        Projectile.width = 30;
        Projectile.height = 34;
        Projectile.penetrate = -1;
        Projectile.tileCollide = false;
        Projectile.ignoreWater = true;
        Projectile.aiStyle = -1;
    }

    public override bool? CanCutTiles() => false;
    public override bool MinionContactDamage() => false;

    public override void DrawBehind(int index, List<int> behindNPCsAndTiles, List<int> behindNPCs, List<int> behindProjectiles, List<int> overPlayers, List<int> overWiresUI)
    {
        if (Projectile.hide)
            behindNPCs.Add(index);
    }

    public override void AI()
    {
        _timer++;

        if (Owner.life <= 0)
            Projectile.Kill();

        Projectile.timeLeft = 2;

        float xOff = (float)Math.Sin(WaveAdjustment);

        //Projectile.Center = Owner.Center + new Vector2(0, Owner.gfxOffY);
        //Projectile.position.X += xOff * 34f * _velScaling.X + (Projectile.width / 4);
        //Projectile.position.Y += (float)Math.Sin(Projectile.ai[1]++ * 0.06f) * 18f * _velScaling.Y + (Projectile.height / 4);

        Projectile.scale = 1 - Math.Abs((float)Math.Cos(WaveAdjustment * 0.5f)) * 0.4f;

        float xVel = xOff * 34f * _velScaling.X + (Projectile.width / 4);
        float yVel = (float)Math.Sin(Projectile.ai[1]++ * 0.06f) * 18f * _velScaling.Y + (Projectile.height / 4);
        Projectile.velocity = (new Vector2(xVel, yVel) * 0.2f) + ((Owner.Center - Projectile.Center) * 0.2f);
        Projectile.rotation = (xOff * 0.8f) + (Owner.velocity.X * 0.2f);

        Lighting.AddLight(Projectile.Center, new Vector3(0.4f, 0.12f, 0.24f) * 0.8f);

        if (Math.Cos(WaveAdjustment) > 0)
            Projectile.hide = true;
        else
            Projectile.hide = false;
    }

    public override void OnSpawn(IEntitySource source)
    {
        Projectile.frame = Main.rand.Next(4);

        _timer = Main.rand.Next(50000);
        _velScaling = new Vector2(Main.rand.NextFloat(1f, 4f), 0).RotatedByRandom(MathHelper.TwoPi) * new Vector2(1f, 1f);
    }

    public override Color? GetAlpha(Color lightColor)
    {
        float adj = 1 - Math.Abs((float)Math.Cos(WaveAdjustment * 0.5f)) * 0.5f;
        Color col = Lighting.GetColor(Projectile.Center.ToTileCoordinates());

        return Color.Lerp(col, Color.Black, 1 - adj);
    }
}
