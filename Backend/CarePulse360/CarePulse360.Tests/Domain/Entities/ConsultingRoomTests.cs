using CarePulse360.Domain.Entities;
using CarePulse360.Domain.Exceptions;

namespace CarePulse360.Tests.Domain.Entities;

public class ConsultingRoomTests
{
    [Fact]
    public void Constructor_NameIsNullOrEmpty_ThrowsBusinessRuleException()
    {
        // Arrange
        string name = null!;
        // Act & Assert
        var exception = Assert.Throws<BusinessRuleException>(() => new ConsultingRoom(name));
        Assert.Equal("Consulting room name cannot be empty.", exception.Message);
    }

    [Fact]
    public void Constructor_NameIsValid_CreatesConsultingRoomInstance()
    {
        // Arrange
        string name = "Room 1";
        // Act
        var consultingRoom = new ConsultingRoom(name);
        // Assert
        Assert.NotNull(consultingRoom);
        Assert.Equal(name, consultingRoom.Name);
    }

}
