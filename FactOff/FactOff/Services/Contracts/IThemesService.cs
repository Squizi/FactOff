using System;

namespace FactOff.Services.Contracts
{
    public interface IThemesService
    {
        Guid CreateTheme(string name);
    }
}
