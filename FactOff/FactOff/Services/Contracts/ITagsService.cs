using FactOff.Models.DB;
using System;
using System.Collections.Generic;

namespace FactOff.Services.Contracts
{
    public interface ITagsService
    {
        Guid CreateTag(string name);
        List<Guid> CreateTags(string tagsString);
        int DeleteTag(Tag tag);
        Guid UpdateTag(Tag tag, string name);
        Tag GetTagById(Guid id);
    }
}
