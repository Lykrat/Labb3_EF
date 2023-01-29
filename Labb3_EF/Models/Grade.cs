using System;
using System.Collections.Generic;

namespace Labb3_EF.Models
{
    public partial class Grade
    {
        public int Id { get; set; }
        public int TeacherId { get; set; }
        public int CourseId { get; set; }
        public int StudentId { get; set; }
        public string Grade1 { get; set; } = null!;
        public DateTime DateTime { get; set; }
    }
}
