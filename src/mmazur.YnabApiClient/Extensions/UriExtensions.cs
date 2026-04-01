using System.Globalization;
using System.Web;

namespace mmazur.YnabApiClient.Extensions;

internal static class UriExtensions
{
    private static readonly TextInfo TextInfo = CultureInfo.InvariantCulture.TextInfo;

    extension(Uri uri)
    {
        public Uri AppendPath(string path) =>
            uri.IsAbsoluteUri ?
                new Uri(uri, path) :
                new Uri($"{uri.OriginalString.Trim('/')}/{path.Trim('/')}/", UriKind.Relative);

        public Uri AppendQueryParameters(object? queryParameters)
        {
            if (queryParameters is null)
            {
                return uri;
            }

            var query = uri.IsAbsoluteUri
                ? uri.Query
                : uri.OriginalString[(uri.OriginalString.IndexOf('?', StringComparison.Ordinal) + 1)..];
            var nameValueCollection = HttpUtility.ParseQueryString(query);

            foreach (var propertyInfo in queryParameters.GetType().GetProperties())
            {
                var value = propertyInfo.GetValue(queryParameters);

                nameValueCollection[propertyInfo.Name] = value is bool boolValue
                    ? TextInfo.ToLower(boolValue.ToString())
                    : value?.ToString();
            }

            var queryString = nameValueCollection.ToString();

            if (uri.IsAbsoluteUri)
            {
                var uriBuilder = new UriBuilder(uri)
                {
                    Query = queryString
                };

                return uriBuilder.Uri;
            }

            var uriWithoutQuery = uri.OriginalString.Split('?')[0];
            return string.IsNullOrWhiteSpace(queryString)
                ? new Uri(uriWithoutQuery, UriKind.Relative)
                : new Uri($"{uriWithoutQuery}?{queryString}", UriKind.Relative);
        }
    }
}