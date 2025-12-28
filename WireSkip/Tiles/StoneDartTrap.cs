using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace WireSkip.Tiles
{
    public class StoneDartTrap : ModTile
    {
        public const int DAMAGE = 15; // Half Lihzahrd Dart Trap
        public const int COOLDOWN = 120;

        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileSolid[Type] = false;
            TileID.Sets.HasOutlines[Type] = true;
            AddMapEntry(new Microsoft.Xna.Framework.Color(150, 150, 150));
            HitSound = SoundID.Tink;
        }
    }
}