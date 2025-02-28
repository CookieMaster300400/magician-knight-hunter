namespace ConsoleApp1
{
    class Box : Item
    {
        public static int BoxSize()
        {
            const int MinBoxSize = 6;
            const int MaxBoxSize = 20;
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int numberOfCells) && numberOfCells >= MinBoxSize && numberOfCells <= MaxBoxSize && numberOfCells % 2 == 0)
                    return numberOfCells;
            }
        }
        public string[] box { get; init; }
        public Box(int numberOfCells, int keyCount = 0, int healCount = 0, int knifeCount = 0) : base(keyCount, knifeCount, healCount)
        {
            box = new string[numberOfCells];
            for (int i = 0; i < numberOfCells; i++)
            {
                if (keyCount > 0)
                {
                    box[i] = keySymbol;
                    KeyCount = keyCount;
                    keyCount = 0;
                }
                else if (knifeCount > 0)
                {
                    box[i] = knifeSymbol;
                    KnifeCount = knifeCount;
                    knifeCount = 0;
                }
                else if (healCount > 0)
                {
                    box[i] = healSymbol;
                    HealCount = healCount;
                    healCount = 0;
                }
                else
                {
                    box[i] = "[ ]";
                }
            }
        }
    }
}