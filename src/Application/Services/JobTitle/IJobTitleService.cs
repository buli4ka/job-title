using Application.ViewModels.JobTitle;

namespace Application.Services.JobTitle;

public interface IJobTitleService
{
    Task<IEnumerable<JobTitleDto>> GetAllJobTitles();
    Task<JobTitleDto> CreateJobTitle(CreateJobTitleDto jobTitleDto);
    Task<JobTitleDto> GetJobTitleById(Guid id);
    Task UpdateJobTitle(JobTitleDto jobTitle);
    Task DeleteJobTitleById(Guid id);
}