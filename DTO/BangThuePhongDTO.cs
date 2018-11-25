using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class BangThuePhongDTO
    {
        private string _id;
        private string _idPhong;
        private string _idNhanVien;
        private string _idKhachHang;
        private DateTime _checkIn;
        private DateTime _checkOut;
        private string _tienDatCoc;
        private string _trangThai;

        public string Id { get => _id; set => _id = value; }
        public string IdPhong { get => _idPhong; set => _idPhong = value; }
        public string IdNhanVien { get => _idNhanVien; set => _idNhanVien = value; }
        public string IdKhachHang { get => _idKhachHang; set => _idKhachHang = value; }
        public DateTime CheckIn { get => _checkIn; set => _checkIn = value; }
        public DateTime CheckOut { get => _checkOut; set => _checkOut = value; }
        public string TienDatCoc { get => _tienDatCoc; set => _tienDatCoc = value; }
        public string TrangThai { get => _trangThai; set => _trangThai = value; }
    }
}
