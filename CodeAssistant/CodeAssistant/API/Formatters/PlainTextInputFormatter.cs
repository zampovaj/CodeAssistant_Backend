using Microsoft.AspNetCore.Mvc.Formatters;
using System.Text;
using System.Threading.Tasks;

namespace CodeAssistant.API.Formatters
{
    /// <summary>
    /// A custom input formatter that enables ASP.NET Core to read plain text (text/plain) request bodies.
    /// </summary>
    public class PlainTextInputFormatter : TextInputFormatter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PlainTextInputFormatter"/> class,
        /// registering support for UTF-8 and Unicode plain text content.
        /// </summary>
        public PlainTextInputFormatter()
        {
            SupportedMediaTypes.Add("text/plain");
            SupportedEncodings.Add(Encoding.UTF8);
            SupportedEncodings.Add(Encoding.Unicode);
        }

        /// <summary>
        /// Determines whether the formatter can read the specified type.
        /// </summary>
        /// <param name="type">The type of the object to read.</param>
        /// <returns>True if the type is <see cref="string"/>; otherwise, false.</returns>
        protected override bool CanReadType(Type type)
        {
            return type == typeof(string);
        }

        /// <summary>
        /// Asynchronously reads the plain text body from the request and returns it as a string.
        /// </summary>
        /// <param name="context">The formatter context.</param>
        /// <param name="encoding">The text encoding to use.</param>
        /// <returns>A task that represents the asynchronous read operation.</returns>
        public override async Task<InputFormatterResult> ReadRequestBodyAsync(InputFormatterContext context, Encoding encoding)
        {
            var request = context.HttpContext.Request;
            using var reader = new StreamReader(request.Body, encoding);
            var content = await reader.ReadToEndAsync();
            return await InputFormatterResult.SuccessAsync(content);
        }
    }

}
