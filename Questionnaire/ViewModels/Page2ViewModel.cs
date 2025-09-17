using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Questionnaire.Core.Models;
using Questionnaire.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Questionnaire.ViewModels;

[ObservableObject]
public sealed partial class Page2ViewModel
{
    private readonly QuestionService questionService;
    private readonly ReponseService reponseService;
    public ICommand AddQuestionCommand { get; set; } = null!;
    public ICommand RemoveQuestionCommand { get; set; } = null!;

    public ObservableCollection<EQuestion> Questions { get; set; } = new();

    [ObservableProperty]
    private EQuestion? selectedQuestion;

    public Page2ViewModel()
    {
        this.questionService = new QuestionService();
        this.reponseService = new ReponseService();

        this.Questions = this.questionService.GetQuestions();
        this.AddQuestionCommand = new RelayCommand(this.AddQuestion);
        this.RemoveQuestionCommand = new RelayCommand<EQuestion>(this.DeleteQuestion);
    }

    private void AddQuestion()
    {
        var question = new EQuestion
        {
            QuestionnaireId = 1,
            Contenu = "Question test",

        };

        this.questionService.AddQuestion(question);

        var reponses = new List<EReponse>
        {
            new EReponse { Contenu = "Réponse 1", QuestionId = question.Id },
            new EReponse { Contenu = "Réponse 2", QuestionId = question.Id },
            new EReponse { Contenu = "Réponse 3", QuestionId = question.Id },
            new EReponse { Contenu = "Réponse 4", QuestionId = question.Id, EstBonneReponse = true },
        };

        foreach (var reponse in reponses)
        {
            this.reponseService.AddReponse(reponse);
        }

        this.SelectedQuestion = question;
        this.Questions.Add(question);
    }

    private void DeleteQuestion(EQuestion? question)
    {
        if (question is not null)
        {
            this.questionService.RemoveQuestion(question);
            this.Questions.Remove(question);
        }
    }
}
