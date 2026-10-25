

using CarePulse360.Domain.Exceptions;

namespace CarePulse360.Domain.Entities;

public class ConsultingRoom
{
    public Guid Id { get; private set; }
    public string Name { get; private set; } = null!;

    public ConsultingRoom(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new BusinessRuleException("Consulting room name cannot be empty.");

        Id = Guid.CreateVersion7();
        Name = name;
    }
}
