using System.Net;

namespace Kobold.TodoApp.Api.Dtos
{
    public class ResponseDto
    {
        public HttpStatusCode StatusCode { get; set; }
        public object Response { get; set; }

        public static ResponseDto ReturnStatusCode(HttpStatusCode statusCode, object response)
        {
            return new ResponseDto()
            {
                StatusCode = statusCode,
                Response = response
            };
        }
        public static ResponseDto Ok(object response)
        {
            return ReturnStatusCode(HttpStatusCode.OK, response);
        }

        public static ResponseDto InternalServerError(object response)
        {
            return ReturnStatusCode(HttpStatusCode.InternalServerError, response);
        }

        public static ResponseDto NotFoundException(object response)
        {
            return ReturnStatusCode(HttpStatusCode.NotFound, response);
        }
    }
}
