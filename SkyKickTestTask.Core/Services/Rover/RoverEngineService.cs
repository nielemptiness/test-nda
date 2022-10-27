using SkyKickTestTask.Common.Enums;
using SkyKickTestTask.Common.Interfaces.Entities;
using SkyKickTestTask.Common.Interfaces.Services.Console;
using SkyKickTestTask.Common.Interfaces.Services.Domain;
using SkyKickTestTask.Core.Services.Rover.RoverEngines;

namespace SkyKickTestTask.Core.Services.Rover
{
    public class RoverEngineService : IRoverEngineService
    {
        private readonly Dictionary<CommandType, IRoverEngine> _roverStrategy;

        public RoverEngineService(IDirectionService service, ILoggerService loggerService)
        {
            _roverStrategy = new Dictionary<CommandType, IRoverEngine>()
            {
                { CommandType.L, new RoverRotateLeftEngine(service) }, 
                { CommandType.R, new RoverRotateRightEngine(service) },
                { CommandType.M, new RoverMoveForwardEngine(loggerService) }
            };
        }
        public void Move(CommandType command, IPosition position)
        {
            if (command == CommandType.Undefined)
                throw new ArgumentOutOfRangeException(nameof(command));

            _roverStrategy[command].Move(position);
        }
    }
}
