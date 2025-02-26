using Flurl.Http.Testing;
using System.Text.Json;
using Yr.Client;
using Yr.Model.Location.Requestables;

namespace Test.Yr.Client;

public class GetForecast
{
    private const string Data = """
        {
          "created": "2025-02-26T13:27:46+01:00",
          "update": "2025-02-26T14:27:46+01:00",
          "uv": {
            "duration": {
              "days": 2,
              "hours": 5
            },
            "url": "https://dsa.no/sol-og-solarium/slik-beskytter-du-deg-i-sola",
            "displayUrl": "dsa.no"
          },
          "dayIntervals": [
            {
              "start": "2025-02-26T13:00:00+01:00",
              "end": "2025-02-26T23:00:00+01:00",
              "twentyFourHourSymbol": "rain",
              "twelveHourSymbols": [
                null,
                "lightrain"
              ],
              "sixHourSymbols": [
                null,
                null,
                "rain",
                "lightrain"
              ],
              "symbolConfidence": "Certain",
              "precipitation": {
                "value": 2,
                "probability": 80
              },
              "temperature": {
                "value": 7.2,
                "min": 4.3,
                "max": 7.2
              },
              "wind": {
                "min": 2.2,
                "max": 4.2,
                "maxGust": 7.8
              }
            },
            {
              "start": "2025-02-27T00:00:00+01:00",
              "end": "2025-02-27T23:00:00+01:00",
              "twentyFourHourSymbol": "lightrain",
              "twelveHourSymbols": [
                "lightrain",
                "lightrain"
              ],
              "sixHourSymbols": [
                "cloudy",
                "lightrain",
                "rain",
                "cloudy"
              ],
              "symbolConfidence": "Certain",
              "precipitation": {
                "value": 1.9,
                "probability": 100
              },
              "temperature": {
                "value": 5.9,
                "min": 3.6,
                "max": 5.9
              },
              "wind": {
                "min": 2.8,
                "max": 4.2,
                "maxGust": 7.8
              }
            },
            {
              "start": "2025-02-28T00:00:00+01:00",
              "end": "2025-02-28T23:00:00+01:00",
              "twentyFourHourSymbol": "cloudy",
              "twelveHourSymbols": [
                "partlycloudy_day",
                "partlycloudy_day"
              ],
              "sixHourSymbols": [
                "partlycloudy_night",
                "cloudy",
                "cloudy",
                "partlycloudy_night"
              ],
              "symbolConfidence": "Uncertain",
              "precipitation": {
                "value": 0,
                "probability": 70
              },
              "temperature": {
                "value": 6.7,
                "min": 3.6,
                "max": 6.9
              },
              "wind": {
                "min": 3.2,
                "max": 3.6,
                "maxGust": 6.2
              }
            },
            {
              "start": "2025-03-01T00:00:00+01:00",
              "end": "2025-03-01T23:00:00+01:00",
              "twentyFourHourSymbol": "lightrain",
              "twelveHourSymbols": [
                "cloudy",
                "rain"
              ],
              "sixHourSymbols": [
                "cloudy",
                "cloudy",
                "rain",
                "rain"
              ],
              "symbolConfidence": "Certain",
              "precipitation": {
                "value": 5.8,
                "probability": 100
              },
              "temperature": {
                "value": 6.9,
                "min": 4.9,
                "max": 6.9
              },
              "wind": {
                "min": 2.5,
                "max": 5
              }
            },
            {
              "start": "2025-03-02T00:00:00+01:00",
              "end": "2025-03-02T23:00:00+01:00",
              "twentyFourHourSymbol": "lightrain",
              "twelveHourSymbols": [
                "rain",
                "lightrain"
              ],
              "sixHourSymbols": [
                "rain",
                "rain",
                "cloudy",
                "rain"
              ],
              "symbolConfidence": "Uncertain",
              "precipitation": {
                "value": 6.1,
                "probability": 70
              },
              "temperature": {
                "value": 8.8,
                "min": 5.3,
                "max": 8.8
              },
              "wind": {
                "min": 3.3,
                "max": 5.3
              }
            },
            {
              "start": "2025-03-03T00:00:00+01:00",
              "end": "2025-03-03T23:00:00+01:00",
              "twentyFourHourSymbol": "lightrain",
              "twelveHourSymbols": [
                "heavyrain",
                "lightrain"
              ],
              "sixHourSymbols": [
                "heavyrain",
                "heavyrain",
                "cloudy",
                "rain"
              ],
              "symbolConfidence": "SomewhatCertain",
              "precipitation": {
                "value": 16.1,
                "probability": 90
              },
              "temperature": {
                "value": 8.3,
                "min": 6.8,
                "max": 8.3
              },
              "wind": {
                "min": 5.3,
                "max": 5.5
              }
            },
            {
              "start": "2025-03-04T00:00:00+01:00",
              "end": "2025-03-04T23:00:00+01:00",
              "twentyFourHourSymbol": "lightrain",
              "twelveHourSymbols": [
                "rain",
                "rain"
              ],
              "sixHourSymbols": [
                "rain",
                "rain",
                "cloudy",
                "heavyrain"
              ],
              "symbolConfidence": "SomewhatCertain",
              "precipitation": {
                "value": 12.2,
                "probability": 90
              },
              "temperature": {
                "value": 8,
                "min": 7.2,
                "max": 8.3
              },
              "wind": {
                "min": 6.3,
                "max": 6.7
              }
            },
            {
              "start": "2025-03-05T00:00:00+01:00",
              "end": "2025-03-05T23:00:00+01:00",
              "twentyFourHourSymbol": "rain",
              "twelveHourSymbols": [
                "rain",
                "rain"
              ],
              "sixHourSymbols": [
                "cloudy",
                "heavyrain",
                "rain",
                "rain"
              ],
              "symbolConfidence": "SomewhatCertain",
              "precipitation": {
                "value": 13.8,
                "probability": 70
              },
              "temperature": {
                "value": 9,
                "min": 6.4,
                "max": 9
              },
              "wind": {
                "min": 4.9,
                "max": 5.9
              }
            },
            {
              "start": "2025-03-06T00:00:00+01:00",
              "end": "2025-03-06T23:00:00+01:00",
              "twentyFourHourSymbol": "cloudy",
              "twelveHourSymbols": [
                "lightrain",
                "lightrain"
              ],
              "sixHourSymbols": [
                "heavyrain",
                "cloudy",
                "cloudy",
                "rain"
              ],
              "symbolConfidence": "Uncertain",
              "precipitation": {
                "value": 8.1,
                "probability": 60
              },
              "temperature": {
                "value": 9.8,
                "min": 7.3,
                "max": 9.8
              },
              "wind": {
                "min": 4.8,
                "max": 5.8
              }
            },
            {
              "start": "2025-03-07T00:00:00+01:00",
              "end": "2025-03-07T23:00:00+01:00",
              "twentyFourHourSymbol": "cloudy",
              "twelveHourSymbols": [
                "lightrain",
                "lightrain"
              ],
              "sixHourSymbols": [
                "rain",
                "cloudy",
                "cloudy",
                "rain"
              ],
              "symbolConfidence": "Uncertain",
              "precipitation": {
                "value": 7.2,
                "probability": 60
              },
              "temperature": {
                "value": 8.7,
                "min": 6.8,
                "max": 8.7
              },
              "wind": {
                "min": 4.7,
                "max": 5.3
              }
            }
          ],
          "shortIntervals": [
            {
              "symbol": {
                "n": 4,
                "clouds": 3,
                "precip": 0,
                "sunup": false
              },
              "symbolCode": {
                "next1Hour": "cloudy",
                "next6Hours": "rain",
                "next12Hours": "lightrain"
              },
              "precipitation": {
                "min": 0,
                "max": 1.1,
                "value": 0,
                "pop": 44,
                "probability": 44
              },
              "temperature": {
                "value": 7.2,
                "probability": {
                  "tenPercentile": 6.3,
                  "ninetyPercentile": 8.1
                }
              },
              "wind": {
                "direction": 172,
                "gust": 7.8,
                "speed": 4.1,
                "probability": {
                  "tenPercentile": 3.3,
                  "ninetyPercentile": 4.8
                }
              },
              "feelsLike": {
                "value": 4
              },
              "pressure": {
                "value": 1009
              },
              "uvIndex": {
                "value": 0.7
              },
              "cloudCover": {
                "value": 87,
                "high": 0,
                "middle": 36,
                "low": 87,
                "fog": 0
              },
              "humidity": {
                "value": 79.4
              },
              "dewPoint": {
                "value": 3.5
              },
              "start": "2025-02-26T14:00:00+01:00",
              "end": "2025-02-26T15:00:00+01:00"
            },
            {
              "symbol": {
                "n": 9,
                "clouds": 3,
                "precipPhase": "Rain",
                "precip": 2,
                "sunup": false
              },
              "symbolCode": {
                "next1Hour": "rain",
                "next6Hours": "rain",
                "next12Hours": "lightrain"
              },
              "precipitation": {
                "min": 0,
                "max": 1,
                "value": 0.3,
                "pop": 40,
                "probability": 40
              },
              "temperature": {
                "value": 7,
                "probability": {
                  "tenPercentile": 6,
                  "ninetyPercentile": 8
                }
              },
              "wind": {
                "direction": 175,
                "gust": 7.5,
                "speed": 3.9,
                "probability": {
                  "tenPercentile": 3.6,
                  "ninetyPercentile": 4.4
                }
              },
              "feelsLike": {
                "value": 4
              },
              "pressure": {
                "value": 1009
              },
              "uvIndex": {
                "value": 0.5
              },
              "cloudCover": {
                "value": 92,
                "high": 8,
                "middle": 37,
                "low": 92,
                "fog": 0
              },
              "humidity": {
                "value": 81.4
              },
              "dewPoint": {
                "value": 3.7
              },
              "start": "2025-02-26T15:00:00+01:00",
              "end": "2025-02-26T16:00:00+01:00"
            },
            {
              "symbol": {
                "n": 9,
                "clouds": 3,
                "precipPhase": "Rain",
                "precip": 2,
                "sunup": false
              },
              "symbolCode": {
                "next1Hour": "rain",
                "next6Hours": "rain",
                "next12Hours": "lightrain"
              },
              "precipitation": {
                "min": 0,
                "max": 1.1,
                "value": 0.9,
                "pop": 38,
                "probability": 38
              },
              "temperature": {
                "value": 6.1,
                "probability": {
                  "tenPercentile": 4.8,
                  "ninetyPercentile": 7.7
                }
              },
              "wind": {
                "direction": 157,
                "gust": 6.9,
                "speed": 3.6,
                "probability": {
                  "tenPercentile": 3.4,
                  "ninetyPercentile": 4
                }
              },
              "feelsLike": {
                "value": 3
              },
              "pressure": {
                "value": 1009
              },
              "uvIndex": {
                "value": 0.2
              },
              "cloudCover": {
                "value": 97,
                "high": 34,
                "middle": 77,
                "low": 97,
                "fog": 0
              },
              "humidity": {
                "value": 93.3
              },
              "dewPoint": {
                "value": 4.8
              },
              "start": "2025-02-26T16:00:00+01:00",
              "end": "2025-02-26T17:00:00+01:00"
            },
            {
              "symbol": {
                "n": 4,
                "clouds": 3,
                "precip": 0,
                "sunup": false
              },
              "symbolCode": {
                "next1Hour": "cloudy",
                "next6Hours": "rain",
                "next12Hours": "lightrain"
              },
              "precipitation": {
                "min": 0,
                "max": 0.6,
                "value": 0,
                "pop": 30,
                "probability": 30
              },
              "temperature": {
                "value": 6,
                "probability": {
                  "tenPercentile": 4.5,
                  "ninetyPercentile": 7.8
                }
              },
              "wind": {
                "direction": 170,
                "gust": 7,
                "speed": 2.2,
                "probability": {
                  "tenPercentile": 2.2,
                  "ninetyPercentile": 4.2
                }
              },
              "feelsLike": {
                "value": 4
              },
              "pressure": {
                "value": 1009
              },
              "uvIndex": {
                "value": 0.1
              },
              "cloudCover": {
                "value": 100,
                "high": 95,
                "middle": 55,
                "low": 99,
                "fog": 0
              },
              "humidity": {
                "value": 96.5
              },
              "dewPoint": {
                "value": 5.2
              },
              "start": "2025-02-26T17:00:00+01:00",
              "end": "2025-02-26T18:00:00+01:00"
            },
            {
              "symbol": {
                "n": 4,
                "clouds": 3,
                "precip": 0,
                "sunup": false
              },
              "symbolCode": {
                "next1Hour": "cloudy",
                "next6Hours": "lightrain",
                "next12Hours": "lightrain"
              },
              "precipitation": {
                "min": 0,
                "max": 0.4,
                "value": 0,
                "pop": 22,
                "probability": 22
              },
              "temperature": {
                "value": 5.6,
                "probability": {
                  "tenPercentile": 4.2,
                  "ninetyPercentile": 7.3
                }
              },
              "wind": {
                "direction": 164,
                "gust": 4.7,
                "speed": 2.2,
                "probability": {
                  "tenPercentile": 2.2,
                  "ninetyPercentile": 3.6
                }
              },
              "feelsLike": {
                "value": 4
              },
              "pressure": {
                "value": 1010
              },
              "uvIndex": {
                "value": 0
              },
              "cloudCover": {
                "value": 100,
                "high": 99,
                "middle": 30,
                "low": 93,
                "fog": 0
              },
              "humidity": {
                "value": 94.8
              },
              "dewPoint": {
                "value": 4.7
              },
              "start": "2025-02-26T18:00:00+01:00",
              "end": "2025-02-26T19:00:00+01:00"
            },
            {
              "symbol": {
                "n": 4,
                "clouds": 3,
                "precip": 0,
                "sunup": false
              },
              "symbolCode": {
                "next1Hour": "cloudy",
                "next6Hours": "lightrain",
                "next12Hours": "lightrain"
              },
              "precipitation": {
                "min": 0,
                "max": 0.5,
                "value": 0,
                "pop": 21,
                "probability": 21
              },
              "temperature": {
                "value": 5,
                "probability": {
                  "tenPercentile": 3.7,
                  "ninetyPercentile": 6.4
                }
              },
              "wind": {
                "direction": 141,
                "gust": 7.1,
                "speed": 4.2,
                "probability": {
                  "tenPercentile": 2.9,
                  "ninetyPercentile": 4.2
                }
              },
              "feelsLike": {
                "value": 2
              },
              "pressure": {
                "value": 1010
              },
              "uvIndex": {
                "value": 0
              },
              "cloudCover": {
                "value": 99,
                "high": 91,
                "middle": 21,
                "low": 95,
                "fog": 0
              },
              "humidity": {
                "value": 94.1
              },
              "dewPoint": {
                "value": 3.9
              },
              "start": "2025-02-26T19:00:00+01:00",
              "end": "2025-02-26T20:00:00+01:00"
            },
            {
              "symbol": {
                "n": 4,
                "clouds": 3,
                "precip": 0,
                "sunup": false
              },
              "symbolCode": {
                "next1Hour": "cloudy",
                "next6Hours": "cloudy",
                "next12Hours": "lightrain"
              },
              "precipitation": {
                "min": 0,
                "max": 0.4,
                "value": 0,
                "pop": 21,
                "probability": 21
              },
              "temperature": {
                "value": 4.6,
                "probability": {
                  "tenPercentile": 3.1,
                  "ninetyPercentile": 6
                }
              },
              "wind": {
                "direction": 144,
                "gust": 7.2,
                "speed": 3.8,
                "probability": {
                  "tenPercentile": 2.6,
                  "ninetyPercentile": 4.2
                }
              },
              "feelsLike": {
                "value": 1
              },
              "pressure": {
                "value": 1010
              },
              "uvIndex": {
                "value": 0
              },
              "cloudCover": {
                "value": 94,
                "high": 51,
                "middle": 25,
                "low": 87,
                "fog": 0
              },
              "humidity": {
                "value": 93.9
              },
              "dewPoint": {
                "value": 3.4
              },
              "start": "2025-02-26T20:00:00+01:00",
              "end": "2025-02-26T21:00:00+01:00"
            },
            {
              "symbol": {
                "n": 4,
                "clouds": 3,
                "precip": 0,
                "sunup": false
              },
              "symbolCode": {
                "next1Hour": "cloudy",
                "next6Hours": "cloudy",
                "next12Hours": "lightrain"
              },
              "precipitation": {
                "min": 0,
                "max": 0.5,
                "value": 0,
                "pop": 25,
                "probability": 25
              },
              "temperature": {
                "value": 4.6,
                "probability": {
                  "tenPercentile": 3.2,
                  "ninetyPercentile": 6
                }
              },
              "wind": {
                "direction": 144,
                "gust": 7.4,
                "speed": 3.9,
                "probability": {
                  "tenPercentile": 3.1,
                  "ninetyPercentile": 4.2
                }
              },
              "feelsLike": {
                "value": 1
              },
              "pressure": {
                "value": 1011
              },
              "uvIndex": {
                "value": 0
              },
              "cloudCover": {
                "value": 98,
                "high": 33,
                "middle": 47,
                "low": 95,
                "fog": 0
              },
              "humidity": {
                "value": 94.1
              },
              "dewPoint": {
                "value": 3.5
              },
              "start": "2025-02-26T21:00:00+01:00",
              "end": "2025-02-26T22:00:00+01:00"
            },
            {
              "symbol": {
                "n": 4,
                "clouds": 3,
                "precip": 0,
                "sunup": false
              },
              "symbolCode": {
                "next1Hour": "cloudy",
                "next6Hours": "cloudy",
                "next12Hours": "lightrain"
              },
              "precipitation": {
                "min": 0,
                "max": 0.6,
                "value": 0,
                "pop": 26,
                "probability": 26
              },
              "temperature": {
                "value": 4.5,
                "probability": {
                  "tenPercentile": 2.9,
                  "ninetyPercentile": 6
                }
              },
              "wind": {
                "direction": 151,
                "gust": 6.9,
                "speed": 3,
                "probability": {
                  "tenPercentile": 2.9,
                  "ninetyPercentile": 4.5
                }
              },
              "feelsLike": {
                "value": 2
              },
              "pressure": {
                "value": 1011
              },
              "uvIndex": {
                "value": 0
              },
              "cloudCover": {
                "value": 92,
                "high": 1,
                "middle": 31,
                "low": 89,
                "fog": 0
              },
              "humidity": {
                "value": 95.1
              },
              "dewPoint": {
                "value": 3.5
              },
              "start": "2025-02-26T22:00:00+01:00",
              "end": "2025-02-26T23:00:00+01:00"
            },
            {
              "symbol": {
                "n": 4,
                "clouds": 3,
                "precip": 0,
                "sunup": false
              },
              "symbolCode": {
                "next1Hour": "cloudy",
                "next6Hours": "cloudy",
                "next12Hours": "lightrain"
              },
              "precipitation": {
                "min": 0,
                "max": 0.7,
                "value": 0,
                "pop": 26,
                "probability": 26
              },
              "temperature": {
                "value": 4.3,
                "probability": {
                  "tenPercentile": 2.7,
                  "ninetyPercentile": 5.9
                }
              },
              "wind": {
                "direction": 156,
                "gust": 7,
                "speed": 3.9,
                "probability": {
                  "tenPercentile": 2.9,
                  "ninetyPercentile": 4.5
                }
              },
              "feelsLike": {
                "value": 1
              },
              "pressure": {
                "value": 1012
              },
              "uvIndex": {
                "value": 0
              },
              "cloudCover": {
                "value": 96,
                "high": 0,
                "middle": 29,
                "low": 95,
                "fog": 0
              },
              "humidity": {
                "value": 95.6
              },
              "dewPoint": {
                "value": 3.4
              },
              "start": "2025-02-26T23:00:00+01:00",
              "end": "2025-02-27T00:00:00+01:00"
            },
            {
              "symbol": {
                "n": 4,
                "clouds": 3,
                "precip": 0,
                "sunup": false
              },
              "symbolCode": {
                "next1Hour": "cloudy",
                "next6Hours": "cloudy",
                "next12Hours": "lightrain"
              },
              "precipitation": {
                "min": 0,
                "max": 0.6,
                "value": 0,
                "pop": 26,
                "probability": 26
              },
              "temperature": {
                "value": 4.2,
                "probability": {
                  "tenPercentile": 2.6,
                  "ninetyPercentile": 5.8
                }
              },
              "wind": {
                "direction": 151,
                "gust": 6.6,
                "speed": 3.6,
                "probability": {
                  "tenPercentile": 2.6,
                  "ninetyPercentile": 4.6
                }
              },
              "feelsLike": {
                "value": 1
              },
              "pressure": {
                "value": 1012
              },
              "uvIndex": {
                "value": 0
              },
              "cloudCover": {
                "value": 92,
                "high": 0,
                "middle": 31,
                "low": 89,
                "fog": 0
              },
              "humidity": {
                "value": 95.2
              },
              "dewPoint": {
                "value": 3.3
              },
              "start": "2025-02-27T00:00:00+01:00",
              "end": "2025-02-27T01:00:00+01:00"
            },
            {
              "symbol": {
                "n": 4,
                "clouds": 3,
                "precip": 0,
                "sunup": false
              },
              "symbolCode": {
                "next1Hour": "cloudy",
                "next6Hours": "cloudy",
                "next12Hours": "lightrain"
              },
              "precipitation": {
                "min": 0,
                "max": 0.6,
                "value": 0,
                "pop": 35,
                "probability": 35
              },
              "temperature": {
                "value": 4.1,
                "probability": {
                  "tenPercentile": 2.5,
                  "ninetyPercentile": 5.7
                }
              },
              "wind": {
                "direction": 150,
                "gust": 6.3,
                "speed": 3.7,
                "probability": {
                  "tenPercentile": 2.8,
                  "ninetyPercentile": 4.5
                }
              },
              "feelsLike": {
                "value": 1
              },
              "pressure": {
                "value": 1012
              },
              "uvIndex": {
                "value": 0
              },
              "cloudCover": {
                "value": 92,
                "high": 0,
                "middle": 31,
                "low": 87,
                "fog": 0
              },
              "humidity": {
                "value": 94.9
              },
              "dewPoint": {
                "value": 3.1
              },
              "start": "2025-02-27T01:00:00+01:00",
              "end": "2025-02-27T02:00:00+01:00"
            },
            {
              "symbol": {
                "n": 4,
                "clouds": 3,
                "precip": 0,
                "sunup": false
              },
              "symbolCode": {
                "next1Hour": "cloudy",
                "next6Hours": "lightrain",
                "next12Hours": "lightrain"
              },
              "precipitation": {
                "min": 0,
                "max": 0.4,
                "value": 0,
                "pop": 27,
                "probability": 27
              },
              "temperature": {
                "value": 4.1,
                "probability": {
                  "tenPercentile": 2.5,
                  "ninetyPercentile": 5.7
                }
              },
              "wind": {
                "direction": 154,
                "gust": 6.5,
                "speed": 3.7,
                "probability": {
                  "tenPercentile": 3,
                  "ninetyPercentile": 4.1
                }
              },
              "feelsLike": {
                "value": 1
              },
              "pressure": {
                "value": 1012
              },
              "uvIndex": {
                "value": 0
              },
              "cloudCover": {
                "value": 95,
                "high": 0,
                "middle": 64,
                "low": 88,
                "fog": 0
              },
              "humidity": {
                "value": 92.3
              },
              "dewPoint": {
                "value": 2.7
              },
              "start": "2025-02-27T02:00:00+01:00",
              "end": "2025-02-27T03:00:00+01:00"
            },
            {
              "symbol": {
                "n": 4,
                "clouds": 3,
                "precip": 0,
                "sunup": false
              },
              "symbolCode": {
                "next1Hour": "cloudy",
                "next6Hours": "lightrain",
                "next12Hours": "lightrain"
              },
              "precipitation": {
                "min": 0,
                "max": 0.2,
                "value": 0,
                "pop": 17,
                "probability": 17
              },
              "temperature": {
                "value": 3.9,
                "probability": {
                  "tenPercentile": 2.2,
                  "ninetyPercentile": 5.6
                }
              },
              "wind": {
                "direction": 151,
                "gust": 6.8,
                "speed": 4,
                "probability": {
                  "tenPercentile": 2.9,
                  "ninetyPercentile": 4.4
                }
              },
              "feelsLike": {
                "value": 0
              },
              "pressure": {
                "value": 1012
              },
              "uvIndex": {
                "value": 0
              },
              "cloudCover": {
                "value": 89,
                "high": 0,
                "middle": 32,
                "low": 84,
                "fog": 0
              },
              "humidity": {
                "value": 92.9
              },
              "dewPoint": {
                "value": 2.6
              },
              "start": "2025-02-27T03:00:00+01:00",
              "end": "2025-02-27T04:00:00+01:00"
            },
            {
              "symbol": {
                "n": 4,
                "clouds": 3,
                "precip": 0,
                "sunup": false
              },
              "symbolCode": {
                "next1Hour": "cloudy",
                "next6Hours": "lightrain",
                "next12Hours": "lightrain"
              },
              "precipitation": {
                "min": 0,
                "max": 0.3,
                "value": 0,
                "pop": 20,
                "probability": 20
              },
              "temperature": {
                "value": 3.9,
                "probability": {
                  "tenPercentile": 2.1,
                  "ninetyPercentile": 5.6
                }
              },
              "wind": {
                "direction": 150,
                "gust": 7.3,
                "speed": 3.8,
                "probability": {
                  "tenPercentile": 3,
                  "ninetyPercentile": 4.3
                }
              },
              "feelsLike": {
                "value": 1
              },
              "pressure": {
                "value": 1013
              },
              "uvIndex": {
                "value": 0
              },
              "cloudCover": {
                "value": 94,
                "high": 0,
                "middle": 3,
                "low": 94,
                "fog": 0
              },
              "humidity": {
                "value": 93.5
              },
              "dewPoint": {
                "value": 2.6
              },
              "start": "2025-02-27T04:00:00+01:00",
              "end": "2025-02-27T05:00:00+01:00"
            },
            {
              "symbol": {
                "n": 4,
                "clouds": 3,
                "precip": 0,
                "sunup": false
              },
              "symbolCode": {
                "next1Hour": "cloudy",
                "next6Hours": "lightrain",
                "next12Hours": "lightrain"
              },
              "precipitation": {
                "min": 0,
                "max": 0.4,
                "value": 0,
                "pop": 28,
                "probability": 28
              },
              "temperature": {
                "value": 3.8,
                "probability": {
                  "tenPercentile": 2.1,
                  "ninetyPercentile": 5.5
                }
              },
              "wind": {
                "direction": 150,
                "gust": 7,
                "speed": 3.9,
                "probability": {
                  "tenPercentile": 3.2,
                  "ninetyPercentile": 4.1
                }
              },
              "feelsLike": {
                "value": 0
              },
              "pressure": {
                "value": 1013
              },
              "uvIndex": {
                "value": 0
              },
              "cloudCover": {
                "value": 96,
                "high": 0,
                "middle": 19,
                "low": 96,
                "fog": 0
              },
              "humidity": {
                "value": 93.6
              },
              "dewPoint": {
                "value": 2.6
              },
              "start": "2025-02-27T05:00:00+01:00",
              "end": "2025-02-27T06:00:00+01:00"
            },
            {
              "symbol": {
                "n": 46,
                "clouds": 3,
                "precipPhase": "Rain",
                "precip": 1,
                "sunup": false
              },
              "symbolCode": {
                "next1Hour": "lightrain",
                "next6Hours": "lightrain",
                "next12Hours": "lightrain"
              },
              "precipitation": {
                "min": 0,
                "max": 0.6,
                "value": 0.1,
                "pop": 36,
                "probability": 36
              },
              "temperature": {
                "value": 3.8,
                "probability": {
                  "tenPercentile": 2.1,
                  "ninetyPercentile": 5.5
                }
              },
              "wind": {
                "direction": 157,
                "gust": 7.3,
                "speed": 3.7,
                "probability": {
                  "tenPercentile": 3.1,
                  "ninetyPercentile": 4.1
                }
              },
              "feelsLike": {
                "value": 1
              },
              "pressure": {
                "value": 1013
              },
              "uvIndex": {
                "value": 0
              },
              "cloudCover": {
                "value": 95,
                "high": 0,
                "middle": 37,
                "low": 95,
                "fog": 0
              },
              "humidity": {
                "value": 93.3
              },
              "dewPoint": {
                "value": 2.6
              },
              "start": "2025-02-27T06:00:00+01:00",
              "end": "2025-02-27T07:00:00+01:00"
            },
            {
              "symbol": {
                "n": 4,
                "clouds": 3,
                "precip": 0,
                "sunup": false
              },
              "symbolCode": {
                "next1Hour": "cloudy",
                "next6Hours": "lightrain",
                "next12Hours": "lightrain"
              },
              "precipitation": {
                "min": 0,
                "max": 0.6,
                "value": 0,
                "pop": 39,
                "probability": 39
              },
              "temperature": {
                "value": 3.8,
                "probability": {
                  "tenPercentile": 2.2,
                  "ninetyPercentile": 5.4
                }
              },
              "wind": {
                "direction": 147,
                "gust": 7.8,
                "speed": 4.4,
                "probability": {
                  "tenPercentile": 3.4,
                  "ninetyPercentile": 4.4
                }
              },
              "feelsLike": {
                "value": 0
              },
              "pressure": {
                "value": 1014
              },
              "uvIndex": {
                "value": 0
              },
              "cloudCover": {
                "value": 98,
                "high": 0,
                "middle": 20,
                "low": 98,
                "fog": 0
              },
              "humidity": {
                "value": 93.5
              },
              "dewPoint": {
                "value": 2.6
              },
              "start": "2025-02-27T07:00:00+01:00",
              "end": "2025-02-27T08:00:00+01:00"
            },
            {
              "symbol": {
                "n": 4,
                "clouds": 3,
                "precip": 0,
                "sunup": false
              },
              "symbolCode": {
                "next1Hour": "cloudy",
                "next6Hours": "lightrain",
                "next12Hours": "lightrain"
              },
              "precipitation": {
                "min": 0,
                "max": 0.7,
                "value": 0,
                "pop": 44,
                "probability": 44
              },
              "temperature": {
                "value": 3.8,
                "probability": {
                  "tenPercentile": 2.2,
                  "ninetyPercentile": 5.5
                }
              },
              "wind": {
                "direction": 151,
                "gust": 7.8,
                "speed": 4.3,
                "probability": {
                  "tenPercentile": 3.2,
                  "ninetyPercentile": 4.3
                }
              },
              "feelsLike": {
                "value": 0
              },
              "pressure": {
                "value": 1014
              },
              "uvIndex": {
                "value": 0
              },
              "cloudCover": {
                "value": 92,
                "high": 0,
                "middle": 3,
                "low": 92,
                "fog": 0
              },
              "humidity": {
                "value": 94.4
              },
              "dewPoint": {
                "value": 2.7
              },
              "start": "2025-02-27T08:00:00+01:00",
              "end": "2025-02-27T09:00:00+01:00"
            },
            {
              "symbol": {
                "n": 46,
                "clouds": 3,
                "precipPhase": "Rain",
                "precip": 1,
                "sunup": false
              },
              "symbolCode": {
                "next1Hour": "lightrain",
                "next6Hours": "lightrain",
                "next12Hours": "lightrain"
              },
              "precipitation": {
                "min": 0,
                "max": 0.6,
                "value": 0.1,
                "pop": 37,
                "probability": 37
              },
              "temperature": {
                "value": 3.9,
                "probability": {
                  "tenPercentile": 2.3,
                  "ninetyPercentile": 5.5
                }
              },
              "wind": {
                "direction": 150,
                "gust": 7.4,
                "speed": 3.9,
                "probability": {
                  "tenPercentile": 3.1,
                  "ninetyPercentile": 4.1
                }
              },
              "feelsLike": {
                "value": 1
              },
              "pressure": {
                "value": 1015
              },
              "uvIndex": {
                "value": 0.2
              },
              "cloudCover": {
                "value": 90,
                "high": 0,
                "middle": 28,
                "low": 90,
                "fog": 0
              },
              "humidity": {
                "value": 94
              },
              "dewPoint": {
                "value": 2.7
              },
              "start": "2025-02-27T09:00:00+01:00",
              "end": "2025-02-27T10:00:00+01:00"
            },
            {
              "symbol": {
                "n": 4,
                "clouds": 3,
                "precip": 0,
                "sunup": false
              },
              "symbolCode": {
                "next1Hour": "cloudy",
                "next6Hours": "lightrain",
                "next12Hours": "lightrain"
              },
              "precipitation": {
                "min": 0,
                "max": 0.4,
                "value": 0,
                "pop": 26,
                "probability": 26
              },
              "temperature": {
                "value": 4.2,
                "probability": {
                  "tenPercentile": 2.6,
                  "ninetyPercentile": 5.9
                }
              },
              "wind": {
                "direction": 149,
                "gust": 7.4,
                "speed": 4.2,
                "probability": {
                  "tenPercentile": 3.5,
                  "ninetyPercentile": 4.2
                }
              },
              "feelsLike": {
                "value": 1
              },
              "pressure": {
                "value": 1016
              },
              "uvIndex": {
                "value": 0.4
              },
              "cloudCover": {
                "value": 87,
                "high": 0,
                "middle": 10,
                "low": 87,
                "fog": 0
              },
              "humidity": {
                "value": 95.1
              },
              "dewPoint": {
                "value": 3.3
              },
              "start": "2025-02-27T10:00:00+01:00",
              "end": "2025-02-27T11:00:00+01:00"
            },
            {
              "symbol": {
                "n": 4,
                "clouds": 3,
                "precip": 0,
                "sunup": false
              },
              "symbolCode": {
                "next1Hour": "cloudy",
                "next6Hours": "lightrain",
                "next12Hours": "lightrain"
              },
              "precipitation": {
                "min": 0,
                "max": 0.3,
                "value": 0,
                "pop": 26,
                "probability": 26
              },
              "temperature": {
                "value": 4.9,
                "probability": {
                  "tenPercentile": 3.2,
                  "ninetyPercentile": 6.6
                }
              },
              "wind": {
                "direction": 152,
                "gust": 8,
                "speed": 4.2,
                "probability": {
                  "tenPercentile": 3.5,
                  "ninetyPercentile": 4.5
                }
              },
              "feelsLike": {
                "value": 2
              },
              "pressure": {
                "value": 1016
              },
              "uvIndex": {
                "value": 0.7
              },
              "cloudCover": {
                "value": 87,
                "high": 0,
                "middle": 7,
                "low": 87,
                "fog": 0
              },
              "humidity": {
                "value": 91.4
              },
              "dewPoint": {
                "value": 3.3
              },
              "start": "2025-02-27T11:00:00+01:00",
              "end": "2025-02-27T12:00:00+01:00"
            },
            {
              "symbol": {
                "n": 3,
                "clouds": 2,
                "precip": 0,
                "var": "Sun",
                "sunup": false
              },
              "symbolCode": {
                "next1Hour": "partlycloudy_day",
                "next6Hours": "rain",
                "next12Hours": "lightrain"
              },
              "precipitation": {
                "min": 0,
                "max": 0.4,
                "value": 0,
                "pop": 29,
                "probability": 29
              },
              "temperature": {
                "value": 5.4,
                "probability": {
                  "tenPercentile": 3.5,
                  "ninetyPercentile": 7.2
                }
              },
              "wind": {
                "direction": 148,
                "gust": 7.8,
                "speed": 4.2,
                "probability": {
                  "tenPercentile": 3.7,
                  "ninetyPercentile": 4.3
                }
              },
              "feelsLike": {
                "value": 2
              },
              "pressure": {
                "value": 1017
              },
              "uvIndex": {
                "value": 0.9
              },
              "cloudCover": {
                "value": 82,
                "high": 0,
                "middle": 1,
                "low": 82,
                "fog": 0
              },
              "humidity": {
                "value": 89.2
              },
              "dewPoint": {
                "value": 3.5
              },
              "start": "2025-02-27T12:00:00+01:00",
              "end": "2025-02-27T13:00:00+01:00"
            },
            {
              "symbol": {
                "n": 4,
                "clouds": 3,
                "precip": 0,
                "sunup": false
              },
              "symbolCode": {
                "next1Hour": "cloudy",
                "next6Hours": "rain",
                "next12Hours": "lightrain"
              },
              "precipitation": {
                "min": 0,
                "max": 0.6,
                "value": 0,
                "pop": 28,
                "probability": 28
              },
              "temperature": {
                "value": 5.8,
                "probability": {
                  "tenPercentile": 4,
                  "ninetyPercentile": 7.4
                }
              },
              "wind": {
                "direction": 155,
                "gust": 7.9,
                "speed": 3.6,
                "probability": {
                  "tenPercentile": 3.6,
                  "ninetyPercentile": 4
                }
              },
              "feelsLike": {
                "value": 3
              },
              "pressure": {
                "value": 1017
              },
              "uvIndex": {
                "value": 0.9
              },
              "cloudCover": {
                "value": 92,
                "high": 0,
                "middle": 0,
                "low": 92,
                "fog": 0
              },
              "humidity": {
                "value": 85.5
              },
              "dewPoint": {
                "value": 3.3
              },
              "start": "2025-02-27T13:00:00+01:00",
              "end": "2025-02-27T14:00:00+01:00"
            },
            {
              "symbol": {
                "n": 4,
                "clouds": 3,
                "precip": 0,
                "sunup": false
              },
              "symbolCode": {
                "next1Hour": "cloudy",
                "next6Hours": "rain",
                "next12Hours": "lightrainshowers_day"
              },
              "precipitation": {
                "min": 0,
                "max": 0.9,
                "value": 0,
                "pop": 36,
                "probability": 36
              },
              "temperature": {
                "value": 5.9,
                "probability": {
                  "tenPercentile": 4,
                  "ninetyPercentile": 7.7
                }
              },
              "wind": {
                "direction": 161,
                "gust": 6.8,
                "speed": 3.6,
                "probability": {
                  "tenPercentile": 3.1,
                  "ninetyPercentile": 4
                }
              },
              "feelsLike": {
                "value": 3
              },
              "pressure": {
                "value": 1017
              },
              "uvIndex": {
                "value": 0.8
              },
              "cloudCover": {
                "value": 96,
                "high": 0,
                "middle": 21,
                "low": 94,
                "fog": 0
              },
              "humidity": {
                "value": 86.4
              },
              "dewPoint": {
                "value": 3.5
              },
              "start": "2025-02-27T14:00:00+01:00",
              "end": "2025-02-27T15:00:00+01:00"
            },
            {
              "symbol": {
                "n": 4,
                "clouds": 3,
                "precip": 0,
                "sunup": false
              },
              "symbolCode": {
                "next1Hour": "cloudy",
                "next6Hours": "lightrain",
                "next12Hours": "lightrainshowers_day"
              },
              "precipitation": {
                "min": 0,
                "max": 1.2,
                "value": 0,
                "pop": 43,
                "probability": 43
              },
              "temperature": {
                "value": 5.9,
                "probability": {
                  "tenPercentile": 4,
                  "ninetyPercentile": 7.7
                }
              },
              "wind": {
                "direction": 178,
                "gust": 7.6,
                "speed": 3.8,
                "probability": {
                  "tenPercentile": 2.4,
                  "ninetyPercentile": 3.8
                }
              },
              "feelsLike": {
                "value": 3
              },
              "pressure": {
                "value": 1017
              },
              "uvIndex": {
                "value": 0.5
              },
              "cloudCover": {
                "value": 93,
                "high": 43,
                "middle": 69,
                "low": 83,
                "fog": 0
              },
              "humidity": {
                "value": 85.9
              },
              "dewPoint": {
                "value": 3.5
              },
              "start": "2025-02-27T15:00:00+01:00",
              "end": "2025-02-27T16:00:00+01:00"
            },
            {
              "symbol": {
                "n": 46,
                "clouds": 3,
                "precipPhase": "Rain",
                "precip": 1,
                "sunup": false
              },
              "symbolCode": {
                "next1Hour": "lightrain",
                "next6Hours": "cloudy",
                "next12Hours": "partlycloudy_day"
              },
              "precipitation": {
                "min": 0,
                "max": 1.2,
                "value": 0.1,
                "pop": 45,
                "probability": 45
              },
              "temperature": {
                "value": 5.6,
                "probability": {
                  "tenPercentile": 3.8,
                  "ninetyPercentile": 7.4
                }
              },
              "wind": {
                "direction": 164,
                "gust": 6.8,
                "speed": 3.3,
                "probability": {
                  "tenPercentile": 2.6,
                  "ninetyPercentile": 3.6
                }
              },
              "feelsLike": {
                "value": 3
              },
              "pressure": {
                "value": 1018
              },
              "uvIndex": {
                "value": 0.3
              },
              "cloudCover": {
                "value": 100,
                "high": 96,
                "middle": 82,
                "low": 100,
                "fog": 0
              },
              "humidity": {
                "value": 90.5
              },
              "dewPoint": {
                "value": 3.9
              },
              "start": "2025-02-27T16:00:00+01:00",
              "end": "2025-02-27T17:00:00+01:00"
            },
            {
              "symbol": {
                "n": 4,
                "clouds": 3,
                "precip": 0,
                "sunup": false
              },
              "symbolCode": {
                "next1Hour": "cloudy",
                "next6Hours": "cloudy",
                "next12Hours": "partlycloudy_day"
              },
              "precipitation": {
                "min": 0,
                "max": 1.1,
                "value": 0,
                "pop": 32,
                "probability": 32
              },
              "temperature": {
                "value": 5.2,
                "probability": {
                  "tenPercentile": 3.5,
                  "ninetyPercentile": 7
                }
              },
              "wind": {
                "direction": 156,
                "gust": 6.1,
                "speed": 3.1,
                "probability": {
                  "tenPercentile": 2.3,
                  "ninetyPercentile": 3.2
                }
              },
              "feelsLike": {
                "value": 3
              },
              "pressure": {
                "value": 1018
              },
              "uvIndex": {
                "value": 0.1
              },
              "cloudCover": {
                "value": 99,
                "high": 94,
                "middle": 58,
                "low": 85,
                "fog": 0
              },
              "humidity": {
                "value": 93.1
              },
              "dewPoint": {
                "value": 3.9
              },
              "start": "2025-02-27T17:00:00+01:00",
              "end": "2025-02-27T18:00:00+01:00"
            },
            {
              "symbol": {
                "n": 4,
                "clouds": 3,
                "precip": 0,
                "sunup": false
              },
              "symbolCode": {
                "next1Hour": "cloudy",
                "next6Hours": "cloudy",
                "next12Hours": "partlycloudy_day"
              },
              "precipitation": {
                "min": 0,
                "max": 0.4,
                "value": 0,
                "pop": 17,
                "probability": 17
              },
              "temperature": {
                "value": 4.7,
                "probability": {
                  "tenPercentile": 3,
                  "ninetyPercentile": 6.5
                }
              },
              "wind": {
                "direction": 135,
                "gust": 5.5,
                "speed": 2.8,
                "probability": {
                  "tenPercentile": 2.3,
                  "ninetyPercentile": 3.3
                }
              },
              "feelsLike": {
                "value": 2
              },
              "pressure": {
                "value": 1019
              },
              "uvIndex": {
                "value": 0
              },
              "cloudCover": {
                "value": 95,
                "high": 71,
                "middle": 7,
                "low": 83,
                "fog": 0
              },
              "humidity": {
                "value": 93.3
              },
              "dewPoint": {
                "value": 3.5
              },
              "start": "2025-02-27T18:00:00+01:00",
              "end": "2025-02-27T19:00:00+01:00"
            },
            {
              "symbol": {
                "n": 4,
                "clouds": 3,
                "precip": 0,
                "sunup": false
              },
              "symbolCode": {
                "next1Hour": "cloudy",
                "next6Hours": "partlycloudy_night",
                "next12Hours": "partlycloudy_night"
              },
              "precipitation": {
                "min": 0,
                "max": 0,
                "value": 0,
                "pop": 10,
                "probability": 10
              },
              "temperature": {
                "value": 4.1,
                "probability": {
                  "tenPercentile": 2.2,
                  "ninetyPercentile": 6
                }
              },
              "wind": {
                "direction": 134,
                "gust": 5.1,
                "speed": 3.1,
                "probability": {
                  "tenPercentile": 2.4,
                  "ninetyPercentile": 3.4
                }
              },
              "feelsLike": {
                "value": 1
              },
              "pressure": {
                "value": 1019
              },
              "uvIndex": {
                "value": 0
              },
              "cloudCover": {
                "value": 99,
                "high": 98,
                "middle": 0,
                "low": 55,
                "fog": 0
              },
              "humidity": {
                "value": 95.2
              },
              "dewPoint": {
                "value": 3.1
              },
              "start": "2025-02-27T19:00:00+01:00",
              "end": "2025-02-27T20:00:00+01:00"
            },
            {
              "symbol": {
                "n": 4,
                "clouds": 3,
                "precip": 0,
                "sunup": false
              },
              "symbolCode": {
                "next1Hour": "cloudy",
                "next6Hours": "partlycloudy_night",
                "next12Hours": "partlycloudy_night"
              },
              "precipitation": {
                "min": 0,
                "max": 0,
                "value": 0,
                "pop": 6,
                "probability": 6
              },
              "temperature": {
                "value": 3.8,
                "probability": {
                  "tenPercentile": 1.7,
                  "ninetyPercentile": 5.7
                }
              },
              "wind": {
                "direction": 118,
                "gust": 5.2,
                "speed": 3,
                "probability": {
                  "tenPercentile": 2.6,
                  "ninetyPercentile": 3.6
                }
              },
              "feelsLike": {
                "value": 1
              },
              "pressure": {
                "value": 1020
              },
              "uvIndex": {
                "value": 0
              },
              "cloudCover": {
                "value": 97,
                "high": 88,
                "middle": 0,
                "low": 67,
                "fog": 0
              },
              "humidity": {
                "value": 93.7
              },
              "dewPoint": {
                "value": 2.6
              },
              "start": "2025-02-27T20:00:00+01:00",
              "end": "2025-02-27T21:00:00+01:00"
            },
            {
              "symbol": {
                "n": 4,
                "clouds": 3,
                "precip": 0,
                "sunup": false
              },
              "symbolCode": {
                "next1Hour": "cloudy",
                "next6Hours": "partlycloudy_night",
                "next12Hours": "partlycloudy_night"
              },
              "precipitation": {
                "min": 0,
                "max": 0,
                "value": 0,
                "pop": 4,
                "probability": 4
              },
              "temperature": {
                "value": 3.6,
                "probability": {
                  "tenPercentile": 1.3,
                  "ninetyPercentile": 5.7
                }
              },
              "wind": {
                "direction": 121,
                "gust": 5.3,
                "speed": 3.2,
                "probability": {
                  "tenPercentile": 2.8,
                  "ninetyPercentile": 3.5
                }
              },
              "feelsLike": {
                "value": 1
              },
              "pressure": {
                "value": 1020
              },
              "uvIndex": {
                "value": 0
              },
              "cloudCover": {
                "value": 90,
                "high": 9,
                "middle": 0,
                "low": 88,
                "fog": 0
              },
              "humidity": {
                "value": 92.4
              },
              "dewPoint": {
                "value": 2.2
              },
              "start": "2025-02-27T21:00:00+01:00",
              "end": "2025-02-27T22:00:00+01:00"
            },
            {
              "symbol": {
                "n": 4,
                "clouds": 3,
                "precip": 0,
                "sunup": false
              },
              "symbolCode": {
                "next1Hour": "cloudy",
                "next6Hours": "partlycloudy_night",
                "next12Hours": "partlycloudy_night"
              },
              "precipitation": {
                "min": 0,
                "max": 0,
                "value": 0,
                "pop": 6,
                "probability": 6
              },
              "temperature": {
                "value": 3.8,
                "probability": {
                  "tenPercentile": 1.4,
                  "ninetyPercentile": 5.9
                }
              },
              "wind": {
                "direction": 127,
                "gust": 5.9,
                "speed": 3.4,
                "probability": {
                  "tenPercentile": 2.7,
                  "ninetyPercentile": 3.5
                }
              },
              "feelsLike": {
                "value": 1
              },
              "pressure": {
                "value": 1021
              },
              "uvIndex": {
                "value": 0
              },
              "cloudCover": {
                "value": 96,
                "high": 0,
                "middle": 0,
                "low": 96,
                "fog": 0
              },
              "humidity": {
                "value": 90.8
              },
              "dewPoint": {
                "value": 2.1
              },
              "start": "2025-02-27T22:00:00+01:00",
              "end": "2025-02-27T23:00:00+01:00"
            },
            {
              "symbol": {
                "n": 3,
                "clouds": 2,
                "precip": 0,
                "var": "Moon",
                "sunup": false
              },
              "symbolCode": {
                "next1Hour": "partlycloudy_night",
                "next6Hours": "partlycloudy_night",
                "next12Hours": "partlycloudy_day"
              },
              "precipitation": {
                "min": 0,
                "max": 0,
                "value": 0,
                "pop": 7,
                "probability": 7
              },
              "temperature": {
                "value": 3.9,
                "probability": {
                  "tenPercentile": 1.5,
                  "ninetyPercentile": 6
                }
              },
              "wind": {
                "direction": 132,
                "gust": 6,
                "speed": 3.4,
                "probability": {
                  "tenPercentile": 2.5,
                  "ninetyPercentile": 3.9
                }
              },
              "feelsLike": {
                "value": 1
              },
              "pressure": {
                "value": 1021
              },
              "uvIndex": {
                "value": 0
              },
              "cloudCover": {
                "value": 78,
                "high": 1,
                "middle": 3,
                "low": 78,
                "fog": 0
              },
              "humidity": {
                "value": 92.8
              },
              "dewPoint": {
                "value": 2.5
              },
              "start": "2025-02-27T23:00:00+01:00",
              "end": "2025-02-28T00:00:00+01:00"
            },
            {
              "symbol": {
                "n": 3,
                "clouds": 2,
                "precip": 0,
                "var": "Moon",
                "sunup": false
              },
              "symbolCode": {
                "next1Hour": "partlycloudy_night",
                "next6Hours": "partlycloudy_night",
                "next12Hours": "partlycloudy_day"
              },
              "precipitation": {
                "min": 0,
                "max": 0,
                "value": 0,
                "pop": 8,
                "probability": 8
              },
              "temperature": {
                "value": 3.9,
                "probability": {
                  "tenPercentile": 1.6,
                  "ninetyPercentile": 6
                }
              },
              "wind": {
                "direction": 131,
                "gust": 6.2,
                "speed": 3.6,
                "probability": {
                  "tenPercentile": 2.9,
                  "ninetyPercentile": 3.6
                }
              },
              "feelsLike": {
                "value": 1
              },
              "pressure": {
                "value": 1022
              },
              "uvIndex": {
                "value": 0
              },
              "cloudCover": {
                "value": 67,
                "high": 0,
                "middle": 1,
                "low": 67,
                "fog": 0
              },
              "humidity": {
                "value": 92.2
              },
              "dewPoint": {
                "value": 2.4
              },
              "start": "2025-02-28T00:00:00+01:00",
              "end": "2025-02-28T01:00:00+01:00"
            },
            {
              "symbol": {
                "n": 3,
                "clouds": 2,
                "precip": 0,
                "var": "Moon",
                "sunup": false
              },
              "symbolCode": {
                "next1Hour": "partlycloudy_night",
                "next6Hours": "partlycloudy_night",
                "next12Hours": "partlycloudy_day"
              },
              "precipitation": {
                "min": 0,
                "max": 0.2,
                "value": 0,
                "pop": 12,
                "probability": 12
              },
              "temperature": {
                "value": 3.8,
                "probability": {
                  "tenPercentile": 1.5,
                  "ninetyPercentile": 5.9
                }
              },
              "wind": {
                "direction": 131,
                "gust": 6.1,
                "speed": 3.3,
                "probability": {
                  "tenPercentile": 2.8,
                  "ninetyPercentile": 3.5
                }
              },
              "feelsLike": {
                "value": 1
              },
              "pressure": {
                "value": 1022
              },
              "uvIndex": {
                "value": 0
              },
              "cloudCover": {
                "value": 56,
                "high": 0,
                "middle": 0,
                "low": 55,
                "fog": 0
              },
              "humidity": {
                "value": 91.3
              },
              "dewPoint": {
                "value": 2.2
              },
              "start": "2025-02-28T01:00:00+01:00",
              "end": "2025-02-28T02:00:00+01:00"
            },
            {
              "symbol": {
                "n": 3,
                "clouds": 2,
                "precip": 0,
                "var": "Moon",
                "sunup": false
              },
              "symbolCode": {
                "next1Hour": "partlycloudy_night",
                "next6Hours": "partlycloudy_night",
                "next12Hours": "cloudy"
              },
              "precipitation": {
                "min": 0,
                "max": 0,
                "value": 0,
                "pop": 12,
                "probability": 12
              },
              "temperature": {
                "value": 3.7,
                "probability": {
                  "tenPercentile": 1.4,
                  "ninetyPercentile": 5.7
                }
              },
              "wind": {
                "direction": 128,
                "gust": 6.7,
                "speed": 3.4,
                "probability": {
                  "tenPercentile": 1.4,
                  "ninetyPercentile": 3.6
                }
              },
              "feelsLike": {
                "value": 1
              },
              "pressure": {
                "value": 1022
              },
              "uvIndex": {
                "value": 0
              },
              "cloudCover": {
                "value": 48,
                "high": 0,
                "middle": 2,
                "low": 47,
                "fog": 0
              },
              "humidity": {
                "value": 90.4
              },
              "dewPoint": {
                "value": 1.9
              },
              "start": "2025-02-28T02:00:00+01:00",
              "end": "2025-02-28T03:00:00+01:00"
            },
            {
              "symbol": {
                "n": 3,
                "clouds": 2,
                "precip": 0,
                "var": "Moon",
                "sunup": false
              },
              "symbolCode": {
                "next1Hour": "partlycloudy_night",
                "next6Hours": "partlycloudy_night",
                "next12Hours": "cloudy"
              },
              "precipitation": {
                "min": 0,
                "max": 0.2,
                "value": 0,
                "pop": 13,
                "probability": 13
              },
              "temperature": {
                "value": 3.6,
                "probability": {
                  "tenPercentile": 1.3,
                  "ninetyPercentile": 5.8
                }
              },
              "wind": {
                "direction": 127,
                "gust": 7,
                "speed": 3.9,
                "probability": {
                  "tenPercentile": 3,
                  "ninetyPercentile": 3.9
                }
              },
              "feelsLike": {
                "value": 0
              },
              "pressure": {
                "value": 1022
              },
              "uvIndex": {
                "value": 0
              },
              "cloudCover": {
                "value": 67,
                "high": 0,
                "middle": 0,
                "low": 67,
                "fog": 0
              },
              "humidity": {
                "value": 88.8
              },
              "dewPoint": {
                "value": 1.6
              },
              "start": "2025-02-28T03:00:00+01:00",
              "end": "2025-02-28T04:00:00+01:00"
            },
            {
              "symbol": {
                "n": 3,
                "clouds": 2,
                "precip": 0,
                "var": "Moon",
                "sunup": false
              },
              "symbolCode": {
                "next1Hour": "partlycloudy_night",
                "next6Hours": "partlycloudy_night",
                "next12Hours": "cloudy"
              },
              "precipitation": {
                "min": 0,
                "max": 0.4,
                "value": 0,
                "pop": 21,
                "probability": 21
              },
              "temperature": {
                "value": 3.9,
                "probability": {
                  "tenPercentile": 1.6,
                  "ninetyPercentile": 5.9
                }
              },
              "wind": {
                "direction": 130,
                "gust": 6.6,
                "speed": 3.5,
                "probability": {
                  "tenPercentile": 2.7,
                  "ninetyPercentile": 3.9
                }
              },
              "feelsLike": {
                "value": 1
              },
              "pressure": {
                "value": 1022
              },
              "uvIndex": {
                "value": 0
              },
              "cloudCover": {
                "value": 77,
                "high": 0,
                "middle": 4,
                "low": 77,
                "fog": 0
              },
              "humidity": {
                "value": 86.7
              },
              "dewPoint": {
                "value": 1.5
              },
              "start": "2025-02-28T04:00:00+01:00",
              "end": "2025-02-28T05:00:00+01:00"
            },
            {
              "symbol": {
                "n": 4,
                "clouds": 3,
                "precip": 0,
                "sunup": false
              },
              "symbolCode": {
                "next1Hour": "cloudy",
                "next6Hours": "cloudy",
                "next12Hours": "cloudy"
              },
              "precipitation": {
                "min": 0,
                "max": 0.4,
                "value": 0,
                "pop": 27,
                "probability": 27
              },
              "temperature": {
                "value": 3.7,
                "probability": {
                  "tenPercentile": 1.5,
                  "ninetyPercentile": 5.8
                }
              },
              "wind": {
                "direction": 141,
                "gust": 6.3,
                "speed": 3.4,
                "probability": {
                  "tenPercentile": 2.9,
                  "ninetyPercentile": 3.9
                }
              },
              "feelsLike": {
                "value": 1
              },
              "pressure": {
                "value": 1023
              },
              "uvIndex": {
                "value": 0
              },
              "cloudCover": {
                "value": 91,
                "high": 0,
                "middle": 2,
                "low": 91,
                "fog": 0
              },
              "humidity": {
                "value": 87.7
              },
              "dewPoint": {
                "value": 1.6
              },
              "start": "2025-02-28T05:00:00+01:00",
              "end": "2025-02-28T06:00:00+01:00"
            },
            {
              "symbol": {
                "n": 4,
                "clouds": 3,
                "precip": 0,
                "sunup": false
              },
              "symbolCode": {
                "next1Hour": "cloudy",
                "next6Hours": "cloudy",
                "next12Hours": "cloudy"
              },
              "precipitation": {
                "min": 0,
                "max": 0.4,
                "value": 0,
                "pop": 24,
                "probability": 24
              },
              "temperature": {
                "value": 3.6,
                "probability": {
                  "tenPercentile": 1.4,
                  "ninetyPercentile": 5.6
                }
              },
              "wind": {
                "direction": 134,
                "gust": 6.1,
                "speed": 3.6,
                "probability": {
                  "tenPercentile": 2.9,
                  "ninetyPercentile": 3.7
                }
              },
              "feelsLike": {
                "value": 0
              },
              "pressure": {
                "value": 1024
              },
              "uvIndex": {
                "value": 0
              },
              "cloudCover": {
                "value": 97,
                "high": 0,
                "middle": 0,
                "low": 97,
                "fog": 0
              },
              "humidity": {
                "value": 87.5
              },
              "dewPoint": {
                "value": 1.4
              },
              "start": "2025-02-28T06:00:00+01:00",
              "end": "2025-02-28T07:00:00+01:00"
            },
            {
              "symbol": {
                "n": 3,
                "clouds": 2,
                "precip": 0,
                "var": "Moon",
                "sunup": false
              },
              "symbolCode": {
                "next1Hour": "partlycloudy_night",
                "next6Hours": "cloudy",
                "next12Hours": "cloudy"
              },
              "precipitation": {
                "min": 0,
                "max": 0.4,
                "value": 0,
                "pop": 22,
                "probability": 22
              },
              "temperature": {
                "value": 3.8,
                "probability": {
                  "tenPercentile": 1.5,
                  "ninetyPercentile": 5.8
                }
              },
              "wind": {
                "direction": 134,
                "gust": 6.3,
                "speed": 3.5,
                "probability": {
                  "tenPercentile": 2.9,
                  "ninetyPercentile": 3.6
                }
              },
              "feelsLike": {
                "value": 1
              },
              "pressure": {
                "value": 1024
              },
              "uvIndex": {
                "value": 0
              },
              "cloudCover": {
                "value": 83,
                "high": 0,
                "middle": 2,
                "low": 83,
                "fog": 0
              },
              "humidity": {
                "value": 88.2
              },
              "dewPoint": {
                "value": 1.5
              },
              "start": "2025-02-28T07:00:00+01:00",
              "end": "2025-02-28T08:00:00+01:00"
            },
            {
              "symbol": {
                "n": 3,
                "clouds": 2,
                "precip": 0,
                "var": "Sun",
                "sunup": false
              },
              "symbolCode": {
                "next1Hour": "partlycloudy_day",
                "next6Hours": "cloudy"
              },
              "precipitation": {
                "min": 0,
                "max": 0.4,
                "value": 0,
                "pop": 24,
                "probability": 24
              },
              "temperature": {
                "value": 3.8,
                "probability": {
                  "tenPercentile": 1.7,
                  "ninetyPercentile": 5.8
                }
              },
              "wind": {
                "direction": 137,
                "gust": 6.2,
                "speed": 3.4,
                "probability": {
                  "tenPercentile": 3,
                  "ninetyPercentile": 4.3
                }
              },
              "feelsLike": {
                "value": 1
              },
              "pressure": {
                "value": 1024
              },
              "uvIndex": {
                "value": 0
              },
              "cloudCover": {
                "value": 63,
                "high": 0,
                "middle": 9,
                "low": 62,
                "fog": 0
              },
              "humidity": {
                "value": 89
              },
              "dewPoint": {
                "value": 1.8
              },
              "start": "2025-02-28T08:00:00+01:00",
              "end": "2025-02-28T09:00:00+01:00"
            },
            {
              "symbol": {
                "n": 3,
                "clouds": 2,
                "precip": 0,
                "var": "Sun",
                "sunup": false
              },
              "symbolCode": {
                "next1Hour": "partlycloudy_day",
                "next6Hours": "cloudy"
              },
              "precipitation": {
                "min": 0,
                "max": 0.4,
                "value": 0,
                "pop": 24,
                "probability": 24
              },
              "temperature": {
                "value": 4.1,
                "probability": {
                  "tenPercentile": 2.1,
                  "ninetyPercentile": 6.1
                }
              },
              "wind": {
                "direction": 139,
                "gust": 6.9,
                "speed": 3.8,
                "probability": {
                  "tenPercentile": 3,
                  "ninetyPercentile": 3.8
                }
              },
              "feelsLike": {
                "value": 1
              },
              "pressure": {
                "value": 1025
              },
              "uvIndex": {
                "value": 0.2
              },
              "cloudCover": {
                "value": 84,
                "high": 0,
                "middle": 51,
                "low": 78,
                "fog": 0
              },
              "humidity": {
                "value": 85.8
              },
              "dewPoint": {
                "value": 1.6
              },
              "start": "2025-02-28T09:00:00+01:00",
              "end": "2025-02-28T10:00:00+01:00"
            },
            {
              "symbol": {
                "n": 4,
                "clouds": 3,
                "precip": 0,
                "sunup": false
              },
              "symbolCode": {
                "next1Hour": "cloudy",
                "next6Hours": "cloudy"
              },
              "precipitation": {
                "min": 0,
                "max": 0.2,
                "value": 0,
                "pop": 17,
                "probability": 17
              },
              "temperature": {
                "value": 4.9,
                "probability": {
                  "tenPercentile": 3,
                  "ninetyPercentile": 6.7
                }
              },
              "wind": {
                "direction": 145,
                "gust": 7.2,
                "speed": 4,
                "probability": {
                  "tenPercentile": 2.2,
                  "ninetyPercentile": 4.3
                }
              },
              "feelsLike": {
                "value": 2
              },
              "pressure": {
                "value": 1025
              },
              "uvIndex": {
                "value": 0.5
              },
              "cloudCover": {
                "value": 96,
                "high": 0,
                "middle": 36,
                "low": 92,
                "fog": 0
              },
              "humidity": {
                "value": 84.4
              },
              "dewPoint": {
                "value": 2.1
              },
              "start": "2025-02-28T10:00:00+01:00",
              "end": "2025-02-28T11:00:00+01:00"
            },
            {
              "symbol": {
                "n": 4,
                "clouds": 3,
                "precip": 0,
                "sunup": false
              },
              "symbolCode": {
                "next1Hour": "cloudy",
                "next6Hours": "cloudy"
              },
              "precipitation": {
                "min": 0,
                "max": 0.3,
                "value": 0,
                "pop": 24,
                "probability": 24
              },
              "temperature": {
                "value": 5.5,
                "probability": {
                  "tenPercentile": 3.5,
                  "ninetyPercentile": 7.4
                }
              },
              "wind": {
                "direction": 157,
                "gust": 7.1,
                "speed": 3.5,
                "probability": {
                  "tenPercentile": 3.3,
                  "ninetyPercentile": 4.3
                }
              },
              "feelsLike": {
                "value": 3
              },
              "pressure": {
                "value": 1026
              },
              "uvIndex": {
                "value": 0.9
              },
              "cloudCover": {
                "value": 99,
                "high": 8,
                "middle": 2,
                "low": 99,
                "fog": 0
              },
              "humidity": {
                "value": 82.9
              },
              "dewPoint": {
                "value": 2.5
              },
              "start": "2025-02-28T11:00:00+01:00",
              "end": "2025-02-28T12:00:00+01:00"
            },
            {
              "symbol": {
                "n": 4,
                "clouds": 3,
                "precip": 0,
                "sunup": false
              },
              "symbolCode": {
                "next1Hour": "cloudy",
                "next6Hours": "cloudy"
              },
              "precipitation": {
                "min": 0,
                "max": 0.4,
                "value": 0,
                "pop": 23,
                "probability": 23
              },
              "temperature": {
                "value": 5.9,
                "probability": {
                  "tenPercentile": 3.7,
                  "ninetyPercentile": 8.1
                }
              },
              "wind": {
                "direction": 142,
                "gust": 6.1,
                "speed": 3.5,
                "probability": {
                  "tenPercentile": 2.8,
                  "ninetyPercentile": 4.2
                }
              },
              "feelsLike": {
                "value": 3
              },
              "pressure": {
                "value": 1026
              },
              "uvIndex": {
                "value": 1.1
              },
              "cloudCover": {
                "value": 100,
                "high": 31,
                "middle": 0,
                "low": 100,
                "fog": 0
              },
              "humidity": {
                "value": 91
              },
              "dewPoint": {
                "value": 4.3
              },
              "start": "2025-02-28T12:00:00+01:00",
              "end": "2025-02-28T13:00:00+01:00"
            },
            {
              "symbol": {
                "n": 4,
                "clouds": 3,
                "precip": 0,
                "sunup": false
              },
              "symbolCode": {
                "next1Hour": "cloudy",
                "next6Hours": "cloudy",
                "next12Hours": "partlycloudy_day"
              },
              "precipitation": {
                "min": 0,
                "max": 0,
                "value": 0,
                "pop": 12,
                "probability": 12
              },
              "temperature": {
                "value": 6.6,
                "probability": {
                  "tenPercentile": 4.2,
                  "ninetyPercentile": 9.1
                }
              },
              "wind": {
                "direction": 150,
                "gust": 6.7,
                "speed": 3.6,
                "probability": {
                  "tenPercentile": 3,
                  "ninetyPercentile": 4.1
                }
              },
              "feelsLike": {
                "value": 4
              },
              "pressure": {
                "value": 1026
              },
              "uvIndex": {
                "value": 1.2
              },
              "cloudCover": {
                "value": 99,
                "high": 87,
                "middle": 0,
                "low": 93,
                "fog": 0
              },
              "humidity": {
                "value": 88.5
              },
              "dewPoint": {
                "value": 4.6
              },
              "start": "2025-02-28T13:00:00+01:00",
              "end": "2025-02-28T14:00:00+01:00"
            },
            {
              "symbol": {
                "n": 4,
                "clouds": 3,
                "precip": 0,
                "sunup": false
              },
              "symbolCode": {
                "next1Hour": "cloudy"
              },
              "precipitation": {
                "min": 0,
                "max": 0,
                "value": 0,
                "pop": 11,
                "probability": 11
              },
              "temperature": {
                "value": 6.7,
                "probability": {
                  "tenPercentile": 4.4,
                  "ninetyPercentile": 8.9
                }
              },
              "wind": {
                "direction": 149,
                "gust": 6.7,
                "speed": 3.6,
                "probability": {
                  "tenPercentile": 2.7,
                  "ninetyPercentile": 3.9
                }
              },
              "feelsLike": {
                "value": 4
              },
              "pressure": {
                "value": 1026
              },
              "uvIndex": {
                "value": 1.1
              },
              "cloudCover": {
                "value": 97,
                "high": 82,
                "middle": 0,
                "low": 83,
                "fog": 0
              },
              "humidity": {
                "value": 85.6
              },
              "dewPoint": {
                "value": 4.3
              },
              "start": "2025-02-28T14:00:00+01:00",
              "end": "2025-02-28T15:00:00+01:00"
            },
            {
              "symbol": {
                "n": 4,
                "clouds": 3,
                "precip": 0,
                "sunup": false
              },
              "symbolCode": {
                "next1Hour": "cloudy"
              },
              "precipitation": {
                "min": 0,
                "max": 0,
                "value": 0,
                "pop": 9,
                "probability": 9
              },
              "temperature": {
                "value": 6.9,
                "probability": {
                  "tenPercentile": 4.6,
                  "ninetyPercentile": 9.1
                }
              },
              "wind": {
                "direction": 161,
                "gust": 6.9,
                "speed": 3.2,
                "probability": {
                  "tenPercentile": 2.7,
                  "ninetyPercentile": 3.7
                }
              },
              "feelsLike": {
                "value": 5
              },
              "pressure": {
                "value": 1026
              },
              "uvIndex": {
                "value": 0.7
              },
              "cloudCover": {
                "value": 98,
                "high": 83,
                "middle": 9,
                "low": 91,
                "fog": 0
              },
              "humidity": {
                "value": 81.3
              },
              "dewPoint": {
                "value": 3.9
              },
              "start": "2025-02-28T15:00:00+01:00",
              "end": "2025-02-28T16:00:00+01:00"
            },
            {
              "symbol": {
                "n": 4,
                "clouds": 3,
                "precip": 0,
                "sunup": false
              },
              "symbolCode": {
                "next1Hour": "cloudy"
              },
              "precipitation": {
                "min": 0,
                "max": 0.2,
                "value": 0,
                "pop": 14,
                "probability": 14
              },
              "temperature": {
                "value": 6.9,
                "probability": {
                  "tenPercentile": 4.6,
                  "ninetyPercentile": 9.1
                }
              },
              "wind": {
                "direction": 154,
                "gust": 5.8,
                "speed": 2.4,
                "probability": {
                  "tenPercentile": 2.2,
                  "ninetyPercentile": 3.2
                }
              },
              "feelsLike": {
                "value": 5
              },
              "pressure": {
                "value": 1026
              },
              "uvIndex": {
                "value": 0.4
              },
              "cloudCover": {
                "value": 99,
                "high": 30,
                "middle": 1,
                "low": 99,
                "fog": 0
              },
              "humidity": {
                "value": 87.2
              },
              "dewPoint": {
                "value": 4.7
              },
              "start": "2025-02-28T16:00:00+01:00",
              "end": "2025-02-28T17:00:00+01:00"
            },
            {
              "symbol": {
                "n": 4,
                "clouds": 3,
                "precip": 0,
                "sunup": false
              },
              "symbolCode": {
                "next1Hour": "cloudy"
              },
              "precipitation": {
                "min": 0,
                "max": 0.2,
                "value": 0,
                "pop": 13,
                "probability": 13
              },
              "temperature": {
                "value": 6.7,
                "probability": {
                  "tenPercentile": 4.5,
                  "ninetyPercentile": 8.8
                }
              },
              "wind": {
                "direction": 143,
                "gust": 4.6,
                "speed": 2.6,
                "probability": {
                  "tenPercentile": 2.4,
                  "ninetyPercentile": 3.3
                }
              },
              "feelsLike": {
                "value": 5
              },
              "pressure": {
                "value": 1026
              },
              "uvIndex": {
                "value": 0.1
              },
              "cloudCover": {
                "value": 96,
                "high": 0,
                "middle": 0,
                "low": 96,
                "fog": 0
              },
              "humidity": {
                "value": 86.8
              },
              "dewPoint": {
                "value": 4.4
              },
              "start": "2025-02-28T17:00:00+01:00",
              "end": "2025-02-28T18:00:00+01:00"
            },
            {
              "symbol": {
                "n": 4,
                "clouds": 3,
                "precip": 0,
                "sunup": false
              },
              "symbolCode": {
                "next1Hour": "cloudy"
              },
              "precipitation": {
                "min": 0,
                "max": 0,
                "value": 0,
                "pop": 10,
                "probability": 10
              },
              "temperature": {
                "value": 6,
                "probability": {
                  "tenPercentile": 4.3,
                  "ninetyPercentile": 7.8
                }
              },
              "wind": {
                "direction": 153,
                "gust": 4.5,
                "speed": 2.5,
                "probability": {
                  "tenPercentile": 2.3,
                  "ninetyPercentile": 3.3
                }
              },
              "feelsLike": {
                "value": 4
              },
              "pressure": {
                "value": 1027
              },
              "uvIndex": {
                "value": 0
              },
              "cloudCover": {
                "value": 92,
                "high": 2,
                "middle": 0,
                "low": 91,
                "fog": 0
              },
              "humidity": {
                "value": 92.9
              },
              "dewPoint": {
                "value": 4.7
              },
              "start": "2025-02-28T18:00:00+01:00",
              "end": "2025-02-28T19:00:00+01:00"
            }
          ],
          "longIntervals": [
            {
              "symbol": {
                "n": 9,
                "clouds": 3,
                "precipPhase": "Rain",
                "precip": 2,
                "sunup": false
              },
              "symbolCode": {
                "next1Hour": "cloudy",
                "next6Hours": "rain",
                "next12Hours": "lightrain"
              },
              "precipitation": {
                "min": 0.1,
                "max": 3.9,
                "value": 2.9,
                "pop": 58,
                "probability": 58
              },
              "temperature": {
                "value": 7.2,
                "min": 4.6,
                "max": 7,
                "probability": {
                  "tenPercentile": 6.3,
                  "ninetyPercentile": 8.1
                }
              },
              "wind": {
                "direction": 172,
                "gust": 7.8,
                "speed": 4.1,
                "probability": {
                  "tenPercentile": 3.3,
                  "ninetyPercentile": 4.8
                }
              },
              "feelsLike": {
                "value": 4
              },
              "pressure": {
                "value": 1009
              },
              "cloudCover": {
                "value": 87,
                "high": 0,
                "middle": 36,
                "low": 87,
                "fog": 0
              },
              "humidity": {
                "value": 79.4
              },
              "dewPoint": {
                "value": 3.5
              },
              "start": "2025-02-26T14:00:00+01:00",
              "end": "2025-02-26T18:00:00+01:00",
              "nominalStart": "2025-02-26T12:00:00+01:00",
              "nominalEnd": "2025-02-26T18:00:00+01:00"
            },
            {
              "symbol": {
                "n": 46,
                "clouds": 3,
                "precipPhase": "Rain",
                "precip": 1,
                "sunup": false
              },
              "symbolCode": {
                "next1Hour": "cloudy",
                "next6Hours": "lightrain",
                "next12Hours": "lightrain"
              },
              "precipitation": {
                "min": 0.1,
                "max": 2.7,
                "value": 0.8,
                "pop": 49,
                "probability": 49
              },
              "temperature": {
                "value": 5.6,
                "min": 4.2,
                "max": 5,
                "probability": {
                  "tenPercentile": 4.2,
                  "ninetyPercentile": 7.3
                }
              },
              "wind": {
                "direction": 164,
                "gust": 4.7,
                "speed": 2.2,
                "probability": {
                  "tenPercentile": 2.2,
                  "ninetyPercentile": 3.6
                }
              },
              "feelsLike": {
                "value": 4
              },
              "pressure": {
                "value": 1010
              },
              "cloudCover": {
                "value": 100,
                "high": 99,
                "middle": 30,
                "low": 93,
                "fog": 0
              },
              "humidity": {
                "value": 94.8
              },
              "dewPoint": {
                "value": 4.7
              },
              "start": "2025-02-26T18:00:00+01:00",
              "end": "2025-02-27T00:00:00+01:00",
              "nominalStart": "2025-02-26T18:00:00+01:00",
              "nominalEnd": "2025-02-27T00:00:00+01:00"
            },
            {
              "symbol": {
                "n": 4,
                "clouds": 3,
                "precip": 0,
                "sunup": false
              },
              "symbolCode": {
                "next1Hour": "cloudy",
                "next6Hours": "cloudy",
                "next12Hours": "lightrain"
              },
              "precipitation": {
                "min": 0,
                "max": 2.2,
                "value": 0,
                "pop": 45,
                "probability": 45
              },
              "temperature": {
                "value": 4.2,
                "min": 3.8,
                "max": 4.1,
                "probability": {
                  "tenPercentile": 2.6,
                  "ninetyPercentile": 5.8
                }
              },
              "wind": {
                "direction": 151,
                "gust": 6.6,
                "speed": 3.6,
                "probability": {
                  "tenPercentile": 2.6,
                  "ninetyPercentile": 4.6
                }
              },
              "feelsLike": {
                "value": 1
              },
              "pressure": {
                "value": 1012
              },
              "cloudCover": {
                "value": 92,
                "high": 0,
                "middle": 31,
                "low": 89,
                "fog": 0
              },
              "humidity": {
                "value": 95.2
              },
              "dewPoint": {
                "value": 3.3
              },
              "start": "2025-02-27T00:00:00+01:00",
              "end": "2025-02-27T06:00:00+01:00",
              "nominalStart": "2025-02-27T00:00:00+01:00",
              "nominalEnd": "2025-02-27T06:00:00+01:00"
            },
            {
              "symbol": {
                "n": 46,
                "clouds": 3,
                "precipPhase": "Rain",
                "precip": 1,
                "sunup": false
              },
              "symbolCode": {
                "next1Hour": "lightrain",
                "next6Hours": "lightrain",
                "next12Hours": "lightrain"
              },
              "precipitation": {
                "min": 0.3,
                "max": 2.5,
                "value": 0.8,
                "pop": 67,
                "probability": 67
              },
              "temperature": {
                "value": 3.8,
                "min": 3.8,
                "max": 5.4,
                "probability": {
                  "tenPercentile": 2.1,
                  "ninetyPercentile": 5.5
                }
              },
              "wind": {
                "direction": 157,
                "gust": 7.3,
                "speed": 3.7,
                "probability": {
                  "tenPercentile": 3.1,
                  "ninetyPercentile": 4.1
                }
              },
              "feelsLike": {
                "value": 1
              },
              "pressure": {
                "value": 1013
              },
              "cloudCover": {
                "value": 95,
                "high": 0,
                "middle": 37,
                "low": 95,
                "fog": 0
              },
              "humidity": {
                "value": 93.3
              },
              "dewPoint": {
                "value": 2.6
              },
              "start": "2025-02-27T06:00:00+01:00",
              "end": "2025-02-27T12:00:00+01:00",
              "nominalStart": "2025-02-27T06:00:00+01:00",
              "nominalEnd": "2025-02-27T12:00:00+01:00"
            },
            {
              "symbol": {
                "n": 9,
                "clouds": 3,
                "precipPhase": "Rain",
                "precip": 2,
                "sunup": false
              },
              "symbolCode": {
                "next1Hour": "partlycloudy_day",
                "next6Hours": "rain",
                "next12Hours": "lightrain"
              },
              "precipitation": {
                "min": 0.3,
                "max": 3.9,
                "value": 1.1,
                "pop": 72,
                "probability": 72
              },
              "temperature": {
                "value": 5.4,
                "min": 4.7,
                "max": 5.9,
                "probability": {
                  "tenPercentile": 3.5,
                  "ninetyPercentile": 7.2
                }
              },
              "wind": {
                "direction": 148,
                "gust": 7.8,
                "speed": 4.2,
                "probability": {
                  "tenPercentile": 3.7,
                  "ninetyPercentile": 4.3
                }
              },
              "feelsLike": {
                "value": 2
              },
              "pressure": {
                "value": 1017
              },
              "cloudCover": {
                "value": 82,
                "high": 0,
                "middle": 1,
                "low": 82,
                "fog": 0
              },
              "humidity": {
                "value": 89.2
              },
              "dewPoint": {
                "value": 3.5
              },
              "start": "2025-02-27T12:00:00+01:00",
              "end": "2025-02-27T18:00:00+01:00",
              "nominalStart": "2025-02-27T12:00:00+01:00",
              "nominalEnd": "2025-02-27T18:00:00+01:00"
            },
            {
              "symbol": {
                "n": 4,
                "clouds": 3,
                "precip": 0,
                "sunup": false
              },
              "symbolCode": {
                "next1Hour": "cloudy",
                "next6Hours": "cloudy",
                "next12Hours": "partlycloudy_day"
              },
              "precipitation": {
                "min": 0,
                "max": 1.1,
                "value": 0,
                "pop": 18,
                "probability": 18
              },
              "temperature": {
                "value": 4.7,
                "min": 3.6,
                "max": 4.1,
                "probability": {
                  "tenPercentile": 3,
                  "ninetyPercentile": 6.5
                }
              },
              "wind": {
                "direction": 135,
                "gust": 5.5,
                "speed": 2.8,
                "probability": {
                  "tenPercentile": 2.3,
                  "ninetyPercentile": 3.3
                }
              },
              "feelsLike": {
                "value": 2
              },
              "pressure": {
                "value": 1019
              },
              "cloudCover": {
                "value": 95,
                "high": 71,
                "middle": 7,
                "low": 83,
                "fog": 0
              },
              "humidity": {
                "value": 93.3
              },
              "dewPoint": {
                "value": 3.5
              },
              "start": "2025-02-27T18:00:00+01:00",
              "end": "2025-02-28T00:00:00+01:00",
              "nominalStart": "2025-02-27T18:00:00+01:00",
              "nominalEnd": "2025-02-28T00:00:00+01:00"
            },
            {
              "symbol": {
                "n": 3,
                "clouds": 2,
                "precip": 0,
                "var": "Moon",
                "sunup": false
              },
              "symbolCode": {
                "next1Hour": "partlycloudy_night",
                "next6Hours": "partlycloudy_night",
                "next12Hours": "partlycloudy_day"
              },
              "precipitation": {
                "min": 0,
                "max": 1.5,
                "value": 0,
                "pop": 31,
                "probability": 31
              },
              "temperature": {
                "value": 3.9,
                "min": 3.6,
                "max": 3.9,
                "probability": {
                  "tenPercentile": 1.6,
                  "ninetyPercentile": 6
                }
              },
              "wind": {
                "direction": 131,
                "gust": 6.2,
                "speed": 3.6,
                "probability": {
                  "tenPercentile": 2.9,
                  "ninetyPercentile": 3.6
                }
              },
              "feelsLike": {
                "value": 1
              },
              "pressure": {
                "value": 1022
              },
              "cloudCover": {
                "value": 67,
                "high": 0,
                "middle": 1,
                "low": 67,
                "fog": 0
              },
              "humidity": {
                "value": 92.2
              },
              "dewPoint": {
                "value": 2.4
              },
              "start": "2025-02-28T00:00:00+01:00",
              "end": "2025-02-28T06:00:00+01:00",
              "nominalStart": "2025-02-28T00:00:00+01:00",
              "nominalEnd": "2025-02-28T06:00:00+01:00"
            },
            {
              "symbol": {
                "n": 4,
                "clouds": 3,
                "precip": 0,
                "sunup": false
              },
              "symbolCode": {
                "next1Hour": "cloudy",
                "next6Hours": "cloudy",
                "next12Hours": "cloudy"
              },
              "precipitation": {
                "min": 0,
                "max": 1.7,
                "value": 0,
                "pop": 46,
                "probability": 46
              },
              "temperature": {
                "value": 3.6,
                "min": 3.8,
                "max": 5.9,
                "probability": {
                  "tenPercentile": 1.4,
                  "ninetyPercentile": 5.6
                }
              },
              "wind": {
                "direction": 134,
                "gust": 6.1,
                "speed": 3.6,
                "probability": {
                  "tenPercentile": 2.9,
                  "ninetyPercentile": 3.7
                }
              },
              "feelsLike": {
                "value": 0
              },
              "pressure": {
                "value": 1024
              },
              "cloudCover": {
                "value": 97,
                "high": 0,
                "middle": 0,
                "low": 97,
                "fog": 0
              },
              "humidity": {
                "value": 87.5
              },
              "dewPoint": {
                "value": 1.4
              },
              "start": "2025-02-28T06:00:00+01:00",
              "end": "2025-02-28T12:00:00+01:00",
              "nominalStart": "2025-02-28T06:00:00+01:00",
              "nominalEnd": "2025-02-28T12:00:00+01:00"
            },
            {
              "symbol": {
                "n": 4,
                "clouds": 3,
                "precip": 0,
                "sunup": false
              },
              "symbolCode": {
                "next1Hour": "cloudy",
                "next6Hours": "cloudy"
              },
              "precipitation": {
                "min": 0,
                "max": 0.9,
                "value": 0,
                "pop": 23,
                "probability": 23
              },
              "temperature": {
                "value": 5.9,
                "min": 6,
                "max": 6.9,
                "probability": {
                  "tenPercentile": 3.7,
                  "ninetyPercentile": 8.1
                }
              },
              "wind": {
                "direction": 142,
                "gust": 6.1,
                "speed": 3.5,
                "probability": {
                  "tenPercentile": 2.8,
                  "ninetyPercentile": 4.2
                }
              },
              "feelsLike": {
                "value": 3
              },
              "pressure": {
                "value": 1026
              },
              "cloudCover": {
                "value": 100,
                "high": 31,
                "middle": 0,
                "low": 100,
                "fog": 0
              },
              "humidity": {
                "value": 91
              },
              "dewPoint": {
                "value": 4.3
              },
              "start": "2025-02-28T12:00:00+01:00",
              "end": "2025-02-28T18:00:00+01:00",
              "nominalStart": "2025-02-28T12:00:00+01:00",
              "nominalEnd": "2025-02-28T18:00:00+01:00"
            },
            {
              "symbol": {
                "n": 3,
                "clouds": 2,
                "precip": 0,
                "var": "Moon",
                "sunup": false
              },
              "symbolCode": {
                "next6Hours": "partlycloudy_night",
                "next12Hours": "cloudy"
              },
              "precipitation": {
                "min": 0,
                "max": 0,
                "value": 0,
                "pop": 14,
                "probability": 14
              },
              "temperature": {
                "value": 5.5,
                "min": 5.1,
                "max": 5.8,
                "probability": {
                  "tenPercentile": 3.6,
                  "ninetyPercentile": 7.4
                }
              },
              "wind": {
                "direction": 141,
                "gust": 5.4,
                "speed": 3.2,
                "probability": {
                  "tenPercentile": 2.5,
                  "ninetyPercentile": 3.7
                }
              },
              "feelsLike": {
                "value": 3
              },
              "pressure": {
                "value": 1027
              },
              "uvIndex": {
                "value": 0
              },
              "cloudCover": {
                "value": 92,
                "high": 35,
                "middle": 0,
                "low": 89,
                "fog": 0
              },
              "humidity": {
                "value": 93.3
              },
              "dewPoint": {
                "value": 4.3
              },
              "start": "2025-02-28T19:00:00+01:00",
              "end": "2025-03-01T01:00:00+01:00",
              "nominalStart": "2025-02-28T18:00:00+01:00",
              "nominalEnd": "2025-03-01T00:00:00+01:00"
            },
            {
              "symbol": {
                "n": 4,
                "clouds": 3,
                "precip": 0,
                "sunup": false
              },
              "symbolCode": {
                "next6Hours": "cloudy",
                "next12Hours": "cloudy"
              },
              "precipitation": {
                "min": 0,
                "max": 0,
                "value": 0,
                "pop": 6,
                "probability": 6
              },
              "temperature": {
                "value": 5.5,
                "min": 5.5,
                "max": 5.6,
                "probability": {
                  "tenPercentile": 4.6,
                  "ninetyPercentile": 6.2
                }
              },
              "wind": {
                "direction": 158,
                "speed": 3.6,
                "probability": {
                  "tenPercentile": 2.7,
                  "ninetyPercentile": 5.1
                }
              },
              "feelsLike": {
                "value": 3
              },
              "pressure": {
                "value": 1026
              },
              "cloudCover": {
                "value": 100,
                "high": 100,
                "middle": 1,
                "low": 100,
                "fog": 0
              },
              "humidity": {
                "value": 94.4
              },
              "dewPoint": {
                "value": 4.6
              },
              "start": "2025-03-01T01:00:00+01:00",
              "end": "2025-03-01T07:00:00+01:00",
              "nominalStart": "2025-03-01T00:00:00+01:00",
              "nominalEnd": "2025-03-01T06:00:00+01:00"
            },
            {
              "symbol": {
                "n": 4,
                "clouds": 3,
                "precip": 0,
                "sunup": false
              },
              "symbolCode": {
                "next6Hours": "cloudy",
                "next12Hours": "lightrain"
              },
              "precipitation": {
                "min": 0,
                "max": 1.5,
                "value": 0,
                "pop": 39,
                "probability": 39
              },
              "temperature": {
                "value": 5.6,
                "min": 5.6,
                "max": 6.9,
                "probability": {
                  "tenPercentile": 4.7,
                  "ninetyPercentile": 6.2
                }
              },
              "wind": {
                "direction": 162,
                "speed": 4.8,
                "probability": {
                  "tenPercentile": 3.4,
                  "ninetyPercentile": 7
                }
              },
              "feelsLike": {
                "value": 2
              },
              "pressure": {
                "value": 1025
              },
              "cloudCover": {
                "value": 100,
                "high": 100,
                "middle": 6,
                "low": 100,
                "fog": 0
              },
              "humidity": {
                "value": 91.9
              },
              "dewPoint": {
                "value": 4.3
              },
              "start": "2025-03-01T07:00:00+01:00",
              "end": "2025-03-01T13:00:00+01:00",
              "nominalStart": "2025-03-01T06:00:00+01:00",
              "nominalEnd": "2025-03-01T12:00:00+01:00"
            },
            {
              "symbol": {
                "n": 9,
                "clouds": 3,
                "precipPhase": "Rain",
                "precip": 2,
                "sunup": false
              },
              "symbolCode": {
                "next6Hours": "rain",
                "next12Hours": "rain"
              },
              "precipitation": {
                "min": 0.5,
                "max": 10.1,
                "value": 3.7,
                "pop": 74,
                "probability": 74
              },
              "temperature": {
                "value": 6.9,
                "min": 6.1,
                "max": 6.9,
                "probability": {
                  "tenPercentile": 6.1,
                  "ninetyPercentile": 7.6
                }
              },
              "wind": {
                "direction": 170,
                "speed": 5,
                "probability": {
                  "tenPercentile": 3.5,
                  "ninetyPercentile": 7.1
                }
              },
              "feelsLike": {
                "value": 4
              },
              "pressure": {
                "value": 1025
              },
              "cloudCover": {
                "value": 100,
                "high": 100,
                "middle": 100,
                "low": 100,
                "fog": 0
              },
              "humidity": {
                "value": 91.5
              },
              "dewPoint": {
                "value": 5.5
              },
              "start": "2025-03-01T13:00:00+01:00",
              "end": "2025-03-01T19:00:00+01:00",
              "nominalStart": "2025-03-01T12:00:00+01:00",
              "nominalEnd": "2025-03-01T18:00:00+01:00"
            },
            {
              "symbol": {
                "n": 9,
                "clouds": 3,
                "precipPhase": "Rain",
                "precip": 2,
                "sunup": false
              },
              "symbolCode": {
                "next6Hours": "rain",
                "next12Hours": "rain"
              },
              "precipitation": {
                "min": 0,
                "max": 4.5,
                "value": 2.1,
                "pop": 51,
                "probability": 51
              },
              "temperature": {
                "value": 6.2,
                "min": 4.9,
                "max": 6.2,
                "probability": {
                  "tenPercentile": 5,
                  "ninetyPercentile": 6.8
                }
              },
              "wind": {
                "direction": 159,
                "speed": 2.5,
                "probability": {
                  "tenPercentile": 0.7,
                  "ninetyPercentile": 3.9
                }
              },
              "feelsLike": {
                "value": 4
              },
              "pressure": {
                "value": 1026
              },
              "cloudCover": {
                "value": 93,
                "high": 0,
                "middle": 79,
                "low": 73,
                "fog": 0
              },
              "humidity": {
                "value": 97
              },
              "dewPoint": {
                "value": 5.7
              },
              "start": "2025-03-01T19:00:00+01:00",
              "end": "2025-03-02T01:00:00+01:00",
              "nominalStart": "2025-03-01T18:00:00+01:00",
              "nominalEnd": "2025-03-02T00:00:00+01:00"
            },
            {
              "symbol": {
                "n": 9,
                "clouds": 3,
                "precipPhase": "Rain",
                "precip": 2,
                "sunup": false
              },
              "symbolCode": {
                "next6Hours": "rain",
                "next12Hours": "rain"
              },
              "precipitation": {
                "min": 0,
                "max": 6,
                "value": 2.1,
                "pop": 61,
                "probability": 61
              },
              "temperature": {
                "value": 5.3,
                "min": 5.3,
                "max": 6.2,
                "probability": {
                  "tenPercentile": 4.5,
                  "ninetyPercentile": 6.7
                }
              },
              "wind": {
                "direction": 157,
                "speed": 3.3,
                "probability": {
                  "tenPercentile": 1.8,
                  "ninetyPercentile": 4.9
                }
              },
              "feelsLike": {
                "value": 3
              },
              "pressure": {
                "value": 1027
              },
              "cloudCover": {
                "value": 100,
                "high": 99,
                "middle": 83,
                "low": 78,
                "fog": 0
              },
              "humidity": {
                "value": 94.9
              },
              "dewPoint": {
                "value": 4.5
              },
              "start": "2025-03-02T01:00:00+01:00",
              "end": "2025-03-02T07:00:00+01:00",
              "nominalStart": "2025-03-02T00:00:00+01:00",
              "nominalEnd": "2025-03-02T06:00:00+01:00"
            },
            {
              "symbol": {
                "n": 9,
                "clouds": 3,
                "precipPhase": "Rain",
                "precip": 2,
                "sunup": false
              },
              "symbolCode": {
                "next6Hours": "rain",
                "next12Hours": "lightrain"
              },
              "precipitation": {
                "min": 0,
                "max": 3.2,
                "value": 1.7,
                "pop": 35,
                "probability": 35
              },
              "temperature": {
                "value": 6.2,
                "min": 6.2,
                "max": 8.8,
                "probability": {
                  "tenPercentile": 4.8,
                  "ninetyPercentile": 7.8
                }
              },
              "wind": {
                "direction": 162,
                "speed": 4.2,
                "probability": {
                  "tenPercentile": 2.4,
                  "ninetyPercentile": 5.4
                }
              },
              "feelsLike": {
                "value": 3
              },
              "pressure": {
                "value": 1026
              },
              "cloudCover": {
                "value": 100,
                "high": 100,
                "middle": 69,
                "low": 98,
                "fog": 0
              },
              "humidity": {
                "value": 95.4
              },
              "dewPoint": {
                "value": 5.5
              },
              "start": "2025-03-02T07:00:00+01:00",
              "end": "2025-03-02T13:00:00+01:00",
              "nominalStart": "2025-03-02T06:00:00+01:00",
              "nominalEnd": "2025-03-02T12:00:00+01:00"
            },
            {
              "symbol": {
                "n": 4,
                "clouds": 3,
                "precip": 0,
                "sunup": false
              },
              "symbolCode": {
                "next6Hours": "cloudy",
                "next12Hours": "lightrain"
              },
              "precipitation": {
                "min": 0,
                "max": 0.8,
                "value": 0,
                "pop": 29,
                "probability": 29
              },
              "temperature": {
                "value": 8.8,
                "min": 7.3,
                "max": 8.8,
                "probability": {
                  "tenPercentile": 7.6,
                  "ninetyPercentile": 9.7
                }
              },
              "wind": {
                "direction": 191,
                "speed": 5.3,
                "probability": {
                  "tenPercentile": 3.7,
                  "ninetyPercentile": 8.6
                }
              },
              "feelsLike": {
                "value": 6
              },
              "pressure": {
                "value": 1025
              },
              "cloudCover": {
                "value": 100,
                "high": 100,
                "middle": 34,
                "low": 69,
                "fog": 0
              },
              "humidity": {
                "value": 90.9
              },
              "dewPoint": {
                "value": 7.3
              },
              "start": "2025-03-02T13:00:00+01:00",
              "end": "2025-03-02T19:00:00+01:00",
              "nominalStart": "2025-03-02T12:00:00+01:00",
              "nominalEnd": "2025-03-02T18:00:00+01:00"
            },
            {
              "symbol": {
                "n": 9,
                "clouds": 3,
                "precipPhase": "Rain",
                "precip": 2,
                "sunup": false
              },
              "symbolCode": {
                "next6Hours": "rain",
                "next12Hours": "rain"
              },
              "precipitation": {
                "min": 0,
                "max": 6.2,
                "value": 2.3,
                "pop": 51,
                "probability": 51
              },
              "temperature": {
                "value": 7.3,
                "min": 6.9,
                "max": 7.3,
                "probability": {
                  "tenPercentile": 6.8,
                  "ninetyPercentile": 7.8
                }
              },
              "wind": {
                "direction": 173,
                "speed": 5.3,
                "probability": {
                  "tenPercentile": 4.1,
                  "ninetyPercentile": 8.7
                }
              },
              "feelsLike": {
                "value": 4
              },
              "pressure": {
                "value": 1022
              },
              "cloudCover": {
                "value": 100,
                "high": 100,
                "middle": 88,
                "low": 98,
                "fog": 0
              },
              "humidity": {
                "value": 91.2
              },
              "dewPoint": {
                "value": 5.9
              },
              "start": "2025-03-02T19:00:00+01:00",
              "end": "2025-03-03T01:00:00+01:00",
              "nominalStart": "2025-03-02T18:00:00+01:00",
              "nominalEnd": "2025-03-03T00:00:00+01:00"
            },
            {
              "symbol": {
                "n": 10,
                "clouds": 3,
                "precipPhase": "Rain",
                "precip": 3,
                "sunup": false
              },
              "symbolCode": {
                "next6Hours": "heavyrain",
                "next12Hours": "heavyrain"
              },
              "precipitation": {
                "min": 0,
                "max": 13.3,
                "value": 5.7,
                "pop": 67,
                "probability": 67
              },
              "temperature": {
                "value": 7.1,
                "min": 7.1,
                "max": 7.2,
                "probability": {
                  "tenPercentile": 6.5,
                  "ninetyPercentile": 8.1
                }
              },
              "wind": {
                "direction": 168,
                "speed": 5.5,
                "probability": {
                  "tenPercentile": 4.5,
                  "ninetyPercentile": 8.8
                }
              },
              "feelsLike": {
                "value": 4
              },
              "pressure": {
                "value": 1019
              },
              "cloudCover": {
                "value": 100,
                "high": 100,
                "middle": 100,
                "low": 100,
                "fog": 0
              },
              "humidity": {
                "value": 96.2
              },
              "dewPoint": {
                "value": 6.5
              },
              "start": "2025-03-03T01:00:00+01:00",
              "end": "2025-03-03T07:00:00+01:00",
              "nominalStart": "2025-03-03T00:00:00+01:00",
              "nominalEnd": "2025-03-03T06:00:00+01:00"
            },
            {
              "symbol": {
                "n": 10,
                "clouds": 3,
                "precipPhase": "Rain",
                "precip": 3,
                "sunup": false
              },
              "symbolCode": {
                "next6Hours": "heavyrain",
                "next12Hours": "lightrain"
              },
              "precipitation": {
                "min": 0.6,
                "max": 15.9,
                "value": 6,
                "pop": 76,
                "probability": 76
              },
              "temperature": {
                "value": 7.2,
                "min": 7.2,
                "max": 8.3,
                "probability": {
                  "tenPercentile": 6.5,
                  "ninetyPercentile": 8.1
                }
              },
              "wind": {
                "direction": 167,
                "speed": 5.5,
                "probability": {
                  "tenPercentile": 3.9,
                  "ninetyPercentile": 9.1
                }
              },
              "feelsLike": {
                "value": 4
              },
              "pressure": {
                "value": 1015
              },
              "cloudCover": {
                "value": 100,
                "high": 100,
                "middle": 100,
                "low": 100,
                "fog": 0
              },
              "humidity": {
                "value": 97
              },
              "dewPoint": {
                "value": 6.8
              },
              "start": "2025-03-03T07:00:00+01:00",
              "end": "2025-03-03T13:00:00+01:00",
              "nominalStart": "2025-03-03T06:00:00+01:00",
              "nominalEnd": "2025-03-03T12:00:00+01:00"
            },
            {
              "symbol": {
                "n": 4,
                "clouds": 3,
                "precip": 0,
                "sunup": false
              },
              "symbolCode": {
                "next6Hours": "cloudy",
                "next12Hours": "lightrain"
              },
              "precipitation": {
                "min": 0,
                "max": 10.7,
                "value": 0,
                "pop": 61,
                "probability": 61
              },
              "temperature": {
                "value": 8.3,
                "min": 7.5,
                "max": 8.3,
                "probability": {
                  "tenPercentile": 7.4,
                  "ninetyPercentile": 9.9
                }
              },
              "wind": {
                "direction": 190,
                "speed": 5.5,
                "probability": {
                  "tenPercentile": 4.1,
                  "ninetyPercentile": 9.2
                }
              },
              "feelsLike": {
                "value": 5
              },
              "pressure": {
                "value": 1014
              },
              "cloudCover": {
                "value": 100,
                "high": 100,
                "middle": 100,
                "low": 100,
                "fog": 0
              },
              "humidity": {
                "value": 91.9
              },
              "dewPoint": {
                "value": 7.1
              },
              "start": "2025-03-03T13:00:00+01:00",
              "end": "2025-03-03T19:00:00+01:00",
              "nominalStart": "2025-03-03T12:00:00+01:00",
              "nominalEnd": "2025-03-03T18:00:00+01:00"
            },
            {
              "symbol": {
                "n": 9,
                "clouds": 3,
                "precipPhase": "Rain",
                "precip": 2,
                "sunup": false
              },
              "symbolCode": {
                "next6Hours": "rain",
                "next12Hours": "rain"
              },
              "precipitation": {
                "min": 0.3,
                "max": 10.5,
                "value": 4.4,
                "pop": 71,
                "probability": 71
              },
              "temperature": {
                "value": 7.5,
                "min": 6.8,
                "max": 7.5,
                "probability": {
                  "tenPercentile": 6.6,
                  "ninetyPercentile": 8.2
                }
              },
              "wind": {
                "direction": 196,
                "speed": 5.3,
                "probability": {
                  "tenPercentile": 4,
                  "ninetyPercentile": 9.1
                }
              },
              "feelsLike": {
                "value": 4
              },
              "pressure": {
                "value": 1012
              },
              "cloudCover": {
                "value": 100,
                "high": 100,
                "middle": 52,
                "low": 62,
                "fog": 0
              },
              "humidity": {
                "value": 94.7
              },
              "dewPoint": {
                "value": 6.6
              },
              "start": "2025-03-03T19:00:00+01:00",
              "end": "2025-03-04T01:00:00+01:00",
              "nominalStart": "2025-03-03T18:00:00+01:00",
              "nominalEnd": "2025-03-04T00:00:00+01:00"
            },
            {
              "symbol": {
                "n": 9,
                "clouds": 3,
                "precipPhase": "Rain",
                "precip": 2,
                "sunup": false
              },
              "symbolCode": {
                "next6Hours": "rain",
                "next12Hours": "rain"
              },
              "precipitation": {
                "min": 0.2,
                "max": 9.5,
                "value": 3.4,
                "pop": 71,
                "probability": 71
              },
              "temperature": {
                "value": 7.4,
                "min": 7.3,
                "max": 7.5,
                "probability": {
                  "tenPercentile": 6.6,
                  "ninetyPercentile": 8.7
                }
              },
              "wind": {
                "direction": 198,
                "speed": 6.5,
                "probability": {
                  "tenPercentile": 4.6,
                  "ninetyPercentile": 9.4
                }
              },
              "feelsLike": {
                "value": 4
              },
              "pressure": {
                "value": 1009
              },
              "cloudCover": {
                "value": 100,
                "high": 100,
                "middle": 100,
                "low": 85,
                "fog": 0
              },
              "humidity": {
                "value": 95
              },
              "dewPoint": {
                "value": 6.6
              },
              "start": "2025-03-04T01:00:00+01:00",
              "end": "2025-03-04T07:00:00+01:00",
              "nominalStart": "2025-03-04T00:00:00+01:00",
              "nominalEnd": "2025-03-04T06:00:00+01:00"
            },
            {
              "symbol": {
                "n": 9,
                "clouds": 3,
                "precipPhase": "Rain",
                "precip": 2,
                "sunup": false
              },
              "symbolCode": {
                "next6Hours": "rain",
                "next12Hours": "lightrain"
              },
              "precipitation": {
                "min": 0.3,
                "max": 11.5,
                "value": 3.8,
                "pop": 71,
                "probability": 71
              },
              "temperature": {
                "value": 7.5,
                "min": 7.5,
                "max": 8,
                "probability": {
                  "tenPercentile": 6.2,
                  "ninetyPercentile": 8.3
                }
              },
              "wind": {
                "direction": 201,
                "speed": 6.7,
                "probability": {
                  "tenPercentile": 4.4,
                  "ninetyPercentile": 9.4
                }
              },
              "feelsLike": {
                "value": 4
              },
              "pressure": {
                "value": 1006
              },
              "cloudCover": {
                "value": 100,
                "high": 100,
                "middle": 100,
                "low": 100,
                "fog": 0
              },
              "humidity": {
                "value": 95.6
              },
              "dewPoint": {
                "value": 6.8
              },
              "start": "2025-03-04T07:00:00+01:00",
              "end": "2025-03-04T13:00:00+01:00",
              "nominalStart": "2025-03-04T06:00:00+01:00",
              "nominalEnd": "2025-03-04T12:00:00+01:00"
            },
            {
              "symbol": {
                "n": 4,
                "clouds": 3,
                "precip": 0,
                "sunup": false
              },
              "symbolCode": {
                "next6Hours": "cloudy",
                "next12Hours": "rain"
              },
              "precipitation": {
                "min": 0,
                "max": 9.2,
                "value": 0,
                "pop": 65,
                "probability": 65
              },
              "temperature": {
                "value": 8,
                "min": 7.2,
                "max": 8,
                "probability": {
                  "tenPercentile": 6.6,
                  "ninetyPercentile": 9.4
                }
              },
              "wind": {
                "direction": 212,
                "speed": 6.7,
                "probability": {
                  "tenPercentile": 4.7,
                  "ninetyPercentile": 10.1
                }
              },
              "feelsLike": {
                "value": 4
              },
              "pressure": {
                "value": 1004
              },
              "cloudCover": {
                "value": 100,
                "high": 100,
                "middle": 100,
                "low": 100,
                "fog": 0
              },
              "humidity": {
                "value": 92.6
              },
              "dewPoint": {
                "value": 6.9
              },
              "start": "2025-03-04T13:00:00+01:00",
              "end": "2025-03-04T19:00:00+01:00",
              "nominalStart": "2025-03-04T12:00:00+01:00",
              "nominalEnd": "2025-03-04T18:00:00+01:00"
            },
            {
              "symbol": {
                "n": 10,
                "clouds": 3,
                "precipPhase": "Rain",
                "precip": 3,
                "sunup": false
              },
              "symbolCode": {
                "next6Hours": "heavyrain",
                "next12Hours": "lightrain"
              },
              "precipitation": {
                "min": 0.8,
                "max": 14.5,
                "value": 5,
                "pop": 78,
                "probability": 78
              },
              "temperature": {
                "value": 7.2,
                "min": 7.2,
                "max": 8.3,
                "probability": {
                  "tenPercentile": 5.3,
                  "ninetyPercentile": 9
                }
              },
              "wind": {
                "direction": 196,
                "speed": 6.3,
                "probability": {
                  "tenPercentile": 3.7,
                  "ninetyPercentile": 9.8
                }
              },
              "feelsLike": {
                "value": 4
              },
              "pressure": {
                "value": 1005
              },
              "cloudCover": {
                "value": 100,
                "high": 100,
                "middle": 100,
                "low": 100,
                "fog": 0
              },
              "humidity": {
                "value": 92.2
              },
              "dewPoint": {
                "value": 6
              },
              "start": "2025-03-04T19:00:00+01:00",
              "end": "2025-03-05T01:00:00+01:00",
              "nominalStart": "2025-03-04T18:00:00+01:00",
              "nominalEnd": "2025-03-05T00:00:00+01:00"
            },
            {
              "symbol": {
                "n": 4,
                "clouds": 3,
                "precip": 0,
                "sunup": false
              },
              "symbolCode": {
                "next6Hours": "cloudy",
                "next12Hours": "rain"
              },
              "precipitation": {
                "min": 0,
                "max": 2.7,
                "value": 0,
                "pop": 31,
                "probability": 31
              },
              "temperature": {
                "value": 8.3,
                "min": 6.4,
                "max": 8.3,
                "probability": {
                  "tenPercentile": 4.2,
                  "ninetyPercentile": 9.8
                }
              },
              "wind": {
                "direction": 240,
                "speed": 5.9,
                "probability": {
                  "tenPercentile": 2.1,
                  "ninetyPercentile": 8.7
                }
              },
              "feelsLike": {
                "value": 5
              },
              "pressure": {
                "value": 1003
              },
              "cloudCover": {
                "value": 100,
                "high": 100,
                "middle": 100,
                "low": 100,
                "fog": 0
              },
              "humidity": {
                "value": 93.5
              },
              "dewPoint": {
                "value": 7.2
              },
              "start": "2025-03-05T01:00:00+01:00",
              "end": "2025-03-05T07:00:00+01:00",
              "nominalStart": "2025-03-05T00:00:00+01:00",
              "nominalEnd": "2025-03-05T06:00:00+01:00"
            },
            {
              "symbol": {
                "n": 10,
                "clouds": 3,
                "precipPhase": "Rain",
                "precip": 3,
                "sunup": false
              },
              "symbolCode": {
                "next6Hours": "heavyrain",
                "next12Hours": "rain"
              },
              "precipitation": {
                "min": 0,
                "max": 19.1,
                "value": 6,
                "pop": 55,
                "probability": 55
              },
              "temperature": {
                "value": 6.6,
                "min": 6.6,
                "max": 9,
                "probability": {
                  "tenPercentile": 3.6,
                  "ninetyPercentile": 10
                }
              },
              "wind": {
                "direction": 165,
                "speed": 4.9,
                "probability": {
                  "tenPercentile": 1.5,
                  "ninetyPercentile": 8.7
                }
              },
              "feelsLike": {
                "value": 3
              },
              "pressure": {
                "value": 1003
              },
              "cloudCover": {
                "value": 100,
                "high": 100,
                "middle": 100,
                "low": 100,
                "fog": 0
              },
              "humidity": {
                "value": 93.9
              },
              "dewPoint": {
                "value": 5.6
              },
              "start": "2025-03-05T07:00:00+01:00",
              "end": "2025-03-05T13:00:00+01:00",
              "nominalStart": "2025-03-05T06:00:00+01:00",
              "nominalEnd": "2025-03-05T12:00:00+01:00"
            },
            {
              "symbol": {
                "n": 9,
                "clouds": 3,
                "precipPhase": "Rain",
                "precip": 2,
                "sunup": false
              },
              "symbolCode": {
                "next6Hours": "rain",
                "next12Hours": "rain"
              },
              "precipitation": {
                "min": 0,
                "max": 9.9,
                "value": 3.9,
                "pop": 51,
                "probability": 51
              },
              "temperature": {
                "value": 9,
                "min": 8.1,
                "max": 9,
                "probability": {
                  "tenPercentile": 5.4,
                  "ninetyPercentile": 10.6
                }
              },
              "wind": {
                "direction": 170,
                "speed": 5,
                "probability": {
                  "tenPercentile": 2.4,
                  "ninetyPercentile": 9.4
                }
              },
              "feelsLike": {
                "value": 6
              },
              "pressure": {
                "value": 1007
              },
              "cloudCover": {
                "value": 100,
                "high": 100,
                "middle": 100,
                "low": 100,
                "fog": 0
              },
              "humidity": {
                "value": 96.6
              },
              "dewPoint": {
                "value": 8.5
              },
              "start": "2025-03-05T13:00:00+01:00",
              "end": "2025-03-05T19:00:00+01:00",
              "nominalStart": "2025-03-05T12:00:00+01:00",
              "nominalEnd": "2025-03-05T18:00:00+01:00"
            },
            {
              "symbol": {
                "n": 9,
                "clouds": 3,
                "precipPhase": "Rain",
                "precip": 2,
                "sunup": false
              },
              "symbolCode": {
                "next6Hours": "rain",
                "next12Hours": "rain"
              },
              "precipitation": {
                "min": 0,
                "max": 10.5,
                "value": 3.9,
                "pop": 65,
                "probability": 65
              },
              "temperature": {
                "value": 8.1,
                "min": 7.8,
                "max": 9,
                "probability": {
                  "tenPercentile": 5.4,
                  "ninetyPercentile": 10.3
                }
              },
              "wind": {
                "direction": 169,
                "speed": 5.1,
                "probability": {
                  "tenPercentile": 2.5,
                  "ninetyPercentile": 8.9
                }
              },
              "feelsLike": {
                "value": 5
              },
              "pressure": {
                "value": 1007
              },
              "cloudCover": {
                "value": 100,
                "high": 100,
                "middle": 100,
                "low": 100,
                "fog": 0
              },
              "humidity": {
                "value": 96.6
              },
              "dewPoint": {
                "value": 7.6
              },
              "start": "2025-03-05T19:00:00+01:00",
              "end": "2025-03-06T01:00:00+01:00",
              "nominalStart": "2025-03-05T18:00:00+01:00",
              "nominalEnd": "2025-03-06T00:00:00+01:00"
            },
            {
              "symbol": {
                "n": 10,
                "clouds": 3,
                "precipPhase": "Rain",
                "precip": 3,
                "sunup": false
              },
              "symbolCode": {
                "next6Hours": "heavyrain",
                "next12Hours": "lightrain"
              },
              "precipitation": {
                "min": 0,
                "max": 8.5,
                "value": 5,
                "pop": 47,
                "probability": 47
              },
              "temperature": {
                "value": 9,
                "min": 8.5,
                "max": 9,
                "probability": {
                  "tenPercentile": 6,
                  "ninetyPercentile": 10.5
                }
              },
              "wind": {
                "direction": 167,
                "speed": 5.4,
                "probability": {
                  "tenPercentile": 3.1,
                  "ninetyPercentile": 8.5
                }
              },
              "feelsLike": {
                "value": 6
              },
              "pressure": {
                "value": 1007
              },
              "cloudCover": {
                "value": 100,
                "high": 100,
                "middle": 100,
                "low": 98,
                "fog": 0
              },
              "humidity": {
                "value": 95.3
              },
              "dewPoint": {
                "value": 8.3
              },
              "start": "2025-03-06T01:00:00+01:00",
              "end": "2025-03-06T07:00:00+01:00",
              "nominalStart": "2025-03-06T00:00:00+01:00",
              "nominalEnd": "2025-03-06T06:00:00+01:00"
            },
            {
              "symbol": {
                "n": 4,
                "clouds": 3,
                "precip": 0,
                "sunup": false
              },
              "symbolCode": {
                "next6Hours": "cloudy",
                "next12Hours": "cloudy"
              },
              "precipitation": {
                "min": 0,
                "max": 8.1,
                "value": 0,
                "pop": 45,
                "probability": 45
              },
              "temperature": {
                "value": 8.5,
                "min": 8.2,
                "max": 9.8,
                "probability": {
                  "tenPercentile": 6,
                  "ninetyPercentile": 10
                }
              },
              "wind": {
                "direction": 164,
                "speed": 5.3,
                "probability": {
                  "tenPercentile": 3.2,
                  "ninetyPercentile": 8.9
                }
              },
              "feelsLike": {
                "value": 6
              },
              "pressure": {
                "value": 1008
              },
              "cloudCover": {
                "value": 100,
                "high": 100,
                "middle": 100,
                "low": 100,
                "fog": 0
              },
              "humidity": {
                "value": 95.3
              },
              "dewPoint": {
                "value": 7.8
              },
              "start": "2025-03-06T07:00:00+01:00",
              "end": "2025-03-06T13:00:00+01:00",
              "nominalStart": "2025-03-06T06:00:00+01:00",
              "nominalEnd": "2025-03-06T12:00:00+01:00"
            },
            {
              "symbol": {
                "n": 4,
                "clouds": 3,
                "precip": 0,
                "sunup": false
              },
              "symbolCode": {
                "next6Hours": "cloudy",
                "next12Hours": "lightrain"
              },
              "precipitation": {
                "min": 0,
                "max": 1.7,
                "value": 0,
                "pop": 39,
                "probability": 39
              },
              "temperature": {
                "value": 9.8,
                "min": 8.1,
                "max": 9.8,
                "probability": {
                  "tenPercentile": 7.6,
                  "ninetyPercentile": 12
                }
              },
              "wind": {
                "direction": 202,
                "speed": 5.8,
                "probability": {
                  "tenPercentile": 3.5,
                  "ninetyPercentile": 10.3
                }
              },
              "feelsLike": {
                "value": 7
              },
              "pressure": {
                "value": 1009
              },
              "cloudCover": {
                "value": 100,
                "high": 24,
                "middle": 98,
                "low": 100,
                "fog": 0
              },
              "humidity": {
                "value": 86.4
              },
              "dewPoint": {
                "value": 7.6
              },
              "start": "2025-03-06T13:00:00+01:00",
              "end": "2025-03-06T19:00:00+01:00",
              "nominalStart": "2025-03-06T12:00:00+01:00",
              "nominalEnd": "2025-03-06T18:00:00+01:00"
            },
            {
              "symbol": {
                "n": 9,
                "clouds": 3,
                "precipPhase": "Rain",
                "precip": 2,
                "sunup": false
              },
              "symbolCode": {
                "next6Hours": "rain",
                "next12Hours": "rain"
              },
              "precipitation": {
                "min": 0,
                "max": 5.5,
                "value": 3.1,
                "pop": 49,
                "probability": 49
              },
              "temperature": {
                "value": 8.1,
                "min": 7.3,
                "max": 8.1,
                "probability": {
                  "tenPercentile": 6.4,
                  "ninetyPercentile": 9.3
                }
              },
              "wind": {
                "direction": 167,
                "speed": 4.8,
                "probability": {
                  "tenPercentile": 3.1,
                  "ninetyPercentile": 8
                }
              },
              "feelsLike": {
                "value": 5
              },
              "pressure": {
                "value": 1008
              },
              "cloudCover": {
                "value": 100,
                "high": 100,
                "middle": 99,
                "low": 100,
                "fog": 0
              },
              "humidity": {
                "value": 90.4
              },
              "dewPoint": {
                "value": 6.6
              },
              "start": "2025-03-06T19:00:00+01:00",
              "end": "2025-03-07T01:00:00+01:00",
              "nominalStart": "2025-03-06T18:00:00+01:00",
              "nominalEnd": "2025-03-07T00:00:00+01:00"
            },
            {
              "symbol": {
                "n": 9,
                "clouds": 3,
                "precipPhase": "Rain",
                "precip": 2,
                "sunup": false
              },
              "symbolCode": {
                "next6Hours": "rain",
                "next12Hours": "lightrain"
              },
              "precipitation": {
                "min": 0,
                "max": 7,
                "value": 3.7,
                "pop": 51,
                "probability": 51
              },
              "temperature": {
                "value": 7.7,
                "min": 6.8,
                "max": 7.7,
                "probability": {
                  "tenPercentile": 5,
                  "ninetyPercentile": 8.7
                }
              },
              "wind": {
                "direction": 164,
                "speed": 5,
                "probability": {
                  "tenPercentile": 3.1,
                  "ninetyPercentile": 8.1
                }
              },
              "feelsLike": {
                "value": 5
              },
              "pressure": {
                "value": 1008
              },
              "cloudCover": {
                "value": 100,
                "high": 99,
                "middle": 100,
                "low": 100,
                "fog": 0
              },
              "humidity": {
                "value": 93.1
              },
              "dewPoint": {
                "value": 6.6
              },
              "start": "2025-03-07T01:00:00+01:00",
              "end": "2025-03-07T07:00:00+01:00",
              "nominalStart": "2025-03-07T00:00:00+01:00",
              "nominalEnd": "2025-03-07T06:00:00+01:00"
            },
            {
              "symbol": {
                "n": 4,
                "clouds": 3,
                "precip": 0,
                "sunup": false
              },
              "symbolCode": {
                "next6Hours": "cloudy",
                "next12Hours": "cloudy"
              },
              "precipitation": {
                "min": 0,
                "max": 7.6,
                "value": 0,
                "pop": 41,
                "probability": 41
              },
              "temperature": {
                "value": 7.2,
                "min": 7,
                "max": 8.7,
                "probability": {
                  "tenPercentile": 4.5,
                  "ninetyPercentile": 8.5
                }
              },
              "wind": {
                "direction": 163,
                "speed": 4.9,
                "probability": {
                  "tenPercentile": 3.2,
                  "ninetyPercentile": 8.1
                }
              },
              "feelsLike": {
                "value": 4
              },
              "pressure": {
                "value": 1007
              },
              "cloudCover": {
                "value": 100,
                "high": 100,
                "middle": 72,
                "low": 100,
                "fog": 0
              },
              "humidity": {
                "value": 95.4
              },
              "dewPoint": {
                "value": 6.5
              },
              "start": "2025-03-07T07:00:00+01:00",
              "end": "2025-03-07T13:00:00+01:00",
              "nominalStart": "2025-03-07T06:00:00+01:00",
              "nominalEnd": "2025-03-07T12:00:00+01:00"
            },
            {
              "symbol": {
                "n": 4,
                "clouds": 3,
                "precip": 0,
                "sunup": false
              },
              "symbolCode": {
                "next6Hours": "cloudy",
                "next12Hours": "lightrain"
              },
              "precipitation": {
                "min": 0,
                "max": 1.6,
                "value": 0,
                "pop": 35,
                "probability": 35
              },
              "temperature": {
                "value": 8.7,
                "min": 7.4,
                "max": 8.7,
                "probability": {
                  "tenPercentile": 6.8,
                  "ninetyPercentile": 11.4
                }
              },
              "wind": {
                "direction": 174,
                "speed": 5.3,
                "probability": {
                  "tenPercentile": 3.2,
                  "ninetyPercentile": 8.7
                }
              },
              "feelsLike": {
                "value": 6
              },
              "pressure": {
                "value": 1007
              },
              "cloudCover": {
                "value": 100,
                "high": 100,
                "middle": 100,
                "low": 100,
                "fog": 0
              },
              "humidity": {
                "value": 84.8
              },
              "dewPoint": {
                "value": 6.3
              },
              "start": "2025-03-07T13:00:00+01:00",
              "end": "2025-03-07T19:00:00+01:00",
              "nominalStart": "2025-03-07T12:00:00+01:00",
              "nominalEnd": "2025-03-07T18:00:00+01:00"
            },
            {
              "symbol": {
                "n": 9,
                "clouds": 3,
                "precipPhase": "Rain",
                "precip": 2,
                "sunup": false
              },
              "symbolCode": {
                "next6Hours": "rain",
                "next12Hours": "rain"
              },
              "precipitation": {
                "min": 0,
                "max": 6.6,
                "value": 3.5,
                "pop": 53,
                "probability": 53
              },
              "temperature": {
                "value": 7.4,
                "min": 6.8,
                "max": 7.4,
                "probability": {
                  "tenPercentile": 5.9,
                  "ninetyPercentile": 9.6
                }
              },
              "wind": {
                "direction": 168,
                "speed": 4.7,
                "probability": {
                  "tenPercentile": 1.5,
                  "ninetyPercentile": 7.7
                }
              },
              "feelsLike": {
                "value": 4
              },
              "pressure": {
                "value": 1009
              },
              "cloudCover": {
                "value": 100,
                "high": 100,
                "middle": 100,
                "low": 100,
                "fog": 0
              },
              "humidity": {
                "value": 92.4
              },
              "dewPoint": {
                "value": 6.2
              },
              "start": "2025-03-07T19:00:00+01:00",
              "end": "2025-03-08T01:00:00+01:00",
              "nominalStart": "2025-03-07T18:00:00+01:00",
              "nominalEnd": "2025-03-08T00:00:00+01:00"
            },
            {
              "symbol": {
                "n": 9,
                "clouds": 3,
                "precipPhase": "Rain",
                "precip": 2,
                "sunup": false
              },
              "symbolCode": {
                "next6Hours": "rain",
                "next12Hours": "lightrain"
              },
              "precipitation": {
                "min": 0,
                "max": 6,
                "value": 3.6,
                "pop": 49,
                "probability": 49
              },
              "temperature": {
                "value": 7.3,
                "min": 6.4,
                "max": 7.3,
                "probability": {
                  "tenPercentile": 4.9,
                  "ninetyPercentile": 9
                }
              },
              "wind": {
                "direction": 162,
                "speed": 4.7,
                "probability": {
                  "tenPercentile": 1.9,
                  "ninetyPercentile": 6.3
                }
              },
              "feelsLike": {
                "value": 4
              },
              "pressure": {
                "value": 1008
              },
              "cloudCover": {
                "value": 100,
                "high": 98,
                "middle": 99,
                "low": 100,
                "fog": 0
              },
              "humidity": {
                "value": 94.9
              },
              "dewPoint": {
                "value": 6.5
              },
              "start": "2025-03-08T01:00:00+01:00",
              "end": "2025-03-08T07:00:00+01:00",
              "nominalStart": "2025-03-08T00:00:00+01:00",
              "nominalEnd": "2025-03-08T06:00:00+01:00"
            },
            {
              "symbol": {
                "n": 4,
                "clouds": 3,
                "precip": 0,
                "sunup": false
              },
              "symbolCode": {
                "next6Hours": "cloudy"
              },
              "precipitation": {
                "min": 0,
                "max": 1.4,
                "value": 0,
                "pop": 33,
                "probability": 33
              },
              "temperature": {
                "value": 6.6,
                "min": 6.5,
                "max": 8.6,
                "probability": {
                  "tenPercentile": 3.5,
                  "ninetyPercentile": 8.7
                }
              },
              "wind": {
                "direction": 157,
                "speed": 3.6,
                "probability": {
                  "tenPercentile": 1.5,
                  "ninetyPercentile": 5.9
                }
              },
              "feelsLike": {
                "value": 4
              },
              "pressure": {
                "value": 1011
              },
              "cloudCover": {
                "value": 100,
                "high": 99,
                "middle": 31,
                "low": 99,
                "fog": 0
              },
              "humidity": {
                "value": 93.3
              },
              "dewPoint": {
                "value": 5.6
              },
              "start": "2025-03-08T07:00:00+01:00",
              "end": "2025-03-08T13:00:00+01:00",
              "nominalStart": "2025-03-08T06:00:00+01:00",
              "nominalEnd": "2025-03-08T12:00:00+01:00"
            }
          ],
          "status": {
            "code": "Ok"
          },
          "_links": {
            "self": {
              "href": "/api/v0/locations/1-92416/forecast"
            },
            "parent": {
              "href": "/api/v0/locations/1-92416"
            }
          }
        }
        """;

    private static Forecast Forecast { get => JsonSerializer.Deserialize<Forecast>(Data) ?? throw new Exception(); }

    [Test]
    public async Task CanFetch()
    {
        using var httpTest = new HttpTest();

        httpTest.RespondWithJson(Forecast);

        var options = new YrOptions()
        {
            ProgramInfo = new()
            {
                Name = "test",
                Version = "0.0.0",
                ContactPoint = "admin@example.com",
            }
        };

        var location = new LocationID()
        {
            ID = "1-92416"
        };

        var forecast = await location.GetAsync<Forecast>(options);

        httpTest.ShouldHaveCalled("https://www.yr.no/api/v0/locations/1-92416/forecast").Times(1);

        Assert.Multiple(() =>
        {
            Assert.That(forecast.Created, Is.EqualTo(new DateTimeOffset(2025, 02, 26, 13, 27, 46, new TimeSpan(1, 0, 0))));
            Assert.That(forecast.Update, Is.EqualTo(new DateTimeOffset(2025, 02, 26, 14, 27, 46, new TimeSpan(1, 0, 0))));
        });
    }
}
