using System;

namespace ConsoleApp1
{
    internal class Program
    {
        static void DrawCharacterInfo(Character player)
        {
            Console.Write($"\n\t{player.CharacterName}\n\n{CharacterBody.bodyCharacter[0]}\t\t\tHealthPoints: {player.HealthPoints}\n{CharacterBody.bodyCharacter[1]}\t\t\tStability: {player.Stability}\n{CharacterBody.bodyCharacter[2]}\t\t\tPower: {player.Power}\n\t\t\t\tAgility: {player.Agility}\n\t [+]\t\t\tIntelligence: {player.Intelligence}\n");
        }
        static void ShowScreenHints()
        {
            Console.Clear();
            Console.WriteLine("Чтобы зайти в интвентарь нажмите 1\nЧтобы посмотреть содержимое сундука нажмите 2");
        }
        static void Name(out string characterName)
        {
            Console.WriteLine("Имя должно быть не длиннее 14 символов и не короче 2\nКакое будет имя персонажа?");
            while (true)
            {
                characterName = Console.ReadLine();
                if (characterName.Length is > 1 and < 15)
                    return;
            }
        }
        static void InsideBox(string[] box, Inventory inventory)
        {
            Console.Write("\t");
            for (int i = 0; i < box.Length; i++)
            {
                int count = box.Length / 2;
                if (i == count)
                    Console.Write("\n\t");
                Console.Write(box[i]);
            }
            Console.Write("\n\n\t");
            for (int i = 0; i < inventory.InventoryContent.Length; i++)
                Console.Write(inventory.InventoryContent[i]);
        }
        public static void ShowInventory(Inventory inventory)
        {
            for (int i = 0; i < inventory.InventoryContent.Length; i++)
            {
                if (inventory.InventoryContent[i][1] != ' ')
                {
                    Console.Write(inventory.InventoryContent[i][1] == '1' ? $"\n\t{inventory.InventoryContent[i]} - Key: {Inventory.KeyCount}" : inventory.InventoryContent[i][1] == '>' ? $"\n\t{inventory.InventoryContent[i]} - FoldingKnife: {Inventory.KnifeCount}" : $"\n\t{inventory.InventoryContent[i]} - Heal: {Inventory.HealCount}");
                }
                else
                {
                    Console.Write($"\n\t{inventory.InventoryContent[i]}");
                }
            }
        }
        public static void BoxOperations(string[] box, Inventory inventory)
        {
            Console.WriteLine("Чтобы закрыть сундук нажмие 0\nЧтобы взять все предметы нажмите ++\nЧтобы выложить конкретные предметы нажмите --\nЧтобы взять конкретные предметы нажмите + и порядковый номер\nЧтобы выложить конкретные предметы нажмите и порядковый номер\nЧтобы взять единицу конкретного предмета нажмите * и порядковый номер\nЧтобы воложить единицу конкретного предмета нажмите / и порядковый номер");
            InsideBox(box, inventory);
            while (true)
            {
                string enter = Console.ReadLine();
                if ((enter == "0") || enter.Length == 2 && ((enter[0] == '/' || enter[0] == '*' || enter[0] == '-' || enter[0] == '+') && (int.TryParse(enter[1].ToString(), out int index) && index != 0) || enter == "++" || enter == "--"))
                {
                    if(enter == "0")
                    {
                        return;
                    }
                    else if (enter[0] == '+' || enter[0] == '*')
                    {
                        Inventory.Add(enter);
                    }
                }
            }
        }
        static void OpenInwentoryOrOpenBox(ref Box box, ref Inventory inventory, Character player)
        {
            while (true)
            {
                ShowScreenHints();
                DrawCharacterInfo(player);
                if (int.TryParse(Console.ReadLine(), out int num) && num == 1)
                {
                    Inventory.CloseInventory(inventory);
                }
                else if (num == 2)
                {
                    BoxOperations(box.box, inventory);
                }
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine($"\t   A *\t\t  0\t\t [=]\n\t  /MV|\t\t /O\\_\t\t/[]\\\n\t  /M\\|\t\t / \\ \t\t ||Т\n\t{Character.Characters.Magician}\t{Character.Characters.Hunter}\t\t{Character.Characters.Knight}\nВыберите персонажа написав его порядковый номер");
            Character.ChooseCharacter();
            string characterName;
            Name(out characterName);
            Character player = new Character(characterName);
            CharacterBody characterBody = new CharacterBody();
            Console.WriteLine("Выберите количество ячеек в сундуке. Минимум 6 максимум 20. Количество должно быть четным.");
            int numberOfCells = Box.BoxSize();
            Box box = new Box(numberOfCells, 2, 3, 1);
            Inventory inventory = new Inventory();
            OpenInwentoryOrOpenBox(ref box, ref inventory, player);
        }
    }
}
