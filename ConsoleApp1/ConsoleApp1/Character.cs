using System.Reflection.PortableExecutable;

namespace ConsoleApp1
{
    internal class Character
    {
        private static readonly List<int[]> characteristics = new()
            {
                new int[] { 3, 8, 10, 4, 10 },
                new int[] { 4, 6, 8, 10, 7 },
                new int[] {5, 10, 9, 2, 5 }
            };
        public enum Characters
        {
            Magician,
            Hunter,
            Knight
        }
        public static Characters characterType;
        public static void ChooseCharacter()
        {
            int numberOfElements = Enum.GetValues(typeof(Characters)).Length;
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int character) && character <= numberOfElements && character > 0)
                {
                    characterType = (Characters)character - 1;
                    break;
                }
            }
        }
        public string CharacterName { get; init; }
        public int HealthPoints { get; init; }
        public int Stability { get; init; }
        public int Power { get; init; }
        public int Agility { get; init; }
        public int Intelligence { get; init; }
        public Character(string characterName)
        {
            CharacterName = characterName;
            HealthPoints = characteristics[(int)characterType][0];
            Stability = characteristics[(int)characterType][1];
            Power = characteristics[(int)characterType][2];
            Agility = characteristics[(int)characterType][3];
            Intelligence = characteristics[(int)characterType][4];
        }
    }
}
