using System.Web;

namespace mmazur.YnabApiClient.Extensions;

internal static class UriExtensions
{
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
            nameValueCollection[propertyInfo.Name] = propertyInfo.GetValue(queryParameters)?.ToString();
        }

        uriBuilder.Query = nameValueCollection.ToString();

        return uriBuilder.Uri;
    }
}