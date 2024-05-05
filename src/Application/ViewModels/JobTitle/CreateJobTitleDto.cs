using System.ComponentModel.DataAnnotations;

namespace Application.ViewModels.JobTitle;

public class CreateJobTitleDto(string name)
{
    [Required]
    [MaxLength(50)]
    public string Name { get; set; } = name;
}