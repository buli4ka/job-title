using Application.Repositories;
using Application.ViewModels.JobTitle;
using AutoMapper;

namespace Application.Services.JobTitle;

// todo add validation

public class JobTitleService(IJobTitleRepository jobTitleRepository, IMapper mapper) : IJobTitleService
{
    private readonly IRepository<Domain.Entities.JobTitle> _jobTitleRepository = jobTitleRepository;


    public async Task<IEnumerable<JobTitleDto>> GetAllJobTitles()
    {
        var titles = await _jobTitleRepository.GetAll();

        return titles.Select(mapper.Map<JobTitleDto>).ToList();
    }

    public async Task<JobTitleDto> CreateJobTitle(CreateJobTitleDto jobTitleDto)
    {
        var entity = await _jobTitleRepository.Create(mapper.Map<Domain.Entities.JobTitle>(jobTitleDto));

        return mapper.Map<JobTitleDto>(entity);
    }

    public async Task<JobTitleDto> GetJobTitleById(Guid id)
    {
        var entity = await _jobTitleRepository.GetById(id);

        return mapper.Map<JobTitleDto>(entity);
    }

    public async Task UpdateJobTitle(JobTitleDto jobTitle)
    {
        await _jobTitleRepository.Update(mapper.Map<Domain.Entities.JobTitle>(jobTitle));
    }

    public async Task DeleteJobTitleById(Guid id)
    {
        await _jobTitleRepository.DeleteById(id);
    }
}