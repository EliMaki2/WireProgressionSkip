using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace WireSkip.Tiles
{
    public class StoneSpikeBallTrap : ModTile
    {
        public const int DAMAGE = 20; // Half Lihzahrd Spike Ball
        public const int COOLDOWN = 120;

        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            TileID.Sets.HasOutlines[Type] = true;
            AddMapEntry(new Microsoft.Xna.Framework.Color(160, 160, 160));
            HitSound = SoundID.Tink;
        }
    }
}
