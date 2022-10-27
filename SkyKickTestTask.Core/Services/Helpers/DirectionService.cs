using SkyKickTestTask.Common.Enums;
using SkyKickTestTask.Common.Interfaces.Services.Domain;

namespace SkyKickTestTask.Core.Services.Helpers
{
    public class DirectionService : IDirectionService
    {
        private readonly List<Direction> _directions;

        public DirectionService()
        {
            _directions = Enum.GetValues<Direction>().ToList();
        }
        public Direction AdjustDirection(Direction direction, int moveDirection)
        {
            var dir = _directions.FindIndex(d => d == direction) + moveDirection;

            if (dir < 0)
            {
                dir = _directions.Count - 1;
            }
            else if (dir >= _directions.Count)
            {
                dir = 0;
            }

            return _directions[dir];
        }
    }
}

