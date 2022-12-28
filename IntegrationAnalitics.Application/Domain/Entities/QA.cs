namespace IntegrationAnalitics.Application.Domain.Entities;

public class QA
{
    public Guid Id { get; set; }
    public Guid AuthorId { get; set; }
    
    public Guid CategoryId { get; set; }
    public string? QuestionString { get; set; }
    public string? AnswerString { get; set; }
    public string? Keywords { get; set; }
    public DateTime DateTime { get; set; }
}