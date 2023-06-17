using Contentful.Core.Models;

namespace SierraPainters.Models;

public class BlogPost
{
    public string Title { get; set; }
    public Document Body { get; set; }
}