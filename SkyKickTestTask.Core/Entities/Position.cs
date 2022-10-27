using SkyKickTestTask.Common.Enums;
using SkyKickTestTask.Common.Interfaces.Entities;
using SkyKickTestTask.Common.Models;

namespace SkyKickTestTask.Core.Entities
{
    public class Position : IPosition
    {
        private const string MarsRoverFinalPosition = "{0} {1} {2}";
        public Coordinate Location { get; set; }
        public Direction  Direction { get; set; }

        public Position(int x, int y, Direction direction)
        {
            Location = new Coordinate(x, y);
            Direction = direction;
        }

        public string GetPosition()
        {
            return string.Format(MarsRoverFinalPosition, Location.X, Location.Y, Direction);
        }
    }
}
