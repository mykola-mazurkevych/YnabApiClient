using System.Globalization;
using System.Reflection;
using System.Web;
using System.Collections.Concurrent;

namespace mmazur.YnabApiClient.Extensions;

internal static class UriExtensions
{
    private const string DateOnlyFormat = "yyyy-MM-dd";

    private static readonly TextInfo TextInfo = CultureInfo.InvariantCulture.TextInfo;
    private static readonly ConcurrentDictionary<Type, PropertyInfo[]> QueryParameterPropertiesCache = new();

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

            var propertyInfos = QueryParameterPropertiesCache.GetOrAdd(
                queryParameters.GetType(),
                static type => type.GetProperties(BindingFlags.Instance | BindingFlags.Public));

            foreach (var propertyInfo in propertyInfos)
            {
                var value = propertyInfo.GetValue(queryParameters);

                nameValueCollection[propertyInfo.Name] =
                    value switch
                    {
                        null => null,
                        bool boolValue => TextInfo.ToLower(boolValue.ToString()),
                        DateOnly dateOnlyValue => dateOnlyValue.ToString(DateOnlyFormat, CultureInfo.InvariantCulture),
                        _ => value.ToString()
                    };
            }

            var queryString = nameValueCollection.ToString();

            if (uri.IsAbsoluteUri)
            {
                var uriBuilder = new UriBuilder(uri) { Query = queryString };

                return uriBuilder.Uri;
            }

            var uriWithoutQuery = uri.OriginalString.Split('?')[0];
            return string.IsNullOrWhiteSpace(queryString)
                ? new Uri(uriWithoutQuery, UriKind.Relative)
                : new Uri($"{uriWithoutQuery}?{queryString}", UriKind.Relative);
        }
    }
}