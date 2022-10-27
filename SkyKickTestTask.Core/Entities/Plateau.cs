using SkyKickTestTask.Common.Interfaces.Entities;
using SkyKickTestTask.Common.Interfaces.Services.Console;
using SkyKickTestTask.Common.Models;

namespace SkyKickTestTask.Core.Entities
{
    public class Plateau : IPlateau
    {
        private static IPlateau? _plateau;
        private static readonly object _lock = new ();
        private readonly ILoggerService _loggerService;
        public Coordinate LowerLeftPoint { get; }

        private Coordinate _upperRightPoint;
        public Coordinate UpperRightPoint
        {
            get
            {
                if (_upperRightPoint == null)
                {
                    _loggerService.LogError("Plateu upper coordinates are not set!");
                    throw new InvalidOperationException("You should set plateu coordinates first!");
                }

                return _upperRightPoint;
            }
            private set
            {
                _upperRightPoint = value;
            }
        }

        private Plateau(ILoggerService loggerService)
        {
            LowerLeftPoint = new Coordinate(0, 0);
            _loggerService = loggerService;
        }

        public void SetUpperCoord(int upperX, int upperY)
        {
            UpperRightPoint = new Coordinate(upperX, upperY);
        }

        public static IPlateau GetInstance(ILoggerService loggerService)
        {
            if (_plateau == null)
            {
                lock (_lock)
                {
                    if (_plateau == null)
                    {
                        _plateau = new Plateau(loggerService);
                    }
                }
            }

            return _plateau;
        }
    }
}
