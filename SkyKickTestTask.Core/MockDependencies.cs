using SkyKickTestTask.Common.Interfaces.Services.Console;
using SkyKickTestTask.Common.Interfaces.Services.Domain;
using SkyKickTestTask.Core.Services.Helpers;
using SkyKickTestTask.Core.Services.Presentation;
using SkyKickTestTask.Core.Services.Rover;

namespace SkyKickTestTask.Core
{
    public static class MockDependencies
    {
        #region ServicesWithoutExternalDeps
            public static IConsoleService ConsoleService { get; } = new ConsoleService();
            public static ICommandTypeService CommandTypeService { get; } = new CommandTypeService();
            public static IDirectionService DirectionService { get; } = new DirectionService();
        #endregion

        public static RoverEngineService RoverEngineService { get; } = new(DirectionService, ConsoleService);

        public static MarsRoverFactory MarsRoverFactory { get; } = new(RoverEngineService, ConsoleService);
    }
}
