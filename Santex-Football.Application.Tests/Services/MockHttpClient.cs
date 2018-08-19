using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Moq;
using Moq.Protected;

namespace Santex_Football.Application.Tests.Services
{
    public class MockHttpClient
    {
        public HttpClient GetMockClient(string url)
        {
            var mockHttpMessageHandler = new Mock<HttpMessageHandler>();
            mockHttpMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .Returns((HttpRequestMessage request, CancellationToken cancellationToken) => GetMockResponse(request, cancellationToken, url));
            return new HttpClient(mockHttpMessageHandler.Object);
        }

        private Task<HttpResponseMessage> GetMockResponse(HttpRequestMessage request,
            CancellationToken cancellationToken, string url)
        {
            
            if (request.RequestUri.LocalPath == url)
            {
                var response = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(GetJsonResponse(url), Encoding.UTF8, "application/json")
                };
                return Task.FromResult(response);
            }
            throw new NotImplementedException();
        }

        private string GetJsonResponse(string url)
        {
            if (url.Contains("competition"))
            {
                return FakeApiResponse.Competitions;
            }

            if (url.Contains("Teams"))
            {
                return FakeApiResponse.Teams;
            }
            if (url.Contains("Players"))
            {
                return FakeApiResponse.Players;
            }

            return String.Empty;
            ;
        }
    }
}