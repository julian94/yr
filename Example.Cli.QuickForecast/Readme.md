# QuickForecast

This is a very simple example client that will check the forecast for whichever location is provided.

## Example Output
```shell
QuickForecast 60.39323 5.3245
The Weather for the next hour will be lightrain
4,9°C  3,7m/s Southeast
with 0,00-0,80mm of precipitation
```

## Publishing
To publish this program run either/both of these commands:
```shell
dotnet publish .\Example.Cli.QuickForecast\ --runtime win-x64   -p:PublishSingleFile=true
dotnet publish .\Example.Cli.QuickForecast\ --runtime linux-x64 -p:PublishSingleFile=true
```
