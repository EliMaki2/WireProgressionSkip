using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace WireSkip.Tiles
{
    public class LunarSpearTrap : ModTile
    {
        public const int DAMAGE = 75; // 3x Stone Spear
        public const int COOLDOWN = 40; // 1/3 cooldown of stone trap

        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            TileID.Sets.HasOutlines[Type] = true;
            AddMapEntry(new Microsoft.Xna.Framework.Color(180, 0, 255));
            HitSound = SoundID.Item34;
        }
    }
}