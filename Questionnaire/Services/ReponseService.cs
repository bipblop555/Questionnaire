using Questionnaire.Core.AccessLayers;
using Questionnaire.Core.Models;
using System.Collections.ObjectModel;

namespace Questionnaire.Services;

internal class ReponseService
{
    private readonly ReponsesRepository reponsesRepository;

    public ReponseService()
    {
        this.reponsesRepository = new ReponsesRepository();
    }

    public ObservableCollection<EReponse> GetReponsesByQuestionId(int questionId)
        => new ObservableCollection<EReponse>(this.reponsesRepository.GetReponsesByQuestionId(questionId));

    public void AddReponse(List<EReponse> reponse)
        => this.reponsesRepository.Create(reponse);

    public void DeleteReponse(int questionId)
        => this.reponsesRepository.Delete(questionId);

    public void UpdateReponse(EReponse reponse) 
        => this.reponsesRepository.Update(reponse);
}
