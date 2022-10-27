// See https://aka.ms/new-console-template for more information

using SkyKickTestTask.Common.Interfaces.Services;
using SkyKickTestTask.Core;
using SkyKickTestTask.Core.Services.Presentation;

IPresentationService presentationService = new PresentationService(MockDependencies.ConsoleService,
    MockDependencies.MarsRoverFactory, MockDependencies.CommandTypeService);

presentationService.ControlRovers();
