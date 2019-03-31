using System;

namespace FactOff.Services.Contracts
{
    interface ITagsService
    {
        Guid CreateTag(string name);
    }
}
