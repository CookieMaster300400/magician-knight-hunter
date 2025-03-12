namespace ConsoleApp1
{
    class Box : Item
    {
        public static string[] box { get; private set; }
        public static void SetBoxSize()
        {
            const byte MinBoxSize = 6;
            const byte MaxBoxSize = 20;
            while(true)
            {
                Console.WriteLine($"Сколько ячеек будет в сундуке?\nНе короче {MinBoxSize}\nНе длиннее {MaxBoxSize}\nКоличество должно быть четным");
                if(int.TryParse(Console.ReadLine(), out int cells) && cells >= MinBoxSize && cells <= MaxBoxSize && cells % 2 == 0)
                {
                    box = new string[cells];
                    break;
                }
                Console.Clear();
            }
        }
        private protected static int _keyCount;
        private protected static int _knifeCount;
        private protected static int _healCount;
        public static void FillTheBox(int key, int knife, int heal)
        {
            for (int i = 0; i < box.Length; i++)
            {
                if (key > 0 && key < maxValue)
                {
                    _keyCount = key;
                    key = 0;
                    box[i] = KeySymbol;
                }
                else if (knife > 0 && knife < maxValue)
                {
                    _knifeCount = knife;
                    knife = 0;
                    box[i] = KnifeSymbol;
                }
                else if (heal > 0 && heal < maxValue)
                {
                    _healCount = heal;
                    heal = 0;
                    box[i] = HealSymbol;
                }
                else
                {
                    box[i] = EmptyPlace;
                }
            }
        }
        public Box() : base()
        {
            FillTheBox(3, 1, 2);
        }
        public static void ShowBox()
        {
            byte j = 0;
            Console.Write("\t");
            for (int i = 0; i < box.Length; i++)
            {
                Console.Write(box[i]);
                ++j;
                if (j == box.Length / 2)
                {
                    Console.Write("\n\t");
                    j = 0;
                }
            }
        }
        public static int[] Remove()
        {
            int[] keysKnifesHeals = { _keyCount, _knifeCount, _healCount };
            _keyCount = 0;
            _knifeCount = 0;
            _healCount = 0;
            FillTheBox(0, 0, 0);
            return keysKnifesHeals;
        }
    }
}
