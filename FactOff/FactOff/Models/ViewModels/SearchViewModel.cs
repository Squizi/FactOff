using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FactOff.Models.ViewModels
{
    public class SearchViewModel
    {
        private string creatorName;
        private string factContent;
        private float factRating;

        public string FactContent { get => factContent; set => factContent = value; }
        public string CreatorName { get => creatorName; set => creatorName = value; }
        public float FactRating { get => factRating; set => factRating = value; }
    }
}
