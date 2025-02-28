namespace ConsoleApp1
{
    abstract class Item
    {
        public static string keySymbol = "[1]";
        public static string knifeSymbol = "[>]";
        public static string healSymbol = "[$]";
        private const int MaxValue = 64;
        private static int _key;
        public static int KeyCount 
        {
            get => _key;
            protected set
            {
                if (value <= MaxValue)
                {
                    _key = value;
                }
            }
        }
        private static int _knife;
        public static int KnifeCount
        {
            get => _key;
            protected set
            {
                if (value <= MaxValue)
                {
                    _knife = value;
                }
            }
        }
        private static int _healCount;
        public static int HealCount
        {
            get => _key;
            protected set
            {
                if (value <= MaxValue)
                {
                    _healCount = value;
                }
            }
        }
        public Item(int key, int knife, int heal)
        {
            KeyCount = key;
            KnifeCount = knife;
            HealCount = heal;
        }
    }
}
