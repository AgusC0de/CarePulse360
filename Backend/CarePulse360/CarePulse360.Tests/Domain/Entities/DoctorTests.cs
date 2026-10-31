using CarePulse360.Domain.Entities;
using CarePulse360.Domain.Exceptions;
using CarePulse360.Domain.ValueObjects;

namespace CarePulse360.Tests.Domain.Entities;

public class DoctorTests
{
    [Fact]
    public void Constructor_FirstNameIsNullOrEmpty_ThrowsBusinessRuleException()
    {
        // Arrange
        string firstName = null!;
        string lastName1 = null!;
        string? lastName2 = null;
        Email email = null!;

        //Act & Assert
        var exception = Assert.Throws<BusinessRuleException>(() => new Patient(firstName, lastName1, lastName2, email));
    }

    [Fact]
    public void Constructor_LastName1IsNullOrEmpty_ThrowsBusinessRuleException()
    {
        // Arrange
        string firstName = "John";
        string lastName1 = null!;
        string? lastName2 = null;
        Email email = null!;

        //Act & Assert
        var exception = Assert.Throws<BusinessRuleException>(() => new Patient(firstName, lastName1, lastName2, email));
    }

    [Fact]
    public void Constructor_EmailIsNullOrEmpty_ThrowsBusinessRuleException()
    {
        // Arrange
        string firstName = "John";
        string lastName1 = "Doe";
        string? lastName2 = null;
        Email email = null!;

        //Act & Assert
        var exception = Assert.Throws<BusinessRuleException>(() => new Patient(firstName, lastName1, lastName2, email));
    }

    [Fact]
    public void Constructor_DataIsValid_CreatesPatientInstance()
    {
        // Arrange
        string firstName = "John";
        string lastName1 = "Doe";
        string? lastName2 = null;
        Email email = new Email("john.doe@example.com");

        //Act
        var patient = new Patient(firstName, lastName1, lastName2, email);

        //Assert
        Assert.NotNull(patient);
        Assert.Equal(firstName, patient.FirstName);
    }

    [Fact]
    public void UpdateFirstName()
    {
        // Arrange
        string firstName = "John";
        string lastName1 = "Doe";
        string? lastName2 = null;
        Email email = new Email("john.doe@example.com");

        string updatedFirstName = "Jane";

        //Act
        var patient = new Patient(firstName, lastName1, lastName2, email);
        patient.UpdateFirstName(updatedFirstName);

        //Assert
        Assert.NotNull(patient);
        Assert.Equal(updatedFirstName, patient.FirstName);
    }

    [Fact]
    public void UpdateLastName1()
    {
        // Arrange
        string firstName = "John";
        string lastName1 = "Doe";
        string? lastName2 = null;
        Email email = new Email("john.doe@example.com");

        string updatedLastName1 = "Smith";

        //Act
        var patient = new Patient(firstName, lastName1, lastName2, email);
        patient.UpdateLastName1(updatedLastName1);

        //Assert
        Assert.NotNull(patient);
        Assert.Equal(updatedLastName1, patient.LastName1);
    }

    [Fact]
    public void UpdateLastName2()
    {
        // Arrange
        string firstName = "John";
        string lastName1 = "Doe";
        string? lastName2 = null;
        Email email = new Email("john.doe@example.com");

        string updatedLastName2 = "Smith";

        //Act
        var patient = new Patient(firstName, lastName1, lastName2, email);
        patient.UpdateLastName2(updatedLastName2);

        //Assert
        Assert.NotNull(patient);
        Assert.Equal(updatedLastName2, patient.LastName2);
    }

    [Fact]
    public void UpdateEmail()
    {
        // Arrange
        string firstName = "John";
        string lastName1 = "Doe";
        string? lastName2 = null;
        Email email = new Email("john.doe@example.com");

        Email updatedEmail = new Email("jane.smith@example.com");

        //Act
        var patient = new Patient(firstName, lastName1, lastName2, email);
        patient.UpdateEmail(updatedEmail);

        //Assert
        Assert.NotNull(patient);
        Assert.Equal(updatedEmail, patient.Email);
    }

}
