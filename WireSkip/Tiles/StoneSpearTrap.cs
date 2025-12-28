using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace WireSkip.Tiles
{
    public class StoneSpearTrap : ModTile
    {
        public const int DAMAGE = 25; // Half Lihzahrd Spear Trap
        public const int COOLDOWN = 120;

        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            TileID.Sets.HasOutlines[Type] = true;
            AddMapEntry(new Microsoft.Xna.Framework.Color(140, 140, 140));
            HitSound = SoundID.Tink;
        }
    }
}