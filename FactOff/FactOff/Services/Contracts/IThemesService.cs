using FactOff.Models.DB;
using System;
using System.Collections.Generic;

namespace FactOff.Services.Contracts
{
    public interface IThemesService
    {
        Guid CreateTheme(string name, byte[] image, string imageContentType);
        Guid UpdateTheme(Theme theme, string name);
        int DeleteTheme(Theme theme);
        Theme GetThemeById(Guid id);
        IEnumerable<Theme> GetAll();
    }
}
