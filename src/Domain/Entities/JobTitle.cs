using Domain.Common;

namespace Domain.Entities;

public class JobTitle(string name) : BaseEntity
{
    public string Name { get; private set; } = name;
}