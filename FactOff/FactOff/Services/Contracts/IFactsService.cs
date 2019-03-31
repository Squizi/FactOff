using FactOff.Models.DB;
using System;
using System.Collections.Generic;

namespace FactOff.Services.Contracts
{
    interface IFactsService
    {
        Guid CreateFact(string context, ICollection<FactsTags> tags);
    }
}
