using SkyKickTestTask.Common.Enums;
using SkyKickTestTask.Common.Interfaces.Entities;
using SkyKickTestTask.Common.Interfaces.Services.Console;
using SkyKickTestTask.Common.Interfaces.Services.Domain;

namespace SkyKickTestTask.Core.Entities
{
    public class Command : ICommand
    {
        private const string CommandSkippedErrorMessage = "The command {0} is not valid. It was skipped";
        private readonly ICommandTypeService _commandTypeService;
        private readonly ILoggerService _loggerService;
        
        public List<CommandType> CommandTypes { get; }
        
        public Command(string input, ILoggerService loggerService, ICommandTypeService commandTypeService)
        {
            CommandTypes = new List<CommandType>();
            _loggerService = loggerService;
            _commandTypeService = commandTypeService;
            InputToCommand(input);
        }

        private void InputToCommand(string input)
        {
            foreach (var value in input)
            {
                if (TryGetCommand(value, out var command))
                {
                    CommandTypes.Add(command);
                }
            }
        }

        private bool TryGetCommand(char input, out CommandType result)
        {
            var exists = _commandTypeService.TryGetCommand(input, out CommandType command);

            if (!exists)
            {
                _loggerService.LogError(string.Format(CommandSkippedErrorMessage, input));
                result = CommandType.Undefined;
                return exists;
            }

            result = command;

            return exists;
        }
    }
}
