using System.Globalization;
using System.Web;

namespace mmazur.YnabApiClient.Extensions;

internal static class UriExtensions
{
    private static readonly TextInfo TextInfo = CultureInfo.InvariantCulture.TextInfo;

    public static Uri AppendQueryParameters(this Uri uri, object? queryParameters)
    {
        if (queryParameters is null)
        {
            return uri;
        }

        var uriBuilder = new UriBuilder(uri);
        var nameValueCollection = HttpUtility.ParseQueryString(uriBuilder.Query);

        foreach (var propertyInfo in queryParameters.GetType().GetProperties())
        {
            var value = propertyInfo.GetValue(queryParameters);

            nameValueCollection[propertyInfo.Name] = value is bool boolValue
                ? TextInfo.ToLower(boolValue.ToString())
                : value?.ToString();
        }

        uriBuilder.Query = nameValueCollection.ToString();

        return uriBuilder.Uri;
    }
}