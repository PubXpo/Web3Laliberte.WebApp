using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Web3Laliberte.OperationsAPI.Model;

namespace Web3Laliberte.OperationsAPI.Controller;

[Route("api/v1/admin")]
[ApiController]
public class AdminAuthController : ControllerBase
{
    private readonly ILogger<AdminAuthController> _logger;
    private readonly string? _adminPassword;

    public AdminAuthController(ILogger<AdminAuthController> logger)
    {
        _logger = logger;
        _adminPassword = Environment.GetEnvironmentVariable("ADMIN_PASSWORD");
        _logger.LogInformation("AdminPassword from environment: {AdminPassword}", _adminPassword);
    }

    /// <summary>
    ///     Login endpoint for admin users
    /// </summary>
    /// <param name="request"></param>
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] AdminAuth request)
    {
        if (request.Password == _adminPassword) return Ok(new { message = "Login successful" });
        _logger.LogWarning("Invalid password attempt");
        return Unauthorized("Invalid password");
    }
    
}