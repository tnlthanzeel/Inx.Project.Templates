using FluentValidation.Results;
using Inexis.Clean.Architecture.Template.SharedKernal.Exceptions;
using Inexis.Clean.Architecture.Template.SharedKernal.Models;
using System.Net;
using System.Text.Json.Serialization;

namespace Inexis.Clean.Architecture.Template.SharedKernal.Responses;

public class KeySetResponseResult<T> : BaseResponse
{
    [JsonIgnore]
    public ApplicationException? ApplicationException { get; }

    public KeySetResponseResult(T? value, KeysetPageInfo? paginator = null) : base()
    {
        Success = value is not null;
        Data = value;
        PageInfo = paginator;
    }

    public KeySetResponseResult(IList<ValidationFailure> validationFailures) : base()
    {
        ApplicationException = _badRequestException;
        Success = false;
        Data = default;

        if (validationFailures.Count is not 0)
        {
            Errors.AddRange(validationFailures.Select(s => new KeyValuePair<string, IEnumerable<string>>(s.PropertyName, new[] { s.ErrorMessage })).ToList());
        }
    }

    public KeySetResponseResult(IList<KeyValuePair<string, IEnumerable<string>>> validationFailures) : base()
    {
        ApplicationException = _badRequestException;
        Success = false;
        Data = default;

        if (validationFailures.Count is not 0)
        {
            Errors.AddRange(validationFailures);
        }
    }

    public KeySetResponseResult(ApplicationException ex) : base()
    {
        Success = false;
        Data = default;

        var errorMsg = new[] { ex.Message };

        switch (ex)
        {
            case BadRequestException e:
                ApplicationException = _badRequestException;
                Errors.Add(new KeyValuePair<string, IEnumerable<string>>(e.PropertyName!, errorMsg));
                break;

            case ValidationException e:
                ApplicationException = _badRequestException;
                Errors.AddRange(e.ValdationErrors);
                break;

            case NotFoundException e:
                ApplicationException = _notFoundException;
                Errors.Add(new KeyValuePair<string, IEnumerable<string>>(e.PropertyName!, errorMsg));
                break;

            case OperationFailedException e:
                ApplicationException = _operationFailedException;
                Errors.Add(new KeyValuePair<string, IEnumerable<string>>(e.PropertyName!, errorMsg));
                break;

            case UnauthorizedException:
                ApplicationException = _unauthorizedException;
                Errors.Add(new KeyValuePair<string, IEnumerable<string>>(nameof(HttpStatusCode.Unauthorized), errorMsg));
                break;

        };
    }

    public KeysetPageInfo? PageInfo { get; set; }

    public T? Data { get; private set; }

    [JsonIgnore]
    public override List<KeyValuePair<string, IEnumerable<string>>> Errors { get; init; } = new();

}
