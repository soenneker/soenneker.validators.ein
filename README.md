[![](https://img.shields.io/nuget/v/soenneker.validators.ein.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.validators.ein/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.validators.ein/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.validators.ein/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.validators.ein.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.validators.ein/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.validators.ein/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.validators.ein/actions/workflows/codeql.yml)

# Soenneker.Validators.Ein

Validates US Employer Identification Number formatting and a built-in allowlist of EIN prefixes.

## Install

```bash
dotnet add package Soenneker.Validators.Ein
```

## Registration

```csharp
using Soenneker.Validators.Ein.Registrars;
using Microsoft.Extensions.DependencyInjection;

services.AddEinValidatorAsSingleton();
```

The validator is stateless. Singleton registration is suitable for most applications; `AddEinValidatorAsScoped()` is also available.

## Usage

```csharp
using Soenneker.Validators.Ein.Abstract;

bool compactIsValid = validator.Validate("123456789");
bool formattedIsValid = validator.Validate("12-3456789");
```

Accepted input has one of two exact shapes:

- nine ASCII digits: `XXXXXXXXX`
- two ASCII digits, a hyphen, and seven ASCII digits: `XX-XXXXXXX`

The first two digits must be present in the validator's compiled EIN prefix allowlist. Input is not trimmed or normalized; spaces, alternate separators, and surrounding text return `false`. Null, empty, or whitespace-only input also returns `false`.

## What validation does not establish

A `true` result does not prove that the IRS issued the EIN, that it belongs to a particular organization, or that it remains active. The validator performs no network lookup and has no ownership or identity verification. Prefix allocations can change independently of the package, so treat this as an input-shape check rather than authoritative tax-identity validation.
