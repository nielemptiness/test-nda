using SkyKickTestTask.Common.Models;

namespace SkyKickTestTask.Common.Interfaces.Entities
{
    public interface IPlateau
    {
        Coordinate LowerLeftPoint { get; }
        Coordinate UpperRightPoint { get; }
        void SetUpperCoord(int upperX, int upperY);
    }
}
