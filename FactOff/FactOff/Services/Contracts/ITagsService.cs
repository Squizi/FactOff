using System;

namespace FactOff.Services.Contracts
{
    public interface ITagsService
    {
        Guid CreateTag(string name);
    }
}
