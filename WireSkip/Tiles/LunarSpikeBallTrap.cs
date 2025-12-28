using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace WireSkip.Tiles
{
    public class LunarSpikeBallTrap : ModTile
    {
        public const int DAMAGE = 60; // 3x Stone Spike Ball
        public const int COOLDOWN = 40;

        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            TileID.Sets.HasOutlines[Type] = true;
            AddMapEntry(new Microsoft.Xna.Framework.Color(200, 50, 255));
            HitSound = SoundID.Item34;
        }
    }
}