using Questionnaire.Core.Context;
using Questionnaire.Core.Models;

namespace Questionnaire.Core.AccessLayers;

public sealed class QuestionsRepository
{
    internal QuestionnaireContext DbContext { get; set; }

    public QuestionsRepository()
    {
        this.DbContext = new QuestionnaireContext();
    }

    public List<EQuestion> GetAllQuestions() 
        => this.DbContext.Questions.ToList();

    public void Create(EQuestion question)
    {
        this.DbContext.Questions.Add(question);
        this.DbContext.SaveChanges();
    }

    public void Delete(int id)
    {
        var question = this.DbContext.Questions.FirstOrDefault(x => x.Id == id);
        if (question is not null)
        {
            this.DbContext.Questions.Remove(question);
            this.DbContext.SaveChanges();
        }
    }
}
