using SkyKickTestTask.Common.Interfaces.Entities;
using SkyKickTestTask.Common.Interfaces.Services;
using SkyKickTestTask.Common.Interfaces.Services.Console;
using SkyKickTestTask.Common.Interfaces.Services.Domain;
using SkyKickTestTask.Core.Entities;

namespace SkyKickTestTask.Core.Services.Presentation
{
    public class PresentationService : IPresentationService
    {
        private readonly IConsoleService _consoleService;
        private readonly IRoverFactory _roverFactory;
        private readonly ICommandTypeService _commandTypeService;

        public PresentationService(IConsoleService console, IRoverFactory factory, ICommandTypeService commandTypeService)
        {
            _consoleService = console;
            _roverFactory = factory;
            _commandTypeService = commandTypeService;
        }
        
        public void ControlRovers()
        {
            BeforeExecution();

            var roversCount = ConfigureEnvironment();
            var counter = 0;
            while (counter < roversCount)
            {
                var rover = SetupRover();

                _consoleService.WriteLine("Enter move commands:");
                var commandInput = _consoleService.ReadString();
                var command = new Command(commandInput, _consoleService, _commandTypeService);
                
                rover.PerformAction(command);
                
                counter++;
            }
            
            _consoleService.WriteLine("Press any key to finish...");
            Console.ReadKey();
        }

        private int ConfigureEnvironment()
        {
            ConfigurePlateau();
            _consoleService.WriteLine("Please enter amount of rovers:");

            return _consoleService.ReadNumber();
        }

        private void ConfigurePlateau()
        {
            _consoleService.WriteLine("Enter plateau upper x:");
            var x = _consoleService.ReadNumber();
            
            _consoleService.WriteLine("Enter plateau upper y:");
            var y = _consoleService.ReadNumber();

            Plateau.GetInstance(MockDependencies.ConsoleService).SetUpperCoord(x, y);
        }

        private IRover SetupRover()
        {
            _consoleService.WriteLine("Enter rover starting x:");
            var x = _consoleService.ReadNumber();
            
            _consoleService.WriteLine("Enter rover starting y:");
            var y = _consoleService.ReadNumber();
            
            var direction = _consoleService.ReadDirection();

            return _roverFactory.CreateRover(x, y, direction);
        }

        private static void BeforeExecution()
        {
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
