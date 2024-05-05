﻿using Application.Services.JobTitle;
using Application.ViewModels.JobTitle;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.JobTitle;

[ApiController]
[Route("[controller]")]
public class JobTitleController(IJobTitleService jobTitleService) : ControllerBase
{
    private readonly IJobTitleService _jobTitleService = jobTitleService;


    [HttpGet("getJobTitles")]
    public Task<IEnumerable<JobTitleDto>> GetAll()
    {
        return _jobTitleService.GetAllJobTitles();
    }  
    
    [HttpGet("getJobTitle/{jobTitleId:guid}")]
    public Task<JobTitleDto> GetById(Guid jobTitleId)
    {
        return _jobTitleService.GetJobTitleById(jobTitleId);
    }

    [HttpPost("createJobTitle")]
    public Task<JobTitleDto> CreateJobTitle(CreateJobTitleDto jobTitleDtoDto)
    {
        return _jobTitleService.CreateJobTitle(jobTitleDtoDto);
    }
    
    [HttpPut("updateJobTitle")]
    public async Task<IActionResult> UpdateJobTitle(JobTitleDto jobTitleDto)
    {
        await _jobTitleService.UpdateJobTitle(jobTitleDto);

        return Ok();
    }    
    [HttpDelete("deleteJobTitle/{jobTitleId:guid}")]
    public async Task<IActionResult> DeleteJobTitle(Guid jobTitleId)
    {
        await _jobTitleService.DeleteJobTitleById(jobTitleId);

        return NoContent();
    }


}