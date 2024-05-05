using System.ComponentModel.DataAnnotations;

namespace Application.ViewModels.JobTitle;

public class JobTitleDto(string name, Guid id)
{
    public Guid Id { get; set; } = id;
    
    [Required]
    [MaxLength(50)]
    public string Name { get; set; } = name;
    
}