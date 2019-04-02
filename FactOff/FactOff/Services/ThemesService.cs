using FactOff.Models.DB;
using FactOff.Services.Contracts;
using System;
using System.Linq;

namespace FactOff.Services
{
    public class ThemesService : IThemesService
    {
        private readonly FactOffContext context;
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

        public int DeleteTheme(Theme theme)
        {
            context.Themes.Remove(theme);
            return context.SaveChanges();
        }

        public Theme GetThemeById(Guid id)
        {
            return context.Themes.Where(t => t.ThemeId == id).FirstOrDefault();
        }

        public Guid UpdateTheme(Theme theme, string name)
        {
            context.Themes.Where(t => t == theme).FirstOrDefault().Name = name;
            context.SaveChanges();
            return theme.ThemeId;
        }
    }
}
