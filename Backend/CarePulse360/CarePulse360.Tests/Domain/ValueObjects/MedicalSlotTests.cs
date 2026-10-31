using CarePulse360.Domain.Exceptions;
using CarePulse360.Domain.ValueObjects;

namespace CarePulse360.Tests.Domain.ValueObjects;

public class MedicalSlotTests
{
    [Fact]
    public void Constructor_StartTimeIsLaterThanOrEqualToEndTime_ThrowsBusinessRuleException()
    {
        DateTime startTime = DateTime.Now.AddDays(1);
        DateTime endTime = DateTime.Now;
        
        var exception =Assert.Throws<BusinessRuleException>(() => new MedicalSlot(startTime, endTime));

        Assert.Equal("Start time must be earlier than end time.", exception.Message);
    }

    [Fact]
    public void Constructor_DataIsValid_CreatesMedicalSlotInstance()
    {
        DateTime startTime = DateTime.Now;
        DateTime endTime = DateTime.Now.AddDays(1);

        var medicalSlot = new MedicalSlot(startTime, endTime);

        Assert.NotNull(medicalSlot);
        Assert.Equal(startTime, medicalSlot.StartTime);
        Assert.Equal(endTime, medicalSlot.EndTime);
    }
}
