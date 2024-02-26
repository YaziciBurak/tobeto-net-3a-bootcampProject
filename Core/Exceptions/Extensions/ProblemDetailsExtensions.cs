﻿using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Core.Exceptions.Extensions;

public static class ProblemDetailsExtensions
{
    public static string AsJson<TProblemDetail>(this TProblemDetail problemDetail)
        where TProblemDetail : ProblemDetails => JsonSerializer.Serialize(problemDetail);
}