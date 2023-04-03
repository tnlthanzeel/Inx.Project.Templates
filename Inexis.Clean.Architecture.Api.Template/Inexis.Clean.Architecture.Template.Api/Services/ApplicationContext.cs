using Inexis.Clean.Architecture.Template.SharedKernal.Extensions;
using Inexis.Clean.Architecture.Template.SharedKernal.Interfaces;

namespace Inexis.Clean.Architecture.Template.Api.Services;

public sealed class ApplicationContext : IApplicationContext
{
    private readonly IWebHostEnvironment _webHostEnvironment;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public ApplicationContext(IWebHostEnvironment webHostEnvironment, IHttpContextAccessor httpContextAccessor)
    {
        _webHostEnvironment = webHostEnvironment;
        _httpContextAccessor = httpContextAccessor;
    }

    public string BaseUrl
    {
        get
        {

            var baseUrl = _webHostEnvironment.IsDevelopment() ? _httpContextAccessor.HttpContext?.Request.BaseUrl() :
                                                           _httpContextAccessor.HttpContext?.Request.BaseUrl();

            return baseUrl!;
        }
    }
}
