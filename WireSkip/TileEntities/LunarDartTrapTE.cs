using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;

namespace WireSkip.TileEntities
{
    // TileEntity for a Lunar Dart Trap
    public class LunarDartTrapTE : ModTileEntity
    {
        private int cooldown = 0;
        private const int MAX_COOLDOWN = 40; // 1/3 of stone trap

        public override void Update()
        {
            if (cooldown > 0) { cooldown--; return; }

            Point16 tilePos = Position;
            Tile tile = Framing.GetTileSafely(tilePos.X, tilePos.Y);
            if (!tile.HasTile) return;

            if (Wiring.CheckMech(tilePos.X, tilePos.Y, 1))
            {
                Wiring.SkipWire(tilePos.X, tilePos.Y);

                Projectile.NewProjectile(
                    new EntitySource_TileInteraction(null, tilePos.X, tilePos.Y),
                    tilePos.X * 16 + 8, tilePos.Y * 16,
                    10f, 0f,
                    ProjectileID.PoisonDartTrap,
                    45, // 3x stone damage
                    2f,
                    Main.myPlayer
                );

                cooldown = MAX_COOLDOWN;
            }
        }

        public override bool IsTileValidForEntity(int i, int j)
        {
            return Main.tile[i,j].HasTile &&
                   Main.tile[i,j].TileType == ModContent.TileType<Tiles.LunarDartTrap>();
        }

        public override int Hook_AfterPlacement(int i, int j, int type, int style, int direction, int alternate)
        {
            if (Main.netMode == NetmodeID.MultiplayerClient)
            {
                NetMessage.SendTileSquare(Main.myPlayer, i, j, 1);
                NetMessage.SendData(MessageID.TileEntityPlacement, number: i, number2: j, number3: Type);
                return -1;
            }
            return Place(i, j);
        }
    }
}