namespace CarePulse360.Domain.Common;

public interface IDomainEvent
{
    DateTime OccurredOn { get; }
}