using FactOff.Models.DB;
using FactOff.Models.ViewModels;
using FactOff.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FactOff.Services
{
    public class SearchService : ISearchService
    {
        private readonly FactOffContext context;

        public SearchService(FactOffContext context)
        {
            this.context = context;
        }

        public IEnumerable<Fact> Search(string search, IEnumerable<Guid> tagIds)
        {
            return context.Facts
                .Include(f => f.Creator)
                .Include(f => f.Tags)
                    .ThenInclude(ft => ft.Tag)
                .Where(f => f.Context.Contains(search) || 
                f.Tags.Any(ft => ft.Tag.Name.Contains(search)) ||
                f.Tags.Any(ft => tagIds.Contains(ft.TagId))
                );
        }
    }
}
