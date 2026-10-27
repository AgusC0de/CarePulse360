using CarePulse360.Domain.Common;

namespace CarePulse360.Domain.Events.Appointment;

public class AppointmentRequestedEvent : IDomainEvent
{
    public DateTime OccurredOn { get; }
}
