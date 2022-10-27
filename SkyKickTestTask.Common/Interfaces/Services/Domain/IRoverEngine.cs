using SkyKickTestTask.Common.Interfaces.Entities;

namespace SkyKickTestTask.Common.Interfaces.Services.Domain
{
    public interface IRoverEngine
    {
        void Move(IPosition position);
    }
}
