using Contentful.Core.Models;

namespace SierraPainters.Models;

public class BlogPost
{
    public SystemProperties Sys { get; set; }
    public string Title { get; set; }
    public string Slug { get; set; }
    public Document Body { get; set; }
}