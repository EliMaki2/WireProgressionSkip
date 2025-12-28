using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace WireSkip.Tiles
{
    public class StoneFlameTrap : ModTile
    {
        public const int DAMAGE = 20; // Half Lihzahrd Flame Trap
        public const int COOLDOWN = 120;

        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            TileID.Sets.HasOutlines[Type] = true;
            AddMapEntry(new Microsoft.Xna.Framework.Color(200, 80, 80));
            HitSound = SoundID.Tink;
        }
    }
}