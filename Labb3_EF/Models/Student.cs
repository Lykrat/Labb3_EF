using System;
using System.Collections.Generic;

namespace Labb3_EF.Models
{
    public partial class Student
    {
        public int Id { get; set; }
        public string Fname { get; set; } = null!;
        public string Lname { get; set; } = null!;
        public int Personnummer { get; set; }
    }
}
