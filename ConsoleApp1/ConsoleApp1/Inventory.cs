namespace ConsoleApp1
{
    class Inventory : Item
    {
        private protected static int _keyCount;
        private protected static int _knifeCount;
        private protected static int _healCount;
        private static byte _inventorySize = 6;

        private static string[] _inventory = new string[_inventorySize];
        public static void FillInventory(int key, int knife, int heal)
        {
            for (int i = 0; i < _inventory.Length; i++)
            {
                if (key > 0 && key < maxValue)
                {
                    _keyCount = key;
                    key = 0;
                    _inventory[i] = KeySymbol;
                }
                else if (knife > 0 && knife < maxValue)
                {
                    _knifeCount = knife;
                    knife = 0;
                    _inventory[i] = KnifeSymbol;
                }
                else if (heal > 0 && heal < maxValue)
                {
                    _healCount = heal;
                    heal = 0;
                    _inventory[i] = HealSymbol;
                }
                else
                {
                    _inventory[i] = EmptyPlace;
                }
            }
        }
        public Inventory() : base()
        {
            FillInventory(0, 0, 0);
        }
        public static void ShowFullInventoryInfo()
        {
            for (int i = 0; i < _inventorySize; i++)
            {
                Console.WriteLine(_inventory[i] == KeySymbol ? $"{_inventory[i]} - {_keyCount}" : _inventory[i] == KnifeSymbol ? $"{_inventory[i]} - {_knifeCount}" : _inventory[i] == HealSymbol ? $"{_inventory[i]} - {_healCount}" : EmptyPlace);
            }
        }
        public static void ShowLineOfIcons()
        {
            for (int i = 0; i < _inventorySize; i++)
            {
                Console.Write($"{_inventory[i]} ");
            }
            Console.WriteLine();
        }
    }
}
