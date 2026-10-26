using CarePulse360.Domain.Exceptions;

namespace CarePulse360.Domain.ValueObjects;

public class MedicalSlot
{
    public DateTime StartTime { get; private set; }
    public DateTime EndTime { get; private set; }

    public MedicalSlot(DateTime startTime, DateTime endTime)
    {
        if (startTime >= endTime)
            throw new BusinessRuleException("Start time must be earlier than end time.");

        StartTime = startTime;
        EndTime = endTime;
    }
}
