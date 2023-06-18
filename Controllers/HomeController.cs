using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SierraPainters.Models;
using Contentful.Core;
using Contentful.Core.Search;

namespace SierraPainters.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    private readonly IContentfulClient _client;

    public HomeController(ILogger<HomeController> logger, IContentfulClient client)
    {
        _logger = logger;
        _client = client;
    }

    public async Task<IActionResult> Index()
    {
        var posts = await _client.GetEntries<BlogPost>();
        return View(posts);
    }

    public async Task<IActionResult> Posts(string id)
    {
        var queryBuilder = QueryBuilder<BlogPost>.New.ContentTypeIs("blogPost").FieldMatches("fields.slug",id);
        var posts = await _client.GetEntries<BlogPost>(queryBuilder);
        return View(posts);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
