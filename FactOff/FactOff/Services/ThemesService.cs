using FactOff.Models.DB;
using FactOff.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FactOff.Services
{
    public class ThemesService : IThemesService
    {
        private FactOffContext context;
        public ThemesService(FactOffContext context)
        {
            this.context = context;
        }

        public Guid CreateTheme(string name)
        {
            Theme theme = new Theme() {
                Name = name
            };

            return theme.ThemeId;
        }
    }
}
