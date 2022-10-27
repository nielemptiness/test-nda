using SkyKickTestTask.Common.Enums;
using SkyKickTestTask.Common.Interfaces.Services.Domain;

namespace SkyKickTestTask.Core.Services.Helpers
{
    public class CommandTypeService : ICommandTypeService
    {
        private readonly Dictionary<char, CommandType> _commandTypesMap;

        public CommandTypeService()
        {
            _commandTypesMap = new Dictionary<char, CommandType>
            {
                { 'L', CommandType.L },
                { 'R', CommandType.R },
                { 'M', CommandType.M }
            };
        }

        public bool TryGetCommand(char input, out CommandType commandType)
        {
            if (!_commandTypesMap.TryGetValue(input, out commandType))
            {
                commandType = CommandType.Undefined;
                return false;
            }

            return true;
        }
    }
}
