using Questionnaire.Core.Models.Abstractions;
using System.ComponentModel.DataAnnotations;

namespace Questionnaire.Core.Models;

public class EReponse : IEntity
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Contenu { get; set; }

    public int QuestionId { get; set; }

    public virtual EQuestion Question { get; set; } = new EQuestion();
}
