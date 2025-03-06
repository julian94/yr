# Search

This is a very simple example client that will search for a given location in Yr's databse.

## Example Output
```shell
Search Bergen
Searching for: Bergen
     1-92416: City - large town in Norway/Vestland/Bergen/Bergen
   2-2759154: Administration centre in The Netherlands/North Holland/Bergen/Bergen
   2-6296828: Meteorological station in Germany/Bergen
   2-2950622: Town in Germany/Lower Saxony/Bergen
   2-2950628: Administration centre in Germany/Rheinland-Pfalz/Bergen
   2-2950626: Administration centre in Germany/Saxony/Bergen
   2-2950635: Administration centre in Germany/Bavaria/Upper Bavaria/Bergen
   2-2950630: Administration centre in Germany/Bavaria/Middle Franconia/Bergen
   2-2950632: Populated place in Germany/Bavaria/Upper Bavaria/Bergen
   2-2950634: Populated place in Germany/Bavaria/Swabia/Bergen
   2-2950633: Populated place in Germany/Bavaria/Swabia/Bergen
   2-2950636: Populated place in Germany/Bavaria/Upper Bavaria/Bergen
   2-2950637: Populated place in Germany/Bavaria/Swabia/Bergen
   2-2950619: Populated locality in Germany/North Rhine-Westphalia/Düsseldorf District/Bergen
   2-2950629: Populated place in Germany/Saarland/Bergen
   2-2950627: Populated place in Germany/Saxony/Bergen
   2-2802207: Populated place in Belgium/Flanders/Flemish Brabant/Bergen
   2-2802204: Populated place in Belgium/Flanders/Antwerp Province/Bergen
   2-5245479: Populated place in United States/Wisconsin/Rock/Bergen
  2-11593634: Populated place in Austria/Styria/Hartberg-Fürstenfeld District/Bergen

```

## Publishing
To publish this program run either/both of these commands:
```shell
dotnet publish .\Example.Cli.Search\ --runtime win-x64   -p:PublishSingleFile=true
dotnet publish .\Example.Cli.Search\ --runtime linux-x64 -p:PublishSingleFile=true
```
