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
    public ICommand AddQuestionCommand { get; set; } = null!;
    public ICommand RemoveQuestionCommand { get; set;} = null!;

    public ObservableCollection<EQuestion> Questions { get; set; } = new();

    [ObservableProperty]
    private EQuestion? selectedQuestion;

    public Page2ViewModel()
    {
        this.questionService = new QuestionService();
        this.Questions = this.questionService.GetQuestions();
        this.AddQuestionCommand = new RelayCommand(this.AddQuestion);
        this.RemoveQuestionCommand = new RelayCommand<EQuestion>(this.DeleteQuestion);
    }

    private void AddQuestion()
    {
        var question = new EQuestion
        {
            Contenu = "Question test",
            Reponses = new ObservableCollection<EReponse>
            {
                new EReponse { Contenu = "Réponse 1" },
                new EReponse { Contenu = "Réponse 2" },
                new EReponse { Contenu = "Réponse 3" }
            },
            ReponseCorrecte = new EReponse { Contenu = "Réponse 3" }
        };

        this.questionService.AddQuestion(question);
        this.SelectedQuestion = question;
        this.Questions.Add(question);
    }

    private void DeleteQuestion(EQuestion? question)
    {
        if(question is not null)
        {
            this.questionService.RemoveQuestion(question);
            this.Questions.Remove(question);
        }
    }
}
