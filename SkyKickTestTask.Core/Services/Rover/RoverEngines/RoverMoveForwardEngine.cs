using SkyKickTestTask.Common.Enums;
using SkyKickTestTask.Common.Interfaces.Entities;
using SkyKickTestTask.Common.Interfaces.Services.Console;
using SkyKickTestTask.Common.Interfaces.Services.Domain;
using SkyKickTestTask.Core.Entities;

namespace SkyKickTestTask.Core.Services.Rover.RoverEngines
{
    public class RoverMoveForwardEngine : IRoverEngine
    {
        private const string RouterCannotGoFurtherError = "Router is at position {0}. Can't move anymore";
        private readonly IPlateau _plateau;
        private readonly ILoggerService _loggerService;

        public RoverMoveForwardEngine(ILoggerService loggerService)
        {
            _loggerService = loggerService;
            _plateau = Plateau.GetInstance(_loggerService);
        }

        public void Move(IPosition position)
        {
            switch (position.Direction)
            {
                case Direction.N:
                    if (position.Location.Y == _plateau.UpperRightPoint.Y)
                    {
                        CantMoveAnymore(position);
                        break;
                    }
                    position.Location.Y += 1;
                    break;
                case Direction.S:
                    if (position.Location.Y == _plateau.LowerLeftPoint.Y) 
                    {
                        CantMoveAnymore(position);
                        break;
                    }
                    position.Location.Y -= 1;
                    break;
                case Direction.E:
                    if (position.Location.X == _plateau.UpperRightPoint.X)
                    {
                        CantMoveAnymore(position);
                        break;
                    }
                    position.Location.X += 1;
                    break;
                case Direction.W:
                    if (position.Location.X == _plateau.LowerLeftPoint.X) 
                    {
                        CantMoveAnymore(position);
                        break;
                    }
                    position.Location.X -= 1;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(position.Direction), "No such direction!");
            }
        }

        private void CantMoveAnymore(IPosition position)
        {
            var message = string.Format(RouterCannotGoFurtherError, position.GetPosition());
            _loggerService.LogError(message);
        }
    }
}
