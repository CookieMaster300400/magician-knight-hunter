using System.Reflection.PortableExecutable;

namespace ConsoleApp1
{
    internal class Character
    {
        public string CharacterName { get; set; }
        public ConsoleApp1.Program.Characters CharacterClass { get; set; }
        public int HealthPoints { get; set; }
        public int Stability { get; }
        public int Power { get; }
        public int Agility { get; }
        public int Intelligence { get; }
        public string Head { get; set; }
        public string Body { get; set; }
        public string Legs { get; set; }
        public Character(string characterName, ConsoleApp1.Program.Characters character, List<object[]> characteristics)
        {
            CharacterName = characterName;
            CharacterClass = character;
            Head = (string)characteristics[(int)CharacterClass][0];
            Body = (string)characteristics[(int)CharacterClass][1];
            Legs = (string)characteristics[(int)CharacterClass][2];
            HealthPoints = (int)characteristics[(int)CharacterClass][3];
            Stability = (int)characteristics[(int)CharacterClass][4];
            Power = (int)characteristics[(int)CharacterClass][5];
            Agility = (int)characteristics[(int)CharacterClass][6];
            Intelligence = (int)characteristics[(int)CharacterClass][7];
        }
    }
}
