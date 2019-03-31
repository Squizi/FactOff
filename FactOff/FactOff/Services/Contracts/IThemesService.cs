using System;

namespace FactOff.Services.Contracts
{
    interface IThemesService
    {
        Guid CreateTheme(string name);
    }
}
