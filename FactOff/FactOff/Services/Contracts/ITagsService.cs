using System;
using System.Collections.Generic;

namespace FactOff.Services.Contracts
{
    public interface ITagsService
    {
        Guid CreateTag(string name);
        List<Guid> CreateTags(string tagsString);
    }
}
