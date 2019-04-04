using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
