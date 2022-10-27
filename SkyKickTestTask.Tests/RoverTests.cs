using SkyKickTestTask.Common.Enums;
using SkyKickTestTask.Common.Interfaces.Entities;
using SkyKickTestTask.Common.Interfaces.Services.Console;
using SkyKickTestTask.Common.Interfaces.Services.Domain;
using SkyKickTestTask.Core;
using SkyKickTestTask.Core.Entities;
using SkyKickTestTask.Core.Services.Rover;
using Xunit;

namespace SkyKickTestTask.Tests;

public class RoverTests
{
    private readonly IConsoleService _consoleService;
    private readonly ICommandTypeService _commandTypeService;
    private readonly IRoverEngineService _roverEngineService;

    public RoverTests()
    {
        // Can be easily substituted by mocks if needed
        _consoleService = MockDependencies.ConsoleService;
        _commandTypeService = MockDependencies.CommandTypeService;
        _roverEngineService = MockDependencies.RoverEngineService;
    }

    [Fact]
    public void WhenPosition_12N_Message_LMLMLMLMM_ResultShouldBe_13N()
    { 
        Plateau.GetInstance(_consoleService).SetUpperCoord(5, 5);
        var command = new Command("LMLMLMLMM", _consoleService, _commandTypeService);
        IRover rover = new MarsRoverFactory(_roverEngineService, _consoleService).CreateRover(1, 2, Direction.N);
        
        rover.PerformAction(command);
        var result = rover.GetPosition();
        var expectedResult = "1 3 N";
        Assert.True(expectedResult == result);
    }
    
    [Fact]
    public void WhenPosition_33E_Message_MMRMMRMRRM_ResultShouldBe_51E()
    {
        Plateau.GetInstance(_consoleService).SetUpperCoord(5, 5);
        var command = new Command("MMRMMRMRRM", _consoleService, _commandTypeService);
        IRover rover = new MarsRoverFactory(_roverEngineService, _consoleService).CreateRover(3, 3, Direction.E);
        
        rover.PerformAction(command);
        var result = rover.GetPosition();
        var expectedResult = "5 1 E";
        Assert.True(expectedResult == result);
    }
}
