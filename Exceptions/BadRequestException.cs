using System.Net;

namespace PokeAPIPolytech.Exceptions;

public class BadRequestException : HttpException
{
    public BadRequestException(string message) : base(HttpStatusCode.BadRequest, message)
    {
    }
}