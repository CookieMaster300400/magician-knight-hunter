namespace ConsoleApp1
{
    class Box
    {
        public int Keys { get; init; }
        public int FoldingKnife { get; init; }
        public int Heals { get; init; }
        public string[] box { get; init; }
        private int KeyCount { get; set; }
        private int HealCount { get; set; }
        private int KnifeCount { get; set; }
        public Box(int numberOfCells, string keySymbol, string knifeSymbol, string healSymbol, int keyCount = 0, int healCount = 0, int knifeCount = 0)
        {
            KeyCount = keyCount;
            KnifeCount = knifeCount;
            HealCount = healCount;
            box = new string[numberOfCells];
            for (int i = 0; i < numberOfCells; i++)
            {
                if (keyCount > 0)
                {
                    box[i] = keySymbol;
                    Keys = keyCount;
                    keyCount = 0;
                }
                else if (knifeCount > 0)
                {
                    box[i] = knifeSymbol;
                    FoldingKnife = knifeCount;
                    knifeCount = 0;
                }
                else if (healCount > 0)
                {
                    box[i] = healSymbol;
                    Heals = healCount;
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