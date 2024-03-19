using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Moment2MVC.Models;

public partial class DogtrickModel
{
    [Required(ErrorMessage = "Ange ett hundtrick på minst 4 bokstäver")]
    [Display(Name = "Namn på hundtrick")]
    [MinLength(4)]
    public string? DogtrickName { get; set; }

    [Display(Name = "Svårighetsgrad")]
    public string? Difficulty { get; set; }

    [Display(Name = "Välj hund")]
    public virtual DogName? DogName { get; set; }
}

public partial class DogName
{
    public string NameOption { get; set; } = "Signe";
    public string[] NameOptions = ["Signe", "Sixten"];
}