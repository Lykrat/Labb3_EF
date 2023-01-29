using System;
using System.Collections.Generic;

namespace Labb3_EF.Models
{
    public partial class Course
    {
        public int Id { get; set; }
        public int TeacherId { get; set; }
        public string CourseName { get; set; } = null!;
    }
}
