namespace SkyKickTestTask.Common.Interfaces.Services.Console
{
    public interface ILoggerService
    {
        void LogError(string message);
        void LogInfo(string message);
    }
}
