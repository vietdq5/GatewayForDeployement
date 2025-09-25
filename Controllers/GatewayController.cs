using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Gateways.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GatewayController : ControllerBase
{
    private readonly ILogger<GatewayController> _logger;

    public GatewayController(ILogger<GatewayController> logger)
    {
        _logger = logger;
    }

    [HttpGet("status")]
    public IActionResult GetStatus()
    {
        return Ok(new
        {
            Status = "Healthy",
            Timestamp = DateTime.UtcNow,
            Version = "1.0.0"
        });
    }

    [HttpGet("routes")]
    [Authorize]
    public IActionResult GetRoutes()
    {
        var routes = new[]
        {
            new { Service = "Notifications", Path = "/api/notifications", Port = 5001 },
            new { Service = "Todos", Path = "/api/todos", Port = 5002 }
        };

        return Ok(routes);
    }
}