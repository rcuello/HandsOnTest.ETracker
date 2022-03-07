namespace HandsOnTest.ETracker.Services.WebApi.Extensions
{
    public static class HttpRequestExtensions
    {
        public static async Task<String> ToRaw(this Microsoft.AspNetCore.Http.HttpRequest request)
        {
            var stream = request.Body;
            var reader = new StreamReader(stream);
            var bodyText = await reader.ReadToEndAsync();
            return bodyText;
        }

        
    }
}
