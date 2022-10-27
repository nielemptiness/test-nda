using SkyKickTestTask.Common.Enums;

namespace SkyKickTestTask.Common.Interfaces.Services.Domain
{
    public interface ICommandTypeService
    {
        bool TryGetCommand(char input, out CommandType commandType);
    }
}
