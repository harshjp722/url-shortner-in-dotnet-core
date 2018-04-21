using System;
using System.Collections.Generic;

namespace URLShortnerDotnetCore.Models
{
    public partial class ShortUrllog
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public string LongUrl { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
