using CarePulse360.Domain.Entities;
using CarePulse360.Domain.Exceptions;
using CarePulse360.Domain.ValueObjects;

namespace CarePulse360.Tests.Domain.Entities;

public class AppointmentTests
{
    private Guid IdPatient = Guid.CreateVersion7();
    private Guid IdDoctor = Guid.CreateVersion7();
    private Guid IdConsultingRoom = Guid.CreateVersion7();
    private MedicalSlot medicalSlot = new MedicalSlot(DateTime.UtcNow.AddDays(1), DateTime.UtcNow.AddDays(2));

    [Fact]
    public void Constructor_AppointmentStartTimeIsInThePast_ThrowsBusinessRuleException()
    {
        var pastMedicalSlot = new MedicalSlot(DateTime.UtcNow.AddDays(-1), DateTime.UtcNow.AddDays(1));
        var exception = Assert.Throws<BusinessRuleException>(() => new Appointment(IdPatient, IdDoctor, IdConsultingRoom, pastMedicalSlot));
        Assert.Equal("The appointment start time cannot be in the past.", exception.Message);
    }

    [Fact]
    public void Constructor_ValidAppointment_CreateInstance()
    {
        var appointment = new Appointment(IdPatient, IdDoctor, IdConsultingRoom, medicalSlot);

        Assert.NotNull(appointment);
        Assert.IsType<Guid>(appointment.Id);
        Assert.Equal(IdPatient, appointment.IdPatient);
        Assert.Equal(IdDoctor, appointment.IdDoctor);
        Assert.Equal(IdConsultingRoom, appointment.IdConsultingRoom);
    }
}
