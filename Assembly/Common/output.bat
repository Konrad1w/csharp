@echo off

set "fabrykaPath=%~dp0Fabryka\bin\Debug\net7.0\Fabryka.exe"

set "beerProcessorPath=%~dp0\BeerProcessor\bin\Debug\net7.0\BeerProcessor.dll"

set "sandwichProcessorPath=%~dp0\SandwichProcessor\bin\Debug\net7.0\SandwichProcessor.dll"

"%fabrykaPath%" "%beerProcessorPath%;Piwo dla Franka" "%sandwichProcessorPath%;Kanapka dla Franka" "%sandwichProcessorPath%;Kanapka Janiny"

pause
