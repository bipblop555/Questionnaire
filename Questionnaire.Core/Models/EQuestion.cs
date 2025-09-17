using Questionnaire.Core.Models.Abstractions;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Questionnaire.Core.Models;

public class EQuestion : IEntity
{
    [Key]
    public int Id { get ; set ; }

    [Required]
    public string Contenu { get; set; }

    public int QuestionnaireId { get; set; }

    public virtual EQuestionnaire Questionnaire { get; set; } = new EQuestionnaire();

    public int ReponseCorrecteId { get; set; }

    [ForeignKey("ReponseCorrecteId")]
    public virtual EReponse ReponseCorrecte { get; set; }

    public ObservableCollection<EReponse> Reponses { get; set; }

}
