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

    public async Task<IActionResult> Index(int id=1)
    {
        // allow view to access page number
        ViewBag.Id = id;

        // query and pass paginated entries to view
        var limit = 10;
        var skip = limit * (id - 1);
        var builder = QueryBuilder<BlogPost>.New.Skip(skip).Limit(limit);
        var posts = await _client.GetEntries<BlogPost>(builder);
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
