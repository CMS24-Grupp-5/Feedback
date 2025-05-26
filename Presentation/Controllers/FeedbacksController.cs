using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.Models;
using Presentation.Service;

namespace Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FeedbacksController(FeedbackService feedbackService) : ControllerBase
{
    private readonly FeedbackService _feedbackService = feedbackService;
    [HttpGet]
    public async Task<IActionResult> GetAllFeedbacks()
    {
        var feedbacks = await _feedbackService.GetAllFeedbacksAsync();
        return Ok(feedbacks);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetFeedbackById(string id)
    {
        var feedback = await _feedbackService.GetFeedbackByIdAsync(id);
        if (feedback == null)
        {
            return NotFound();
        }
        return Ok(feedback);
    }
    [HttpPost]
    public async Task<IActionResult> AddFeedback([FromBody] Feedback feedback)
    {
        if (feedback == null || string.IsNullOrEmpty(feedback.FeedbackText))
        {
            return BadRequest("Invalid feedback data.");
        }
        await _feedbackService.AddFeedbackAsync(feedback);
        return CreatedAtAction(nameof(GetFeedbackById), new { id = feedback.Id }, feedback);
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateFeedback(string id, [FromBody] Feedback feedback)
    {
        if (feedback == null || string.IsNullOrEmpty(feedback.FeedbackText) || id != feedback.Id)
        {
            return BadRequest("Invalid feedback data.");
        }
        await _feedbackService.UpdateFeedbackAsync(feedback);
        return NoContent();
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteFeedback(string id)
    {
        await _feedbackService.DeleteFeedbackAsync(id);
        return NoContent();
    }
}
