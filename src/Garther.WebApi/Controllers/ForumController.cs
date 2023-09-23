using Garther.Domain.UseCases.Forums;
using Microsoft.AspNetCore.Mvc;
using Garther.WebApi.Models;

namespace Garther.WebApi.Controllers;

[ApiController]
[Route("/api/v1/forum/[action]")]
public class ForumController : Controller
{
    private readonly ILogger<ForumController> _logger;

    public ForumController(ILogger<ForumController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Forum.Database.Entities.Forum[]))]
    public async Task<ActionResult> IndexAsync(CancellationToken token, 
        [FromServices] IGetForums forumsUseCase)
    {
        var forums = await forumsUseCase.ExecuteAsync(token);
        return Ok(forums.Select(forum => new ForumModel
        {
            Id = forum.Id,
            Title = forum.Title
        }));
    }
}