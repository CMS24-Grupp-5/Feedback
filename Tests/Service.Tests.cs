using Microsoft.EntityFrameworkCore;
using Presentation.Contexts;
using Presentation.Models;
using Presentation.Service;

namespace Tests
{
    public class FeedbackServiceTests
    {
        private AppDbContext GetInMemoryDbContext()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            return new AppDbContext(options);
        }

        private Feedback GetSampleFeedback(string id = "1") => new()
        {
            Id = id,
            Author = "Test Author",
            FeedbackText = "This is a test feedback."
        };

        [Fact]
        public async Task AddFeedbackAsync_ShouldAddFeedback()
        {
            var context = GetInMemoryDbContext();
            var service = new FeedbackService(context);
            var feedback = GetSampleFeedback();

            await service.AddFeedbackAsync(feedback);
            var result = await context.Feedbacks.FirstOrDefaultAsync();

            Assert.NotNull(result);
            Assert.Equal("Test Author", result.Author);
        }

        [Fact]
        public async Task GetAllFeedbacksAsync_ShouldReturnAllFeedbacks()
        {
            var context = GetInMemoryDbContext();
            var service = new FeedbackService(context);

            context.Feedbacks.Add(GetSampleFeedback("1"));
            context.Feedbacks.Add(GetSampleFeedback("2"));
            await context.SaveChangesAsync();

            var result = await service.GetAllFeedbacksAsync();

            Assert.Equal(2, result.Count);
        }

        [Fact]
        public async Task GetFeedbackByIdAsync_ShouldReturnCorrectFeedback()
        {
            var context = GetInMemoryDbContext();
            var service = new FeedbackService(context);
            var feedback = GetSampleFeedback("123");

            context.Feedbacks.Add(feedback);
            await context.SaveChangesAsync();

            var result = await service.GetFeedbackByIdAsync("123");

            Assert.NotNull(result);
            Assert.Equal("123", result.Id);
        }

        [Fact]
        public async Task UpdateFeedbackAsync_ShouldUpdateFeedback()
        {
            var context = GetInMemoryDbContext();
            var service = new FeedbackService(context);
            var feedback = GetSampleFeedback("456");

            context.Feedbacks.Add(feedback);
            await context.SaveChangesAsync();

            feedback.FeedbackText = "Updated feedback.";
            await service.UpdateFeedbackAsync(feedback);

            var result = await context.Feedbacks.FindAsync("456");
            Assert.Equal("Updated feedback.", result!.FeedbackText);
        }

        [Fact]
        public async Task DeleteFeedbackAsync_ShouldRemoveFeedback()
        {
            var context = GetInMemoryDbContext();
            var service = new FeedbackService(context);
            var feedback = GetSampleFeedback("789");

            context.Feedbacks.Add(feedback);
            await context.SaveChangesAsync();

            await service.DeleteFeedbackAsync("789");

            var result = await context.Feedbacks.FindAsync("789");
            Assert.Null(result);
        }

        [Fact]
        public async Task DeleteFeedbackAsync_ShouldHandleMissingFeedbackGracefully()
        {
            var context = GetInMemoryDbContext();
            var service = new FeedbackService(context);

            var exception = await Record.ExceptionAsync(() => service.DeleteFeedbackAsync("non-existent"));

            Assert.Null(exception);
        }
    }
}
