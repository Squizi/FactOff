using FactOff.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FactOff.Services.Contracts
{
    public interface IFactsTagsService
    {
        int AddTagsToFact(Guid factId, List<Guid> tagsId);
    }
}
