using QuanLyBida.DTO;
using System;
using System.Collections.Generic;

public class TableBLL
{
    private TableDAL tableDAL = new TableDAL();

    public List<TableDTO> GetAllTables()
    {
        return tableDAL.GetAllTables();
    }

    public bool UpdateTableStatus(int maBan, string trangThai)
    {
        return tableDAL.UpdateTableStatus(maBan, trangThai);
    }

    // THÊM: Cập nhật thời gian bắt đầu
    public bool UpdateStartTime(int maBan, DateTime startTime)
    {
        return tableDAL.UpdateStartTime(maBan, startTime);
    }

    // THÊM: Cập nhật thời gian kết thúc  
    public bool UpdateEndTime(int maBan, DateTime endTime)
    {
        return tableDAL.UpdateEndTime(maBan, endTime);
    }

    // THÊM: Reset thời gian
    public bool ResetTime(int maBan)
    {
        return tableDAL.ResetTime(maBan);
    }
}