using Microsoft.AspNetCore.Http;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System;
using MovieCatalog.Infrastructure.Repository;
using MovieCatalog.Domain.Model;
using System.Diagnostics;

namespace MovieCatalog.Application.Api.Middleware
{
    public class RequestProcessingMiddleware
    {
        private readonly RequestDelegate _next;
        public RequestProcessingMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context, IAdminRepository adminRepository)
        {
            var stopwatch = new Stopwatch();
            var originalBodyStream = context.Response.Body;
            var request = await GetRequestAsTextAsync(context.Request);
            await using var responseBody = new MemoryStream();
            context.Response.Body = responseBody;

            stopwatch.Start();
            await _next(context);
            stopwatch.Stop();

            var response = await GetResponseAsTextAsync(context.Response);
            await responseBody.CopyToAsync(originalBodyStream);

            if (request.Contains("api/Movie/"))
            { 
                var searchRequest = new MovieSearch()
                {
                    SearchToken = context.Request.Query["title"].ToString(),
                    ImdbID = "",//extract value from response jsonString
                    ProcessingTimeMs = stopwatch.ElapsedMilliseconds,
                    TimeStamp = DateTime.Now,
                    IpAddress = context.Connection.RemoteIpAddress.ToString()
                };
                await adminRepository.AddMovieSearchAsync(searchRequest);
            }
        }

        private async Task<string> GetRequestAsTextAsync(HttpRequest request)
        {
            var body = request.Body;
            request.EnableBuffering();
            var buffer = new byte[Convert.ToInt32(request.ContentLength)];
            await request.Body.ReadAsync(buffer, 0, buffer.Length);
            var bodyAsText = Encoding.UTF8.GetString(buffer);
            request.Body = body;
            return $"{request.Scheme} {request.Host}{request.Path} {request.QueryString} {bodyAsText}";
        }

        private async Task<string> GetResponseAsTextAsync(HttpResponse response)
        {
            response.Body.Seek(0, SeekOrigin.Begin);
            var text = await new StreamReader(response.Body).ReadToEndAsync();
            response.Body.Seek(0, SeekOrigin.Begin);
            return text;
        }


    }
}
