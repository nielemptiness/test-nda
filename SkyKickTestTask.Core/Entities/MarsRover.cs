using SkyKickTestTask.Common.Interfaces.Entities;
using SkyKickTestTask.Common.Interfaces.Services.Console;
using SkyKickTestTask.Common.Interfaces.Services.Domain;

namespace SkyKickTestTask.Core.Entities
{
    public class MarsRover : IRover
    {
        private const string RouterStoppedMessage = "Rouver has stopped at {0}";
        private readonly IPosition _position;
        private readonly IRoverEngineService _roverEngine;
        private readonly ILoggerService _loggerService;

        public MarsRover(IPosition position, IRoverEngineService _engine, ILoggerService _logger)
        {
            _position = position;
            _roverEngine = _engine;
            _loggerService = _logger;
        }

        public void OnMovementFinished()
        { 
            var message = string.Format(RouterStoppedMessage, GetPosition());
           
           _loggerService.LogInfo(message);
        }

        public string GetPosition()
        {
            return _position.GetPosition(); 
        }

        public void PerformAction(ICommand command)
        {
            foreach (var commandType in command.CommandTypes)
            {
                _roverEngine.Move(commandType, _position);
            }

            OnMovementFinished();
        }
    }
}
