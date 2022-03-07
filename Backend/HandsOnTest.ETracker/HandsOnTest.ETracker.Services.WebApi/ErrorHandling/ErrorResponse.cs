using HandsOnTest.ETracker.Services.WebApi.Extensions;
using System.Runtime.Serialization;

namespace HandsOnTest.ETracker.Services.WebApi.ErrorHandling
{
    [DataContract]
    public class ErrorResponse
    {

        [DataMember(Name = "message")]
        public String Message { get; set; }

        [DataMember(Name = "detail")]
        public string[] Details { get; set; }

        public ErrorResponse(string message)
        {
            Message = message;
        }

        public static ErrorResponse FromCodeAndMessage(Exception exception, HttpRequest request)
        {
            var message = exception.ToFullMessage();
            var response = new ErrorResponse(message);

            return response;
        }
    }
}
