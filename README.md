# Object-Oriented Programming — C# Coursework

A collection of C#/.NET assignments built around a weather forecasting domain. The exercises progress from basic object-oriented modeling to collections, interfaces, repositories, and a desktop user interface.

## Technologies

- C#, .NET Core 3.1 (the original target framework)
- Object-oriented design, classes and properties, interfaces, and collections
- Windows Presentation Foundation (WPF) for the final desktop application
- Newtonsoft.Json and the OpenWeatherMap API in the WPF assignment

## Projects

| Folder | Focus | What it contains |
| --- | --- | --- |
| [`DZ1/`](DZ1/) | Classes and methods | A `Weather` class, calculated apparent temperature/wind chill, and a console demonstration. |
| [`DZ2/`](DZ2/) | Forecast objects and parsing | `DailyForecast`, `WeeklyForecast`, parsing a weekly forecast from a text file, and an indexer. |
| [`DZ3/`](DZ3/) | Abstraction and interfaces | Weather generators, a weekly forecast, and console/file printer implementations. |
| [`DZ4/`](DZ4/) | Collections and repositories | A daily forecast repository, custom exception handling, iteration, and copying repository data. |
| [`DZ5/`](DZ5/) | Desktop application | A WPF weather interface, city lookup, JSON parsing, weather icons, and API-based forecasts. |

Each folder is an **independent Visual Studio solution**. These are successive coursework exercises, not a single unified application.

## Running the console projects

The first four projects target **.NET Core 3.1**, which is out of support. Use a compatible development environment, or migrate the project files before using a current SDK.

For example, from the repository root:

```bash
dotnet run --project DZ1/UI/UI.csproj
```

Other exercises can be run similarly by replacing `DZ1` with `DZ2`, `DZ3`, or `DZ4`, subject to their required inputs. **DZ2 expects a `weather.forecast` input file**, which is not supplied in this repository.

## WPF application (DZ5)

- Requires **Windows** and a development environment supporting the original WPF target.
- Open `DZ5/DZ5.sln` in Visual Studio.
- The source contains an **OpenWeatherMap API-key placeholder** in `DZ5/UI/MainWindow.xaml.cs`; supply your own key to use API features.
- The app reads `city.list.json` from the working directory, so the file must be accessible at runtime.
- Its API requests target historical OpenWeatherMap endpoints. Some endpoints or subscriptions may have changed, so live forecasts are **not verified** with current API plans.

## Repository layout

```text
DZ1/  C# weather model and console application
DZ2/  Daily/weekly forecasts and file parsing
DZ3/  Generators, abstractions, and output methods
DZ4/  Forecast repository and error handling
DZ5/  WPF weather application and resources
LICENSE
```

## Scope and limitations

This is an **academic coursework archive**, not a supported or production-ready weather service. The solutions have not been modernized to current .NET versions. Original assignment algorithms are retained to reflect the work as submitted.

## License

See [LICENSE](LICENSE). The license notice originating with the coursework template has been preserved.
