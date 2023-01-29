using System;
using System.Collections.Generic;

namespace Labb3_EF.Models
{
    public partial class EmploymentType
    {
        public int Id { get; set; }
        public string Employment { get; set; } = null!;
    }
}
