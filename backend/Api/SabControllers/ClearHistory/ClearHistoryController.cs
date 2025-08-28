using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NzbWebDAV.Api.SabControllers;
using NzbWebDAV.Config;
using NzbWebDAV.Database;

namespace NzbWebDAV.Api.SabControllers.ClearHistory;

public class ClearHistoryController(
    HttpContext httpContext,
    DavDatabaseClient dbClient,
    ConfigManager configManager
) : SabApiController.BaseController(httpContext, configManager)
{
    public async Task<SabBaseResponse> ClearHistory()
    {
        await dbClient.ClearHistoryAsync();
        return new SabBaseResponse() { Status = true };
    }

    protected override async Task<IActionResult> Handle()
    {
        return Ok(await ClearHistory());
    }
}
