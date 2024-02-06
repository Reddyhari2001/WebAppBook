using System;
using System.Collections.Generic;

namespace WebAppBook.Models
{
    public partial class Book
    {
        public int BookId { get; set; }
        public string BookName { get; set; } = null!;
        public double? Price { get; set; }
        public string? Author { get; set; }
    }
}
