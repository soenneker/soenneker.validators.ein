using Soenneker.Validators.Validator.Abstract;

namespace Soenneker.Validators.Ein.Abstract;

/// <summary>
/// A validation module checking the syntax of Employer identification numbers (EINs)
/// </summary>
public interface IEinValidator : IValidator
{
    /// <summary>
    /// Validates whether the given EIN (Employer Identification Number) string is correctly formatted
    /// and contains a valid IRS-issued prefix. Supports both formats: "XXXXXXXXX" and "XX-XXXXXXX".
    /// </summary>
    /// <param name="ein">
    /// The EIN string to validate. Can be null or whitespace, in which case the result is <c>false</c>.
    /// </param>
    /// <returns><see langword="true"/> if the EIN has an accepted format and prefix; otherwise, <see langword="false"/>.</returns>
    bool Validate(string? ein);
}
