using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FirstWebAPI.Filters
{
    public class CustomExceptionFilter:IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var ex=context.Exception;
            var path="log.txt";

            File.AppendAllText(path,$"[{DateTime.Now}] {ex.Message} {Environment.NewLine}");

            context.Result=new ObjectResult("An error occurred. Check log.")
            {
                StatusCode=500
            };
        }
    }
}
