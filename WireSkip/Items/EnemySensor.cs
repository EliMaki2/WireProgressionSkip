using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace WireSkip.Items
{
    public class EnemySensor : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Enemy Sensor");
            // Tooltip.SetDefault("Detects nearby enemies and triggers wires.");
        }

        public override void SetDefaults()
        {
            Item.width = 16;
            Item.height = 16;
            Item.maxStack = 99;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.consumable = true;
            Item.value = Item.buyPrice(gold: 1); // base value 1 gold
            Item.rare = ItemRarityID.Green;
            Item.createTile = ModContent.TileType<Tiles.EnemySensor>();
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.Wire, 5)
                .AddIngredient(ItemID.WireCutter, 1)
                .AddIngredient(ItemID.IronBar, 3)
                .AddTile(TileID.WorkBenches)
                .Register();
        }
    }
}