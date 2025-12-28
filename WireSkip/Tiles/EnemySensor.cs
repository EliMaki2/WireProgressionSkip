using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace WireSkip.Tiles
{
    public class EnemySensor : ModTile
    {
        private const int WIDTH = 7;
        private const int HEIGHT = 6;

        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileSolid[Type] = false;
            TileID.Sets.HasOutlines[Type] = true;

            AddMapEntry(new Color(200, 50, 50));
            HitSound = SoundID.Tink;
            DustType = DustID.Electric;
        }

        public override void NearbyEffects(int i, int j, bool closer)
        {
            bool enemyFound = false;
            int tileX = i - WIDTH / 2;
            int tileY = j - HEIGHT;

            for (int x = tileX; x < tileX + WIDTH; x++)
            {
                for (int y = tileY; y < tileY + HEIGHT; y++)
                {
                    foreach (NPC npc in Main.npc)
                    {
                        if (npc.active && !npc.friendly && !npc.townNPC)
                        {
                            Vector2 center = new Vector2(x * 16 + 8, y * 16 + 8);
                            if (Vector2.Distance(npc.Center, center) < 1) // center-based check
                            {
                                enemyFound = true;
                                break;
                            }
                        }
                    }
                    if (enemyFound) break;
                }
                if (enemyFound) break;
            }

            if (enemyFound)
                Wiring.TripWire(i, j, 1, 1);
        }
    }
}