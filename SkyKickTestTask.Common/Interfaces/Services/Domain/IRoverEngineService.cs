using SkyKickTestTask.Common.Enums;
using SkyKickTestTask.Common.Interfaces.Entities;

namespace SkyKickTestTask.Common.Interfaces.Services.Domain
{
    public interface IRoverEngineService
    {
        void Move(CommandType command, IPosition position);
    }
}
