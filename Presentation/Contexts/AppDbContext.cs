using Microsoft.EntityFrameworkCore;
using Presentation.Models;

namespace Presentation.Contexts;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Feedback> Feedbacks { get; set; } = null!;
}