using System;

namespace ConsoleApp1
{
    internal class Inventory : Item
    {
        public string[] InventoryContent { get; init; }
        public Inventory(int keyCount = 0, int knifeCount = 0, int healCount = 0, int NumberCellsInventory = 8) : base(keyCount, knifeCount, healCount)
        {
            InventoryContent = new string[NumberCellsInventory];

            for (int i = 0; i < InventoryContent.Length; i++)
            {
                if (keyCount > 0)
                {
                    InventoryContent[i] = keySymbol;
                    KeyCount = keyCount;
                    keyCount = 0;
                }
                else if (knifeCount > 0)
                {
                    InventoryContent[i] = knifeSymbol;
                    KnifeCount = knifeCount;
                    knifeCount = 0;
                }
                else if (healCount > 0)
                {
                    InventoryContent[i] = healSymbol;
                    HealCount = healCount;
                    healCount = 0;
                }
                else
                {
                    InventoryContent[i] = "[ ]";
                }
            }
        }
        public static void CloseInventory(Inventory inventory)
        {
            Console.WriteLine("Чтобы закрыть инвентарь нажмите 0");
            Program.ShowInventory(inventory);
            while (true)
            {
                if (char.TryParse(Console.ReadLine(), out char exit) && exit == '0')
                {
                    break;
                }
            }
        }
        public static void Add(string enter)
        {
            if (enter == "++")
            {
                KeyCount = KeyCount + Box.KeyCount;
                Console.WriteLine("drftyguhijkl");
            }
        }
    }
}