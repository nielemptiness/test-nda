namespace SkyKickTestTask.Common.Interfaces.Services.Console
{
    public interface IConsoleService : ILoggerService, IUserInputService
    {
        void WriteLine(string output);
    }
}
