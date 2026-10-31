using CarePulse360.Domain.Exceptions;
using CarePulse360.Domain.ValueObjects;

namespace CarePulse360.Domain.Entities;

public class Doctor
{
    public Guid Id { get; private set; }
    public string FirstName { get; private set; } = null!;
    public string LastName1 { get; private set; } = null!;
    public string? LastName2 { get; private set; } = null!;
    public Email Email { get; private set; } = null!;

    public Doctor(string firstName, string lastName1, string? lastName2, Email email)
    {
        ValidateInputParameters(firstName, lastName1, email);

        Id = Guid.CreateVersion7();
        FirstName = firstName;
        LastName1 = lastName1;
        LastName2 = lastName2;
        Email = email;
    }

    public void UpdateFirstName(string firstName)
    {
        EnforceBusinessRulesFirstName(firstName);
        FirstName = firstName;
    }

    public void UpdateLastName1(string lastName1)
    {
        EnforceBusinessRulesLastName1(lastName1);
        LastName1 = lastName1;
    }

    public void UpdateLastName2(string lastName2)
    {
        LastName2 = lastName2;
    }

    public void UpdateEmail(Email email)
    {
        EnforceBusinessRulesEmail(email);
        Email = email;
    }

    private void EnforceBusinessRulesFirstName(string firstName)
    {
        if (string.IsNullOrWhiteSpace(firstName))
        {
            throw new BusinessRuleException($"The field {nameof(firstName)} is required.");
        }
    }

    private void EnforceBusinessRulesLastName1(string lastName1)
    {
        if (string.IsNullOrWhiteSpace(lastName1))
        {
            throw new BusinessRuleException($"The field {nameof(lastName1)} is required.");
        }
    }

    private void EnforceBusinessRulesEmail(Email email)
    {
        if (email is null)
        {
            throw new BusinessRuleException($"The field {nameof(Email)} is required.");
        }
    }

    private void ValidateInputParameters(string firstName, string lastName1, Email email)
    {
        EnforceBusinessRulesFirstName(firstName);
        EnforceBusinessRulesLastName1(lastName1);
        EnforceBusinessRulesEmail(email);
    }
}
