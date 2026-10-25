using CarePulse360.Domain.Exceptions;
using System.Text.RegularExpressions;

namespace CarePulse360.Domain.ValueObjects;

public record class Email
{
    public string Value { get; private set; } = null!;

    private static readonly Regex EmailRegex = new(
        @"^[a-zA-Z0-9._%+\-]+@[a-zA-Z0-9](?:[a-zA-Z0-9\-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9\-]{0,61}[a-zA-Z0-9])?)*\.[a-zA-Z]{2,}$",
        RegexOptions.Compiled | RegexOptions.CultureInvariant);

    public Email(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new BusinessRuleException("Email cannot be empty.");

        if (!EmailRegex.IsMatch(value))
            throw new BusinessRuleException("Invalid email format.");

    }
}
