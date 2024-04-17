using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using POS.Infrastructure;

namespace POS.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class HomeController : ControllerBase
{
    private readonly AppOptions _appOptions;

    public HomeController(IOptions<AppOptions> appOptions)
    {
        _appOptions = appOptions.Value;
    }

    [HttpGet]
    public ActionResult Get()
    {
        var appName = _appOptions.Name;
        return Ok(appName);
    }
}
