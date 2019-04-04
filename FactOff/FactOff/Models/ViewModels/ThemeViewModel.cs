using Microsoft.AspNetCore.Http;

namespace FactOff.Models.ViewModels
{
    public class ThemeViewModel
    {
        public string Name { get; set; }
        public IFormFile ImageUploaded { get; set; }
        public byte[] Image { get; set; }
        public string ImageContentType { get; set; }
    }
}
