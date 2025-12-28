using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace WireSkip.Items
{
    // This is the item that places the Lunar Spear Trap tile
    public class LunarSpearTrapItem : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 16;          // item sprite width
            Item.height = 16;         // item sprite height
            Item.maxStack = 99;       // stack limit
            Item.useTurn = true;      // turn player when placing
            Item.autoReuse = true;    // allow holding to place multiple
            Item.useAnimation = 15;   // animation speed
            Item.useTime = 10;        // placement speed
            Item.useStyle = ItemUseStyleID.Swing; // swing to place
            Item.consumable = true;   // consumes on placement
            Item.value = Item.buyPrice(gold: 5); // base value
            Item.rare = ItemRarityID.Lime;       // item rarity
            Item.createTile = ModContent.TileType<Tiles.LunarSpearTrap>(); // the tile it places
        }

        // No crafting recipes since this trap is naturally placed
        public override void AddRecipes()
        {
            // Empty
        }
    }
}