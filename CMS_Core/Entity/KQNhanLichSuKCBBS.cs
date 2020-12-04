using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Core.Entity
{
    public class KQNhanLichSuKCBBS
    {
        public string maKetQua { get; set; }
        public string ghiChu { get; set; }
        public string maThe { get; set; }
        public string hoTen { get; set; }
        public string ngaySinh { get; set; }
        public string gioiTinh { get; set; }
        public string diaChi { get; set; }
        public string maDKBD { get; set; }
        public string cqBHXH { get; set; }
        public string gtTheTu { get; set; }
        public string gtTheDen { get; set; }
        public string maKV { get; set; }
        public string ngayDu5Nam { get; set; }
        public string maSoBHXH { get; set; }
        public string maTheCu { get; set; }
        public string maTheMoi { get; set; }
        public string gtTheTuMoi { get; set; }
        public string gtTheDenMoi { get; set; }
        public string maDKBDMoi { get; set; }
        public string tenDKBDMoi { get; set; }
        public List<LichSuKCB2018> dsLichSuKCB2018 { get; set; }
        public List<LichSuKT2018> dsLichSuKT2018 { get; set; }
    }

    public class ApiTheBHYT2018
    {
        public string maThe { get; set; }
        public string hoTen { get; set; }
        public string ngaySinh { get; set; }
    }
    public class LichSuKCB2018
    {
        public string maHoSo { get; set; }
        public string maCSKCB { get; set; }
        public string ngayVao { get; set; }
        public string ngayRa { get; set; }
        public string tenBenh { get; set; }
        public string tinhTrang { get; set; }
        public string kqDieuTri { get; set; }
    }
    public class LichSuKT2018
    {
        public string userKT { get; set; }
        public string ThoiGianKT { get; set; }
        public string thongBao { get; set; }
        public string maLoi { get; set; }
    }
}
