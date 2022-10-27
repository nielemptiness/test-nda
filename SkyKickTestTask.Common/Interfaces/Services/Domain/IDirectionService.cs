using SkyKickTestTask.Common.Enums;

namespace SkyKickTestTask.Common.Interfaces.Services.Domain
{
    public interface IDirectionService
    {
        Direction AdjustDirection(Direction direction, int moveDirection);
    }
}
