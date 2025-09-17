using Questionnaire.Core.AccessLayers;
using Questionnaire.Core.Models;
using System.Collections.ObjectModel;

namespace Questionnaire.Services;

public class QuestionnaireService
{
    private readonly QuestionnaireRepository questionnaireRepository;

    public QuestionnaireService()
    {
        this.questionnaireRepository = new QuestionnaireRepository();
    }

    public ObservableCollection<EQuestionnaire> GetQuestionnaires()
        => new ObservableCollection<EQuestionnaire>(this.questionnaireRepository.GetAllQuestionnaires());

    public void AddQuestionaire(EQuestionnaire questionnaire)
        => this.questionnaireRepository.Create(questionnaire);

    public void RemoveQuestionaire(EQuestionnaire questionnaire)
        => this.questionnaireRepository.Delete(questionnaire.Id);
}
