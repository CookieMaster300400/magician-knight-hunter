namespace ConsoleApp1
{
    class Character
    {
        public enum Characters
        {
            Magician,
            Knight,
            Hunter
        }
        private static Characters _characterType;
        private static byte _power;
        private static byte _agility;
        private static byte _intelligence;
        private static byte _healthPoints;
        private static byte _stability;
        private static string _name;
        private static void ShowCharacters()
        {
            for(int i = 0; i < Enum.GetValues(typeof(Characters)).Length; i++)
            {
                Console.Write($"      {(Characters)i}    ");
            }
        }
        public static void ChooseCharacter()
        {
            while (true)
            {
                Console.Clear();
                ShowCharacters();
                Console.WriteLine("\nЧтобы выбрать персонажа нужно написать его порядковый номер");
                if (int.TryParse(Console.ReadLine(), out int index) && index - 1 >= 0 && index - 1 < Enum.GetValues(typeof(Characters)).Length)
                {
                    _characterType = (Characters)index - 1;
                    break;
                }
            }
        }
        public static void SetPlayerCharacteristics()
        {
            if (_characterType == Characters.Magician)
            {
                _agility = 4;
                _healthPoints = 3;
                _stability = 8;
                _power = 10;
                _intelligence = 10;
            }
            else if (_characterType == Characters.Knight)
            {
                _agility = 2;
                _healthPoints = 5;
                _stability = 10;
                _power = 9;
                _intelligence = 5;
            }
            else
            {
                _agility = 10;
                _healthPoints = 4;
                _stability = 6;
                _power = 8;
                _intelligence = 7;
            }
        }
        public static void SetName()
        {
            const byte MinNameLength = 2;
            const byte MaxNameLength = 10;
            while(true)
            {
                Console.Clear();
                Console.WriteLine($"   Имя должно быть не короче {MinNameLength} символов и не длиннее {MaxNameLength}\n   Какое будет имя у персонажа?");
                string name = Console.ReadLine();
                if(name.Length >= MinNameLength && name.Length <= MaxNameLength)
                {
                    _name = name;
                    break;
                }
            }
        }
        public static void ShowPlayerCharacteristics()
        {
            Console.WriteLine($"\n   {_characterType}: {_name}\n");
            Console.WriteLine($"   Ловкость: {_agility}\n   Здоровье: {_healthPoints}\n   Устойчивость: {_stability}\n   Сила: {_power}\n   Интеллект: {_intelligence}");
        }
    }
}
