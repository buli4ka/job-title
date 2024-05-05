using Application.ViewModels.JobTitle;
using Domain.Entities;

namespace Application.Profile;

public class AutoMapperProfile : AutoMapper.Profile
{
    public AutoMapperProfile()
    {
        CreateMap<JobTitle, JobTitleDto>();
        CreateMap<JobTitleDto, JobTitle>();
        CreateMap<CreateJobTitleDto, JobTitle>();
    }
}