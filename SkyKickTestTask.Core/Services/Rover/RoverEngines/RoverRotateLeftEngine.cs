using SkyKickTestTask.Common.Interfaces.Entities;
using SkyKickTestTask.Common.Interfaces.Services.Domain;

namespace SkyKickTestTask.Core.Services.Rover.RoverEngines
{
    public class RoverRotateLeftEngine : IRoverEngine
    {
        private const int MoveLeftDirection = -1;
        private readonly IDirectionService _directionService;

        public RoverRotateLeftEngine(IDirectionService service)
        {
            _directionService = service;
        }
        public void Move(IPosition position)
        {
            position.Direction = _directionService.AdjustDirection(position.Direction, MoveLeftDirection);
        }
    }
}
