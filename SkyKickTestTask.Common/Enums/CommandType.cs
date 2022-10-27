using System.ComponentModel;

namespace SkyKickTestTask.Common.Enums
{
    public enum CommandType
    {
        Undefined = 0, 
        [Description("Spin 90 degrees left on spot")]
        L = 1,
        [Description("Spin 90 degrees right on spot")]
        R = 2,
        [Description("Move forward one grid point")]
        M = 3
    }
}
