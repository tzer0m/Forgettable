using Microsoft.Extensions.Options;
using System.Net.Http.Headers;

namespace Forgettable.Services
{
    /// <summary>
    /// Talks to the Paperless-ngx API.
    /// </summary>
    /// <param name="http">The HTTP client.</param>
    /// <param name="options">The Paperless settings.</param>
    public class PaperlessClient(HttpClient http, IOptions<PaperlessOptions> options)
    {
        /// <summary>
        /// Returns the link to a document in the Paperless web UI.
        /// </summary>
        /// <param name="id">The document ID.</param>
        public string GetDocumentUrl(int id)
        {
            return $"{options.Value.BaseUrl.TrimEnd('/')}/documents/{id}/details";
        }

        /// <summary>
        /// Downloads a document's thumbnail, or null if it can't be found.
        /// </summary>
        /// <param name="id">The document ID.</param>
        public async Task<byte[]?> GetThumbnailAsync(int id)
        {
            using HttpRequestMessage request = new(HttpMethod.Get, $"{options.Value.BaseUrl.TrimEnd('/')}/api/documents/{id}/thumb/");
            request.Headers.Authorization = new AuthenticationHeaderValue("Token", options.Value.Token);
            using HttpResponseMessage response = await http.SendAsync(request);
            return response.IsSuccessStatusCode ? await response.Content.ReadAsByteArrayAsync() : null;
        }
    }
}