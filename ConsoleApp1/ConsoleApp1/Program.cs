using System;

namespace ConsoleApp1
{
    internal class Program
    {
        public enum Characters
        {
            Magician,
            Hunter,
            Knight
        }
        static Characters ChooseCharacter()
        {
            int numberOfElements = Enum.GetValues(typeof(Characters)).Length;
            Console.WriteLine("\t   A *\t\t  0\t\t [=]\n\t  /MV|\t\t /O\\_\t\t/[]\\\n\t  /M\\|\t\t / \\ \t\t ||Т\n\tMagician\tHunter\t\tKnight\nВыберите персонажа написав его порядковый номер");
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int character) && character <= numberOfElements && character > 0)
                {
                    return (Characters)character - 1;
                }
            }
        }
        static void ShowCharacterAndInformation(Character player)
        {
            Console.Clear();
            Console.Write($"Чтобы зайти в интвентарь нажмите 1\nЧтобы посмотреть содержимое сундука нажмите 2\n\n\t{player.CharacterName}\n\n{player.Head}\t\t\tHealthPoints: {player.HealthPoints}\n{player.Body}\t\t\tStability: {player.Stability}\n{player.Legs}\t\t\tPower: {player.Power}\n\t\t\t\tAgility: {player.Agility}\n\t [+]\t\t\tIntelligence: {player.Intelligence}\n");
        }
        static int BoxSize()
        {
            const int MinBoxSize = 6;
            const int MaxBoxSize = 20;
            Console.WriteLine("Выберите количество ячеек в сундуке. Минимум 6 максимум 20. Количество должно быть четным.");
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int numberOfCells) && numberOfCells >= MinBoxSize && numberOfCells <= MaxBoxSize && numberOfCells % 2 == 0)
                    return numberOfCells;
            }
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
            for (int i = 0; i < box.Length; i++)
            {
                int count = box.Length / 2;
                if (i == count)
                    Console.Write("\n\t");
                Console.Write(box[i]);
            }
            Console.Write("\n\n\t");
            for (int i = 0; i < inventory.inventory.Length; i++)
                Console.Write(inventory.inventory[i]);
        }
        static void ShowInventory(Inventory inventory)
        {
            for (int i = 0; i < inventory.inventory.Length; i++)
            {
                if (inventory.inventory[i][1] != ' ')
                {
                    Console.Write(inventory.inventory[i][1] == '1' ? $"\n\t{inventory.inventory[i]} - Key: {inventory.Keys}" : inventory.inventory[i][1] == '>' ? $"\n\t{inventory.inventory[i]} - FoldingKnife: {inventory.FoldingKnife}" : $"\n\t{inventory.inventory[i]} - Heal: {inventory.Heal}");
                }
                else
                {
                    Console.Write($"\n\t{inventory.inventory[i]}");
                }
            }
        }
        static void InventoryOperations(Inventory inventory, Character player)
        {
            Console.WriteLine("Чтобы закрыть инвентарь нажмите 0");
            ShowInventory(inventory);
            while (true)
            {
                if (char.TryParse(Console.ReadLine(), out char exitOrGet) && exitOrGet == '0')
                {
                    break;
                }
            }
        }
        static void BoxAndInventoryOperations(ref Box box, ref Inventory inventory, int numberOfCells, Character player, string KeySymbol, string KnifeSymbol, string HealSymbol)
        {
            while (true)
            {
                ShowCharacterAndInformation(player);
                Console.Write("Чтобы закрыть сундук нажмите 0\nЧтобы взять все предметы нажмите ++\nЧтобы выложить все предметы нажмите --\nЧтобы взять конкретные предметы нажмите + и порядковый номер\nЧтобы выложить конкретные предметы нажмите - и порядковый номер\nЧтобы взять единицу конкретного предмета нажмите * и порядковый номер\nЧтобы выложить единицу конкретного предмета нажмите / и порядковый номер\n\n\t");
                InsideBox(box.box, inventory);
                Console.Write("\n\n\t");
                string enter = Console.ReadLine();
                int index = 0;
                if ((enter.Length == 1 && enter[0] == '0') || enter.Length == 2 && ((enter[0] == '+' || enter[0] == '-' || enter[0] == '*' || enter[0] == '-') && ((int.TryParse(enter[1].ToString(), out index) || (enter[1] == '+' || enter[1] == '-')))))
                {
                    if (enter[0] == '0')
                    {
                        break;
                    }
                    else if (enter[1] == '-' && (inventory.inventory.Contains("[$]") || inventory.inventory.Contains("[>]") || inventory.inventory.Contains("[1]")))
                    {
                        box = new Box(numberOfCells, KeySymbol, KnifeSymbol, HealSymbol, inventory.Keys + box.Keys, inventory.Heal + box.Heals, inventory.FoldingKnife + box.FoldingKnife);
                        inventory = new Inventory(KeySymbol, KnifeSymbol, HealSymbol);
                    }
                    else if (enter[1] == '+' && (box.box.Contains("[$]") || box.box.Contains("[>]") || box.box.Contains("[1]")))
                    {
                        inventory = new Inventory(KeySymbol, KnifeSymbol, HealSymbol, box.Keys + inventory.Keys, box.FoldingKnife + inventory.FoldingKnife, box.Heals + inventory.Heal);
                        box = new Box(numberOfCells, KeySymbol, KnifeSymbol, HealSymbol);
                    }
                    else if (enter[0] == '+' && index != 0 && box.box[index - 1] != "[ ]")
                    {
                        if (box.box[index - 1] == KeySymbol)
                        {
                            inventory = new Inventory(KeySymbol, KnifeSymbol, HealSymbol, box.Keys + inventory.Keys, inventory.FoldingKnife, inventory.Heal);
                            box = new Box(numberOfCells, KeySymbol, KnifeSymbol, HealSymbol, 0, box.Heals, box.FoldingKnife);
                        }
                        else if (box.box[index - 1] == KnifeSymbol)
                        {
                            inventory = new Inventory(KeySymbol, KnifeSymbol, HealSymbol, inventory.Keys, inventory.FoldingKnife + box.FoldingKnife, inventory.Heal);
                            box = new Box(numberOfCells, KeySymbol, KnifeSymbol, HealSymbol, box.Keys, box.Heals, 0);
                        }
                        else if (box.box[index - 1] == HealSymbol)
                        {
                            inventory = new Inventory(KeySymbol, KnifeSymbol, HealSymbol, inventory.Keys, inventory.FoldingKnife, inventory.Heal + box.Heals);
                            box = new Box(numberOfCells, KeySymbol, KnifeSymbol, HealSymbol, box.Keys, 0, box.FoldingKnife);
                        }
                    }
                    else if (enter[0] == '-' && index != 0 && inventory.inventory[index - 1] != "[ ]")
                    {
                        if (inventory.inventory[index - 1] == KeySymbol)
                        {
                            box = new Box(numberOfCells, KeySymbol, KnifeSymbol, HealSymbol, box.Keys + inventory.Keys, box.Heals, box.FoldingKnife);
                            inventory = new Inventory(KeySymbol, KnifeSymbol, HealSymbol, 0, inventory.FoldingKnife, inventory.Heal);
                        }
                        else if (inventory.inventory[index - 1] == KnifeSymbol)
                        {
                            box = new Box(numberOfCells, KeySymbol, KnifeSymbol, HealSymbol, box.Keys, box.Heals, box.FoldingKnife + inventory.FoldingKnife);
                            inventory = new Inventory(KeySymbol, KnifeSymbol, HealSymbol, inventory.Keys, 0, inventory.Heal);
                        }
                        else if (inventory.inventory[index - 1] == HealSymbol)
                        {
                            box = new Box(numberOfCells, KeySymbol, KnifeSymbol, HealSymbol, box.Keys, box.Heals + inventory.Heal, box.FoldingKnife);
                            inventory = new Inventory(KeySymbol, KnifeSymbol, HealSymbol, inventory.Keys, inventory.FoldingKnife, 0);
                        }
                    }
                    else if (enter[0] == '*' && index != 0 && box.box[index - 1] != "[ ]")
                    {
                        if (box.box[index - 1] == KeySymbol)
                        {
                            inventory = new Inventory(KeySymbol, KnifeSymbol, HealSymbol, 1 + inventory.Keys, inventory.FoldingKnife, inventory.Heal);
                            box = new Box(numberOfCells, KeySymbol, KnifeSymbol, HealSymbol, box.Keys - 1, box.Heals, box.FoldingKnife);
                        }
                        else if (box.box[index - 1] == KnifeSymbol)
                        {
                            inventory = new Inventory(KeySymbol, KnifeSymbol, HealSymbol, inventory.Keys, inventory.FoldingKnife + 1, inventory.Heal);
                            box = new Box(numberOfCells, KeySymbol, KnifeSymbol, HealSymbol, box.Keys, box.Heals, box.FoldingKnife - 1);
                        }
                        else if (box.box[index - 1] == HealSymbol)
                        {
                            inventory = new Inventory(KeySymbol, KnifeSymbol, HealSymbol, inventory.Keys, inventory.FoldingKnife, inventory.Heal + 1);
                            box = new Box(numberOfCells, KeySymbol, KnifeSymbol, HealSymbol, box.Keys, box.Heals - 1, box.FoldingKnife);
                        }
                    }
                    else if (enter[0] == '/' && index != 0 && inventory.inventory[index - 1] != "[ ]")
                    {
                        if (inventory.inventory[index - 1] == KeySymbol)
                        {
                            box = new Box(numberOfCells, KeySymbol, KnifeSymbol, HealSymbol, box.Keys + 1, box.Heals, box.FoldingKnife);
                            inventory = new Inventory(KeySymbol, KnifeSymbol, HealSymbol, inventory.Keys - 1, inventory.FoldingKnife, inventory.Heal);
                        }
                        else if (inventory.inventory[index - 1] == KnifeSymbol)
                        {
                            box = new Box(numberOfCells, KeySymbol, KnifeSymbol, HealSymbol, box.Keys, box.Heals, box.FoldingKnife + 1);
                            inventory = new Inventory(KeySymbol, KnifeSymbol, HealSymbol, inventory.Keys, inventory.FoldingKnife - 1, inventory.Heal);
                        }
                        else if (inventory.inventory[index - 1] == HealSymbol)
                        {
                            box = new Box(numberOfCells, KeySymbol, KnifeSymbol, HealSymbol, box.Keys, box.Heals + 1, box.FoldingKnife);
                            inventory = new Inventory(KeySymbol, KnifeSymbol, HealSymbol, inventory.Keys, inventory.FoldingKnife, inventory.Heal - 1);
                        }
                    }
                }
            }
        }
        static void OpenInwentoryOrOpenBox(ref Box box, ref Inventory inventory, Character player, int numberOfCells, string KeySymbol, string KnifeSymbol, string HealSymbol)
        {
            while (true)
            {
                ShowCharacterAndInformation(player);
                if (int.TryParse(Console.ReadLine(), out int num) && num == 1)
                {
                    InventoryOperations(inventory, player);
                }
                else if (num == 2)
                {
                    BoxAndInventoryOperations(ref box, ref inventory, numberOfCells, player, KeySymbol, KnifeSymbol, HealSymbol);
                }
            }
        }
        static void Main(string[] args)
        {
            const string KeySymbol = "[1]";
            const string KnifeSymbol = "[>]";
            const string HealSymbol = "[$]";
            List<object[]> characteristics = new()
            {
                new object[] { "\t   A *", "\t  /MV|", "\t  /M\\|", 3, 8, 10, 4, 10 },
                new object[] { "\t 0", "\t/O\\_", "\t/ \\", 4, 6, 8, 10, 7 },
                new object[] { "\t (=)", "\t/[]\\", "\t ||Т", 5, 10, 9, 2, 5 }
            };
            string characterName;
            Characters character = ChooseCharacter();
            Name(out characterName);
            int numberOfCells = BoxSize();
            Box box = new Box(numberOfCells, KeySymbol, KnifeSymbol, HealSymbol, 2, 3, 1);
            Character player = new Character(characterName, character, characteristics);
            Inventory inventory = new Inventory(KeySymbol, KnifeSymbol, HealSymbol);
            OpenInwentoryOrOpenBox(ref box, ref inventory, player, numberOfCells, KeySymbol, KnifeSymbol, HealSymbol);
        }
    }
}
