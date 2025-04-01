using FluentAssertions;
using Soenneker.Tests.FixturedUnit;
using Soenneker.Validators.Ein.Abstract;
using Xunit;

namespace Soenneker.Validators.Ein.Tests;

[Collection("Collection")]
public class EinValidatorTests : FixturedUnitTest
{
    private readonly IEinValidator _validator;

    public EinValidatorTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
        _validator = Resolve<IEinValidator>(true);
    }

    [Fact]
    public void Default()
    {

    }

    [Theory]
    [InlineData("12-3456789")]
    [InlineData("203456789")]
    [InlineData("88-7654321")]
    [InlineData("999999999")] // valid prefix, no dash
    public void Validate_ValidEinFormats_ShouldReturnTrue(string ein)
    {
        bool? result = _validator.Validate(ein);
        result.Should().BeTrue();
    }

    [Theory]
    [InlineData("00-1234567")]  // invalid prefix
    [InlineData("07-1234567")]  // invalid prefix
    [InlineData("15-1234567")]  // invalid prefix
    [InlineData("12345678")]    // too short
    [InlineData("1234567890")]  // too long
    [InlineData("12-34A6789")]  // non-digit
    [InlineData("12-345678")]   // too short after dash
    [InlineData("12_3456789")]  // invalid separator
    [InlineData("abcdefghj")]   // all non-digits
    public void Validate_InvalidEinFormats_ShouldReturnFalse(string ein)
    {
        bool? result = _validator.Validate(ein);
        result.Should().BeFalse();
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public void Validate_NullOrWhitespace_ShouldReturnFalse(string? ein)
    {
        bool? result = _validator.Validate(ein!);
        result.Should().BeFalse();
    }

    [Fact]
    public void Validate_ValidEinWithDash_BoundaryPrefix_ShouldReturnTrue()
    {
        bool? result = _validator.Validate("01-0000000"); // smallest valid prefix
        result.Should().BeTrue();
    }

    [Fact]
    public void Validate_ValidEinWithoutDash_MaxPrefix_ShouldReturnTrue()
    {
        bool? result = _validator.Validate("999999999"); // highest valid prefix
        result.Should().BeTrue();
    }
}
