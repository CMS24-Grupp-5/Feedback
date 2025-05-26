using Microsoft.EntityFrameworkCore;
using Presentation.Contexts;
using Presentation.Models;

namespace Presentation.Service;

public class FeedbackService
{
    private readonly AppDbContext _context;
    public FeedbackService(AppDbContext context)
    {
        _context = context;
    }
    public async Task<List<Feedback>> GetAllFeedbacksAsync()
    {
        return await _context.Feedbacks.ToListAsync();
    }
    public async Task<Feedback?> GetFeedbackByIdAsync(string id)
    {
        return await _context.Feedbacks.FindAsync(id);
    }
    public async Task AddFeedbackAsync(Feedback feedback)
    {
        _context.Feedbacks.Add(feedback);
        await _context.SaveChangesAsync();
    }
    public async Task UpdateFeedbackAsync(Feedback feedback)
    {
        _context.Feedbacks.Update(feedback);
        await _context.SaveChangesAsync();
    }
    public async Task DeleteFeedbackAsync(string id)
    {
        var feedback = await GetFeedbackByIdAsync(id);
        if (feedback != null)
        {
            _context.Feedbacks.Remove(feedback);
            await _context.SaveChangesAsync();
        }
    }
}
