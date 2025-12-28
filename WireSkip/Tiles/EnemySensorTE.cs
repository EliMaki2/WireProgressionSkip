using Terraria;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;

namespace WireSkip.Tiles
{
    public class EnemySensorTE : ModTileEntity
    {
        private bool wireActive = false;

        public override void Update()
        {
            int i = Position.X;
            int j = Position.Y;

            // Detection rectangle above the sensor (7 tiles wide × 6 tiles tall)
            int rectWidth = 7;
            int rectHeight = 6;
            int startX = i - rectWidth / 2; // horizontally centered
            int startY = j - rectHeight;    // directly above sensor

            bool enemyDetected = false;

            foreach (NPC npc in Main.npc)
            {
                if (npc.active && !npc.friendly && !npc.townNPC)
                {
                    int npcTileX = (int)(npc.Center.X / 16f);
                    int npcTileY = (int)(npc.Center.Y / 16f);

                    if (npcTileX >= startX && npcTileX < startX + rectWidth &&
                        npcTileY >= startY && npcTileY < startY + rectHeight)
                    {
                        enemyDetected = true;
                        break; // one enemy is enough
                    }
                }
            }

            // If at least one enemy is detected and wire is not active, activate it
            if (enemyDetected && !wireActive)
            {
                Wiring.TripWire(i, j, 1, 1); // activate wire
                wireActive = true;
            }

            // If no enemies are in the rectangle, reset the signal
            if (!enemyDetected && wireActive)
            {
                // Reset the wire manually so it can be triggered again
                // (simulate switch reset)
                wiringReset(i, j);
                wireActive = false;
            }
        }

        // Helper method to reset the wire so it can trigger again
        private void wiringReset(int i, int j)
        {
            Tile tile = Framing.GetTileSafely(i, j);
            if (tile != null)
            {
                Wiring.SkipWire(i, j); // make sure next TripWire works
            }
        }

        public override bool IsTileValidForEntity(int i, int j)
        {
            Tile tile = Framing.GetTileSafely(i, j);
            return tile.HasTile && tile.TileType == ModContent.TileType<EnemySensor>();
        }
    }
}