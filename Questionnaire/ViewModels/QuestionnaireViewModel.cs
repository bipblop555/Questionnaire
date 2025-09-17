using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Questionnaire.Core.Models;
using Questionnaire.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Questionnaire.ViewModels;

public sealed partial class QuestionnaireViewModel : ObservableObject
{
    private readonly QuestionnaireService questionnaireService;
    public ICommand NewQuestionnaireCommand { get; set; } = null!;
    public ICommand DeleteQuestionnaireCommand { get; set; } = null!;

    public ObservableCollection<EQuestionnaire> Questionnaires { get; set; } = new();

    [ObservableProperty]
    private EQuestionnaire? selectedQuestionnaire;

    public QuestionnaireViewModel()
    {
        this.questionnaireService = new QuestionnaireService();
        this.Questionnaires = this.questionnaireService.GetQuestionnaires();
        this.NewQuestionnaireCommand = new RelayCommand(this.AddQuestionnaire);
        this.DeleteQuestionnaireCommand = new RelayCommand<EQuestionnaire>(this.DeleteQuestionnaire);
    }

    private void AddQuestionnaire()
    {
        var questionnaire = new EQuestionnaire { Title = "Questionnaire Test" };
        this.questionnaireService.AddQuestionaire(questionnaire);
        this.selectedQuestionnaire = questionnaire;
        this.Questionnaires.Add(questionnaire);
    }

    private void DeleteQuestionnaire(EQuestionnaire? questionnaire)
    {
        if (questionnaire is not null)
        {
            this.questionnaireService.RemoveQuestionaire(questionnaire);
            this.Questionnaires.Remove(questionnaire);
        }
    }
}
