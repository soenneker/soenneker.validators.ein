using AwesomeAssertions;
using Soenneker.Tests.HostedUnit;
using Soenneker.Validators.Ein.Abstract;

namespace Soenneker.Validators.Ein.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public class EinValidatorTests : HostedUnitTest
{
    private readonly IEinValidator _validator;

    public EinValidatorTests(Host host) : base(host)
    {
        _validator = Resolve<IEinValidator>(true);
    }

    [Test]
    public void Default()
    {

    }

    [Test]
    [Arguments("12-3456789")]
    [Arguments("203456789")]
    [Arguments("88-7654321")]
    [Arguments("999999999")] // valid prefix, no dash
    public void Validate_ValidEinFormats_ShouldReturnTrue(string ein)
    {
        bool? result = _validator.Validate(ein);
        result.Should().BeTrue();
    }

    [Test]
    [Arguments("00-1234567")]  // invalid prefix
    [Arguments("07-1234567")]  // invalid prefix
    [Arguments("15-1234567")]  // invalid prefix
    [Arguments("12345678")]    // too short
    [Arguments("1234567890")]  // too long
    [Arguments("12-34A6789")]  // non-digit
    [Arguments("12-345678")]   // too short after dash
    [Arguments("12_3456789")]  // invalid separator
    [Arguments("abcdefghj")]   // all non-digits
    public void Validate_InvalidEinFormats_ShouldReturnFalse(string ein)
    {
        bool? result = _validator.Validate(ein);
        result.Should().BeFalse();
    }

    [Test]
    [Arguments(null)]
    [Arguments("")]
    [Arguments("   ")]
    public void Validate_NullOrWhitespace_ShouldReturnFalse(string? ein)
    {
        bool? result = _validator.Validate(ein!);
        result.Should().BeFalse();
    }

    [Test]
    public void Validate_ValidEinWithDash_BoundaryPrefix_ShouldReturnTrue()
    {
        bool? result = _validator.Validate("01-0000000"); // smallest valid prefix
        result.Should().BeTrue();
    }

    [Test]
    public void Validate_ValidEinWithoutDash_MaxPrefix_ShouldReturnTrue()
    {
        bool? result = _validator.Validate("999999999"); // highest valid prefix
        result.Should().BeTrue();
    }
}

