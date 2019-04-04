using System;
using System.Collections.Generic;

namespace FactOff.Services.Contracts
{
    public interface IFactsTagsService
    {
        int AddTagsToFact(Guid factId, List<Guid> tagsId);
    }
}
