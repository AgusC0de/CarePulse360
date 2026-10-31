using CarePulse360.Domain.Entities;
using CarePulse360.Domain.Enumerators;
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
        Assert.Equal(AppointmentStatus.Requested, appointment.Status);
    }

    [Fact]
    public void Appointment_CantCancelTwice_ThrowsBusinessRuleException()
    {
        var appointment = new Appointment(IdPatient, IdDoctor, IdConsultingRoom, medicalSlot);

        appointment.Cancel();

        var exception = Assert.Throws<BusinessRuleException>(() => appointment.Cancel());

        Assert.Equal("Only requested or confirmed appointments can be cancelled.", exception.Message);
    }

    [Fact]
    public void Appointment_CantCancelCompleted_ThrowsBusinessRuleException()
    {
        var appointment = new Appointment(IdPatient, IdDoctor, IdConsultingRoom, medicalSlot);
        appointment.Confirm();
        appointment.Complete();
        
        var exception = Assert.Throws<BusinessRuleException>(() => appointment.Cancel());

        Assert.Equal("Only requested or confirmed appointments can be cancelled.", exception.Message);
    }

    [Fact]
    public void Appointment_CantConfirmedTwice_ThrowsBusinessRuleException()
    {
        var appointment = new Appointment(IdPatient, IdDoctor, IdConsultingRoom, medicalSlot);
        appointment.Confirm();

        var exception = Assert.Throws<BusinessRuleException>(() => appointment.Confirm());

        Assert.Equal("Only requested appointments can be confirmed.", exception.Message);
    }

    [Fact]
    public void AppointmentRequested_CantCancelCompleted_ThrowsBusinessRuleException()
    {
        var appointment = new Appointment(IdPatient, IdDoctor, IdConsultingRoom, medicalSlot);
        
        var exception = Assert.Throws<BusinessRuleException>(() => appointment.Complete());

        Assert.Equal("Only confirmed appointments can be completed.", exception.Message);
    }

    [Fact]
    public void Appointment_Cancel()
    {
        var appointment = new Appointment(IdPatient, IdDoctor, IdConsultingRoom, medicalSlot);

        appointment.Cancel();

        Assert.Equal(AppointmentStatus.Cancelled, appointment.Status);
    }

    [Fact]
    public void Appointment_Confirm()
    {
        var appointment = new Appointment(IdPatient, IdDoctor, IdConsultingRoom, medicalSlot);

        appointment.Confirm();

        Assert.Equal(AppointmentStatus.Confirmed, appointment.Status);
    }

    [Fact]
    public void Appointment_Complete()
    {
        var appointment = new Appointment(IdPatient, IdDoctor, IdConsultingRoom, medicalSlot);

        appointment.Confirm();
        appointment.Complete();

        Assert.Equal(AppointmentStatus.Completed, appointment.Status);
    }
}
