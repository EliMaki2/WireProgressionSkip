using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace WireSkip.Tiles
{
    public class LunarDartTrap : ModTile
    {
        public const int DAMAGE = 45; // 3x Stone Dart
        public const int COOLDOWN = 40;

        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileSolid[Type] = false;
            TileID.Sets.HasOutlines[Type] = true;
            AddMapEntry(new Microsoft.Xna.Framework.Color(180, 0, 255));
            HitSound = SoundID.Item34;
        }
    }
}