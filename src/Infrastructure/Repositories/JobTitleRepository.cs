using Application.Exceptions;
using Application.Repositories;
using Domain.Entities;
using Infrastructure.DBConfiguration;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class JobTitleRepository(AppDBContext appDbContext) : IJobTitleRepository
{
    public async Task<IEnumerable<JobTitle>> GetAll()
    {
        return await appDbContext.JobTitles.ToListAsync();
    }

    public async Task<JobTitle> Create(JobTitle entity)
    {
        await appDbContext.JobTitles.AddAsync(entity);

        await appDbContext.SaveChangesAsync();

        return entity;
    }

    public async Task<JobTitle> GetById(Guid id)
    {
        var entity = await appDbContext.JobTitles.Where(e => e.Id == id).FirstOrDefaultAsync();

        if (entity == null) throw new NotFoundException($"Job wasn't found");

        return entity;
    }

    public async Task Update(JobTitle entity)
    {
        var job = await GetById(entity.Id);

        await appDbContext.JobTitles.Where(e => e.Id == entity.Id).ExecuteUpdateAsync(e => e.SetProperty(p => p.Name, p => entity.Name));

        await appDbContext.SaveChangesAsync();
    }

    public async Task DeleteById(Guid id)
    {
        var entity = await GetById(id);

        appDbContext.Remove(entity);

        await appDbContext.SaveChangesAsync();
    }
}