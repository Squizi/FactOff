using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace FactOff.Models.DB
{
    public class Tag
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid TagId { get; set; }
        public string Name { get; set; }

        public ICollection<FactsTags> Facts { get; set; }

        public Tag()
        {
            Facts = new List<FactsTags>();
        }
    }
}
