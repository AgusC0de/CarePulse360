

namespace CarePulse360.Domain.ValueObjects;

public class MedicalSlot
{
    public DateTime StartTime { get; private set; }
    public DateTime EndTime { get; private set; }

    public MedicalSlot()
    {
        
    }
}
