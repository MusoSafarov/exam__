using Npgsql;

namespace Infrastructure.Data;

public static class Database
{
    private static string connection = "Host=localhost;Port=5432;Database=exam3;Username=postgres;Password=1234";
    public static NpgsqlConnection Connection()=> new NpgsqlConnection(connection);
}
