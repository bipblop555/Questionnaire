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

    public void Create(List<EReponse> reponse)
    {
        this.DbContext.Reponses.AddRange(reponse);
        this.DbContext.SaveChangesAsync();
    }

    public void Delete(int questionId)
    {
        var reponse = this.DbContext.Reponses
            .Where(r => r.QuestionId == questionId).ToList();
        if ( reponse is not null)
        {
            foreach(var r in reponse)
            {
                this.DbContext.Remove(r);
                this.DbContext.SaveChanges();
            }
        }
    }

    public void Update(EReponse reponse)
    {
        var reponseDb = this.DbContext.Reponses.FirstOrDefault(r => r.Id == reponse.Id);
        if ( reponseDb is not null )
        {
            reponseDb = reponse;
            this.DbContext.SaveChangesAsync();
        }
    }

}
