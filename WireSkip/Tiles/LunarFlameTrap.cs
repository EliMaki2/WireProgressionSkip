using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace WireSkip.Tiles
{
    public class LunarFlameTrap : ModTile
    {
        public const int DAMAGE = 60; // 3x Stone Flame
        public const int COOLDOWN = 40;

        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            TileID.Sets.HasOutlines[Type] = true;
            AddMapEntry(new Microsoft.Xna.Framework.Color(255, 50, 200));
            HitSound = SoundID.Item34;
        }
    }
}