using SkyKickTestTask.Common.Enums;
using SkyKickTestTask.Common.Interfaces.Entities;

namespace SkyKickTestTask.Common.Interfaces.Services.Domain
{
    public interface IRoverFactory
    {
        IRover CreateRover(int x, int y, Direction direction);
    }
}
