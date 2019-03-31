using FactOff.Models.DB;
using FactOff.Services.Contracts;
using System;

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
