namespace IntegrationAnalitics.Application.Domain.Entities.Planning;

public class PokerPlan
{
    public Guid Id { get; set; }
    public List<TaskPokerPlan> TaskPokerPlans { get; set; }
    public DateTime DateTime { get; set; }
}