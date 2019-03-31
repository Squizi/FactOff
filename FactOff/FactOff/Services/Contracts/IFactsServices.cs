using FactOff.Models.DB2;
using System;
using System.Collections.Generic;

namespace FactOff.Services.Contracts
{
    interface IFactsService
    {
        Guid CreateFact(string context, ICollection<FactsTags> tags);
    }
}
