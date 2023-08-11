

namespace FileCabinetAppOOP.All_UI
{
    public class ConsoleUI : IUserInterface
    {
        public void Display(string message)
        {
            Console.WriteLine(message);
        }

        public string? GetUserInput()
        {
            return Console.ReadLine();
        }
    }

}
