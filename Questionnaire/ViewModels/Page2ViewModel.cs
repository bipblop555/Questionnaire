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
    private int questionnaireId;

    private readonly QuestionService questionService;
    private readonly ReponseService reponseService;
    public ICommand AddQuestionCommand { get; set; } = null!;
    public ICommand RemoveQuestionCommand { get; set; } = null!;
    public ICommand UpdateQuestionCommand { get; set; } = null!;
    public ObservableCollection<EQuestion> Questions { get; set; } = new();

    [ObservableProperty]
    private EQuestion? selectedQuestion;

    public Page2ViewModel(int questionnaireId)
    {
        this.questionnaireId = questionnaireId;

        this.questionService = new QuestionService();
        this.reponseService = new ReponseService();

        this.Questions = this.questionService.GetQuestionsByQuestionnaireId(questionnaireId);
        this.AddQuestionCommand = new RelayCommand(this.AddQuestion);
        this.RemoveQuestionCommand = new RelayCommand<int>(this.DeleteQuestion);
        this.UpdateQuestionCommand = new RelayCommand<int>(this.UpdateQuestion);
    }

    private void AddQuestion()
    {
        var question = new EQuestion
        {
            QuestionnaireId = this.questionnaireId,
            Contenu = "Titre de la question",
        };

        this.questionService.AddQuestion(question);
        var reponses = new List<EReponse>
        {
            new EReponse { Contenu = "Réponse A", QuestionId = question.Id },
            new EReponse { Contenu = "Réponse B", QuestionId = question.Id },
            new EReponse { Contenu = "Réponse C", QuestionId = question.Id },
            new EReponse { Contenu = "Réponse D", QuestionId = question.Id, EstBonneReponse = true },
        };

        foreach (var reponse in reponses)
        {
            this.reponseService.AddReponse(reponse);
        }

        this.SelectedQuestion = question;
        this.Questions.Add(question);
    }

    //private void AddReponses(EQuestion question)
    //{
        
    //}

    private void UpdateQuestion(int questionId)
    {
        //this.questionService.
    }

    private void DeleteQuestion(int questionId)
    {
        this.questionService.RemoveQuestion(questionId);
        var question = this.Questions.FirstOrDefault(q => q.Id == questionId);
        if(question is not null)
            this.Questions.Remove(question);
        DeleteReponses(questionId);
    }

    private void DeleteReponses(int questionId)
    {
        this.reponseService.DeleteReponse(questionId);
    }
}
