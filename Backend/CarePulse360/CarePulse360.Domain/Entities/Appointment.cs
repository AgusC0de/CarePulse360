

using CarePulse360.Domain.Enumerators;

namespace CarePulse360.Domain.Entities;

public class Appointment
{
    public Guid Id { get; private set; }
    public Guid IdPatient { get; private set; }
    public Guid IdDoctor { get; private set; }
    public Guid IdConsultingRoom { get; private set; }
    public AppointmentStatus appointmentStatus { get; private set; }
    public Patient? Patient { get; private set; }
    public Doctor? Doctor { get; private set; }
    public ConsultingRoom? ConsultingRoom { get; private set; }

}
