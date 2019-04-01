using FactOff.Models.DB;
using FactOff.Models.ViewModels;
using System;
using System.Collections.Generic;

namespace FactOff.Services.Contracts
{
    public interface IFactsService
    {
        Guid CreateFact(string context);
        FactsIndexViewModel GetAllFacts();
        Fact GetFactById(Guid id);
    }
}
