using Questionnaire.Core.Context;
using Questionnaire.Core.Models;

namespace Questionnaire.Core.AccessLayers;

public class ReponsesRepository
{
    internal QuestionnaireContext DbContext { get; set; }

    public ReponsesRepository()
    {
        this.DbContext = new QuestionnaireContext();
    }

    public List<EReponse> GetReponsesByQuestionId(int questionId) 
        => this.DbContext.Reponses.Where(r => r.QuestionId == questionId).ToList();

    public void Create(EReponse reponse)
    {
        this.DbContext.Reponses.Add(reponse);
        this.DbContext.SaveChanges();
    }

    public void Delete(int questionId)
    {
        var reponse = this.DbContext.Reponses
            .Where(r => r.QuestionId == questionId).ToList();
        if ( reponse is not null)
        {
            this.DbContext.RemoveRange(reponse);
            this.DbContext.SaveChanges();
        }
    }

}
