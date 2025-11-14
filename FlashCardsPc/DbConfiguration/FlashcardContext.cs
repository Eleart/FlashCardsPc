using FlashCardsPc.Models;
using Microsoft.EntityFrameworkCore;

namespace FlashCardsPc.DbConfiguration;
public class FlashcardContext : DbContext
{
    public DbSet<Card> Cards { get; set; }

    public string DbPath { get; }

    public FlashcardContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = Path.Join(path, "flashcards.db");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    => options.UseSqlite($"Data Source={DbPath}");
}
