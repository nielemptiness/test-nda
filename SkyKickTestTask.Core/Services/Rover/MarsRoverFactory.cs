using SkyKickTestTask.Common.Enums;
using SkyKickTestTask.Common.Interfaces.Entities;
using SkyKickTestTask.Common.Interfaces.Services.Console;
using SkyKickTestTask.Common.Interfaces.Services.Domain;
using SkyKickTestTask.Core.Entities;

namespace SkyKickTestTask.Core.Services.Rover
{
    public sealed class MarsRoverFactory : IRoverFactory
    {
        private readonly IRoverEngineService _roverEngineService;
        private readonly ILoggerService _loggerService;

        public MarsRoverFactory(IRoverEngineService roverEngineService, ILoggerService loggerService)
        {
            _roverEngineService = roverEngineService;
            _loggerService = loggerService;
        }
        public IRover CreateRover(int x, int y, Direction direction)
        {
            var position = new Position(x, y, direction);

            return new MarsRover(position, _roverEngineService, _loggerService);
        }
    }
}
