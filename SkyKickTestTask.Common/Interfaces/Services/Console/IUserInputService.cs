using SkyKickTestTask.Common.Enums;

namespace SkyKickTestTask.Common.Interfaces.Services.Console
{
    public interface IUserInputService
    {
        int ReadNumber();
        string ReadString();
        Direction ReadDirection();
    }
}
