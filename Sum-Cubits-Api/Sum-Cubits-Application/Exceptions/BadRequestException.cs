

using FluentValidation.Results;

namespace Sum_Cubits_Application.Application.Exceptions;

public class BadRequestException : Exception
{
    public BadRequestException()
        : base("The request is not valid.")
    {
    }

    public BadRequestException(string requestName)
        : base($"The request {requestName} is not valid.")
    {
    }

    public BadRequestException(IReadOnlyCollection<ValidationFailure> errors)
        : base(errors.Count != 0 ? errors.First().ErrorMessage : "BadRequest")
    {
    }
}