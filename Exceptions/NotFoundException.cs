﻿using System.Net;

namespace PokeAPIPolytech.Exceptions;

public class NotFoundException : HttpException
{
    public NotFoundException(string message) : base(HttpStatusCode.NotFound, message)
    {
    }
}