using CarePulse360.Domain.Exceptions;
using CarePulse360.Domain.ValueObjects;

namespace CarePulse360.Tests.Domain.ValueObjects;

public class EmailTests
{
    [Fact]
    public void Constructor_EmailIsNullOrEmpty_ThrowsBusinessRuleException()
    {
        // Arrange
        string emailNull = null!;

        //Act & Assert
        var exception = Assert.Throws<BusinessRuleException>(() => new Email(emailNull));

        Assert.Equal("Email cannot be empty.", exception.Message);
    }

    [Fact]
    public void Constructor_EmailWithInvalidFormat_ThrowsBusinessRuleException()
    {
        // Arrange
        string emailInvalid = "invalid-email";

        //Act & Assert
        var exception = Assert.Throws<BusinessRuleException>(() => new Email(emailInvalid));

        Assert.Equal("Invalid email format.", exception.Message);
    }
}
