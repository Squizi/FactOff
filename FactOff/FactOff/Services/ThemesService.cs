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
        /// <summary>
        /// The required context for the connection to the database.
        /// </summary>
        private readonly FactOffContext context;

        /// <summary>
        /// The constructor for the <c>ThemesService</c> that is being called by the <c>StartUp class</c>.
        /// </summary>
        /// <param name="context">The required context for the connection to the database.</param>
        public ThemesService(FactOffContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Creates a new theme with all required fields - theme name, image & type of the image.
        /// </summary>
        /// <param name="name">The name of the theme.</param>
        /// <param name="image">Shown image for the theme.</param>
        /// <param name="imageContentType">The type of the image</param>
        /// <returns>The id of the created theme.</returns>
        /// <example>
        /// <code>
        /// byte[] image;
        /// using (var ms = new MemoryStream())
        /// {
        ///     request.ImageUploaded.CopyTo(ms);
        ///     image = ms.ToArray();
        /// }
        /// Theme theme = GetThemeById(CreateTheme("My new theme", image, request.ImageUploaded.ContentType));
        /// Console.WriteLine(theme.Name);
        /// </code>
        /// </example>
        /// <see cref="GetThemeById(Guid)"/>
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

        /// <summary>
        /// Deletes a given <paramref name="theme"/>.
        /// </summary>
        /// <param name="theme">The theme to be deleted.</param>
        /// <returns>Affected rows.</returns>
        /// <example>
        /// <code>
        /// byte[] image;
        /// using (var ms = new MemoryStream())
        /// {
        ///     request.ImageUploaded.CopyTo(ms);
        ///     image = ms.ToArray();
        /// }
        /// Theme theme = GetThemeById(CreateTheme("My new theme", image, request.ImageUploaded.ContentType));
        /// DeleteTheme(theme);
        /// if(context.Themes.Where(t => t == theme).First() == null){
        ///     Console.WriteLine(theme.Name);
        /// }
        /// else{
        ///     Console.WriteLine("No such theme in the database.");
        /// }
        /// </code>
        /// </example>
        /// <see cref="CreateTheme(string, byte[], string)"/>
        /// <seealso cref="GetThemeById(Guid)"/>
        public int DeleteTheme(Theme theme)
        {
            context.Themes.Remove(theme);
            return context.SaveChanges();
        }

        /// <summary>
        /// Return a theme with a given <paramref name="id"/>.
        /// </summary>
        /// <param name="id">The id of the searched theme.</param>
        /// <returns>The theme with the coresponding <paramref name="id"/>.</returns>
        /// <example>
        /// <code>
        /// byte[] image;
        /// using (var ms = new MemoryStream())
        /// {
        ///     request.ImageUploaded.CopyTo(ms);
        ///     image = ms.ToArray();
        /// }
        /// Theme theme = GetThemeById(CreateTheme("My new theme", image, request.ImageUploaded.ContentType));
        /// Console.WriteLine(theme.Name);
        /// </code>
        /// </example>
        /// <see cref="CreateTheme(string, byte[], string)"/>
        public Theme GetThemeById(Guid id)
        {
            return context.Themes.Where(t => t.ThemeId == id).FirstOrDefault();
        }

        /// <summary>
        /// Return a collection of all themes.
        /// </summary>
        /// <returns>All themes</returns>
        /// <example>
        /// <code>
        /// IEnumerable<Theme> themes = GetAllThemes();
        /// foreach(Theme theme in themes){
        ///     Console.WriteLine(theme.Name);
        /// }
        /// </code>
        /// </example>
        public IEnumerable<Theme> GetAllThemes()
        {
            return context.Themes;
        }

        /// <summary>
        /// Edits an existing theme.
        /// </summary>
        /// <param name="theme">The theme to be changed</param>
        /// <param name="name">The new name of the theme.</param>
        /// <param name="image">The new image of the theme.</param>
        /// <param name="imageContentType">The type of the new image.</param>
        /// <returns>The id of the theme.</returns>
        /// <example>
        /// <code>
        /// byte[] image;
        /// var ms = null;
        /// using (ms = new MemoryStream())
        /// {
        ///     request.ImageUploaded.CopyTo(ms);
        ///     image = ms.ToArray();
        /// }
        /// byte[] image2;
        /// using (ms = new MemoryStream())
        /// {
        ///     request.ImageUploaded.CopyTo(ms);
        ///     image2 = ms.ToArray();
        /// }
        /// Theme theme = GetThemeById(CreateTheme("My new theme", image, request.ImageUploaded.ContentType));
        /// UpdateTheme(theme, "The new name", image2, request.ImageUploaded.ContentType);
        /// Console.WriteLine(theme.Name);
        /// </code>
        /// </example>
        /// <see cref="CreateTheme(string, byte[], string)"/>
        /// <seealso cref="GetThemeById(Guid)"/>
        public Guid UpdateTheme(Theme theme, string name, byte[] image, string imageContentType)
        {
            theme.Name = name;
            theme.Image = image;
            theme.ImageContentType = imageContentType;
            context.SaveChanges();
            return theme.ThemeId;
        }
    }
}
