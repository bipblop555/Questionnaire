using Microsoft.EntityFrameworkCore;
using Questionnaire.Core.Models;

namespace Questionnaire.Core.Context;

public class QuestionnaireContext : DbContext
{
    public DbSet<EQuestionnaire> Questionnaires { get; set; }
    public DbSet<EQuestion> Questions { get; set; }
    public DbSet<EReponse> Reponses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=localhost;Database=QuestionnaireDB;Trusted_Connection=True;TrustServerCertificate=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EQuestionnaire>()
            .HasMany(q => q.Questions)
            .WithOne(q => q.Questionnaire)
            .HasForeignKey(q => q.QuestionnaireId)
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<EQuestion>()
            .HasMany(q => q.Reponses)
            .WithOne(r => r.Question)
            .HasForeignKey(r => r.QuestionId)
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<EQuestion>()
            .HasOne(q => q.ReponseCorrecte)
            .WithMany()
            .HasForeignKey(q => q.ReponseCorrecteId)
            .OnDelete(DeleteBehavior.Restrict);
    }

}
