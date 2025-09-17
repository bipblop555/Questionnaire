using Questionnaire.Core.Context;
using Questionnaire.Core.Models;

namespace Questionnaire.Core.AccessLayers;

public sealed class QuestionnaireRepository
{
    internal QuestionnaireContext DbContext { get; private set; }

    public QuestionnaireRepository()
    {
        this.DbContext = new QuestionnaireContext();
    }

    public List<EQuestionnaire> GetAllQuestionnaires()
        => this.DbContext.Questionnaires.ToList();

    public void Create(EQuestionnaire questionnaire)
    {
        this.DbContext.Questionnaires.Add(questionnaire);
        this.DbContext.SaveChanges();
    }

    public void Delete(int id)
    {
        var questionnaire = this.DbContext.Questionnaires.Find(id);

        if (questionnaire is not null)
        {
            this.DbContext.Questionnaires.Remove(questionnaire);
            this.DbContext.SaveChanges();
        }
    }
}
