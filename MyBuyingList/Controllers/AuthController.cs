﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using MyBuyingList.Application.Features.Login.Services;

namespace MyBuyingList.Web.Controllers;
public class AuthController : ApiControllerBase
{
    private ILoginService _loginService;
    public AuthController(ILoginService loginService)
    {
        _loginService = loginService;
    }

    [EnableRateLimiting("Authentication")]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
    [HttpGet, Produces("text/plain")]
    public async Task<IActionResult> Authenticate(string username, string password, CancellationToken token)
    {
        var jwtToken = await _loginService.AuthenticateAndReturnJwtTokenAsync(username, password, token);
        return string.IsNullOrEmpty(jwtToken) ? Unauthorized() : Ok(jwtToken);
    }
}
