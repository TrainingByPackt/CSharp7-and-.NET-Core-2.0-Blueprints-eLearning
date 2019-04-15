using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace AzureFunctionExample
{
    internal class MockedHttpRequest : HttpRequest
    {
        public override QueryString QueryString { get; set; }

        public override Stream Body { get; set; }

        public override string ContentType { get; set; }

        public override long? ContentLength { get; set; }

        public override IRequestCookieCollection Cookies { get; set; }

        public override IHeaderDictionary Headers { get; }

        public override string Protocol { get; set; }

        public override IQueryCollection Query { get; set; }

        public override IFormCollection Form { get; set; }

        public override PathString Path { get; set; }

        public override PathString PathBase { get; set; }

        public override HostString Host { get; set; }

        public override bool IsHttps { get; set; }

        public override string Scheme { get; set; }

        public override string Method { get; set; }

        public override HttpContext HttpContext { get; }

        public override bool HasFormContentType { get; }

        public override Task<IFormCollection> ReadFormAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return null;
        }
    }
}
