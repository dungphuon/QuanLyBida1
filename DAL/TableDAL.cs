using QuanLyBida.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

public class TableDAL : DatabaseHelper
{
    public List<TableDTO> GetAllTables()
    {
        var list = new List<TableDTO>();
        using (var conn = GetConnection())
        {
            conn.Open();
            string sql = "SELECT * FROM BanBida";
            using (var cmd = new SqlCommand(sql, conn))
            {
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var table = new TableDTO
                        {
                            MaBan = Convert.ToInt32(reader["MaBan"]),
                            TenBan = reader["TenBan"].ToString(),
                            LoaiBan = reader["LoaiBan"].ToString(),
                            TrangThai = reader["TrangThai"].ToString(),
                            GiaGio = Convert.ToDecimal(reader["GiaGio"])
                        };

                        if (reader["ThoiGianBatDau"] != DBNull.Value)
                            table.ThoiGianBatDau = Convert.ToDateTime(reader["ThoiGianBatDau"]);
                        if (reader["ThoiGianKetThuc"] != DBNull.Value)
                            table.ThoiGianKetThuc = Convert.ToDateTime(reader["ThoiGianKetThuc"]);

                        list.Add(table);
                    }
                }
            }
        }
        return list;
    }

    public bool UpdateTableStatus(int maBan, string trangThai)
    {
        using (var conn = GetConnection())
        {
            conn.Open();
            string sql = "UPDATE BanBida SET TrangThai = @TrangThai WHERE MaBan = @MaBan";
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@TrangThai", trangThai);
                cmd.Parameters.AddWithValue("@MaBan", maBan);
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }

    public bool UpdateStartTime(int maBan, DateTime startTime)
    {
        using (var conn = GetConnection())
        {
            conn.Open();
            string sql = "UPDATE BanBida SET ThoiGianBatDau = @ThoiGianBatDau WHERE MaBan = @MaBan";
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@ThoiGianBatDau", startTime);
                cmd.Parameters.AddWithValue("@MaBan", maBan);
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }

    public bool UpdateEndTime(int maBan, DateTime endTime)
    {
        using (var conn = GetConnection())
        {
            conn.Open();
            string sql = "UPDATE BanBida SET ThoiGianKetThuc = @ThoiGianKetThuc WHERE MaBan = @MaBan";
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@ThoiGianKetThuc", endTime);
                cmd.Parameters.AddWithValue("@MaBan", maBan);
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }

    public bool ResetTime(int maBan)
    {
        using (var conn = GetConnection())
        {
            conn.Open();
            string sql = "UPDATE BanBida SET ThoiGianBatDau = NULL, ThoiGianKetThuc = NULL WHERE MaBan = @MaBan";
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@MaBan", maBan);
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}