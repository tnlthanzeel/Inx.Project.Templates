using Inexis.Clean.Architecture.Template.SharedKernal.Exceptions;
using Inexis.Clean.Architecture.Template.SharedKernal.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Inexis.Clean.Architecture.Template.Api.Controllers;

[ApiController]
public abstract class AppControllerBase : ControllerBase
{
    [ApiExplorerSettings(IgnoreApi = true)]
    protected ObjectResult UnsuccessfullResponse<T>(ResponseResult<T> responseResult)
    {
        return UnsuccessfullResponseHandler(responseResult);
    }

    [ApiExplorerSettings(IgnoreApi = true)]
    protected ObjectResult UnsuccessfullResponse(ResponseResult responseResult)
    {
        return UnsuccessfullResponseHandler(responseResult);
    }

    [ApiExplorerSettings(IgnoreApi = true)]
    private ObjectResult UnsuccessfullResponseHandler<T>(ResponseResult<T> responseResult)
    {
        var groupedErrors = responseResult.Errors.GroupBy(x => x.Key).ToList();

        return BuildResponseResult(responseResult.ApplicationException!, groupedErrors);
    }

    protected ObjectResult UnsuccessfullResponse<T>(KeySetResponseResult<T> responseResult)
    {
        return UnsuccessfullResponseHandler(responseResult);
    }

    [ApiExplorerSettings(IgnoreApi = true)]
    protected ObjectResult UnsuccessfullResponse(KeySetResponseResult responseResult)
    {
        return UnsuccessfullResponseHandler(responseResult);
    }

    [ApiExplorerSettings(IgnoreApi = true)]
    private ObjectResult UnsuccessfullResponseHandler<T>(KeySetResponseResult<T> responseResult)
    {
        var groupedErrors = responseResult.Errors.GroupBy(x => x.Key).ToList();

        return BuildResponseResult(responseResult.ApplicationException!, groupedErrors);
    }

    private ObjectResult BuildResponseResult(ApplicationException exception, List<IGrouping<string, KeyValuePair<string, IEnumerable<string>>>> groupedErrors)
    {
        ErrorResponse errorResponse = new()
        {
            Errors = groupedErrors.Select(s => new KeyValuePair<string, IEnumerable<string>>(s.Key, s.SelectMany(er => er.Value).ToList())).ToList()
        };

        return exception switch
        {
            BadRequestException => BadRequest(errorResponse),
            NotFoundException => NotFound(errorResponse),
            UnauthorizedException => Unauthorized(errorResponse),
            _ => StatusCode(statusCode: StatusCodes.Status500InternalServerError, errorResponse)
        };
    }
}
