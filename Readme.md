# Yr

> [Yr](https://www.yr.no) is the joint online weather service from the Norwegian Meteorological Institute (met.no) and the Norwegian Broadcasting Corporation (NRK).  
This is an **UNOFFICIAL** api for using it.  

[Recommended: For more details on the YR api, read their documentation.](https://developer.yr.no/)

## Requirements
1. Dotnet 9 or better.
2. Reading and understanding the [YR Terms of Service.](https://developer.yr.no/doc/TermsOfService/)  
  Most important rules:  
   1. You must identify yourself  
   2. You must not cause unnecessary traffic  
   3. You must not overload our servers  

## Structure
* `Yr.Model`: Model for parsing data from the yr api using `System.Text.Json`.
* `Yr.Client`: Http client for data from the yr api using `Flurl.Http`.
* `Example.Cli.QuickForecast`: Very simple command line program.

## Nuget package
I might make one at some point, but I would want to have more coverage of the api first.

## Contributing
Sure go ahead and make issues and pull requests, I'll try to be prompt with addressing them.
