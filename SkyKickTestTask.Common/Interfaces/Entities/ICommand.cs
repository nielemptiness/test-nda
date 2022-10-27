using SkyKickTestTask.Common.Enums;

namespace SkyKickTestTask.Common.Interfaces.Entities
{
    public interface ICommand
    {
        List<CommandType> CommandTypes { get; }
    }
}
