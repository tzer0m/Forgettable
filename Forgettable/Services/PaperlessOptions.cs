namespace Forgettable.Services
{
    /// <summary>
    /// Settings for connecting to Paperless-ngx.
    /// </summary>
    public class PaperlessOptions
    {
        /// <summary>
        /// The Paperless base URL.
        /// </summary>
        public string BaseUrl { get; set; } = string.Empty;

        /// <summary>
        /// The Paperless API token.
        /// </summary>
        public string Token { get; set; } = string.Empty;
    }
}