using CarePulse360.Domain.Enumerators;
using CarePulse360.Domain.Exceptions;
using CarePulse360.Domain.ValueObjects;

namespace CarePulse360.Domain.Entities;

public class Appointment
{
    public Guid Id { get; private set; }
    public Guid IdPatient { get; private set; }
    public Guid IdDoctor { get; private set; }
    public Guid IdConsultingRoom { get; private set; }
    public AppointmentStatus Status { get; private set; }
    public MedicalSlot MedicalSlot { get; private set; } = null!;
    public Patient? Patient { get; private set; }
    public Doctor? Doctor { get; private set; }
    public ConsultingRoom? ConsultingRoom { get; private set; }

    public Appointment(Guid idPatient, Guid idDoctor, Guid idConsultingRoom, MedicalSlot medicalSlot)
    {
        if (medicalSlot.StartTime < DateTime.UtcNow)        
            throw new BusinessRuleException("The appointment start time cannot be in the past.");

        Id = Guid.CreateVersion7();
        IdPatient = idPatient;
        IdDoctor = idDoctor;
        IdConsultingRoom = idConsultingRoom;
        MedicalSlot = medicalSlot;
        Status = AppointmentStatus.Requested;
    }

    public void Cancel()
    {
        if (Status != AppointmentStatus.Requested && Status != AppointmentStatus.Confirmed)
            throw new BusinessRuleException("Only requested or confirmed appointments can be cancelled.");
    }

    public void Confirm()
    {
        if (Status != AppointmentStatus.Requested)
            throw new BusinessRuleException("Only requested appointments can be confirmed.");
    }

    public void Complete()
    {
        if (Status != AppointmentStatus.Confirmed)
            throw new BusinessRuleException("Only confirmed appointments can be completed.");
    }        
}
