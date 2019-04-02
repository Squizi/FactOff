using FactOff.Models.DB;
using System;

namespace FactOff.Services.Contracts
{
    public interface IThemesService
    {
        Guid CreateTheme(string name);
        Guid UpdateTheme(Theme theme, string name);
        int DeleteTheme(Theme theme);
        Theme GetThemeById(Guid id);
    }
}
