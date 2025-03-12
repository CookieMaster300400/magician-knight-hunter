namespace ConsoleApp1
{
    internal class Program
    {
        static void ShowScreenHints()
        {
            Console.WriteLine("Чтобы Зайти в инвентарь нажмите 1\nЧтобы зайти в сундук нажмите 2");
        }
        static void InvenroryOperacions()
        {
            while (true)
            {
                Inventory.ShowFullInventoryInfo();
                Console.WriteLine("Чтобы выйти из инвентаря нажмите 0");
                if (int.TryParse(Console.ReadLine(), out int enter) && enter == 0)
                {
                    break;
                }
            }
        }
        static void BoxOperations()
        {
            while (true)
            {
                DrawScreanForBoxOperations();
                string operation = Console.ReadLine();
                if (operation == "0")
                {
                    break;
                }
                else if (operation == "++")
                {
                    int[] boxKeysKnifesHeals = Box.Remove();
                    Inventory.FillInventory(boxKeysKnifesHeals[0], boxKeysKnifesHeals[1], boxKeysKnifesHeals[2]);
                }
            }
        }
        static void DrawScreanForBoxOperations()
        {
            Console.Clear();
            ShowScreenHints();
            Character.ShowPlayerCharacteristics();
            Console.WriteLine("Чтобы выйти из сундука нажмите 0\nЧтобы  предметы нажмите ++");
            Box.ShowBox();
            Inventory.ShowLineOfIcons();
        }
        static void TheGameIsOn()
        {
            while (true)
            {
                Console.Clear();
                ShowScreenHints();
                Character.ShowPlayerCharacteristics();
                if (int.TryParse(Console.ReadLine(), out int enter) && enter == 1)
                {
                    InvenroryOperacions();
                }
                else if (enter == 2)
                {
                    BoxOperations();
                }
            }
        }
        static void Main(string[] args)
        {
            Box.SetBoxSize();
            Character.ChooseCharacter();
            Character.SetPlayerCharacteristics();
            Character.SetName();
            Inventory inventory = new Inventory();
            Box box = new Box();
            TheGameIsOn();
        }
    }
}
