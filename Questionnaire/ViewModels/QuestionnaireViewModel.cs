using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Questionnaire.Core.Models;
using Questionnaire.Services;
using Questionnaire.Views;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Navigation;

namespace Questionnaire.ViewModels;

public sealed partial class QuestionnaireViewModel : ObservableObject
{
    private readonly QuestionnaireService questionnaireService;
    public ICommand NewQuestionnaireCommand { get; set; } = null!;
    public ICommand DeleteQuestionnaireCommand { get; set; } = null!;
    public ICommand OpenQuestionnaireCommand { get; set; } = null!;
    
    public ObservableCollection<EQuestionnaire> Questionnaires { get; set; } = new();

    [ObservableProperty]
    private EQuestionnaire? selectedQuestionnaire;

    public QuestionnaireViewModel()
    {
        this.questionnaireService = new QuestionnaireService();
        this.Questionnaires = this.questionnaireService.GetQuestionnaires();
        this.NewQuestionnaireCommand = new RelayCommand(this.AddQuestionnaire);
        this.DeleteQuestionnaireCommand = new RelayCommand<EQuestionnaire>(this.DeleteQuestionnaire);
        this.OpenQuestionnaireCommand = new RelayCommand(this.OpenQuestionaire);
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

    private void OpenQuestionaire()
    {
        var page2 = new Page2();
        var navigationWindow = Application.Current.MainWindow as NavigationWindow;
        navigationWindow?.Navigate(page2);
    }
}
