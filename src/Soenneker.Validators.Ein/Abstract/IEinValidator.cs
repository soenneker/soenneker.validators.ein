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
    /// <returns>
    /// <c>true</c> if the EIN is properly formatted and has a valid prefix; 
    /// <c>false</c> if the format or content is invalid;
    /// <c>null</c> is not returned in this implementation, though the return type allows it.
    /// </returns>
    bool Validate(string ein);
}
