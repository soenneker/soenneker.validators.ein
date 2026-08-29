[![](https://img.shields.io/nuget/v/soenneker.validators.ein.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.validators.ein/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.validators.ein/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.validators.ein/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.validators.ein.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.validators.ein/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.validators.ein/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.validators.ein/actions/workflows/codeql.yml)

# Soenneker.Validators.Ein

A validation module checking the syntax of Employer identification numbers (EINs).

## Install

```bash
dotnet add package Soenneker.Validators.Ein
```

## Quick start

```csharp
using Soenneker.Validators.Ein.Registrars;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
var result = services.AddEinValidatorAsSingleton();
```

Adds `IEinValidator` as a singleton service.

## What you get

- `IEinValidator` — A validation module checking the syntax of Employer identification numbers (EINs).
- `EinValidatorRegistrar` — A validation module checking the syntax of Employer identification numbers (EINs).

## API at a glance

| API | What it does | Result / important behavior |
| --- | --- | --- |
| `IEinValidator.Validate(ein)` | Validates whether the given EIN (Employer Identification Number) string is correctly formatted and contains a valid IRS-issued prefix. Supports both formats: "XXXXXXXXX" and "XX-XXXXXXX". | `true` if the EIN is properly formatted and has a valid prefix; `false` if the format or content is invalid; `null` is not returned in this implementation, though the return type allows it. |
| `EinValidatorRegistrar.AddEinValidatorAsSingleton(services)` | Adds `IEinValidator` as a singleton service. | The same service collection, so additional registrations can be chained. |
| `EinValidatorRegistrar.AddEinValidatorAsScoped(services)` | Adds `IEinValidator` as a scoped service. | The same service collection, so additional registrations can be chained. |
