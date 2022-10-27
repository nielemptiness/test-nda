namespace SkyKickTestTask.Common.Interfaces.Entities
{
    public interface IRover
    {
        void OnMovementFinished();
        void PerformAction(ICommand command);
        string GetPosition();
    }
}
