using FactOff.Models.DB;
using System;
using System.Collections.Generic;

namespace FactOff.Services.Contracts
{
    public interface IFactsService
    {
        Guid CreateFact(string context);
    }
}
