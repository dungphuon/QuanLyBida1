using System;
using System.Data.SqlClient;

public class DatabaseHelper
{
    // Biến tĩnh lưu chuỗi kết nối (được nạp từ Program.cs hoặc FormCauHinh)
    private static string _connectionString = "";

    // Hàm để nạp chuỗi kết nối mới
    public static void SetConnectionString(string connStr)
    {
        _connectionString = connStr;
    }

    public static SqlConnection GetConnection()
    {
        // Nếu chưa có chuỗi kết nối, trả về chuỗi rỗng để tránh lỗi null
        return new SqlConnection(_connectionString);
    }

    // Hàm kiểm tra kết nối (Dùng cho cả Program.cs và FormCauHinh)
    // Trả về true nếu kết nối OK, false nếu thất bại
    public static bool TestConnection(string connStrToTest = null)
    {
        // Nếu không truyền tham số, dùng chuỗi hiện tại
        string connStr = connStrToTest ?? _connectionString;

        if (string.IsNullOrEmpty(connStr)) return false;

        try
        {
            using (var conn = new SqlConnection(connStr))
            {
                conn.Open();
                return true; // Kết nối thành công
            }
        }
        catch
        {
            return false; // Kết nối thất bại
        }
    }
}