# Rest.GetChangeio
This is an unofficial .NET (standard) library for [GetChangeio](https://docs.getchange.io/getting-started/) REST APIs.

[![.NET](https://github.com/diegostamigni/Rest.GetChangeio/actions/workflows/dotnet.yml/badge.svg)](https://github.com/diegostamigni/Rest.GetChangeio/actions/workflows/dotnet.yml)

## Description
All APIs are grouped in services:
 * Donation service
 * Nonprofits service
 * ...

All concrete classes respect a contract (ex. `DonationService` -> `IDonationService`) making things easier for testing/mocking and people that wants to use dependency injection. All services need at least the `IGetChangeioConfig` which exposes the following properties:
 * GetChangeioPublicKey
 * GetChangeioPrivateKey

Because this config is strictly dependant on your project, you are supposed to inherit from this contract and provide an implementation upon service construction.


### Examples

#### Create donation
```csharp
var config = MyConfig(); // inherits from `IGetChangeioConfig`
var donationService = new DonationService(config);
var result = await donationService.CreateAsync(new("n_IfEoPCaPqVsFAUI5xl0CBUOx", 1000));
...
```

#### Search non-profits
```csharp
var config = MyConfig(); // inherits from `IGetChangeioConfig`
var nonprofitsService = new NonprofitsService(config);
var result = await nonprofitsService.SearchAsync("fcancer"); // supports pagination via the `page` property
...
```

### Supported APIs
* Donation
    - [x] Create a donation
    - [x] List your donations
    - [x] Retrieve a donation
    - [ ] Retrieve carbon offset stats
* Nonprofits
    - [x] Show a nonprofit
    - [x] Search a nonprofit
    - [ ] Get social media content
* Climate
    - [ ] Draft a shipping carbon offset
    - [ ] Crate a shipping carbon offset
    - [ ] Draft a crypto carbon offset
    - [ ] Create a crypto carbon offset
    - [ ] Retrieve carbon offset stats

Feel free to contribute! Support for missing APIs and tests are underway.
