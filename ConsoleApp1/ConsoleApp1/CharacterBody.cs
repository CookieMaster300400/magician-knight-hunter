namespace ConsoleApp1
{
    class CharacterBody
    {
        public static readonly List<string[]> body = new()
        {
            new string[] { "\t   A *", "\t  /MV|", "\t  /M\\|" },
            new string[] { "\t 0", "\t/O\\_", "\t/ \\" },
            new string[] { "\t (=)", "\t/[]\\", "\t ||Т" }
        };
        public static string[] bodyCharacter;

        public CharacterBody()
        {
            bodyCharacter = new string[body[(int)Character.characterType].Length];
            for(int i = 0; i < body[(int)Character.characterType].Length; i++)
            {
                bodyCharacter[i] = body[(int)Character.characterType][i];
            }
        }
    }
}
