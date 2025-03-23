using System.ComponentModel.DataAnnotations;

namespace CRM_CSharp.Models.AlertRate;

public class AlertRate
{
    public int AlertRateId { get; set; }

    [Required(ErrorMessage = "Le taux d'alerte est requis")]
    [Range(0, 1, ErrorMessage = "Le taux doit être compris entre 0 et 1")]
    [Display(Name = "Taux d'alerte")]
    public double Rate { get; set; }
}