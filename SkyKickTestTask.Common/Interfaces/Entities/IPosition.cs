using SkyKickTestTask.Common.Enums;
using SkyKickTestTask.Common.Models;

namespace SkyKickTestTask.Common.Interfaces.Entities
{
    public interface IPosition
    {
        Coordinate Location { get; set; }
        Direction  Direction { get; set; }
        string GetPosition();
    }
}
