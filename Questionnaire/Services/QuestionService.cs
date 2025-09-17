namespace Questionnaire.Services;
using Questionnaire.Core.AccessLayers;
using Questionnaire.Core.Models;
using System.Collections.ObjectModel;

public class QuestionService
{
    private readonly QuestionsRepository questionsRepository;

    public QuestionService()
    {
        this.questionsRepository = new QuestionsRepository();
    }

    public ObservableCollection<EQuestion> GetQuestions() 
        => new ObservableCollection<EQuestion>(this.questionsRepository.GetAllQuestions());
    
    public void AddQuestion(EQuestion question)
        => this.questionsRepository.Create(question);

    public void RemoveQuestion(EQuestion question)
        => this.questionsRepository.Delete(question.Id);
}
