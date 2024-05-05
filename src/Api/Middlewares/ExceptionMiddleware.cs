using System.Net;
using System.Text.Json;
using Application.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace Api.Middlewares;

public class ExceptionMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);

        }
        catch (Exception error)
        {
            Console.WriteLine("Catch");

            ProblemDetails problem = new();
            context.Response.ContentType = "application/json";

            switch (error)
            {
                case NotFoundException:
                    context.Response.StatusCode = (int) HttpStatusCode.NotFound;
                    problem.Status = (int) HttpStatusCode.NotFound;
                    problem.Detail = error.Message;
                    
                    break;

                default:
                    // unhandled error
                    context.Response.StatusCode = (int) HttpStatusCode.InternalServerError;
                    problem.Status = (int) HttpStatusCode.NotFound;
                    problem.Detail = error.Message;

                    break;
            }

            var result = JsonSerializer.Serialize(problem);
            await context.Response.WriteAsync(result);
            
        }
    }
}