using FactOff.Models.DB;
using FactOff.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FactOff.Services
{
    /// <summary>
    /// The <c>ThemesService class</c> that inherits from <c>IThemesService interface</c>.
    /// Contains all the CRUD operations to manipulate the themes in the database.
    /// <list type="bullet">
    /// <item>
    /// <term>Create</term>
    /// <description><c>CreateTheme</c> function creates a new theme by giving the image (image content type) & name of the theme.</description>
    /// </item>
    /// <item>
    /// <term>Read</term>
    /// <description><c>GetThemeById</c> & <c>GetAllThemes</c> are all read methods that get the specified amount of themes.</description>
    /// </item>
    /// <item>
    /// <term>Update</term>
    /// <description><c>UpdateTheme</c> edits a specific theme's name.</description>
    /// </item>
    /// <item>
    /// <term>Delete</term>
    /// <description><c>DeleteTheme</c> function removes a specific theme from the database.</description>
    /// </item>
    /// </list>
    /// </summary>
    /// <remarks>
    /// <para>This class can communicate with the database and edit the information in the themes table.</para>
    /// </remarks>
    public class ThemesService : IThemesService
    {
        private readonly FactOffContext context;
        public ThemesService(FactOffContext context)
        {
            this.context = context;
        }

        public Guid CreateTheme(string name, byte[] image, string imageContentType)
        {
            Theme theme = new Theme()
            {
                Name = name,
                Image = image,
                ImageContentType = imageContentType
            };

            context.Themes.Add(theme);
            context.SaveChanges();

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

        public IEnumerable<Theme> GetAllThemes()
        {
            return context.Themes;
        }

        public Guid UpdateTheme(Theme theme, string name)
        {
            context.Themes.Where(t => t == theme).FirstOrDefault().Name = name;
            context.SaveChanges();
            return theme.ThemeId;
        }
    }
}
