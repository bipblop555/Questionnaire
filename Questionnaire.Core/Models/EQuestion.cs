using Questionnaire.Core.Models.Abstractions;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Questionnaire.Core.Models;

public class EQuestion : IEntity
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Contenu { get; set; }

    public int QuestionnaireId { get; set; }

    public virtual EQuestionnaire Questionnaire { get; set; }

    public List<EReponse> Reponses { get; set; }

    public EReponse? BonneReponse
        => Reponses?.FirstOrDefault(r => r.EstBonneReponse == true);

    [NotMapped]
    public List<EReponse>? MauvaisesReponses
        => Reponses?.Where(r => !r.EstBonneReponse).ToList();

}
