using System;

namespace ConsoleApp1
{
    internal class Inventory
    {
        public string[] inventory { get; init; }
        public int Keys { get; init; }
        public int FoldingKnife { get; init; }
        public int Heal { get; init; }
        private int KeyCount { get; set; }
        private int HealCount { get; set; }
        private int KnifeCount { get; set; }
        public Inventory(string keySymbol, string knifeSymbol, string healSymbol, int keyCount = 0, int knifeCount = 0, int healCount = 0, int NumberCellsInventory = 8)
        {
            inventory = new string[NumberCellsInventory];
            this.KeyCount = keyCount;
            this.KnifeCount = knifeCount;
            this.HealCount = healCount;
            for (int i = 0; i < inventory.Length; i++)
            {
                if (keyCount > 0)
                {
                    inventory[i] = keySymbol;
                    Keys = keyCount;
                    keyCount = 0;
                }
                else if (knifeCount > 0)
                {
                    inventory[i] = knifeSymbol;
                    FoldingKnife = knifeCount;
                    knifeCount = 0;
                }
                else if (healCount > 0)
                {
                    inventory[i] = healSymbol;
                    Heal = healCount;
                    healCount = 0;
                }
                else
                {
                inventory[i] = "[ ]";
                }
            }
        }
    }
}