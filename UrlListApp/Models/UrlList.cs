using System;
using System.Collections.Generic;

namespace UrlListApp.Models
{
    public class UrlList
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string? Title { get; set; }
        public string? CustomUrl { get; set; } // For custom or generated URLs
        public List<UrlItem> Urls { get; set; } = new List<UrlItem>();
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }

    public class UrlItem
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string? Url { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
    }
}
