using Microsoft.Extensions.Logging;
using Soenneker.Validators.Ein.Abstract;
using Soenneker.Extensions.Char;
using Soenneker.Extensions.String;

namespace Soenneker.Validators.Ein;

/// <inheritdoc cref="IEinValidator"/>
public class EinValidator : Validator.Validator, IEinValidator
{
    public EinValidator(ILogger<EinValidator> logger) : base(logger)
    {
    }

    public bool Validate(string? ein)
    {
        if (ein.IsNullOrWhiteSpace())
            return false;

        int len = ein.Length;

        if (len == 9)
        {
            for (var i = 0; i < 9; i++)
            {
                if (!ein[i].IsDigit())
                    return false;
            }

            int prefix = (ein[0] - '0') * 10 + (ein[1] - '0');
            return IsValidPrefix(prefix);
        }

        if (len == 10 && ein[2] == '-')
        {
            for (var i = 0; i < 10; i++)
            {
                if (i == 2)
                    continue;

                if (!ein[i].IsDigit())
                    return false;
            }

            int prefix = (ein[0] - '0') * 10 + (ein[1] - '0');
            return IsValidPrefix(prefix);
        }

        return false;
    }

    private static bool IsValidPrefix(int prefix)
    {
        return prefix switch
        {
            1 or 2 or 3 or 4 or 5 or 6 or 10 or 11 or 12 or 20 or 21 or 22 or 23 or 24 or 25 or 26 or 27 or 30 or 31 or 32 or 33 or 34 or 36 or 37 or 38 or 39
                or 40 or 41 or 42 or 43 or 44 or 45 or 46 or 47 or 48 or 49 or 50 or 51 or 52 or 53 or 54 or 55 or 56 or 57 or 58 or 59 or 60 or 61 or 62 or 63
                or 64 or 65 or 70 or 71 or 72 or 73 or 80 or 81 or 82 or 83 or 84 or 85 or 86 or 87 or 88 or 90 or 91 or 92 or 93 or 94 or 95 or 96 or 97 or 98
                or 99 => true,
            _ => false
        };
    }
}