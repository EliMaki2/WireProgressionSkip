using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;

namespace WireSkip.TileEntities
{
    // TileEntity for a Stone Dart Trap
    public class StoneDartTrapTE : ModTileEntity
    {
        private int cooldown = 0; // counter to enforce cooldown between shots
        private const int MAX_COOLDOWN = 120; // double vanilla Lihzahrd dart trap

        public override void Update()
        {
            if (cooldown > 0) { cooldown--; return; } // wait until cooldown is 0

            Point16 tilePos = Position; // current tile coordinates
            Tile tile = Framing.GetTileSafely(tilePos.X, tilePos.Y);
            if (!tile.HasTile) return; // ensure tile exists

            // Check if wire triggered this tile
            if (Wiring.CheckMech(tilePos.X, tilePos.Y, 1))
            {
                // Skip this red wire for the rest of the tick
                Wiring.SkipWire(tilePos.X, tilePos.Y);

                // Spawn dart projectile
                Projectile.NewProjectile(
                    new EntitySource_TileInteraction(null, tilePos.X, tilePos.Y),
                    tilePos.X * 16 + 8, tilePos.Y * 16,
                    10f, 0f, // horizontal speed
                    ProjectileID.PoisonDartTrap,
                    15,      // damage (half vanilla)
                    2f,      // knockback
                    Main.myPlayer
                );

                cooldown = MAX_COOLDOWN; // reset cooldown
            }
        }

        // Ensure TileEntity only attaches to the correct tile
        public override bool IsTileValidForEntity(int i, int j)
        {
            return Main.tile[i, j].HasTile &&
                   Main.tile[i, j].TileType == ModContent.TileType<Tiles.StoneDartTrap>();
        }

        // Register TileEntity on placement
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