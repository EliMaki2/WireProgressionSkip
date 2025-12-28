using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;

namespace WireSkip.NPCs
{
    ublic class WireThief : ModNPC
{
    public override string Texture => "WireSkip/NPCs/WireThief";

    public override void SetStaticDefaults()
    {
        Main.npcFrameCount[Type] = Main.npcFrameCount[NPCID.Mechanic];
    }

    public override void SetDefaults()
    {
        NPC.width = 18;
        NPC.height = 40;
        NPC.aiStyle = NPCAIStyleID.Passive;
        NPC.damage = 6;
        NPC.defense = 25;
        NPC.lifeMax = 250;
        NPC.knockBackResist = 0.5f;
        NPC.friendly = true;
        NPC.townNPC = true;
        NPC.HitSound = SoundID.NPCHit1;
        NPC.DeathSound = SoundID.NPCDeath1;

        AnimationType = NPCID.Mechanic;
    }
}
        public override bool CanTownNPCSpawn(int numTownNPCs)
        {
            int[] wiringItems = {
                ItemID.Wire,
                ItemID.Actuator,
                ItemID.WireCutter,
                ItemID.Lever,
                ItemID.DartTrap,
                ItemID.SuperDartTrap,
                ItemID.FlameTrap
            };

            for (int i = 0; i < Main.maxPlayers; i++)
            {
                Player player = Main.player[i];
                if (!player.active) continue;

                foreach (int id in wiringItems)
                    if (player.HasItem(id)) return true;
            }
            return false;
        }

        public override string GetChat()
        {
            WeightedRandom<string> chat = new();

            chat.Add("I didn't steal it. I liberated it.");
            if (NPC.FindFirstNPC(NPCID.Demolitionist) != -1)
                chat.Add("The Demolitionist understands leverage.");
            if (NPC.FindFirstNPC(NPCID.DD2Bartender) != -1)
                chat.Add("The barkeep knows how to keep quiet.");
            if (NPC.FindFirstNPC(NPCID.Mechanic) != -1)
                chat.Add("She asks too many questions.");

            Player player = Main.LocalPlayer;
            if (player.ZoneHallow) chat.Add("Clean signals. Stable currents.");
            if (player.ZoneJungle) chat.Add("The jungle hides mistakes.");
            if (player.ZoneForest) chat.Add("Too open. Too honest.");

            return chat;
        }

        public override void SetChatButtons(ref string button, ref string button2)
        {
            button = "Shop";
        }

        public override void OnChatButtonClicked(bool firstButton, ref string shopName)
        {
            if (firstButton)
            {
                shopName = "Shop";
            }
        }

        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            // Nothing for now
        }

        public override void AddShops()
        {
            var shop = new NPCShop(Type, "Shop");

            // Available from start
            shop.Add(new NPCShop.Entry(ItemID.Wire));

            // After King Slime
            shop.Add(new NPCShop.Entry(509, Condition.downedSlimeKing)); // Red Wrench
            shop.Add(new NPCShop.Entry(ItemID.WireCutter, Condition.downedSlimeKing));
            shop.Add(new NPCShop.Entry(ItemID.Lever, Condition.downedSlimeKing));

            // After Eye of Cthulhu
            shop.Add(new NPCShop.Entry(ItemID.Actuator, Condition.downedBoss1));
            shop.Add(new NPCShop.Entry(ItemID.RedPressurePlate, Condition.downedBoss1));

            // After Skeletron
            shop.Add(new NPCShop.Entry(3613, Condition.downedBoss3)); // Day Sensor
            shop.Add(new NPCShop.Entry(3614, Condition.downedBoss3)); // Night Sensor
            shop.Add(new NPCShop.Entry(3726, Condition.downedBoss3)); // Water Sensor
            shop.Add(new NPCShop.Entry(3727, Condition.downedBoss3)); // Lava Sensor
            shop.Add(new NPCShop.Entry(3728, Condition.downedBoss3)); // Honey Sensor
            shop.Add(new NPCShop.Entry(3615, Condition.downedBoss3)); // Player Sensor
            shop.Add(new NPCShop.Entry(ModContent.ItemType<Items.EnemySensor>(), Condition.downedBoss3));

            // After Queen Bee and Goblin Army
            shop.Add(new NPCShop.Entry(3603, Condition.downedQueenBee )); // AND Gate
            shop.Add(new NPCShop.Entry(3604, Condition.downedQueenBee )); // OR Gate
            shop.Add(new NPCShop.Entry(3607, Condition.downedQueenBee )); // XOR Gate
            shop.Add(new NPCShop.Entry(3605, Condition.downedQueenBee )); // NAND Gate
            shop.Add(new NPCShop.Entry(3606, Condition.downedQueenBee )); // NOR Gate
            shop.Add(new NPCShop.Entry(3608, Condition.downedQueenBee )); // XNOR Gate
            shop.Add(new NPCShop.Entry(3602, Condition.downedQueenBee )); // Logic Lamp (Off)
            shop.Add(new NPCShop.Entry(3618, Condition.downedQueenBee )); // Logic Lamp (On)

            // After Brain of Cthulhu or Eater of Worlds
            shop.Add(new NPCShop.Entry(ModContent.ItemType<Items.StoneDartTrapItem>(), Condition.downedBoss2));
            shop.Add(new NPCShop.Entry(ModContent.ItemType<Items.StoneSpearTrapItem>(), Condition.downedBoss2));
            shop.Add(new NPCShop.Entry(ModContent.ItemType<Items.StoneFlameTrapItem>(), Condition.downedBoss2));
            shop.Add(new NPCShop.Entry(ModContent.ItemType<Items.StoneSpikeBallTrapItem>(), Condition.downedBoss2));

            // After Wall of Flesh - Regular vanilla traps
            shop.Add(new NPCShop.Entry(ItemID.DartTrap, Condition.Hardmode));
            shop.Add(new NPCShop.Entry(ItemID.SuperDartTrap, Condition.Hardmode));
            shop.Add(new NPCShop.Entry(ItemID.SpearTrap, Condition.Hardmode));
            shop.Add(new NPCShop.Entry(ItemID.FlameTrap, Condition.Hardmode));
            shop.Add(new NPCShop.Entry(1148, Condition.Hardmode)); 

            // After Moon Lord - Lunar traps
            shop.Add(new NPCShop.Entry(ModContent.ItemType<Items.LunarDartTrapItem>(), Condition.DownedMoonLord));
            shop.Add(new NPCShop.Entry(ModContent.ItemType<Items.LunarSpearTrapItem>(), Condition.DownedMoonLord));
            shop.Add(new NPCShop.Entry(ModContent.ItemType<Items.LunarFlameTrapItem>(), Condition.DownedMoonLord));
            shop.Add(new NPCShop.Entry(ModContent.ItemType<Items.LunarSpikeBallTrapItem>(), Condition.DownedMoonLord));

            shop.Register();
        }
    }
}