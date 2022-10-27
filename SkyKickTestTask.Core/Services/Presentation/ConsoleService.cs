using SkyKickTestTask.Common.Enums;
using SkyKickTestTask.Common.Interfaces.Services.Console;

namespace SkyKickTestTask.Core.Services.Presentation
{
    public class ConsoleService : IConsoleService
    {
        public void LogError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
        }
        
        public void LogInfo(string message)
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
        }
        
        public int ReadNumber()
        {
            try
            {
                var res = int.Parse(Console.ReadLine());
                return res;
            }
            catch (Exception e)
            {
                LogError(e.Message);
                throw new ArgumentException("Can't parse coordinate value!");
            }
        }

        public string ReadString()
        {
            return Console.ReadLine();
        }

        public Direction ReadDirection()
        {
            Console.WriteLine("Enter rover Direction char (N, E, S, W):");
            try
            {
                var direction = Enum.Parse<Direction>(Console.ReadLine());
                return direction;
            }
            catch (Exception e)
            {
                LogError(e.Message);
                throw new ArgumentException("Can't read Direction!");
            }
        }

        public void WriteLine(string output)
        {
            Console.WriteLine(output);
        }
    }
}
