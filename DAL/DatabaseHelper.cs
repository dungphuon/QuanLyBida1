using System;
using System.Data.SqlClient;

public class DatabaseHelper
{
    // DÙNG SQL SERVER EXPRESS
    private static string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=QuanLyBida;Integrated Security=True";

    public static SqlConnection GetConnection()
    {
        return new SqlConnection(connectionString);
    }

    public static bool TestConnection()
    {
        try
        {
            using (var conn = GetConnection())
            {
                conn.Open();
               
                return true;
            }
        }
        catch (Exception ex)
        {
            throw new Exception($"❌ Lỗi kết nối: {ex.Message}\n\nConnection String: {connectionString}");
        }

    }
}