using Npgsql;

namespace Ceii.Api.Data.Extensions;

public static class StringExtensions
{
    public static string BuildConnectionString(this string str)
    {
        var databaseUri = new Uri(str);
        var userInfo = databaseUri.UserInfo.Split(':');

        var builder = new NpgsqlConnectionStringBuilder
        {
            Host = databaseUri.Host,
            Port = databaseUri.Port,
            Username = userInfo[0],
            Password = userInfo[1],
            Database = databaseUri.LocalPath.TrimStart('/')
        };

        return builder.ToString();
    }
}