using System.ComponentModel.DataAnnotations;

namespace Presentation.Models;

public class Feedback
{
    [Key]
    public string Id { get; set; } = Guid.NewGuid().ToString();

    public string FeedbackText { get; set; } = null!;

    public string? Author { get; set; }

}
