using FactOff.Models.DB;
using System;
using System.Collections.Generic;

namespace FactOff.Services.Contracts
{
    /// <summary>
    /// <c>IThemesService interface</c> for the <c>ThemesService class</c>.
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
    public interface IThemesService
    {
        /// <summary>
        /// Creates a new theme with all required fields - theme name, image & type of the image.
        /// </summary>
        /// <param name="name">The name of the theme.</param>
        /// <param name="image">Shown image for the theme.</param>
        /// <param name="imageContentType">The type of the image</param>
        /// <returns>The id of the created theme.</returns>
        Guid CreateTheme(string name, byte[] image, string imageContentType);
        /// <summary>
        /// Edits an existing theme.
        /// </summary>
        /// <param name="theme">The theme to be changed</param>
        /// <param name="name">The new name of the theme.</param>
        /// <param name="image">The new image of the theme.</param>
        /// <param name="imageContentType">The type of the new image.</param>
        /// <returns>The id of the theme.</returns>
        Guid UpdateTheme(Theme theme, string name, byte[] image, string imageContentType);
        /// <summary>
        /// Deletes a given <paramref name="theme"/>.
        /// </summary>
        /// <param name="theme">The theme to be deleted.</param>
        /// <returns>Affected rows.</returns>
        int DeleteTheme(Theme theme);
        /// <summary>
        /// Return a theme with a given <paramref name="id"/>.
        /// </summary>
        /// <param name="id">The id of the searched theme.</param>
        /// <returns>The theme with the coresponding <paramref name="id"/>.</returns>
        Theme GetThemeById(Guid id);
        /// <summary>
        /// Return a collection of all themes.
        /// </summary>
        /// <returns>All themes</returns>
        IEnumerable<Theme> GetAllThemes();
    }
}
