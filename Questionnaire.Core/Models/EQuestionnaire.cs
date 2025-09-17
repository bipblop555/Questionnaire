using Questionnaire.Core.Models.Abstractions;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Questionnaire.Core.Models;

public class EQuestionnaire : IEntity
{
    [Key]
    public int Id { get ; set; }

    [Required]
    public string Title { get; set; }

    public ObservableCollection<EQuestion> Questions { get; set; }


}
