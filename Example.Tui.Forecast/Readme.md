# Forecast

This is a very simple example client that will check the forecast for whichever location is provided.

## Example Output
```shell
QuickForecast 60.39323 5.3245
```

## Publishing
To publish this program run either/both of these commands:
```shell
dotnet publish .\Example.Tui.Forecast\ --runtime win-x64   -p:PublishSingleFile=true
dotnet publish .\Example.Tui.Forecast\ --runtime linux-x64 -p:PublishSingleFile=true
```
